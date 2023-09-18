using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Centac;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class CentacUsoSalaConferenciaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        LogicaNegocios.Formatos.Centac.UsoSalaConferencia usoSalaConferenciaBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public CentacUsoSalaConferenciaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Uso de la Sala de Conferencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("UsoSalaConferencia");

            return Json(new { 
                data1 = dependenciaDTO, 
                data2 = listaCargas 
            });
        }

        public IActionResult CargaTabla()
        {
            List<UsoSalaConferenciaDTO> select = usoSalaConferenciaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoDependencia, string FechaUsoSala, string TipoConferencia,
            int NumeroParticipante, int CargaId, string Fecha)
        {
            UsoSalaConferenciaDTO usoSalaConferenciaDTO = new();
            usoSalaConferenciaDTO.CodigoDependencia = CodigoDependencia;
            usoSalaConferenciaDTO.FechaUsoSala = FechaUsoSala;
            usoSalaConferenciaDTO.TipoConferencia = TipoConferencia;
            usoSalaConferenciaDTO.NumeroParticipante = NumeroParticipante;
            usoSalaConferenciaDTO.CargaId = CargaId;
            usoSalaConferenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usoSalaConferenciaBL.AgregarRegistro(usoSalaConferenciaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(usoSalaConferenciaBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoDependencia, string FechaUsoSala, 
            string TipoConferencia, int NumeroParticipante)
        {
            UsoSalaConferenciaDTO usoSalaConferenciaDTO = new();
            usoSalaConferenciaDTO.UsoSalaConferenciaId = Id;
            usoSalaConferenciaDTO.CodigoDependencia = CodigoDependencia;
            usoSalaConferenciaDTO.FechaUsoSala = FechaUsoSala;
            usoSalaConferenciaDTO.TipoConferencia = TipoConferencia;
            usoSalaConferenciaDTO.NumeroParticipante = NumeroParticipante;
            usoSalaConferenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usoSalaConferenciaBL.ActualizarFormato(usoSalaConferenciaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            UsoSalaConferenciaDTO usoSalaConferenciaDTO = new();
            usoSalaConferenciaDTO.UsoSalaConferenciaId = Id;
            usoSalaConferenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (usoSalaConferenciaBL.EliminarFormato(usoSalaConferenciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            UsoSalaConferenciaDTO usoSalaConferenciaDTO = new();
            usoSalaConferenciaDTO.CargaId = Id;
            usoSalaConferenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (usoSalaConferenciaBL.EliminarCarga(usoSalaConferenciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<UsoSalaConferenciaDTO> lista = new List<UsoSalaConferenciaDTO>();
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

                    lista.Add(new UsoSalaConferenciaDTO
                    {
                        CodigoDependencia = fila.GetCell(0).ToString(),
                        FechaUsoSala = fila.GetCell(1).ToString(),
                        TipoConferencia = fila.GetCell(2).ToString(),
                        NumeroParticipante = int.Parse(fila.GetCell(3).ToString()),
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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("FechaUsoSala", typeof(string)),
                    new DataColumn("TipoConferencia", typeof(string)),
                    new DataColumn("NumeroParticipante", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = usoSalaConferenciaBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }


        public IActionResult ReporteCUSC(int CargaId)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Centac\\UsoSalaConferencia.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var alquilerAreaCentroEsparcimientoS = usoSalaConferenciaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("UsoSalaConferencia", alquilerAreaCentroEsparcimientoS);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\CentacUsoSalaConferencia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "CentacUsoSalaConferencia.xlsx");
        }
    }

}
