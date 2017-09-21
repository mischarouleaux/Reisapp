using System;
using System.Collections.Generic;

namespace Reisapp.Models
{
	public class CityModel
	{
		public int id { get; set; }
		public string name { get; set; }
		public List<ConnectionModel> connections { get; set; }


	}
}
