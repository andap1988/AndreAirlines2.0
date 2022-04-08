using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class Flight
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Destiny")]
        public Airport Destiny { get; set; }

        [JsonProperty("Origin")]
        public Airport Origin { get; set; }

        [JsonProperty("Airship")]
        public Airship Airship { get; set; }

        [JsonProperty("DepartureTime")]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("DisembarkationTime")]
        public DateTime DisembarkationTime { get; set; }
    }
}
