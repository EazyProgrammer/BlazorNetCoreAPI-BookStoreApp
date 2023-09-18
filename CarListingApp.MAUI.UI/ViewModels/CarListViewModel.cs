
using CarListingApp.MAUI.UI.Models;
using CarListingApp.MAUI.UI.Services;
using CarListingApp.MAUI.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace CarListingApp.MAUI.UI.ViewModels;

public partial class CarListViewModel : BaseViewModel
{
    private readonly CarService _carService;
    public ObservableCollection<Car> Cars { get; private set; } = new();

    [ObservableProperty]
    private bool isRefreshing;

    public CarListViewModel(CarService carService)
    {
        Title = "Car Listings";
        _carService = carService;
    }

    [RelayCommand]
    public async Task GetCarList()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;

            if (Cars.Any()) Cars.Clear();

            var cars = _carService.GetCars();

            foreach (var car in cars) Cars.Add(car);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get cars:  {ex.Message}");
            await Shell.Current.DisplayAlert("Error", "Failed to retrieve list of cars.", "Ok");

            throw;
        }
        finally
        {
            IsLoading = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task GetCarDetails(Car car)
    {
        if (car == null) return;

        await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>
        {
            {nameof(Car), car}
        });
    }
}
