namespace Planning_platform.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Day_of_week { get; set; }
        public int Number_on_day { get; set; }
        public int Subject_id { get; set; }
        public int Class_id { get; set; }
        //public List<Class> Class { get; set; }    
        //public int Class_id { get; set; }
        public int teacher_id { get; set; }
    }
}
