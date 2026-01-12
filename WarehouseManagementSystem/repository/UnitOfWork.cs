using WarehouseManagementSystem.DL.interfaces;

namespace WarehouseManagementSystem.PL.repository
{
	public class UnitOfWork : IUnitOfWork
	{
		public IShipmentRepository ShipmentRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public UnitOfWork(IShipmentRepository shipmentRepository, IProductRepository productRepository)
		{
			ShipmentRepository = shipmentRepository;
			ProductRepository = productRepository;
		}
	}
}
