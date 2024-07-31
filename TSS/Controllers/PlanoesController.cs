using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSS.Data;
using TSS.Models;

namespace TSS.Controllers
{
    public class PlanoesController : Controller
    {
        private readonly TSSContext _context;

        public PlanoesController(TSSContext context)
        {
            _context = context;
        }

        // GET: Planoes
        public async Task<IActionResult> Index()
        {
            var tSSContext = _context.Plano.Include(p => p.Tipoplano);
            return View(await tSSContext.ToListAsync());
        }

        // GET: Planoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .Include(p => p.Tipoplano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Planoes/Create
        public IActionResult Create()
        {
            ViewData["Tipoplano_Id"] = new SelectList(_context.Tipoplano, "Id", "Nome");
            return View();
        }

        // POST: Planoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Tipoplano_Id")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tipoplano_Id"] = new SelectList(_context.Tipoplano, "Id", "Nome", plano.Tipoplano_Id);
            return View(plano);
        }

        // GET: Planoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            ViewData["Tipoplano_Id"] = new SelectList(_context.Tipoplano, "Id", "Nome", plano.Tipoplano_Id);
            return View(plano);
        }

        // POST: Planoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Tipoplano_Id")] Plano plano)
        {
            if (id != plano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(plano.Id))
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
            ViewData["Tipoplano_Id"] = new SelectList(_context.Tipoplano, "Id", "Nome", plano.Tipoplano_Id);
            return View(plano);
        }

        // GET: Planoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .Include(p => p.Tipoplano)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // POST: Planoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plano = await _context.Plano.FindAsync(id);
            if (plano != null)
            {
                _context.Plano.Remove(plano);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
            return _context.Plano.Any(e => e.Id == id);
        }

        // GET: Planoes/SelectPlano
        public IActionResult SelectPlano()
        {
            var planos = _context.Plano.ToList();
            return View(planos);
        }
        // GET: Planoes/AssignPlano/5
        public async Task<IActionResult> AssignPlano(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (email == null)
            {
                return RedirectToAction("Login", "Conta");
            }

            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var plano = await _context.Plano.FindAsync(id);

            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }

            usuario.Plano = plano;
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Cliente");
        }
        [HttpGet]
        public async Task<IActionResult> Select(int id)
        {
            var usuarioEmail = User.FindFirstValue(ClaimTypes.Email);

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == usuarioEmail);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var plano = await _context.Plano.FindAsync(id);

            if (plano == null)
            {
                return NotFound("Plano não encontrado.");
            }

            usuario.Plano = plano;
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Cliente");
        }

    }
}
