using System.ComponentModel.DataAnnotations;

namespace AndreAirlinesAPI2._0.Model
{
    public class Airport
    {
        [Key]
        public string Acronym { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
