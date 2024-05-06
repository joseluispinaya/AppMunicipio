using AppMunicipio.Mobile.Handlers;
using Microsoft.Maui.Platform;

namespace AppMunicipio.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#endif
                }
            });

            MainPage = new AppShell();
        }
    }
}