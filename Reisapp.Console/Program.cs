using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reisapp.Business.Services;
namespace Reisapp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welkom bij de Reisapp");
            System.Console.WriteLine("Kies de optie");
            System.Console.WriteLine("Optie 1: Vindt de route van een stad naar een andere stad.");
            System.Console.WriteLine("Optie 2: Vindt de verbindingen vanuit een stad.");
            System.Console.WriteLine("Optie 3: Vindt de verbindingen richting een stad.");

    

            int option = Convert.ToInt32(System.Console.ReadLine());

            while (option > 3)
            {
                System.Console.WriteLine("Dit is geen optie.");
                System.Console.WriteLine("Kies de optie");
                System.Console.WriteLine("Optie 1: Vindt de route van een stad naar een andere stad.");
                System.Console.WriteLine("Optie 2: Vindt de verbindingen vanuit een stad.");
                System.Console.WriteLine("Optie 3: Vindt de verbindingen richting een stad.");
                option = Convert.ToInt32(System.Console.ReadLine());
            }

            if (option == 1)
            {
                System.Console.WriteLine("Van welke stad wilt u reizen?");
                var FromCity = System.Console.ReadLine();
                int FromCityID = CityService.GetIdByName(FromCity);
                while (FromCityID == 0)
                {
                    System.Console.WriteLine("Deze stad bestaat niet in onze database, kies een andere");
                    FromCity = System.Console.ReadLine();
                    FromCityID = CityService.GetIdByName(FromCity);
                }
               

                System.Console.WriteLine("Naar welke stad wilt u reizen");
                var TowardsCity = System.Console.ReadLine();
                int TowardsCityID = CityService.GetIdByName(TowardsCity);
                while (TowardsCityID == 0)
                {
                    System.Console.WriteLine("Deze stad bestaat niet in onze database, kies een andere");
                    TowardsCity = System.Console.ReadLine();
                    TowardsCityID = CityService.GetIdByName(TowardsCity);
                }

                System.Console.WriteLine("Welk van de volgende transport type wilt u gebruiken?");
                System.Console.WriteLine("Type een 0 voor nee");
                System.Console.WriteLine("Type een 1 voor ja");
                System.Console.WriteLine("");
                
                
                System.Console.WriteLine("Bus: ");
                int bus = Convert.ToInt32(System.Console.ReadLine());
                while (bus > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    bus = Convert.ToInt32(System.Console.ReadLine());
                }

                System.Console.WriteLine("Trein: ");
                int train = Convert.ToInt32(System.Console.ReadLine());
                while (train > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    train = Convert.ToInt32(System.Console.ReadLine());
                }

                System.Console.WriteLine("Vliegtuig: ");
                int airplane = Convert.ToInt32(System.Console.ReadLine());
                while (airplane > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    airplane = Convert.ToInt32(System.Console.ReadLine());
                }

                bool isbus = false;
                bool istrain = false;
                bool isairplane = false;

                if (bus == 1) { isbus = true; }
                if (train == 1) { istrain = true; }
                if (airplane == 1) { isairplane = true; }

                var result = RouteService.FindRoute(FromCityID, TowardsCityID, isbus, istrain, isairplane);

                System.Console.WriteLine("");
                System.Console.WriteLine("");
                System.Console.WriteLine("");                

                foreach (var item in result.PreviousID)
                {
                    if (item == null) { System.Console.WriteLine("Er is geen verbinding tussen de twee plaatsen");}
                    else
                    {
                        System.Console.WriteLine("Van: " + CityService.GetNameByID(item.CurrentID));
                        System.Console.WriteLine("Naar: " + CityService.GetNameByID(item.towardsID));
                        System.Console.WriteLine("Transport type: " + item.typeConnection);
                        System.Console.WriteLine("Duur: " + item.duration + " minuten");
                        System.Console.WriteLine("");
                    }
                    
                }

                System.Console.WriteLine("");
                System.Console.WriteLine("");

                System.Console.WriteLine("De totale tijd van de route: " + result.TotalDuration + " minuten");


                System.Console.ReadLine();
            }

            if (option == 2)
            {
                System.Console.WriteLine("Van welke stad wilt u de verbindingen weten?");
                var cityname = System.Console.ReadLine();
                int cityid = CityService.GetIdByName(cityname);

                while(cityid == 0)
                {
                    System.Console.WriteLine("Deze stad staat niet in onze database, kies een andere");
                    cityname = System.Console.ReadLine();
                    cityid = CityService.GetIdByName(cityname);
                }

                System.Console.WriteLine("Welk van de volgende transport type wilt u gebruiken?");
                System.Console.WriteLine("Type een 0 voor nee");
                System.Console.WriteLine("Type een 1 voor ja");
                System.Console.WriteLine("");


                System.Console.WriteLine("Bus: ");
                int bus = Convert.ToInt32(System.Console.ReadLine());
                while (bus > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    bus = Convert.ToInt32(System.Console.ReadLine());
                }

                System.Console.WriteLine("Trein: ");
                int train = Convert.ToInt32(System.Console.ReadLine());
                while (train > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    train = Convert.ToInt32(System.Console.ReadLine());
                }

                System.Console.WriteLine("Vliegtuig: ");
                int airplane = Convert.ToInt32(System.Console.ReadLine());
                while (airplane > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    airplane = Convert.ToInt32(System.Console.ReadLine());
                }

                bool isbus = false;
                bool istrain = false;
                bool isairplane = false;

                if (bus == 1) { isbus = true; }
                if (train == 1) { istrain = true; }
                if (airplane == 1) { isairplane = true; }

                System.Console.WriteLine("");

                var result = CityService.GetFromCity(cityname, isbus, istrain, isairplane);

                if (result.connections.Count == 0) { System.Console.WriteLine("Er zijn geen verbindingen vanuit deze plek."); }

                foreach(var item in result.connections)
                {
                    if (item == null)
                    {
                        System.Console.WriteLine("Er zijn geen verbindingen vanuit deze plek.");
                    }
                    else
                    {
                        if (item.towardsID == cityid)
                        {
                            System.Console.WriteLine("Van: " + CityService.GetNameByID(item.CurrentID));
                            System.Console.WriteLine("Naar: " + CityService.GetNameByID(item.towardsID));
                        }
                        else
                        {
                            System.Console.WriteLine("Van: " + CityService.GetNameByID(item.towardsID));
                            System.Console.WriteLine("Naar: " + CityService.GetNameByID(item.CurrentID));
                        }
                        System.Console.WriteLine("Transport type: " + item.typeConnection);
                        System.Console.WriteLine("Duur: " + item.duration + " minuten");
                        System.Console.WriteLine("");
                    }
                    
                }

                System.Console.ReadLine();

            }


            if (option == 3)
            {
                System.Console.WriteLine("Van welke stad wilt u de verbindingen richting deze stad weten?");
                var cityname = System.Console.ReadLine();
                int cityid = CityService.GetIdByName(cityname);

                while (cityid == 0)
                {
                    System.Console.WriteLine("Deze stad staat niet in onze database, kies een andere");
                    cityname = System.Console.ReadLine();
                    cityid = CityService.GetIdByName(cityname);
                }

                System.Console.WriteLine("Welk van de volgende transport type wilt u gebruiken?");
                System.Console.WriteLine("Type een 0 voor nee");
                System.Console.WriteLine("Type een 1 voor ja");
                System.Console.WriteLine("");


                System.Console.WriteLine("Bus: ");
                int bus = Convert.ToInt32(System.Console.ReadLine());
                while (bus > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    bus = Convert.ToInt32(System.Console.ReadLine());
                }

                System.Console.WriteLine("Trein: ");
                int train = Convert.ToInt32(System.Console.ReadLine());
                while (train > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    train = Convert.ToInt32(System.Console.ReadLine());
                }

                System.Console.WriteLine("Vliegtuig: ");
                int airplane = Convert.ToInt32(System.Console.ReadLine());
                while (airplane > 1)
                {
                    System.Console.WriteLine("Geen geldige invoer, type 0 of 1: ");
                    airplane = Convert.ToInt32(System.Console.ReadLine());
                }

                bool isbus = false;
                bool istrain = false;
                bool isairplane = false;

                if (bus == 1) { isbus = true; }
                if (train == 1) { istrain = true; }
                if (airplane == 1) { isairplane = true; }

                System.Console.WriteLine("");

                var result = CityService.GetTowardsCity(cityname, isbus, istrain, isairplane);

                if (result.connections.Count == 0) { System.Console.WriteLine("Er zijn geen verbindingen vanuit deze plek."); }

                foreach (var item in result.connections)
                {
                    if (item == null) { System.Console.WriteLine("Er zijn geen verbindingen richting deze stad."); }
                    else
                    {
                        if (item.towardsID == cityid)
                        {
                            System.Console.WriteLine("Van: " + CityService.GetNameByID(item.CurrentID));
                            System.Console.WriteLine("Naar: " + CityService.GetNameByID(item.towardsID));
                        }
                        else
                        {
                            System.Console.WriteLine("Van: " + CityService.GetNameByID(item.towardsID));
                            System.Console.WriteLine("Naar: " + CityService.GetNameByID(item.CurrentID));
                        }

                        System.Console.WriteLine("Transport type: " + item.typeConnection);
                        System.Console.WriteLine("Duur: " + item.duration + " minuten");
                        System.Console.WriteLine("");
                    }
                    
                }

                System.Console.ReadLine();
            }

            System.Console.ReadLine();

        }
    }
}
