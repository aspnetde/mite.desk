using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure
{
    public class ConfigurationService : IConfigurationService
    {

        public ConfigurationService(IRegistryService registryService, IEncryptionService encryptionService, string applicationID, string executablePath)
        {
            RegistryService = registryService;
            EncryptionService = encryptionService;
            ApplicationID = applicationID;
            ExecutablePath = executablePath;
        }

        private readonly IRegistryService RegistryService;
        private readonly IEncryptionService EncryptionService;
        private readonly string ApplicationID;
        private readonly string ExecutablePath;

        public AppSettings GetAppSettings()
        {

            var settings = new AppSettings();

            if (!RegistryService.ApplicationRegistryKeyExists())
                RegistryService.CreateApplicationRegistryKey();

            settings.AccountName = EncryptionService.DecryptString(RegistryService.GetApplicationRegistryKeyValue("C"), ApplicationID);
            settings.Email = EncryptionService.DecryptString(RegistryService.GetApplicationRegistryKeyValue("D"), ApplicationID);
            settings.APIKey = EncryptionService.DecryptString(RegistryService.GetApplicationRegistryKeyValue("E"), ApplicationID);
            settings.Password = EncryptionService.DecryptString(RegistryService.GetApplicationRegistryKeyValue("F"), ApplicationID);

            settings.ProxyUser = EncryptionService.DecryptString(RegistryService.GetApplicationRegistryKeyValue("R"), ApplicationID);
            settings.ProxyPassword = EncryptionService.DecryptString(RegistryService.GetApplicationRegistryKeyValue("S"), ApplicationID);
            
            settings.Culture = RegistryService.GetApplicationRegistryKeyValue("N");
            if (string.IsNullOrEmpty(settings.Culture)) settings.Culture = "de-DE";

            string autostartRegistryValue = RegistryService.GetApplicationRegistryKeyValue(@"Software\Microsoft\Windows\CurrentVersion\Run", "mite.desk");
            settings.Autostart = autostartRegistryValue != null && autostartRegistryValue == ExecutablePath;

            bool minimizeByClosing;
            bool.TryParse(RegistryService.GetApplicationRegistryKeyValue("H"), out minimizeByClosing);
            settings.MinimizeByClosing = minimizeByClosing;

            bool startMinimized;
            bool.TryParse(RegistryService.GetApplicationRegistryKeyValue("I"), out startMinimized);
            settings.StartMinimized = startMinimized;

            DateTime lastUpdateCheck;
            DateTime.TryParse(RegistryService.GetApplicationRegistryKeyValue("K"), out lastUpdateCheck);
            settings.LastUpdateCheck = lastUpdateCheck;

            int selectedProjectID;
            int.TryParse(RegistryService.GetApplicationRegistryKeyValue("L"), out selectedProjectID);
            settings.SelectedProjectID = selectedProjectID;

            int activityID;
            int.TryParse(RegistryService.GetApplicationRegistryKeyValue("M"), out activityID);
            settings.SelectedActivityID = activityID;

            bool useProxy;
            bool.TryParse(RegistryService.GetApplicationRegistryKeyValue("O"), out useProxy);
            settings.UseProxy = useProxy;

            bool stopStopwatchByClosing;
            bool.TryParse(RegistryService.GetApplicationRegistryKeyValue("T"), out stopStopwatchByClosing);
            settings.StopStopwatchByClosing = stopStopwatchByClosing;

            bool askForStoppingStopwatchByClosing;
            bool.TryParse(RegistryService.GetApplicationRegistryKeyValue("U"), out askForStoppingStopwatchByClosing);
            settings.AskForStoppingStopwatchByClosing = askForStoppingStopwatchByClosing;

            bool sortTimeEntriesDescending;
            bool.TryParse(RegistryService.GetApplicationRegistryKeyValue("V"), out sortTimeEntriesDescending);
            settings.SortTimeEntriesDescending = sortTimeEntriesDescending;

            settings.ProxyServer = RegistryService.GetApplicationRegistryKeyValue("P");

            int proxyPort;
            int.TryParse(RegistryService.GetApplicationRegistryKeyValue("Q"), out proxyPort);
            settings.ProxyPort = proxyPort;

            return settings;

        }

        public Dictionary<string, string> UpdateAppSettings(AppSettings settings)
        {

            Dictionary<string, string> errors = new Dictionary<string, string>();

            if(string.IsNullOrEmpty(settings.AccountName) || settings.AccountName.Trim().Length == 0)
                errors.Add("AccountName", Localization.Configuration.AccountNameEmpty);

            if(settings.AuthenticationType == AuthenticationType.EmailAndPassword)
            {
                if (string.IsNullOrEmpty(settings.Email) || settings.Email.Trim().Length == 0)
                    errors.Add("Email", Localization.Configuration.EmailEmpty);
                else if (!new Regex(@"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,6}$").Match(settings.Email).Success)
                    errors.Add("Email", Localization.Configuration.EmailFormat);

                if (string.IsNullOrEmpty(settings.Password) || settings.Password.Trim().Length == 0)
                    errors.Add("Password", Localization.Configuration.PasswordEmpty);
            }
            else if(settings.AuthenticationType == AuthenticationType.APIKey)
            {
                if (string.IsNullOrEmpty(settings.APIKey) || settings.APIKey.Trim().Length == 0)
                    errors.Add("APIKey", Localization.Configuration.APIKeyEmpty);
            }

            if(errors.Count == 0)
            {

                RegistryService.SetApplicationRegistryKeyValue("C", EncryptionService.EncryptString(settings.AccountName, ApplicationID));
                RegistryService.SetApplicationRegistryKeyValue("H", settings.MinimizeByClosing.ToString());
                RegistryService.SetApplicationRegistryKeyValue("I", settings.StartMinimized.ToString());
                RegistryService.SetApplicationRegistryKeyValue("L", settings.SelectedProjectID.ToString());
                RegistryService.SetApplicationRegistryKeyValue("M", settings.SelectedActivityID.ToString());
                RegistryService.SetApplicationRegistryKeyValue("N", settings.Culture);
                RegistryService.SetApplicationRegistryKeyValue("O", settings.UseProxy.ToString());
                RegistryService.SetApplicationRegistryKeyValue("P", settings.ProxyServer);
                RegistryService.SetApplicationRegistryKeyValue("Q", settings.ProxyPort.ToString());
                RegistryService.SetApplicationRegistryKeyValue("R", EncryptionService.EncryptString(settings.ProxyUser, ApplicationID));
                RegistryService.SetApplicationRegistryKeyValue("S", EncryptionService.EncryptString(settings.ProxyPassword, ApplicationID));
                RegistryService.SetApplicationRegistryKeyValue("T", settings.StopStopwatchByClosing.ToString());
                RegistryService.SetApplicationRegistryKeyValue("U", settings.AskForStoppingStopwatchByClosing.ToString());
                RegistryService.SetApplicationRegistryKeyValue("V", settings.SortTimeEntriesDescending.ToString());

                if (settings.LastUpdateCheck > DateTime.MinValue)
                    RegistryService.SetApplicationRegistryKeyValue("K", settings.LastUpdateCheck.ToShortDateString());

                if(settings.AuthenticationType == AuthenticationType.EmailAndPassword)
                {
                    RegistryService.SetApplicationRegistryKeyValue("D", EncryptionService.EncryptString(settings.Email, ApplicationID));
                    RegistryService.SetApplicationRegistryKeyValue("F", EncryptionService.EncryptString(settings.Password, ApplicationID));
                    RegistryService.SetApplicationRegistryKeyValue("E", string.Empty);
                }
                else if (settings.AuthenticationType == AuthenticationType.APIKey)
                {
                    RegistryService.SetApplicationRegistryKeyValue("D", string.Empty);
                    RegistryService.SetApplicationRegistryKeyValue("F", string.Empty);
                    RegistryService.SetApplicationRegistryKeyValue("E", EncryptionService.EncryptString(settings.APIKey, ApplicationID));
                }

                if (settings.Autostart)
                    RegistryService.SetApplicationRegistryKeyValue(@"Software\Microsoft\Windows\CurrentVersion\Run", "mite.desk", ExecutablePath);
                else
                    RegistryService.DeleteApplicationRegistryKeyValue(@"Software\Microsoft\Windows\CurrentVersion\Run", "mite.desk");

            }

            return errors;

        }

    }
}
