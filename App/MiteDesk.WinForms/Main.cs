using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Core.Services;
using SixtyNineDegrees.MiteDesk.Tools.Connector;
using StructureMap;
using Timer=System.Windows.Forms.Timer;
using SixtyNineDegrees.MiteDesk.WinForms.Localization;

namespace SixtyNineDegrees.MiteDesk.WinForms
{

    public partial class Main : Form
    {

        #region Setup

        public void Initialize()
        {
            TimeEntryService = ObjectFactory.GetInstance<ITimeEntryService>();
            ConfigurationService = ObjectFactory.GetInstance<IConfigurationService>();

            SetAppSettings();
            Helper.SetCulture(AppSettings.Culture);

            InitializeComponent();
            LocalizeForm();

            NotificationClockTimer = new Timer();
            NotificationClockTimer.Interval = 200;
            NotificationClockTimer.Tick += NotificationClockTimer_Tick;

            ActiveTimeEntryClockTimer = new Timer();
            ActiveTimeEntryClockTimer.Tick += ActiveTimeEntryClockTimer_Tick;
            ActiveTimeEntryClockTimer.Interval = 200;

            InitializationBackgroundWorker.DoWork += InitializationBackgroundWorker_DoWork;
            InitializationBackgroundWorker.RunWorkerCompleted += InitializationBackgroundWorker_RunWorkerCompleted;

            TimeEntriesBackgroundWorker.DoWork += TimeEntriesBackgroundWorker_DoWork;
            TimeEntriesBackgroundWorker.RunWorkerCompleted += TimeEntriesBackgroundWorker_RunWorkerCompleted;

            ListTimeEntries.MouseClick += TimeEntries_MouseClick;
            StopwatchStatus.MouseMove += StopwatchStatus_MouseMove;
            StopwatchStatus.MouseLeave += StopwatchStatus_MouseLeave;

            ListProjects.TextUpdate += Helper.ValidateTextEnteredInComboBox;
            ListActivities.TextUpdate += Helper.ValidateTextEnteredInComboBox;

            Calendar.SizeChanged += Calendar_SizeChanged;

            InitializeForm(true);
        }


        private AppSettings AppSettings;

        private ITimeEntryService TimeEntryService;
        private IConfigurationService ConfigurationService;

        private TimeEntry CurrentTimeEntry;
        private Timer NotificationClockTimer;

        private Timer ActiveTimeEntryClockTimer;
        private int ActiveTimeEntryClockTimerActiveFrame;

        public bool IsInitialized;

        private int LastTrackedTimeEntryID;
        public bool StopInitialization;

        private IList<DateTime> ActiveDates;
        private IList<TimeEntry> TimeEntries;
        private IList<Project> Projects;
        private IList<Activity> Activities;
        private User AuthenticatedUser;
        private DateTime CalendarCurrentSelectionStart;

        private TimeEntry trackedTimeEntry;
        private TimeEntry TrackedTimeEntry
        {
            get { return trackedTimeEntry; }
            set
            {
                if (value != null)
                {
                    int minutes = value.Minutes;
                    trackedTimeEntry = TimeEntryService.GetTimeEntryByID(value.ID);
                    trackedTimeEntry.Minutes = minutes;
                }
                else
                {
                    if (trackedTimeEntry != null)
                        LastTrackedTimeEntryID = trackedTimeEntry.ID;
                    trackedTimeEntry = null;
                }
            }
        }

        #endregion

        #region Initialisierung

        public void SetAppSettings()
        {
            AppSettings = ConfigurationService.GetAppSettings();
        }

        public void LocalizeForm()
        {
            MainMenuItemCreateNewTimeEntry.Text = MainLabels.MenuNewTimeEntry;
            MainMenuItemRefreshActivitiesAndProjects.Text = MainLabels.MenuRefreshProjectsAndActivities;
            einstellungenToolStripMenuItem.Text = MainLabels.MenuSettings;
            beendenToolStripMenuItem.Text = MainLabels.MenuExit;
            datenToolStripMenuItem.Text = MainLabels.MenuData;
            MainMenuCustomersItem.Text = MainLabels.MenuCustomers;
            MainMenuProjectsItem.Text = MainLabels.MenuProjects;
            MainMenuActivitiesItem.Text = MainLabels.MenuActivities;
            miteZeitenToolStripMenuItem.Text = MainLabels.MenuMiteAccount;
            groupBox1.Text = MainLabels.GroupboxCalendarTitle;
            TimeEntryContextMenuDeleteItem.Text = MainLabels.ButtonDelete;
            BtnCancel.Text = MainLabels.ButtonCancel;
            BtnAccept.Text = MainLabels.ButtonCreate;
            WeekOfYear.Text = MainLabels.LabelCalendarWeek;
            TimeEntryDetailView.Text = MainLabels.GroupboxFormCreateMode;
            groupBox2.Text = MainLabels.GroupboxTimeEntriesTitle + string.Format(" {0:d}", Calendar.SelectionStart);
            label2.Text = MainLabels.LabelProject;
            label3.Text = MainLabels.LabelActivity;
            label4.Text = MainLabels.LabelDuration;
            label5.Text = MainLabels.LabelNote;
            ToolStripConnectionStatus.Text = MainLabels.Connected;
            ToolStripMenuItemDisconnectFromServer.Text = MainLabels.Disconnect;
            ToolStripMenuItemConnectToServer.Text = MainLabels.Connect;
            TimeEntryContextMenuStartStopwatchItem.Text = MainLabels.StartStopwatch;
            TimeEntryContextMenuStopStopwatchItem.Text = MainLabels.StopStopwatch;
            NotifyContextMenuStartStopwatchItem.Text = MainLabels.NotifyContextMenuStartStopwatch;
            NotifyContextMenuStopStopwatchItem.Text = MainLabels.NotifyContextMenuStopStopwatch;
            NotifyContextMenuOpenMiteDeskItem.Text = MainLabels.NotifyContextMenuRestoreWindow;
            ExitButton.Text = MainLabels.NotifyContextMenuExit;
            Locked.Text = MainLabels.Locked;
            TimeEntryContextMenuLock.Text = MainLabels.MarkAsLocked;
            TimeEntryContextMenuUnlock.Text = MainLabels.MarkAsUnlocked;
        }

        public void InitializeForm(bool firstStart)
        {

            if (!StopInitialization)
            {
                if (firstStart && string.IsNullOrEmpty(AppSettings.AccountName))
                    new Settings(true).ShowDialog(this);
                else
                    Helper.StartBackgroundWorker(InitializationBackgroundWorker, null);    
            }
            
            if (firstStart && AppSettings.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
                Visible = false;
                ShowInTaskbar = false;
            }

            if (firstStart)
            {
                CurrentTimeEntry = null;
                TrackedTimeEntry = null;
                StopwatchStatus.Text = null;
                Stopwatch.Enabled = true;
                IsInitialized = true;
                ListProjects.Focus();
            }
    
            EnableOrDisableForm(true);

            Stopwatch_Tick(null, null);

        }

        void InitializationBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (InitializationBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            AuthenticatedUser = ObjectFactory.GetInstance<IAuthenticationService>().GetAuthenticatedUser();
            Projects = ObjectFactory.GetInstance<IProjectService>().GetAllActiveProjects();
            Activities = ObjectFactory.GetInstance<IActivityService>().GetAllActiveActivities();
        }

        void InitializationBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!e.Cancelled)
                    InitializeProjectsAndActivities();
                if (!e.Cancelled)
                    DisplayAuthenticatedUserInTitleBar();
                if (!e.Cancelled)
                    SetWeekOfYear(DateTime.Today);
                if (!e.Cancelled)
                    EnableOrDisableDataMenuItem();
                if (!e.Cancelled)
                    InitializeEntryDetailView();
                if (!e.Cancelled)
                    Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, Calendar.SelectionStart);
            }
            catch (TargetInvocationException)
            {
            }
        }

        private void InitializeEntryDetailView()
        {
            if (Locked == null || AuthenticatedUser == null)
                return;
            Locked.Visible = AuthenticatedUser.Role == UserRole.Admin || AuthenticatedUser.Role == UserRole.Owner;
        }

        private void InitializeProjectsAndActivities()
        {

            if (ListActivities == null || Projects == null)
                return;

            int selectedProjectID = ListProjects.SelectedItem != null ? ((ListItem)ListProjects.SelectedItem).Value : AppSettings.SelectedProjectID;

            ListProjects.Items.Clear();
            ListProjects.ValueMember = "Value";
            ListProjects.DisplayMember = "Text";
            ListProjects.Items.Add(new ListItem { Text = string.Empty, Value = 0 });

            var customers = new Dictionary<int, string>();

            foreach (var project in Projects)
            {
                if(!customers.ContainsKey(project.CustomerID))
                    customers.Add(project.CustomerID, project.CustomerName);
            }

            if(!customers.ContainsKey(0))
                customers.Add(0, string.Empty);

            customers.OrderBy(c => c.Value).ToDictionary(c => c.Key, c => c.Value);

            foreach (var customer in customers)
            {
                foreach (var project in Projects.Where(p => p.CustomerID == customer.Key))
                {
                    ListProjects.Items.Add(new ListItem { Text = !string.IsNullOrEmpty(customer.Value) ? customer.Value + ": " + project.Name : project.Name, Value = project.ID });
                    if (selectedProjectID == project.ID)
                        ListProjects.SelectedItem = ListProjects.Items[ListProjects.Items.Count - 1];
                }
            }

            int selectedActivityID = ListActivities.SelectedItem != null ? ((ListItem)ListActivities.SelectedItem).Value : AppSettings.SelectedActivityID;
            
            ListActivities.Items.Clear();
            ListActivities.ValueMember = "Value";
            ListActivities.DisplayMember = "Text";
            ListActivities.Items.Add(new ListItem { Text = string.Empty, Value = 0 });

            foreach (var activity in Activities)
            {
                ListActivities.Items.Add(new ListItem { Text = activity.Name, Value = activity.ID });
                if (selectedActivityID == activity.ID)
                    ListActivities.SelectedItem = ListActivities.Items[ListActivities.Items.Count - 1];
            }

        }

        #endregion

        #region Menü

        private void EnableOrDisableDataMenuItem()
        {
            if (AuthenticatedUser != null)
                datenToolStripMenuItem.Visible = AuthenticatedUser.Role != UserRole.TimeTracker;
        }

        private void Exit(object sender, EventArgs e)
        {
            if (HandleClosing())
                Application.Exit();
        }

        private void MainMenuItemSettingsClick(object sender, EventArgs e)
        {
            new Settings(false).ShowDialog(this);
        }

        private void MainMenuItemCreateNewTimeEntryClick(object sender, EventArgs e)
        {
            ResetForm();
            ListProjects.Focus();
        }

        private void MainMenuItemRefreshProjectsAndActivitiesClick(object sender, EventArgs e)
        {
            Helper.StartBackgroundWorker(InitializationBackgroundWorker, null);
        }

        private void miteZeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Helper.OpenBrowser("https://" + AppSettings.AccountName + ".mite.yo.lk/daily");
        }

        private void MainMenuCustomersItem_Click(object sender, EventArgs e)
        {
            new Customers().ShowDialog(this);
        }

        private void MainMenuProjectsItem_Click(object sender, EventArgs e)
        {
            new Projects().ShowDialog(this);
        }

        private void MainMenuActivitiesItem_Click(object sender, EventArgs e)
        {
            new Activities().ShowDialog(this);
        }

        #endregion

        #region Kopfleiste

        private void DisplayAuthenticatedUserInTitleBar()
        {
            if (AuthenticatedUser != null)
                Text = "mite.desk " + Helper.CurrentVersion + " - " + MainLabels.AuthenticatedAs + " " + AuthenticatedUser.Name + " (" + AuthenticatedUser.Email + ")";
        }

        #endregion

        #region Zeiteintrag erstellen und bearbeiten

        private void CreateOrUpdateTimeEntry(bool update)
        {

            TimeEntry entry = update ? CurrentTimeEntry : new TimeEntry();

            if (ListActivities.SelectedIndex > -1)
                entry.ActivityID = ((ListItem)ListActivities.SelectedItem).Value;

            if (ListProjects.SelectedIndex > -1)
                entry.ProjectID = ((ListItem)ListProjects.SelectedItem).Value;

            entry.Note = Note.Text;
            entry.Date = Calendar.SelectionStart;
            entry.Locked = Locked.Checked;

            IDictionary<string, string> result = update ? TimeEntryService.UpdateTimeEntry(CurrentTimeEntry, Time.Text) : 
                                                          TimeEntryService.CreateTimeEntry(ref entry, Time.Text);

            if (result.Count > 0)
            {
                DisplayValidationMessages(result);
                return;
            }

            ErrorProvider.Clear();

            if (!update)
            {

                if (entry.Minutes == 0 && !entry.Locked)
                    TimeEntryService.StartStopwatch(entry.ID);

                Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, Calendar.SelectionStart);
                Stopwatch_Tick(null, null);

                Note.Text = string.Empty;
                Time.Text = "00:00";

            }
            else
            {
                CurrentTimeEntry = null;
                ResetForm();
                Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, Calendar.SelectionStart);
            }

            AppSettings.SelectedProjectID = entry.ProjectID;
            AppSettings.SelectedActivityID = entry.ActivityID;
            ConfigurationService.UpdateAppSettings(AppSettings);
    
        }

        private void Locked_Click(object sender, EventArgs e)
        {
            if (CurrentTimeEntry != null && CurrentTimeEntry.Locked && !Locked.Checked)
                CreateOrUpdateTimeEntry(true);
        }

        #endregion

        #region Zeiteintrag löschen

        private void DeleteTimeEntry(object sender, EventArgs e)
        {
            DeleteTimeEntry(CurrentTimeEntry.ID);
        }

        private void DeleteTimeEntry(int entryID)
        {
            var question = MessageBox.Show(MainLabels.MsgBoxDeleteTimeEntryText, MainLabels.MsgBoxDeleteTimeEntryTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (question == DialogResult.Yes)
            {
                TimeEntryService.DeleteTimeEntry(entryID);
                ResetForm();
                Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, Calendar.SelectionStart);
            }
        }

        #endregion

        #region Zeiteintrag darstellen

        private void LoadSingleTimeEntryInForm(int id)
        {

            CurrentTimeEntry = TimeEntryService.GetTimeEntryByID(id);

            foreach (var project in ListProjects.Items)
            {
                if (((ListItem)project).Value == CurrentTimeEntry.ProjectID)
                {
                    ListProjects.SelectedItem = project;
                    break;
                }
            }

            foreach (var activity in ListActivities.Items)
            {
                if (((ListItem)activity).Value == CurrentTimeEntry.ActivityID)
                {
                    ListActivities.SelectedItem = activity;
                    break;
                }
            }

            var minutes = CurrentTimeEntry.Minutes;

            if (TrackedTimeEntry != null && TrackedTimeEntry.ID == CurrentTimeEntry.ID)
                minutes = TrackedTimeEntry.Minutes;

            Time.Text = Helper.GetFormattedTimeText(minutes);
            Note.Text = CurrentTimeEntry.Note;
            BtnAccept.Text = MainLabels.ButtonSave;
            TimeEntryDetailView.Text = MainLabels.GroupboxFormEditMode;
            Time.Enabled = CurrentTimeEntry == null || TrackedTimeEntry == null || id != TrackedTimeEntry.ID;

            EnableOrDisableTimeEntryDetailView();

        }

        private void EnableOrDisableTimeEntryDetailView()
        {
            ListProjects.Enabled = !CurrentTimeEntry.Locked;
            ListActivities.Enabled = !CurrentTimeEntry.Locked;
            Time.Enabled = !CurrentTimeEntry.Locked;
            Note.Enabled = !CurrentTimeEntry.Locked;
            BtnAccept.Enabled = !CurrentTimeEntry.Locked;
            BtnCancel.Enabled = !CurrentTimeEntry.Locked;
            Locked.Checked = CurrentTimeEntry.Locked;
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            CreateOrUpdateTimeEntry(CurrentTimeEntry != null);
            Cursor = Cursors.Default;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        #endregion

        #region Kalender

        private void SelectDate(object sender, DateRangeEventArgs e)
        {
            Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, e.Start);
            SetWeekOfYear(e.Start);
        }

        private void SetWeekOfYear(DateTime date)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            WeekOfYear.Text = MainLabels.LabelCalendarWeek + " " + cultureInfo.Calendar.GetWeekOfYear(date, cultureInfo.DateTimeFormat.CalendarWeekRule, cultureInfo.DateTimeFormat.FirstDayOfWeek);
        }

        private void SetCalendarBoldedDays()
        {
            if(ActiveDates == null)
                return;

            var firstDate = new DateTime(Calendar.SelectionStart.Year, Calendar.SelectionStart.Month, 1);
            if (CalendarCurrentSelectionStart != firstDate)
            {
                Calendar.BoldedDates = ActiveDates.ToArray();
                CalendarCurrentSelectionStart = firstDate;
            }
        }

        void Calendar_SizeChanged(object sender, EventArgs e)
        {
            int width = ((MonthCalendar) sender).Size.Width;
            if(width > 164)
            {
                Width = 600;
                groupBox1.Width = 223;
                groupBox2.Width = 580;
            }
        }

        #endregion

        #region Zeiteinträge

        void TimeEntriesBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if(!e.Cancelled)
                    LoadTimeEntries();
                if (!e.Cancelled)
                    SetCalendarBoldedDays();
            }
            catch (TargetInvocationException ex)
            {}
        }

        void TimeEntriesBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            if(TimeEntriesBackgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            var selectedDate = (DateTime) e.Argument;
            var firstDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);

            if (CalendarCurrentSelectionStart != firstDate && AuthenticatedUser != null)
            {
                var lastDate = firstDate.AddMonths(1).AddDays(-1);
                ActiveDates = TimeEntryService.GetTimeEntryDatesByRange(firstDate, lastDate, AuthenticatedUser.ID);
            }
            
            TimeEntries = TimeEntryService.GetTimeEntriesByDate(selectedDate);

            if (AppSettings.SortTimeEntriesDescending)
                TimeEntries = TimeEntries.OrderByDescending(entry => entry.ID).ToList();

        }

        private void LoadTimeEntries()
        {

            if (TimeEntries == null)
                return;

            ListTimeEntries.SmallImageList = new ImageList();

            ListViewItem selected = new ListViewItem();
            selected.ImageKey = "-1";

            if (ListTimeEntries.SelectedItems.Count > 0)
                selected = ListTimeEntries.SelectedItems[0];

            ListTimeEntries.Items.Clear();
            RefreshListTimeEntriesGroupLabel();

            foreach (var entry in TimeEntries)
            {

                var text = GetTimeEntryDisplayText(TrackedTimeEntry != null && TrackedTimeEntry.ID == entry.ID ? TrackedTimeEntry : entry);
                ListViewItem item = new ListViewItem(text, entry.ID.ToString());
                item.ToolTipText = text;
                item.Selected = item.ImageKey == selected.ImageKey;

                if (TrackedTimeEntry != null && TrackedTimeEntry.ID == entry.ID)
                {
                    item.ForeColor = Color.FromArgb(255, 102, 51);
                    item.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                    ListTimeEntries.SmallImageList.Images.Add(item.ImageKey, Properties.Resources.mite_desk_icon_16x16_1);
                }
                else
                {
                    ListTimeEntries.SmallImageList.Images.Add(item.ImageKey, GetIdleIcon(entry.ID));
                }

                ListTimeEntries.Items.Add(item);
            }
        }

        private void RefreshListTimeEntriesGroupLabel()
        {

            if (TimeEntries == null)
                return;

            if (TimeEntries.Count == 0)
            {
                groupBox2.Text = MainLabels.GroupboxTimeEntriesTitle + " " + string.Format("{0:d}", Calendar.SelectionStart);
            }
            else
            {
                int minutes = 0;
                foreach (var timeEntry in TimeEntries)
                    minutes += timeEntry.Minutes;
                groupBox2.Text = MainLabels.GroupboxTimeEntriesTitle + " " + string.Format("{0:d}", Calendar.SelectionStart) + " (" + TimeEntries.Count + ", " + MainLabels.TimeTotal + " " + Helper.GetFormattedTimeText(minutes) + ")";
            }
        }

        private void RefreshTimeEntries()
        {
            for (int i = 0; i < ListTimeEntries.Items.Count; i++)
            {
                var item = ListTimeEntries.Items[i];
                if (TrackedTimeEntry != null && item.ImageKey == TrackedTimeEntry.ID.ToString())
                {
                    var text = GetTimeEntryDisplayText(TrackedTimeEntry);
                    if (item.ForeColor != Color.FromArgb(255, 102, 51))
                    {
                        item.ForeColor = Color.FromArgb(255, 102, 51);
                        item.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                        item.Text = text;
                        item.ToolTipText = item.Text;
                        ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_1;
                    }
                    else if(item.Text != text)
                    {
                        item.Text = text;
                    }
                }
                else
                {
                    if (item.ForeColor == Color.FromArgb(255, 102, 51))
                    {
                        item.ForeColor = Color.Black;
                        item.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                    }
                    ListTimeEntries.SmallImageList.Images[i] = GetIdleIcon(int.Parse(item.ImageKey));
                }
            }
        }

        private Bitmap GetIdleIcon(int timeEntryID)
        {
            if (TimeEntries != null)
            {
                var entry = TimeEntries.SingleOrDefault(e => e.ID == timeEntryID);
                if(entry != null && entry.Locked)
                    return Properties.Resources.Locked;
            }
            return Properties.Resources.mite_desk_icon_16x16_1;
        }

        void TimeEntries_MouseClick(object sender, MouseEventArgs e)
        {
            // In den ersten 20 Pixeln ist der Cursor auf dem Stoppuhr-Icon
            if(e.X <= 20 && e.Button != MouseButtons.Right && TimeEntries != null && ListTimeEntries.SelectedItems != null && ListTimeEntries.SelectedItems.Count > 0)
            {
                var entry = TimeEntries.SingleOrDefault(t => t.ID == int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
                if (entry != null && !entry.Locked)
                    HandleStopwatch(entry.ID);
            }
        }

        private static string GetTimeEntryDisplayText(TimeEntry entry)
        {
            return GetTimeEntryDisplayText(entry, 0);
        }

        private static string GetTimeEntryDisplayText(TimeEntry entry, int maxLength)
        {

            var text = string.Format(" {0} / {1} / {2} / {3}{4}",
                                     Helper.GetFormattedTimeText(entry.Minutes),
                                     entry.CustomerName, entry.ProjectName, entry.ActivityName,
                                     entry.Note.Trim().Length > 0 ? " (" + entry.Note + ")" : string.Empty);
            
            if (maxLength == 0 || text.Length <= maxLength)
                return text;

            return text.Substring(0, maxLength - 4) + " ...";

        }

        private void TimeEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListTimeEntries.SelectedItems.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                LoadSingleTimeEntryInForm(int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
                Cursor = Cursors.Default;
            }
        }

        void ActiveTimeEntryClockTimer_Tick(object sender, EventArgs e)
        {

            if (ActiveTimeEntryClockTimerActiveFrame == 8)
                ActiveTimeEntryClockTimerActiveFrame = 0;

            ActiveTimeEntryClockTimerActiveFrame++;

            for (int i = 0; i < ListTimeEntries.Items.Count; i++)
            {
                if (TrackedTimeEntry != null && ListTimeEntries.Items[i].ImageKey == TrackedTimeEntry.ID.ToString())
                {
                    switch (ActiveTimeEntryClockTimerActiveFrame)
                    {
                        case 1:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_1;
                            break;
                        case 2:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_2;
                            break;
                        case 3:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_3;
                            break;
                        case 4:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_4;
                            break;
                        case 5:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_5;
                            break;
                        case 6:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_6;
                            break;
                        case 7:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_7;
                            break;
                        case 8:
                            ListTimeEntries.SmallImageList.Images[i] = Properties.Resources.mite_desk_icon_16x16_8;
                            break;
                    }
                    ListTimeEntries.RedrawItems(i, i, false);
                    break;
                }

            }

        }

        #region Kontextmenü

        private void TimeEntryContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            TimeEntry entry = null;

            if (ListTimeEntries.SelectedItems.Count > 0 && TimeEntries != null)
                entry = TimeEntries.SingleOrDefault(t => t.ID == int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));

            if(entry == null)
            {
                e.Cancel = true;
                return;
            }

            TimeEntryContextMenuStartStopwatchItem.Visible = !entry.Locked;
            TimeEntryContextMenuStopStopwatchItem.Visible = !entry.Locked;
            
            toolStripSeparator8.Visible = !entry.Locked;
            TimeEntryContextMenuDeleteItem.Visible = !entry.Locked;
            TimeEntryContextMenuLock.Visible = !entry.Locked && (AuthenticatedUser.Role == UserRole.Admin || AuthenticatedUser.Role == UserRole.Owner);
            TimeEntryContextMenuUnlock.Visible = entry.Locked;

            toolStripSeparator9.Visible = !entry.Locked && (AuthenticatedUser.Role == UserRole.Admin || AuthenticatedUser.Role == UserRole.Owner);

            if (entry.Locked)
                return;

            if(TrackedTimeEntry != null && TrackedTimeEntry.ID == entry.ID)
            {
                TimeEntryContextMenuStartStopwatchItem.Visible = false;
                TimeEntryContextMenuStopStopwatchItem.Visible = true;
            }
            else
            {
                TimeEntryContextMenuStartStopwatchItem.Visible = true;
                TimeEntryContextMenuStopStopwatchItem.Visible = false;                
            }
            
        }

        private void TimeEntryContextMenuStartStopwatchItem_Click(object sender, EventArgs e)
        {
            HandleStopwatch(int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
        }

        private void TimeEntryContextMenuStopStopwatchItem_Click(object sender, EventArgs e)
        {
            HandleStopwatch(int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
        }

        private void TimeEntryContextMenuDeleteItem_Click(object sender, EventArgs e)
        {
            if (TrackedTimeEntry != null)
                HandleStopwatch(int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
            DeleteTimeEntry(int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
        }

        private void alsNichtabgeschlossenMarkierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locked.Checked = false;
            CreateOrUpdateTimeEntry(true);
        }

        private void alsAbgeschlossenMarkierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(TrackedTimeEntry != null)
                HandleStopwatch(int.Parse(ListTimeEntries.SelectedItems[0].ImageKey));
            Locked.Checked = true;
            CreateOrUpdateTimeEntry(true);
        }

        #endregion

        #endregion

        #region Formular-Helfer

        private void ResetForm()
        {
            ListTimeEntries.SelectedItems.Clear();
            Note.Text = null;
            Time.Text = "00:00";
            Locked.Checked = false;
            BtnAccept.Text = MainLabels.ButtonCreate;
            TimeEntryDetailView.Text = MainLabels.GroupboxFormCreateMode;
            CurrentTimeEntry = null;
            ErrorProvider.Clear();
            RefreshStopwatchStatus();
            ListProjects.Enabled = true;
            ListActivities.Enabled = true;
            Time.Enabled = true;
            Note.Enabled = true;
            BtnAccept.Enabled = true;
            BtnCancel.Enabled = true;
            Locked.Checked = false;
        }

        private void DisplayValidationMessages(IDictionary<string, string> errors)
        {
            ErrorProvider.Clear();
            if (errors.ContainsKey("Time"))
                ErrorProvider.SetError(Time, errors["Time"]);
        }

        #endregion

        #region Fehlerbehandlung

        public void NotifyAboutNetworkErrorAndDisableForm(MiteConnectorException exception)
        {
            EnableOrDisableForm(false);
            ToolStripConnectionStatus.Text += " - " + MainLabels.ConnectionFailed;
        }

        public void EnableOrDisableForm(bool enabled)
        {

            Stopwatch.Enabled = enabled;
            Cursor = Cursors.Default;

            Calendar.Enabled = enabled;
            ListProjects.Enabled = enabled;
            ListActivities.Enabled = enabled;
            Time.Enabled = enabled;
            Note.Enabled = enabled;
            ListTimeEntries.Enabled = enabled;
            MainMenuItemCreateNewTimeEntry.Enabled = enabled;
            MainMenuItemRefreshActivitiesAndProjects.Enabled = enabled;
            MainMenuCustomersItem.Enabled = enabled;
            MainMenuProjectsItem.Enabled = enabled;
            MainMenuActivitiesItem.Enabled = enabled;
            BtnAccept.Enabled = enabled;
            BtnCancel.Enabled = enabled;

            if (enabled)
            {
                DisplayAuthenticatedUserInTitleBar();
                ToolStripConnectionStatus.Text = MainLabels.Connected;
                ToolStripMenuItemDisconnectFromServer.Visible = true;
                ToolStripMenuItemConnectToServer.Visible = false;
                ToolStripConnectionStatus.Image = Properties.Resources.Connected;
            }
            else
            {
                Text = "mite.desk " + Helper.CurrentVersion + " - " + MainLabels.Disconnected;
                ToolStripConnectionStatus.Text = MainLabels.Disconnected;
                ToolStripMenuItemDisconnectFromServer.Visible = false;
                ToolStripMenuItemConnectToServer.Visible = true;
                ToolStripConnectionStatus.Image = Properties.Resources.Disconnected;
                StopwatchStatus.Visible = false;
                if (NotificationClockTimer != null && NotificationClockTimer.Enabled)
                    NotificationClockTimer.Stop();
                if (ActiveTimeEntryClockTimer != null)
                    ActiveTimeEntryClockTimer.Stop();
            }
        }

        #endregion

        #region Online- und Offlinemodus

        private void ConnectToServer(object sender, EventArgs e)
        {
            try
            {
                ObjectFactory.GetInstance<IAuthenticationService>().GetAuthenticatedUser();
                InitializeForm(false);
            }
            catch (MiteConnectorException ex)
            {
                NotifyAboutNetworkErrorAndDisableForm(ex);
                MessageBox.Show(MainLabels.MsgBoxConnectionErrorText, MainLabels.MsgBoxConnectionErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void DisconnectFromServer(object sender, EventArgs e)
        {
            EnableOrDisableForm(false);
        }

        #endregion

        #region Stoppuhr

        private void HandleStopwatch(int timeEntryID)
        {
            Cursor = Cursors.WaitCursor;
            Stopwatch.Enabled = false;

            int stoppedTimeEntryID = StopStopwatch();
            if (stoppedTimeEntryID != timeEntryID)
                StartStopwatch(timeEntryID);
            RefreshStopwatchStatus();           
            RefreshTimeEntries();
        	RefreshListTimeEntriesGroupLabel();

            Stopwatch.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void StartStopwatch(int timeEntryID)
        {
            TimeEntryService.StartStopwatch(timeEntryID);
            TrackedTimeEntry = TimeEntryService.GetTimeEntryCurrentlyTrackedByStopwatch();
            if (NotifyIcon.Visible)
            {
                NotifyIcon.Icon = Properties.Resources.mitedesk_clock_6;
                NotifyIcon.Text = GetTimeEntryDisplayText(TrackedTimeEntry, 63);
                NotificationClockTimer.Start();
            }
        }

        private int StopStopwatch()
        {
            int trackedTimeEntryID = TrackedTimeEntry != null ? TrackedTimeEntry.ID : 0;
            if (trackedTimeEntryID != 0)
            {
                TimeEntryService.StopStopwatch(trackedTimeEntryID);
                TrackedTimeEntry = null;
                Time.Enabled = CurrentTimeEntry == null || !CurrentTimeEntry.Locked;
                if (NotifyIcon.Visible)
                {
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_6;
                    NotifyIcon.Text = MainLabels.StopwatchNotStarted;
                    NotificationClockTimer.Stop();
                }
            }
            return trackedTimeEntryID;
        }

        void StopwatchStatus_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        void StopwatchStatus_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = e.X >= 355 ? Cursors.Hand : Cursors.Default;
        }

        private void Stopwatch_Tick(object sender, EventArgs e)
        {

            bool wasTracking = TrackedTimeEntry != null;
            TrackedTimeEntry = TimeEntryService.GetTimeEntryCurrentlyTrackedByStopwatch();

            bool isTracking = TrackedTimeEntry != null;
            bool statusHasChanged = wasTracking != isTracking;

            if (statusHasChanged)
                Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, Calendar.SelectionStart);

            RefreshStopwatchStatus();
            RefreshTimeEntries();

            if (WindowState == FormWindowState.Minimized) 
                RefreshTaskbarNotificationInfo(false);

        }

        private void RefreshStopwatchStatus()
        {
            if (TrackedTimeEntry != null)
            {
                StopwatchStatus.Text = string.Format(MainLabels.Stopwatch + ": {0}", Helper.GetFormattedTimeText(TrackedTimeEntry.Minutes));
                StopwatchStatus.Visible = true;
                ActiveTimeEntryClockTimer.Enabled = true;
                if(NotifyIcon.Visible)
                {
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_6;
                    NotifyIcon.Text = GetTimeEntryDisplayText(TrackedTimeEntry, 63);
                    if (!NotificationClockTimer.Enabled)
                        NotificationClockTimer.Start();
                }
                else
                {
                    if (TimeEntries != null)
                    {
                        var timeEntry = TimeEntries.SingleOrDefault(t => t.ID == TrackedTimeEntry.ID);
                        if (timeEntry != null)
                            timeEntry.Minutes = TrackedTimeEntry.Minutes;
                    }
                    RefreshListTimeEntriesGroupLabel();
                }
                if (CurrentTimeEntry != null && CurrentTimeEntry.ID == TrackedTimeEntry.ID)
                {
                    Time.Text = Helper.GetFormattedTimeText(TrackedTimeEntry.Minutes);
                    Time.Enabled = false;
                }
                else if(CurrentTimeEntry == null || !CurrentTimeEntry.Locked)
                {
                    Time.Enabled = true;
                }
            }
            else
            {
                Time.Enabled = CurrentTimeEntry == null || !CurrentTimeEntry.Locked;
                StopwatchStatus.Visible = false;
                ActiveTimeEntryClockTimer.Enabled = false;
                if(NotifyIcon.Visible)
                {
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_6;
                    NotifyIcon.Text = MainLabels.StopwatchNotStarted;
                    NotificationClockTimer.Stop();
                }
            }
        }

        private void StopwatchStatus_Click(object sender, EventArgs e)
        {
            Calendar.SelectionStart = TrackedTimeEntry.Date;
            Helper.StartBackgroundWorker(TimeEntriesBackgroundWorker, TrackedTimeEntry.Date);
            SetWeekOfYear(TrackedTimeEntry.Date);
        }

        #endregion

        #region Minimierung Taskbar

        private const int SizeMinimized = 1;
        private const int WmSize = 5;
        private const int SwRestore = 9;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WmSize && (int)m.WParam == SizeMinimized)
            {
                RefreshTaskbarNotificationInfo(true);
            }
            else if(m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                if(!Visible)
                    ReOpenMainForm();
                Activate();
            }
            base.WndProc(ref m);
        }

        void RefreshTaskbarNotificationInfo(bool initialize)
        {

            Visible = false;
            WindowState = FormWindowState.Minimized;
            NotifyIcon.Icon = Properties.Resources.mitedesk_clock_6;

            // Nur wenn nicht im offline-Modus
            if (Stopwatch.Enabled && TrackedTimeEntry != null)
            {
                NotifyIcon.Text = GetTimeEntryDisplayText(TrackedTimeEntry, 63);
                NotificationIconNumber = 0;
                NotificationClockTimer.Start();
            }
            else
            {
                NotifyIcon.Text = MainLabels.StopwatchNotStarted;
            }

            if (!initialize)
                return;

            NotifyIcon.Visible = true;
            NotifyIcon.MouseClick += NotifyIcon_MouseClick;
            
        }

        private void ReOpenMainForm()
        {
            if (NotificationClockTimer != null && NotificationClockTimer.Enabled)
                NotificationClockTimer.Stop();
            Visible = true;
            ShowInTaskbar = true;
            NotifyIcon.Visible = false;
            WinApi.ShowWindow(Handle, SwRestore);
            ListProjects.Focus();
        }

        void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left || e.Clicks > 1)
                return;
            ReOpenMainForm();
        }

        private void NotifyContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TimeEntry entry = null;
            if (TimeEntries != null) 
                entry = TimeEntries.SingleOrDefault(t => t.ID == LastTrackedTimeEntryID);
            NotifyContextMenuStartStopwatchItem.Visible = NotificationClockTimer != null && !NotificationClockTimer.Enabled;
            NotifyContextMenuStartStopwatchItem.Enabled = entry != null && !entry.Locked;
            NotifyContextMenuStopStopwatchItem.Visible = NotificationClockTimer != null && NotificationClockTimer.Enabled;
        }

        private void NotifyContextMenuStartStopwatchItem_Click(object sender, EventArgs e)
        {
            HandleStopwatch(LastTrackedTimeEntryID);
        }

        private void NotifyContextMenuStopStopwatchItem_Click(object sender, EventArgs e)
        {
            HandleStopwatch(TrackedTimeEntry.ID);
        }

        private void NotifyContextMenuOpenMiteDeskItem_Click(object sender, EventArgs e)
        {
            ReOpenMainForm();
        }

        private void NotifyContextMenuExitApplicationItem_Click(object sender, EventArgs e)
        {
            if(HandleClosing())
                Application.Exit();
        }

        #region Stoppuhr in Taskbar

        private int NotificationIconNumber;

        void NotificationClockTimer_Tick(object sender, EventArgs e)
        {

            if(WindowState != FormWindowState.Minimized)
            {
                NotificationClockTimer.Stop();
                return;
            }

            if (NotificationIconNumber == 8)
                NotificationIconNumber = 0;

            NotificationIconNumber++;

            // bad, bad, bad ... :(
            switch(NotificationIconNumber)
            {
                case 1:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_1;
                    break;
                case 2:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_2;
                    break;
                case 3:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_3;
                    break;
                case 4:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_4;
                    break;
                case 5:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_5;
                    break;
                case 6:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_6;
                    break;
                case 7:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_7;
                    break;
                case 8:
                    NotifyIcon.Icon = Properties.Resources.mitedesk_clock_8;
                    break;
            }
        }

        #endregion

        #endregion

        #region Schließen/Minimieren

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            if (AppSettings.MinimizeByClosing)
            {
                RefreshTaskbarNotificationInfo(true);
                e.Cancel = true;
                return;
            }

            if (!HandleClosing())
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);

        }

        private bool HandleClosing()
        {

            if (AppSettings.StopStopwatchByClosing)
            {
                StopStopwatch();
            }

            else if (AppSettings.AskForStoppingStopwatchByClosing && TrackedTimeEntry != null)
            {
                var result = MessageBox.Show(MainLabels.AskForStoppingStopwatch, MainLabels.Stopwatch, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StopStopwatch();
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;

        }

        #endregion


    }

}
