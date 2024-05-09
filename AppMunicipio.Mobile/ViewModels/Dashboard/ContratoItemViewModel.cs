using AppMunicipio.Mobile.Views.Dashboard;
using AppMunicipio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMunicipio.Mobile.ViewModels.Dashboard
{
    public class ContratoItemViewModel : Contrato
    {

        public ICommand SelectContratoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await VerDetalleCommandAsync();
                });
            }
        }

        private async Task VerDetalleCommandAsync()
        {
            await Shell.Current.Navigation.PushAsync(new ContratoDetalleView(this));
        }
    }
}
