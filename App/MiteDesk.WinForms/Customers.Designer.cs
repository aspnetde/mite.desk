namespace SixtyNineDegrees.MiteDesk.WinForms
{
    partial class Customers
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
            this.ActiveCustomersTree = new System.Windows.Forms.TreeView();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSave = new System.Windows.Forms.Button();
            this.FormGroup = new System.Windows.Forms.GroupBox();
            this.CheckBoxArchived = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxNote = new System.Windows.Forms.TextBox();
            this.BoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabCustomers = new System.Windows.Forms.TabControl();
            this.ActiveCustomersTabPage = new System.Windows.Forms.TabPage();
            this.ArchivedCustomersTabPage = new System.Windows.Forms.TabPage();
            this.ArchivedCustomersTree = new System.Windows.Forms.TreeView();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TreeDataBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnNewCustomer = new System.Windows.Forms.Button();
            this.TreeContextMenu.SuspendLayout();
            this.FormGroup.SuspendLayout();
            this.TabCustomers.SuspendLayout();
            this.ActiveCustomersTabPage.SuspendLayout();
            this.ArchivedCustomersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveCustomersTree
            // 
            this.ActiveCustomersTree.ContextMenuStrip = this.TreeContextMenu;
            this.ActiveCustomersTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveCustomersTree.FullRowSelect = true;
            this.ActiveCustomersTree.HideSelection = false;
            this.ActiveCustomersTree.Location = new System.Drawing.Point(3, 3);
            this.ActiveCustomersTree.Name = "ActiveCustomersTree";
            this.ActiveCustomersTree.ShowLines = false;
            this.ActiveCustomersTree.ShowPlusMinus = false;
            this.ActiveCustomersTree.ShowRootLines = false;
            this.ActiveCustomersTree.Size = new System.Drawing.Size(175, 245);
            this.ActiveCustomersTree.TabIndex = 2;
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
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(355, 295);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(83, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Übernehmen";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FormGroup
            // 
            this.FormGroup.Controls.Add(this.CheckBoxArchived);
            this.FormGroup.Controls.Add(this.label2);
            this.FormGroup.Controls.Add(this.BoxNote);
            this.FormGroup.Controls.Add(this.BoxName);
            this.FormGroup.Controls.Add(this.label1);
            this.FormGroup.Enabled = false;
            this.FormGroup.Location = new System.Drawing.Point(214, 9);
            this.FormGroup.Name = "FormGroup";
            this.FormGroup.Size = new System.Drawing.Size(313, 276);
            this.FormGroup.TabIndex = 3;
            this.FormGroup.TabStop = false;
            // 
            // CheckBoxArchived
            // 
            this.CheckBoxArchived.AutoSize = true;
            this.CheckBoxArchived.Location = new System.Drawing.Point(10, 160);
            this.CheckBoxArchived.Name = "CheckBoxArchived";
            this.CheckBoxArchived.Size = new System.Drawing.Size(70, 17);
            this.CheckBoxArchived.TabIndex = 5;
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
            // TabCustomers
            // 
            this.TabCustomers.Controls.Add(this.ActiveCustomersTabPage);
            this.TabCustomers.Controls.Add(this.ArchivedCustomersTabPage);
            this.TabCustomers.Location = new System.Drawing.Point(8, 8);
            this.TabCustomers.Name = "TabCustomers";
            this.TabCustomers.SelectedIndex = 0;
            this.TabCustomers.Size = new System.Drawing.Size(189, 277);
            this.TabCustomers.TabIndex = 1;
            // 
            // ActiveCustomersTabPage
            // 
            this.ActiveCustomersTabPage.Controls.Add(this.ActiveCustomersTree);
            this.ActiveCustomersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ActiveCustomersTabPage.Name = "ActiveCustomersTabPage";
            this.ActiveCustomersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActiveCustomersTabPage.Size = new System.Drawing.Size(181, 251);
            this.ActiveCustomersTabPage.TabIndex = 0;
            this.ActiveCustomersTabPage.Text = "Aktive";
            this.ActiveCustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // ArchivedCustomersTabPage
            // 
            this.ArchivedCustomersTabPage.Controls.Add(this.ArchivedCustomersTree);
            this.ArchivedCustomersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ArchivedCustomersTabPage.Name = "ArchivedCustomersTabPage";
            this.ArchivedCustomersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ArchivedCustomersTabPage.Size = new System.Drawing.Size(181, 251);
            this.ArchivedCustomersTabPage.TabIndex = 1;
            this.ArchivedCustomersTabPage.Text = "Archivierte";
            this.ArchivedCustomersTabPage.UseVisualStyleBackColor = true;
            // 
            // ArchivedCustomersTree
            // 
            this.ArchivedCustomersTree.ContextMenuStrip = this.TreeContextMenu;
            this.ArchivedCustomersTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchivedCustomersTree.FullRowSelect = true;
            this.ArchivedCustomersTree.HideSelection = false;
            this.ArchivedCustomersTree.Location = new System.Drawing.Point(3, 3);
            this.ArchivedCustomersTree.Name = "ArchivedCustomersTree";
            this.ArchivedCustomersTree.ShowLines = false;
            this.ArchivedCustomersTree.ShowPlusMinus = false;
            this.ArchivedCustomersTree.ShowRootLines = false;
            this.ArchivedCustomersTree.Size = new System.Drawing.Size(175, 245);
            this.ArchivedCustomersTree.TabIndex = 1;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(444, 295);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(83, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Schließen";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click_1);
            // 
            // BtnNewCustomer
            // 
            this.BtnNewCustomer.Location = new System.Drawing.Point(9, 295);
            this.BtnNewCustomer.Name = "BtnNewCustomer";
            this.BtnNewCustomer.Size = new System.Drawing.Size(87, 23);
            this.BtnNewCustomer.TabIndex = 9;
            this.BtnNewCustomer.Text = "Neuer Kunde";
            this.BtnNewCustomer.UseVisualStyleBackColor = true;
            this.BtnNewCustomer.Click += new System.EventHandler(this.BtnNewCustomer_Click);
            // 
            // Customers
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(537, 327);
            this.Controls.Add(this.TabCustomers);
            this.Controls.Add(this.FormGroup);
            this.Controls.Add(this.BtnNewCustomer);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(553, 365);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(553, 365);
            this.Name = "Customers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kunden";
            this.TreeContextMenu.ResumeLayout(false);
            this.FormGroup.ResumeLayout(false);
            this.FormGroup.PerformLayout();
            this.TabCustomers.ResumeLayout(false);
            this.ActiveCustomersTabPage.ResumeLayout(false);
            this.ArchivedCustomersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ActiveCustomersTree;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox FormGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxNote;
        private System.Windows.Forms.TextBox BoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl TabCustomers;
        private System.Windows.Forms.TabPage ActiveCustomersTabPage;
        private System.Windows.Forms.TreeView ArchivedCustomersTree;
        private System.Windows.Forms.TabPage ArchivedCustomersTabPage;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.ComponentModel.BackgroundWorker TreeDataBackgroundWorker;
        private System.Windows.Forms.CheckBox CheckBoxArchived;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnNewCustomer;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
    }
}