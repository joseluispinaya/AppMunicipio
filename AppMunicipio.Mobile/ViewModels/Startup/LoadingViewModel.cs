using AppMunicipio.Mobile.Views.Dashboard;
using AppMunicipio.Mobile.Views.Startup;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMunicipio.Mobile.ViewModels.Startup
{
    public class LoadingViewModel
    {
        public LoadingViewModel()
        {
            CheckUserLoginDetails();
        }
        private async void CheckUserLoginDetails()
        {
            var sere = await SecureStorage.Default.GetAsync(SettingsConst.Tokens);
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(sere) as JwtSecurityToken;

            var firstNameClaim = tokenS.Claims.FirstOrDefault(claim => claim.Type == "FirstName");
            var userName = $"{firstNameClaim.Value}";

            if (string.IsNullOrEmpty(userName))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginView)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(InicioView)}");
            }
        }
    }
}
