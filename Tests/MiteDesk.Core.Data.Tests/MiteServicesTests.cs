using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data.Tests
{
    [TestClass]
    public class MiteServicesTests
    {

        private MiteServices Repository;

        [TestInitialize]
        public void Setup()
        {
            var mockRepository = new MockRepository();
            var configurationService = mockRepository.DynamicMock<IConfigurationService>();
            using (mockRepository.Record())
            {
                Expect.Call(configurationService.GetAppSettings()).Return(new AppSettings { AccountName = "win", Email = "bandt@69grad.de", Password = "winmite" }).Repeat.Any();
            }
            Repository = new MiteServices(configurationService);
        }

        [TestMethod]
        public void GetAllActiveActivities_liefert_alle_aktiven_Leistungen_zurück()
        {
            // 3 Leistungen, 13.07.2009
            var result = Repository.GetAllActiveActivities();
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetAllArchivedActivities_liefert_eine_Liste_aller_archivierten_Leistungen_zurück()
        {
            // 1 archivierte Leistung, 17.08.2009
            var result = Repository.GetAllArchivedActivities();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetActivityByID_liefert_eine_bestimmte_Leistung_anhand_ihrer_ID_zurück()
        {
            // 76072, Entwickeln, 17.08.2009
            var result = Repository.GetActivityByID(76072);
            Assert.IsNotNull(result);
            Assert.AreEqual("Entwickeln", result.Name);
        }

        [TestMethod]
        public void UpdateActivity_aktualisiert_eine_Leistung_in_der_Mite_Datenbank()
        {

            // 76072, Entwickeln, 17.08.2009
            var id = 76072;
            var note = Guid.NewGuid().ToString();

            var activity = Repository.GetActivityByID(id);

            Assert.AreNotEqual(note, activity.Note);

            activity.Note = note;
            Repository.UpdateActivity(activity);

            activity = Repository.GetActivityByID(id);
            Assert.AreEqual(note, activity.Note);

        }

        [TestMethod]
        public void DeleteActivity_löscht_eine_Leistung_anhand_ihrer_ID_aus_der_mite_Datenbank()
        {

            var activity = new Activity();
            activity.Note = Guid.NewGuid().ToString();
            activity.Name = Guid.NewGuid().ToString();

            Repository.CreateActivity(activity);

            var result = Repository.GetAllActiveActivities().SingleOrDefault(c => c.Name == activity.Name);

            Assert.IsNotNull(result);
            Repository.DeleteActivity(result.ID);

            Exception exception = null;
            try
            {
                Repository.GetActivityByID(result.ID);
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(MiteConnectorException));
            Assert.IsTrue(exception.Message.IndexOf("404") > -1);

        }

        [TestMethod]
        public void CreateActivity_legt_eine_neue_Leistung_in_der_Mite_Datenbank_an()
        {

            var activity = new Activity();
            activity.Note = Guid.NewGuid().ToString();
            activity.Name = Guid.NewGuid().ToString();

            Repository.CreateActivity(activity);

            var result = Repository.GetAllActiveActivities().SingleOrDefault(c => c.Name == activity.Name);

            Assert.IsNotNull(result);
            Assert.AreEqual(activity.Note, result.Note);

            Repository.DeleteActivity(result.ID);

        }

    }
}
