using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinanzApp.Models
{
    public partial class RegistroTransaccione
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Elije una opcion")]
        [Display(Name = "Tipo de Transaccion")]
        public string TipoTransaccion { get; set; }
        [Required(ErrorMessage = "Elije una opcion")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Elije el tipo de pago")]
        [Display(Name = "Tipo de pago")]
        public int IdTipoPago { get; set; }
        [Required(ErrorMessage = "Elije la fecha de transaccion")]
        [Display(Name = "Fecha de transaccion")]
        public DateTime FechaTransaccion { get; set; }
        [Required(ErrorMessage = "Elije la fecha de registro")]
        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }
        [Required(ErrorMessage = "Digita el monto de la transaccion")]
        [Display(Name = "Monto de la trasaccion")]
        public decimal MontoTransaccion { get; set; }
        [Display(Name = "Numero de tarjeta de credito")]
        [CreditCard(ErrorMessage ="Tarjeta Invalida")]
        public int? NoTdc { get; set; }
        [Required(ErrorMessage = "Debes ingresar un comentario")]
        [Range(0, 250, ErrorMessage ="Debes ingresar valores entre 0 y 250 caracteres")]
        public string Comentario { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }

        public virtual TiposPago IdTipoPagoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
