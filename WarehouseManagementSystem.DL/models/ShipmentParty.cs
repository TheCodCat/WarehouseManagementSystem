using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.DL.models
{
	public class ShipmentParty
	{
		public int Id { get; set; }
		public Party Party { get; set; }
		public string CellTitle { get; set; }
	}
}
