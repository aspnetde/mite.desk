using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Tools.Connector;

namespace SixtyNineDegrees.MiteDesk.Core.Data.Tests
{
    [TestClass]
    public class MiteTimeEntriesTests
    {

        private MiteTimeEntries Repository;
        private List<int> TempEntries;

        [TestInitialize]
        public void Setup()
        {
            var mockRepository = new MockRepository();
            var configurationService = mockRepository.DynamicMock<IConfigurationService>();
            using (mockRepository.Record())
            {
                Expect.Call(configurationService.GetAppSettings()).Return(new AppSettings { AccountName = "win", Email = "bandt@69grad.de", Password = "winmite" }).Repeat.Any();
            }
            Repository = new MiteTimeEntries(configurationService);
            TempEntries = new List<int>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            foreach (var entry in TempEntries)
            {
                Repository.DeleteTimeEntry(entry);
            }
        }

        [TestMethod]
        public void GetTimeEntries_liefert_alle_Einträge_zu_einem_Datum()
        {
            // 13.07.2009 - 3 Einträge
            var result = Repository.GetTimeEntriesByDate(new DateTime(2009, 7, 13));
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetTimeEntriesByActivityID_liefert_alle_Einträge_zu_einer_Leistung()
        {
            // Entwickeln  - 76072, 15.12.2009
            var result = Repository.GetTimeEntriesByActivityID(76072);
            Assert.AreEqual(15, result.Count);
        }

        [TestMethod]
        public void GetTimeEntriesByProjectID_liefert_alle_Einträge_zu_einem_Projekt()
        {
            // Windows 7 - 152451, 5 Einträge, 15.12.2009
            var result = Repository.GetTimeEntriesByProjectID(152451);
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void GetTimeEntry_liefert_einen_bestimmten_Eintrag_anhand_seiner_ID()
        {
            // 1952882 - vom 13.07.2009
            var result = Repository.GetTimeEntryByID(1952882);
            Assert.AreEqual("Taskbar", result.Note);
        }

        [TestMethod]
        public void CreateTimeEntry_erstellt_einen_neuen_Eintrag()
        {

            var entry = new TimeEntry
                            {
                                ActivityID = 76072,
                                ProjectID = 152455,
                                Minutes = 3,
                                Date = new DateTime(2009, 7, 12),
                                Note = Guid.NewGuid().ToString(),
                                ID = 0
                            };

            Repository.CreateTimeEntry(ref entry);

            Assert.AreNotEqual(0, entry.ID);

            TempEntries.Add(entry.ID);

        }

        [TestMethod]
        public void DeleteTimeEntry_löscht_einen_vorhandenen_Eintrag()
        {
            
            // Anlegen
            var entry = new TimeEntry
                            {
                                ActivityID = 76072,
                                ProjectID = 152455,
                                Minutes = 3,
                                Date = new DateTime(2009, 7, 12),
                                Note = Guid.NewGuid().ToString(),
                                ID = 0
                            };

            Repository.CreateTimeEntry(ref entry);
            Assert.AreNotEqual(0, entry.ID);

            // Löschen
            Repository.DeleteTimeEntry(entry.ID);

            // Server muss 404 liefern (Der Remoteserver hat einen Fehler zurückgegeben: (404) Nicht gefunden..)
            MiteConnectorException exception = null;
            try
            {
                Repository.GetTimeEntryByID(entry.ID);
            }
            catch (MiteConnectorException e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);

        }

        [TestMethod]
        public void UpdateTimeEntry_Aktualisiert_einen_vorhandenen_Eintrag()
        {

            // Eintrag steht am 7.7.09 fest drin

            var entry = new TimeEntry
                            {
                                Note = Guid.NewGuid().ToString(),
                                ID = 1954379,
                                ActivityID = 76073,
                                ProjectID = 152451,
                                Minutes = 0,
                                Date = new DateTime(2009, 7, 7)
                            };

            Repository.UpdateTimeEntry(entry);

            // Prüfen ob der Text aktualisiert wurde
            var result = Repository.GetTimeEntryByID(entry.ID);
            Assert.AreEqual(entry.Note, result.Note);

        }

        [TestMethod]
        public void StartStopwatch_startet_die_Stopuhr_auf_einen_angegebenen_Zeiteintrag()
        {
            // Eintrag 1954379 steht am 7.7.09 fest drin

            // Check
            var result = Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.IsNull(result);

            // Start
            Repository.StartStopwatch(1954379);

            // Check
            result = Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.AreEqual(1954379, result.ID);

            // Stop
            Repository.StopStopwatch(1954379);
        }

        [TestMethod]
        public void StopStopwatch_stoppt_die_Stopuhr_auf_einen_angegebenen_Zeiteintrag()
        {
            // Eintrag 1954379 steht am 7.7.09 fest drin

            // Start
            Repository.StartStopwatch(1954379);

            // Check
            var result = Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.AreEqual(1954379, result.ID);

            // Stop
            Repository.StopStopwatch(1954379);

            // Check
            result = Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTimeEntryCurrentlyTrackedByStopwatch_liefert_den_Zeiteintrag_der_gerade_gestoppt_wird()
        {
            // Eintrag 1954379 steht am 7.7.09 fest drin

            // Check
            var result = Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.IsNull(result);

            // Start
            Repository.StartStopwatch(1954379);

            // Check
            result = Repository.GetTimeEntryCurrentlyTrackedByStopwatch();
            Assert.AreEqual(1954379, result.ID);

            // Stop
            Repository.StopStopwatch(1954379);
        }

        [TestMethod]
        public void GetTimeEntryDatesByRange_liefert_eine_Liste_von_Dates_in_einem_bestimmten_Datumsbereich()
        {
            var result = Repository.GetTimeEntryDatesByRange(new DateTime(2009, 8, 1), new DateTime(2009, 8, 31), 18352);
            Assert.AreEqual(7, result.Count);
            Assert.AreEqual(new DateTime(2009, 8, 3), result[6]);
        }

    }
}
