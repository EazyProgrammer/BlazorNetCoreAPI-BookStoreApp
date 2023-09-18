
using CarListingApp.MAUI.UI.Models;

namespace CarListingApp.MAUI.UI.Services;

public class CarService
{
    public List<Car> GetCars()
    {
        var cars = new List<Car>();

        for (int i = 1; i < 101; i++)
            cars.Add(new Car { Id = i, Make = $"Make {i}", Model = $"Model {i}", Vin = Guid.NewGuid().ToString().ToUpper() });

        return cars;
    }
}
