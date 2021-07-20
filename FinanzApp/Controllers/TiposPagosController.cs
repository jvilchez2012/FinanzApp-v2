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
    public class TiposPagosController : Controller
    {
        private readonly finanzappsdbContext _context;

        public TiposPagosController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: TiposPagos
        public async Task<IActionResult> Index()
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                return View(await _context.TiposPagos.ToListAsync());
            }
            else
            {
                return Redirect("Login/Index");
            }
            
        }

        // GET: TiposPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPago = await _context.TiposPagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposPago == null)
            {
                return NotFound();
            }

            return View(tiposPago);
        }

        // GET: TiposPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Estado")] TiposPago tiposPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposPago);
        }

        // GET: TiposPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPago = await _context.TiposPagos.FindAsync(id);
            if (tiposPago == null)
            {
                return NotFound();
            }
            return View(tiposPago);
        }

        // POST: TiposPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Estado")] TiposPago tiposPago)
        {
            if (id != tiposPago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposPagoExists(tiposPago.Id))
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
            return View(tiposPago);
        }

        // GET: TiposPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposPago = await _context.TiposPagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposPago == null)
            {
                return NotFound();
            }

            return View(tiposPago);
        }

        // POST: TiposPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposPago = await _context.TiposPagos.FindAsync(id);
            _context.TiposPagos.Remove(tiposPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposPagoExists(int id)
        {
            return _context.TiposPagos.Any(e => e.Id == id);
        }
    }
}
