using Microsoft.AspNetCore.Mvc;
using nomadate_web.Models;

namespace nomadate_web.Controllers
{
    public class DebugController : Controller
    {
        private readonly NomadateContext _context;

        public DebugController(NomadateContext context)
        {
            _context = context;
        }

        // GET: /Debug/Usuarios
        public IActionResult Usuarios()
        {
            var lista = _context.Usuarios.ToList();
            return View(lista);
        }
    }
}
