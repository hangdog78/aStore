using System.Linq;
using aStoreServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using static System.Net.Mime.MediaTypeNames;

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
        async public Task<Operation> Post([FromBody] Operation value)
        {
            var tests= _context.Operations.AddAsync(value);
            _context.SaveChanges();
            System.Console.WriteLine(tests.GetType);
            return null;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Operations.ToList());
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
