using aStoreServer.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aStoreServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TestController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Operation value)
        {
            var tests = await _context.Operations.AddAsync(value);
            _context.SaveChanges();
            var tmp = new ObjectResult(tests) { StatusCode = StatusCodes.Status201Created };

            return tmp;
   
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TraceController : ControllerBase
    {
       public class TestController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TestController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTests()
        {
            var tests = _context.Test.ToList();
            return Ok(tests);
        }
    }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
