using Newtonsoft.Json;
using Report.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Report.Access
{
    public class SearchInApi
    {
        public static async Task RecentsBasePrice()
        {
            using (HttpClient client = new())
            {
                List<BasePrice> basePrices = new();
                BasePrice basePrice = new();
                bool hasItem = true;
                int item = 0;

                client.BaseAddress = new Uri("https://localhost:44317");
                do
                {
                    item++;
                    HttpResponseMessage response = await client.GetAsync($"api/BasePrices/{item}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        basePrices.Add(JsonConvert.DeserializeObject<BasePrice>(responseBody));
                    }

                    hasItem = response.IsSuccessStatusCode;

                } while (hasItem);

                var basePricesOrder = basePrices.OrderByDescending(basePrice => basePrice.InclusionDate);

                foreach (var basePriceOrder in basePricesOrder)
                {
                    var jsonString = JsonConvert.SerializeObject(basePriceOrder, Formatting.Indented);
                    Console.WriteLine(jsonString);
                }
            }

            Console.WriteLine("\n Pressione ENTER para voltar...");
            Console.ReadKey();
        }

        public static async Task TicketsBuyPerMonth()
        {
            string choice;
            int option = 0;
            bool flag = true;
            do
            {
                Console.WriteLine("\n Qual o mes que deseja gerar o relatorio? Pressione ENTER para gerar do mes atual.");
                Console.Write("\n Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out option);

                if (option < 0 || option > 12)
                {
                    Console.WriteLine("\n Opcao invalida.");
                    Console.WriteLine("\n Pressione ENTER para digitar novamente...");
                    Console.ReadKey();
                }
                else
                    flag = false;
            } while (flag);

            using (HttpClient client = new())
            {
                List<Ticket> tickets = new();
                List<Ticket> ticketsMonth = new();
                Ticket ticket = new();
                bool hasItem = true;
                int item = 0;

                client.BaseAddress = new Uri("https://localhost:44317");
                do
                {
                    item++;
                    HttpResponseMessage response = await client.GetAsync($"api/Tickets/{item}");

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        tickets.Add(JsonConvert.DeserializeObject<Ticket>(responseBody));
                    }

                    hasItem = response.IsSuccessStatusCode;

                } while (hasItem);

                tickets.ForEach(ticket =>
                {
                    if (option == 0)
                    {
                        if (ticket.RegistrationDate.Month == DateTime.Now.Month)
                        {
                            ticketsMonth.Add(ticket);
                        }
                    }
                    else
                    {
                        if (ticket.RegistrationDate.Month == option)
                        {
                            ticketsMonth.Add(ticket);
                        }
                    }

                });

                var ticketsOrder = ticketsMonth.OrderByDescending(ticket => ticket.RegistrationDate);

                foreach (var ticketOrder in ticketsOrder)
                {
                    var jsonString = JsonConvert.SerializeObject(ticketOrder, Formatting.Indented);
                    Console.WriteLine(jsonString);
                }
            }

            Console.WriteLine("\n Pressione ENTER para voltar...");
            Console.ReadKey();
        }

    }
}
