using CarListingApp.API.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var con = new SqliteConnection($"Data Source=C:\\CarListDb\\CarList.db");
//var con = new SqliteConnection($"Data Source={Path.Join(Directory.GetCurrentDirectory(), "CarList.db")}");
builder.Services.AddDbContext<CarListDBContext>(o => o.UseSqlite(con));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapGet("/cars", async (CarListDBContext db) =>
{
    var cars = await db.Cars.ToListAsync();
    return cars;
});

app.MapGet("/cars/{id}", async (int id, CarListDBContext db) => await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound());

app.MapPut("/cars/{id}", async (int id, Car car, CarListDBContext db) =>
{
    var record = await db.Cars.FindAsync(id);

    if (record == null) return Results.NotFound();

    record.Make = car.Make;
    record.Model = car.Model;
    record.Vin = car.Vin;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/cars/{id}", async (int id, CarListDBContext db) =>
{
    var record = await db.Cars.FindAsync(id);

    if (record == null) return Results.NotFound();

    db.Remove(record);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPost("/cars/", async (Car car, CarListDBContext db) =>
{
    await db.AddAsync(car);
    await db.SaveChangesAsync();

    return Results.Created($"/cars/{car.Id}", car);
});

app.Run();
