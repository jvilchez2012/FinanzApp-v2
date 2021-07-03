using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class GestionIngreso
    {
        public int Id { get; set; }
        public int IdTipoIngreso { get; set; }
        public string Descripcion { get; set; }
        public string Fuente { get; set; }
        public bool Estado { get; set; }

        public virtual TiposIngreso IdTipoIngresoNavigation { get; set; }
    }
}
