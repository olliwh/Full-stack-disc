using Disc_backend.Models;
using Disc_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Disc_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : GenericController<Person>
    {
        public PersonsController(IGenericRepository<Person> repository) : base(repository) { }

    }
}
