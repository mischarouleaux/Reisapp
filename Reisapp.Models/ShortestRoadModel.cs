using System;
using System.Collections.Generic;

namespace Reisapp.Models
{
	public class ShortestRoadModel
	{

		public int CurrentID { get; set; }
        public List<ConnectionModel> PreviousID { get; set; }
		public int TotalDuration { get; set; }
        public string typeConnection { get; set; }

	}
}