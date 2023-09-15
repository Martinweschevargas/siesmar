using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class SituacionOperatividadEquipoController : Controller
    {
        readonly SituacionOperatividadEquipoDAO situacionOperatividadEquipoBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "SituacionOperatividadEquipo", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<SituacionOperatividadEquipoDTO> listaSituacionOperatividadEquipos = situacionOperatividadEquipoBL.ObtenerSituacionOperatividadEquipos();
            return Json(new { data = listaSituacionOperatividadEquipos });
        }

        public ActionResult InsertarSituacionOperatividadEquipo(string DescripcionMaterial, string Cantidad, string CodigoUnidad, string Ubicacion, string Distrito, string Condicion, string Observacion)
        {
            SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO = new();
            situacionOperatividadEquipoDTO.DescripcionMaterial = DescripcionMaterial;
            situacionOperatividadEquipoDTO.Cantidad = Cantidad;
            situacionOperatividadEquipoDTO.CodigoUnidad = CodigoUnidad;
            situacionOperatividadEquipoDTO.Ubicacion = Ubicacion;
            situacionOperatividadEquipoDTO.Distrito = Distrito;
            situacionOperatividadEquipoDTO.Condicion = Condicion;
            situacionOperatividadEquipoDTO.Observacion = Observacion;
            situacionOperatividadEquipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadEquipoBL.AgregarSituacionOperatividadEquipo(situacionOperatividadEquipoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult MostrarSituacionOperatividadEquipo(int SituacionOperatividadEquipoId)
        {
            return Json(situacionOperatividadEquipoBL.BuscarSituacionOperatividadEquipoID(SituacionOperatividadEquipoId));
        }

        public ActionResult ActualizarSituacionOperatividadEquipo(int SituacionOperatividadEquipoId, string DescripcionMaterial, string Cantidad, string CodigoUnidad, string Ubicacion, string Distrito, string Condicion, string Observacion)
        {
            SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO = new();
            situacionOperatividadEquipoDTO.SituacionOperatividadEquipoId = SituacionOperatividadEquipoId;
            situacionOperatividadEquipoDTO.DescripcionMaterial = DescripcionMaterial;
            situacionOperatividadEquipoDTO.Cantidad = Cantidad;
            situacionOperatividadEquipoDTO.CodigoUnidad = CodigoUnidad;
            situacionOperatividadEquipoDTO.Ubicacion = Ubicacion;
            situacionOperatividadEquipoDTO.Distrito = Distrito;
            situacionOperatividadEquipoDTO.Condicion = Condicion;
            situacionOperatividadEquipoDTO.Observacion = Observacion;
            situacionOperatividadEquipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperatividadEquipoBL.ActualizarSituacionOperatividadEquipo(situacionOperatividadEquipoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarSituacionOperatividadEquipo(int SituacionOperatividadEquipoId)
        {
            SituacionOperatividadEquipoDTO situacionOperatividadEquipoDTO = new();
            situacionOperatividadEquipoDTO.SituacionOperatividadEquipoId = SituacionOperatividadEquipoId;
            situacionOperatividadEquipoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            string mensaje = "";

            if (situacionOperatividadEquipoBL.EliminarSituacionOperatividadEquipo(situacionOperatividadEquipoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    }
}
