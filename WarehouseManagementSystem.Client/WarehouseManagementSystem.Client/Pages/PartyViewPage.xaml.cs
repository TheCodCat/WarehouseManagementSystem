using UraniumUI.Pages;
using WarehouseManagementSystem.Client.ViewModels;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.Pages 
{ 
	public partial class PartyViewPage : UraniumContentPage
	{
		private readonly PartyViewViewModel vm;
		public PartyViewPage(PartyViewViewModel partyViewViewModel)
		{
			InitializeComponent();
			vm = partyViewViewModel;
			BindingContext = vm;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			vm.GetAllParty().GetAwaiter();
        }
	}
}