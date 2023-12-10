using Planning_platform.Entities;

namespace Planning_platform.Models
{
    public class UserModel:ApplicationUser
    {
        public int? ClassId { get; set; }
    }
}
