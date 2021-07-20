using FinanzApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly finanzappsdbContext _context;

        public LoginController(finanzappsdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Usuario u)
        {
            var usuario =  _context.Usuarios.Where(x => x.Nombre == u.Nombre && x.Identificacion == u.Identificacion).FirstOrDefault();
            if (usuario != null)
            {
                HttpContext.Session.SetString("nombre", usuario.Nombre);

                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
            
        }
    }
}
