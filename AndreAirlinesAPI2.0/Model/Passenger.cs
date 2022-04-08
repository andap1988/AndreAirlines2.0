using System;
using System.ComponentModel.DataAnnotations;

namespace AndreAirlinesAPI2._0.Model
{
    public class Passenger
    {
        [Key]
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public virtual Address Address { get; set; }
    }
}
