namespace BookStoreApp.BusinessLogic.Models.Books
{
    public class BookReadOnlyDto : BookDetailsDto
    {
        public string AuthorName { get; set; } = string.Empty;
    }
}
