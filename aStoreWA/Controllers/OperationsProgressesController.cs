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
    public class OperationsProgressesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OperationsProgressesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OperationsProgresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationsProgress>>> GetOperationsProgress()
        {
          if (_context.OperationsProgress == null)
          {
              return NotFound();
          }
            return await _context.OperationsProgress.ToListAsync();
        }

        // GET: api/OperationsProgresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationsProgress>> GetOperationsProgress(int id)
        {
          if (_context.OperationsProgress == null)
          {
              return NotFound();
          }
            var operationsProgress = await _context.OperationsProgress.FindAsync(id);

            if (operationsProgress == null)
            {
                return NotFound();
            }

            return operationsProgress;
        }

        // PUT: api/OperationsProgresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationsProgress(int id, OperationsProgress operationsProgress)
        {
            if (id != operationsProgress.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationsProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationsProgressExists(id))
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

        // POST: api/OperationsProgresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperationsProgress>> PostOperationsProgress(OperationsProgress operationsProgress)
        {
          if (_context.OperationsProgress == null)
          {
              return Problem("Entity set 'ApplicationContext.OperationsProgress'  is null.");
          }
            _context.OperationsProgress.Add(operationsProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperationsProgress", new { id = operationsProgress.Id }, operationsProgress);
        }

        // DELETE: api/OperationsProgresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationsProgress(int id)
        {
            if (_context.OperationsProgress == null)
            {
                return NotFound();
            }
            var operationsProgress = await _context.OperationsProgress.FindAsync(id);
            if (operationsProgress == null)
            {
                return NotFound();
            }

            _context.OperationsProgress.Remove(operationsProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationsProgressExists(int id)
        {
            return (_context.OperationsProgress?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
