namespace BookStoreApp.BusinessLogic.Models
{
    public class VirtualizeResponse<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalSize { get; set; }
    }
}
