using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WarehouseManagementSystem.DL.models
{
	public class CellStorage
	{
		[Key] public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
	}
}
