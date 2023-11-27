namespace Planning_platform.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Teacher_id { get; set; }
        public int Student_id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}
