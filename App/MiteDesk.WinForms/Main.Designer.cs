namespace SixtyNineDegrees.MiteDesk.WinForms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemRefreshActivitiesAndProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemCreateNewTimeEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuCustomersItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuProjectsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuActivitiesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miteZeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeEntryDetailView = new System.Windows.Forms.GroupBox();
            this.Locked = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.Note = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ListActivities = new System.Windows.Forms.ComboBox();
            this.ListProjects = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListTimeEntries = new System.Windows.Forms.ListView();
            this.TextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeEntryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TimeEntryContextMenuStopStopwatchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeEntryContextMenuStartStopwatchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.TimeEntryContextMenuUnlock = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeEntryContextMenuLock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.TimeEntryContextMenuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ToolStripConnectionStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemDisconnectFromServer = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemConnectToServer = new System.Windows.Forms.ToolStripMenuItem();
            this.StopwatchStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Stopwatch = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyContextMenuStartStopwatchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyContextMenuStopStopwatchItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.NotifyContextMenuOpenMiteDeskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.WeekOfYear = new System.Windows.Forms.Label();
            this.InitializationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.TimeEntriesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.MainMenu.SuspendLayout();
            this.TimeEntryDetailView.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TimeEntryContextMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.NotifyContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemExit,
            this.datenToolStripMenuItem,
            this.toolStripMenuItem1});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(572, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // MainMenuItemExit
            // 
            this.MainMenuItemExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemRefreshActivitiesAndProjects,
            this.MainMenuItemCreateNewTimeEntry,
            this.toolStripSeparator2,
            this.einstellungenToolStripMenuItem,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.MainMenuItemExit.Name = "MainMenuItemExit";
            this.MainMenuItemExit.Size = new System.Drawing.Size(70, 20);
            this.MainMenuItemExit.Text = "mite.desk";
            // 
            // MainMenuItemRefreshActivitiesAndProjects
            // 
            this.MainMenuItemRefreshActivitiesAndProjects.ImageTransparentColor = System.Drawing.Color.Black;
            this.MainMenuItemRefreshActivitiesAndProjects.Name = "MainMenuItemRefreshActivitiesAndProjects";
            this.MainMenuItemRefreshActivitiesAndProjects.ShortcutKeyDisplayString = "";
            this.MainMenuItemRefreshActivitiesAndProjects.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MainMenuItemRefreshActivitiesAndProjects.Size = new System.Drawing.Size(254, 22);
            this.MainMenuItemRefreshActivitiesAndProjects.Text = "Projekte/Leistungen neu laden";
            this.MainMenuItemRefreshActivitiesAndProjects.Click += new System.EventHandler(this.MainMenuItemRefreshProjectsAndActivitiesClick);
            // 
            // MainMenuItemCreateNewTimeEntry
            // 
            this.MainMenuItemCreateNewTimeEntry.ImageTransparentColor = System.Drawing.Color.Black;
            this.MainMenuItemCreateNewTimeEntry.Name = "MainMenuItemCreateNewTimeEntry";
            this.MainMenuItemCreateNewTimeEntry.ShortcutKeyDisplayString = "";
            this.MainMenuItemCreateNewTimeEntry.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MainMenuItemCreateNewTimeEntry.Size = new System.Drawing.Size(254, 22);
            this.MainMenuItemCreateNewTimeEntry.Text = "Neuen Zeiteintrag erstellen";
            this.MainMenuItemCreateNewTimeEntry.Click += new System.EventHandler(this.MainMenuItemCreateNewTimeEntryClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(251, 6);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.einstellungenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.MainMenuItemSettingsClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(251, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // datenToolStripMenuItem
            // 
            this.datenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuCustomersItem,
            this.MainMenuProjectsItem,
            this.MainMenuActivitiesItem});
            this.datenToolStripMenuItem.Name = "datenToolStripMenuItem";
            this.datenToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.datenToolStripMenuItem.Text = "Daten";
            this.datenToolStripMenuItem.Visible = false;
            // 
            // MainMenuCustomersItem
            // 
            this.MainMenuCustomersItem.Name = "MainMenuCustomersItem";
            this.MainMenuCustomersItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.MainMenuCustomersItem.Size = new System.Drawing.Size(151, 22);
            this.MainMenuCustomersItem.Text = "Kunden";
            this.MainMenuCustomersItem.Click += new System.EventHandler(this.MainMenuCustomersItem_Click);
            // 
            // MainMenuProjectsItem
            // 
            this.MainMenuProjectsItem.Name = "MainMenuProjectsItem";
            this.MainMenuProjectsItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MainMenuProjectsItem.Size = new System.Drawing.Size(151, 22);
            this.MainMenuProjectsItem.Text = "Projekte";
            this.MainMenuProjectsItem.Click += new System.EventHandler(this.MainMenuProjectsItem_Click);
            // 
            // MainMenuActivitiesItem
            // 
            this.MainMenuActivitiesItem.Name = "MainMenuActivitiesItem";
            this.MainMenuActivitiesItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.MainMenuActivitiesItem.Size = new System.Drawing.Size(151, 22);
            this.MainMenuActivitiesItem.Text = "Leistungen";
            this.MainMenuActivitiesItem.Click += new System.EventHandler(this.MainMenuActivitiesItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miteZeitenToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // miteZeitenToolStripMenuItem
            // 
            this.miteZeitenToolStripMenuItem.Image = global::SixtyNineDegrees.MiteDesk.WinForms.Properties.Resources.faviconico;
            this.miteZeitenToolStripMenuItem.Name = "miteZeitenToolStripMenuItem";
            this.miteZeitenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.miteZeitenToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.miteZeitenToolStripMenuItem.Text = "mite.account";
            this.miteZeitenToolStripMenuItem.Click += new System.EventHandler(this.miteZeitenToolStripMenuItem_Click);
            // 
            // TimeEntryDetailView
            // 
            this.TimeEntryDetailView.Controls.Add(this.Locked);
            this.TimeEntryDetailView.Controls.Add(this.BtnCancel);
            this.TimeEntryDetailView.Controls.Add(this.BtnAccept);
            this.TimeEntryDetailView.Controls.Add(this.Note);
            this.TimeEntryDetailView.Controls.Add(this.label5);
            this.TimeEntryDetailView.Controls.Add(this.Time);
            this.TimeEntryDetailView.Controls.Add(this.label4);
            this.TimeEntryDetailView.Controls.Add(this.ListActivities);
            this.TimeEntryDetailView.Controls.Add(this.ListProjects);
            this.TimeEntryDetailView.Controls.Add(this.label3);
            this.TimeEntryDetailView.Controls.Add(this.label2);
            this.TimeEntryDetailView.Location = new System.Drawing.Point(7, 34);
            this.TimeEntryDetailView.Name = "TimeEntryDetailView";
            this.TimeEntryDetailView.Size = new System.Drawing.Size(343, 216);
            this.TimeEntryDetailView.TabIndex = 29;
            this.TimeEntryDetailView.TabStop = false;
            this.TimeEntryDetailView.Text = "Neuen Zeiteintrag erstellen";
            // 
            // Locked
            // 
            this.Locked.AutoSize = true;
            this.Locked.Location = new System.Drawing.Point(161, 90);
            this.Locked.Name = "Locked";
            this.Locked.Size = new System.Drawing.Size(98, 17);
            this.Locked.TabIndex = 35;
            this.Locked.Text = "Abgeschlossen";
            this.Locked.UseVisualStyleBackColor = true;
            this.Locked.Visible = false;
            this.Locked.Click += new System.EventHandler(this.Locked_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(161, 185);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Verwerfen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAccept
            // 
            this.BtnAccept.Location = new System.Drawing.Point(78, 185);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(75, 23);
            this.BtnAccept.TabIndex = 6;
            this.BtnAccept.Text = "Erstellen";
            this.BtnAccept.UseVisualStyleBackColor = true;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // Note
            // 
            this.Note.Location = new System.Drawing.Point(78, 120);
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Note.Size = new System.Drawing.Size(242, 59);
            this.Note.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Bemerkung";
            // 
            // Time
            // 
            this.ErrorProvider.SetIconPadding(this.Time, 3);
            this.Time.Location = new System.Drawing.Point(78, 88);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(55, 20);
            this.Time.TabIndex = 4;
            this.Time.Text = "00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Dauer";
            // 
            // ListActivities
            // 
            this.ListActivities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ListActivities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ListActivities.FormattingEnabled = true;
            this.ErrorProvider.SetIconPadding(this.ListActivities, 3);
            this.ListActivities.Location = new System.Drawing.Point(78, 56);
            this.ListActivities.Name = "ListActivities";
            this.ListActivities.Size = new System.Drawing.Size(242, 21);
            this.ListActivities.TabIndex = 3;
            // 
            // ListProjects
            // 
            this.ListProjects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ListProjects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ListProjects.FormattingEnabled = true;
            this.ErrorProvider.SetIconPadding(this.ListProjects, 3);
            this.ListProjects.Location = new System.Drawing.Point(78, 24);
            this.ListProjects.Name = "ListProjects";
            this.ListProjects.Size = new System.Drawing.Size(242, 21);
            this.ListProjects.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Leistung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Projekt";
            // 
            // Calendar
            // 
            this.Calendar.BackColor = System.Drawing.SystemColors.Control;
            this.Calendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.Calendar.Location = new System.Drawing.Point(12, 24);
            this.Calendar.MaxSelectionCount = 1;
            this.Calendar.Name = "Calendar";
            this.Calendar.ShowTodayCircle = false;
            this.Calendar.TabIndex = 10;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.SelectDate);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListTimeEntries);
            this.groupBox2.Location = new System.Drawing.Point(7, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(557, 121);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Einträge für den 09.07.2009";
            // 
            // ListTimeEntries
            // 
            this.ListTimeEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TextColumn});
            this.ListTimeEntries.ContextMenuStrip = this.TimeEntryContextMenu;
            this.ListTimeEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListTimeEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListTimeEntries.HideSelection = false;
            this.ListTimeEntries.LabelWrap = false;
            this.ListTimeEntries.Location = new System.Drawing.Point(10, 23);
            this.ListTimeEntries.MultiSelect = false;
            this.ListTimeEntries.Name = "ListTimeEntries";
            this.ListTimeEntries.ShowGroups = false;
            this.ListTimeEntries.ShowItemToolTips = true;
            this.ListTimeEntries.Size = new System.Drawing.Size(537, 88);
            this.ListTimeEntries.TabIndex = 9;
            this.ListTimeEntries.UseCompatibleStateImageBehavior = false;
            this.ListTimeEntries.View = System.Windows.Forms.View.Details;
            this.ListTimeEntries.SelectedIndexChanged += new System.EventHandler(this.TimeEntries_SelectedIndexChanged);
            // 
            // TextColumn
            // 
            this.TextColumn.Text = "TextColumn";
            this.TextColumn.Width = 500;
            // 
            // TimeEntryContextMenu
            // 
            this.TimeEntryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeEntryContextMenuStopStopwatchItem,
            this.TimeEntryContextMenuStartStopwatchItem,
            this.toolStripSeparator9,
            this.TimeEntryContextMenuUnlock,
            this.TimeEntryContextMenuLock,
            this.toolStripSeparator8,
            this.TimeEntryContextMenuDeleteItem});
            this.TimeEntryContextMenu.Name = "TimeEntryContextMenu";
            this.TimeEntryContextMenu.Size = new System.Drawing.Size(259, 126);
            this.TimeEntryContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TimeEntryContextMenu_Opening);
            // 
            // TimeEntryContextMenuStopStopwatchItem
            // 
            this.TimeEntryContextMenuStopStopwatchItem.Name = "TimeEntryContextMenuStopStopwatchItem";
            this.TimeEntryContextMenuStopStopwatchItem.Size = new System.Drawing.Size(258, 22);
            this.TimeEntryContextMenuStopStopwatchItem.Text = "Stoppuhr anhalten";
            this.TimeEntryContextMenuStopStopwatchItem.Click += new System.EventHandler(this.TimeEntryContextMenuStopStopwatchItem_Click);
            // 
            // TimeEntryContextMenuStartStopwatchItem
            // 
            this.TimeEntryContextMenuStartStopwatchItem.Name = "TimeEntryContextMenuStartStopwatchItem";
            this.TimeEntryContextMenuStartStopwatchItem.Size = new System.Drawing.Size(258, 22);
            this.TimeEntryContextMenuStartStopwatchItem.Text = "Stoppuhr starten";
            this.TimeEntryContextMenuStartStopwatchItem.Click += new System.EventHandler(this.TimeEntryContextMenuStartStopwatchItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(255, 6);
            // 
            // TimeEntryContextMenuUnlock
            // 
            this.TimeEntryContextMenuUnlock.Name = "TimeEntryContextMenuUnlock";
            this.TimeEntryContextMenuUnlock.Size = new System.Drawing.Size(258, 22);
            this.TimeEntryContextMenuUnlock.Text = "Als nicht-abgeschlossen markieren";
            this.TimeEntryContextMenuUnlock.Visible = false;
            this.TimeEntryContextMenuUnlock.Click += new System.EventHandler(this.alsNichtabgeschlossenMarkierenToolStripMenuItem_Click);
            // 
            // TimeEntryContextMenuLock
            // 
            this.TimeEntryContextMenuLock.Name = "TimeEntryContextMenuLock";
            this.TimeEntryContextMenuLock.Size = new System.Drawing.Size(258, 22);
            this.TimeEntryContextMenuLock.Text = "Als abgeschlossen markieren";
            this.TimeEntryContextMenuLock.Click += new System.EventHandler(this.alsAbgeschlossenMarkierenToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(255, 6);
            // 
            // TimeEntryContextMenuDeleteItem
            // 
            this.TimeEntryContextMenuDeleteItem.Name = "TimeEntryContextMenuDeleteItem";
            this.TimeEntryContextMenuDeleteItem.Size = new System.Drawing.Size(258, 22);
            this.TimeEntryContextMenuDeleteItem.Text = "Löschen";
            this.TimeEntryContextMenuDeleteItem.Click += new System.EventHandler(this.TimeEntryContextMenuDeleteItem_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripConnectionStatus,
            this.StopwatchStatus});
            this.StatusBar.Location = new System.Drawing.Point(0, 386);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(572, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 31;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ToolStripConnectionStatus
            // 
            this.ToolStripConnectionStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemDisconnectFromServer,
            this.ToolStripMenuItemConnectToServer});
            this.ToolStripConnectionStatus.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripConnectionStatus.Image")));
            this.ToolStripConnectionStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripConnectionStatus.Name = "ToolStripConnectionStatus";
            this.ToolStripConnectionStatus.Size = new System.Drawing.Size(94, 20);
            this.ToolStripConnectionStatus.Text = "Verbunden";
            // 
            // ToolStripMenuItemDisconnectFromServer
            // 
            this.ToolStripMenuItemDisconnectFromServer.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemDisconnectFromServer.Image")));
            this.ToolStripMenuItemDisconnectFromServer.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripMenuItemDisconnectFromServer.Name = "ToolStripMenuItemDisconnectFromServer";
            this.ToolStripMenuItemDisconnectFromServer.Size = new System.Drawing.Size(190, 22);
            this.ToolStripMenuItemDisconnectFromServer.Text = "Verbindung trennen";
            this.ToolStripMenuItemDisconnectFromServer.Click += new System.EventHandler(this.DisconnectFromServer);
            // 
            // ToolStripMenuItemConnectToServer
            // 
            this.ToolStripMenuItemConnectToServer.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemConnectToServer.Image")));
            this.ToolStripMenuItemConnectToServer.ImageTransparentColor = System.Drawing.Color.Black;
            this.ToolStripMenuItemConnectToServer.Name = "ToolStripMenuItemConnectToServer";
            this.ToolStripMenuItemConnectToServer.Size = new System.Drawing.Size(190, 22);
            this.ToolStripMenuItemConnectToServer.Text = "Verbindung herstellen";
            this.ToolStripMenuItemConnectToServer.Visible = false;
            this.ToolStripMenuItemConnectToServer.Click += new System.EventHandler(this.ConnectToServer);
            // 
            // StopwatchStatus
            // 
            this.StopwatchStatus.Image = global::SixtyNineDegrees.MiteDesk.WinForms.Properties.Resources.mini_clock_animated_15x15;
            this.StopwatchStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StopwatchStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StopwatchStatus.Name = "StopwatchStatus";
            this.StopwatchStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.StopwatchStatus.Size = new System.Drawing.Size(463, 17);
            this.StopwatchStatus.Spring = true;
            this.StopwatchStatus.Text = "Stoppuhr: 00:00";
            this.StopwatchStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StopwatchStatus.Visible = false;
            this.StopwatchStatus.Click += new System.EventHandler(this.StopwatchStatus_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // Stopwatch
            // 
            this.Stopwatch.Interval = 30000;
            this.Stopwatch.Tick += new System.EventHandler(this.Stopwatch_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyContextMenu;
            // 
            // NotifyContextMenu
            // 
            this.NotifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyContextMenuStartStopwatchItem,
            this.NotifyContextMenuStopStopwatchItem,
            this.toolStripSeparator5,
            this.NotifyContextMenuOpenMiteDeskItem,
            this.toolStripSeparator6,
            this.ExitButton});
            this.NotifyContextMenu.Name = "NotifyContextMenu";
            this.NotifyContextMenu.Size = new System.Drawing.Size(173, 104);
            this.NotifyContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.NotifyContextMenu_Opening);
            // 
            // NotifyContextMenuStartStopwatchItem
            // 
            this.NotifyContextMenuStartStopwatchItem.Name = "NotifyContextMenuStartStopwatchItem";
            this.NotifyContextMenuStartStopwatchItem.Size = new System.Drawing.Size(172, 22);
            this.NotifyContextMenuStartStopwatchItem.Text = "Stoppuhr starten";
            this.NotifyContextMenuStartStopwatchItem.Click += new System.EventHandler(this.NotifyContextMenuStartStopwatchItem_Click);
            // 
            // NotifyContextMenuStopStopwatchItem
            // 
            this.NotifyContextMenuStopStopwatchItem.Name = "NotifyContextMenuStopStopwatchItem";
            this.NotifyContextMenuStopStopwatchItem.Size = new System.Drawing.Size(172, 22);
            this.NotifyContextMenuStopStopwatchItem.Text = "Stoppuhr anhalten";
            this.NotifyContextMenuStopStopwatchItem.Click += new System.EventHandler(this.NotifyContextMenuStopStopwatchItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(169, 6);
            // 
            // NotifyContextMenuOpenMiteDeskItem
            // 
            this.NotifyContextMenuOpenMiteDeskItem.Name = "NotifyContextMenuOpenMiteDeskItem";
            this.NotifyContextMenuOpenMiteDeskItem.Size = new System.Drawing.Size(172, 22);
            this.NotifyContextMenuOpenMiteDeskItem.Text = "Wiederherstellen";
            this.NotifyContextMenuOpenMiteDeskItem.Click += new System.EventHandler(this.NotifyContextMenuOpenMiteDeskItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(169, 6);
            // 
            // ExitButton
            // 
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(172, 22);
            this.ExitButton.Text = "Beenden";
            this.ExitButton.Click += new System.EventHandler(this.NotifyContextMenuExitApplicationItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WeekOfYear);
            this.groupBox1.Controls.Add(this.Calendar);
            this.groupBox1.Location = new System.Drawing.Point(364, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 216);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kalender";
            // 
            // WeekOfYear
            // 
            this.WeekOfYear.AutoSize = true;
            this.WeekOfYear.Location = new System.Drawing.Point(9, 195);
            this.WeekOfYear.Name = "WeekOfYear";
            this.WeekOfYear.Size = new System.Drawing.Size(135, 13);
            this.WeekOfYear.TabIndex = 28;
            this.WeekOfYear.Text = "Gewählte Kalenderwoche: ";
            // 
            // InitializationBackgroundWorker
            // 
            this.InitializationBackgroundWorker.WorkerSupportsCancellation = true;
            // 
            // TimeEntriesBackgroundWorker
            // 
            this.TimeEntriesBackgroundWorker.WorkerSupportsCancellation = true;
            // 
            // Main
            // 
            this.AcceptButton = this.BtnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(572, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.TimeEntryDetailView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mite.desk";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.TimeEntryDetailView.ResumeLayout(false);
            this.TimeEntryDetailView.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.TimeEntryContextMenu.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.NotifyContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem MainMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox TimeEntryDetailView;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnAccept;
        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ListActivities;
        private System.Windows.Forms.ComboBox ListProjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.ToolStripStatusLabel StopwatchStatus;
        private System.Windows.Forms.ToolStripMenuItem MainMenuItemCreateNewTimeEntry;
        private System.Windows.Forms.ToolStripMenuItem MainMenuItemRefreshActivitiesAndProjects;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton ToolStripConnectionStatus;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemConnectToServer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDisconnectFromServer;
        private System.Windows.Forms.ListView ListTimeEntries;
        private System.Windows.Forms.ColumnHeader TextColumn;
        private System.Windows.Forms.Timer Stopwatch;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label WeekOfYear;
        private System.Windows.Forms.ToolStripMenuItem miteZeitenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TimeEntryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem TimeEntryContextMenuStartStopwatchItem;
        private System.Windows.Forms.ToolStripMenuItem TimeEntryContextMenuStopStopwatchItem;
        private System.Windows.Forms.ContextMenuStrip NotifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem NotifyContextMenuStartStopwatchItem;
        private System.Windows.Forms.ToolStripMenuItem NotifyContextMenuStopStopwatchItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem NotifyContextMenuOpenMiteDeskItem;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.ComponentModel.BackgroundWorker TimeEntriesBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem datenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainMenuCustomersItem;
        private System.Windows.Forms.ToolStripMenuItem MainMenuProjectsItem;
        private System.Windows.Forms.ToolStripMenuItem MainMenuActivitiesItem;
        public System.ComponentModel.BackgroundWorker InitializationBackgroundWorker;
        private System.Windows.Forms.CheckBox Locked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem TimeEntryContextMenuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem TimeEntryContextMenuUnlock;
        private System.Windows.Forms.ToolStripMenuItem TimeEntryContextMenuLock;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}