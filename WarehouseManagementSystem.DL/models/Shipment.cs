using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementSystem.DL.models
{
	public class Shipment
	{
		[Key] public int Id { get; set; }
		public ICollection<Party> PartyList { get; set; }
		public DateTime DateTime { get; set; }
	}
}
