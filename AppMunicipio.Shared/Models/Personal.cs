using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMunicipio.Shared.Models
{
    public class Personal
    {
        public int Id { get; set; }

        public string? Ci { get; set; }

        public string? Nombres { get; set; }

        public DateTime Nacimiento { get; set; }

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public string? Celular { get; set; }

        public string? Image { get; set; }

        public int TipoPersonalId { get; set; }
        public TipoPersonal? TipoPersonal { get; set; }
        public Unidad? Unidad { get; set; }
        public int UnidadId { get; set; }

        public ICollection<Contrato>? Contratos { get; set; }

        public DateTime FechaLocal => Nacimiento.ToLocalTime();
    }
}
