using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirlinesAPI2._0.Data;
using AndreAirlinesAPI2._0.Model;

namespace AndreAirlinesAPI2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirshipsController : ControllerBase
    {
        private readonly AndreAirlinesAPI2_0Context _context;

        public AirshipsController(AndreAirlinesAPI2_0Context context)
        {
            _context = context;
        }

        // GET: api/Airships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airship>>> GetAirship()
        {
            return await _context.Airship.ToListAsync();
        }

        // GET: api/Airships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airship>> GetAirship(string id)
        {
            var airship = await _context.Airship.FindAsync(id);

            if (airship == null)
            {
                return NotFound();
            }

            return airship;
        }

        // PUT: api/Airships/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirship(string id, Airship airship)
        {
            if (id != airship.Id)
            {
                return BadRequest();
            }

            _context.Entry(airship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirshipExists(id))
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

        // POST: api/Airships
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airship>> PostAirship(Airship airship)
        {
            _context.Airship.Add(airship);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AirshipExists(airship.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAirship", new { id = airship.Id }, airship);
        }

        // DELETE: api/Airships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirship(string id)
        {
            var airship = await _context.Airship.FindAsync(id);
            if (airship == null)
            {
                return NotFound();
            }

            _context.Airship.Remove(airship);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirshipExists(string id)
        {
            return _context.Airship.Any(e => e.Id == id);
        }
    }
}
