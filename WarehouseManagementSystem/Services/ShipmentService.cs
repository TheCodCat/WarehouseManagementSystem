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
			var time = DateTime.UtcNow;
			shipmentServiceAL.AddShipment(time,request.Adapt<ShipmentDto>());
			var shipmentParty = await shipmentServiceAL.GetShipment(time);

			var responce = new ShipmentResponce();
			responce.Responce.AddRange(shipmentParty.Adapt<List<PartyResponce>>());

			return responce;
		}
	}
}
