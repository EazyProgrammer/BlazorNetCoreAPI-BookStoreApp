
using CarListingApp.MAUI.UI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListingApp.MAUI.UI.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class CarDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Car car;

    public CarDetailsViewModel()
    {
        Title = $"Car Details - {car.Make} {car.Model}";
    }
}
