using System;

namespace SixtyNineDegrees.MiteDesk.Core.Model
{

    public class AppSettings
    {
        public string Culture { get; set; }
        public int SelectedProjectID { get; set; }
        public int SelectedActivityID { get; set; }
        public DateTime LastUpdateCheck { get; set; }
        public bool StartMinimized { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
        public string AccountName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string APIKey { get; set; }
        public bool MinimizeByClosing { get; set; }
        public bool Autostart { get; set; }
        public bool UseProxy { get; set; }
        public int ProxyPort { get; set; }
        public string ProxyServer { get; set; }
        public string ProxyUser { get; set; }
        public string ProxyPassword { get; set; }
        public bool StopStopwatchByClosing { get; set; }
        public bool AskForStoppingStopwatchByClosing { get; set; }
        public bool SortTimeEntriesDescending { get; set; }
    }

    public enum AuthenticationType
    {
        EmailAndPassword = 0,
        APIKey = 1
    }

}
