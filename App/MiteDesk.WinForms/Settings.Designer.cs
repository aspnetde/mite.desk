namespace SixtyNineDegrees.MiteDesk.WinForms
{
    partial class Settings
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.CheckConnectionButton = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ExtendedTab = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.MinimizeByClosing = new System.Windows.Forms.CheckBox();
            this.StopStopwatchByClosing = new System.Windows.Forms.CheckBox();
            this.AskForStoppingStopwatchByClosing = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EnableAutostart = new System.Windows.Forms.CheckBox();
            this.StartMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.SortDescending = new System.Windows.Forms.CheckBox();
            this.LanguageTab = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ListLanguages = new System.Windows.Forms.ComboBox();
            this.NetworkTab = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ProxyServer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ProxyPort = new System.Windows.Forms.NumericUpDown();
            this.BoxUseProxyServer = new System.Windows.Forms.CheckBox();
            this.LblProxyPassword = new System.Windows.Forms.Label();
            this.LblProxyUser = new System.Windows.Forms.Label();
            this.ProxyPassword = new System.Windows.Forms.TextBox();
            this.ProxyUser = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.AccountTab = new System.Windows.Forms.TabPage();
            this.GroupBoxAuthenticateByAPIKey = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.APIKey = new System.Windows.Forms.TextBox();
            this.GroupBoxAuthenticateByEmailAndPassword = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.CheckBoxShowPasswordInClearText = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AccountName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AuthenticateByEmailAndPassword = new System.Windows.Forms.RadioButton();
            this.AuthenticateByAPIKey = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TabContainer = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.ExtendedTab.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.LanguageTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.NetworkTab.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPort)).BeginInit();
            this.AccountTab.SuspendLayout();
            this.GroupBoxAuthenticateByAPIKey.SuspendLayout();
            this.GroupBoxAuthenticateByEmailAndPassword.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TabContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(365, 324);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "Abbrechen";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(283, 324);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 10;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // CheckConnectionButton
            // 
            this.CheckConnectionButton.Location = new System.Drawing.Point(9, 324);
            this.CheckConnectionButton.Name = "CheckConnectionButton";
            this.CheckConnectionButton.Size = new System.Drawing.Size(107, 23);
            this.CheckConnectionButton.TabIndex = 9;
            this.CheckConnectionButton.Text = "Verbindung testen";
            this.CheckConnectionButton.UseVisualStyleBackColor = true;
            this.CheckConnectionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(297, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Sichere Verbindung mit SSL-Verschlüsselung verwenden.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Schlüssel";
            // 
            // ExtendedTab
            // 
            this.ExtendedTab.Controls.Add(this.groupBox8);
            this.ExtendedTab.Controls.Add(this.groupBox2);
            this.ExtendedTab.Controls.Add(this.groupBox5);
            this.ExtendedTab.Location = new System.Drawing.Point(4, 22);
            this.ExtendedTab.Name = "ExtendedTab";
            this.ExtendedTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExtendedTab.Size = new System.Drawing.Size(423, 279);
            this.ExtendedTab.TabIndex = 2;
            this.ExtendedTab.Text = "Erweitert";
            this.ExtendedTab.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.AskForStoppingStopwatchByClosing);
            this.groupBox5.Controls.Add(this.StopStopwatchByClosing);
            this.groupBox5.Controls.Add(this.MinimizeByClosing);
            this.groupBox5.Location = new System.Drawing.Point(8, 83);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(406, 96);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Beenden";
            // 
            // MinimizeByClosing
            // 
            this.MinimizeByClosing.AutoSize = true;
            this.MinimizeByClosing.Location = new System.Drawing.Point(10, 23);
            this.MinimizeByClosing.Name = "MinimizeByClosing";
            this.MinimizeByClosing.Size = new System.Drawing.Size(376, 17);
            this.MinimizeByClosing.TabIndex = 4;
            this.MinimizeByClosing.Text = "mite.desk beim Schließen des Fensters nicht beenden, sondern minimieren";
            this.MinimizeByClosing.UseVisualStyleBackColor = true;
            // 
            // StopStopwatchByClosing
            // 
            this.StopStopwatchByClosing.AutoSize = true;
            this.StopStopwatchByClosing.Location = new System.Drawing.Point(10, 47);
            this.StopStopwatchByClosing.Name = "StopStopwatchByClosing";
            this.StopStopwatchByClosing.Size = new System.Drawing.Size(262, 17);
            this.StopStopwatchByClosing.TabIndex = 5;
            this.StopStopwatchByClosing.Text = "Beim Beenden die Stoppuhr automatisch anhalten";
            this.StopStopwatchByClosing.UseVisualStyleBackColor = true;
            this.StopStopwatchByClosing.CheckedChanged += new System.EventHandler(this.StopStopwatchByClosing_CheckedChanged);
            // 
            // AskForStoppingStopwatchByClosing
            // 
            this.AskForStoppingStopwatchByClosing.AutoSize = true;
            this.AskForStoppingStopwatchByClosing.Location = new System.Drawing.Point(10, 71);
            this.AskForStoppingStopwatchByClosing.Name = "AskForStoppingStopwatchByClosing";
            this.AskForStoppingStopwatchByClosing.Size = new System.Drawing.Size(337, 17);
            this.AskForStoppingStopwatchByClosing.TabIndex = 6;
            this.AskForStoppingStopwatchByClosing.Text = "Vor dem Beenden fragen, ob die Stoppuhr angehalten werden soll";
            this.AskForStoppingStopwatchByClosing.UseVisualStyleBackColor = true;
            this.AskForStoppingStopwatchByClosing.CheckedChanged += new System.EventHandler(this.AskForStoppingStopwatchByClosing_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartMinimized);
            this.groupBox2.Controls.Add(this.EnableAutostart);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 71);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start";
            // 
            // EnableAutostart
            // 
            this.EnableAutostart.AutoSize = true;
            this.EnableAutostart.Location = new System.Drawing.Point(10, 23);
            this.EnableAutostart.Name = "EnableAutostart";
            this.EnableAutostart.Size = new System.Drawing.Size(355, 17);
            this.EnableAutostart.TabIndex = 1;
            this.EnableAutostart.Text = "mite.desk bei der Windows-Anmeldung automatisch starten (Autostart)";
            this.EnableAutostart.UseVisualStyleBackColor = true;
            // 
            // StartMinimized
            // 
            this.StartMinimized.AutoSize = true;
            this.StartMinimized.Location = new System.Drawing.Point(10, 46);
            this.StartMinimized.Name = "StartMinimized";
            this.StartMinimized.Size = new System.Drawing.Size(102, 17);
            this.StartMinimized.TabIndex = 2;
            this.StartMinimized.Text = "Minimiert starten";
            this.StartMinimized.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.SortDescending);
            this.groupBox8.Location = new System.Drawing.Point(8, 185);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(406, 49);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Zeiteinträge";
            // 
            // SortDescending
            // 
            this.SortDescending.AutoSize = true;
            this.SortDescending.Location = new System.Drawing.Point(10, 23);
            this.SortDescending.Name = "SortDescending";
            this.SortDescending.Size = new System.Drawing.Size(319, 17);
            this.SortDescending.TabIndex = 4;
            this.SortDescending.Text = "Einträge in umgekehrter Reihenfolge sortieren (neueste zuerst)";
            this.SortDescending.UseVisualStyleBackColor = true;
            // 
            // LanguageTab
            // 
            this.LanguageTab.Controls.Add(this.groupBox6);
            this.LanguageTab.Location = new System.Drawing.Point(4, 22);
            this.LanguageTab.Name = "LanguageTab";
            this.LanguageTab.Size = new System.Drawing.Size(423, 279);
            this.LanguageTab.TabIndex = 3;
            this.LanguageTab.Text = "Sprache";
            this.LanguageTab.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ListLanguages);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(406, 58);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sprache";
            // 
            // ListLanguages
            // 
            this.ListLanguages.FormattingEnabled = true;
            this.ListLanguages.Items.AddRange(new object[] {
            "Deutsch",
            "English"});
            this.ListLanguages.Location = new System.Drawing.Point(10, 23);
            this.ListLanguages.Name = "ListLanguages";
            this.ListLanguages.Size = new System.Drawing.Size(383, 21);
            this.ListLanguages.TabIndex = 0;
            // 
            // NetworkTab
            // 
            this.NetworkTab.Controls.Add(this.groupBox7);
            this.NetworkTab.Location = new System.Drawing.Point(4, 22);
            this.NetworkTab.Name = "NetworkTab";
            this.NetworkTab.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkTab.Size = new System.Drawing.Size(423, 279);
            this.NetworkTab.TabIndex = 1;
            this.NetworkTab.Text = "Netzwerk";
            this.NetworkTab.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox2);
            this.groupBox7.Controls.Add(this.ProxyUser);
            this.groupBox7.Controls.Add(this.ProxyPassword);
            this.groupBox7.Controls.Add(this.LblProxyUser);
            this.groupBox7.Controls.Add(this.LblProxyPassword);
            this.groupBox7.Controls.Add(this.BoxUseProxyServer);
            this.groupBox7.Controls.Add(this.ProxyPort);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.ProxyServer);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(406, 158);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Proxy";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Proxy-Server";
            // 
            // ProxyServer
            // 
            this.ProxyServer.Location = new System.Drawing.Point(113, 46);
            this.ProxyServer.Name = "ProxyServer";
            this.ProxyServer.Size = new System.Drawing.Size(174, 20);
            this.ProxyServer.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Port";
            // 
            // ProxyPort
            // 
            this.ProxyPort.Location = new System.Drawing.Point(325, 46);
            this.ProxyPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ProxyPort.Name = "ProxyPort";
            this.ProxyPort.Size = new System.Drawing.Size(64, 20);
            this.ProxyPort.TabIndex = 11;
            // 
            // BoxUseProxyServer
            // 
            this.BoxUseProxyServer.AutoSize = true;
            this.BoxUseProxyServer.Location = new System.Drawing.Point(10, 20);
            this.BoxUseProxyServer.Name = "BoxUseProxyServer";
            this.BoxUseProxyServer.Size = new System.Drawing.Size(142, 17);
            this.BoxUseProxyServer.TabIndex = 9;
            this.BoxUseProxyServer.Text = "Proxy-Server verwenden";
            this.BoxUseProxyServer.UseVisualStyleBackColor = true;
            this.BoxUseProxyServer.CheckedChanged += new System.EventHandler(this.BoxUseProxy_CheckedChanged);
            // 
            // LblProxyPassword
            // 
            this.LblProxyPassword.AutoSize = true;
            this.LblProxyPassword.Location = new System.Drawing.Point(9, 107);
            this.LblProxyPassword.Name = "LblProxyPassword";
            this.LblProxyPassword.Size = new System.Drawing.Size(50, 13);
            this.LblProxyPassword.TabIndex = 13;
            this.LblProxyPassword.Text = "Passwort";
            // 
            // LblProxyUser
            // 
            this.LblProxyUser.AutoSize = true;
            this.LblProxyUser.Location = new System.Drawing.Point(9, 77);
            this.LblProxyUser.Name = "LblProxyUser";
            this.LblProxyUser.Size = new System.Drawing.Size(55, 13);
            this.LblProxyUser.TabIndex = 12;
            this.LblProxyUser.Text = "Username";
            // 
            // ProxyPassword
            // 
            this.ProxyPassword.Location = new System.Drawing.Point(113, 104);
            this.ProxyPassword.Name = "ProxyPassword";
            this.ProxyPassword.Size = new System.Drawing.Size(276, 20);
            this.ProxyPassword.TabIndex = 15;
            this.ProxyPassword.UseSystemPasswordChar = true;
            // 
            // ProxyUser
            // 
            this.ProxyUser.Location = new System.Drawing.Point(113, 74);
            this.ProxyUser.Name = "ProxyUser";
            this.ProxyUser.Size = new System.Drawing.Size(276, 20);
            this.ProxyUser.TabIndex = 14;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(113, 130);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(115, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Passwort anzeigen";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // AccountTab
            // 
            this.AccountTab.Controls.Add(this.groupBox1);
            this.AccountTab.Controls.Add(this.GroupBoxAuthenticateByEmailAndPassword);
            this.AccountTab.Controls.Add(this.GroupBoxAuthenticateByAPIKey);
            this.AccountTab.Location = new System.Drawing.Point(4, 22);
            this.AccountTab.Name = "AccountTab";
            this.AccountTab.Padding = new System.Windows.Forms.Padding(3);
            this.AccountTab.Size = new System.Drawing.Size(423, 279);
            this.AccountTab.TabIndex = 0;
            this.AccountTab.Text = "Account";
            this.AccountTab.UseVisualStyleBackColor = true;
            // 
            // GroupBoxAuthenticateByAPIKey
            // 
            this.GroupBoxAuthenticateByAPIKey.Controls.Add(this.APIKey);
            this.GroupBoxAuthenticateByAPIKey.Controls.Add(this.label4);
            this.GroupBoxAuthenticateByAPIKey.Location = new System.Drawing.Point(6, 207);
            this.GroupBoxAuthenticateByAPIKey.Name = "GroupBoxAuthenticateByAPIKey";
            this.GroupBoxAuthenticateByAPIKey.Size = new System.Drawing.Size(406, 61);
            this.GroupBoxAuthenticateByAPIKey.TabIndex = 0;
            this.GroupBoxAuthenticateByAPIKey.TabStop = false;
            this.GroupBoxAuthenticateByAPIKey.Text = "Anmeldung per API-Schlüssel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Schlüssel";
            // 
            // APIKey
            // 
            this.APIKey.Location = new System.Drawing.Point(111, 26);
            this.APIKey.Name = "APIKey";
            this.APIKey.Size = new System.Drawing.Size(276, 20);
            this.APIKey.TabIndex = 7;
            // 
            // GroupBoxAuthenticateByEmailAndPassword
            // 
            this.GroupBoxAuthenticateByEmailAndPassword.Controls.Add(this.CheckBoxShowPasswordInClearText);
            this.GroupBoxAuthenticateByEmailAndPassword.Controls.Add(this.Email);
            this.GroupBoxAuthenticateByEmailAndPassword.Controls.Add(this.Password);
            this.GroupBoxAuthenticateByEmailAndPassword.Controls.Add(this.label2);
            this.GroupBoxAuthenticateByEmailAndPassword.Controls.Add(this.label3);
            this.GroupBoxAuthenticateByEmailAndPassword.Location = new System.Drawing.Point(6, 91);
            this.GroupBoxAuthenticateByEmailAndPassword.Name = "GroupBoxAuthenticateByEmailAndPassword";
            this.GroupBoxAuthenticateByEmailAndPassword.Size = new System.Drawing.Size(406, 110);
            this.GroupBoxAuthenticateByEmailAndPassword.TabIndex = 0;
            this.GroupBoxAuthenticateByEmailAndPassword.TabStop = false;
            this.GroupBoxAuthenticateByEmailAndPassword.Text = "Anmeldung per E-Mail/Passwort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Passwort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "E-Mail-Adresse";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(111, 55);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(276, 20);
            this.Password.TabIndex = 5;
            this.Password.UseSystemPasswordChar = true;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(111, 25);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(276, 20);
            this.Email.TabIndex = 4;
            // 
            // CheckBoxShowPasswordInClearText
            // 
            this.CheckBoxShowPasswordInClearText.AutoSize = true;
            this.CheckBoxShowPasswordInClearText.Location = new System.Drawing.Point(111, 81);
            this.CheckBoxShowPasswordInClearText.Name = "CheckBoxShowPasswordInClearText";
            this.CheckBoxShowPasswordInClearText.Size = new System.Drawing.Size(115, 17);
            this.CheckBoxShowPasswordInClearText.TabIndex = 6;
            this.CheckBoxShowPasswordInClearText.Text = "Passwort anzeigen";
            this.CheckBoxShowPasswordInClearText.UseVisualStyleBackColor = true;
            this.CheckBoxShowPasswordInClearText.CheckedChanged += new System.EventHandler(this.CheckBoxShowPasswordInClearText_CheckedChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.AuthenticateByAPIKey);
            this.groupBox1.Controls.Add(this.AuthenticateByEmailAndPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AccountName);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account";
            // 
            // AccountName
            // 
            this.AccountName.Location = new System.Drawing.Point(152, 18);
            this.AccountName.Name = "AccountName";
            this.AccountName.Size = new System.Drawing.Size(173, 20);
            this.AccountName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Anmelden via";
            // 
            // AuthenticateByEmailAndPassword
            // 
            this.AuthenticateByEmailAndPassword.AutoSize = true;
            this.AuthenticateByEmailAndPassword.Location = new System.Drawing.Point(111, 49);
            this.AuthenticateByEmailAndPassword.Name = "AuthenticateByEmailAndPassword";
            this.AuthenticateByEmailAndPassword.Size = new System.Drawing.Size(102, 17);
            this.AuthenticateByEmailAndPassword.TabIndex = 2;
            this.AuthenticateByEmailAndPassword.TabStop = true;
            this.AuthenticateByEmailAndPassword.Text = "E-Mail/Passwort";
            this.AuthenticateByEmailAndPassword.UseVisualStyleBackColor = true;
            this.AuthenticateByEmailAndPassword.Click += new System.EventHandler(this.RadioAuthByEmailAndPassword_Click);
            // 
            // AuthenticateByAPIKey
            // 
            this.AuthenticateByAPIKey.AutoSize = true;
            this.AuthenticateByAPIKey.Location = new System.Drawing.Point(235, 49);
            this.AuthenticateByAPIKey.Name = "AuthenticateByAPIKey";
            this.AuthenticateByAPIKey.Size = new System.Drawing.Size(90, 17);
            this.AuthenticateByAPIKey.TabIndex = 3;
            this.AuthenticateByAPIKey.TabStop = true;
            this.AuthenticateByAPIKey.Text = "API-Schlüssel";
            this.AuthenticateByAPIKey.UseVisualStyleBackColor = true;
            this.AuthenticateByAPIKey.Click += new System.EventHandler(this.RadioAuthByAPIKey_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::SixtyNineDegrees.MiteDesk.WinForms.Properties.Resources.hilfe;
            this.pictureBox1.Location = new System.Drawing.Point(41, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(108, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "https://";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(326, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = ".mite.yo.lk";
            // 
            // TabContainer
            // 
            this.TabContainer.Controls.Add(this.AccountTab);
            this.TabContainer.Controls.Add(this.NetworkTab);
            this.TabContainer.Controls.Add(this.LanguageTab);
            this.TabContainer.Controls.Add(this.ExtendedTab);
            this.TabContainer.Location = new System.Drawing.Point(9, 10);
            this.TabContainer.Name = "TabContainer";
            this.TabContainer.SelectedIndex = 0;
            this.TabContainer.Size = new System.Drawing.Size(431, 305);
            this.TabContainer.TabIndex = 12;
            // 
            // Settings
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(449, 356);
            this.Controls.Add(this.TabContainer);
            this.Controls.Add(this.CheckConnectionButton);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.ButtonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Einstellungen";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ExtendedTab.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.LanguageTab.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.NetworkTab.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyPort)).EndInit();
            this.AccountTab.ResumeLayout(false);
            this.GroupBoxAuthenticateByAPIKey.ResumeLayout(false);
            this.GroupBoxAuthenticateByAPIKey.PerformLayout();
            this.GroupBoxAuthenticateByEmailAndPassword.ResumeLayout(false);
            this.GroupBoxAuthenticateByEmailAndPassword.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TabContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button CheckConnectionButton;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl TabContainer;
        private System.Windows.Forms.TabPage AccountTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton AuthenticateByAPIKey;
        private System.Windows.Forms.RadioButton AuthenticateByEmailAndPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AccountName;
        private System.Windows.Forms.GroupBox GroupBoxAuthenticateByEmailAndPassword;
        private System.Windows.Forms.CheckBox CheckBoxShowPasswordInClearText;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GroupBoxAuthenticateByAPIKey;
        private System.Windows.Forms.TextBox APIKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage NetworkTab;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox ProxyUser;
        private System.Windows.Forms.TextBox ProxyPassword;
        private System.Windows.Forms.Label LblProxyUser;
        private System.Windows.Forms.Label LblProxyPassword;
        private System.Windows.Forms.CheckBox BoxUseProxyServer;
        private System.Windows.Forms.NumericUpDown ProxyPort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ProxyServer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage LanguageTab;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox ListLanguages;
        private System.Windows.Forms.TabPage ExtendedTab;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox SortDescending;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox StartMinimized;
        private System.Windows.Forms.CheckBox EnableAutostart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox AskForStoppingStopwatchByClosing;
        private System.Windows.Forms.CheckBox StopStopwatchByClosing;
        private System.Windows.Forms.CheckBox MinimizeByClosing;
    }
}