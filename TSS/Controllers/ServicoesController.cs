using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSS.Data;
using TSS.Models;

namespace TSS.Controllers
{
    public class ServicoesController : Controller
    {
        private readonly TSSContext _context;

        public ServicoesController(TSSContext context)
        {
            _context = context;
        }

        // GET: Servicoes
        public async Task<IActionResult> Index()
        {
            var servicos = await _context.Servico
                .Include(s => s.Status)
                .Include(s => s.Tiposervico)
                .Include(s => s.Usuario)
                .ToListAsync();
            return View(servicos);
        }

        // GET: Servicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .Include(s => s.Status)
                .Include(s => s.Tiposervico)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // GET: Servicoes/Create
        public IActionResult Create()
        {
            ViewData["Status_Id"] = new SelectList(_context.Set<Status>(), "Id", "Nome");
            ViewData["Tiposervico_Id"] = new SelectList(_context.Tiposervico, "Id", "Nome");
            ViewData["Usuario_Id"] = new SelectList(_context.Set<Usuario>(), "Id", "Nome"); // Ajustado para "Nome"
            return View();
        }

        // POST: Servicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dtini,Dtfim,Descricao,Usuario_Id,Tiposervico_Id,Status_Id")] Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Status_Id"] = new SelectList(_context.Set<Status>(), "Id", "Nome", servico.Status_Id);
            ViewData["Tiposervico_Id"] = new SelectList(_context.Tiposervico, "Id", "Nome", servico.Tiposervico_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Set<Usuario>(), "Id", "Nome", servico.Usuario_Id); // Ajustado para "Nome"
            return View(servico);
        }

        // GET: Servicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }
            ViewData["Status_Id"] = new SelectList(_context.Set<Status>(), "Id", "Nome", servico.Status_Id);
            ViewData["Tiposervico_Id"] = new SelectList(_context.Tiposervico, "Id", "Nome", servico.Tiposervico_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Set<Usuario>(), "Id", "Nome", servico.Usuario_Id); // Ajustado para "Nome"
            return View(servico);
        }

        // POST: Servicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dtini,Dtfim,Descricao,Usuario_Id,Tiposervico_Id,Status_Id")] Servico servico)
        {
            if (id != servico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicoExists(servico.Id))
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
            ViewData["Status_Id"] = new SelectList(_context.Set<Status>(), "Id", "Nome", servico.Status_Id);
            ViewData["Tiposervico_Id"] = new SelectList(_context.Tiposervico, "Id", "Nome", servico.Tiposervico_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Set<Usuario>(), "Id", "Nome", servico.Usuario_Id); // Ajustado para "Nome"
            return View(servico);
        }

        // GET: Servicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servico
                .Include(s => s.Status)
                .Include(s => s.Tiposervico)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        // POST: Servicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servico = await _context.Servico.FindAsync(id);
            if (servico != null)
            {
                _context.Servico.Remove(servico);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ServicoExists(int id)
        {
            return _context.Servico.Any(e => e.Id == id);
        }
    }
}
