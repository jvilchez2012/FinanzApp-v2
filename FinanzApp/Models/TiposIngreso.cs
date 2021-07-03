using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class TiposIngreso
    {
        public TiposIngreso()
        {
            GestionIngresos = new HashSet<GestionIngreso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<GestionIngreso> GestionIngresos { get; set; }
    }
}
