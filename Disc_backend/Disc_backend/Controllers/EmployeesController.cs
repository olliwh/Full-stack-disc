using Disc_backend.Models;
using Disc_backend.Repositories;
using Isopoh.Cryptography.Argon2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Disc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<Employee>
    {
        private readonly IEmployeesRepository _employeeRepository;
        public EmployeesController(IGenericRepository<Employee> repository, IEmployeesRepository empRepo) : base(repository) 
        {
            _employeeRepository = empRepo;
        }
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
        [HttpGet("getDefaultPass")]
        public IActionResult getDefaultPass()
        {
            string password = "Pass@word1";
            string hash = Argon2.Hash(password);
            return Ok(hash);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<IActionResult> GetAll(
            [FromQuery] int? departmentId = null,
            [FromQuery] int? discProfileId = null,
            [FromQuery] int? positionId = null)
        {
            var employees = await _employeeRepository.GetAll(departmentId, discProfileId, positionId);
            return Ok(employees);
        }
    }
}
