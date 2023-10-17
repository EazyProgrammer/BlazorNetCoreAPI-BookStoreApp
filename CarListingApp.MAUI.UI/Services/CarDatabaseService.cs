
using CarListingApp.MAUI.UI.Models;
using SQLite;

namespace CarListingApp.MAUI.UI.Services;

public class CarDatabaseService
{
    int result = 0;
    private SQLiteConnection con;
    private string _dbPath;

    public string statusMessage;

    public CarDatabaseService(string dbPath)
    {
        _dbPath = dbPath;
    }

    private void Init()
    {
        if (con != null) return;

        con = new SQLiteConnection(_dbPath);
        con.CreateTable<Car>();
    }

    public List<Car> GetCars()
    {
        try
        {
            Init();

            return con.Table<Car>().ToList();
        }
        catch (Exception)
        {
            statusMessage = "Failed to retrieve data.";
            return new();
        }
    }

    public Car GetCar(int id)
    {
        try
        {
            Init();

            return con.Table<Car>().Where(c => c.Id == id).FirstOrDefault();
        }
        catch (Exception)
        {
            statusMessage = "Failed to retrieve data.";
            return new();
        }
    }

    public void AddCar(Car car)
    {
        try
        {
            Init();

            if (car == null) throw new Exception("Invalid car details");

            result = con.Insert(car);
            statusMessage = result == 0 ? "Failed to create new car" : "Successfully created new car";
        }
        catch (Exception)
        {
            statusMessage = "Failed to create new car.";
        }
    }

    public void UpdateCar(Car car)
    {
        try
        {
            Init();

            if (car == null) throw new Exception("Invalid car details");

            result = con.Update(car);
            statusMessage = result == 0 ? "Failed to update new car" : "Successfully updated new car";
        }
        catch (Exception)
        {
            statusMessage = "Failed to update new car.";
        }
    }

    public void DeleteCar(int id)
    {
        try
        {
            Init();

            var car = con.Table<Car>().Where(c => c.Id == id).FirstOrDefault();

            if (car == null) throw new Exception("Invalid car details");

            result = con.Delete(car);
            statusMessage = result == 0 ? "Failed to delete new car" : "Successfully deleted car";
        }
        catch (Exception)
        {
            statusMessage = "Failed to delete new car.";
        }
    }
}
