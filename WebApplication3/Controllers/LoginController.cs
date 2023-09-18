using Marina.Siesmar.Entidades.Seguridad;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServiceReference3;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> logger;

        public LoginController(ILogger<LoginController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Login()
        {
            logger.LogWarning("Entro al Login Http");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDTO u)
        {
            try
            {
                using (Service1Client ws = new Service1Client())
                {

                    var user =await ws.LoginServiceAsync(u.user, u.pass);

                    if (string.IsNullOrEmpty(user.Error))
                    {
                        if ( user.CheckPassword==1)
                        {
                            var claims = new List<Claim>
                            {
                            new Claim("IdUsuario",user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Documento),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, user.Rol.ToString())
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            AuthenticationProperties p = new();

                            p.AllowRefresh = true;
                            p.IsPersistent = u.MantenerActivo;

                            if (!u.MantenerActivo)
                                p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30);
                            else
                                p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), p);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewData["Mensaje"] = "Acceso Denegado";
                        }
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Error";
                    }
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
