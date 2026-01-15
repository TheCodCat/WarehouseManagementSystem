using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.RegularExpressions;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.ViewModels
{
    public partial class PartyViewViewModel : ObservableObject
    {
        private readonly Productor.ProductorClient _client;

        private ShipmentResponce shipmentResponce;

        [ObservableProperty]
        private ShipmentResponce partyViews;

        [ObservableProperty]
        private string selectionFillter;

        public PartyViewViewModel(Productor.ProductorClient productorClient)
        {
            _client = productorClient;
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
        }
    }
}
