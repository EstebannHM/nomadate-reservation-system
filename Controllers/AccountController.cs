using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using nomadate_web.Models;
using nomadate_web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace nomadate_web.Controllers;

public class AccountController : Controller
{
    private readonly NomadateContext _context;

    public AccountController(NomadateContext context)
    {
        _context = context;
    }

    // GET /Account/Login  (solo para probar, NO carga vista)
    [HttpGet]
    public IActionResult Login()
    {
        return Ok(new { message = "Login endpoint OK" });
    }

    // POST /Account/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { error = "Datos inválidos" });

        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == model.Email && u.Contrasenna == model.Contrasenna);

        if (usuario == null)
            return Unauthorized(new { error = "Email o contraseña incorrectos." });

        // Crear Claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, $"{usuario.Nombre} {usuario.Apellido}"),
            new Claim(ClaimTypes.Email, usuario.Email),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return Ok(new { message = "Login correcto" });
    }

    // POST /Account/Register
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new { error = "Datos inválidos" });

        bool existe = await _context.Usuarios.AnyAsync(u => u.Email == model.Email);
        if (existe)
            return Conflict(new { error = "El correo ya existe" });

        var nuevo = new Usuario
        {
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            Email = model.Email,
            Contrasenna = model.Contrasenna
        };

        _context.Usuarios.Add(nuevo);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuario registrado correctamente" });
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Sesión cerrada" });
    }
}
