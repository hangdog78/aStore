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
    public class OperationStatesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OperationStatesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/OperationStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperationState>>> GetOperationState()
        {
          if (_context.OperationState == null)
          {
              return NotFound();
          }
            return await _context.OperationState.ToListAsync();
        }

        // GET: api/OperationStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationState>> GetOperationState(int id)
        {
          if (_context.OperationState == null)
          {
              return NotFound();
          }
            var operationState = await _context.OperationState.FindAsync(id);

            if (operationState == null)
            {
                return NotFound();
            }

            return operationState;
        }

        // PUT: api/OperationStates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperationState(int id, OperationState operationState)
        {
            if (id != operationState.Id)
            {
                return BadRequest();
            }

            _context.Entry(operationState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperationStateExists(id))
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

        // POST: api/OperationStates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OperationState>> PostOperationState(OperationState operationState)
        {
          if (_context.OperationState == null)
          {
              return Problem("Entity set 'ApplicationContext.OperationState'  is null.");
          }
            _context.OperationState.Add(operationState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperationState", new { id = operationState.Id }, operationState);
        }

        // DELETE: api/OperationStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperationState(int id)
        {
            if (_context.OperationState == null)
            {
                return NotFound();
            }
            var operationState = await _context.OperationState.FindAsync(id);
            if (operationState == null)
            {
                return NotFound();
            }

            _context.OperationState.Remove(operationState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperationStateExists(int id)
        {
            return (_context.OperationState?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
