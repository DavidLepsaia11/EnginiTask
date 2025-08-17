using EnginiTask.Domain;
using EnginiTask.Repository.Database;
using EnginiTask.Service.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnginiTask.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesDbContext context) : base(context)
        {
        }

        public async Task<EmployeeNode?> GetHierarchyAsync(int Id)
        {
             var flat = await _context.EmployeeSubtree
                .FromSqlInterpolated($@"
                    WITH cte AS (
                        SELECT Id, ManagerId, Name
                        FROM dbo.Employees WHERE Id = {Id}
                        UNION ALL
                        SELECT e.Id, e.ManagerId, e.Name
                        FROM dbo.Employees e
                        INNER JOIN cte ON e.ManagerId = cte.Id
                    )
                    SELECT Id, ManagerId, Name FROM cte 
                    OPTION (MAXRECURSION 32767);")
                    .AsNoTracking()
                    .ToListAsync();

            if (flat.Count == 0) return null;

            var nodes = new Dictionary<int, EmployeeNode>(flat.Count);
            foreach (var r in flat)
                nodes[r.Id] = new EmployeeNode { Id = r.Id, Name = r.Name, ManagerId = r.ManagerId };

            foreach (var n in nodes.Values)
                if (n.ManagerId is int m && nodes.TryGetValue(m, out var parent))
                    parent.Subordinates.Add(n);

            return nodes[Id];

        }
    }
}
