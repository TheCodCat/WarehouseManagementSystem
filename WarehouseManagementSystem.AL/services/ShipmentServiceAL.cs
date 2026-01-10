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

		public async void AddShipment(DateTime dateTime,ShipmentDto request)
		{
			unitOfWork.ShipmentRepository.AddShipment(dateTime, request.Partys.Adapt<Party[]>());
		}

		public async Task<ShipmentParty[]> GetShipment(DateTime dateTime)
		{
			return await unitOfWork.ShipmentRepository.GetShipment(dateTime);
		}
	}
}
