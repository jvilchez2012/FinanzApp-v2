using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinanzApp.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            RegistroTransacciones = new HashSet<RegistroTransaccione>();
        }


        public int Id { get; set; }
        [Required(ErrorMessage = "Escribe tu nombre")]
        [MinLength(1, ErrorMessage = "Escribe al menos 1 caracter")]
        [MaxLength(60, ErrorMessage = "Escribe un maximo de 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escribe tu identificacion")]
        [RegularExpression("^[0-9]{3}-[0-9]{7}-[0-9]{1}$")]
        public string Identificacion { get; set; }
        [Display(Name = "Limite de egresos")]
        [Required(ErrorMessage = "Revise el monto")]
        [Range(1, 999999999999999, ErrorMessage = "Revise el monto")]
        public decimal LimiteEgresos { get; set; }
        [Display(Name = "Tipo de persona")]
        public string TipoPersona { get; set; }
        [Display(Name = "Fecha de corte")]
        public DateTime FechaCorte { get; set; }
        [Range(1, 999999999999999, ErrorMessage = "Revise el monto")]
        public decimal balance { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }

        public virtual ICollection<RegistroTransaccione> RegistroTransacciones { get; set; }
    }
}
