using Disc_backend.Models;
using Disc_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<Employee>
    {
        public EmployeesController(IGenericRepository<Employee> repository) : base(repository) { }
        /// <summary>
        /// todo:
        /// return statuscode on all controllers
        /// employee_priovate info controller?
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        // Example of custom endpoint
        [HttpGet("by-department/{departmentId}")]
        public IActionResult GetByDepartment(int departmentId)
        {
            // You can extend with repo or DbContext logic
            return Ok($"Employees from department {departmentId}");
        }
    }
}
