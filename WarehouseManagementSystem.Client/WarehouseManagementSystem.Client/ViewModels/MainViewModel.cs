using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using System.Text.RegularExpressions;
using WarehouseManagementSystem.Client.Models;
using WarehouseManagementSystemServer;
using FastCloner;
using WarehouseManagementSystem.Client.Pages;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly Shipment.ShipmentClient shipmentClient;
        private readonly Productor.ProductorClient productorClient;
        private readonly IServiceProvider services;

        [ObservableProperty]
        private List<ProductMaui> productMaui = new List<ProductMaui>();

        [ObservableProperty]
        private string selectedSearch;

        [ObservableProperty]
        private bool isRequest;

        public MainViewModel(Shipment.ShipmentClient shipmentClient, Productor.ProductorClient productorClient, IServiceProvider serviceCollection)
        {
            this.shipmentClient = shipmentClient;
            this.productorClient = productorClient;
            services = serviceCollection;
        }

        public async void GetAllProduct()
        {
            try
            {
                IsRequest = true;
                var result = await productorClient.GetAllProductAsync(new Google.Protobuf.WellKnownTypes.Empty());
                ProductMaui = result.Products.Adapt<List<ProductMaui>>();
            }
            catch
            {
                ProductMaui = new List<ProductMaui>();
            }
            finally
            {
                IsRequest = false;
            }
        }

        [RelayCommand]
        public async void AddShipment()
        {
            try
            {
                var mainPage = services.GetRequiredService<MainPage>();

                var alertResult = await mainPage.DisplayAlertAsync("Подтвердите действие","Полученны все товары?", "Да", "Нет");

                if (!alertResult) return;

                IsRequest = true;
                var request = new ShipmentRequest();
                request.Partys.AddRange(ShipmentBoardDtos.Adapt<List<Party>>());

                var result = await shipmentClient.SetShipmentAsync(request);

                mainPage.Navigation.PushModalAsync(new ProductAndCellPage(services.GetRequiredService<ProductAndCellViewModel>()));
                services.GetRequiredService<ProductAndCellViewModel>().ShipmentResponce = result;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                IsRequest = false;
            }
        }

        partial void OnSelectedSearchChanging(string? oldValue, string newValue)
     {
            if (string.IsNullOrEmpty(newValue)) return;

            Regex regex = new Regex(@"^(\d+)\\(.+?)\\(.+)$");
            var result = regex.Match(newValue);
            var id = result.Groups[1].Value;

            int.TryParse(id, out int intId);
            var anyProduct = ShipmentBoardDtos.FirstOrDefault(x => x.Id == intId);
            if (anyProduct != null)
            {
                var clone = FastCloner.FastCloner.DeepClone(anyProduct);
                clone.Count += 1;
                var index = ShipmentBoardDtos.IndexOf(anyProduct);
                ShipmentBoardDtos[index] = clone;
            }
            else
            {
                var product = ProductMaui.FirstOrDefault(x => x.Id == intId).Adapt<ShipmentBoardDto>();
                product.Count = 1;

                ShipmentBoardDtos.Add(product);
            }

            SelectedSearch = string.Empty;
        }
    }
}
