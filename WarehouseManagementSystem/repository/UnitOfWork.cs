using WarehouseManagementSystem.DL.interfaces;

namespace WarehouseManagementSystem.PL.repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public IShipmentRepository ShipmentRepository { get; set; }

		public UnitOfWork(IShipmentRepository shipmentRepository)
		{
			ShipmentRepository = shipmentRepository;
		}
	}
}
