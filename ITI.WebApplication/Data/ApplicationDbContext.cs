using ITI.WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI.WebApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=default");
            }
        }

        public DbSet<Student> Students { get; private set; }
        public DbSet<Department> Departments { get; private set; }
    }
}
