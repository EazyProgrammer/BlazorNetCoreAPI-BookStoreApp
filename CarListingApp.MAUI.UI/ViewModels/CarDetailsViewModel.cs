
using CarListingApp.MAUI.UI.Models;
using CarListingApp.MAUI.UI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Web;

namespace CarListingApp.MAUI.UI.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    Car car;

    [ObservableProperty]
    int id;

    NetworkAccess accessType = Connectivity.Current.NetworkAccess;

    private readonly CarApiService _apiService;
    private readonly CarDatabaseService _databaseService;

    public CarDetailsViewModel(CarApiService carApiService, CarDatabaseService databaseService)
    {
        _apiService = carApiService;
        _databaseService = databaseService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Id = Convert.ToInt32(HttpUtility.UrlDecode(query[nameof(Id)].ToString()));
        Car = App._carService.GetCar(Id);
    }

    [RelayCommand]
    public async Task GetCar()
    {
        if (accessType == NetworkAccess.Internet) Car = await _apiService.GetCarAsync(Id);
        else Car = _databaseService.GetCar(Id);
    }
}
