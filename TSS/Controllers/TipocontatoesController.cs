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
    public class TipocontatoesController : Controller
    {
        private readonly TSSContext _context;

        public TipocontatoesController(TSSContext context)
        {
            _context = context;
        }

        // GET: Tipocontatoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipocontato.ToListAsync());
        }

        // GET: Tipocontatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipocontato = await _context.Tipocontato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipocontato == null)
            {
                return NotFound();
            }

            return View(tipocontato);
        }

        // GET: Tipocontatoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipocontatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Tipocontato tipocontato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipocontato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipocontato);
        }

        // GET: Tipocontatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipocontato = await _context.Tipocontato.FindAsync(id);
            if (tipocontato == null)
            {
                return NotFound();
            }
            return View(tipocontato);
        }

        // POST: Tipocontatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Tipocontato tipocontato)
        {
            if (id != tipocontato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipocontato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipocontatoExists(tipocontato.Id))
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
            return View(tipocontato);
        }

        // GET: Tipocontatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipocontato = await _context.Tipocontato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipocontato == null)
            {
                return NotFound();
            }

            return View(tipocontato);
        }

        // POST: Tipocontatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipocontato = await _context.Tipocontato.FindAsync(id);
            if (tipocontato != null)
            {
                _context.Tipocontato.Remove(tipocontato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipocontatoExists(int id)
        {
            return _context.Tipocontato.Any(e => e.Id == id);
        }
    }
}
