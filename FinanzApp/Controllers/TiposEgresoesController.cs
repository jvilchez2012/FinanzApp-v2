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
    public class TiposEgresoesController : Controller
    {
        private readonly finanzappsdbContext _context;

        public TiposEgresoesController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: TiposEgresoes
        public async Task<IActionResult> Index()
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                return View(await _context.TiposEgresos.ToListAsync());
            }
            else
            {
                return Redirect("Login/Index");
            }
            
        }

        // GET: TiposEgresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposEgreso = await _context.TiposEgresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposEgreso == null)
            {
                return NotFound();
            }

            return View(tiposEgreso);
        }

        // GET: TiposEgresoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposEgresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] TiposEgreso tiposEgreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposEgreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposEgreso);
        }

        // GET: TiposEgresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposEgreso = await _context.TiposEgresos.FindAsync(id);
            if (tiposEgreso == null)
            {
                return NotFound();
            }
            return View(tiposEgreso);
        }

        // POST: TiposEgresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] TiposEgreso tiposEgreso)
        {
            if (id != tiposEgreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposEgreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposEgresoExists(tiposEgreso.Id))
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
            return View(tiposEgreso);
        }

        // GET: TiposEgresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposEgreso = await _context.TiposEgresos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposEgreso == null)
            {
                return NotFound();
            }

            return View(tiposEgreso);
        }

        // POST: TiposEgresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposEgreso = await _context.TiposEgresos.FindAsync(id);
            _context.TiposEgresos.Remove(tiposEgreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposEgresoExists(int id)
        {
            return _context.TiposEgresos.Any(e => e.Id == id);
        }
    }
}
