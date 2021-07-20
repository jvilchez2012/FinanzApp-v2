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
        [Range(0, 250, ErrorMessage = "Debes ingresar valores entre 0 y 250 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="Ingresa la fuente del ingreso")]
        public string Fuente { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }

        public virtual TiposIngreso IdTipoIngresoNavigation { get; set; }
    }
}
