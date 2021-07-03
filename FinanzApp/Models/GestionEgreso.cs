using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class GestionEgreso
    {
        public int Id { get; set; }
        public int IdTipoEgreso { get; set; }
        public int IdReglonEgreso { get; set; }
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual RenglonesEgreso IdReglonEgresoNavigation { get; set; }
        public virtual TiposEgreso IdTipoEgresoNavigation { get; set; }
        public virtual TiposPago IdTipoPagoNavigation { get; set; }
    }
}
