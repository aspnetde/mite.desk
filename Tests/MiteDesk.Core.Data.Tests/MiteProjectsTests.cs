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
    public class MiteProjectsTests
    {

        private MiteProjects Repository;

        [TestInitialize]
        public void Setup()
        {
            var mockRepository = new MockRepository();
            var configurationService = mockRepository.DynamicMock<IConfigurationService>();
            using (mockRepository.Record())
            {
                Expect.Call(configurationService.GetAppSettings()).Return(new AppSettings { AccountName = "win", Email = "bandt@69grad.de", Password = "winmite" }).Repeat.Any();
            }
            Repository = new MiteProjects(configurationService);
        }

        [TestMethod]
        public void GetAllActiveProjects_liefert_eine_Liste_aller_aktiven_Projekte()
        {
            // 4 aktive Projekte, 12.09.2009
            var result = Repository.GetAllActiveProjects();
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void GetProjectsByProject_liefert_eine_Liste_aller_Projekte_eines_Kunden()
        {
            // 54054, Microsoft, 2 Projekte 12.09.2009
            var result = Repository.GetProjectsByCustomer(54054);
            Assert.AreEqual(2, result.Count);
        }


        [TestMethod]
        public void GetAllArchivedProjects_liefert_eine_Liste_aller_archivierten_Projekte_zurück()
        {
            // 1 archiviertes Projekt, 18.08.2009
            var result = Repository.GetAllArchivedProjects();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetProjectByID_liefert_eine_bestimmtes_Projekt_anhand_seiner_ID_zurück()
        {
            // 152453, Snow Leopard, 18.08.2009
            var result = Repository.GetProjectByID(152453);
            Assert.IsNotNull(result);
            Assert.AreEqual("Snow Leopard", result.Name);
        }

        [TestMethod]
        public void UpdateProject_aktualisiert_ein_Projekt_in_der_Mite_Datenbank()
        {

            // 152453, Snow Leopard, 18.08.2009
            var id = 152453;
            var note = Guid.NewGuid().ToString();

            var project = Repository.GetProjectByID(id);

            Assert.AreNotEqual(note, project.Note);

            project.Note = note;
            Repository.UpdateProject(project);

            project = Repository.GetProjectByID(id);
            Assert.AreEqual(note, project.Note);

        }

        [TestMethod]
        public void DeleteProject_löscht_ein_Projekt_anhand_seiner_ID_aus_der_mite_Datenbank()
        {

            var project = new Project();
            project.Note = Guid.NewGuid().ToString();
            project.Name = Guid.NewGuid().ToString();
            project.BudgetType = "minutes";

            Repository.CreateProject(project);

            var result = Repository.GetAllActiveProjects().SingleOrDefault(c => c.Name == project.Name);

            Assert.IsNotNull(result);
            Repository.DeleteProject(result.ID);

            Exception exception = null;
            try
            {
                Repository.GetProjectByID(result.ID);
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
        public void CreateProject_legt_ein_neues_Projekt_in_der_Mite_Datenbank_an()
        {

            var project = new Project();
            project.Note = Guid.NewGuid().ToString();
            project.Name = Guid.NewGuid().ToString();
            project.BudgetType = "minutes";

            Repository.CreateProject(project);

            var result = Repository.GetAllActiveProjects().SingleOrDefault(c => c.Name == project.Name);

            Assert.IsNotNull(result);
            Assert.AreEqual(project.Note, result.Note);

            Repository.DeleteProject(result.ID);

        }

    }
}
