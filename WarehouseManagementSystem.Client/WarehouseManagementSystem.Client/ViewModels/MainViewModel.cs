using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WarehouseManagementSystem.Client.Models;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly Shipment.ShipmentClient shipmentClient;
        private readonly Productor.ProductorClient productorClient;

        [ObservableProperty]
        private IList<ProductMaui> productMaui;

        public MainViewModel(Shipment.ShipmentClient shipmentClient, Productor.ProductorClient productorClient)
        {
            this.shipmentClient = shipmentClient;
            this.productorClient = productorClient;
        }

        public async void GetAllProduct()
        {
            var result = await productorClient.GetAllProductAsync(new Google.Protobuf.WellKnownTypes.Empty());
            ProductMaui = new List<ProductMaui>(result.Products.Adapt<ProductMaui[]>());
        }

        [RelayCommand]
        public async void AddShipment()
        {
            //var result = await shipmentClient.SetShipmentAsync(new ShipmentRequest()
            //{
            //    Partys =
            //    {
            //        new Party(){ Count = 1, Product = new Product(){ Name = "asdasd", Id = 0, Description = "asdasd" }
            //    }
            //}});
        }
    }
}
