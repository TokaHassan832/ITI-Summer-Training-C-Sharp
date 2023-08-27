using Microsoft.EntityFrameworkCore;

namespace mvc1.Models
{
    public class ITIContext : DbContext
    {

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Department> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EVM7DE3;Database = ITI;Trusted_Connection = True;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
