namespace Planning_platform.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Subject_name { get; set; }
        public IList<Lesson> Lessons { get; } = new List<Lesson>();

    }
}
