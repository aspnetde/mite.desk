namespace SixtyNineDegrees.MiteDesk.Core.Model
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string BudgetType { get; set; }
        public int Budget { get; set; }
        public bool Archived { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public override bool Equals(object obj)
        {
            var p = (Project)obj;
            return ID == p.ID &&
                   Name == p.Name &&
                   Note == p.Note &&
                   Budget == p.Budget &&
                   BudgetType == p.BudgetType &&
                   Archived == p.Archived;
        }

    }
}
