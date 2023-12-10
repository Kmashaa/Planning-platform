namespace Planning_platform.Entities
{
    public class Homework
    {
        public int Id { get; set; }
        //public int Plan_id { get; set; }
        public int? PlanId { get; set; } // Foreign key
        public Plan Plan { get; set; } // Reference navigation
        public string Text { get; set; }
        public Boolean Is_publiched { get; set; }
    }
}
