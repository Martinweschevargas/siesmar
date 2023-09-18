using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using SmartBreadcrumbs.Attributes;

namespace WebApplication3.Controllers
{
    [Authorize]
    [DefaultBreadcrumb("Inicio")]
    public class HomeController : Controller
    {
        Menu menu = new();

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult getDependencias()
        {
            List<MenuPrincipalDTO> dependencias = menu.ObtenerDependencias(User.obtenerUsuarioId());
            Dictionary<string, List<MenuPrincipalDTO>> Grupos = new Dictionary<string, List<MenuPrincipalDTO>>();
            foreach (var dependencia in dependencias)
            {
                string nombreGrupo = dependencia.Dependencia;
                Grupos[nombreGrupo] = new List<MenuPrincipalDTO>();
                List<MenuPrincipalDTO> items1 = menu.ObtenerDependenciasSubordinadas1(nombreGrupo, User.obtenerUsuarioId());
                List<MenuPrincipalDTO> items2 = menu.ObtenerDependenciasSubordinadas2(nombreGrupo, User.obtenerUsuarioId());
                if (items1 != null && items1.Count > 0)
                {
                    Grupos[nombreGrupo].AddRange(items1);
                    Grupos[nombreGrupo].AddRange(items2);
                }      
            }
            return Json(Grupos);
        }

        public JsonResult cargarMenuSeguridad()
        {
            int usuarioId = User.obtenerUsuarioId();
            List<MenuPrincipalDTO> Seguridad = menu.ObtenerMenuSeguridad(usuarioId);
            return Json(Seguridad);
        }

        public IActionResult SinAcceso()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}