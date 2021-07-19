using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanzApp.Models;

namespace FinanzApp.Controllers
{
    public class TiposIngresosController : Controller
    {
        private readonly finanzappsdbContext _context;

        public TiposIngresosController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: TiposIngresos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposIngresos.ToListAsync());
        }

        // GET: TiposIngresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposIngreso = await _context.TiposIngresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposIngreso == null)
            {
                return NotFound();
            }

            return View(tiposIngreso);
        }

        // GET: TiposIngresos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposIngresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] TiposIngreso tiposIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposIngreso);
        }

        // GET: TiposIngresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposIngreso = await _context.TiposIngresos.FindAsync(id);
            if (tiposIngreso == null)
            {
                return NotFound();
            }
            return View(tiposIngreso);
        }

        // POST: TiposIngresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] TiposIngreso tiposIngreso)
        {
            if (id != tiposIngreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposIngresoExists(tiposIngreso.Id))
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
            return View(tiposIngreso);
        }

        // GET: TiposIngresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposIngreso = await _context.TiposIngresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposIngreso == null)
            {
                return NotFound();
            }

            return View(tiposIngreso);
        }

        // POST: TiposIngresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposIngreso = await _context.TiposIngresos.FindAsync(id);
            _context.TiposIngresos.Remove(tiposIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposIngresoExists(int id)
        {
            return _context.TiposIngresos.Any(e => e.Id == id);
        }
    }
}
