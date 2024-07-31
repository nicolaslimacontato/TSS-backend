using Microsoft.AspNetCore.Mvc;
using TSS.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace TSS.Controllers
{
    public class AdminController : Controller
    {
        private readonly TSSContext _context;

        // Construtor do controlador com injeção de dependência
        public AdminController(TSSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalUsuarios = _context.Usuario.Count();
            ViewBag.TotalPlanos = _context.Plano.Count();
            ViewBag.TotalServicos = _context.Servico.Count();
            ViewBag.ServicosPendentes = _context.Servico.Count(s => s.Status.Nome == "Em andamento");

            return View();
        }

        public IActionResult AnaliseUsuarios()
        {
            var totalUsuarios = _context.Usuario.Count();
            var usuariosPorTipo = _context.Usuario
                .GroupBy(u => u.Tipousuario.Nome)
                .Select(g => new { Tipo = g.Key, Count = g.Count() })
                .ToList();

            ViewBag.TotalUsuarios = totalUsuarios;
            ViewBag.UsuariosPorTipo = usuariosPorTipo;

            // Preparar dados para o gráfico
            var tipos = usuariosPorTipo.Select(u => u.Tipo).ToList();
            var counts = usuariosPorTipo.Select(u => u.Count).ToList();

            // Serializar dados para JSON
            ViewBag.TiposJson = JsonSerializer.Serialize(tipos);
            ViewBag.CountsJson = JsonSerializer.Serialize(counts);

            return View();
        }
        public IActionResult AnaliseServicos()
        {
            var totalServicos = _context.Servico.Count();
            var servicosPorTipo = _context.Servico
                .GroupBy(s => s.Tiposervico.Nome)
                .Select(g => new { Tipo = g.Key, Count = g.Count() })
                .ToList();

            // Verificar se servicosPorTipo contém dados
            if (servicosPorTipo == null || !servicosPorTipo.Any())
            {
                // Defina valores padrão se não houver dados
                ViewBag.Tipos = new List<string>();
                ViewBag.Counts = new List<int>();
            }
            else
            {
                // Preparar dados para o gráfico
                ViewBag.Tipos = servicosPorTipo.Select(s => s.Tipo).ToList();
                ViewBag.Counts = servicosPorTipo.Select(s => s.Count).ToList();
            }

            ViewBag.TotalServicos = totalServicos;
            ViewBag.ServicosPorTipo = servicosPorTipo;

            // Serializar dados para JSON
            ViewBag.TiposJson = JsonSerializer.Serialize(ViewBag.Tipos);
            ViewBag.CountsJson = JsonSerializer.Serialize(ViewBag.Counts);

            return View();
        }

    }
}
