using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TSS.Data;
using TSS.Models;
using System.Security.Claims;

namespace TSS.Controllers
{
    [Authorize(Policy = "ClientePolicy")]
    public class ClienteController : Controller
    {
        private readonly TSSContext _context;

        public ClienteController(TSSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (email == null)
            {
                return RedirectToAction("Login", "Conta");
            }

            var usuario = await _context.Usuario
                .Include(u => u.Servicos)
                    .ThenInclude(s => s.Tiposervico)
                .Include(u => u.Servicos)
                    .ThenInclude(s => s.Status)
                .Include(u => u.Plano) // Incluindo o plano do usuário
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            ViewBag.Servicos = usuario.Servicos;
            ViewBag.Plano = usuario.Plano; // Passa o plano para a view

            return View();
        }
    }
}
