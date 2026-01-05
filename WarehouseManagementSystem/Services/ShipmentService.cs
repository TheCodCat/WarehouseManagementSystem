using Grpc.Core;
using Mapster;
using WarehouseManagementSystem.AL.Dtos;
using WarehouseManagementSystem.AL.services;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.PL.Services
{
	public class ShipmentService : Shipment.ShipmentBase
	{
		private readonly ShipmentServiceAL shipmentServiceAL;

		public ShipmentService(ShipmentServiceAL shipmentServiceAL)
		{
			this.shipmentServiceAL = shipmentServiceAL;
		}
		public override async Task<ShipmentResponce> SetShipment(ShipmentRequest request, ServerCallContext context)
		{
			shipmentServiceAL.AddShipment(request.Adapt<ShipmentDto>());

			return new ShipmentResponce();
		}
	}
}
