using CommunityToolkit.Mvvm.ComponentModel;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystemClient.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly Shipment.ShipmentClient _client;
        public MainViewModel()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5103");
            _client = new Shipment.ShipmentClient(channel);

            //Task.Run(() => TestCheck());
        }

        public async void TestCheck()
        {
            var result = await _client.SetShipmentAsync(new ShipmentRequest()
            {
                Partys =
                {
                    new Party(){ Product = new Product(){ Id = 0, Name = "asdasd", Description = "asdwrw" }, Count = 1 }
                }
            });
        }
    }
}
