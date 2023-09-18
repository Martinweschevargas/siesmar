using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavServicioConstruccionInstalacionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ServicioConstruccionInstalacion servicioConstruccionInstalacionBL = new();

        TrabajoSeñalizacionNautica trabajoSeñalizacionNauticaBL = new();
        ZonaNautica zonaNauticaBL = new();
        Carga cargaBL = new();

        public DihidronavServicioConstruccionInstalacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicios de Construcción, Instalación, mantenimiento de señales náuticas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TrabajoSeñalizacionNauticaDTO> trabajoSeñalizacionNauticaDTO = trabajoSeñalizacionNauticaBL.ObtenerTrabajoSeñalizacionNauticas(); 
            List<ZonaNauticaDTO> zonaNauticaDTO = zonaNauticaBL.ObtenerZonaNauticas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioConstruccionInstalacion");


            return Json(new
            {
                data1 = trabajoSeñalizacionNauticaDTO,
                data2 = zonaNauticaDTO,
                data3 = listaCargas,

            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioConstruccionInstalacionDTO> servicioConstruccionInstalacionDTO = servicioConstruccionInstalacionBL.ObtenerLista();
            return Json(new { data = servicioConstruccionInstalacionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string CodigoTrabajoSenializacionNautica, string CodigoZonaNautica, 
            string FechaTermino, string FechaInicio, string DescripcionServicio,  string EstadoServicio,int CargaId)
        {
            ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO = new();
            servicioConstruccionInstalacionDTO.NumeroOrden = NumeroOrden;
            servicioConstruccionInstalacionDTO.CodigoTrabajoSenializacionNautica = CodigoTrabajoSenializacionNautica;
            servicioConstruccionInstalacionDTO.DescripcionServicio = DescripcionServicio;
            servicioConstruccionInstalacionDTO.FechaInicio = FechaInicio;
            servicioConstruccionInstalacionDTO.FechaTermino = FechaTermino;
            servicioConstruccionInstalacionDTO.CodigoZonaNautica = CodigoZonaNautica;
            servicioConstruccionInstalacionDTO.EstadoServicio = EstadoServicio;
            servicioConstruccionInstalacionDTO.CargaId = CargaId;
            servicioConstruccionInstalacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioConstruccionInstalacionBL.AgregarRegistro(servicioConstruccionInstalacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioConstruccionInstalacionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ServicioConstruccionInstalacionId, int NumeroOrden, string CodigoTrabajoSenializacionNautica, string CodigoZonaNautica,
            string FechaTermino, string FechaInicio, string DescripcionServicio, string EstadoServicio)
        {
            ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO = new();
            servicioConstruccionInstalacionDTO.ServicioConstruccionInstalacionId = ServicioConstruccionInstalacionId;
            servicioConstruccionInstalacionDTO.NumeroOrden = NumeroOrden;
            servicioConstruccionInstalacionDTO.CodigoTrabajoSenializacionNautica = CodigoTrabajoSenializacionNautica;
            servicioConstruccionInstalacionDTO.DescripcionServicio = DescripcionServicio;
            servicioConstruccionInstalacionDTO.FechaInicio = FechaInicio;
            servicioConstruccionInstalacionDTO.FechaTermino = FechaTermino;
            servicioConstruccionInstalacionDTO.CodigoZonaNautica = CodigoZonaNautica;
            servicioConstruccionInstalacionDTO.EstadoServicio = EstadoServicio;
            servicioConstruccionInstalacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioConstruccionInstalacionBL.ActualizarFormato(servicioConstruccionInstalacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO = new();
            servicioConstruccionInstalacionDTO.ServicioConstruccionInstalacionId = Id;
            servicioConstruccionInstalacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioConstruccionInstalacionBL.EliminarFormato(servicioConstruccionInstalacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioConstruccionInstalacionDTO> lista = new List<ServicioConstruccionInstalacionDTO>();
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

                    lista.Add(new ServicioConstruccionInstalacionDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        CodigoTrabajoSenializacionNautica = fila.GetCell(1).ToString(),
                        DescripcionServicio = fila.GetCell(2).ToString(),
                        FechaInicio = fila.GetCell(3).ToString(),
                        FechaTermino = fila.GetCell(4).ToString(),
                        CodigoZonaNautica = fila.GetCell(5).ToString(),
                        EstadoServicio = fila.GetCell(6).ToString()
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("CodigoTrabajoSenializacionNautica", typeof(string)),
                    new DataColumn("DescripcionServicio", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("CodigoZonaNautica", typeof(string)),
                    new DataColumn("EstadoServicio", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioConstruccionInstalacionBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }


        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }



        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavServicioConstruccionInstalacion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavServicioConstruccionInstalacion.xlsx");
        }
    }

}