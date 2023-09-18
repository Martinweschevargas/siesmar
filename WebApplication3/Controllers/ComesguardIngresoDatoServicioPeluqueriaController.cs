using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comesguard;
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

    public class ComesguardIngresoDatoServicioPeluqueriaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        IngresoDatoServicioPeluqueria ingresoDatoServicioPeluqueriaBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public ComesguardIngresoDatoServicioPeluqueriaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato para el ingreso de datos del servicio de peluquería", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("IngresoDatoServicioPeluqueria");

            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = especialidadGenericaPersonalDTO,
                data3 = dependenciaDTO,
                data4 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<IngresoDatoServicioPeluqueriaDTO> select = ingresoDatoServicioPeluqueriaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaServicio, string CIP, string CodigoGradoPersonalMilitar,
            string CodigoEspecialidadGenericaPersonal, string CodigoDependencia, int CargaId)
        {
            IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO = new();
            ingresoDatoServicioPeluqueriaDTO.FechaServicio = FechaServicio;
            ingresoDatoServicioPeluqueriaDTO.CIP = CIP;
            ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            ingresoDatoServicioPeluqueriaDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioPeluqueriaDTO.CargaId = CargaId;

            ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioPeluqueriaBL.AgregarRegistro(ingresoDatoServicioPeluqueriaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ingresoDatoServicioPeluqueriaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaServicio, string CIP, string CodigoGradoPersonalMilitar,
            string CodigoEspecialidadGenericaPersonal, string CodigoDependencia)
        {
            IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO = new();
            ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioPeluqueriaId = Id;
            ingresoDatoServicioPeluqueriaDTO.FechaServicio = FechaServicio;
            ingresoDatoServicioPeluqueriaDTO.CIP = CIP;
            ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            ingresoDatoServicioPeluqueriaDTO.CodigoDependencia = CodigoDependencia;

            ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioPeluqueriaBL.ActualizarFormato(ingresoDatoServicioPeluqueriaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO = new();
            ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioPeluqueriaId = Id;
            ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ingresoDatoServicioPeluqueriaBL.EliminarFormato(ingresoDatoServicioPeluqueriaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<IngresoDatoServicioPeluqueriaDTO> lista = new List<IngresoDatoServicioPeluqueriaDTO>();
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

                    lista.Add(new IngresoDatoServicioPeluqueriaDTO
                    {
                        FechaServicio = fila.GetCell(0).ToString(),
                        CIP = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(3).ToString(),
                        CodigoDependencia = fila.GetCell(4).ToString(),
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
                    new DataColumn("FechaServicio ", typeof(string)),
                    new DataColumn("CIP", typeof(string)),
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
            var IND_OPERACION = ingresoDatoServicioPeluqueriaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCIDSP(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comesguard\\IngresoDatoServicioPeluqueria.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = ingresoDatoServicioPeluqueriaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("IngresoDatoServicioPeluqueria", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IngresoDatoServicioPeluqueria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IngresoDatoServicioPeluqueria.xlsx");
        }
    }

}


