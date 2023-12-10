using Planning_platform.Entities;

namespace Planning_platform.Models
{
    public class LessonModel:Lesson
    {
        //public int Id { get; set; }
        //public string Day_of_week { get; set; }
        //public int Number_on_day { get; set; }
        ////public int Subject_id { get; set; }
        //public int SubjectId { get; set; } // Foreign key
        //public Subject Subject { get; set; } // Reference navigation
        ////public int Class_id { get; set; }
        //public int ClassId { get; set; } // Foreign key
        //public Class Class { get; set; } // Reference navigation

        ////public int teacher_id { get; set; }
        public string? TeacherId { get; set; } // Foreign key
        //public ApplicationUser Teacher { get; set; } // Reference navigation

        //public IList<Plan> Plans { get; } = new List<Plan>();
    }
}
