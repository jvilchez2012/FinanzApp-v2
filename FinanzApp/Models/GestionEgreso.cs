using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinanzApp.Models
{
    public partial class GestionEgreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Elije un tipo de egreso")]
        public int IdTipoEgreso { get; set; }
        [Required(ErrorMessage = "Elije un renglon de egreso")]
        public int IdReglonEgreso { get; set; }
        [Required(ErrorMessage = "Elije un tipo de pago")]
        public int IdTipoPago { get; set; }
        [Required(ErrorMessage = "Escribe la descripcion del egreso")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }

        public virtual RenglonesEgreso IdReglonEgresoNavigation { get; set; }
        public virtual TiposEgreso IdTipoEgresoNavigation { get; set; }
        public virtual TiposPago IdTipoPagoNavigation { get; set; }
    }
}
