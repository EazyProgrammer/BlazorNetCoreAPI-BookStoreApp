using BookStoreApp.BusinessLogic.Authorization;
using BookStoreApp.BusinessLogic.Authors;
using BookStoreApp.BusinessLogic.Configurations;
using BookStoreApp.BusinessLogic.Helpers;
using BookStoreApp.BusinessLogic.Models.Authors;
using BookStoreApp.BusinessLogic.Models.Books;
using BookStoreApp.Repository;
using BookStoreApp.Repository.AuthorRepo;
using BookStoreApp.Repository.BookRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BookStoreAppConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddBookStoreConfigurations(
             this IServiceCollection services, string connString)
        {
            services.AddDbContext<BookStoreDBContext>(options => options.UseSqlServer(connString));

            services
                .AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BookStoreDBContext>();

            services.AddAutoMapper(typeof(MapperConfig));

            return services;
        }

        public static IServiceCollection AddBookStoreServices(
             this IServiceCollection services)
        {
            //BL layer
            services.AddScoped<IAuthorizationBusinessLogic, AuthorizationBusinessLogic>();
            services.AddScoped<IAuthorBusinessLogic, AuthorBusinessLogic>();
            services.AddScoped<IBookBusinessLogic, BookBusinessLogic>();

            //Repo layer
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            //helpers
            services.AddScoped<IFileHelper, FileHelper>();

            return services;
        }
    }
}
