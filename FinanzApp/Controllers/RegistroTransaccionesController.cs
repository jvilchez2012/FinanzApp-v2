using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanzApp.Models;
using Microsoft.AspNetCore.Http;

namespace FinanzApp.Controllers
{
    public class RegistroTransaccionesController : Controller
    {
        private readonly finanzappsdbContext _context;

        public RegistroTransaccionesController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: RegistroTransacciones
        public async Task<IActionResult> Index(String Criterio = null)
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                var finanzappsdbContext = _context.RegistroTransacciones.Include(r => r.IdTipoPagoNavigation).Include(r => r.IdUsuarioNavigation);

                return View(await _context.RegistroTransacciones.Where(p => Criterio == null ||
                                                         p.TipoTransaccion.StartsWith(Criterio) ||
                                                         p.Comentario.StartsWith(Criterio) ||
                                             p.NoTdc.ToString().StartsWith(Criterio)).ToListAsync());
            }
            else
            {
                return Redirect("Login/Index");
            }
            
        }

        // GET: RegistroTransacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccione = await _context.RegistroTransacciones
                .Include(r => r.IdTipoPagoNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroTransaccione == null)
            {
                return NotFound();
            }

            return View(registroTransaccione);
        }

        // GET: RegistroTransacciones/Create
        public IActionResult Create()
        {
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Identificacion");
            return View();
        }

        // POST: RegistroTransacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoTransaccion,IdUsuario,IdTipoPago,FechaTransaccion,FechaRegistro,MontoTransaccion,NoTdc,Comentario,Estado")] RegistroTransaccione registroTransaccione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroTransaccione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion", registroTransaccione.IdTipoPago);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Identificacion", registroTransaccione.IdUsuario);
            return View(registroTransaccione);
        }

        // GET: RegistroTransacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccione = await _context.RegistroTransacciones.FindAsync(id);
            if (registroTransaccione == null)
            {
                return NotFound();
            }
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion", registroTransaccione.IdTipoPago);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Identificacion", registroTransaccione.IdUsuario);
            return View(registroTransaccione);
        }

        // POST: RegistroTransacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoTransaccion,IdUsuario,IdTipoPago,FechaTransaccion,FechaRegistro,MontoTransaccion,NoTdc,Comentario,Estado")] RegistroTransaccione registroTransaccione)
        {
            if (id != registroTransaccione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroTransaccione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroTransaccioneExists(registroTransaccione.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion", registroTransaccione.IdTipoPago);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Identificacion", registroTransaccione.IdUsuario);
            return View(registroTransaccione);
        }

        // GET: RegistroTransacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroTransaccione = await _context.RegistroTransacciones
                .Include(r => r.IdTipoPagoNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroTransaccione == null)
            {
                return NotFound();
            }

            return View(registroTransaccione);
        }

        // POST: RegistroTransacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroTransaccione = await _context.RegistroTransacciones.FindAsync(id);
            _context.RegistroTransacciones.Remove(registroTransaccione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroTransaccioneExists(int id)
        {
            return _context.RegistroTransacciones.Any(e => e.Id == id);
        }
    }
}
