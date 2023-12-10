namespace Planning_platform.Entities
{
    public class Blog
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public IList<Post> Posts { get; } = new List<Post>();

    }
}
