using Grpc.Net.Client;
using WarehouseManagementSystem.Client.ViewModels;
using WarehouseManagementSystemServer;

namespace WarehouseManagementSystem.Client.Pages
{
    public partial class MainPage : ContentPage
    {
        MainViewModel mainViewModel;
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
            this.mainViewModel = mainViewModel;
        }

        protected override void OnAppearing()
        {
            mainViewModel.GetAllProduct();
        }
    }

}
