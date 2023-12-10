using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Planning_platform.Models
{
    public class ChangeClassModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<Planning_platform.Entities.Class> AllClasses { get; set; }
        public int? UserClasses {  get; set; }
        //public IList<string> UserClasses { get; set; }
        public ChangeClassModel()
        {
            AllClasses = new List<Planning_platform.Entities.Class>();
            UserClasses = 0;
        }
    }
}
