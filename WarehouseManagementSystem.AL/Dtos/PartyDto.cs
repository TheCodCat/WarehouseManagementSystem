using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagementSystem.AL.Dtos
{
	public class PartyDto
	{
		[ForeignKey("ProductID")] public ProductDto Product { get; set; }
		public int ProductID { get; set; }
		public int Count { get; set; }
	}
}
