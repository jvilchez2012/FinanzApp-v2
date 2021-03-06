using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinanzApp.Models
{
    public partial class ProcesoCorte
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Elije el año")]
        [Display(Name = "Año")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Elije el mes")]
        [Display(Name = "Mes")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "Elije la fecha de corte")]
        [Display(Name = "Fecha de corte")]
        public DateTime FechaCorte { get; set; }

        [Required(ErrorMessage = "Escribe el balance inicial")]
        [Display(Name = "Balance inicial")]
        public decimal BalanceInicial { get; set; }
        [Range(1, 999999999999999, ErrorMessage = "Revise el monto")]
        [Required(ErrorMessage = "Escribe el total de los ingresos")]
        [Display(Name = "Total de ingresos")]
        public decimal TotalIngresos { get; set; }

        [Required(ErrorMessage = "Escribe el total de egresos")]
        [Display(Name = "Total de egresos")]
        [Range(1, 999999999999999, ErrorMessage = "Revise el monto")]

        public decimal TotalEgresos { get; set; }
        
        [Display(Name = "Balance al corte")]
        

        public decimal BalanceCorte { get; set; }
    }
}
