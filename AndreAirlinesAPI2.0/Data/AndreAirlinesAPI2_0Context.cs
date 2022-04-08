using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreAirlinesAPI2._0.Model;

namespace AndreAirlinesAPI2._0.Data
{
    public class AndreAirlinesAPI2_0Context : DbContext
    {
        public AndreAirlinesAPI2_0Context (DbContextOptions<AndreAirlinesAPI2_0Context> options)
            : base(options)
        {
        }

        public DbSet<AndreAirlinesAPI2._0.Model.Address> Address { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.Airport> Airport { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.Airship> Airship { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.BasePrice> BasePrice { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.Class> Class { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.Flight> Flight { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.Passenger> Passenger { get; set; }

        public DbSet<AndreAirlinesAPI2._0.Model.Ticket> Ticket { get; set; }
    }
}
