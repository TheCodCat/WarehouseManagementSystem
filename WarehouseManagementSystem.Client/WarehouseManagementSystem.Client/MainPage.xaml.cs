using Grpc.Net.Client;
using WarehouseManagementSystem.Client.ViewModels;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Shipment.ShipmentClient shipmentClient)
        {
            InitializeComponent();
            BindingContext = new MainViewModel(shipmentClient);
        }
    }

}
