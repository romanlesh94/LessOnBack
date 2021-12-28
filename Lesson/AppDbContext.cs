using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=lessondb;Trusted_Connection=True;");
        }

    }
}
