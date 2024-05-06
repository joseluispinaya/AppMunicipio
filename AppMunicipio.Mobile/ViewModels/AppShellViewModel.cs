using AppMunicipio.Mobile.Views.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMunicipio.Mobile.ViewModels
{
    public class AppShellViewModel
    {
        public ICommand SalirCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await SalirCommandAsync();
                });
            }
        }
        private async Task SalirCommandAsync()
        {
            SecureStorage.Default.Remove(SettingsConst.Tokens);
            SecureStorage.Default.Remove(SettingsConst.Logi);


            var sere = await SecureStorage.Default.GetAsync(SettingsConst.Tokens);

            await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
        }
    }
}
