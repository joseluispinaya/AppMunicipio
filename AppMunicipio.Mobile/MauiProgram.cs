using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Mobile.ViewModels.Dashboard;
using AppMunicipio.Mobile.ViewModels.Startup;
using AppMunicipio.Mobile.Views.Dashboard;
using AppMunicipio.Mobile.Views.Startup;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Shared;
#if IOS
using Plugin.Firebase.iOS;
#endif
#if ANDROID
using Plugin.Firebase.Android;
#endif

namespace AppMunicipio.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterFirebaseServices()
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
        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events =>
            {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(app, launchOptions, CreateCrossFirebaseSettings());
                return false;
            }));
#else
                events.AddAndroid(android => android.OnCreate((activity, state) =>
                    CrossFirebase.Initialize(activity, state, CreateCrossFirebaseSettings())));
#endif
            });
            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);

            return builder;
        }
        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(isAuthEnabled: true);
        }
    }
}