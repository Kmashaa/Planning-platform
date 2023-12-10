namespace Planning_platform.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string? ModeratorId { get; set; } // Foreign key
        public ApplicationUser? Moderator { get; set; } // Reference navigation
    }
}
