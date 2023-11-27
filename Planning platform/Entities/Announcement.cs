namespace Planning_platform.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int Moderator_id { get; set; }
    }
}
