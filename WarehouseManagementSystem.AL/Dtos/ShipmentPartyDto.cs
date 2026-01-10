using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.AL.Dtos
{
	public class ShipmentPartyDto
	{
		public int Id { get; set; }
		public Party Party { get; set; }
		public string CellTitle { get; set; }
	}
}
