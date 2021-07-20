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
    public class ProcesoCortesController : Controller
    {
        private readonly finanzappsdbContext _context;

        public ProcesoCortesController(finanzappsdbContext context)
        {
            _context = context;
        }

        // GET: ProcesoCortes
        public async Task<IActionResult> Index()
        {
            string sessionName = HttpContext.Session.GetString("nombre");
            if (sessionName != null)
            {
                return View(await _context.ProcesoCortes.ToListAsync());
            }
            else
            {
                return Redirect("Login/Index");
            }
            
        }

        // GET: ProcesoCortes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesoCorte = await _context.ProcesoCortes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesoCorte == null)
            {
                return NotFound();
            }

            return View(procesoCorte);
        }

        // GET: ProcesoCortes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcesoCortes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Mes,FechaCorte,BalanceInicial,TotalIngresos,TotalEgresos,BalanceCorte")] ProcesoCorte procesoCorte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesoCorte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesoCorte);
        }

        // GET: ProcesoCortes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesoCorte = await _context.ProcesoCortes.FindAsync(id);
            if (procesoCorte == null)
            {
                return NotFound();
            }
            return View(procesoCorte);
        }

        // POST: ProcesoCortes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,Mes,FechaCorte,BalanceInicial,TotalIngresos,TotalEgresos,BalanceCorte")] ProcesoCorte procesoCorte)
        {
            if (id != procesoCorte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesoCorte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesoCorteExists(procesoCorte.Id))
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
            return View(procesoCorte);
        }

        // GET: ProcesoCortes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesoCorte = await _context.ProcesoCortes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesoCorte == null)
            {
                return NotFound();
            }

            return View(procesoCorte);
        }

        // POST: ProcesoCortes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesoCorte = await _context.ProcesoCortes.FindAsync(id);
            _context.ProcesoCortes.Remove(procesoCorte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesoCorteExists(int id)
        {
            return _context.ProcesoCortes.Any(e => e.Id == id);
        }
    }
}
