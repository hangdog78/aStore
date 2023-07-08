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
    public class DepGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DepGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/DepGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepGroup>>> GetDepGroup()
        {
          if (_context.DepGroup == null)
          {
              return NotFound();
          }
            return await _context.DepGroup.ToListAsync();
        }

        // GET: api/DepGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepGroup>> GetDepGroup(int id)
        {
          if (_context.DepGroup == null)
          {
              return NotFound();
          }
            var depGroup = await _context.DepGroup.FindAsync(id);

            if (depGroup == null)
            {
                return NotFound();
            }

            return depGroup;
        }

        // PUT: api/DepGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepGroup(int id, DepGroup depGroup)
        {
            if (id != depGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(depGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepGroupExists(id))
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

        // POST: api/DepGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepGroup>> PostDepGroup(DepGroup depGroup)
        {
          if (_context.DepGroup == null)
          {
              return Problem("Entity set 'ApplicationContext.DepGroup'  is null.");
          }
            _context.DepGroup.Add(depGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepGroup", new { id = depGroup.Id }, depGroup);
        }

        // DELETE: api/DepGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepGroup(int id)
        {
            if (_context.DepGroup == null)
            {
                return NotFound();
            }
            var depGroup = await _context.DepGroup.FindAsync(id);
            if (depGroup == null)
            {
                return NotFound();
            }

            _context.DepGroup.Remove(depGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepGroupExists(int id)
        {
            return (_context.DepGroup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
