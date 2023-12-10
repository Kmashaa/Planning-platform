using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planning_platform.Entities;

namespace Planning_platform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Announcement> Announcements { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        //public DbSet<Logg> Loggs { get; set; } = null!;
        public DbSet<Plan> Plans { get; set; } = null!;
        //public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}