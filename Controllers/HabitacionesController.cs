using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nomadate_web.Models;

namespace nomadate_web.Controllers;

public class HabitacionesController : Controller
{
    private readonly ILogger<HabitacionesController> _logger;
    private readonly NomadateContext _context;

    public HabitacionesController(ILogger<HabitacionesController> logger, NomadateContext context)
    {
        _logger = logger;
        _context = context;
    }

    // GET: Habitaciones
    public async Task<IActionResult> Index()
    {
        // Obtener todas las habitaciones de la base de datos
        var habitaciones = await _context.Habitacions.ToListAsync();
        return View(habitaciones);
    }

    // GET: Habitaciones/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var habitacion = await _context.Habitacions
            .Include(h => h.Resennas)
                .ThenInclude(r => r.IdUsuarioNavigation)
            .FirstOrDefaultAsync(m => m.IdHabitacion == id);

        if (habitacion == null)
        {
            return NotFound();
        }

        return View(habitacion);
    }
}
