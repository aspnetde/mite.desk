using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services.Tests
{
    
    [TestClass]
    public class ProjectServiceTests
    {

        #region Setup

        private ProjectService ProjectService;
        private MockRepository MockRepository;
        private IProjectRepository ProjectRepository;

        [TestInitialize]
        public void Setup()
        {

            MockRepository = new MockRepository();
            ProjectRepository = MockRepository.DynamicMock<IProjectRepository>();
            ProjectService = new ProjectService(ProjectRepository);

            using (MockRepository.Record())
            {
                Expect.Call(ProjectRepository.GetAllActiveProjects()).Return(new List<Project>(new[] { new Project(), new Project(), new Project(), new Project() })).Repeat.Any();
                Expect.Call(ProjectRepository.GetAllArchivedProjects()).Return(new List<Project>(new[] { new Project() })).Repeat.Any();
                Expect.Call(ProjectRepository.GetProjectsByCustomer(34)).Return(new List<Project>(new[] { new Project(), new Project() })).Repeat.Any();
                Expect.Call(ProjectService.GetProjectByID(1234)).Return(new Project {ID = 1234}).Repeat.Any();
            }

        }

        #endregion

        [TestMethod]
        public void GetAllActiveProjects_liefert_eine_Liste_aller_aktiven_Projekte()
        {
            var result = ProjectService.GetAllActiveProjects();
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void GetProjectsByCustomer_liefert_alle_Projekte_eines_einzelnen_Kunden()
        {
            var result = ProjectService.GetProjectsByCustomer(34);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetAllArchivedProjects_liefert_alle_archivierten_Projekte_aus_dem_ProjectRepository()
        {
            var result = ProjectService.GetAllArchivedProjects();
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void DeleteProject_ruft_das_Repository_zum_Löschen_des_gewählten_Projektes_auf()
        {
            ProjectService.DeleteProject(123456);
            ProjectRepository.AssertWasCalled(r => r.DeleteProject(123456));
        }

        [TestMethod]
        public void GetProjectByID_liefert_ein_bestimmtes_Projekt_aus_dem_Repository_anhand_seiner_ID()
        {
            var result = ProjectService.GetProjectByID(1234);
            Assert.IsNotNull(result);
            Assert.AreEqual(1234, result.ID);
        }

        [TestMethod]
        public void CreateProject_liefert_einen_Fehler_wenn_der_name_des_Projektes_nicht_angegeben_wurde()
        {
            var project = new Project { Name = "" };
            var result = ProjectService.CreateProject(project, "");
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        [TestMethod]
        public void CreateProject_liefert_keinen_Fehler_wenn_alles_okay()
        {
            var project = new Project { Name = "Testprojekt" };
            var result = ProjectService.CreateProject(project, "");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CreateProject_speichert_das_Projekt_im_Repository_wenn_alles_okay()
        {
            var project = new Project { Name = "Testprojekt" };
            ProjectService.CreateProject(project, "");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(project));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_25_komma_50_2550_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "euro" };
            ProjectService.CreateProject(project, "25,50");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "euro", Budget = 2550 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_25__komma_r_2500_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "euro" };
            ProjectService.CreateProject(project, "25,r");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "euro", Budget = 2500 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_25__komma_799_2580_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "euro" };
            ProjectService.CreateProject(project, "25,799");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "euro", Budget = 2580 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_r_komma_50_50_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "euro" };
            ProjectService.CreateProject(project, "r,50");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "euro", Budget = 50 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_einem_Leerstring_0_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "euro" };
            ProjectService.CreateProject(project, "");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "euro", Budget = 0 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_100_10000_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "euro" };
            ProjectService.CreateProject(project, "100");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "euro", Budget = 10000 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_Minutes_bei_Eingabe_von_3_180_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "minutes" };
            ProjectService.CreateProject(project, "3");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "minutes", Budget = 180 }));
        }

        [TestMethod]
        public void CreateProject_übergibt_als_Budget_Minutes_bei_Eingabe_von_3_20_200_ans_Repository()
        {
            var project = new Project { Name = "OK", BudgetType = "minutes" };
            ProjectService.CreateProject(project, "3:20");
            ProjectRepository.AssertWasCalled(r => r.CreateProject(new Project { Name = "OK", BudgetType = "minutes", Budget = 200 }));
        }

        [TestMethod]
        public void UpdateProject_liefert_einen_Fehler_wenn_der_Name_des_Projektes_nicht_angegeben_wurde()
        {
            var project = new Project { ID = 3, Name = "" };
            var result = ProjectService.UpdateProject(project, "");
            Assert.IsTrue(result.ContainsKey("Name"));
        }

        [TestMethod]
        public void UpdateProject_wirft_eine_ArgumentException_wenn_die_ID_des_Projektes_nicht_angegeben_wurde()
        {
            Exception exception = null;
            var project = new Project { ID = 0 };
            try
            {
                ProjectService.UpdateProject(project, "");
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentException));
        }

        [TestMethod]
        public void UpdateProject_liefert_keinen_Fehler_wenn_alles_okay()
        {
            var project = new Project { ID = 3, Name = "Testprojekt" };
            var result = ProjectService.UpdateProject(project, "");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void UpdateProject_speichert_das_Projekt_im_Repository_wenn_alles_okay()
        {
            var project = new Project { ID = 3, Name = "Testprojekt" };
            ProjectService.UpdateProject(project, "");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(project));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_25_komma_50_2550_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "euro" };
            ProjectService.UpdateProject(project, "25,50");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "euro", Budget = 2550 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_25__komma_r_2500_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "euro" };
            ProjectService.UpdateProject(project, "25,r");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "euro", Budget = 2500 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_25__komma_799_2580_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "euro" };
            ProjectService.UpdateProject(project, "25,799");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "euro", Budget = 2580 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_r_komma_50_50_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "euro" };
            ProjectService.UpdateProject(project, "r,50");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "euro", Budget = 50 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_einem_Leerstring_0_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "euro" };
            ProjectService.UpdateProject(project, "");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "euro", Budget = 0 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_EUR_bei_Eingabe_von_100_10000_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "euro" };
            ProjectService.UpdateProject(project, "100");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "euro", Budget = 10000 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_Minutes_bei_Eingabe_von_3_180_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "minutes" };
            ProjectService.UpdateProject(project, "3");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "minutes", Budget = 180 }));
        }

        [TestMethod]
        public void UpdateProject_übergibt_als_Budget_Minutes_bei_Eingabe_von_3_20_200_ans_Repository()
        {
            var project = new Project { ID = 3, Name = "OK", BudgetType = "minutes" };
            ProjectService.UpdateProject(project, "3:20");
            ProjectRepository.AssertWasCalled(r => r.UpdateProject(new Project { ID = 3, Name = "OK", BudgetType = "minutes", Budget = 200 }));
        }

    }
}
