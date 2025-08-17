using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginiTask.Domain
{
    public class EmployeeFlat
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; } = "";
    }
}
