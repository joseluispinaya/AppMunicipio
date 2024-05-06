using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Mobile.ViewModels.Startup;

namespace AppMunicipio.Mobile.Views.Startup;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
        IRepository repository = new Repository();
        BindingContext = new LoginViewModel(repository);
    }
}