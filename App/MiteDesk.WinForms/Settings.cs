using System;
using System.Windows.Forms;
using SixtyNineDegrees.MiteDesk.Core.Infrastructure;
using SixtyNineDegrees.MiteDesk.Core.Model;
using SixtyNineDegrees.MiteDesk.Core.Services;
using SixtyNineDegrees.MiteDesk.Tools.Connector;
using SixtyNineDegrees.MiteDesk.WinForms.Localization;
using StructureMap;

namespace SixtyNineDegrees.MiteDesk.WinForms
{
    public partial class Settings : Form
    {

        public bool ReLocalize;
        public AppSettings AppSettings;

        public Settings(bool firstSetup)
        {

            ReLocalize = false;
            FirstSetup = firstSetup;

            InitializeComponent();
            LocalizeForm();

            Config = ObjectFactory.GetInstance<IConfigurationService>();

            TabContainer.SelectedIndexChanged += TabContainer_SelectedIndexChanged;

            AppSettings = Config.GetAppSettings();
            MinimizeByClosing.Checked = AppSettings.MinimizeByClosing;
            EnableAutostart.Checked = AppSettings.Autostart;
            AccountName.Text = AppSettings.AccountName;
            StartMinimized.Checked = AppSettings.StartMinimized;
            BoxUseProxyServer.Checked = AppSettings.UseProxy;
            StopStopwatchByClosing.Checked = AppSettings.StopStopwatchByClosing;
            AskForStoppingStopwatchByClosing.Checked = AppSettings.AskForStoppingStopwatchByClosing;
            SortDescending.Checked = AppSettings.SortTimeEntriesDescending;

            SetProxyPanel();
            if (BoxUseProxyServer.Checked)
            {
                ProxyServer.Text = AppSettings.ProxyServer;
                ProxyPort.Value = AppSettings.ProxyPort;
                ProxyUser.Text = AppSettings.ProxyUser;
                ProxyPassword.Text = AppSettings.ProxyPassword;
            }

            if (!string.IsNullOrEmpty(AppSettings.APIKey))
            {
                APIKey.Text = AppSettings.APIKey;
                SetAuthentiactionByAPIKey();
            }
            else
            {
                SetAuthenticationByEmailAndPassword();
                Email.Text = AppSettings.Email;
                Password.Text = AppSettings.Password;
            }

            ListLanguages.SelectedIndex = AppSettings.Culture == "en-US" ? 1 : 0;

            if (firstSetup)
                ShowFirstSetupMessage();

        }

        void LocalizeForm()
        {

            #region Lokalisierung

            Text = SettingsLabels.FormTitle;

            AccountTab.Text = SettingsLabels.TabAccount;
            LanguageTab.Text = SettingsLabels.TabLanguage;
            ExtendedTab.Text = SettingsLabels.TabAdvanced;
            NetworkTab.Text = SettingsLabels.TabNetwork;

            CheckConnectionButton.Text = SettingsLabels.ButtonCheckConnection;
            ButtonOK.Text = SettingsLabels.ButtonOK;
            ButtonCancel.Text = SettingsLabels.ButtonCancel;

            groupBox1.Text = SettingsLabels.AccountGroupboxTitle;
            GroupBoxAuthenticateByEmailAndPassword.Text = SettingsLabels.LoginByAccountGroupboxTitle;
            GroupBoxAuthenticateByAPIKey.Text = SettingsLabels.LoginByApiKeyGroupboxTitle;
            groupBox6.Text = SettingsLabels.LanguageGroupboxTitle;
            groupBox2.Text = SettingsLabels.StartGroupboxTitle;
            groupBox5.Text = SettingsLabels.AdvancedGroupboxTitle;

            label1.Text = SettingsLabels.AccountLabelAccountName;
            label5.Text = SettingsLabels.AccountLabelConnectBy;
            AuthenticateByEmailAndPassword.Text = SettingsLabels.AccountLabelConnectByEmailAndPassword;
            AuthenticateByAPIKey.Text = SettingsLabels.AccountLabelConnectByApiKey;

            label2.Text = SettingsLabels.LoginByAccountLabelEmail;
            label3.Text = SettingsLabels.LoginByAccountLabelPassword;
            CheckBoxShowPasswordInClearText.Text = SettingsLabels.LoginByAccountLabelShowPassword;
            checkBox2.Text = SettingsLabels.LoginByAccountLabelShowPassword;
            label4.Text = SettingsLabels.AccountLabelAPIKey;

            EnableAutostart.Text = SettingsLabels.StartLabelAutostart;
            StartMinimized.Text = SettingsLabels.StartLabelStartMinimized;
            MinimizeByClosing.Text = SettingsLabels.AdvancedLabelMinimizeByClose;

            BoxUseProxyServer.Text = SettingsLabels.ProxyServerLabel;
            label9.Text = SettingsLabels.ProxyServer;

            LblProxyPassword.Text = SettingsLabels.ProxyPassword;
            LblProxyUser.Text = SettingsLabels.ProxyUser;

            StopStopwatchByClosing.Text = SettingsLabels.StopStopwatchByClosing;
            AskForStoppingStopwatchByClosing.Text = SettingsLabels.AskForStoppingStopwatchByClosing;

            groupBox8.Text = SettingsLabels.TimeEntriesGroupboxTitle;
            SortDescending.Text = SettingsLabels.SortDescending;

            #endregion

        }

        void TabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckConnectionButton.Visible = TabContainer.SelectedIndex <= 1;
        }

        private readonly bool FirstSetup;
        private readonly IConfigurationService Config;

        private void SetAuthentiactionByAPIKey()
        {
            ErrorProvider.Clear();
            AuthenticateByAPIKey.Checked = true;
            AuthenticateByEmailAndPassword.Checked = false;
            GroupBoxAuthenticateByAPIKey.Enabled = true;
            GroupBoxAuthenticateByEmailAndPassword.Enabled = false;
        }

        private void SetAuthenticationByEmailAndPassword()
        {
            ErrorProvider.Clear();
            AuthenticateByAPIKey.Checked = false;
            AuthenticateByEmailAndPassword.Checked = true;
            GroupBoxAuthenticateByAPIKey.Enabled = false;
            GroupBoxAuthenticateByEmailAndPassword.Enabled = true;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if(SaveFormData())
            {
                //if (!FirstSetup)
                //{
                    Cursor = Cursors.WaitCursor;
                    ((Main)Owner).InitializeForm(false);
                    Cursor = Cursors.Default;
                //}
                Close();
            }
        }

        private bool SaveFormData()
        {

            var settings = new AppSettings();
            settings.AccountName = AccountName.Text;
            settings.MinimizeByClosing = MinimizeByClosing.Checked;
            settings.Autostart = EnableAutostart.Checked;
            settings.StartMinimized = StartMinimized.Checked;
            settings.UseProxy = BoxUseProxyServer.Checked;
            settings.ProxyServer = ProxyServer.Text;
            settings.ProxyPort = (int)ProxyPort.Value;
            settings.ProxyPassword = ProxyPassword.Text;
            settings.ProxyUser = ProxyUser.Text;
            settings.AskForStoppingStopwatchByClosing = AskForStoppingStopwatchByClosing.Checked;
            settings.StopStopwatchByClosing = StopStopwatchByClosing.Checked;
            settings.SortTimeEntriesDescending = SortDescending.Checked;
            
            settings.Culture = ListLanguages.SelectedIndex == 1 ? "en-US" : "de-DE";
            ReLocalize = AppSettings.Culture != settings.Culture;

            if (AuthenticateByAPIKey.Checked)
            {
                settings.AuthenticationType = AuthenticationType.APIKey;
                settings.APIKey = APIKey.Text;
            }
            else
            {
                settings.AuthenticationType = AuthenticationType.EmailAndPassword;
                settings.Email = Email.Text;
                settings.Password = Password.Text;
            }

            var result = Config.UpdateAppSettings(settings);

            if (result.Count == 0)
            {
                Helper.SetCulture(settings.Culture);
                return true;
            }

            ErrorProvider.Clear();

            if (result.ContainsKey("AccountName"))
                ErrorProvider.SetError(AccountName, result["AccountName"]);

            if (result.ContainsKey("Email"))
                ErrorProvider.SetError(Email, result["Email"]);

            if (result.ContainsKey("Password"))
                ErrorProvider.SetError(Password, result["Password"]);

            if (result.ContainsKey("APIKey"))
                ErrorProvider.SetError(APIKey, result["APIKey"]);

            return false;

        }

        private void RadioAuthByEmailAndPassword_Click(object sender, EventArgs e)
        {
            SetAuthenticationByEmailAndPassword();
        }

        private void RadioAuthByAPIKey_Click(object sender, EventArgs e)
        {
            SetAuthentiactionByAPIKey();
        }

        private void CheckBoxShowPasswordInClearText_CheckedChanged_1(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = !CheckBoxShowPasswordInClearText.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SaveFormData())
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    var user = ObjectFactory.GetInstance<IAuthenticationService>().GetAuthenticatedUser();
                    MessageBox.Show(string.Format(SettingsLabels.MsgBoxConnectionTestSuccessText, user.Name, user.Email), SettingsLabels.MsgBoxConnectionTestSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(MiteConnectorException ex)
                {
                    ((Main)Owner).EnableOrDisableForm(false);
                    MessageBox.Show(string.Format(SettingsLabels.MsgBoxConnectionTestFailureText, ex.Message), SettingsLabels.MsgBoxConnectionTestFailureTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor = Cursors.Default;
            }
        }

        private static void ShowFirstSetupMessage()
        {
            MessageBox.Show(SettingsLabels.MsgBoxFirstSetupMessageText, SettingsLabels.MsgBoxFirstSetupMessageTitle, MessageBoxButtons.OK);
        }

        protected override void OnClosed(EventArgs e)
        {
            ((Main)Owner).SetAppSettings();
            if (ReLocalize)
                ((Main)Owner).LocalizeForm();
            base.OnClosed(e);
        }

        private void BoxUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            SetProxyPanel();
        }

        private void SetProxyPanel()
        {
            ProxyServer.Enabled = BoxUseProxyServer.Checked;
            ProxyPort.Enabled = BoxUseProxyServer.Checked;
            ProxyUser.Enabled = BoxUseProxyServer.Checked;
            ProxyPassword.Enabled = BoxUseProxyServer.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ProxyPassword.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new LoginHelp().ShowDialog(this);
        }

        private void StopStopwatchByClosing_CheckedChanged(object sender, EventArgs e)
        {
            if (StopStopwatchByClosing.Checked)
                AskForStoppingStopwatchByClosing.Checked = false;
        }

        private void AskForStoppingStopwatchByClosing_CheckedChanged(object sender, EventArgs e)
        {
            if (AskForStoppingStopwatchByClosing.Checked)
                StopStopwatchByClosing.Checked = false;
        }

    }
}
