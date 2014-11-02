using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure
{
    public interface IConfigurationService
    {
        AppSettings GetAppSettings();
        Dictionary<string, string> UpdateAppSettings(AppSettings settings);
    }
}
