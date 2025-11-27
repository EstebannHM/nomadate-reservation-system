using Microsoft.AspNetCore.Mvc;

namespace nomadate_web.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Admin
        public IActionResult Index()
        {
            // Verificar si el usuario está autenticado
            var isAuthenticated = HttpContext.Session.GetString("AdminAuthenticated");
            
            if (isAuthenticated != "true")
            {
                return RedirectToAction("Login");
            }
            
            return View();
        }

        // GET: /Admin/Login
        public IActionResult Login()
        {
            // Si ya está autenticado, redirigir al dashboard
            var isAuthenticated = HttpContext.Session.GetString("AdminAuthenticated");
            if (isAuthenticated == "true")
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Credenciales hardcodeadas
            if (username == "admin" && password == "admin123")
            {
                // Guardar en sesión
                HttpContext.Session.SetString("AdminAuthenticated", "true");
                HttpContext.Session.SetString("AdminUsername", username);
                
                return RedirectToAction("Index");
            }
            
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        // GET: /Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
