using System;
using System.Collections.Generic;
using Reisapp.Models;
using Reisapp.Models.Services;

namespace Reisapp.Business.Services
{
    public class RouteService
    {
        public static List<CityModel> createList(bool isbus, bool istrain, bool isairplane)
        {
			List<CityModel> cities = new List<CityModel>();
			cities = CreateList.createList(cities);

            List<CityModel> result = new List<CityModel>();


            foreach (var item in cities)
            {
                List<ConnectionModel> list = new List<ConnectionModel>();
                foreach(var connection in item.connections)
                {
                    if ((isbus == true && connection.typeConnection == "Bus") || (istrain == true && connection.typeConnection == "Trein") || (isairplane == true && connection.typeConnection == "Vliegtuig")) { }
                    else 
                    {
                        list.Add(connection);

                    }
                }

				for (int i = 0; i < list.Count; i++)
				{
					item.connections.Remove(list[i]);
				}
            }
            return cities;
        }

        public static ShortestRoadModel FindRoute(int startpoint, int endpoint, bool isbus, bool istrain, bool isairplane)
        {
			//Initialize
			bool IsBus = isbus;
			bool IsTrain = istrain;
			bool IsAirplane = isairplane;

            List<CityModel> cities = createList(IsBus, IsTrain, IsAirplane);
			List<CityModel> listBeen = new List<CityModel>();
			List<ShortestRoadModel> shortestRoad = new List<ShortestRoadModel>();
            List<ConnectionModel> connections = new List<ConnectionModel>();

            int startPoint = startpoint;
            int endPoint = endpoint;

			//bool shortestRouteFound = false;
			int totalDuration = 0;

            var result = Induction(cities, listBeen, shortestRoad, startPoint, endPoint, cities.Find(x => x.id == startPoint), totalDuration, connections, null);

            return result;

        }

        public static ShortestRoadModel Induction(List<CityModel> cities, List<CityModel> listBeen, List<ShortestRoadModel> shortestRoad, int startPoint, int endPoint, CityModel currentModel, int totalDuration, List<ConnectionModel> previousIDList, ConnectionModel currentconnection)
		{
			var duration = totalDuration;
			var count = currentModel.connections.Count;
			foreach (var item in currentModel.connections)
			{
				var x = listBeen.Find(y => y.id == item.towardsID);
				if (x != null) { count = count - 1; }
			}

			bool endPointFound = false;



			if (currentModel.connections.Count <= 0)
			{
				//Stoppen en terug
				//if (totalduration < shortestroad.currentid) {Vervangen}
				if (shortestRoad.Find(x => x.CurrentID == currentModel.id) == null)
				{
                    previousIDList = addPreviousID(previousIDList, currentconnection);
                    CreateShortestRoadModel(currentModel.id, previousIDList, totalDuration, shortestRoad, endPoint, currentconnection);
				}

				if (totalDuration < shortestRoad.Find(x => x.CurrentID == currentModel.id).TotalDuration)
				{
                    previousIDList = addPreviousID(previousIDList, currentconnection);
                    EditShortestRoadModel(currentModel.id, previousIDList, totalDuration, shortestRoad, endPoint, currentconnection);
				}

				return shortestRoad.Find(x => x.CurrentID == currentModel.id);
			}
			else if (currentModel.id == endPoint)
			{
				//Stoppen en terug
				//if (totalduration < shortestroad.currentid) {Vervangen}
				if (shortestRoad.Find(x => x.CurrentID == currentModel.id) == null)
				{
                    CreateShortestRoadModel(currentModel.id, previousIDList, totalDuration, shortestRoad, endPoint, currentconnection);
				}

				if (totalDuration < shortestRoad.Find(x => x.CurrentID == currentModel.id).TotalDuration)
				{
                    EditShortestRoadModel(currentModel.id, previousIDList, totalDuration, shortestRoad, endPoint, currentconnection);
				}

				endPointFound = true;

				return shortestRoad.Find(x => x.CurrentID == currentModel.id);
			}
			else
			{
				List<ConnectionModel> list = new List<ConnectionModel>();
				//Voer inductie uit en los op
				foreach (var connection in currentModel.connections)
				{
					var x = listBeen.Find((y => y.id == connection.towardsID));
					if (x == null) { list.Add(connection); }
				}

				foreach (var connection in list)
				{
                    currentconnection = connection;
					totalDuration = duration;
					totalDuration = totalDuration + currentModel.connections.Find(x => x.towardsID == connection.towardsID).duration;

                    previousIDList = addPreviousID(previousIDList, currentconnection);

					if (shortestRoad.Find(x => x.CurrentID == currentModel.id) == null)
					{
                        CreateShortestRoadModel(currentModel.id, previousIDList, totalDuration, shortestRoad, endPoint, currentconnection);
					}

					if (totalDuration < shortestRoad.Find(x => x.CurrentID == currentModel.id).TotalDuration)
					{
                        EditShortestRoadModel(currentModel.id, previousIDList, totalDuration, shortestRoad, endPoint, currentconnection);
					}

					listBeen.Add(currentModel);
					var nextCityModel = cities.Find(x => x.id == connection.towardsID);

                    Induction(cities, listBeen, shortestRoad, startPoint, endPoint, nextCityModel, totalDuration, previousIDList, currentconnection);


					
				    previousIDList.Remove(currentconnection);
					
				}

				

				listBeen.Remove(currentModel);
				return shortestRoad.Find(x => x.CurrentID == endPoint);
			}
		}

        public static List<ConnectionModel> addPreviousID(List<ConnectionModel> connections, ConnectionModel currentconnection)
		{
            var result = connections.IndexOf(currentconnection);

            if (result == -1) { connections.Add(currentconnection); }

            return connections;
		}


		//Helpers
        public static void CreateShortestRoadModel(int currentid, List<ConnectionModel> previousid, int totalduration, List<ShortestRoadModel> shortestRoad, int endpoint, ConnectionModel currentconnection)
		{
			ShortestRoadModel model = new ShortestRoadModel()
			{
				CurrentID = currentid,
                PreviousID = new List<ConnectionModel>(),
				TotalDuration = totalduration,
			};

			foreach (var item in previousid)
			{
				model.PreviousID.Add(item);
			}
            if (currentid != endpoint) { model.PreviousID.Add(currentconnection); }

			shortestRoad.Add(model);
		}

        public static void EditShortestRoadModel(int currentid, List<ConnectionModel> previousid, int totalduration, List<ShortestRoadModel> shortestRoad, int endpoint, ConnectionModel currentconnection)
		{
			var old = shortestRoad.Find(x => x.CurrentID == currentid);
			shortestRoad.Remove(old);

			ShortestRoadModel model = new ShortestRoadModel()
			{
				CurrentID = currentid,
                PreviousID = new List<ConnectionModel>(),
				TotalDuration = totalduration,
			};



			foreach (var item in previousid)
			{
				model.PreviousID.Add(item);
			}
            if (currentid != endpoint) { model.PreviousID.Add(currentconnection); }

			shortestRoad.Add(model);
		}

    }
}
