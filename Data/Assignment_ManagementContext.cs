using Microsoft.EntityFrameworkCore;
using Assignment_Management.Models;

namespace Assignment_Management.Data
{
    public class Assignment_ManagementContext : DbContext
    {
        public Assignment_ManagementContext (DbContextOptions<Assignment_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Professor> Professor { get; set;} = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Course_Professors> Course_Professors { get; set; } = default!;
        public DbSet<Course_Students> Course_Students { get; set; } = default!;
    }
}
