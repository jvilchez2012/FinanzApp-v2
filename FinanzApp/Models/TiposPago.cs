using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FinanzApp.Models
{
    public partial class TiposPago
    {
        public TiposPago()
        {
            GestionEgresos = new HashSet<GestionEgreso>();
            RegistroTransacciones = new HashSet<RegistroTransaccione>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Debes ingresar la descripcion")]
        [Range(0, 250, ErrorMessage = "Debes ingresar valores entre 0 y 250 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debes seleccionar el estado (ACTIVO O INACTIVO)")]
        public bool Estado { get; set; }

        public virtual ICollection<GestionEgreso> GestionEgresos { get; set; }
        public virtual ICollection<RegistroTransaccione> RegistroTransacciones { get; set; }
    }
}
