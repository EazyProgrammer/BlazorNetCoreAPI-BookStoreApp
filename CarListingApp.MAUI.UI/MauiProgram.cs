using CarListingApp.MAUI.UI.Services;
using CarListingApp.MAUI.UI.ViewModels;
using CarListingApp.MAUI.UI.Views;
using Microsoft.Extensions.Logging;

namespace CarListingApp.MAUI.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<CarService>();

            builder.Services.AddSingleton<CarListViewModel>();
            builder.Services.AddSingleton<CarDetailsViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<CarDetailsPage>();

            return builder.Build();
        }
    }
}