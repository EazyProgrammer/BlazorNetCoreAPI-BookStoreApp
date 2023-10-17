
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
    [ObservableProperty]
    private bool editMode = false;

    [ObservableProperty]
    private bool addMode = true;

    [ObservableProperty]
    private bool isRefreshing;

    [ObservableProperty]
    private int carId;

    [ObservableProperty]
    private string make;

    [ObservableProperty]
    private string model;

    [ObservableProperty]
    private string vin;

    public ObservableCollection<Car> Cars { get; private set; } = new();

    private readonly CarApiService _apiService;
    private readonly CarDatabaseService _databaseService;

    NetworkAccess accessType = Connectivity.Current.NetworkAccess;
    string message = string.Empty;

    public CarListViewModel(CarApiService apiService, CarDatabaseService databaseService)
    {
        _apiService = apiService;
        Title = "Car Listings";
        //GetCarList().Wait();
    }

    [RelayCommand]
    public async Task GetCarList()
    {
        if (IsLoading) return;

        try
        {
            var cars = new List<Car>();
            IsLoading = true;

            if (Cars.Any()) Cars.Clear();

            if (accessType == NetworkAccess.Internet) cars = await _apiService.GetCarsAsync();
            else cars = _databaseService.GetCars();

            if (cars == null)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to retrieve list of cars.", "Ok");
                return;
            }

            foreach (var car in cars) Cars.Add(car);

            //string fileName = "carList.json";
            //var serializedList = JsonSerializer.Serialize(cars);
            //File.WriteAllText(fileName, serializedList);

            //var rawText = File.ReadAllText(fileName);
            //var carsFromText = JsonSerializer.Deserialize<List<Car>>(rawText);

            //var path = FileSystem.AppDataDirectory;
            //string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
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
    public async Task GetCarDetails(int id)
    {
        if (id == 0) return;

        await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
    }

    [RelayCommand]
    public async Task AddCar()
    {
        if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
        {
            await Shell.Current.DisplayAlert("Invalid Data", "Please  insert valid car details", "OK");
            return;
        }

        var car = new Car
        {
            Make = Make,
            Model = Model,
            Vin = Vin
        };

        if (accessType == NetworkAccess.Internet) await _apiService.AddCarAsync(car);
        else _databaseService.AddCar(car);

        if (_apiService.statusMessage.Contains("Success"))
        {
            Make = "";
            Model = "";
            Vin = "";
        }

        await Shell.Current.DisplayAlert("Info", _apiService.statusMessage, "OK");
        await GetCarList();
    }

    [RelayCommand]
    public async Task DeleteCar(int id)
    {
        if (id == 0)
        {
            await Shell.Current.DisplayAlert("Invalid car record", "Please refresh and try again", "OK");
            return;
        }

        if (accessType == NetworkAccess.Internet) await _apiService.DeleteCarAsync(id);
        else _databaseService.DeleteCar(id);

        await Shell.Current.DisplayAlert("Info", _apiService.statusMessage, "OK");
        await GetCarList();
    }

    [RelayCommand]
    public async Task EditCar(int id)
    {
        if (id == 0) await Shell.Current.DisplayAlert("Invalid car record", "Please refresh and try again", "OK");

        var car = new Car();

        if (accessType == NetworkAccess.Internet) await _apiService.GetCarAsync(id);
        else _databaseService.GetCar(id);

        if (car == null || car.Id <= 0) await Shell.Current.DisplayAlert("Invalid car record", "Please refresh and try again", "OK");

        EditMode = true;
        AddMode = false;

        CarId = car.Id;
        Make = car.Make;
        Model = car.Model;
        Vin = car.Vin;
    }

    [RelayCommand]
    public async Task UpdateCar()
    {
        if (CarId == 0)
        {
            await Shell.Current.DisplayAlert("Invalid car record", "Please refresh and try again", "OK");
            return;
        }

        var car = new Car
        {
            Id = CarId,
            Make = Make,
            Model = Model,
            Vin = Vin
        };

        if (accessType == NetworkAccess.Internet) await _apiService.UpdateCarAsync(car);
        else _databaseService.UpdateCar(car);

        if (_apiService.statusMessage.Contains("Success"))
        {
            EditMode = false;
            AddMode = true;

            Make = "";
            Model = "";
            Vin = "";
        }

        await Shell.Current.DisplayAlert("Info", _apiService.statusMessage, "OK");
        await GetCarList();
    }
}
