using Microsoft.AspNetCore.Identity;

namespace Planning_platform.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //public int Class_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        //public string Email {  get; set; }
        public IList<Announcement> Announcements { get; } = new List<Announcement>();
        public IList<Lesson> Lessons { get; } = new List<Lesson>();
        //public IList<Class> Classes { get; } = new List<Class>();


        public int? ClassId { get; set; }

        //public Class? clas {  get; set; }



    }
}
