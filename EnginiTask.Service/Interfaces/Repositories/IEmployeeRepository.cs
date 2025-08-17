using EnginiTask.Domain;


namespace EnginiTask.Service.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<EmployeeNode?> GetHierarchyAsync(int Id);
    }
}
