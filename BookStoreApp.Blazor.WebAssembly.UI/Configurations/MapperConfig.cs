using AutoMapper;
using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;

namespace BookStoreApp.Blazor.WebAssembly.UI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorReadOnlyDto, AuthorUpdateDto>().ReverseMap(); 
            CreateMap<AuthorBooksDto, AuthorUpdateDto>().ReverseMap(); 

            CreateMap<BookReadOnlyDto, BookUpdateDto>().ReverseMap(); 
        }
    }
}
