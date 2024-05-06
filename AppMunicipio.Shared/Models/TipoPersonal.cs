using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMunicipio.Shared.Models
{
    public class TipoPersonal
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        public ICollection<Personal>? Personales { get; set; }

        public int PersonalNumber => Personales == null ? 0 : Personales.Count;
    }
}
