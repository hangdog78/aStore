using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aStoreServer.Models;
using System.Data.Entity.ModelConfiguration;

namespace aStoreServer.Controllers
{

    public class GroupEntityTypeConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupEntityTypeConfiguration()
        {
            // Определяем связь между дочерними категориями.
            HasMany(p => p.Children).
                WithOptional(p => p.Parent);

            // Определяем связь между продуктами категориями.
            HasMany(p => p.Entitys)
                .WithMany(p => p.Groups);

            // Указание таблицы в БД.
            ToTable("Groups");
        }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public GroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroup()
        {
          if (_context.Group == null)
          {
              return NotFound();
          }
            return await _context.Group.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
          if (_context.Group == null)
          {
              return NotFound();
          }
            var @group = await _context.Group.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return @group;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group @group)
        {
          if (_context.Group == null)
          {
              return Problem("Entity set 'ApplicationContext.Group'  is null.");
          }
            if (@group.GroupId != null)
            {
                var group2 = await _context.Group.FindAsync(@group.GroupId);
                if (group2 != null)
                {
                    @group.Parent = group2;
                    group2.Children.Add(@group);
                }
                
            }
            _context.Group.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (_context.Group == null)
            {
                return NotFound();
            }
            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Group.Remove(@group);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(int id)
        {
            return (_context.Group?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
