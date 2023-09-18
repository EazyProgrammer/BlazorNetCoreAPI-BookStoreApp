using CarListingApp.MAUI.UI.ViewModels;

namespace CarListingApp.MAUI.UI.Views;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage(CarDetailsViewModel carDetailsViewModel)
	{
		InitializeComponent();

		BindingContext = carDetailsViewModel;
    }
}