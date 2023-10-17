using Microsoft.EntityFrameworkCore;

namespace CarListingApp.API.Data;

public class CarListDBContext : DbContext
{
    public CarListDBContext(DbContextOptions<CarListDBContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var cars = new List<Car>();

        for (int i = 1; i < 101; i++)
            cars.Add(new Car { Id = i, Make = $"Make {i}", Model = $"Model {i}", Vin = Guid.NewGuid().ToString().ToUpper() });

        modelBuilder.Entity<Car>().HasData(cars);
    }
}
