using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Marina.Siesmar.Presentacion.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Marina.Siesmar.Presentacion.Filters
{
    public class VerificarSesion: ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                base.OnActionExecuting(context);

                ClaimsPrincipal c = context.HttpContext.User;

                if (!c.Identity.IsAuthenticated)
                {
                    if(context.Controller is LoginController == false)
                    {
                        context.HttpContext.Response.Redirect("/Login/Login");
                    }
                }
            }
            catch (Exception)
            {
                context.Result = new RedirectResult("/Login/Login");
            }
            
        }
    }
}
