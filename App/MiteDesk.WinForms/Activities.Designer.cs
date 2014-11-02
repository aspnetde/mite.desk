namespace SixtyNineDegrees.MiteDesk.WinForms
{
    partial class Activities
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
            this.ActiveActivitiesTabPage = new System.Windows.Forms.TabPage();
            this.ActivActivitiesTree = new System.Windows.Forms.TreeView();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchivedCustomersTabPage = new System.Windows.Forms.TabPage();
            this.ArchivedActivitiesTree = new System.Windows.Forms.TreeView();
            this.FormGroup = new System.Windows.Forms.GroupBox();
            this.BoxHourlyRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckBoxBillable = new System.Windows.Forms.CheckBox();
            this.CheckBoxArchived = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxNote = new System.Windows.Forms.TextBox();
            this.BoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnNewActivity = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TreeDataBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.TabCustomers.SuspendLayout();
            this.ActiveActivitiesTabPage.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.ArchivedCustomersTabPage.SuspendLayout();
            this.FormGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCustomers
            // 
            this.TabCustomers.Controls.Add(this.ActiveActivitiesTabPage);
            this.TabCustomers.Controls.Add(this.ArchivedCustomersTabPage);
            this.TabCustomers.Location = new System.Drawing.Point(9, 9);
            this.TabCustomers.Name = "TabCustomers";
            this.TabCustomers.SelectedIndex = 0;
            this.TabCustomers.Size = new System.Drawing.Size(189, 277);
            this.TabCustomers.TabIndex = 10;
            // 
            // ActiveActivitiesTabPage
            // 
            this.ActiveActivitiesTabPage.Controls.Add(this.ActivActivitiesTree);
            this.ActiveActivitiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ActiveActivitiesTabPage.Name = "ActiveActivitiesTabPage";
            this.ActiveActivitiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActiveActivitiesTabPage.Size = new System.Drawing.Size(181, 251);
            this.ActiveActivitiesTabPage.TabIndex = 0;
            this.ActiveActivitiesTabPage.Text = "Aktive";
            this.ActiveActivitiesTabPage.UseVisualStyleBackColor = true;
            // 
            // ActivActivitiesTree
            // 
            this.ActivActivitiesTree.ContextMenuStrip = this.TreeContextMenu;
            this.ActivActivitiesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActivActivitiesTree.FullRowSelect = true;
            this.ActivActivitiesTree.HideSelection = false;
            this.ActivActivitiesTree.Location = new System.Drawing.Point(3, 3);
            this.ActivActivitiesTree.Name = "ActivActivitiesTree";
            this.ActivActivitiesTree.ShowLines = false;
            this.ActivActivitiesTree.ShowPlusMinus = false;
            this.ActivActivitiesTree.ShowRootLines = false;
            this.ActivActivitiesTree.Size = new System.Drawing.Size(175, 245);
            this.ActivActivitiesTree.TabIndex = 2;
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            this.TreeContextMenu.Size = new System.Drawing.Size(119, 26);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.DeleteToolStripMenuItem.Text = "Löschen";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // ArchivedCustomersTabPage
            // 
            this.ArchivedCustomersTabPage.Controls.Add(this.ArchivedActivitiesTree);
            this.ArchivedCustomersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ArchivedCustomersTabPage.Name = "ArchivedCustomersTabPage";
            this.ArchivedCustomersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ArchivedCustomersTabPage.Size = new System.Drawing.Size(181, 251);
            this.ArchivedCustomersTabPage.TabIndex = 1;
            this.ArchivedCustomersTabPage.Text = "Archivierte";
            this.ArchivedCustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // ArchivedActivitiesTree
            // 
            this.ArchivedActivitiesTree.ContextMenuStrip = this.TreeContextMenu;
            this.ArchivedActivitiesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivedActivitiesTree.FullRowSelect = true;
            this.ArchivedActivitiesTree.HideSelection = false;
            this.ArchivedActivitiesTree.Location = new System.Drawing.Point(3, 3);
            this.ArchivedActivitiesTree.Name = "ArchivedActivitiesTree";
            this.ArchivedActivitiesTree.ShowLines = false;
            this.ArchivedActivitiesTree.ShowPlusMinus = false;
            this.ArchivedActivitiesTree.ShowRootLines = false;
            this.ArchivedActivitiesTree.Size = new System.Drawing.Size(175, 245);
            this.ArchivedActivitiesTree.TabIndex = 1;
            // 
            // FormGroup
            // 
            this.FormGroup.Controls.Add(this.BoxHourlyRate);
            this.FormGroup.Controls.Add(this.label3);
            this.FormGroup.Controls.Add(this.CheckBoxBillable);
            this.FormGroup.Controls.Add(this.CheckBoxArchived);
            this.FormGroup.Controls.Add(this.label2);
            this.FormGroup.Controls.Add(this.BoxNote);
            this.FormGroup.Controls.Add(this.BoxName);
            this.FormGroup.Controls.Add(this.label1);
            this.FormGroup.Enabled = false;
            this.FormGroup.Location = new System.Drawing.Point(215, 10);
            this.FormGroup.Name = "FormGroup";
            this.FormGroup.Size = new System.Drawing.Size(313, 276);
            this.FormGroup.TabIndex = 11;
            this.FormGroup.TabStop = false;
            // 
            // BoxHourlyRate
            // 
            this.BoxHourlyRate.Location = new System.Drawing.Point(10, 175);
            this.BoxHourlyRate.Name = "BoxHourlyRate";
            this.BoxHourlyRate.Size = new System.Drawing.Size(43, 20);
            this.BoxHourlyRate.TabIndex = 5;
            this.BoxHourlyRate.TextChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stundensatz in €";
            // 
            // CheckBoxBillable
            // 
            this.CheckBoxBillable.AutoSize = true;
            this.CheckBoxBillable.Location = new System.Drawing.Point(89, 177);
            this.CheckBoxBillable.Name = "CheckBoxBillable";
            this.CheckBoxBillable.Size = new System.Drawing.Size(96, 17);
            this.CheckBoxBillable.TabIndex = 6;
            this.CheckBoxBillable.Text = "Verrechenbar?";
            this.CheckBoxBillable.UseVisualStyleBackColor = true;
            this.CheckBoxBillable.CheckedChanged += new System.EventHandler(this.EnableBtnSave);
            // 
            // CheckBoxArchived
            // 
            this.CheckBoxArchived.AutoSize = true;
            this.CheckBoxArchived.Location = new System.Drawing.Point(216, 177);
            this.CheckBoxArchived.Name = "CheckBoxArchived";
            this.CheckBoxArchived.Size = new System.Drawing.Size(70, 17);
            this.CheckBoxArchived.TabIndex = 7;
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
            // BtnNewActivity
            // 
            this.BtnNewActivity.Location = new System.Drawing.Point(10, 296);
            this.BtnNewActivity.Name = "BtnNewActivity";
            this.BtnNewActivity.Size = new System.Drawing.Size(87, 23);
            this.BtnNewActivity.TabIndex = 11;
            this.BtnNewActivity.Text = "Neue Leistung";
            this.BtnNewActivity.UseVisualStyleBackColor = true;
            this.BtnNewActivity.Click += new System.EventHandler(this.BtnNewActivity_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(445, 296);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(83, 23);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Schließen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(356, 296);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(83, 23);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "Übernehmen";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // Activities
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(537, 327);
            this.Controls.Add(this.TabCustomers);
            this.Controls.Add(this.FormGroup);
            this.Controls.Add(this.BtnNewActivity);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(553, 365);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(553, 365);
            this.Name = "Activities";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Leistungen";
            this.TabCustomers.ResumeLayout(false);
            this.ActiveActivitiesTabPage.ResumeLayout(false);
            this.TreeContextMenu.ResumeLayout(false);
            this.ArchivedCustomersTabPage.ResumeLayout(false);
            this.FormGroup.ResumeLayout(false);
            this.FormGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCustomers;
        private System.Windows.Forms.TabPage ActiveActivitiesTabPage;
        private System.Windows.Forms.TreeView ActivActivitiesTree;
        private System.Windows.Forms.TabPage ArchivedCustomersTabPage;
        private System.Windows.Forms.TreeView ArchivedActivitiesTree;
        private System.Windows.Forms.GroupBox FormGroup;
        private System.Windows.Forms.CheckBox CheckBoxArchived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxNote;
        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNewActivity;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.ComponentModel.BackgroundWorker TreeDataBackgroundWorker;
        private System.Windows.Forms.TextBox BoxHourlyRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheckBoxBillable;
    }
}