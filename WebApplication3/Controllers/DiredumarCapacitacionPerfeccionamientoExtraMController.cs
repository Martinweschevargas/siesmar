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
    public class DiredumarCapacitacionPerfeccionamientoExtraMController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        CapacitacionPerfeccionamientoExtraM capacitacionPerfeccionamientoExtraMBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        PaisUbigeo paisUbigeoBL = new();
        NivelEstudio nivelEstudioBL = new();
        InstitucionEducativaSuperior institucionEducativaSBL = new();
        Carga cargaBL = new();

        public DiredumarCapacitacionPerfeccionamientoExtraMController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Capacitación y Perfeccionamiento Extra Institucional del Personal Militar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<NivelEstudioDTO> nivelEstudioDTO = nivelEstudioBL.ObtenerNivelEstudios();
            List<InstitucionEducativaSuperiorDTO> institucionEducativaSDTO = institucionEducativaSBL.ObtenerInstitucionEducativaSuperiors();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CapacitacionPerfeccionamientoExtraM");
            return Json(new
            {
                data1 = tipoPersonalMilitarDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = paisUbigeoDTO,
                data4 = nivelEstudioDTO,
                data5 = institucionEducativaSDTO,
                data6 = listaCargas,

            });
        }

        public IActionResult CargaTabla()
        {
            List<CapacitacionPerfeccionamientoExtraMDTO> select = capacitacionPerfeccionamientoExtraMBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CIPCapPerf, string DNICapPerf, string CodigoGradoPersonalMilitar, string CodigoNivelEstudio,
            string NumericoPais, string CodigoTipoPersonalMilitar, string CodigoInstitucionEducativaSuperior, string MensionCapacitacion, 
            string FinanciamientoCapacitacion, int CargaId, string Fecha)
        {
            CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO = new();
            capacitacionPerfeccionamientoExtraMDTO.CIPCapaPerf = CIPCapPerf;
            capacitacionPerfeccionamientoExtraMDTO.DNICapaPerf = DNICapPerf;
            capacitacionPerfeccionamientoExtraMDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            capacitacionPerfeccionamientoExtraMDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            capacitacionPerfeccionamientoExtraMDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            capacitacionPerfeccionamientoExtraMDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            capacitacionPerfeccionamientoExtraMDTO.MencionCapacitacion = MensionCapacitacion;
            capacitacionPerfeccionamientoExtraMDTO.FinanciamientoCapacitacion = FinanciamientoCapacitacion;
            capacitacionPerfeccionamientoExtraMDTO.NumericoPais = NumericoPais;
            capacitacionPerfeccionamientoExtraMDTO.CargaId = CargaId;
            capacitacionPerfeccionamientoExtraMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionPerfeccionamientoExtraMBL.AgregarRegistro(capacitacionPerfeccionamientoExtraMDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(capacitacionPerfeccionamientoExtraMBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CIPCapPerf, string DNICapPerf, string CodigoGradoPersonalMilitar, string CodigoNivelEstudio,
            string NumericoPais, string CodigoTipoPersonalMilitar, string CodigoInstitucionEducativaSuperior, string MensionCapacitacion,
            string FinanciamientoCapacitacion)
        {
            CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO = new();
            capacitacionPerfeccionamientoExtraMDTO.CapacitacionPerfeccionamientoExtraMId = Id;
            capacitacionPerfeccionamientoExtraMDTO.CIPCapaPerf = CIPCapPerf;
            capacitacionPerfeccionamientoExtraMDTO.DNICapaPerf = DNICapPerf;
            capacitacionPerfeccionamientoExtraMDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            capacitacionPerfeccionamientoExtraMDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            capacitacionPerfeccionamientoExtraMDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            capacitacionPerfeccionamientoExtraMDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            capacitacionPerfeccionamientoExtraMDTO.MencionCapacitacion = MensionCapacitacion;
            capacitacionPerfeccionamientoExtraMDTO.FinanciamientoCapacitacion = FinanciamientoCapacitacion;
            capacitacionPerfeccionamientoExtraMDTO.NumericoPais = NumericoPais;
            capacitacionPerfeccionamientoExtraMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionPerfeccionamientoExtraMBL.ActualizarFormato(capacitacionPerfeccionamientoExtraMDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int id)
        {
            string mensaje = "";
            CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO = new();
            capacitacionPerfeccionamientoExtraMDTO.CapacitacionPerfeccionamientoExtraMId = id;
            capacitacionPerfeccionamientoExtraMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionPerfeccionamientoExtraMBL.EliminarFormato(capacitacionPerfeccionamientoExtraMDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            CapacitacionPerfeccionamientoExtraMDTO capacitacionPerfeccionamientoExtraMDTO = new();
            capacitacionPerfeccionamientoExtraMDTO.CargaId = Id;
            capacitacionPerfeccionamientoExtraMDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionPerfeccionamientoExtraMBL.EliminarCarga(capacitacionPerfeccionamientoExtraMDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CapacitacionPerfeccionamientoExtraMDTO> lista = new List<CapacitacionPerfeccionamientoExtraMDTO>();
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

                    lista.Add(new CapacitacionPerfeccionamientoExtraMDTO
                    {
                        CIPCapaPerf = fila.GetCell(0).ToString(),
                        DNICapaPerf = fila.GetCell(1).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(2).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoNivelEstudio =  fila.GetCell(4).ToString(),
                        CodigoInstitucionEducativaSuperior = fila.GetCell(5).ToString(),
                        MencionCapacitacion = fila.GetCell(6).ToString(),
                        FinanciamientoCapacitacion = fila.GetCell(7).ToString(),
                        NumericoPais = fila.GetCell(8).ToString()
                    });
                }
            }
            catch (Exception)
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
                    new DataColumn("CIPCapaPerf", typeof(string)),
                    new DataColumn("DNICapaPerf", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoNivelEstudio", typeof(string)),
                    new DataColumn("CodigoInstitucionEducativaSuperior", typeof(string)),
                    new DataColumn("MensionCapacitacion", typeof(string)),
                    new DataColumn("FinanciamientoCapacitacion", typeof(string)),
                    new DataColumn("NumericoPais ", typeof(string)),
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
                    fila.GetCell(8).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = capacitacionPerfeccionamientoExtraMBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDCPESUB(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diredumar\\CapacitacionPerfeccionamientoExtraPSubalterno.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capacitacionPerfeccionamientoExtra = capacitacionPerfeccionamientoExtraMBL.DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPSubalterno(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("CapacitacionPerfeccionamientoExtraPSubalterno", capacitacionPerfeccionamientoExtra);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiredumarCapacitacionPerfeccionamientoExtraM.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiredumarCapacitacionPerfeccionamientoExtraM.xlsx");
        }

    }

}