using EnginiTask.Domain;
using EnginiTask.Repository.Database.Configurations;
using Microsoft.EntityFrameworkCore;


namespace EnginiTask.Repository.Database
{
    public sealed class EmployeesDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureEntities();
            modelBuilder.SeedDefaultData();
        }
    }
}
