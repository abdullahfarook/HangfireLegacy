using System.Web.Http;
using HangFireLegacy.Services;

namespace HangFireLegacy.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {
        private readonly IRepository _repository;

        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }
        // GET api/values
        [Route("")]
        [HttpGet]
        public object Get()
        {
            return new {Result = _repository.Foo()};
        }
    }
}
