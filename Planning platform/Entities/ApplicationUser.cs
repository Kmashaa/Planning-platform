using Microsoft.AspNetCore.Identity;

namespace Planning_platform.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int Class_id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email {  get; set; }

    }
}
