using System.Web.Http;
using HangFireLegacy.Services;

namespace HangFireLegacy.Controllers
{
    [Route("values")]
    public class ValuesController : ApiController
    {
        private readonly IRepository _repository;

        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }
        // GET api/values
        public object Get()
        {
            return new {Result = _repository.Foo()};
        }
    }
}
