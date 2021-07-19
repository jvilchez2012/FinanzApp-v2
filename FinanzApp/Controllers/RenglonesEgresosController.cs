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
    public class RenglonesEgresosController : Controller
    {
        private readonly finanzappsdbContext _context;

        public RenglonesEgresosController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: RenglonesEgresos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RenglonesEgresos.ToListAsync());
        }

        // GET: RenglonesEgresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renglonesEgreso = await _context.RenglonesEgresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renglonesEgreso == null)
            {
                return NotFound();
            }

            return View(renglonesEgreso);
        }

        // GET: RenglonesEgresos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RenglonesEgresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] RenglonesEgreso renglonesEgreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renglonesEgreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renglonesEgreso);
        }

        // GET: RenglonesEgresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renglonesEgreso = await _context.RenglonesEgresos.FindAsync(id);
            if (renglonesEgreso == null)
            {
                return NotFound();
            }
            return View(renglonesEgreso);
        }

        // POST: RenglonesEgresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] RenglonesEgreso renglonesEgreso)
        {
            if (id != renglonesEgreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renglonesEgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenglonesEgresoExists(renglonesEgreso.Id))
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
            return View(renglonesEgreso);
        }

        // GET: RenglonesEgresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renglonesEgreso = await _context.RenglonesEgresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renglonesEgreso == null)
            {
                return NotFound();
            }

            return View(renglonesEgreso);
        }

        // POST: RenglonesEgresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renglonesEgreso = await _context.RenglonesEgresos.FindAsync(id);
            _context.RenglonesEgresos.Remove(renglonesEgreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenglonesEgresoExists(int id)
        {
            return _context.RenglonesEgresos.Any(e => e.Id == id);
        }
    }
}
