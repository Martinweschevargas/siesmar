using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comesnapi;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComesnapiServicioPeluqueriaComesnapiController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ServicioPeluqueriaComesnapi servicioPeluqueriaComesnapiBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public ComesnapiServicioPeluqueriaComesnapiController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio de peluquería", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioPeluqueriaComesnapi");


            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = especialidadGenericaPersonalDTO,
                data3 = dependenciaDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioPeluqueriaComesnapiDTO> select = servicioPeluqueriaComesnapiBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string Fecha, string CIPPersonal, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string CodigoDependencia,
             int CargaId   )
        {
            ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO = new();
            servicioPeluqueriaComesnapiDTO.Fecha = Fecha;
            servicioPeluqueriaComesnapiDTO.CIPPersonal = CIPPersonal;
            servicioPeluqueriaComesnapiDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioPeluqueriaComesnapiDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            servicioPeluqueriaComesnapiDTO.CodigoDependencia = CodigoDependencia;
            servicioPeluqueriaComesnapiDTO.CargaId = CargaId;
            
            servicioPeluqueriaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioPeluqueriaComesnapiBL.AgregarRegistro(servicioPeluqueriaComesnapiDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioPeluqueriaComesnapiBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string Fecha, string CIPPersonal, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string CodigoDependencia)
        {
            ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO = new();
            servicioPeluqueriaComesnapiDTO.ServicioPeluqueriaComesnapiId = Id;
            servicioPeluqueriaComesnapiDTO.Fecha = Fecha;
            servicioPeluqueriaComesnapiDTO.CIPPersonal = CIPPersonal;
            servicioPeluqueriaComesnapiDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioPeluqueriaComesnapiDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            servicioPeluqueriaComesnapiDTO.CodigoDependencia = CodigoDependencia;
            
            servicioPeluqueriaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioPeluqueriaComesnapiBL.ActualizarFormato(servicioPeluqueriaComesnapiDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioPeluqueriaComesnapiDTO servicioPeluqueriaComesnapiDTO = new();
            servicioPeluqueriaComesnapiDTO.ServicioPeluqueriaComesnapiId = Id;
            servicioPeluqueriaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioPeluqueriaComesnapiBL.EliminarFormato(servicioPeluqueriaComesnapiDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioPeluqueriaComesnapiDTO> lista = new List<ServicioPeluqueriaComesnapiDTO>();
            try
            {
                Stream stream = ArchivoExcel.OpenReadStream();
                IWorkbook? MiExcel = null;

                if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                {
                    MiExcel = new XSSFWorkbook(stream);
                }
                else
                {
                    MiExcel = new HSSFWorkbook(stream);
                }
                ISheet HojaExcel = MiExcel.GetSheetAt(0);
                int cantidadFilas = HojaExcel.LastRowNum;

                for (int i = 1; i <= cantidadFilas; i++)
                {
                    IRow fila = HojaExcel.GetRow(i);

                    lista.Add(new ServicioPeluqueriaComesnapiDTO
                    {
                        Fecha = fila.GetCell(0).ToString(),
                        CIPPersonal = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(3).ToString(),
                        CodigoDependencia = fila.GetCell(4).ToString()
                    });
                }
            }
            catch (Exception e)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
                MiExcel = new XSSFWorkbook(stream);
            else
                MiExcel = new HSSFWorkbook(stream);

            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;

            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("Fecha", typeof(string)),
                    new DataColumn("CIPPersonal", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioPeluqueriaComesnapiBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }
        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = servicioPeluqueriaComesnapiBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComesnapiServicioPeluqueria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComesnapiServicioPeluqueria.xlsx");
        }
    }

}

