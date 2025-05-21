using AppReservasBio.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppReservasBio.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AppDbContext _context;
        public CuentaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string password)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Correo y contraseña son requeridos.");
                return View();
            }

            // Buscar usuario en BD
            var usuario = _context.UsuariosAdmin.FirstOrDefault(u => u.Correo == correo && u.Password == password);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Credenciales inválidas.");
                return View();
            }

            // Crear los claims
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Nombre),
            new Claim(ClaimTypes.Email, usuario.Correo),
            new Claim("UserId", usuario.Id.ToString())
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Recuerda la sesión aunque se cierre el navegador (opcional)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Crear", "Reservas"); // Redirige a la página principal
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Crear", "Reservas");
        }

    }
}
