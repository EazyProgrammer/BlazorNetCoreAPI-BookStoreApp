
using SQLite;

namespace CarListingApp.MAUI.UI.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
