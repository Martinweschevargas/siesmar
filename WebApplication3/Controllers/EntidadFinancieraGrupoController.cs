using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class EntidadFinancieraGrupoController : Controller
    {
        readonly EntidadFinancieraGrupoDAO entidadFinancieraGrupoBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Entidades Financieras Grupos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<EntidadFinancieraGrupoDTO> listaEntidadFinancieraGrupos = entidadFinancieraGrupoBL.ObtenerEntidadFinancieraGrupos();
            return Json(new { data = listaEntidadFinancieraGrupos });
        }

        public ActionResult InsertarEntidadFinancieraGrupo(string DescEntidadFinancieraGrupo, string CodigoEntidadFinancieraGrupo)
        {
            EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO = new();
            entidadFinancieraGrupoDTO.DescEntidadFinancieraGrupo = DescEntidadFinancieraGrupo;
            entidadFinancieraGrupoDTO.CodigoEntidadFinancieraGrupo = CodigoEntidadFinancieraGrupo;
            entidadFinancieraGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            var IND_OPERACION = entidadFinancieraGrupoBL.AgregarEntidadFinancieraGrupo(entidadFinancieraGrupoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarEntidadFinancieraGrupo(int EntidadFinancieraGrupoId)
        {
            return Json(entidadFinancieraGrupoBL.BuscarEntidadFinancieraGrupoID(EntidadFinancieraGrupoId));
        }

        public ActionResult ActualizarEntidadFinancieraGrupo(int EntidadFinancieraGrupoId, string DescEntidadFinancieraGrupo, string CodigoEntidadFinancieraGrupo)
        {
            EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO = new();
            entidadFinancieraGrupoDTO.EntidadFinancieraGrupoId = EntidadFinancieraGrupoId;
            entidadFinancieraGrupoDTO.DescEntidadFinancieraGrupo = DescEntidadFinancieraGrupo;
            entidadFinancieraGrupoDTO.CodigoEntidadFinancieraGrupo = CodigoEntidadFinancieraGrupo;
            entidadFinancieraGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            var IND_OPERACION = entidadFinancieraGrupoBL.ActualizarEntidadFinancieraGrupo(entidadFinancieraGrupoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarEntidadFinancieraGrupo(int EntidadFinancieraGrupoId)
        {
            EntidadFinancieraGrupoDTO entidadFinancieraGrupoDTO = new();
            entidadFinancieraGrupoDTO.EntidadFinancieraGrupoId = EntidadFinancieraGrupoId;
            entidadFinancieraGrupoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (entidadFinancieraGrupoBL.EliminarEntidadFinancieraGrupo(entidadFinancieraGrupoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
