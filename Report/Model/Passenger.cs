using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class Passenger
    {
        [JsonProperty("Cpf")]
        public string Cpf { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Telephone")]
        public string Telephone { get; set; }

        [JsonProperty("DateBirth")]
        public DateTime DateBirth { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Address")]
        public virtual Address Address { get; set; }
    }
}
