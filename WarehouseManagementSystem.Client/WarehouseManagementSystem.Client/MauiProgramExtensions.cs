using InputKit.Handlers;
using Mapster;
using Microsoft.Extensions.Logging;
using UraniumUI;
using WarehouseManagementSystem.Client.Models;
using WarehouseManagementSystem.Client.Pages;
using WarehouseManagementSystem.Client.Services;
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
                    fonts.AddFontAwesomeIconFonts();
                });

            builder.UseMauiApp<App>()
                .ConfigureMauiHandlers(handles => 
                {
                    handles.AddInputKitHandlers();
            });
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddScoped<PartyPage>();
            builder.Services.AddScoped<PartyViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ProductAndCellPage>();
            builder.Services.AddScoped<MainViewModel>();
            builder.Services.AddScoped<ProductAndCellViewModel>();
            builder.Services.AddScoped<PartyViewViewModel>();

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

            TypeAdapterConfig<ShipmentBoardDto, Party>
                .NewConfig()
                .ConstructUsing(src => new Party()
                {
                     Count = src.Count,
                     Product = new Product()
                     {
                          Id = src.Id,
                          Description = src.Description,
                          Name = src.Title
                     }
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder;
        }
    }
}
