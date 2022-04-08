﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Model
{
    public class Class
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
