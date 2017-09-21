using System;
using System.Collections.Generic;
using Reisapp.Models;
using Reisapp.Models.Services;

namespace Reisapp.Business.Services
{
    public class CityService
    {
        public CityModel GetTowardsCity(string cityname, bool bus, bool train, bool airplane)
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

            return city;

        }

        public CityModel GetFromCity(string cityname, bool bus, bool train, bool airplane)
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

            return city;
        }
    }
}
