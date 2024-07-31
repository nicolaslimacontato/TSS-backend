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
    public class TipousuariosController : Controller
    {
        private readonly TSSContext _context;

        public TipousuariosController(TSSContext context)
        {
            _context = context;
        }

        // GET: Tipousuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipousuario.ToListAsync());
        }

        // GET: Tipousuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipousuario = await _context.Tipousuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipousuario == null)
            {
                return NotFound();
            }

            return View(tipousuario);
        }

        // GET: Tipousuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipousuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipousuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipousuario);
        }

        // GET: Tipousuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipousuario = await _context.Tipousuario.FindAsync(id);
            if (tipousuario == null)
            {
                return NotFound();
            }
            return View(tipousuario);
        }

        // POST: Tipousuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Tipousuario tipousuario)
        {
            if (id != tipousuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipousuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipousuarioExists(tipousuario.Id))
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
            return View(tipousuario);
        }

        // GET: Tipousuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipousuario = await _context.Tipousuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipousuario == null)
            {
                return NotFound();
            }

            return View(tipousuario);
        }

        // POST: Tipousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipousuario = await _context.Tipousuario.FindAsync(id);
            if (tipousuario != null)
            {
                _context.Tipousuario.Remove(tipousuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipousuarioExists(int id)
        {
            return _context.Tipousuario.Any(e => e.Id == id);
        }
    }
}
