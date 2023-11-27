namespace Planning_platform.Entities
{
    public class Logg
    { 
        public int Id { get; set; }
        public int Teacher_id { get; set; }
        public int Homework_id { get; set; }
        public string Action { get; set; }
        public DateTime Created { get; set; }
    }
}
