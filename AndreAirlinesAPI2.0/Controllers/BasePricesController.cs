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
    public class BasePricesController : ControllerBase
    {
        private readonly AndreAirlinesAPI2_0Context _context;

        public BasePricesController(AndreAirlinesAPI2_0Context context)
        {
            _context = context;
        }

        // GET: api/BasePrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasePrice>>> GetBasePrice()
        {
            return await _context.BasePrice.Include(basePrice => basePrice.Destiny.Address)
                                           .Include(basePrice => basePrice.Origin.Address)
                                           .Include(basePrice => basePrice.Class)
                                           .ToListAsync();
        }

        // GET: api/BasePrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasePrice>> GetBasePrice(int id)
        {
            var basePrice = await _context.BasePrice.Include(basePrice => basePrice.Destiny.Address)
                                                    .Include(basePrice => basePrice.Origin.Address)
                                                    .Include(basePrice => basePrice.Class)
                                                    .Where(basePrice => basePrice.Id == id)
                                                    .FirstOrDefaultAsync();

            if (basePrice == null)
            {
                return NotFound();
            }

            return basePrice;
        }

        // PUT: api/BasePrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasePrice(int id, BasePrice basePrice)
        {
            if (id != basePrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(basePrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasePriceExists(id))
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

        // POST: api/BasePrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BasePrice>> PostBasePrice(BasePrice basePrice)
        {
            var airportOrigin = await _context.Airport.Include(address => address.Address).Where(airport => airport.Acronym == basePrice.Origin.Acronym).FirstOrDefaultAsync();
            var airportDestiny = await _context.Airport.Include(address => address.Address).Where(airport => airport.Acronym == basePrice.Destiny.Acronym).FirstOrDefaultAsync();
            var classFlight = await _context.Class.FindAsync(basePrice.Class.Id);

            if (airportOrigin != null)
                basePrice.Origin = airportOrigin;
            if (airportDestiny != null)
                basePrice.Destiny = airportDestiny;
            if (classFlight != null)
                basePrice.Class = classFlight;

            _context.BasePrice.Add(basePrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasePrice", new { id = basePrice.Id }, basePrice);
        }

        // DELETE: api/BasePrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasePrice(int id)
        {
            var basePrice = await _context.BasePrice.FindAsync(id);
            if (basePrice == null)
            {
                return NotFound();
            }

            _context.BasePrice.Remove(basePrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasePriceExists(int id)
        {
            return _context.BasePrice.Any(e => e.Id == id);
        }
    }
}
