using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WarehouseManagementSystem.Client.Models;
using WarehouseManagementSystem.Client.Pages;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class ProductAndCellViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;

        [ObservableProperty]
        private ShipmentResponce shipmentResponce;

        public ProductAndCellViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [RelayCommand]
        public async void PopModalNext()
        {
            var page = _serviceProvider.GetRequiredService<ProductAndCellPage>();
            await page?.Navigation.PopAsync();
        }
    }
}
