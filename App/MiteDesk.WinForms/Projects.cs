using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Core.Services;
using SixtyNineDegrees.MiteDesk.WinForms.Localization;
using StructureMap;

namespace SixtyNineDegrees.MiteDesk.WinForms
{
    public partial class Projects : Form
    {

        #region Setup

        public Projects()
        {
            InitializeComponent();
            LocalizeForm();
            ProjectService = ObjectFactory.GetInstance<IProjectService>();

            TreeDataBackgroundWorker.DoWork += TreeDataBackgroundWorker_DoWork;
            TreeDataBackgroundWorker.RunWorkerCompleted += TreeDataBackgroundWorker_RunWorkerCompleted;
            Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);

            ActiveProjectsTree.NodeMouseClick += Tree_NodeMouseClick;
            ArchivedProjectsTree.NodeMouseClick += Tree_NodeMouseClick;

            ListCustomers.TextUpdate += Helper.ValidateTextEnteredInComboBox;
            PrepareFormForNewProject();
        }

        private IList<Project> ActiveProjects;
        private IList<Project> ArchivedProjects;
        private IList<Customer> ActiveCustomers;
        private IList<Customer> ArchivedCustomers;
        private readonly IProjectService ProjectService;

        private Project CurrentProject;
        private bool CreateNewProject;

        #endregion

        #region Lokalisierung

        private void LocalizeForm()
        {
            Text = ProjectsLabels.FormTitle;
            ActiveProjectsTabPage.Text = ProjectsLabels.TabActiveTitle;
            ArchivedCustomersTabPage.Text = ProjectsLabels.TabArchivedTitle;
            BtnNewProject.Text = ProjectsLabels.ButtonNewActivity;
            BtnSave.Text = ProjectsLabels.ButtonApply;
            BtnCancel.Text = ProjectsLabels.ButtonCancel;
            label1.Text = ProjectsLabels.LabelName;
            label2.Text = ProjectsLabels.LabelNote;
            label3.Text = ProjectsLabels.LabelCustomer;
            label4.Text = ProjectsLabels.LabelBudget;
            BtnOpenCustomers.Text = ProjectsLabels.ButtonCustomers;
            CheckBoxArchived.Text = ProjectsLabels.LabelArchived;
            DeleteToolStripMenuItem.Text = ProjectsLabels.ButtonDelete;
            ListBudgetType.Items.Add(ProjectsLabels.BudgetHours);
            ListBudgetType.Items.Add(ProjectsLabels.BudgetEuro);
        }

        #endregion

        #region Treeviews befüllen

        void TreeDataBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (TreeDataBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            ActiveProjects = ProjectService.GetAllActiveProjects();
            ArchivedProjects = ProjectService.GetAllArchivedProjects();

            var customerService = ObjectFactory.GetInstance<ICustomerService>();
            ActiveCustomers = customerService.GetAllActiveCustomers();
            ArchivedCustomers = customerService.GetAllArchivedCustomers();

        }

        void TreeDataBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (ActiveProjects == null || ArchivedProjects == null || ActiveCustomers == null || e.Cancelled)
                return;

            FillTree(ActiveProjectsTree, ActiveProjects);
            FillTree(ArchivedProjectsTree, ArchivedProjects);
            
            ListItem selected = ListCustomers.SelectedItem != null ? (ListItem) ListCustomers.SelectedItem : null;
            ListCustomers.Items.Clear();
            ListCustomers.Items.Add(new ListItem {Value = 0, Text = string.Empty});

            foreach (var customer in ActiveCustomers)
            {
                ListCustomers.Items.Add(new ListItem {Value = customer.ID, Text = customer.Name});
                if (selected != null && selected.Value == customer.ID)
                    ListCustomers.SelectedItem = ListCustomers.Items[ListCustomers.Items.Count - 1];
            }

            foreach (var customer in ArchivedCustomers)
            {
                ListCustomers.Items.Add(new ListItem { Value = customer.ID, Text = customer.Name + " (" + ProjectsLabels.LabelArchived  + ")"});
                if (selected != null && selected.Value == customer.ID)
                    ListCustomers.SelectedItem = ListCustomers.Items[ListCustomers.Items.Count - 1];
            }
            
        }

        void FillTree(TreeView tree, IList<Project> projects)
        {

            tree.Nodes.Clear();

            var customers = new Dictionary<int, string>();

            foreach (var project in projects)
            {
                if (!customers.ContainsKey(project.CustomerID))
                    customers.Add(project.CustomerID, project.CustomerName);
            }

            customers.OrderBy(c => c.Value).ToDictionary(c => c.Key, c => c.Value);

            foreach (var customer in customers)
            {
                foreach (var project in projects.Where(p => p.CustomerID == customer.Key))
                {
                    tree.Nodes.Add(project.ID.ToString(), !string.IsNullOrEmpty(customer.Value) ? customer.Value + ": " + project.Name : project.Name);
                }
            }

        }

        #endregion

        #region Projekt darstellen

        private void LoadSingleProjectInForm(int projectID)
        {

            FormGroup.Text = ProjectsLabels.GroupBoxTitleEditMode;
            CreateNewProject = false;
            CheckBoxArchived.Visible = true;
            CurrentProject = ProjectService.GetProjectByID(projectID);
            BoxName.Text = CurrentProject.Name;
            BoxNote.Text = CurrentProject.Note;
            CheckBoxArchived.Checked = CurrentProject.Archived;

            ListBudgetType.SelectedIndex = CurrentProject.BudgetType == "minutes" ? 0 : 1;

            foreach (var customerItem in ListCustomers.Items)
            {
                if (((ListItem)customerItem).Value == CurrentProject.CustomerID)
                {
                    ListCustomers.SelectedItem = customerItem;
                    break;
                }
            }

            if (CurrentProject.Budget == 0)
            {
                BoxBudget.Text = CurrentProject.BudgetType == "minutes" ? "0:00" : "0,00";
            }
            else
            {
                if(CurrentProject.BudgetType == "minutes")
                {
                    BoxBudget.Text = Helper.GetFormattedTimeText(CurrentProject.Budget);
                }
                else
                {
                    if (CurrentProject.Budget % 100 == 0)
                    {
                        BoxBudget.Text = (CurrentProject.Budget / 100).ToString();
                    }
                    else
                    {
                        BoxBudget.Text = (CurrentProject.Budget / 100) + "," +
                                             (CurrentProject.Budget % 100).ToString().PadRight(2, '0');
                    }

                    if (BoxBudget.Text == "0")
                        BoxBudget.Text = "0,00";
                    else if (BoxBudget.Text.IndexOf(',') < 0)
                        BoxBudget.Text = BoxBudget.Text + ",00";
                }
            }

            BtnSave.Enabled = false;
            FormGroup.Enabled = true;
            BoxName.Focus();
        }

        private void BtnOpenCustomers_Click(object sender, EventArgs e)
        {
            new Customers().ShowDialog(this);
        }

        #endregion

        #region Formular zurücksetzen

        private void PrepareFormForNewProject()
        {
            ResetForm();
            FormGroup.Text = ProjectsLabels.GroupBoxTitleCreateMode;
            FormGroup.Enabled = true;
            CreateNewProject = true;
            CheckBoxArchived.Visible = false;
            BoxName.Focus();
        }

        private void ResetForm()
        {
            FormGroup.Enabled = false;
            FormGroup.Text = null;
            CheckBoxArchived.Visible = true;
            CurrentProject = null;
            CreateNewProject = false;
            ActiveProjectsTree.SelectedNode = null;
            ArchivedProjectsTree.SelectedNode = null;
            ListCustomers.SelectedItem = null;
            ListBudgetType.SelectedItem = null;
            BoxName.Text = null;
            BoxNote.Text = null;
            BoxBudget.Text = "0:00";
            CheckBoxArchived.Checked = false;
            BtnSave.Enabled = false;
            ErrorProvider.Clear();
        }

        #endregion

        #region Projekt erstellen/aktualisieren

        private void BtnSave_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            var project = CurrentProject ?? new Project();
            project.Name = BoxName.Text;
            project.Note = BoxNote.Text;
            project.Archived = CheckBoxArchived.Checked;
            project.BudgetType = ListBudgetType.SelectedIndex == 0 ? "minutes" : "cents";
            project.CustomerID =  ListCustomers.SelectedItem != null ? ((ListItem) ListCustomers.SelectedItem).Value : 0;

            var result = CurrentProject != null
                             ? ProjectService.UpdateProject(project, BoxBudget.Text)
                             : ProjectService.CreateProject(project, BoxBudget.Text);

            ErrorProvider.Clear();

            if(result.Count == 0)
            {
                Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);
                if (CreateNewProject)
                    PrepareFormForNewProject();
                else
                    BtnSave.Enabled = false;
                Cursor = Cursors.Default;
                return;
            }

            if (result.ContainsKey("Name"))
                ErrorProvider.SetError(BoxName, result["Name"]);

            Cursor = Cursors.Default;

        }

        #endregion

        #region Projekt löschen

        private void DeleteProject(int projectID)
        {

            var timeEntries = ObjectFactory.GetInstance<ITimeEntryService>().GetTimeEntriesByProjectID(projectID);

            if (timeEntries.Count > 0)
            {
                MessageBox.Show(ProjectsLabels.MsgBoxDeleteErrorText, ProjectsLabels.MsgBoxDeleteErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var question = MessageBox.Show(ProjectsLabels.MsgBoxDeleteQuestionText, ProjectsLabels.MsgBoxDeleteQuestionTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                ProjectService.DeleteProject(projectID);
                ResetForm();
                Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);
            }
        }

        #endregion

        #region Event-Handler

        private void BtnNewProject_Click(object sender, EventArgs e)
        {
            PrepareFormForNewProject();
        }

        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = e.Node;
            LoadSingleProjectInForm(int.Parse(e.Node.Name));
        }

        private void DeleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (ActiveProjectsTabPage.Visible)
                DeleteProject(int.Parse(ActiveProjectsTree.SelectedNode.Name));
            else
                DeleteProject(int.Parse(ArchivedProjectsTree.SelectedNode.Name));
        }

        protected override void OnClosed(EventArgs e)
        {
            Helper.StartBackgroundWorker(((Main)Owner).InitializationBackgroundWorker, null);
            base.OnClosed(e);
        }

        private void EnableBtnSave(object sender, EventArgs e)
        {
            if (FormGroup.Enabled)
                BtnSave.Enabled = true;
        }

        #endregion

    }
}
