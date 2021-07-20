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
    public class GestionEgresosController : Controller
    {
        private readonly finanzappsdbContext _context;

        public GestionEgresosController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: GestionEgresos
        public async Task<IActionResult> Index()
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                var finanzappsdbContext = _context.GestionEgresos.Include(g => g.IdReglonEgresoNavigation).Include(g => g.IdTipoEgresoNavigation).Include(g => g.IdTipoPagoNavigation);
                return View(await finanzappsdbContext.ToListAsync());
            }
            else
            {
                return Redirect("Login/Index");
            }
            
        }

        // GET: GestionEgresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionEgreso = await _context.GestionEgresos
                .Include(g => g.IdReglonEgresoNavigation)
                .Include(g => g.IdTipoEgresoNavigation)
                .Include(g => g.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionEgreso == null)
            {
                return NotFound();
            }

            return View(gestionEgreso);
        }

        // GET: GestionEgresos/Create
        public IActionResult Create()
        {
            ViewData["IdReglonEgreso"] = new SelectList(_context.RenglonesEgresos, "Id", "Descripcion");
            ViewData["IdTipoEgreso"] = new SelectList(_context.TiposEgresos, "Id", "Id");
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion");
            return View();
        }

        // POST: GestionEgresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipoEgreso,IdReglonEgreso,IdTipoPago,Descripcion,Estado")] GestionEgreso gestionEgreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestionEgreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReglonEgreso"] = new SelectList(_context.RenglonesEgresos, "Id", "Descripcion", gestionEgreso.IdReglonEgreso);
            ViewData["IdTipoEgreso"] = new SelectList(_context.TiposEgresos, "Id", "Id", gestionEgreso.IdTipoEgreso);
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion", gestionEgreso.IdTipoPago);
            return View(gestionEgreso);
        }

        // GET: GestionEgresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionEgreso = await _context.GestionEgresos.FindAsync(id);
            if (gestionEgreso == null)
            {
                return NotFound();
            }
            ViewData["IdReglonEgreso"] = new SelectList(_context.RenglonesEgresos, "Id", "Descripcion", gestionEgreso.IdReglonEgreso);
            ViewData["IdTipoEgreso"] = new SelectList(_context.TiposEgresos, "Id", "Id", gestionEgreso.IdTipoEgreso);
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion", gestionEgreso.IdTipoPago);
            return View(gestionEgreso);
        }

        // POST: GestionEgresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoEgreso,IdReglonEgreso,IdTipoPago,Descripcion,Estado")] GestionEgreso gestionEgreso)
        {
            if (id != gestionEgreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestionEgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestionEgresoExists(gestionEgreso.Id))
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
            ViewData["IdReglonEgreso"] = new SelectList(_context.RenglonesEgresos, "Id", "Descripcion", gestionEgreso.IdReglonEgreso);
            ViewData["IdTipoEgreso"] = new SelectList(_context.TiposEgresos, "Id", "Id", gestionEgreso.IdTipoEgreso);
            ViewData["IdTipoPago"] = new SelectList(_context.TiposPagos, "Id", "Descripcion", gestionEgreso.IdTipoPago);
            return View(gestionEgreso);
        }

        // GET: GestionEgresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionEgreso = await _context.GestionEgresos
                .Include(g => g.IdReglonEgresoNavigation)
                .Include(g => g.IdTipoEgresoNavigation)
                .Include(g => g.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionEgreso == null)
            {
                return NotFound();
            }

            return View(gestionEgreso);
        }

        // POST: GestionEgresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestionEgreso = await _context.GestionEgresos.FindAsync(id);
            _context.GestionEgresos.Remove(gestionEgreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestionEgresoExists(int id)
        {
            return _context.GestionEgresos.Any(e => e.Id == id);
        }
    }
}
