using AppMunicipio.Mobile.Repositories;
using AppMunicipio.Shared.Models;
using PropertyChanged;
using System.Windows.Input;

namespace AppMunicipio.Mobile.ViewModels.Dashboard
{
    [AddINotifyPropertyChangedInterface]
    public class PersonalViewModel
    {
        private readonly IRepository _repository;

        public PersonalViewModel(IRepository repository)
        {
            _repository = repository;
            Foto = "noimage";
        }
        public Personal Persona { get; set; }
        public string Cedula { get; set; }

        public string Edad { get; set; }

        public bool IsRunning { get; set; }
        public ImageSource Foto { get; set; }
        public List<Contrato> Contratos { get; set; }
        public List<ContratoItemViewModel> Detalles { get; set; }

        public ICommand BuscarCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await ExecuteBuscarCommandAsync();
                });
            }
        }
        private async Task ExecuteBuscarCommandAsync()
        {
            IsRunning = true;
            Cedula = "764532312";
            string url = "https://municipioze.azurewebsites.net/";
            var httpResponse = await _repository.GetPerso<Personal>(Cedula, url, "api", "/PersoMobails");
            IsRunning = false;
            if (httpResponse.Error)
            {
                var message = await httpResponse.GetErrorMessageAsync();
                await App.Current.MainPage.DisplayAlert("Error", message, "Ok");
                return;
            }
            Persona = httpResponse.Response!;
            Contratos = Persona.Contratos.ToList();
            Foto = httpResponse.Response.Image;

            DateTime fecnaci = Persona.Nacimiento;
            DateTime fechaActual = DateTime.UtcNow;
            int edad = await CalcularEdad(fecnaci, fechaActual);
            Edad = edad.ToString() + " años";

            Detalles = Persona.Contratos.Select(t => new ContratoItemViewModel
            {
                Id = t.Id,
                FechaIngre = t.FechaIngre,
                FechaFin = t.FechaFin,
                FechaRegis = t.FechaRegis,
                Cargoc = t.Cargoc,
                Sueldo_Fijo = t.Sueldo_Fijo,
                DiasTrabajo = t.DiasTrabajo,
                Curricu = t.Curricu,
                Personal = t.Personal,
                PersonalId = t.PersonalId,
                PdfFullPath = t.PdfFullPath
            }).ToList();

        }
        private static async Task<int> CalcularEdad(DateTime fechaNacimiento, DateTime fechaActual)
        {
            await Task.Delay(100); // Esperar 100 milisegundos

            fechaNacimiento = fechaNacimiento.ToLocalTime();
            fechaActual = fechaActual.ToLocalTime();
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            return edad;
        }
    }
}
