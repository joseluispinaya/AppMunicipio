using AppMunicipio.Mobile.ViewModels.Dashboard;

namespace AppMunicipio.Mobile.Views.Dashboard;

public partial class ContratoDetalleView : ContentPage
{
	public ContratoDetalleView(ContratoItemViewModel contratoItemViewModel)
	{
		InitializeComponent();
        BindingContext = new ContratoDetalleViewModel(contratoItemViewModel);
    }
}