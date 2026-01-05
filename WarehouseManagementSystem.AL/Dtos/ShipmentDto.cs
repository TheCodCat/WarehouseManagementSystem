using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementSystem.AL.Dtos
{
	public class ShipmentDto
	{
		[Key] public int Id { get; set; }
		public PartyDto[] Partys { get; set; }
		public DateTime DateTime { get; set; }
	}
}
