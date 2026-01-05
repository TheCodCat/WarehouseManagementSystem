namespace WarehouseManagementSystem.DL.interfaces
{
	public interface IUnitOfWork
	{
		public IShipmentRepository ShipmentRepository { get; set; }
	}
}
