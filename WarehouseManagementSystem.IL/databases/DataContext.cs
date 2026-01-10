using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
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
			modelBuilder.ApplyConfiguration(new ShipmentConfigure());
			modelBuilder.ApplyConfiguration(new CellCpnfigure());
		}

	}
	public class ShipmentConfigure : IEntityTypeConfiguration<Shipment>
	{
		void IEntityTypeConfiguration<Shipment>.Configure(EntityTypeBuilder<Shipment> builder)
		{
			builder
				.HasMany(x => x.PartyList);
		}
	}

	public class CellCpnfigure : IEntityTypeConfiguration<CellStorage>
	{
		public void Configure(EntityTypeBuilder<CellStorage> builder)
		{
			builder.HasKey(x => x.Id);
		}
	}

	public class PartyConfigure : IEntityTypeConfiguration<Party>
	{
		public void Configure(EntityTypeBuilder<Party> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Product).WithOne().IsRequired(false);
		}
	}
}
