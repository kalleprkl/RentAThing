#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAThing.Models;

namespace RentAThing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly RentalContext _context;

        public ThingsController(RentalContext context)
        {
            _context = context;
        }

        // GET: api/Things
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thing>>> GetThings()
        {
            return await _context.Things.ToListAsync();
        }

        // GET: api/Things/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thing>> GetThing(int id)
        {
            var thing = await _context.Things.FindAsync(id);

            if (thing == null)
            {
                return NotFound();
            }

            return thing;
        }

        // PUT: api/Things/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThing(int id, Thing thing)
        {
            if (id != thing.ID)
            {
                return BadRequest();
            }

            _context.Entry(thing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThingExists(id))
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

        // POST: api/Things
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thing>> PostThing(Thing thing)
        {
            _context.Things.Add(thing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThing", new { id = thing.ID }, thing);
        }

        // DELETE: api/Things/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThing(int id)
        {
            var thing = await _context.Things.FindAsync(id);
            if (thing == null)
            {
                return NotFound();
            }

            _context.Things.Remove(thing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThingExists(int id)
        {
            return _context.Things.Any(e => e.ID == id);
        }
    }
}
