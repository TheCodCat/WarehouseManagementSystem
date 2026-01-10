using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.DL.interfaces
{
	public interface IShipmentRepository
	{
		public Task AddShipment(DateTime dateTime, params Party[] parties);
		public Task<ShipmentParty[]> GetShipment(DateTime dateTime);
	}
}
