using System;
using System.Collections.Generic;
using Reisapp.Models;

namespace Reisapp.Models.Services
{
    public class CreateList
    {
		//CreateCities
		public static List<CityModel> createList(List<CityModel> list)
		{
			list.Add(new CityModel
			{
				id = 1,
				name = "Landgraaf",
				connections = new List<ConnectionModel>() {
                    new ConnectionModel() {CurrentID = 1, towardsID = 2, duration = 5, typeConnection = "Trein"},
                    new ConnectionModel() {CurrentID = 1, towardsID = 2, duration = 8, typeConnection = "Bus"},
                    new ConnectionModel() {CurrentID = 1, towardsID = 3, duration = 10, typeConnection = "Bus"}
				},
			});

			list.Add(new CityModel
			{
				id = 2,
				name = "Brunssum",
				connections = new List<ConnectionModel>(){
					new ConnectionModel() {CurrentID = 2, towardsID = 1, duration = 5, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 2, towardsID = 3, duration = 7, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 2, towardsID = 4, duration = 2, typeConnection = "Bus"}
				},
			});

			list.Add(new CityModel
			{
				id = 3,
				name = "Heerlen",
				connections = new List<ConnectionModel>() {
					new ConnectionModel() {CurrentID = 3, towardsID = 1, duration = 10, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 3, towardsID = 2, duration = 7, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 3, towardsID = 5, duration = 5, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 3, towardsID = 6, duration = 8, typeConnection = "Bus"}
				}
			});

			list.Add(new CityModel
			{
				id = 4,
				name = "Hoensbroek",
				connections = new List<ConnectionModel>() {
					new ConnectionModel() {CurrentID = 4, towardsID = 2, duration = 2, typeConnection = "Bus"}
				},
			});

			list.Add(new CityModel
			{
				id = 5,
				name = "Valkenburg",
				connections = new List<ConnectionModel>() {
					new ConnectionModel() {CurrentID = 5, towardsID = 3, duration = 5, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 5, towardsID = 7, duration = 12, typeConnection = "Bus"}
				},
			});

			list.Add(new CityModel
			{
				id = 6,
				name = "Sittard",
				connections = new List<ConnectionModel>() {
					new ConnectionModel() {CurrentID = 6, towardsID = 3, duration = 8, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 6, towardsID = 7, duration = 7, typeConnection = "Bus"}
				},
			});

			list.Add(new CityModel
			{
				id = 7,
				name = "Maastricht",
				connections = new List<ConnectionModel>() {
					new ConnectionModel() {CurrentID = 7, towardsID = 5, duration = 5, typeConnection = "Bus"},
					new ConnectionModel() {CurrentID = 7, towardsID = 6, duration = 10, typeConnection = "Bus"}
				},
			});

			return list;
		}

	}
}
