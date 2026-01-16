using WarehouseManagementSystem.Client.ViewModels;

namespace WarehouseManagementSystem.Client.Pages;

public partial class ProductAndCellPage : ContentPage
{
    public ProductAndCellPage(ProductAndCellViewModel productAndCellViewModel)
    {
        InitializeComponent();
        BindingContext = productAndCellViewModel;
    }

    public ProductAndCellViewModel ProductAndCellViewModel
    {
        get => default;
        set
        {
        }
    }
}