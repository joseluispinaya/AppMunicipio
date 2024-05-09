using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Mobile.ViewModels.Dashboard;

namespace AppMunicipio.Mobile.Views.Dashboard;

public partial class PersonalView : ContentPage
{
	public PersonalView()
	{
		InitializeComponent();
        IRepository repository = new Repository();
        BindingContext = new PersonalViewModel(repository);
    }
}