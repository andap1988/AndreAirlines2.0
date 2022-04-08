using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class Address
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("District")]
        public string District { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Number")]
        public int Number { get; set; }

        [JsonProperty("Complement")]
        public string Complement { get; set; }
    }
}
