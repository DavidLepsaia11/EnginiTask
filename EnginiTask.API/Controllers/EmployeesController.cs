using EnginiTask.Domain;
using EnginiTask.Repository.Database;
using EnginiTask.Service.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnginiTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service, EmployeesDbContext db)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<Employee>>> GetAll()
        {
            var employees = await _service.Set()    
                                .AsNoTracking()
                                .ToListAsync();   
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = _service.Get(id);
            if (employee is null) return NotFound();
            object Shape(Employee n) => new
            {
                n.Id,
                n.Name,
                n.ManagerId,
                Subordinates = (n.Subordinates ?? Array.Empty<Employee>())
                      .Select(Shape).ToList() 
            };
            var resp = Shape(employee); 
            return Ok(resp);
        }
    }
}
