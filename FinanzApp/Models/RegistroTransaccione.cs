using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class RegistroTransaccione
    {
        public int Id { get; set; }
        public string TipoTransaccion { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal MontoTransaccion { get; set; }
        public int? NoTdc { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }

        public virtual TiposPago IdTipoPagoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
