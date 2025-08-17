using EnginiTask.Domain;
using EnginiTask.Repository.Database;
using EnginiTask.Service.Interfaces.Repositories;
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

        public EmployeesController(IEmployeeService service)
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
        public async Task<ActionResult<EmployeeNode>> Get(int id)
        {
            var employee = await _service.GetHierarchyAsync(id);
            if (employee is null) return NotFound();
            return Ok(employee);
        }
    }
}
