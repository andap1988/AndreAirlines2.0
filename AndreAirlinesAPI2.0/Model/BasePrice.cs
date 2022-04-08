using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndreAirlinesAPI2._0.Model
{
    public class BasePrice
    {
        public int Id { get; set; }
        public Airport Origin { get; set; }
        public Airport Destiny { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public double PercentPromotion { get; set; }
        public Class Class { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InclusionDate { get; set; }
    }
}
