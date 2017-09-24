using System;
using System.Collections.Generic;
using Reisapp.Models;
using Reisapp.Models.Services;

namespace Reisapp.Business.Services
{
    public static class CityService
    {
        public static int GetIdByName(string cityname)
        {
            List<CityModel> cities = new List<CityModel>();
            cities = CreateList.createList(cities);

            CityModel city = cities.Find(x => x.name == cityname);
            
            if (city == null)
            {
                return 0;
            }

            return city.id;
        }

        public static string GetNameByID(int id)
        {
            List<CityModel> cities = new List<CityModel>();
            cities = CreateList.createList(cities);

            CityModel city = cities.Find(x => x.id == id);

            if (city == null)
            {
                return "";
            }

            return city.name;
        }


        public static CityModel GetTowardsCity(string cityname, bool bus, bool train, bool airplane)
        {
			List<CityModel> cities = new List<CityModel>();
			cities = CreateList.createList(cities);

            List<ConnectionModel> removeCities = new List<ConnectionModel>();

            CityModel city = cities.Find(x => x.name == cityname);

			foreach (var item in city.connections)
			{
				if ((item.typeConnection == "Bus" && bus == true) || (item.typeConnection == "Trein" && train == true) || (item.typeConnection == "Vliegtuig" && airplane == true))
				{

				}
				else
				{
					removeCities.Add(item);
				}
			}

            foreach (var item in removeCities)
            {
                city.connections.Remove(item);
            }


            return city;

        }

        public static CityModel GetFromCity(string cityname, bool bus, bool train, bool airplane)
        {
            List<CityModel> cities = new List<CityModel>();
            cities = CreateList.createList(cities);

            List<ConnectionModel> removeCities = new List<ConnectionModel>();

            CityModel city = cities.Find(x => x.name == cityname);

			foreach (var item in city.connections)
			{
				if ((item.typeConnection == "Bus" && bus == true) || (item.typeConnection == "Trein" && train == true) || (item.typeConnection == "Vliegtuig" && airplane == true))
				{

				}
				else
				{
					removeCities.Add(item);
				}

                
            }
            

            foreach(var item in removeCities)
            {
                city.connections.Remove(item);
            }


            return city;
        }
    }
}
