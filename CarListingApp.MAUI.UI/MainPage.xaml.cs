using CarListingApp.MAUI.UI.ViewModels;

namespace CarListingApp.MAUI.UI;

public partial class MainPage : ContentPage
{
    private readonly CarListViewModel _carListViewModel;

    public MainPage(CarListViewModel carListViewModel)
    {
        InitializeComponent();

        BindingContext = carListViewModel;
        _carListViewModel = carListViewModel;

        //Preferences.Set("saveDetails", true);
        //var detailsSaved = Preferences.Get("saveDetails", false);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _carListViewModel.GetCarList();
    }
}