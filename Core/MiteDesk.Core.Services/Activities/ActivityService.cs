using System;
using System.Collections.Generic;
using SixtyNineDegrees.MiteDesk.Core.Data;
using SixtyNineDegrees.MiteDesk.Core.Model;

namespace SixtyNineDegrees.MiteDesk.Core.Services
{
    public class ActivityService : IActivityService
    {

        public ActivityService(IActivityRepository repository)
        {
            Repository = repository;
        }

        private readonly IActivityRepository Repository;

        public IList<Activity> GetAllActiveActivities()
        {
            return Repository.GetAllActiveActivities();
        }

        public IList<Activity> GetAllArchivedActivities()
        {
            return Repository.GetAllArchivedActivities();
        }

        public Dictionary<string, string> CreateActivity(Activity activity, string hourlyRate)
        {
            var errors = ValidateActivity(activity);
            if (errors.Count == 0)
            {
                activity.HourlyRate = ParseHourlyRate(hourlyRate);
                Repository.CreateActivity(activity);
            }
            return errors;
        }

        public Dictionary<string, string> UpdateActivity(Activity activity, string hourlyRate)
        {
            if (activity.ID == 0)
                throw new ArgumentException(Localization.Activities.IDException, "activity");

            var errors = ValidateActivity(activity);
            if (errors.Count == 0)
            {
                activity.HourlyRate = ParseHourlyRate(hourlyRate);
                Repository.UpdateActivity(activity);
            }

            return errors;
        }

        private static Dictionary<string, string> ValidateActivity(Activity activity)
        {
            var errors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(activity.Name) || activity.Name.Trim().Length == 0)
            {
                errors.Add("Name", Localization.Activities.NameEmpty);
            }
            return errors;
        }

        private static int ParseHourlyRate(string value)
        {
            
            int rate = 0;
            
            if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
                return rate;

    
            if(value.IndexOf(',') > -1)
            {

                int first, second;

                int.TryParse(value.Split(',')[0], out first);

                if (value.Split(',')[1].Length <= 2)
                {
                    int.TryParse(value.Split(',')[1], out second);
                }
                else
                {
                    decimal tmp;
                    decimal.TryParse(value, out tmp);
                    tmp = Math.Round(tmp, 2);
                    int.TryParse(tmp.ToString().Split(',')[1], out second);
                }

                rate = (first*100) + second;

            }
            else
            {
                int.TryParse(value, out rate);
                if(rate > 0)
                {
                    rate = rate * 100;
                }
            }

            return rate;

        }

        public Activity GetActivityByID(int activityID)
        {
            return Repository.GetActivityByID(activityID);
        }

        public void DeleteActivity(int activityID)
        {
            Repository.DeleteActivity(activityID);
        }
    }
}
