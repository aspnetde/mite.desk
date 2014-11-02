namespace SixtyNineDegrees.MiteDesk.Core.Model
{
    public class Activity
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int HourlyRate { get; set; }
        public bool Billable { get; set; }
        public bool Archived { get; set; }

        public override bool Equals(object obj)
        {
            var a = (Activity) obj;
            return ID == a.ID &&
                   Name == a.Name &&
                   Note == a.Note &&
                   HourlyRate == a.HourlyRate &&
                   Billable == a.Billable &&
                   Archived == a.Archived;
        }

    }
}
