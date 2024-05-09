using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Mobile.ViewModels.Dashboard;
using AppMunicipio.Mobile.ViewModels.Startup;
using AppMunicipio.Mobile.Views.Dashboard;
using AppMunicipio.Mobile.Views.Startup;
using Microsoft.Extensions.Logging;

namespace AppMunicipio.Mobile
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

            builder.Services.AddSingleton<IRepository, Repository>();
            //Views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<InicioView>();
            builder.Services.AddTransient<LoadingView>();
            builder.Services.AddTransient<PersonalView>();
            builder.Services.AddTransient<ContratoDetalleView>();
            builder.Services.AddTransient<PersonalListView>();

            //View Models
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoadingViewModel>();
            builder.Services.AddTransient<PersonalViewModel>();
            builder.Services.AddTransient<ContratoDetalleViewModel>();
            builder.Services.AddTransient<PersonalListViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}