using WarehouseManagementSystemClient.ViewModels;

namespace WarehouseManagementSystemClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
