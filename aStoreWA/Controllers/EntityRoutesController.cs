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
    public class EntityRoutesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EntityRoutesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/EntityRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntityRoute>>> GetEntityRoute()
        {
          if (_context.EntityRoute == null)
          {
              return NotFound();
          }
            return await _context.EntityRoute.ToListAsync();
        }

        // GET: api/EntityRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntityRoute>> GetEntityRoute(int id)
        {
          if (_context.EntityRoute == null)
          {
              return NotFound();
          }
            var entityRoute = await _context.EntityRoute.FindAsync(id);

            if (entityRoute == null)
            {
                return NotFound();
            }

            return entityRoute;
        }

        // PUT: api/EntityRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityRoute(int id, EntityRoute entityRoute)
        {
            if (id != entityRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityRouteExists(id))
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

        // POST: api/EntityRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntityRoute>> PostEntityRoute(EntityRoute entityRoute)
        {
          if (_context.EntityRoute == null)
          {
              return Problem("Entity set 'ApplicationContext.EntityRoute'  is null.");
          }
            _context.EntityRoute.Add(entityRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityRoute", new { id = entityRoute.Id }, entityRoute);
        }

        // DELETE: api/EntityRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityRoute(int id)
        {
            if (_context.EntityRoute == null)
            {
                return NotFound();
            }
            var entityRoute = await _context.EntityRoute.FindAsync(id);
            if (entityRoute == null)
            {
                return NotFound();
            }

            _context.EntityRoute.Remove(entityRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityRouteExists(int id)
        {
            return (_context.EntityRoute?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
