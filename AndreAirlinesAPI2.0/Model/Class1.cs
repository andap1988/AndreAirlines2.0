namespace AndreAirlinesAPI2._0.Model
{
    public class Class1
    {/*
        public static int Menu()
        {
            string choice;
            int option;
            bool flag = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\n Menu de Relatorios \n");
                Console.WriteLine(" 1 - Preco Base Recentes");
                Console.WriteLine(" 2 - Passagens Compradas no Mes");
                Console.WriteLine(" 3 - Sair");
                Console.Write("\n Escolha: ");
                choice = Console.ReadLine();
                int.TryParse(choice, out option);

                if (option < 1 || option > 3)
                {
                    Console.WriteLine("\n Opcao invalida.");
                    Console.WriteLine("\n Pressione ENTER para voltar");
                    Console.ReadKey();
                }
                else
                    flag = false;
            } while (flag);

            return option;

        }
        static void Main(string[] args)
        {
            int option;
            bool flag = true;

            option = Menu();

            do
            {
                switch (option)
                {
                    case 1:

                        option = Menu();
                        break;
                    case 2:

                        option = Menu();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        option = Menu();
                        break;
                }

            } while (flag);

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t Andre Airlines Agradece a Preferencia!");
            Console.WriteLine("\n\n\n\n\n\n\n");
        }

        public static async void RecentsBasePrice()
        {
            HttpClient client = new();

            try
            {

                client.BaseAddress = new Uri("https://localhost:44382");

                HttpResponseMessage response = await client.GetAsync("api/BasePrice");

            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine("Exception HttpRequest => " + exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Generic => " + exception.Message);
            }
        }*/
    }
}
