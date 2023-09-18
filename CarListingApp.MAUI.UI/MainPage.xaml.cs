using CarListingApp.MAUI.UI.ViewModels;

namespace CarListingApp.MAUI.UI;

public partial class MainPage : ContentPage
{
    public MainPage(CarListViewModel carListViewModel)
    {
        InitializeComponent();

        BindingContext = carListViewModel;
    }

    
}