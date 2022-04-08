using AndreAirlinesAPI2._0.Data;
using AndreAirlinesAPI2._0.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AndreAirlinesAPI2._0.Service
{
    public class NewTicket
    {
        //private static readonly AndreAirlinesAPI2_0Context _context = _context;

        public static async Task<Ticket> ReturnPriceTicket(Ticket ticket, AndreAirlinesAPI2_0Context _context)
        {
            decimal price;
            double percent = 0;

            var basePrice = await _context.BasePrice.Where(basePrice =>
                                                                       basePrice.Origin == ticket.Flight.Origin &&
                                                                       basePrice.Destiny == ticket.Flight.Destiny &&
                                                                       basePrice.Class.Id == ticket.Class.Id)
                                                    .OrderByDescending(basePrice => basePrice.InclusionDate)
                                                    .FirstOrDefaultAsync();
            percent = basePrice.PercentPromotion;

            if (basePrice.Class.Id != 4)
            {
                price = basePrice.Price - (basePrice.Price * ((decimal)percent / 100));
                ticket.Price = price;
                return ticket;
                
            }
            else
            {
                price = basePrice.Price;
                ticket.Price = price;
                return ticket;
            }
        }
    }
}
