
using CarListingApp.MAUI.UI.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CarListingApp.MAUI.UI.Services;

public class CarApiService
{
    private HttpClient _httpClient;
    public static string BaseAddress;
    public string statusMessage;

    public CarApiService()
    {
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://172.20.0.1:45554" : "https://mpactfire.mpact.net:45554";
        _httpClient = new(clientHandler) { BaseAddress = new Uri(BaseAddress) };
    }

    public async Task<List<Car>> GetCarsAsync()
    {
        try
        {
            var hst = Uri.CheckHostName(BaseAddress);
            var reponse = await _httpClient.GetAsync("/cars");
            reponse.EnsureSuccessStatusCode();

            var data = await reponse.Content.ReadAsStringAsync();
            var cars = JsonConvert.DeserializeObject<List<Car>>(data);
            return cars;
        }
        catch (Exception ex)
        {
            statusMessage = "Failed to retrieve data.";
            return null;
        }
    }

    public async Task<Car> GetCarAsync(int id)
    {
        try
        {
            var reponse = await _httpClient.GetStringAsync("/cars/" + id);
            var cars = JsonConvert.DeserializeObject<Car>(reponse);
            return cars;
        }
        catch (Exception)
        {
            statusMessage = "Failed to retrieve data.";
            return null;
        }
    }

    public async Task AddCarAsync(Car car)
    {
        try
        {
            var reponse = await _httpClient.PostAsJsonAsync("/cars/", car);
            reponse.EnsureSuccessStatusCode();

            statusMessage = "Successfully added " + car.Model + " " + car.Make;
        }
        catch (Exception)
        {
            statusMessage = "Failed to add car.";
        }
    }

    public async Task UpdateCarAsync(Car car)
    {
        try
        {
            var reponse = await _httpClient.PutAsJsonAsync("/cars/" + car.Id, car);
            reponse.EnsureSuccessStatusCode();

            statusMessage = "Successfully updated car";
        }
        catch (Exception)
        {
            statusMessage = "Failed to update car.";
        }
    }

    public async Task DeleteCarAsync(int id)
    {
        try
        {
            var reponse = await _httpClient.DeleteAsync("/cars/" + id);
            reponse.EnsureSuccessStatusCode();

            statusMessage = "Successfully deleted car";
        }
        catch (Exception)
        {
            statusMessage = "Failed to deleted car.";
        }
    }
}
