using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Mobile.ViewModels.Dashboard;

namespace AppMunicipio.Mobile.Views.Dashboard;

public partial class PersonalListView : ContentPage
{
	public PersonalListView()
	{
		InitializeComponent();
        IRepository repository = new Repository();
        BindingContext = new PersonalListViewModel(repository);
    }
}