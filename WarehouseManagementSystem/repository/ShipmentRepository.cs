using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.DL.models;
using WarehouseManagementSystem.IL.databases;

namespace WarehouseManagementSystem.PL.repository
{
	public class ShipmentRepository : IShipmentRepository
	{
		private readonly DataContext dataContext;

		public ShipmentRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}
		public async Task AddShipment(DateTime dateTime, params Party[] parties)
		{
			Shipment shipment = new Shipment()
			{
				DateTime = dateTime,
				PartyList = parties
			};

			for (int i = 0; i < parties.Length; i++)
			{
				var item = dataContext.parties.Add(parties[i]);

				dataContext.products.Add(parties[i].Product);
			}
			dataContext.shipments.Add(shipment);
			dataContext.SaveChanges();
		}
	}
}
