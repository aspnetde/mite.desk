using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Text;

namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure
{
    public class RegistryService : IRegistryService
    {
        private const string RegistryKey = "Software\\69 Grad\\mite.desk";

        public bool ApplicationRegistryKeyExists()
        {
            return Registry.CurrentUser.OpenSubKey(RegistryKey) != null;
        }

        public void CreateApplicationRegistryKey()
        {
            Registry.CurrentUser.CreateSubKey(RegistryKey);
        }

        public void SetApplicationRegistryKeyValue(string key, string name, string value)
        {
            var subKey = Registry.CurrentUser.OpenSubKey(key, true);
            if (subKey == null)
                Registry.CurrentUser.CreateSubKey(key);
            subKey.SetValue(name, value ?? string.Empty);
        }

        public void DeleteApplicationRegistryKeyValue(string key, string name)
        {
            var subKey = Registry.CurrentUser.OpenSubKey(key, true);
            if (subKey != null && subKey.GetValue(name) != null)
                subKey.DeleteValue(name);
        }

        public string GetApplicationRegistryKeyValue(string key, string name)
        {
            return (string)Registry.CurrentUser.OpenSubKey(key).GetValue(name);
        }

        public string GetApplicationRegistryKeyValue(string name)
        {
            return GetApplicationRegistryKeyValue(RegistryKey, name);
        }

        public void SetApplicationRegistryKeyValue(string name, string value)
        {
            SetApplicationRegistryKeyValue(RegistryKey, name, value);
        }
    }
}
