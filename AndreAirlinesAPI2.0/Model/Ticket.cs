using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndreAirlinesAPI2._0.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public Class Class { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
