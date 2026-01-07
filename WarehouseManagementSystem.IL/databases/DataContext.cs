using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.DL.models;

namespace WarehouseManagementSystem.IL.databases
{
	public class DataContext : DbContext
	{
		public DbSet<Product> products { get; set; }
		public DbSet<Party> parties { get; set; }
		public DbSet<Shipment> shipments { get; set; }
		public DbSet<CellStorage> cellStorages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source = data.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Shipment>()
				.HasMany(x => x.PartyList);

			//modelBuilder.Entity<Party>()
			//	.HasOne(x => x.CellStorage)
			//	.WithOne(x => x.Party)
			//	.IsRequired(false);
		}
	}
}
