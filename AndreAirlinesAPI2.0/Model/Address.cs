using Newtonsoft.Json;

namespace AndreAirlinesAPI2._0.Model
{
    public class Address
    {
        public int Id { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }
        public string Country { get; set; }

        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

        public Address(string district, string city, string country, string zipCode, string street, string state, int number, string complement)
        {
            District = district;
            City = city;
            Country = country;
            ZipCode = zipCode;
            Street = street;
            State = state;
            Number = number;
            Complement = complement;
        }
    }
}
