using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.DL.models
{
	public class Party
	{
		[Key] public int Id { get; set; }
		[ForeignKey("ProductID")] public Product Product { get; set; }
		public int ProductID { get; set; }
		[ForeignKey("ShipmentID")] public Shipment Shipment { get; set; }
		public int ShipmentID { get; set; }

		[ForeignKey("CellID")] public CellStorage? CellStorage { get; set; }
		public int? CellID { get; set; }
		public int Count { get; set; }
	}
}
