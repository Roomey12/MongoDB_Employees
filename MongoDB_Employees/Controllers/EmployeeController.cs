using Microsoft.AspNetCore.Mvc;
using MongoDB_Employees.Models;
using MongoDB_Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get() =>
            _employeeService.Get();

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var emp = _employeeService.Get(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            _employeeService.Create(employee);
            return Ok();
        }
    }
}
