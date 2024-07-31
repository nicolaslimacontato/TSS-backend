using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSS.Data;
using TSS.Models;

namespace TSS.Controllers
{
    public class TipoplanoesController : Controller
    {
        private readonly TSSContext _context;

        public TipoplanoesController(TSSContext context)
        {
            _context = context;
        }

        // GET: Tipoplanoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipoplano.ToListAsync());
        }

        // GET: Tipoplanoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoplano = await _context.Tipoplano
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoplano == null)
            {
                return NotFound();
            }

            return View(tipoplano);
        }

        // GET: Tipoplanoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoplanoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Tipoplano tipoplano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoplano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoplano);
        }

        // GET: Tipoplanoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoplano = await _context.Tipoplano.FindAsync(id);
            if (tipoplano == null)
            {
                return NotFound();
            }
            return View(tipoplano);
        }

        // POST: Tipoplanoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Tipoplano tipoplano)
        {
            if (id != tipoplano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoplano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoplanoExists(tipoplano.Id))
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
            return View(tipoplano);
        }

        // GET: Tipoplanoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoplano = await _context.Tipoplano
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoplano == null)
            {
                return NotFound();
            }

            return View(tipoplano);
        }

        // POST: Tipoplanoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoplano = await _context.Tipoplano.FindAsync(id);
            if (tipoplano != null)
            {
                _context.Tipoplano.Remove(tipoplano);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoplanoExists(int id)
        {
            return _context.Tipoplano.Any(e => e.Id == id);
        }
    }
}
