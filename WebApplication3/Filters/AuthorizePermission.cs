using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Marina.Siesmar.Utilitarios;

namespace Marina.Siesmar.Presentacion.Filters
{
    public class AuthorizePermission : Attribute, IAuthorizationFilter
    {

        private int Formato;
        private int Permiso;

        public AuthorizePermission(int Formato = 0, int Permiso = 0)
        {
            this.Formato = Formato;
            this.Permiso = Permiso;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                Menu SeguridadMenu = new();
                ClaimsPrincipal c = context.HttpContext.User;

                if (c.Identity.IsAuthenticated)
                {
                    var resultPermiso = SeguridadMenu.ValidarPermisos(c.obtenerUsuarioId(), Formato, Permiso);
                    if (resultPermiso == 0)
                    {
                        context.Result = new RedirectResult("/Home/SinAcceso");
                    }
                }       
            }
            catch (Exception)
            {
                context.Result = new RedirectResult("/Home/SinAcceso");
            }
        }

    }
}
