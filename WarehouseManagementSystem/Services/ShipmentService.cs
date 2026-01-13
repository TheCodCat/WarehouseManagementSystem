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
			var requestAdapt = request.Adapt<ShipmentDto>();
			requestAdapt.DateTime = DateTime.UtcNow;

            shipmentServiceAL.AddShipment(requestAdapt);
			var shipmentParty = await shipmentServiceAL.GetShipment(requestAdapt.DateTime);

			var responce = new ShipmentResponce();
			responce.Responce.AddRange(shipmentParty.Adapt<List<PartyResponce>>());

			return responce;
		}
	}
}
