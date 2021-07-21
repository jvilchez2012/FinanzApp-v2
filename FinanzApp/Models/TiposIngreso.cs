using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Debes ingresar la descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }

        public virtual ICollection<GestionIngreso> GestionIngresos { get; set; }
    }
}
