using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class TiposPago
    {
        public TiposPago()
        {
            GestionEgresos = new HashSet<GestionEgreso>();
            RegistroTransacciones = new HashSet<RegistroTransaccione>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<GestionEgreso> GestionEgresos { get; set; }
        public virtual ICollection<RegistroTransaccione> RegistroTransacciones { get; set; }
    }
}
