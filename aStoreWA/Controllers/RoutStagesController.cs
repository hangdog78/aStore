using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aStoreServer.Models;

namespace aStoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutStagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RoutStagesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RoutStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoutStage>>> GetRoutStage()
        {
          if (_context.RoutStage == null)
          {
              return NotFound();
          }
            return await _context.RoutStage.ToListAsync();
        }

        // GET: api/RoutStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoutStage>> GetRoutStage(int id)
        {
          if (_context.RoutStage == null)
          {
              return NotFound();
          }
            var routStage = await _context.RoutStage.FindAsync(id);

            if (routStage == null)
            {
                return NotFound();
            }

            return routStage;
        }

        // PUT: api/RoutStages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoutStage(int id, RoutStage routStage)
        {
            if (id != routStage.Id)
            {
                return BadRequest();
            }

            _context.Entry(routStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoutStageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RoutStages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoutStage>> PostRoutStage(RoutStage routStage)
        {
          if (_context.RoutStage == null)
          {
              return Problem("Entity set 'ApplicationContext.RoutStage'  is null.");
          }
            _context.RoutStage.Add(routStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoutStage", new { id = routStage.Id }, routStage);
        }

        // DELETE: api/RoutStages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoutStage(int id)
        {
            if (_context.RoutStage == null)
            {
                return NotFound();
            }
            var routStage = await _context.RoutStage.FindAsync(id);
            if (routStage == null)
            {
                return NotFound();
            }

            _context.RoutStage.Remove(routStage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoutStageExists(int id)
        {
            return (_context.RoutStage?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
