using EnginiTask.Domain;
using EnginiTask.Service.Interfaces.Repositories;
using EnginiTask.Service.Interfaces.Services;

namespace EnginiTask.Service
{
    public class EmployeeService : ServiceBase<Employee, IEmployeeRepository>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
        }

        public Task<EmployeeNode?> GetHierarchyAsync(int Id) =>
            _repository.GetHierarchyAsync(Id);

    }
}
