using AndreAirlinesAPI2._0.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AndreAirlinesAPI2._0.Service
{
    public class SearchZipCode
    {

        public static async Task<Address> ReturnAddress(string zipCode)
        {
            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://viacep.com.br/ws/" + zipCode + "/json/");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var address = JsonConvert.DeserializeObject<Address>(responseBody);
                    return address;
                }
                else
                {
                    return null;
                }

            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine("\n Exception caught!");
                Console.WriteLine("\n Message: {0}", exception.Message);
                throw exception;
            }
        }
    }
}
