using Disc_backend.Models;
using Disc_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : GenericController<Department>
    {
        public DepartmentsController(IGenericRepository<Department> repository) : base(repository) { }

    }
}
