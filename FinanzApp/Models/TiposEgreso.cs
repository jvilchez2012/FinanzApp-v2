using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class TiposEgreso
    {
        public TiposEgreso()
        {
            GestionEgresos = new HashSet<GestionEgreso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<GestionEgreso> GestionEgresos { get; set; }
    }
}
