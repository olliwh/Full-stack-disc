using Disc_backend.Models;
using Disc_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : GenericController<Company>
    {
        public CompaniesController(IGenericRepository<Company> repository) : base(repository) { }

    }
}
