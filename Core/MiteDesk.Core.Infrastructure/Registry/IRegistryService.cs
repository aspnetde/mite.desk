using System;

namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure
{
    public interface IRegistryService
    {
        bool ApplicationRegistryKeyExists();
        void CreateApplicationRegistryKey();
        void SetApplicationRegistryKeyValue(string name, string value);
        void SetApplicationRegistryKeyValue(string key, string name, string value);
        void DeleteApplicationRegistryKeyValue(string key, string name);
        string GetApplicationRegistryKeyValue(string key, string name);
        string GetApplicationRegistryKeyValue(string name);
    }
}
