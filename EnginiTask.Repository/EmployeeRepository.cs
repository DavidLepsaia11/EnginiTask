using EnginiTask.Domain;
using EnginiTask.Repository.Database;
using EnginiTask.Service.Interfaces.Repositories;

namespace EnginiTask.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(EmployeesDbContext context) : base(context)
        {
        }
    }
}
