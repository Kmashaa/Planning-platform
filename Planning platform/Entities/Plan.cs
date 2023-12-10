namespace Planning_platform.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        //public int Lesson_id { get; set; }
        public int? LessonId { get; set; } // Foreign key
        public DateTime Date { get; set; }
        public Lesson Lesson { get; set; } // Reference navigation


        public IList<Homework> Homeworks { get; } = new List<Homework>();


    }
}
