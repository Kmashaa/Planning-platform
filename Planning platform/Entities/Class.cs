namespace Planning_platform.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public int Num_of_class { get; set; }
        public char Letter_of_class { get; set; }
        //public List<Lesson> Lessons { get; set; }
        public IList<Lesson> Lessons { get; } = new List<Lesson>();
        public IList<ApplicationUser> Students { get; } = new List<ApplicationUser>();

        //public int? ClassId { get; set; } // Foreign key
        //public Class Clas { get; set; } // Reference navigation
        //public ApplicationUser? student { get; set; }

    }
}
