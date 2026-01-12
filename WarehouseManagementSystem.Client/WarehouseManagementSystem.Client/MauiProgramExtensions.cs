using Microsoft.Extensions.Logging;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddGrpcClient<Shipment.ShipmentClient>(o =>
            {
                o.Address = new Uri("http://localhost:5103");
            });
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder;
        }
    }
}
