using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Core.Services;
using SixtyNineDegrees.MiteDesk.WinForms.Localization;
using StructureMap;

namespace SixtyNineDegrees.MiteDesk.WinForms
{
    public partial class Customers : Form
    {

        #region Setup

        public Customers()
        {
            InitializeComponent();
            LocalizeForm();

            CustomerService = ObjectFactory.GetInstance<ICustomerService>();

            TreeDataBackgroundWorker.DoWork += TreeDataBackgroundWorker_DoWork;
            TreeDataBackgroundWorker.RunWorkerCompleted += TreeDataBackgroundWorker_RunWorkerCompleted;
            Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);

            ActiveCustomersTree.NodeMouseClick += Tree_NodeMouseClick;
            ArchivedCustomersTree.NodeMouseClick += Tree_NodeMouseClick;

            PrepareFormForNewCustomer();
        }

        private IList<Customer> ActiveCustomers;
        private IList<Customer> ArchivedCustomers;
        private readonly ICustomerService CustomerService;

        private Customer CurrentCustomer;
        private bool CreateNewCustomer;

        #endregion

        #region Lokalisierung

        private void LocalizeForm()
        {
            Text = CustomersLabels.FormTitle;
            ActiveCustomersTabPage.Text = CustomersLabels.TabActiveTitle;
            ArchivedCustomersTabPage.Text = CustomersLabels.TabArchivedTitle;
            BtnNewCustomer.Text = CustomersLabels.ButtonNewActivity;
            BtnSave.Text = CustomersLabels.ButtonApply;
            BtnCancel.Text = CustomersLabels.ButtonCancel;
            label1.Text = CustomersLabels.LabelName;
            label2.Text = CustomersLabels.LabelNote;
            CheckBoxArchived.Text = CustomersLabels.LabelArchived;
            DeleteToolStripMenuItem.Text = CustomersLabels.ButtonDelete;
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
            ActiveCustomers = CustomerService.GetAllActiveCustomers();
            ArchivedCustomers = CustomerService.GetAllArchivedCustomers();
        }

        void TreeDataBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (ActiveCustomers == null || ArchivedCustomers == null || e.Cancelled)
                return;

            ActiveCustomersTree.Nodes.Clear();

            foreach (var customer in ActiveCustomers)
                ActiveCustomersTree.Nodes.Add(customer.ID.ToString(), customer.Name);

            ArchivedCustomersTree.Nodes.Clear();

            foreach (var customer in ArchivedCustomers)
                ArchivedCustomersTree.Nodes.Add(customer.ID.ToString(), customer.Name);
        }

        #endregion

        #region Kundendatensatz darstellen

        private void LoadSingleCustomerInForm(int customerID)
        {
            FormGroup.Text = CustomersLabels.GroupBoxTitleEditMode;
            CreateNewCustomer = false;
            CheckBoxArchived.Visible = true;
            CurrentCustomer = CustomerService.GetCustomerByID(customerID);
            BoxName.Text = CurrentCustomer.Name;
            BoxNote.Text = CurrentCustomer.Note;
            CheckBoxArchived.Checked = CurrentCustomer.Archived;
            FormGroup.Enabled = true;
            BoxName.Focus();
            BtnSave.Enabled = false;
        }

        #endregion

        #region Formular zurücksetzen

        private void PrepareFormForNewCustomer()
        {
            ResetForm();
            FormGroup.Text = CustomersLabels.GroupBoxTitleCreateMode;
            BtnSave.Enabled = false;
            FormGroup.Enabled = true;
            CreateNewCustomer = true;
            CheckBoxArchived.Visible = false;
            BoxName.Focus();
        }

        private void ResetForm()
        {
            FormGroup.Text = null;
            CheckBoxArchived.Visible = true;
            CurrentCustomer = null;
            CreateNewCustomer = false;
            ActiveCustomersTree.SelectedNode = null;
            ArchivedCustomersTree.SelectedNode = null;
            BoxName.Text = null;
            BoxNote.Text = null;
            CheckBoxArchived.Checked = false;
            FormGroup.Enabled = false;
            BtnSave.Enabled = false;
            ErrorProvider.Clear();
        }

        #endregion

        #region Kunde erstellen/aktualisieren

        private void BtnSave_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            var customer = CurrentCustomer ?? new Customer();
            customer.Name = BoxName.Text;
            customer.Note = BoxNote.Text;
            customer.Archived = CheckBoxArchived.Checked;

            var result = CurrentCustomer != null
                             ? CustomerService.UpdateCustomer(customer)
                             : CustomerService.CreateCustomer(customer);

            ErrorProvider.Clear();

            if(result.Count == 0)
            {
                Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);
                if (CreateNewCustomer)
                    PrepareFormForNewCustomer();
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

        #region Kunde löschen

        private void DeleteCustomer(int customerID)
        {

            var projects = ObjectFactory.GetInstance<IProjectService>().GetProjectsByCustomer(customerID);

            if(projects.Count > 0)
            {
                MessageBox.Show(CustomersLabels.MsgBoxDeleteErrorText, CustomersLabels.MsgBoxDeleteErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var question = MessageBox.Show(CustomersLabels.MsgBoxDeleteQuestionText, CustomersLabels.MsgBoxDeleteQuestionTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                CustomerService.DeleteCustomer(customerID);
                ResetForm();
                Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);
            }
        }

        #endregion

        #region Event-Handler

        private void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            PrepareFormForNewCustomer();
        }

        private void BtnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = e.Node;
            LoadSingleCustomerInForm(int.Parse(e.Node.Name));
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveCustomersTabPage.Visible)
                DeleteCustomer(int.Parse(ActiveCustomersTree.SelectedNode.Name));
            else
                DeleteCustomer(int.Parse(ArchivedCustomersTree.SelectedNode.Name));
        }

        protected override void OnClosed(EventArgs e)
        {
            if (Owner is Main)
                Helper.StartBackgroundWorker(((Main)Owner).InitializationBackgroundWorker, null);
            else if(Owner is Projects)
                Helper.StartBackgroundWorker(((Projects)Owner).TreeDataBackgroundWorker, null);
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
