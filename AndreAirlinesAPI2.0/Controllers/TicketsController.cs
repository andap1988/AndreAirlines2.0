using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirlinesAPI2._0.Data;
using AndreAirlinesAPI2._0.Model;
using AndreAirlinesAPI2._0.Service;

namespace AndreAirlinesAPI2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AndreAirlinesAPI2_0Context _context;

        public TicketsController(AndreAirlinesAPI2_0Context context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return await _context.Ticket.Include(ticket => ticket.Flight.Destiny.Address)
                                        .Include(ticket => ticket.Flight.Origin.Address)
                                        .Include(ticket => ticket.Flight.Airship)
                                        .Include(ticket => ticket.Passenger.Address)
                                        .ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Ticket.Include(ticket => ticket.Flight.Destiny.Address)
                                        .Include(ticket => ticket.Flight.Origin.Address)
                                        .Include(ticket => ticket.Flight.Airship)
                                        .Include(ticket => ticket.Passenger.Address)
                                        .Where(ticket => ticket.Id == id)
                                        .FirstOrDefaultAsync();

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            var flight = await _context.Flight.Include(flight => flight.Destiny)
                                              .Include(flight => flight.Destiny.Address)
                                              .Include(flight => flight.Origin)
                                              .Include(flight => flight.Origin.Address)
                                              .Include(flight => flight.Airship)
                                              .Where(flight => flight.Id == ticket.Flight.Id).FirstOrDefaultAsync();
            var passenger = await _context.Passenger.Include(passenger => passenger.Address).Where(passenger => passenger.Cpf == ticket.Passenger.Cpf).FirstOrDefaultAsync();
            var newClass = await _context.Class.FindAsync(ticket.Class.Id);

            ticket.Class = newClass;
            ticket.Passenger = passenger;
            ticket.Flight = flight;

            var newTicket = NewTicket.ReturnPriceTicket(ticket, _context);

            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
