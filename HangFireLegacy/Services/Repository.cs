using System.Linq;
using HangFireLegacy.Data;

namespace HangFireLegacy.Services
{
    public class Repository : IRepository
    {
        private readonly HangFireLegacyContext _context;

        public Repository(HangFireLegacyContext context)
        {
            _context = context;
        }
        public string Foo()
        {
            var result = _context.Foos.FirstOrDefault();
            return result != null ? result.Bar : "bar";
        }
    }
}
