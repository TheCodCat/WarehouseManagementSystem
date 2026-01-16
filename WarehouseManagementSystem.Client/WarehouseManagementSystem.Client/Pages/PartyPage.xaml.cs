using WarehouseManagementSystem.Client.ViewModels;

namespace WarehouseManagementSystem.Client.Pages;

public partial class PartyPage : ContentPage
{
	public PartyPage(PartyViewModel partyViewModel)
	{
		InitializeComponent();
		BindingContext = partyViewModel;
	}
}