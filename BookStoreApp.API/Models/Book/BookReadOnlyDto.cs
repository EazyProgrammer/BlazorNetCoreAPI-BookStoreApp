namespace BookStoreApp.API.Models.Book
{
    public class BookReadOnlyDto : BookDetailsDto
    {
        public string AuthorName { get; set; } = "";
    }
}
