using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirlinesAPI2._0.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public Airport Destiny { get; set; }
        public Airport Origin { get; set; }
        public Airship Airship { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DisembarkationTime { get; set; }
    }
}
