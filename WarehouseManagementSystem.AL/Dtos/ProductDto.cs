using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementSystem.AL.Dtos
{
	public record class ProductDto
	{
		[Key] public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
