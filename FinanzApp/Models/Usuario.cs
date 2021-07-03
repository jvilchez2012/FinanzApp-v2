using System;
using System.Collections.Generic;

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
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public decimal LimiteEgresos { get; set; }
        public string TipoPersona { get; set; }
        public DateTime FechaCorte { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<RegistroTransaccione> RegistroTransacciones { get; set; }
    }
}
