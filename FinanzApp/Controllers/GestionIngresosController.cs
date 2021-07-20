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
    public class GestionIngresosController : Controller
    {
        private readonly finanzappsdbContext _context;

        public GestionIngresosController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: GestionIngresos
        public async Task<IActionResult> Index()
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                var finanzappsdbContext = _context.GestionIngresos.Include(g => g.IdTipoIngresoNavigation);
                return View(await finanzappsdbContext.ToListAsync());
            }
            else
            {
                return Redirect("Login/Index");
            }
            
        }

        // GET: GestionIngresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionIngreso = await _context.GestionIngresos
                .Include(g => g.IdTipoIngresoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionIngreso == null)
            {
                return NotFound();
            }

            return View(gestionIngreso);
        }

        // GET: GestionIngresos/Create
        public IActionResult Create()
        {
            ViewData["IdTipoIngreso"] = new SelectList(_context.TiposIngresos, "Id", "Descripcion");
            return View();
        }

        // POST: GestionIngresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipoIngreso,Descripcion,Fuente,Estado")] GestionIngreso gestionIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestionIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoIngreso"] = new SelectList(_context.TiposIngresos, "Id", "Descripcion", gestionIngreso.IdTipoIngreso);
            return View(gestionIngreso);
        }

        // GET: GestionIngresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionIngreso = await _context.GestionIngresos.FindAsync(id);
            if (gestionIngreso == null)
            {
                return NotFound();
            }
            ViewData["IdTipoIngreso"] = new SelectList(_context.TiposIngresos, "Id", "Descripcion", gestionIngreso.IdTipoIngreso);
            return View(gestionIngreso);
        }

        // POST: GestionIngresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoIngreso,Descripcion,Fuente,Estado")] GestionIngreso gestionIngreso)
        {
            if (id != gestionIngreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestionIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestionIngresoExists(gestionIngreso.Id))
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
            ViewData["IdTipoIngreso"] = new SelectList(_context.TiposIngresos, "Id", "Descripcion", gestionIngreso.IdTipoIngreso);
            return View(gestionIngreso);
        }

        // GET: GestionIngresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestionIngreso = await _context.GestionIngresos
                .Include(g => g.IdTipoIngresoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionIngreso == null)
            {
                return NotFound();
            }

            return View(gestionIngreso);
        }

        // POST: GestionIngresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestionIngreso = await _context.GestionIngresos.FindAsync(id);
            _context.GestionIngresos.Remove(gestionIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestionIngresoExists(int id)
        {
            return _context.GestionIngresos.Any(e => e.Id == id);
        }
    }
}
