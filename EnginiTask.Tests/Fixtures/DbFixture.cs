using EnginiTask.Repository.Database;
using Microsoft.Extensions.DependencyInjection;
using EnginiTask.Tests.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnginiTask.Domain;

namespace EnginiTask.Tests.Fixtures
{
    public sealed class DbFixture : IDisposable
    {
        private readonly EmployeesDbContext _dbContext;

        public DbFixture()
        {
            var services = new ServiceCollection();
            services.ConfigureDbContext();

            _dbContext = services
                .BuildServiceProvider()
                .GetService<EmployeesDbContext>()!;

            InsertTestData();
        }

        public void Dispose() => _dbContext.Dispose();

        private void InsertTestData()
        {
            _dbContext.Employees.Add(new Employee { Id = 1, Name = "Employee 1", ManagerId = null });
            _dbContext.Employees.Add(new Employee() { Id = 2, Name = "Employee 2", ManagerId = 1 });
            _dbContext.Employees.Add(new Employee() { Id = 3, Name = "Employee 3", ManagerId = 1 });
            _dbContext.Employees.Add(new Employee() { Id = 4, Name = "Employee 4", ManagerId = 2 });
            _dbContext.Employees.Add(new Employee() { Id = 5, Name = "Employee 5", ManagerId = 2 });
            _dbContext.Employees.Add(new Employee() { Id = 6, Name = "Employee 6", ManagerId = 4 });

            _dbContext.SaveChanges();
        }
    }

    [CollectionDefinition("DbFixture")]
    public sealed class EmployeesCollection : ICollectionFixture<DbFixture> { }
}
