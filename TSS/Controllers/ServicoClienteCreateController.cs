using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSS.Data;
using TSS.Models;

namespace TSS.Controllers
{
    [Authorize(Policy = "ClientePolicy")]
    public class ServicoClienteCreateController : Controller
    {
        private readonly TSSContext _context;

        public ServicoClienteCreateController(TSSContext context)
        {
            _context = context;
        }

        // GET: ServicoClienteCreate/Create
        public IActionResult Create()
        {
            ViewData["Tiposervico_Id"] = new SelectList(_context.Tiposervico, "Id", "Nome");
            return View();
        }

         // POST: ServicoClienteCreate/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Descricao,Tiposervico_Id")] Servico servico)
    {
        if (ModelState.IsValid)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    var userId = int.Parse(userIdClaim);
                    servico.Usuario_Id = userId;
                    servico.Status_Id = 2; // Definindo status "Em andamento"
                    servico.Dtini = DateTime.Now; // Definindo data de início como data atual
                    // Deixar Dtfim para ser preenchido posteriormente

                    _context.Add(servico);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    // Lidar com o caso onde a Claim não existe
                    ModelState.AddModelError("", "Não foi possível identificar o usuário.");
                }
            }
            else
            {
                // Lidar com o caso onde o usuário não está autenticado
                ModelState.AddModelError("", "Usuário não autenticado.");
            }
        }
        ViewData["Tiposervico_Id"] = new SelectList(_context.Tiposervico, "Id", "Nome", servico.Tiposervico_Id);
        return View(servico);
    }
    }
}
