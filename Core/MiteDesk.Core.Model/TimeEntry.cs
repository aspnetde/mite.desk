using System;

namespace SixtyNineDegrees.MiteDesk.Core.Model
{
    public class TimeEntry
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public string Note { get; set; }
        public int ProjectID { get; set; }
        public int ActivityID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string ActivityName { get; set; }
        public bool Locked { get; set; }
    }
}
