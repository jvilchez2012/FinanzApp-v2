using FinanzApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzApp.Controllers
{
    public class ReporteController : Controller
    {
        private readonly finanzappsdbContext _context;
        public ReporteController(finanzappsdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                ViewData["Usuarios"] = new SelectList(_context.Usuarios, "Id", "Nombre");

                return View();
            }
            else
            {
                return Redirect("Login/Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buscar(RegistroTransaccione transacciones)
        {
           
                try
                {
                    var busqueda = _context.RegistroTransacciones
                    .Join(
                         _context.Usuarios,
                         RT => RT.IdUsuario,
                         U => U.Id,
                         (RT,U) =>new
                         {
                             fechaR = RT.FechaRegistro,
                             nombreUsuario = U.Nombre,
                             IdUsuario = RT.IdUsuario,
                             TipoTransaccion = RT.TipoTransaccion,
                             MontoTransaccion = RT.MontoTransaccion,
                             Comentario = RT.Comentario
                         }
                        )
                    .Where(c => ((transacciones.FechaInicio==null || c.fechaR >= transacciones.FechaInicio) && (transacciones.FechaFin==null || c.fechaR <= transacciones.FechaFin ))
                    &&  (c.IdUsuario == transacciones.IdUsuario || transacciones.IdUsuario == 0));

                    var builder = new StringBuilder();
                    builder.AppendLine("Usuario,Tipo Transaccion,Fecha Transaccion, Monto transaccion, Comentario");

                    foreach (var item in busqueda)
                    {
                        builder.AppendLine($"{item.nombreUsuario},{item.TipoTransaccion},{item.fechaR},{item.MontoTransaccion},{item.Comentario}");
                    }

                    return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "reporte.csv");
                }
                catch (DbUpdateConcurrencyException)
                {                    
                        throw;                    
                }
        }


    }
}
