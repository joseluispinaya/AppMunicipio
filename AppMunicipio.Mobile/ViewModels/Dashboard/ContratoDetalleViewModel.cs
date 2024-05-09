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
    public class ContratoDetalleViewModel
    {
        private ContratoItemViewModel _contratoItemViewModel;

        public ContratoDetalleViewModel(ContratoItemViewModel contratoItemViewModel)
        {
            _contratoItemViewModel = contratoItemViewModel;
            VerDetalle();
        }
        public Contrato Contra { get; set; }
        public string Dias { get; set; }
        private async void VerDetalle()
        {
            await Task.Delay(100);
            Contra = _contratoItemViewModel;
            Dias = Contra.DiasTrabajo;
        }
    }
}
