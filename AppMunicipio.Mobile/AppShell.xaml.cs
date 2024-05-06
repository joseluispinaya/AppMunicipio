using AppMunicipio.Mobile.ViewModels;
using AppMunicipio.Mobile.Views.Dashboard;

namespace AppMunicipio.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = new AppShellViewModel();
            Routing.RegisterRoute(nameof(InicioView), typeof(InicioView));
        }
    }
}