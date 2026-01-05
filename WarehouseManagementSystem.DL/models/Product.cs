using System.ComponentModel.DataAnnotations;

namespace WarehouseManagementSystem.DL.models
{
	public record class Product
	{
		[Key] public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
