using AppMunicipio.Mobile.ViewModels.Startup;

namespace AppMunicipio.Mobile.Views.Startup;

public partial class LoadingView : ContentPage
{
	public LoadingView()
	{
		InitializeComponent();
        BindingContext = new LoadingViewModel();
    }
}