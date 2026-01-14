using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseManagementSystem.Client.Models;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class ProductAndCellViewModel : ObservableObject
    {
        [ObservableProperty]
        private ShipmentResponce shipmentResponce;
    }
}
