using Mapster;
using WarehouseManagementSystem.AL.Dtos;
using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.AL.services
{
	public class ShipmentServiceAL
	{
		private readonly IUnitOfWork unitOfWork;

		public ShipmentServiceAL(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public void AddShipment(ShipmentDto request)
		{
			unitOfWork.ShipmentRepository.AddShipment(DateTime.UtcNow, request.Partys.Adapt<Party[]>());
		}
	}
}
