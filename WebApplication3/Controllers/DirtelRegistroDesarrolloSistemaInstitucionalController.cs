using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirtel;
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
    public class DirtelRegistroDesarrolloSistemaInstitucionalController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroDesarrolloSistemaInstitucional registroDesarrolloSistemaInstitucionalBL = new();
        AreaSatisfaceDirtel areaSatisfaceDirtelBL = new();
        CicloDesarrolloSoftware cicloDesarrolloSoftwareBL = new();
        DenominacionBaseDato denominacionBaseDatoBL = new();
        DenominacionLenguajeProgramacion denominacionLenguajeProgramacionBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public DirtelRegistroDesarrolloSistemaInstitucionalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Desarrollos Sistemas Institucionales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaSatisfaceDirtelDTO> areaSatisfaceDirtelDTO = areaSatisfaceDirtelBL.ObtenerAreaSatisfaceDirtels();
            List<CicloDesarrolloSoftwareDTO> cicloDesarrolloSoftwareDTO = cicloDesarrolloSoftwareBL.ObtenerCicloDesarrolloSoftwares();
            List<DenominacionBaseDatoDTO> denominacionBaseDatoDTO = denominacionBaseDatoBL.ObtenerDenominacionBaseDatos();
            List<DenominacionLenguajeProgramacionDTO> denominacionLenguajeProgramacionDTO = denominacionLenguajeProgramacionBL.ObtenerDenominacionLenguajeProgramacions();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroDesarrolloSistemaInstitucional");

            return Json(new
            {
                data1 = areaSatisfaceDirtelDTO,
                data2 = cicloDesarrolloSoftwareDTO,
                data3 = denominacionBaseDatoDTO,
                data4 = denominacionLenguajeProgramacionDTO,
                data5 = dependenciaDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroDesarrolloSistemaInstitucionalDTO> registroDesarrolloSistemaInstitucionalDTO = registroDesarrolloSistemaInstitucionalBL.ObtenerLista();
            return Json(new { data = registroDesarrolloSistemaInstitucionalDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string SiglaSoftware, string CodigoAreaSatisfaceDirtel, string DescripcionFuncionalidad,
            string CodigoCicloDesarrolloSoftware, string NombreSistema, string ServicioWeb, string ModalidadDesarrollo,
            string CodigoDenominacionBaseDato , string FechaDesarrollo, string AlcanceSistemaInstitucional, string ServidorWeb, string FechaPuestaProduccion, 
            string AvanceDesarrollo, string CodigoDenominacionLenguajeProgramacion, string CodigoDependencia, string ServidorBD, int CargaId)
        {

            RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO = new();
            registroDesarrolloSistemaInstitucionalDTO.NombreSistema = NombreSistema;
            registroDesarrolloSistemaInstitucionalDTO.SiglaSoftware = SiglaSoftware;
            registroDesarrolloSistemaInstitucionalDTO.CodigoAreaSatisfaceDirtel = CodigoAreaSatisfaceDirtel;
            registroDesarrolloSistemaInstitucionalDTO.DescripcionFuncionalidad = DescripcionFuncionalidad;
            registroDesarrolloSistemaInstitucionalDTO.FechaDesarrollo = FechaDesarrollo;
            registroDesarrolloSistemaInstitucionalDTO.CodigoCicloDesarrolloSoftware = CodigoCicloDesarrolloSoftware;
            registroDesarrolloSistemaInstitucionalDTO.AvanceDesarrollo = AvanceDesarrollo;
            registroDesarrolloSistemaInstitucionalDTO.ServicioWeb = ServicioWeb;
            registroDesarrolloSistemaInstitucionalDTO.AlcanceSistemaInstitucional = AlcanceSistemaInstitucional;
            registroDesarrolloSistemaInstitucionalDTO.ModalidadDesarrollo = ModalidadDesarrollo;
            registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionBaseDato = CodigoDenominacionBaseDato;
            registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionLenguajeProgramacion = CodigoDenominacionLenguajeProgramacion;
            registroDesarrolloSistemaInstitucionalDTO.ServidorWeb = ServidorWeb;
            registroDesarrolloSistemaInstitucionalDTO.CodigoDependencia = CodigoDependencia;
            registroDesarrolloSistemaInstitucionalDTO.FechaPuestaProduccion = FechaPuestaProduccion;
            registroDesarrolloSistemaInstitucionalDTO.ServidorBD = ServidorBD;
            registroDesarrolloSistemaInstitucionalDTO.CargaId = CargaId;
            registroDesarrolloSistemaInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();


            var IND_OPERACION = registroDesarrolloSistemaInstitucionalBL.AgregarRegistro(registroDesarrolloSistemaInstitucionalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroDesarrolloSistemaInstitucionalBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int RegistroDesarrolloSistemaInstitucionalId, string SiglaSoftware, string CodigoAreaSatisfaceDirtel, string DescripcionFuncionalidad,
            string CodigoCicloDesarrolloSoftware, string NombreSistema, string ServicioWeb, string ModalidadDesarrollo,
            string CodigoDenominacionBaseDato, string FechaDesarrollo, string AlcanceSistemaInstitucional, string ServidorWeb, string FechaPuestaProduccion,
            string AvanceDesarrollo, string CodigoDenominacionLenguajeProgramacion, string CodigoDependencia, string ServidorBD)
        {
            RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO = new();
            registroDesarrolloSistemaInstitucionalDTO.RegistroDesarrolloSistemaInstitucionalId = RegistroDesarrolloSistemaInstitucionalId;
            registroDesarrolloSistemaInstitucionalDTO.NombreSistema = NombreSistema;
            registroDesarrolloSistemaInstitucionalDTO.SiglaSoftware = SiglaSoftware;
            registroDesarrolloSistemaInstitucionalDTO.CodigoAreaSatisfaceDirtel = CodigoAreaSatisfaceDirtel;
            registroDesarrolloSistemaInstitucionalDTO.DescripcionFuncionalidad = DescripcionFuncionalidad;
            registroDesarrolloSistemaInstitucionalDTO.FechaDesarrollo = FechaDesarrollo;
            registroDesarrolloSistemaInstitucionalDTO.CodigoCicloDesarrolloSoftware = CodigoCicloDesarrolloSoftware;
            registroDesarrolloSistemaInstitucionalDTO.AvanceDesarrollo = AvanceDesarrollo;
            registroDesarrolloSistemaInstitucionalDTO.ServicioWeb = ServicioWeb;
            registroDesarrolloSistemaInstitucionalDTO.AlcanceSistemaInstitucional = AlcanceSistemaInstitucional;
            registroDesarrolloSistemaInstitucionalDTO.ModalidadDesarrollo = ModalidadDesarrollo;
            registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionBaseDato = CodigoDenominacionBaseDato;
            registroDesarrolloSistemaInstitucionalDTO.CodigoDenominacionLenguajeProgramacion = CodigoDenominacionLenguajeProgramacion;
            registroDesarrolloSistemaInstitucionalDTO.ServidorWeb = ServidorWeb;
            registroDesarrolloSistemaInstitucionalDTO.CodigoDependencia = CodigoDependencia;
            registroDesarrolloSistemaInstitucionalDTO.FechaPuestaProduccion = FechaPuestaProduccion;
            registroDesarrolloSistemaInstitucionalDTO.ServidorBD = ServidorBD;
            registroDesarrolloSistemaInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroDesarrolloSistemaInstitucionalBL.ActualizarFormato(registroDesarrolloSistemaInstitucionalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO = new();
            registroDesarrolloSistemaInstitucionalDTO.RegistroDesarrolloSistemaInstitucionalId = Id;
            registroDesarrolloSistemaInstitucionalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroDesarrolloSistemaInstitucionalBL.EliminarFormato(registroDesarrolloSistemaInstitucionalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroDesarrolloSistemaInstitucionalDTO> lista = new List<RegistroDesarrolloSistemaInstitucionalDTO>();
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

                    lista.Add(new RegistroDesarrolloSistemaInstitucionalDTO
                    {
                        NombreSistema = fila.GetCell(0).ToString(),
                        SiglaSoftware = fila.GetCell(1).ToString(),
                        CodigoAreaSatisfaceDirtel = fila.GetCell(2).ToString(),
                        DescripcionFuncionalidad = fila.GetCell(3).ToString(),
                        FechaDesarrollo = fila.GetCell(4).ToString(),
                        CodigoCicloDesarrolloSoftware = fila.GetCell(5).ToString(),
                        AvanceDesarrollo = fila.GetCell(6).ToString(),
                        ServicioWeb = fila.GetCell(7).ToString(),
                        AlcanceSistemaInstitucional = fila.GetCell(8).ToString(),
                        ModalidadDesarrollo = fila.GetCell(9).ToString(),
                        CodigoDenominacionBaseDato = fila.GetCell(10).ToString(),
                        CodigoDenominacionLenguajeProgramacion = fila.GetCell(11).ToString(),
                        ServidorWeb = fila.GetCell(12).ToString(),
                        CodigoDependencia = fila.GetCell(13).ToString(),
                        FechaPuestaProduccion = fila.GetCell(14).ToString(),
                        ServidorBD = fila.GetCell(15).ToString(),

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

            dt.Columns.AddRange(new DataColumn[17]
            {
                    new DataColumn("NombreSistema", typeof(string)),
                    new DataColumn("SiglaSoftware", typeof(string)),
                    new DataColumn("CodigoAreaSatisfaceDirtel", typeof(string)),
                    new DataColumn("DescripcionFuncionalidad", typeof(string)),
                    new DataColumn("FechaDesarrollo", typeof(string)),
                    new DataColumn("CodigoCicloDesarrolloSoftware", typeof(string)),
                    new DataColumn("AvanceDesarrollo", typeof(string)),
                    new DataColumn("ServicioWeb ", typeof(string)),
                    new DataColumn("AlcanceSistemaInstitucional ", typeof(string)),
                    new DataColumn("ModalidadDesarrollo ", typeof(string)),
                    new DataColumn("CodigoDenominacionBaseDato ", typeof(string)),
                    new DataColumn("CodigoDenominacionLenguajeProgramacion ", typeof(string)),
                    new DataColumn("ServidorWeb ", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("FechaPuestaProduccion ", typeof(string)),
                    new DataColumn("ServidorBD ", typeof(string)),

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
                   UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                   fila.GetCell(5).ToString(),
                   fila.GetCell(6).ToString(),
                   fila.GetCell(7).ToString(),
                   fila.GetCell(8).ToString(),
                   fila.GetCell(9).ToString(),
                   fila.GetCell(10).ToString(),
                   fila.GetCell(11).ToString(),
                   fila.GetCell(12).ToString(),
                   fila.GetCell(13).ToString(),
                   UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                   fila.GetCell(15).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroDesarrolloSistemaInstitucionalBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDRDSI(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirtel\\RegistroDesarrolloSistemaInstitucional.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = registroDesarrolloSistemaInstitucionalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RegistroDesarrolloSistemaInstitucional", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\RegistroDesarrolloSistemaInstitucional.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "RegistroDesarrolloSistemaInstitucional.xlsx");
        }
    }

}