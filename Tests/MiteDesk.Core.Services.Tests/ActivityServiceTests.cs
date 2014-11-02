using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services.Tests
{
    [TestClass]
    public class ActivityServiceTests
    {

        #region Setup

        private ActivityService ActivityService;
        private MockRepository MockRepository;
        private IActivityRepository ActivityRepository;

        [TestInitialize]
        public void Setup()
        {

            MockRepository = new MockRepository();
            ActivityRepository = MockRepository.DynamicMock<IActivityRepository>();
            ActivityService = new ActivityService(ActivityRepository);

            using (MockRepository.Record())
            {
                Expect.Call(ActivityRepository.GetAllActiveActivities()).Return(new List<Activity>(new[] { new Activity(), new Activity() })).Repeat.Any();
                Expect.Call(ActivityRepository.GetAllArchivedActivities()).Return(new List<Activity>(new[] { new Activity() })).Repeat.Any();
                Expect.Call(ActivityRepository.GetActivityByID(1234)).Return(new Activity() { ID = 1234 }).Repeat.Any();
            }

        }

        #endregion

        [TestMethod]
        public void GetAllActiveActivities_liefert_eine_Liste_aller_aktiven_Leistungen()
        {
            var result = ActivityService.GetAllActiveActivities();
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetAllArchivedActivities_liefert_alle_archivierten_Leistungen_aus_dem_ActivityRepository()
        {
            var result = ActivityService.GetAllArchivedActivities();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void DeleteActivity_ruft_das_Repository_zum_Löschen_der_gewählten_Leistung_auf()
        {
            ActivityService.DeleteActivity(123456);
            ActivityRepository.AssertWasCalled(r => r.DeleteActivity(123456));
        }

        [TestMethod]
        public void GetActivityByID_liefert_eine_bestimmte_Leistung_aus_dem_Repository_anhand_ihrer_ID()
        {
            var result = ActivityService.GetActivityByID(1234);
            Assert.IsNotNull(result);
            Assert.AreEqual(1234, result.ID);
        }

        [TestMethod]
        public void CreateActivity_liefert_einen_Fehler_wenn_der_Name_einer_Leistung_nicht_angegeben_wurde()
        {
            var activity = new Activity { Name = "" };
            var result = ActivityService.CreateActivity(activity, "");
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        [TestMethod]
        public void CreateActivity_liefert_keinen_Fehler_wenn_alles_okay()
        {
            var activity = new Activity { Name = "Testleistung" };
            var result = ActivityService.CreateActivity(activity, "");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CreateActivity_speichert_die_Leistung_im_Repository_wenn_alles_okay()
        {
            var activity = new Activity { Name = "Testleistung" };
            ActivityService.CreateActivity(activity, "");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(activity));
        }

        [TestMethod]
        public void CreateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_25_komma_50_2550_ans_Repository()
        {
            var activity = new Activity { Name = "OK" };
            ActivityService.CreateActivity(activity, "25,50");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(new Activity { Name = "OK", HourlyRate = 2550 }));
        }

        [TestMethod]
        public void CreateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_25__komma_r_2500_ans_Repository()
        {
            var activity = new Activity { Name = "OK" };
            ActivityService.CreateActivity(activity, "25,r");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(new Activity { Name = "OK", HourlyRate = 2500 }));
        }

        [TestMethod]
        public void CreateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_25__komma_799_2580_ans_Repository()
        {
            var activity = new Activity { Name = "OK" };
            ActivityService.CreateActivity(activity, "25,799");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(new Activity { Name = "OK", HourlyRate = 2580 }));
        }

        [TestMethod]
        public void CreateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_r_komma_50_50_ans_Repository()
        {
            var activity = new Activity { Name = "OK" };
            ActivityService.CreateActivity(activity, "r,50");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(new Activity { Name = "OK", HourlyRate = 50 }));
        }

        [TestMethod]
        public void CreateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_einem_Leerstring_0_ans_Repository()
        {
            var activity = new Activity { Name = "OK" };
            ActivityService.CreateActivity(activity, "");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(new Activity { Name = "OK", HourlyRate = 0 }));
        }

        [TestMethod]
        public void CreateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_100_10000_ans_Repository()
        {
            var activity = new Activity { Name = "OK" };
            ActivityService.CreateActivity(activity, "100");
            ActivityRepository.AssertWasCalled(r => r.CreateActivity(new Activity { Name = "OK", HourlyRate = 10000 }));
        }

        [TestMethod]
        public void UpdateActivity_liefert_einen_Fehler_wenn_der_Name_der_Leistung_nicht_angegeben_wurde()
        {
            var activity = new Activity { ID = 3, Name = "" };
            var result = ActivityService.UpdateActivity(activity, "");
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        [TestMethod]
        public void UpdateActivity_wirft_eine_ArgumentException_wenn_die_ID_der_Leistung_nicht_angegeben_wurde()
        {
            Exception exception = null;
            var activity = new Activity { ID = 0 };
            try
            {
                ActivityService.UpdateActivity(activity, "");
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        }

        [TestMethod]
        public void UpdateActivity_liefert_keinen_Fehler_wenn_alles_okay()
        {
            var activity = new Activity { ID = 3, Name = "Testleistung" };
            var result = ActivityService.UpdateActivity(activity, "");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void UpdateActivity_speichert_die_Leistung_im_Repository_wenn_alles_okay()
        {
            var activity = new Activity { ID = 3, Name = "Testleistung" };
            ActivityService.UpdateActivity(activity, "");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(activity));
        }

        [TestMethod]
        public void UpdateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_25_komma_50_2550_ans_Repository()
        {
            var activity = new Activity { ID = 3, Name = "OK" };
            ActivityService.UpdateActivity(activity, "25,50");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(new Activity { ID = 3, Name = "OK", HourlyRate = 2550 }));
        }

        [TestMethod]
        public void UpdateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_25__komma_r_2500_ans_Repository()
        {
            var activity = new Activity { ID = 3, Name = "OK" };
            ActivityService.UpdateActivity(activity, "25,r");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(new Activity { ID = 3, Name = "OK", HourlyRate = 2500 }));
        }

        [TestMethod]
        public void UpdateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_r_komma_50_50_ans_Repository()
        {
            var activity = new Activity { ID = 3, Name = "OK" };
            ActivityService.UpdateActivity(activity, "r,50");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(new Activity { ID = 3, Name = "OK", HourlyRate = 50 }));
        }

        [TestMethod]
        public void UpdateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_einem_Leerstring_0_ans_Repository()
        {
            var activity = new Activity { ID = 3, Name = "OK" };
            ActivityService.UpdateActivity(activity, "");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(new Activity { ID = 3, Name = "OK", HourlyRate = 0 }));
        }

        [TestMethod]
        public void UpdateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_100_10000_ans_Repository()
        {
            var activity = new Activity { ID = 3, Name = "OK" };
            ActivityService.UpdateActivity(activity, "100");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(new Activity { ID = 3, Name = "OK", HourlyRate = 10000 }));
        }

        [TestMethod]
        public void UpdateActivity_übergibt_als_Stundensatz_bei_Eingabe_von_25__komma_799_2580_ans_Repository()
        {
            var activity = new Activity { ID = 3, Name = "OK" };
            ActivityService.UpdateActivity(activity, "25,799");
            ActivityRepository.AssertWasCalled(r => r.UpdateActivity(new Activity { ID = 3, Name = "OK", HourlyRate = 2580 }));
        }

    }
}
