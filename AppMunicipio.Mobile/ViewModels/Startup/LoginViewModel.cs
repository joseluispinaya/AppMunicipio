using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Mobile.Views.Dashboard;
using AppMunicipio.Shared.DTOs;
using PropertyChanged;
using System.IdentityModel.Tokens.Jwt;
using System.Windows.Input;

namespace AppMunicipio.Mobile.ViewModels.Startup
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        private readonly IRepository _repository;
        public LoginViewModel(IRepository repository)
        {
            _repository = repository;
        }
        public string Email { get; set; }

        public string Password { get; set; }
        public bool IsRunning { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await LoginCommandAsync();
                });
            }
        }

        private async Task LoginCommandAsync()
        {
            //if (string.IsNullOrEmpty(Email))
            //{
            //    await App.Current.MainPage.DisplayAlert("Error", "Ingrese Usuario", "Ok");
            //    //await Shell.Current.DisplayAlert("Error", "Ingrese Usuario", "Ok");
            //    return;
            //}
            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();

            //LoginDTO loginDTO = new LoginDTO
            //{
            //    Password = Password,
            //    Email = Email
            //};
            LoginDTO loginDTO = new LoginDTO
            {
                Password = "123456",
                Email = "joseluis@yopmail.com"
            };

            var responseHttp = await _repository.Post<LoginDTO, TokenDTO>(url, "/api/accounts/Login", loginDTO);
            IsRunning = false;
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await App.Current.MainPage.DisplayAlert("Error", message, "Ok");
                return;
            }

            //SecureStorage.Default.Remove(SettingsConst.Tokens);
            //SecureStorage.Default.Remove(SettingsConst.Logi);

            await SecureStorage.Default.SetAsync(SettingsConst.Tokens, responseHttp.Response.Token);
            await SecureStorage.Default.SetAsync(SettingsConst.Logi, "si");
            Password = string.Empty;

            //var sere = await SecureStorage.Default.GetAsync(SettingsConst.Tokens);
            //var handler = new JwtSecurityTokenHandler();
            //var tokenS = handler.ReadToken(sere) as JwtSecurityToken;

            //var firstNameClaim = tokenS.Claims.FirstOrDefault(claim => claim.Type == "FirstName");
            //var lastNameClaim = tokenS.Claims.FirstOrDefault(claim => claim.Type == "LastName");

            //var userName = $"{firstNameClaim.Value} {lastNameClaim.Value}";
            await Shell.Current.GoToAsync($"//{nameof(InicioView)}");
        }
    }
}
