using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text.RegularExpressions;
using WarehouseManagementSystem.Client.Pages;
using WarehouseManagementSystem.Client.Services;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class PartyViewViewModel : ObservableObject
    {
        private readonly Productor.ProductorClient _client;
        private readonly IServiceProvider serviceProvider;

        private ShipmentResponce shipmentResponce;

        [ObservableProperty]
        private ShipmentResponce partyViews;

        [ObservableProperty]
        private string selectionFillter;

        public PartyViewViewModel(Productor.ProductorClient productorClient, IServiceProvider serviceProvider)
        {
            _client = productorClient;
            this.serviceProvider = serviceProvider;
        }

        public async Task GetAllParty()
        {
            try
            {
                shipmentResponce = await _client.GetPartiesToCellAsync(new Google.Protobuf.WellKnownTypes.Empty());
                PartyViews = FastCloner.FastCloner.DeepClone(shipmentResponce);
            }
            catch (Exception ex)
            {
                PartyViews = new ShipmentResponce();
            }
        }

        partial void OnSelectionFillterChanging(string? oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(newValue))
            {
                var clone = FastCloner.FastCloner.DeepClone(shipmentResponce);
                PartyViews = clone;

            }

            var regexCell = new Regex(@"^[aA-zZ]\d{0,}");
            var regexIndex = new Regex(@"^[0-9]{1,}");

            var resultCell = regexCell.IsMatch(newValue);
            var resultIndex = regexIndex.IsMatch(newValue);

            if (resultCell)
            {
                var clone = new ShipmentResponce();
                clone.Responce.AddRange(shipmentResponce.Responce.Where(x => x.CellTitle.Contains(newValue, StringComparison.CurrentCultureIgnoreCase)));

                PartyViews = clone;
            }
            else if (resultIndex)
            {
                var clone = new ShipmentResponce();
                int.TryParse(newValue, out int resultInt);
                clone.Responce.AddRange(shipmentResponce.Responce.Where(x => x.Id == resultInt));

                PartyViews = clone;
            }
        }

        [RelayCommand]
        private async void OverviewParty(PartyResponce partyResponce)
        {
            var nav = serviceProvider.GetRequiredService<INavigationService>();
            var vm = serviceProvider.GetRequiredService<PartyViewModel>();
            nav?.PushAsync(new PartyPage(vm));
            vm.PartyResponce = partyResponce;
        }
    }
}
