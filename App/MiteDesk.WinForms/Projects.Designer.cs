namespace SixtyNineDegrees.MiteDesk.WinForms
{
    partial class Projects
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
            this.TabCustomers = new System.Windows.Forms.TabControl();
            this.ActiveProjectsTabPage = new System.Windows.Forms.TabPage();
            this.ActiveProjectsTree = new System.Windows.Forms.TreeView();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchivedCustomersTabPage = new System.Windows.Forms.TabPage();
            this.ArchivedProjectsTree = new System.Windows.Forms.TreeView();
            this.FormGroup = new System.Windows.Forms.GroupBox();
            this.BtnOpenCustomers = new System.Windows.Forms.Button();
            this.ListBudgetType = new System.Windows.Forms.ComboBox();
            this.BoxBudget = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListCustomers = new System.Windows.Forms.ComboBox();
            this.CheckBoxArchived = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxNote = new System.Windows.Forms.TextBox();
            this.BoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnNewProject = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TreeDataBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.TabCustomers.SuspendLayout();
            this.ActiveProjectsTabPage.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.ArchivedCustomersTabPage.SuspendLayout();
            this.FormGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCustomers
            // 
            this.TabCustomers.Controls.Add(this.ActiveProjectsTabPage);
            this.TabCustomers.Controls.Add(this.ArchivedCustomersTabPage);
            this.TabCustomers.Location = new System.Drawing.Point(9, 7);
            this.TabCustomers.Name = "TabCustomers";
            this.TabCustomers.SelectedIndex = 0;
            this.TabCustomers.Size = new System.Drawing.Size(189, 277);
            this.TabCustomers.TabIndex = 10;
            // 
            // ActiveProjectsTabPage
            // 
            this.ActiveProjectsTabPage.Controls.Add(this.ActiveProjectsTree);
            this.ActiveProjectsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ActiveProjectsTabPage.Name = "ActiveProjectsTabPage";
            this.ActiveProjectsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActiveProjectsTabPage.Size = new System.Drawing.Size(181, 251);
            this.ActiveProjectsTabPage.TabIndex = 0;
            this.ActiveProjectsTabPage.Text = "Aktive";
            this.ActiveProjectsTabPage.UseVisualStyleBackColor = true;
            // 
            // ActiveProjectsTree
            // 
            this.ActiveProjectsTree.ContextMenuStrip = this.TreeContextMenu;
            this.ActiveProjectsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveProjectsTree.FullRowSelect = true;
            this.ActiveProjectsTree.HideSelection = false;
            this.ActiveProjectsTree.Location = new System.Drawing.Point(3, 3);
            this.ActiveProjectsTree.Name = "ActiveProjectsTree";
            this.ActiveProjectsTree.ShowLines = false;
            this.ActiveProjectsTree.ShowPlusMinus = false;
            this.ActiveProjectsTree.ShowRootLines = false;
            this.ActiveProjectsTree.Size = new System.Drawing.Size(175, 245);
            this.ActiveProjectsTree.TabIndex = 2;
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.DeleteToolStripMenuItem.Text = "Löschen";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click_1);
            // 
            // ArchivedCustomersTabPage
            // 
            this.ArchivedCustomersTabPage.Controls.Add(this.ArchivedProjectsTree);
            this.ArchivedCustomersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ArchivedCustomersTabPage.Name = "ArchivedCustomersTabPage";
            this.ArchivedCustomersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ArchivedCustomersTabPage.Size = new System.Drawing.Size(181, 251);
            this.ArchivedCustomersTabPage.TabIndex = 1;
            this.ArchivedCustomersTabPage.Text = "Archivierte";
            this.ArchivedCustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // ArchivedProjectsTree
            // 
            this.ArchivedProjectsTree.ContextMenuStrip = this.TreeContextMenu;
            this.ArchivedProjectsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivedProjectsTree.FullRowSelect = true;
            this.ArchivedProjectsTree.HideSelection = false;
            this.ArchivedProjectsTree.Location = new System.Drawing.Point(3, 3);
            this.ArchivedProjectsTree.Name = "ArchivedProjectsTree";
            this.ArchivedProjectsTree.ShowLines = false;
            this.ArchivedProjectsTree.ShowPlusMinus = false;
            this.ArchivedProjectsTree.ShowRootLines = false;
            this.ArchivedProjectsTree.Size = new System.Drawing.Size(175, 245);
            this.ArchivedProjectsTree.TabIndex = 1;
            // 
            // FormGroup
            // 
            this.FormGroup.Controls.Add(this.BtnOpenCustomers);
            this.FormGroup.Controls.Add(this.ListBudgetType);
            this.FormGroup.Controls.Add(this.BoxBudget);
            this.FormGroup.Controls.Add(this.label4);
            this.FormGroup.Controls.Add(this.label3);
            this.FormGroup.Controls.Add(this.ListCustomers);
            this.FormGroup.Controls.Add(this.CheckBoxArchived);
            this.FormGroup.Controls.Add(this.label2);
            this.FormGroup.Controls.Add(this.BoxNote);
            this.FormGroup.Controls.Add(this.BoxName);
            this.FormGroup.Controls.Add(this.label1);
            this.FormGroup.Enabled = false;
            this.FormGroup.Location = new System.Drawing.Point(215, 8);
            this.FormGroup.Name = "FormGroup";
            this.FormGroup.Size = new System.Drawing.Size(313, 276);
            this.FormGroup.TabIndex = 11;
            this.FormGroup.TabStop = false;
            // 
            // BtnOpenCustomers
            // 
            this.BtnOpenCustomers.Location = new System.Drawing.Point(209, 174);
            this.BtnOpenCustomers.Name = "BtnOpenCustomers";
            this.BtnOpenCustomers.Size = new System.Drawing.Size(77, 21);
            this.BtnOpenCustomers.TabIndex = 9;
            this.BtnOpenCustomers.Text = "Kunden ...";
            this.BtnOpenCustomers.UseVisualStyleBackColor = true;
            this.BtnOpenCustomers.Click += new System.EventHandler(this.BtnOpenCustomers_Click);
            // 
            // ListBudgetType
            // 
            this.ListBudgetType.FormattingEnabled = true;
            this.ListBudgetType.Location = new System.Drawing.Point(116, 215);
            this.ListBudgetType.Name = "ListBudgetType";
            this.ListBudgetType.Size = new System.Drawing.Size(87, 21);
            this.ListBudgetType.TabIndex = 7;
            this.ListBudgetType.SelectedIndexChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // BoxBudget
            // 
            this.BoxBudget.Location = new System.Drawing.Point(10, 216);
            this.BoxBudget.Name = "BoxBudget";
            this.BoxBudget.Size = new System.Drawing.Size(100, 20);
            this.BoxBudget.TabIndex = 6;
            this.BoxBudget.Text = "0:00";
            this.BoxBudget.TextChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Budget";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kunde";
            // 
            // ListCustomers
            // 
            this.ListCustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ListCustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ListCustomers.DisplayMember = "Text";
            this.ListCustomers.FormattingEnabled = true;
            this.ListCustomers.Location = new System.Drawing.Point(10, 174);
            this.ListCustomers.Name = "ListCustomers";
            this.ListCustomers.Size = new System.Drawing.Size(193, 21);
            this.ListCustomers.TabIndex = 5;
            this.ListCustomers.ValueMember = "Value";
            this.ListCustomers.SelectedIndexChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // CheckBoxArchived
            // 
            this.CheckBoxArchived.AutoSize = true;
            this.CheckBoxArchived.Location = new System.Drawing.Point(10, 242);
            this.CheckBoxArchived.Name = "CheckBoxArchived";
            this.CheckBoxArchived.Size = new System.Drawing.Size(70, 17);
            this.CheckBoxArchived.TabIndex = 8;
            this.CheckBoxArchived.Text = "Archiviert";
            this.CheckBoxArchived.UseVisualStyleBackColor = true;
            this.CheckBoxArchived.CheckedChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bemerkung";
            // 
            // BoxNote
            // 
            this.BoxNote.Location = new System.Drawing.Point(10, 79);
            this.BoxNote.Multiline = true;
            this.BoxNote.Name = "BoxNote";
            this.BoxNote.Size = new System.Drawing.Size(276, 75);
            this.BoxNote.TabIndex = 4;
            this.BoxNote.TextChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // BoxName
            // 
            this.BoxName.Location = new System.Drawing.Point(10, 37);
            this.BoxName.Name = "BoxName";
            this.BoxName.Size = new System.Drawing.Size(276, 20);
            this.BoxName.TabIndex = 3;
            this.BoxName.TextChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // BtnNewProject
            // 
            this.BtnNewProject.Location = new System.Drawing.Point(10, 294);
            this.BtnNewProject.Name = "BtnNewProject";
            this.BtnNewProject.Size = new System.Drawing.Size(87, 23);
            this.BtnNewProject.TabIndex = 12;
            this.BtnNewProject.Text = "Neues Projekt";
            this.BtnNewProject.UseVisualStyleBackColor = true;
            this.BtnNewProject.Click += new System.EventHandler(this.BtnNewProject_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(445, 294);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(83, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Schließen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click_1);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(356, 295);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(83, 23);
            this.BtnSave.TabIndex = 9;
            this.BtnSave.Text = "Übernehmen";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // Projects
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(537, 330);
            this.Controls.Add(this.TabCustomers);
            this.Controls.Add(this.FormGroup);
            this.Controls.Add(this.BtnNewProject);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(543, 355);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(543, 355);
            this.Name = "Projects";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projekte";
            this.TabCustomers.ResumeLayout(false);
            this.ActiveProjectsTabPage.ResumeLayout(false);
            this.TreeContextMenu.ResumeLayout(false);
            this.ArchivedCustomersTabPage.ResumeLayout(false);
            this.FormGroup.ResumeLayout(false);
            this.FormGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCustomers;
        private System.Windows.Forms.TabPage ActiveProjectsTabPage;
        private System.Windows.Forms.TreeView ActiveProjectsTree;
        private System.Windows.Forms.TabPage ArchivedCustomersTabPage;
        private System.Windows.Forms.TreeView ArchivedProjectsTree;
        private System.Windows.Forms.GroupBox FormGroup;
        private System.Windows.Forms.CheckBox CheckBoxArchived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxNote;
        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNewProject;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ListCustomers;
        private System.Windows.Forms.ComboBox ListBudgetType;
        private System.Windows.Forms.TextBox BoxBudget;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnOpenCustomers;
        public System.ComponentModel.BackgroundWorker TreeDataBackgroundWorker;
    }
}