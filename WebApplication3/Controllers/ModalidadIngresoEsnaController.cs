using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class ModalidadIngresoEsnaController : Controller
    {
        readonly ILogger<ModalidadIngresoEsnaController> _logger;

        public ModalidadIngresoEsnaController(ILogger<ModalidadIngresoEsnaController> logger)
        {
            _logger = logger;
        }

        readonly ModalidadIngresoEsnaDAO modalidadIngresoEsnaBL = new();
        Usuario usuarioBL = new();

        //[Authorize(Roles = "Administrador,Supervisor,Empleado")]
        [Breadcrumb(FromAction = "Index", Title = "Modalidades Ingresos Esnas", FromController= typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult CargarDatos()
        {
            List<ModalidadIngresoEsnaDTO> listaModalidadIngresoEsnas = modalidadIngresoEsnaBL.ObtenerModalidadIngresoEsnas();
            return Json(new { data = listaModalidadIngresoEsnas });
        }

        public ActionResult InsertarModalidadIngresoEsna(string DescModalidadIngresoEsna, string CodigoModalidadIngresoEsna)
        {
            var IND_OPERACION="";
            try
            {
                ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO = new();
                modalidadIngresoEsnaDTO.DescModalidadIngresoEsna = DescModalidadIngresoEsna;
                modalidadIngresoEsnaDTO.CodigoModalidadIngresoEsna = CodigoModalidadIngresoEsna;
                modalidadIngresoEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

                IND_OPERACION = modalidadIngresoEsnaBL.AgregarModalidadIngresoEsna(modalidadIngresoEsnaDTO);

                //_logger.LogWarning(IND_OPERACION);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Content(IND_OPERACION);
        }

        public ActionResult MostrarModalidadIngresoEsna(int ModalidadIngresoEsnaId)
        {
            return Json(modalidadIngresoEsnaBL.BuscarModalidadIngresoEsnaID(ModalidadIngresoEsnaId));
        }

        public ActionResult ActualizarModalidadIngresoEsna(int ModalidadIngresoEsnaId, string DescModalidadIngresoEsna, string CodigoModalidadIngresoEsna)
        {
            ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO = new();
            modalidadIngresoEsnaDTO.ModalidadIngresoEsnaId = ModalidadIngresoEsnaId;
            modalidadIngresoEsnaDTO.DescModalidadIngresoEsna = DescModalidadIngresoEsna;
            modalidadIngresoEsnaDTO.CodigoModalidadIngresoEsna = CodigoModalidadIngresoEsna;
            modalidadIngresoEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadIngresoEsnaBL.ActualizarModalidadIngresoEsna(modalidadIngresoEsnaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult EliminarModalidadIngresoEsna(int ModalidadIngresoEsnaId)
        {
            ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO = new();
            modalidadIngresoEsnaDTO.ModalidadIngresoEsnaId = ModalidadIngresoEsnaId;
            modalidadIngresoEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = modalidadIngresoEsnaBL.EliminarModalidadIngresoEsna(modalidadIngresoEsnaDTO);

            return Content(IND_OPERACION);
        }
    }
}
