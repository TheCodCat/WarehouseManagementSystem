using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.DL.interfaces;
using WarehouseManagementSystem.DL.models;
using WarehouseManagementSystem.IL.databases;
using WarehouseManagementSystem.PL.models;

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

			var cells = dataContext.cellStorages
				.Select(x => new CellCount() { CellStorage = x, Count = 0 }).ToArray();

			var cellsParty = dataContext.parties.GroupBy(x => x.CellStorage)
				.Select(x => new CellCount() { CellStorage = x.Key, Count = x.Count() });

			foreach (var item in cellsParty)
			{
				var cell = cells.FirstOrDefault(x => x.CellStorage == item.CellStorage);
				cell.Count = item.Count;
			}

			foreach (var party in parties)
			{
				var cell = cells.Where(x => x.Count == cells.Min(x => x.Count)).FirstOrDefault();
				party.CellStorage = cell.CellStorage;
				cell.Count++;

				dataContext.parties.Add(party);
				dataContext.products.Add(party.Product);
			}

			dataContext.shipments.Add(shipment);
			dataContext.SaveChanges();
		}
	}
}
