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
    public class TiposervicoesController : Controller
    {
        private readonly TSSContext _context;

        public TiposervicoesController(TSSContext context)
        {
            _context = context;
        }

        // GET: Tiposervicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiposervico.ToListAsync());
        }

        // GET: Tiposervicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposervico = await _context.Tiposervico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposervico == null)
            {
                return NotFound();
            }

            return View(tiposervico);
        }

        // GET: Tiposervicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tiposervicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Tiposervico tiposervico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposervico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposervico);
        }

        // GET: Tiposervicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposervico = await _context.Tiposervico.FindAsync(id);
            if (tiposervico == null)
            {
                return NotFound();
            }
            return View(tiposervico);
        }

        // POST: Tiposervicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Tiposervico tiposervico)
        {
            if (id != tiposervico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposervico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposervicoExists(tiposervico.Id))
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
            return View(tiposervico);
        }

        // GET: Tiposervicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposervico = await _context.Tiposervico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposervico == null)
            {
                return NotFound();
            }

            return View(tiposervico);
        }

        // POST: Tiposervicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposervico = await _context.Tiposervico.FindAsync(id);
            if (tiposervico != null)
            {
                _context.Tiposervico.Remove(tiposervico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposervicoExists(int id)
        {
            return _context.Tiposervico.Any(e => e.Id == id);
        }
    }
}
