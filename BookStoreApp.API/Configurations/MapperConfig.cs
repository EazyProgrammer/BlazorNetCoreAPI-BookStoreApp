using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();

            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();

            CreateMap<BookReadOnlyDto, Book>();
            CreateMap<Book, BookReadOnlyDto>()
                .ForMember(b => b.AuthorName, a => a.MapFrom(map => map.Author != null ? $"{map.Author.FirstName} {map.Author.LastName}" : ""));
        }
    }
}
