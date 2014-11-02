using System.Collections.Generic;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Core.Services;
using SixtyNineDegrees.MiteDesk.WinForms.Localization;
using StructureMap;

namespace SixtyNineDegrees.MiteDesk.WinForms
{
    public partial class Activities : Form
    {
 
        #region Setup

        public Activities()
        {
            InitializeComponent();

            LocalizeForm();

            ActivityService = ObjectFactory.GetInstance<IActivityService>();

            TreeDataBackgroundWorker.DoWork += TreeDataBackgroundWorker_DoWork;
            TreeDataBackgroundWorker.RunWorkerCompleted += TreeDataBackgroundWorker_RunWorkerCompleted;
            Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);

            ActivActivitiesTree.NodeMouseClick += Tree_NodeMouseClick;
            ArchivedActivitiesTree.NodeMouseClick += Tree_NodeMouseClick;

            PrepareFormForNewActivity();
        }

        private IList<Activity> ActiveActivities;
        private IList<Activity> ArchivedActivities;
        private readonly IActivityService ActivityService;

        private Activity CurrentActivity;
        private bool CreateNewActivity;

        #endregion

        #region Lokalisierung

        private void LocalizeForm()
        {
            Text = ActivitiesLabels.FormTitle;
            ActiveActivitiesTabPage.Text = ActivitiesLabels.TabActiveTitle;
            ArchivedCustomersTabPage.Text = ActivitiesLabels.TabArchivedTitle;
            BtnNewActivity.Text = ActivitiesLabels.ButtonNewActivity;
            BtnSave.Text = ActivitiesLabels.ButtonApply;
            BtnCancel.Text = ActivitiesLabels.ButtonCancel;
            label1.Text = ActivitiesLabels.LabelName;
            label2.Text = ActivitiesLabels.LabelNote;
            label3.Text = ActivitiesLabels.LabelHourlyNote;
            CheckBoxBillable.Text = ActivitiesLabels.LabelBillable;
            CheckBoxArchived.Text = ActivitiesLabels.LabelArchived;
            DeleteToolStripMenuItem.Text = ActivitiesLabels.ButtonDelete;
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
            ActiveActivities = ActivityService.GetAllActiveActivities();
            ArchivedActivities = ActivityService.GetAllArchivedActivities();
        }

        void TreeDataBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (ActiveActivities == null || ArchivedActivities == null || e.Cancelled)
                return;

            ActivActivitiesTree.Nodes.Clear();

            foreach (var activity in ActiveActivities)
                ActivActivitiesTree.Nodes.Add(activity.ID.ToString(), activity.Name);

            ArchivedActivitiesTree.Nodes.Clear();

            foreach (var activity in ArchivedActivities)
                ArchivedActivitiesTree.Nodes.Add(activity.ID.ToString(), activity.Name);
        }

        #endregion

        #region Leistung darstellen

        private void LoadSingleActivityInForm(int activityID)
        {

            FormGroup.Text = ActivitiesLabels.GroupBoxTitleEditMode;
            CreateNewActivity = false;
            CheckBoxArchived.Visible = true;
            CurrentActivity = ActivityService.GetActivityByID(activityID);
            BoxName.Text = CurrentActivity.Name;
            BoxNote.Text = CurrentActivity.Note;

            if(CurrentActivity.HourlyRate % 100 == 0)
            {
                BoxHourlyRate.Text = (CurrentActivity.HourlyRate/100).ToString();
            }
            else
            {
                BoxHourlyRate.Text = (CurrentActivity.HourlyRate/100) + "," +
                                     (CurrentActivity.HourlyRate%100).ToString().PadRight(2, '0');
            }

            if (BoxHourlyRate.Text == "0")
                BoxHourlyRate.Text = null;

            CheckBoxArchived.Checked = CurrentActivity.Archived;
            CheckBoxBillable.Checked = CurrentActivity.Billable;
            FormGroup.Enabled = true;
            BtnSave.Enabled = false;
            BoxName.Focus();
        }

        #endregion

        #region Formular zurücksetzen

        private void PrepareFormForNewActivity()
        {
            ResetForm();
            FormGroup.Text = ActivitiesLabels.GroupBoxTitleCreateMode;
            FormGroup.Enabled = true;
            CreateNewActivity = true;
            CheckBoxArchived.Visible = false;
            BtnSave.Enabled = false;
            BoxName.Focus();
        }

        private void ResetForm()
        {
            FormGroup.Text = null;
            CheckBoxArchived.Visible = true;
            CurrentActivity = null;
            CreateNewActivity = false;
            ActivActivitiesTree.SelectedNode = null;
            ArchivedActivitiesTree.SelectedNode = null;
            BoxName.Text = null;
            BoxNote.Text = null;
            BoxHourlyRate.Text = null;
            CheckBoxArchived.Checked = false;
            CheckBoxBillable.Checked = false;
            FormGroup.Enabled = false;
            BtnSave.Enabled = false;
            ErrorProvider.Clear();
        }

        #endregion

        #region Leistung erstellen/aktualisieren

        private void BtnSave_Click(object sender, System.EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            var activity = CurrentActivity ?? new Activity();
            activity.Name = BoxName.Text;
            activity.Note = BoxNote.Text;
            activity.Archived = CheckBoxArchived.Checked;
            activity.Billable = CheckBoxBillable.Checked;

            var result = CurrentActivity != null
                             ? ActivityService.UpdateActivity(activity, BoxHourlyRate.Text)
                             : ActivityService.CreateActivity(activity, BoxHourlyRate.Text);

            ErrorProvider.Clear();

            if (result.Count == 0)
            {
                Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);
                if (CreateNewActivity)
                    PrepareFormForNewActivity();
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

        #region Leistung löschen

        private void DeleteActivity(int activityID)
        {

            var timeEntries = ObjectFactory.GetInstance<ITimeEntryService>().GetTimeEntriesByActivityID(activityID);

            if (timeEntries.Count > 0)
            {
                MessageBox.Show(ActivitiesLabels.MsgBoxDeleteErrorText, ActivitiesLabels.MsgBoxDeleteQuestionTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var question = MessageBox.Show(ActivitiesLabels.MsgBoxDeleteQuestionText, ActivitiesLabels.MsgBoxDeleteQuestionTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                ActivityService.DeleteActivity(activityID);
                ResetForm();
                Helper.StartBackgroundWorker(TreeDataBackgroundWorker, null);
            }
        }

        #endregion

        #region Event-Handler

        private void BtnNewActivity_Click(object sender, System.EventArgs e)
        {
            PrepareFormForNewActivity();
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = e.Node;
            LoadSingleActivityInForm(int.Parse(e.Node.Name));
        }

        private void DeleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (ActiveActivitiesTabPage.Visible)
                DeleteActivity(int.Parse(ActivActivitiesTree.SelectedNode.Name));
            else
                DeleteActivity(int.Parse(ArchivedActivitiesTree.SelectedNode.Name));
        }

        protected override void OnClosed(System.EventArgs e)
        {
            Helper.StartBackgroundWorker(((Main)Owner).InitializationBackgroundWorker, null);
            base.OnClosed(e);
        }

        private void EnableBtnSave(object sender, System.EventArgs e)
        {
            if (FormGroup.Enabled)
                BtnSave.Enabled = true;
        }

        #endregion

    }
}
