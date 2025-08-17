using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginiTask.Domain
{
    public sealed class EmployeeNode
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int? ManagerId { get; init; }
        public List<EmployeeNode> Subordinates { get; } = new();
    }
}
