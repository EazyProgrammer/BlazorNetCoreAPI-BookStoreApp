using CarListingApp.MAUI.UI.ViewModels;

namespace CarListingApp.MAUI.UI.Views;

public partial class CarDetailsPage : ContentPage
{
    private readonly CarDetailsViewModel _carDetailsViewModel;
	public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
	{
		InitializeComponent();

		BindingContext = carDetailsViewModel;
        _carDetailsViewModel = carDetailsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _carDetailsViewModel.GetCar();
    }
}