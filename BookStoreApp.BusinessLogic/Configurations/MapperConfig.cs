using AutoMapper;
using BookStoreApp.BusinessLogic.Models.Authors;
using BookStoreApp.BusinessLogic.Models.Books;
using BookStoreApp.BusinessLogic.Models.Users;
using BookStoreApp.Repository;

namespace BookStoreApp.BusinessLogic.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
            CreateMap<UserLoginDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserDetailsDto, ApplicationUser>().ReverseMap();

            CreateMap<AuthorBooksDto, Author>().ReverseMap();
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();

            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookDetailsDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();

            CreateMap<BookReadOnlyDto, Book>();
            CreateMap<Book, BookReadOnlyDto>()
                .ForMember(b => b.AuthorName, a => a.MapFrom(map => map.Author != null ? $"{map.Author.FirstName} {map.Author.LastName}" : ""));
        }
    }
}
