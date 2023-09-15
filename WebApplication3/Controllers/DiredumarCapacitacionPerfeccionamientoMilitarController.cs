using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diredumar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DiredumarCapacitacionPerfeccionamientoMilitarController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        CapacitacionPerfeccionamientoMilitar capacitacionPerfecMilitarBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        PaisUbigeo paisUbigeoBL = new();
        EntidadMilitar entidadMilitarBL = new();
        CodigoEscuela codigoEscuelaBL = new();
        Carga cargaBL = new();

        public DiredumarCapacitacionPerfeccionamientoMilitarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Capacitación y Perfeccionamiento Institucional del Personal Militar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadMilitarBL.ObtenerEntidadMilitars();
            List<CodigoEscuelaDTO> codigoEscuelaDTO = codigoEscuelaBL.ObtenerCodigoEscuelas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CapacitacionPerfeccionamientoMilitar");

            return Json(new {  data1 = tipoPersonalMilitarDTO, data2 = gradoPersonalMilitarDTO, data3 = paisUbigeoDTO, data4 = entidadMilitarDTO, 
                data5 = codigoEscuelaDTO, data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<CapacitacionPerfeccionamientoMilitarDTO> select = capacitacionPerfecMilitarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string CIPCapPerf, string DNICapPerf, string CodigoTipoPersonalMilitar, 
            string CodigoGradoPersonalMilitar, string NumericoPais, string CodigoEntidadMilitar, string CodigoEscuela, 
            string MensionCurso, int HorasCurso, int CargaId, string Fecha)
        {
            CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO = new();
            capacitacionPerfecMilitarDTO.CIPCapPerf = CIPCapPerf;
            capacitacionPerfecMilitarDTO.DNICapPerf = DNICapPerf;
            capacitacionPerfecMilitarDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            capacitacionPerfecMilitarDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            capacitacionPerfecMilitarDTO.NumericoPais = NumericoPais;
            capacitacionPerfecMilitarDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            capacitacionPerfecMilitarDTO.CodigoCodigoEscuela = CodigoEscuela;
            capacitacionPerfecMilitarDTO.MensionCurso = MensionCurso;
            capacitacionPerfecMilitarDTO.HorasCurso = HorasCurso;
            capacitacionPerfecMilitarDTO.CargaId = CargaId;
            capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionPerfecMilitarBL.AgregarRegistro(capacitacionPerfecMilitarDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(capacitacionPerfecMilitarBL.EditarFormado(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id , string CIPCapPerf, string DNICapPerf, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, string NumericoPais, string CodigoEntidadMilitar, string CodigoEscuela,
            string MensionCurso, int HorasCurso)
        {
            CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO = new();
            capacitacionPerfecMilitarDTO.CapacitacionPerfeccionamientoMilitarId = Id;
            capacitacionPerfecMilitarDTO.CIPCapPerf = CIPCapPerf;
            capacitacionPerfecMilitarDTO.DNICapPerf = DNICapPerf;
            capacitacionPerfecMilitarDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            capacitacionPerfecMilitarDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            capacitacionPerfecMilitarDTO.NumericoPais = NumericoPais;
            capacitacionPerfecMilitarDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            capacitacionPerfecMilitarDTO.CodigoCodigoEscuela = CodigoEscuela;
            capacitacionPerfecMilitarDTO.MensionCurso = MensionCurso;
            capacitacionPerfecMilitarDTO.HorasCurso = HorasCurso;
            capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionPerfecMilitarBL.ActualizarFormato(capacitacionPerfecMilitarDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO = new();
            capacitacionPerfecMilitarDTO.CapacitacionPerfeccionamientoMilitarId = Id;
            capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionPerfecMilitarBL.EliminarFormato(capacitacionPerfecMilitarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            CapacitacionPerfeccionamientoMilitarDTO capacitacionPerfecMilitarDTO = new();
            capacitacionPerfecMilitarDTO.CargaId = Id;
            capacitacionPerfecMilitarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionPerfecMilitarBL.EliminarCarga(capacitacionPerfecMilitarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CapacitacionPerfeccionamientoMilitarDTO> lista = new List<CapacitacionPerfeccionamientoMilitarDTO>();
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

                    lista.Add(new CapacitacionPerfeccionamientoMilitarDTO
                    {
                        CIPCapPerf = fila.GetCell(0).ToString(),
                        DNICapPerf = fila.GetCell(1).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(2).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(3).ToString(),
                        NumericoPais = fila.GetCell(4).ToString(),
                        CodigoEntidadMilitar = fila.GetCell(5).ToString(),
                        CodigoCodigoEscuela = fila.GetCell(6).ToString(),
                        MensionCurso = fila.GetCell(7).ToString(),
                        HorasCurso = int.Parse(fila.GetCell(8).ToString())
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
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CIPCapPerf", typeof(string)),
                    new DataColumn("DNICapPerf", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoEscuela", typeof(string)),
                    new DataColumn("MensionCurso", typeof(string)),
                    new DataColumn("HorasCurso", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = capacitacionPerfecMilitarBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDCPMSUP(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diredumar\\CapacitacionPerfeccionamientoMilitarPSuperior.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capacitacionPerfecMilitar = capacitacionPerfecMilitarBL.DiredumarVisualizacionCapacitacionPerfeccionamientoMilitarPSuperior(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("CapacitacionPerfeccionamientoMilitarPSuperior", capacitacionPerfecMilitar);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiredumarCapacitacionPerfeccionamientoMilitar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiredumarCapacitacionPerfeccionamientoMilitar.xlsx");
        }

    }

}