using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMunicipio.Shared.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        public DateTime FechaIngre { get; set; }

        public DateTime FechaFin { get; set; }

        public DateTime FechaRegis { get; set; }

        public string Cargoc { get; set; } = null!;

        public decimal Sueldo_Fijo { get; set; }

        public string? DiasTrabajo { get; set; }

        public string? Curricu { get; set; }

        public Personal? Personal { get; set; }
        public int PersonalId { get; set; }

        public DateTime FechaLocalCi => FechaIngre.ToLocalTime();

        public DateTime FechaLocalCf => FechaFin.ToLocalTime();

        public string FormatoSueldo => $"Bs/{Sueldo_Fijo:0.00}";

        public string? PdfFullPath { get; set; }
    }
}
