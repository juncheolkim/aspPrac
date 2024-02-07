using aspAPIPrac.Model;
using Microsoft.AspNetCore.Mvc;
using SqlKata.Execution;

namespace aspAPIPrac.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {

        private readonly QueryFactory db;

        public DummyController(QueryFactory db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            var users = await db.Query("dummyData").GetAsync();

            return users;
        }
    }
}
