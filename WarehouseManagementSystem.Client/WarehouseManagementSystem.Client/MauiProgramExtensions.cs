using Mapster;
using Microsoft.Extensions.Logging;
using UraniumUI;
using WarehouseManagementSystem.Client.Models;
using WarehouseManagementSystem.Client.ViewModels;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddMaterialSymbolsFonts();
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddGrpcClient<Shipment.ShipmentClient>(o =>
            {
                o.Address = new Uri("http://localhost:5103");
            });

            builder.Services.AddGrpcClient<Productor.ProductorClient>(o =>
            {
                o.Address = new Uri("http://localhost:5103");
            });

            TypeAdapterConfig<ProductMaui, Product>
            .NewConfig()
            .ConstructUsing(srs => new Product()
            {
                Id = srs.Id,
                Name = srs.Name,
                Description = srs.Description
            });

            TypeAdapterConfig<ProductMaui, ShipmentBoardDto>
                .NewConfig()
                .ConstructUsing(src => new ShipmentBoardDto()
                {
                    Id = src.Id,
                    Title = src.Name,
                    Description = src.Description
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder;
        }
    }
}
