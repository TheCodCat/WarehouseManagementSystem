using CommunityToolkit.Mvvm.ComponentModel;
using Grpc.Net.Client;

namespace WarehouseManagementSystemClient.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly Shiment.ShipmentClient _client;
        public MainViewModel()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5103");
            _client = new WarehouseManagementSystem_Client.Shipment.ShipmentClient(channel);

            //Task.Run(() => TestCheck());
        }

        public async void TestCheck()
        {
            var result = await _client.SetShipmentAsync(new WarehouseManagementSystem_Client.ShipmentRequest()
            {
                Partys =
                {
                    new WarehouseManagementSystem_Client.Party(){ Product = new WarehouseManagementSystem_Client.Product(){ Id = 0, Name = "asdasd", Description = "asdwrw" }, Count = 1 }
                }
            });
        }
    }
}
