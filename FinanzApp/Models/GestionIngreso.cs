using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinanzApp.Models
{
    public partial class GestionIngreso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes elegir el tipo de ingreso")]
        [Display(Name = "Tipo de ingreso")]
        public int IdTipoIngreso { get; set; }
        [Required(ErrorMessage = "Debes ingresar la descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="Ingresa la fuente del ingreso")]
        public string Fuente { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }
        [Display(Name = "Tipo de ingreso")]
        public virtual TiposIngreso IdTipoIngresoNavigation { get; set; }
    }
}
