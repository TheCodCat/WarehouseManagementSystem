using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly Shipment.ShipmentClient shipmentClient;

        public MainViewModel(Shipment.ShipmentClient shipmentClient)
        {
            this.shipmentClient = shipmentClient;
        }
    }
}
