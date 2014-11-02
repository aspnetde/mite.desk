using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Data
{
    public interface IActivityRepository
    {
        IList<Activity> GetAllActiveActivities();
        IList<Activity> GetAllArchivedActivities();
        Activity GetActivityByID(int activityID);
        void DeleteActivity(int activityID);
        void CreateActivity(Activity activity);
        void UpdateActivity(Activity activity);
    }
}