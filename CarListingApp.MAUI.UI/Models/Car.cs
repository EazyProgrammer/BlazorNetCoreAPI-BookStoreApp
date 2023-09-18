
namespace CarListingApp.MAUI.UI.Models;

public class Car : BaseEntity
{
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Vin { get; set; } = string.Empty;
}
