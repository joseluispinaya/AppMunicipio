using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Shared.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMunicipio.Mobile.ViewModels.Dashboard
{
    [AddINotifyPropertyChangedInterface]
    public class PersonalListViewModel
    {
        private readonly IRepository _repository;

        public PersonalListViewModel(IRepository repository)
        {
            _repository = repository;
            LoadPersonalAsync();
        }
        public List<Personal> Personales { get; set; }
        public List<PersonalItemViewModel> Detalles { get; set; }
        public bool IsRunning { get; set; }

        private async void LoadPersonalAsync()
        {
            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();
            var token = await SecureStorage.Default.GetAsync(SettingsConst.Tokens);
            //var httpResponse = await _repository.GetPerso<Personal>(Cedula, url, "api", "/PersoMobails");
            var responseHttp = await _repository.Get<List<Personal>>(url, "/api/personales", "bearer", token);
            IsRunning = false;
            Personales = responseHttp.Response;
            Detalles = Personales.Select(t => new PersonalItemViewModel
            {
                Id = t.Id,
                Ci = t.Ci,
                Nombres = t.Nombres,
                Nacimiento = t.Nacimiento,
                Direccion = t.Direccion,
                Correo = t.Correo,
                Celular = t.Celular,
                Image = t.Image,
                TipoPersonalId = t.TipoPersonalId,
                TipoPersonal = t.TipoPersonal,
                Unidad = t.Unidad,
                UnidadId = t.UnidadId,
                Contratos = t.Contratos
            }).ToList();
        }
    }
}
