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

			var listcell = dataContext.cellStorages.Where(x => x.Party == null).ToList();
			for (int i = 0; i < parties.Length; i++)
			{
				dataContext.parties.Add(parties[i]);

				var cell = listcell.FirstOrDefault();
				if (cell is not null)
				{
					cell.Party = parties[i];
					listcell.Remove(cell);
				}
				else
				{
					//какаято логика
				}

				dataContext.products.Add(parties[i].Product);
			}
			dataContext.shipments.Add(shipment);
			dataContext.SaveChanges();
		}
	}
}
