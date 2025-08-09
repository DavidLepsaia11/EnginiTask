using EnginiTask.Domain;
using Microsoft.EntityFrameworkCore;


namespace EnginiTask.Repository.Database.Configurations
{
    internal static class DatabaseInitializerExtensions
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Employee 1" , ManagerId = null },
            new Employee() { Id = 2, Name = "Employee 2", ManagerId = 1 },
            new Employee() { Id = 3, Name = "Employee 3", ManagerId = 1 },
            new Employee() { Id = 4, Name = "Employee 4", ManagerId = 2 },
            new Employee() { Id = 5, Name = "Employee 5" , ManagerId = 2 },
            new Employee() { Id = 6, Name = "Employee 6", ManagerId = 4 }
        );
    }
}
