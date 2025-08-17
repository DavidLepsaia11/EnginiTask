using EnginiTask.Domain;

namespace EnginiTask.Service.Interfaces.Services
{
    public interface IEmployeeService : IQueryService<Employee>
    {
        Task<EmployeeNode?> GetHierarchyAsync(int Id);
    }
}
