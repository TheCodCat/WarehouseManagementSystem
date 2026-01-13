using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class ProductAndCellViewModel : ObservableObject
    {
        [ObservableProperty]
        private ShipmentResponce shipmentResponce;

        partial void OnShipmentResponceChanging(ShipmentResponce? oldValue, ShipmentResponce newValue)
        {
        }
    }
}
