using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace _16
{
    class Program
    {
        static string connectionString = @"Data Source=WIN-HGKNVQ9J21J;Initial Catalog=oop_16;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /* private static async Task SEL() // Відображення всієї інформації про таблицю клієнти
         {
             string sqlEx = "SELECT * FROM Buyers";
             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 await connection.OpenAsync();
                 SqlCommand cmd = new SqlCommand(sqlEx, connection);
                 SqlDataReader reader = await cmd.ExecuteReaderAsync();

                 if (reader.HasRows)
                 {
                     Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6));
                     while (await reader.ReadAsync())
                     {
                         int IdBuyer = reader.GetInt32(0);
                         string buyerName = reader.GetString(1);
                         object dateofBirth = reader.GetValue(2);
                         string GendBuyer = reader.GetString(3);
                         string Email_Buyer = reader.GetString(4);
                         string country = reader.GetString(5);
                         string City = reader.GetString(6);
                         Console.WriteLine($"{IdBuyer}\t{buyerName}\t{dateofBirth}\t{GendBuyer}\t{Email_Buyer}\t{country}\t{City}");
                     }
                 }
             }


         }
        */
        public  List<Oll> GetOll()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            List<Oll> list = connection.Query<Oll>("select * from buyers").ToList<Oll>();
            connection.Close();
            foreach (Oll oll in list)
            {
                Console.WriteLine($"{oll.idBuyer} {oll.NameBuyer.PadLeft(10)} {oll.dateOfBirth} {oll.GendBuyer.PadLeft(8)} {oll.Email_Buyer} {oll.country}{oll.City}");
            }
            return list;
        }



        private List<string> Email() // Відображення всієї інформації про пошту
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("SELECT Email_Buyer FROM Buyers").ToList<string>();
                foreach (var email in list)
                    Console.WriteLine(email);

                return list;
            }
        }

        private List<string> SectionInfo() // Відображення всієї інформації про імя секції
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("SELECT nameSection FROM Sections").ToList<string>();
                foreach (var section in list)
                    Console.WriteLine(section);

                return list;
            }
        }




        /*      private static async Task SectionInfo() // Відображення всієї інформації про міста
                  {
                      string sqlEx = "SELECT nameSection FROM Sections";
                      using (SqlConnection connection = new SqlConnection(connectionString))
                      {
                          await connection.OpenAsync();
                          SqlCommand cmd = new SqlCommand(sqlEx, connection);
                          SqlDataReader reader = await cmd.ExecuteReaderAsync();

                          if (reader.HasRows)
                          {
                              Console.WriteLine("0", reader.GetName(0));
                              while (await reader.ReadAsync())
                              {
                                  string nameSection = reader.GetString(0);
                                  Console.WriteLine(nameSection);
                              }
                          }
                      }


                  }

          */
        private List<string> ActionsInfo() //  Вiдображення списку розподiлу акцiйних товарiв
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("SELECT name_actions FROM actions").ToList<string>();
                foreach (var name_actions in list)
                    Console.WriteLine(name_actions);

                return list;
            }
        }


        /*     private static async Task ActionsInfo() // Відображення всієї інформації про міста
             {
                 string sqlEx = "SELECT name_actions FROM actions";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     await connection.OpenAsync();
                     SqlCommand cmd = new SqlCommand(sqlEx, connection);
                     SqlDataReader reader = await cmd.ExecuteReaderAsync();

                     if (reader.HasRows)
                     {
                         Console.WriteLine("0", reader.GetName(0));
                         while (await reader.ReadAsync())
                         {
                             string name_actions = reader.GetString(0);
                             Console.WriteLine(name_actions);
                         }
                     }
                 }


             }

        */
        private List<string> City() // Відображення про всі міста
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("SELECT City FROM Buyers group by City").ToList<string>();
                foreach (var City in list)
                    Console.WriteLine(City);

                return list;
            }
        }
        /*
        private static async Task City() // Відображення всієї інформації про міста
             {
                 string sqlEx = "SELECT City FROM Buyers group by City ";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     await connection.OpenAsync();
                     SqlCommand cmd = new SqlCommand(sqlEx, connection);
                     SqlDataReader reader = await cmd.ExecuteReaderAsync();

                     if (reader.HasRows)
                     {
                         Console.WriteLine("0", reader.GetName(0));
                         while (await reader.ReadAsync())
                         {
                             string City = reader.GetString(0);
                             Console.WriteLine(City);
                         }
                     }
                 }


             }
        */
        private List<string> Country() //  Вiдображення всiх країн
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query<string>("SELECT country FROM Buyers group by country").ToList<string>();
                foreach (var Country in list)
                    Console.WriteLine(Country);

                return list;
            }
        }

        /*
        
             private static async Task Country() // Відображення всієї інформації про країни
             {
                 string sqlEx = "SELECT country FROM Buyers group by country ";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                     await connection.OpenAsync();
                     SqlCommand cmd = new SqlCommand(sqlEx, connection);
                     SqlDataReader reader = await cmd.ExecuteReaderAsync();

                     if (reader.HasRows)
                     {
                         Console.WriteLine("0", reader.GetName(0));
                         while (await reader.ReadAsync())
                         {
                             string country = reader.GetString(0);
                             Console.WriteLine(country);
                         }
                     }
                 }


             }
         */

        private void CountBuyerCity() // Вiдобразити кiлькiсть покупцiв у кожному мiстi
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query("SELECT count(idBuyer) as count_idbuyer,City FROM Buyers group by City;");
                foreach (var CountBuyerCity in list)
                    Console.WriteLine(CountBuyerCity.count_idbuyer + " " + CountBuyerCity.City);
            }
        }
        private void CountBuyer() // Вiдобразити кiлькiсть покупцiв у кожнiй країнi
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query("SELECT count(idBuyer) as count_buyer,country FROM Buyers group by country;");
                foreach (var CountBuyer in list)
                    Console.WriteLine(CountBuyer.count_buyer + " " + CountBuyer.country);
            }
        }

        private void CountCity() // Вiдобразити кiлькiсть мiст у кожнiй країнi
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var list = connection.Query("SELECT count(City) as count_city,country FROM Buyers group by country;");
                foreach (var CountCity in list)
                    Console.WriteLine(CountCity.count_city + " " + CountCity.country);
            }
        }


        private void CityBuyres() // Вiдобразити кількість покупців у кожному місті
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.Write("Введiть назву мiстa: ");
                string city = Console.ReadLine();
                Console.WriteLine(city);
                var list = connection.Query("Sselect NameBuyer,dateOfBirth ,GendBuyer,City from buyers  where City=@city;", new { city }
                );
                foreach (var CityBuyres in list)
                    Console.WriteLine(CityBuyres.NameBuyer + " " + CityBuyres.dateOfBirth + " "+ CityBuyres.GendBuyer+ " " + CityBuyres.City );
            }
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Вiдображення всiх  покупцiв");
            Console.WriteLine("2. Вiдображення email  всiх покупцiв");
            Console.WriteLine("3. Вiдображення списку розподiлу");
            Console.WriteLine("4. Вiдображення списку розподiлу акцiйних товарiв");
            Console.WriteLine("5. Вiдображення всiх мiст");
            Console.WriteLine("6. Вiдображення всiх країн");
            Console.WriteLine("7.Вiдобразити кiлькiсть покупцiв у кожному мiстi");
            Console.WriteLine("8.Вiдобразити кiлькiсть покупцiв у кожнiй країнi");
            Console.WriteLine("9.Вiдобразити кiлькiсть мiст у кожнiй країнi");
            Console.WriteLine("10.Вiдобразити середню кiлькiсть мiст по всьому країнi");
            Console.WriteLine("11.Вiдобразити кількість покупців у кожному місті");


            var lu = new Program();

            int k = Convert.ToInt32(Console.ReadLine());

            while(k != 15)
            {
                switch (k)
                {
                    case 1:
                        Console.WriteLine(lu.GetOll());
                        break;
                    case 2:
                        Console.WriteLine(lu.Email());
                        break;
                    case 3:
                        Console.WriteLine(lu.SectionInfo());
                        break;
                    case 4:
                        Console.WriteLine(lu.ActionsInfo());
                        break;
                    case 5:
                        Console.WriteLine(lu.City());
                        break;
                    case 6:
                        Console.WriteLine(lu.Country());
                        break;
                    case 7:
                        lu.CountBuyerCity();
                        break;
                    case 8:
                        lu.CountBuyer();
                        break;
                    case 9:
                        lu.CountCity();
                        break;
                    case 11 :
                        lu.CityBuyres();
                        break;
                    default:
                         Console.WriteLine("Error");
                        break;
                }
                k = Convert.ToInt32(Console.ReadLine());
            }

        }
    }
}