using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.AL.Dtos
{
	public class PartyDto
	{
		public int Id { get; set; }
		public ProductDto Product { get; set; }
		public int Count { get; set; }
        public Shipment Shipment { get; set; }
        public CellStorage? CellStorage { get; set; }
    }
}
