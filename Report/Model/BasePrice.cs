using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class BasePrice
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Origin")]
        public Airport Origin { get; set; }

        [JsonProperty("Destiny")]
        public Airport Destiny { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("PercentPromotion")]
        public double PercentPromotion { get; set; }

        [JsonProperty("Class")]
        public Class Class { get; set; }

        [JsonProperty("InclusionDate")]
        public DateTime InclusionDate { get; set; }
    }
}
