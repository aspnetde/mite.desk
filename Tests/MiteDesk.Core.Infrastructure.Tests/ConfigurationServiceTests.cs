using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure.Tests
{

    [TestClass]
    public class ConfigurationServiceTests
    {

        #region Setup

        private ConfigurationService ConfigurationService;
        private MockRepository MockRepository;
        private IRegistryService RegistryService;
        private string ApplicationID;
        private IEncryptionService EncryptionService;

        [TestInitialize]
        public void Setup()
        {
            MockRepository = new MockRepository();
            ApplicationID = new Guid("32141871-78de-40b2-a715-49ced5c0c872").ToString();
            EncryptionService = new EncryptionService();
            RegistryService = MockRepository.DynamicMock<IRegistryService>();
            ConfigurationService = new ConfigurationService(RegistryService, EncryptionService, ApplicationID, "executablepath");
            using(MockRepository.Record())
            {
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("D")).Return("T/jSvAFKeMsiOAk5IfqEEg==").Repeat.Any(); // Klartext: Email
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("C")).Return("gnrAw6R9MIEu7ODFX5vFP8oG3ViER5xKMPwe74iQBUQ=").Repeat.Any(); // Klartext: AccountName
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("F")).Return("drn0I4314VvDkPx/CLSu1kBHLLW1D6Fy7HlYwAMcMyw=").Repeat.Any(); // Klartext: Password
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("E")).Return("lW0Qqcm99mIdHsRVHRsXdg==").Repeat.Any(); // Klartext: APIKey
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("G")).Return("true").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("H")).Return("true").Repeat.Any();
                Expect.Call(RegistryService.ApplicationRegistryKeyExists()).Return(true).Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue(@"Software\Microsoft\Windows\CurrentVersion\Run", "mite.desk")).Return("executablepath").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("I")).Return("true").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("J")).Return("14").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("K")).Return(new DateTime(2009, 9, 14).ToShortDateString()).Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("L")).Return("12345").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("M")).Return("54321").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("N")).Return("en-US").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("O")).Return("false").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("P")).Return("proxy").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("Q")).Return("8080").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("R")).Return("N6bmZIEuU+0a3j3UB186eQ==").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("S")).Return("ygNNVm9GOfo5hZPeIrv67RunNJVsLJg+v9JlAReQE7Q=").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("T")).Return("true").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("U")).Return("true").Repeat.Any();
                Expect.Call(RegistryService.GetApplicationRegistryKeyValue("V")).Return("true").Repeat.Any();
            }
        }

        #endregion

        #region UpdateAppSettings

        [TestMethod]
        public void UpdateAppSettings_liefert_einen_Fehler_mit_Key_AccountName_wenn_dieser_leer_ist()
        {
            var settings = new AppSettings { AccountName = "" };
            var result = ConfigurationService.UpdateAppSettings(settings);
            Assert.IsTrue(result.ContainsKey("AccountName"));
        }

        [TestMethod]
        public void UpdateAppSettings_liefert_einen_Fehler_mit_Key_Email_wenn_diese_leer_ist_und_AuthenticationType_EmailAndPassword()
        {
            var settings = new AppSettings { Email = "", AuthenticationType = AuthenticationType.EmailAndPassword };
            var result = ConfigurationService.UpdateAppSettings(settings);
            Assert.IsTrue(result.ContainsKey("Email"));
        }

        [TestMethod]
        public void UpdateAppSettings_liefert_einen_Fehler_mit_Key_Email_wenn_diese_falsch_formatiert_istund_AuthenticationType_EmailAndPassword()
        {
            var settings = new AppSettings { Email = "falsch", AuthenticationType = AuthenticationType.EmailAndPassword };
            var result = ConfigurationService.UpdateAppSettings(settings);
            Assert.IsTrue(result.ContainsKey("Email"));
        }

        [TestMethod]
        public void UpdateAppSettings_liefert_einen_Fehler_mit_Key_Password_wenn_das_Passwort_nicht_angegeben_ist_und_AuthenticationType_EmailAndPassword()
        {
            var settings = new AppSettings { Password = "", AuthenticationType = AuthenticationType.EmailAndPassword  };
            var result = ConfigurationService.UpdateAppSettings(settings);
            Assert.IsTrue(result.ContainsKey("Password"));
        }

        [TestMethod]
        public void UpdateAppSettings_liefert_einen_Fehler_mit_Key_APIKey_wenn_dieser_leer_ist_und_AuthenticationType_APIKey()
        {
            var settings = new AppSettings { APIKey = "", AuthenticationType = AuthenticationType.APIKey };
            var result = ConfigurationService.UpdateAppSettings(settings);
            Assert.IsTrue(result.ContainsKey("APIKey"));
        }

        [TestMethod]
        public void UpdateAppSettings_liefert_keinen_Fehler_wenn_alle_Angaben_korrekt_ausgefüllt_sind()
        {
            var settings = new AppSettings { Password = "test", AccountName = "test", Email = "info@test.com" };
            var result = ConfigurationService.UpdateAppSettings(settings);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Emailadresse_wenn_angegeben_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "test", Email = "info@test.com" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("D", "H2KJPyLdpQ6aO3A83t3k54y48/oFoCfi49Ac7sISTDc="));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_das_Passwort_wenn_angegeben_verschlüsselt_in_der_Registry()
        {
            var settings = new AppSettings { Password = "Password", AccountName = "test", Email = "info@test.com" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("F", "drn0I4314VvDkPx/CLSu1kBHLLW1D6Fy7HlYwAMcMyw="));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Emailadresse_wenn_nicht_angegeben_als_Leerstring_in_der_Registry()
        {
            var settings = new AppSettings { AccountName = "AccountName", APIKey = "Key", AuthenticationType = AuthenticationType.APIKey};
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("D", string.Empty));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_das_Passwort_wennn_nicht_angegeben_als_Leerstring_in_der_Registry()
        {
            var settings = new AppSettings { AccountName = "AccountName", APIKey = "Key", AuthenticationType = AuthenticationType.APIKey };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("F", string.Empty));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_ApiKey_wenn_angegeben_verschlüsselt_in_der_Registry()
        {
            var settings = new AppSettings { AccountName = "AccountName", APIKey = "APIKey", AuthenticationType = AuthenticationType.APIKey };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("E", "lW0Qqcm99mIdHsRVHRsXdg=="));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_ApiKey_als_Leerstring_in_der_Registry_wenn_nicht_angegeben()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("E", string.Empty));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_Accountnamen_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("C", "gnrAw6R9MIEu7ODFX5vFP8oG3ViER5xKMPwe74iQBUQ="));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Info_ob_das_Fenster_beim_Schließen_minimiert_wird_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", MinimizeByClosing = false};
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("H", Boolean.FalseString));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_Pfad_zur_Anwendung_wenn_die_Anwendung_per_Autostart_geladen_werden_soll_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", Autostart = true };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue(@"Software\Microsoft\Windows\CurrentVersion\Run", "mite.desk", "executablepath"));
        }

        [TestMethod]
        public void UpdateAppSettings_löscht_den_Pfad_zur_Anwendung_wenn_die_Anwendung_nicht_per_Autostart_geladen_werden_soll_aus_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", Autostart = false };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.DeleteApplicationRegistryKeyValue(@"Software\Microsoft\Windows\CurrentVersion\Run", "mite.desk"));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Info_ob_die_Anwendung_minimiert_gestartet_werden_soll_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", StartMinimized = false };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("I", Boolean.FalseString));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_das_zuletzt_gewählte_Projekt_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", SelectedProjectID = 123 };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("L", "123"));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_zuletzt_gewählte_Leistung_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", SelectedActivityID = 456 };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("M", "456"));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Culture_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", Culture = "de-DE" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("N", "de-DE"));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Info_ob_ein_Proxy_verwendet_wird_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", UseProxy = true };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("O", true.ToString()));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_Proxyserver_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", ProxyServer = "proxy" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("P", "proxy"));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_Proxyport_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", ProxyPort = 8080 };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("Q", "8080"));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_den_ProxyUser_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", ProxyUser = "user" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("R", "N6bmZIEuU+0a3j3UB186eQ=="));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_das_ProxyPasswort_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", ProxyPassword = "password" };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("S", "ygNNVm9GOfo5hZPeIrv67RunNJVsLJg+v9JlAReQE7Q="));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Info_ob_die_Stoppuhr_beim_Schließen_automatisch_gestoppt_wird_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", StopStopwatchByClosing = true };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("T", true.ToString()));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Info_ob_beim_Schließen_gefragt_wird_ob_die_Stoppuhr_gestoppt_wird_in_der_Registry()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", AskForStoppingStopwatchByClosing = false };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("U", false.ToString()));
        }

        [TestMethod]
        public void UpdateAppSettings_speichert_die_Info_ob_Zeiteinträge_absteigend_sortiert_werden_sollen()
        {
            var settings = new AppSettings { Password = "test", AccountName = "AccountName", Email = "info@test.com", SortTimeEntriesDescending = false };
            ConfigurationService.UpdateAppSettings(settings);
            RegistryService.AssertWasCalled(r => r.SetApplicationRegistryKeyValue("V", false.ToString()));
        }

        #endregion

        #region GetAppSettings

        [TestMethod]
        public void GetAppSettings_liefert_die_in_der_Registry_gespeicherte_Email_Adresse()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("Email", result.Email);
        }

        [TestMethod]
        public void GetAppSettings_liefert_den_in_der_Registry_gespeicherten_ApiKey_entschlüsselt()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("APIKey", result.APIKey);
        }

        [TestMethod]
        public void GetAppSettings_liefert_den_in_der_Registry_gespeicherten_Accountnamen()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("AccountName", result.AccountName);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_in_der_Registry_gespeicherte_Info_ob_das_Fenster_beim_Schließen_minimiert_wird()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsTrue(result.MinimizeByClosing);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_in_der_Registry_gespeicherte_Info_ob_die_Anwendung_per_Autostart_gestartet_wird()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsTrue(result.Autostart);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_in_der_Registry_gespeicherte_Info_ob_die_Anwendung_minimiert_gestartet_wird()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsTrue(result.StartMinimized);
        }

        [TestMethod]
        public void GetAppSettings_liefert_den_Tag_an_dem_der_letzte_UpdateCheck_durchgeführt_wurde()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual(new DateTime(2009, 9, 14), result.LastUpdateCheck);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_ID_der_zuletzt_gewählten_Leistung()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual(54321, result.SelectedActivityID);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_ID_des_zuletzt_gewählten_Projektes()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual(12345, result.SelectedProjectID);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_aktuelle_Culture_wenn_in_Registry_vorhanden()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("en-US", result.Culture);
        }

        [TestMethod]
        public void GetAppSettings_liefert_als_aktuelle_Culture_deDE_wenn_nicht_in_Registry_gesetzt()
        {
            var tmpRegistryService = MockRepository.DynamicMock<IRegistryService>();
            using (MockRepository.Record())
            {
                Expect.Call(tmpRegistryService.ApplicationRegistryKeyExists()).Return(true).Repeat.Any();
                Expect.Call(tmpRegistryService.GetApplicationRegistryKeyValue("N")).Return("").Repeat.Any();
            }
            var tmpConfigurationService = new ConfigurationService(tmpRegistryService, EncryptionService, ApplicationID, "executablepath");
            var result = tmpConfigurationService.GetAppSettings();
            Assert.AreEqual("de-DE", result.Culture);
        }

        [TestMethod]
        public void GetAppSettings_liefert_den_Proxyserver()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsFalse(result.UseProxy);
        }

        [TestMethod]
        public void GetAppSettings_liefert_den_Proxyport()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("proxy", result.ProxyServer);
        }

        [TestMethod]
        public void GetAppSettings_liefert_die_Info_ob_ein_Proxy_verwendet_werden_soll()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual(8080, result.ProxyPort);
        }

        [TestMethod]
        public void GetAppSettings_liefert_den_Proxyuser()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("user", result.ProxyUser);
        }

        [TestMethod]
        public void GetAppSettings_liefert_das_Proxypasswort()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.AreEqual("password", result.ProxyPassword);
        }

        [TestMethod]
        public void GetAppSettings_liefert_StopStopwatchByClosing()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsTrue(result.StopStopwatchByClosing);
        }

        [TestMethod]
        public void GetAppSettings_liefert_AskForStoppingStopwatchByClosing()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsTrue(result.AskForStoppingStopwatchByClosing);
        }

        [TestMethod]
        public void GetAppSettings_liefert_SortTimeEntriesDescending()
        {
            var result = ConfigurationService.GetAppSettings();
            Assert.IsTrue(result.SortTimeEntriesDescending);
        }

        #endregion

    }
}
