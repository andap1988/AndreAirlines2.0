using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class Ticket
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Flight")]
        public Flight Flight { get; set; }

        [JsonProperty("Passenger")]
        public Passenger Passenger { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("Class")]
        public Class Class { get; set; }

        [JsonProperty("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }
    }
}
