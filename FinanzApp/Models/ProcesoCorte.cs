using System;
using System.Collections.Generic;

#nullable disable

namespace FinanzApp.Models
{
    public partial class ProcesoCorte
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Mes { get; set; }
        public DateTime FechaCorte { get; set; }
        public decimal BalanceInicial { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal BalanceCorte { get; set; }
    }
}
