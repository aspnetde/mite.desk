using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services.Tests
{
    [TestClass]
    public class TimeEntryServiceTests
    {

        #region Setup

        private ITimeEntryService TimeEntryService;
        private MockRepository MockRepository;
        private ITimeEntryRepository TimeEntryRepository;

        [TestInitialize]
        public void Setup()
        {

            MockRepository = new MockRepository();

            TimeEntryRepository  = MockRepository.DynamicMock<ITimeEntryRepository>();
            IProjectRepository projectRepository = MockRepository.DynamicMock<IProjectRepository>();
            IActivityRepository activityRepository = MockRepository.DynamicMock<IActivityRepository>();

            TimeEntryService = new TimeEntryService(TimeEntryRepository, new ProjectService(projectRepository), new ActivityService(activityRepository));

            using (MockRepository.Record())
            {
                Expect.Call(projectRepository.GetAllActiveProjects()).Return(new List<Project>(new[] { new Project(), new Project { ID = 2 } })).Repeat.Any();
                Expect.Call(activityRepository.GetAllActiveActivities()).Return(new List<Activity>(new[] { new Activity(), new Activity { ID = 2 } })).Repeat.Any();
                Expect.Call(TimeEntryRepository.GetTimeEntryByID(15)).Return(new TimeEntry { ID = 15 }).Repeat.Any();
                Expect.Call(TimeEntryRepository.GetTimeEntryCurrentlyTrackedByStopwatch()).Return(new TimeEntry { ID = 34 }).Repeat.Any();
                Expect.Call(TimeEntryRepository.GetTimeEntriesByDate(new DateTime(2009, 7, 14))).Return(new List<TimeEntry>(new [] { new TimeEntry(), new TimeEntry(),  new TimeEntry() })).Repeat.Any();
                Expect.Call(TimeEntryRepository.GetTimeEntriesByActivityID(35)).Return(new List<TimeEntry>(new[] { new TimeEntry(), new TimeEntry(), })).Repeat.Any();
                Expect.Call(TimeEntryRepository.GetTimeEntriesByProjectID(2)).Return(new List<TimeEntry>(new[] { new TimeEntry(), new TimeEntry(), })).Repeat.Any();
                Expect.Call(TimeEntryService.GetTimeEntryDatesByRange(new DateTime(2009, 8, 1), new DateTime(2009, 8, 15), 18352)).Return(new List<DateTime>(new[] { new DateTime(2009, 8, 1), new DateTime(2009, 8, 12) }));
            }

        }
        
        #endregion

        [TestMethod]
        public void CreateTimeEntry_liefert_einen_Fehler_wenn_die_ProjektID_nicht_in_der_Liste_der_verfügbaren_Projekte_vorhanden_ist()
        {
            var entry = new TimeEntry { ProjectID = -1 };
            var result = TimeEntryService.CreateTimeEntry(ref entry, "");
            Assert.IsTrue(result.ContainsKey("ProjectID"));
        }

        [TestMethod]
        public void CreateTimeEntry_liefert_einen_Fehler_wenn_die_ActivityID_nicht_in_der_Liste_der_verfügbaren_Leistungen_vorhanden_ist()
        {
            var entry = new TimeEntry { ActivityID = -1 };
            var result = TimeEntryService.CreateTimeEntry(ref entry, "");
            Assert.IsTrue(result.ContainsKey("ActivityID"));
        }

        [TestMethod]
        public void CreateTimeEntry_liefert_einen_Fehler_wenn_das_Datum_nicht_angegeben_ist()
        {
            var entry = new TimeEntry();
            var result = TimeEntryService.CreateTimeEntry(ref entry, "");
            Assert.IsTrue(result.ContainsKey("Date"));
        }

        [TestMethod]
        public void CreateTimeEntry_liefert_einen_Fehler_wenn_die_Zeit_nicht_korrekt_formatiert_ist()
        {
            var entry = new TimeEntry();
            var result = TimeEntryService.CreateTimeEntry(ref entry, "ccxc");
            Assert.IsTrue(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void CreateTimeEntry_übergibt_den_neuen_TimeEntry_ans_Repository_wenn_Validierung_erfolgreich()
        {
            var entry = new TimeEntry { ActivityID = 2, Date = DateTime.Now, Minutes = 30, ProjectID = 2 };
            TimeEntryService.CreateTimeEntry(ref entry, "1:30");
            TimeEntryRepository.AssertWasCalled(r => r.CreateTimeEntry(ref entry));
        }

        [TestMethod]
        public void GetTimeEntriesByDate_liefert_alle_Einträge_zu_einem_Datum()
        {
            var result = TimeEntryService.GetTimeEntriesByDate(new DateTime(2009, 7, 14));
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetTimeEntriesByActivityID_liefert_alle_Einträge_zu_einer_leistung()
        {
            var result = TimeEntryService.GetTimeEntriesByActivityID(35);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTimeEntriesByProjectID_liefert_alle_Einträge_zu_einem_Projekt()
        {
            var result = TimeEntryService.GetTimeEntriesByProjectID(2);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTimeEntryByID_liefert_einen_bestimmten_Eintrag_anhand_seiner_ID()
        {
            var result = TimeEntryService.GetTimeEntryByID(15);
            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.ID);
        }

        [TestMethod]
        public void DeleteTimeEntry_ruft_das_Repository_zum_Löschen_des_gewählten_Eintrags_auf()
        {
            TimeEntryService.DeleteTimeEntry(34);
            TimeEntryRepository.AssertWasCalled(r => r.DeleteTimeEntry(34));
        }

        [TestMethod]
        public void UpdateTimeEntry_liefert_einen_Fehler_wenn_die_ProjektID_nicht_in_der_Liste_der_verfügbaren_Projekte_vorhanden_ist()
        {
            var entry = new TimeEntry { ProjectID = -1 };
            var result = TimeEntryService.UpdateTimeEntry(entry, "");
            Assert.IsTrue(result.ContainsKey("ProjectID"));
        }

        [TestMethod]
        public void UpdateTimeEntry_liefert_einen_Fehler_wenn_die_ActivityID_nicht_in_der_Liste_der_verfügbaren_Leistungen_vorhanden_ist()
        {
            var entry = new TimeEntry { ActivityID = -1 };
            var result = TimeEntryService.UpdateTimeEntry(entry, "");
            Assert.IsTrue(result.ContainsKey("ActivityID"));
        }

        [TestMethod]
        public void UpdateTimeEntry_liefert_einen_Fehler_wenn_das_Datum_nicht_angegeben_ist()
        {
            var entry = new TimeEntry();
            var result = TimeEntryService.UpdateTimeEntry(entry, "");
            Assert.IsTrue(result.ContainsKey("Date"));
        }

        [TestMethod]
        public void UpdateTimeEntry_liefert_einen_Fehler_wenn_die_Zeit_nicht_korrekt_formatiert_ist()
        {
            var entry = new TimeEntry();
            var result = TimeEntryService.UpdateTimeEntry(entry, "ccxc");
            Assert.IsTrue(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void UpdateTimeEntry_übergibt_den_neuen_TimeEntry_ans_Repository_wenn_Validierung_erfolgreich()
        {
            var entry = new TimeEntry { ActivityID = 2, Date = DateTime.Now, Minutes = 30, ProjectID = 2 };
            TimeEntryService.UpdateTimeEntry(entry, "1:30");
            TimeEntryRepository.AssertWasCalled(r => r.UpdateTimeEntry(entry));
        }

        [TestMethod]
        public void StartStopwatch_ruft_StartStopwatch_im_Repository_für_die_übergebene_ID_auf()
        {
            TimeEntryService.StartStopwatch(456);
            TimeEntryRepository.AssertWasCalled(r => r.StartStopwatch(456));
        }

        [TestMethod]
        public void StopStopwatch_ruft_StopStopwatch_im_Repository_für_die_übergebene_ID_auf()
        {
            TimeEntryService.StopStopwatch(456);
            TimeEntryRepository.AssertWasCalled(r => r.StopStopwatch(456));
        }

        [TestMethod]
        public void GetTimeEntryCurrentlyTrackedByStopwatch_liefert_den_Zeiteintrag_aus_dem_Repository_der_gerade_gestoppt_wird()
        {
            var result = TimeEntryService.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.IsNotNull(result);
            Assert.AreEqual(34, result.ID);
        }

        [TestMethod]
        public void GetTimeEntryDatesByRange_liefert_eine_Liste_von_Dates_in_einem_bestimmten_Datums_bereich()
        {
            var result = TimeEntryService.GetTimeEntryDatesByRange(new DateTime(2009, 8, 1), new DateTime(2009, 8, 15), 18352);
            Assert.AreEqual(new DateTime(2009, 8, 1), result[0]);
            Assert.AreEqual(new DateTime(2009, 8, 12), result[1]);
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format1()
        {
            // 01:35 = 95
            var time = "01:35";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(95, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format2()
        {
            // 01:00 = 60
            var time = "01:00";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(60, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format3()
        {
            // 0:00 = 0
            var time = "0:00";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(0, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format4()
        {
            // 0 = 0
            var time = "0";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(0, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format5()
        {
            // 13 = 780
            var time = "13";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(780, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format6()
        {
            // 4,25 = 255
            var time = "4,25";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(timeEntry.Minutes, 255);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format7()
        {
            // 5.5 = 330
            var time = "5.5";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(330, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format8()
        {
            // 1,30 = 78
            var time = "1,30";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(78, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

        [TestMethod]
        public void ValidateTimeEntry_errechnet_die_Minuten_aus_korrekter_Zeiteingabe_richtig_Format9()
        {
            // = 0
            var time = "";
            var timeEntry = new TimeEntry();
            var result = TimeEntryService.ValidateTimeEntry(timeEntry, time);
            Assert.AreEqual(0, timeEntry.Minutes);
            Assert.IsFalse(result.ContainsKey("Time"));
        }

    }
}

