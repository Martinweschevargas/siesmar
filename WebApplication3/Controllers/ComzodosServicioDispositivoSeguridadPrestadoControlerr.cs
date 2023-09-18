using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzodos;
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
    public class ComzodosServicioDispositivoSeguridadPrestadoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ServicioDispositivoSeguridadPrestado servicioDispositivoSeguridadPrestadoBL = new();
        ZonaNaval zonaNavalBL = new();
        Dependencia dependenciaBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public ComzodosServicioDispositivoSeguridadPrestadoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicios de Dispositivos de Seguridad Prestados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioDispositivoSeguridadPrestado");

            return Json(new
            {
                data1 = zonaNavalDTO,
                data2 = dependenciaDTO,
                data3 = distritoUbigeoDTO,
                data4= listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioDispositivoSeguridadPrestadoDTO> servicioDispositivoSeguridadPrestadoDTO = servicioDispositivoSeguridadPrestadoBL.ObtenerLista();
            return Json(new { data = servicioDispositivoSeguridadPrestadoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoZonaNaval, int EfectivoParticipante, string CodigoDependencia,
            string FechaSolicitud, string FechaHoraInicio, string Lugar,string DistritoUbigeo, 
            string FechaHoraTermino, string ObservacionServicioDispositivo, int ComisionPorMes, int CargaId, string Fecha)
        {
            ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO = new();
            servicioDispositivoSeguridadPrestadoDTO.FechaSolicitud = FechaSolicitud;
            servicioDispositivoSeguridadPrestadoDTO.CodigoZonaNaval = CodigoZonaNaval;
            servicioDispositivoSeguridadPrestadoDTO.CodigoDependencia = CodigoDependencia;
            servicioDispositivoSeguridadPrestadoDTO.FechaHoraInicio = FechaHoraInicio;
            servicioDispositivoSeguridadPrestadoDTO.FechaHoraTermino = FechaHoraTermino;
            servicioDispositivoSeguridadPrestadoDTO.EfectivoParticipante = EfectivoParticipante;
            servicioDispositivoSeguridadPrestadoDTO.Lugar = Lugar;
            servicioDispositivoSeguridadPrestadoDTO.DistritoUbigeo = DistritoUbigeo;
            servicioDispositivoSeguridadPrestadoDTO.ObservacionServicioDispositivo = ObservacionServicioDispositivo;
            servicioDispositivoSeguridadPrestadoDTO.ComisionPorMes = ComisionPorMes;
            servicioDispositivoSeguridadPrestadoDTO.CargaId = CargaId;
            servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioDispositivoSeguridadPrestadoBL.AgregarRegistro(servicioDispositivoSeguridadPrestadoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioDispositivoSeguridadPrestadoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ServicioDispositivoSeguridadPrestadoId, string CodigoZonaNaval, int EfectivoParticipante, string CodigoDependencia,
            string FechaSolicitud, string FechaHoraInicio, string Lugar, string DistritoUbigeo,
            string FechaHoraTermino, string ObservacionServicioDispositivo, int ComisionPorMes)
        {
            ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO = new();
            servicioDispositivoSeguridadPrestadoDTO.ServicioDispositivoSeguridadPrestadoId = ServicioDispositivoSeguridadPrestadoId;
            servicioDispositivoSeguridadPrestadoDTO.FechaSolicitud = FechaSolicitud;
            servicioDispositivoSeguridadPrestadoDTO.CodigoZonaNaval = CodigoZonaNaval;
            servicioDispositivoSeguridadPrestadoDTO.CodigoDependencia = CodigoDependencia;
            servicioDispositivoSeguridadPrestadoDTO.FechaHoraInicio = FechaHoraInicio;
            servicioDispositivoSeguridadPrestadoDTO.FechaHoraTermino = FechaHoraTermino;
            servicioDispositivoSeguridadPrestadoDTO.EfectivoParticipante = EfectivoParticipante;
            servicioDispositivoSeguridadPrestadoDTO.Lugar = Lugar;
            servicioDispositivoSeguridadPrestadoDTO.DistritoUbigeo = DistritoUbigeo;
            servicioDispositivoSeguridadPrestadoDTO.ObservacionServicioDispositivo = ObservacionServicioDispositivo;
            servicioDispositivoSeguridadPrestadoDTO.ComisionPorMes = ComisionPorMes;
            servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioDispositivoSeguridadPrestadoBL.ActualizarFormato(servicioDispositivoSeguridadPrestadoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO = new();
            servicioDispositivoSeguridadPrestadoDTO.ServicioDispositivoSeguridadPrestadoId = Id;
            servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioDispositivoSeguridadPrestadoBL.EliminarFormato(servicioDispositivoSeguridadPrestadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioDispositivoSeguridadPrestadoDTO servicioDispositivoSeguridadPrestadoDTO = new();
            servicioDispositivoSeguridadPrestadoDTO.CargaId = Id;
            servicioDispositivoSeguridadPrestadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioDispositivoSeguridadPrestadoBL.EliminarCarga(servicioDispositivoSeguridadPrestadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioDispositivoSeguridadPrestadoDTO> lista = new List<ServicioDispositivoSeguridadPrestadoDTO>();
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

                    lista.Add(new ServicioDispositivoSeguridadPrestadoDTO
                    {
                        FechaSolicitud = fila.GetCell(0).ToString(),
                        CodigoZonaNaval = fila.GetCell(1).ToString(),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        FechaHoraInicio = fila.GetCell(3).ToString(),
                        FechaHoraTermino = fila.GetCell(4).ToString(),
                        EfectivoParticipante = int.Parse(fila.GetCell(5).ToString()),
                        Lugar = fila.GetCell(6).ToString(),
                        DistritoUbigeo = fila.GetCell(7).ToString(),
                        ObservacionServicioDispositivo = fila.GetCell(8).ToString(),
                        ComisionPorMes = int.Parse(fila.GetCell(9).ToString())
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("FechaHoraInicio", typeof(string)),
                    new DataColumn("FechaHoraTermino", typeof(string)),
                    new DataColumn("EfectivoParticipante", typeof(int)),
                    new DataColumn("Lugar", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("ObservacionServicioDispositivo", typeof(string)),
                    new DataColumn("ComisionPorMes", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(3).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    int.Parse(fila.GetCell(9).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = servicioDispositivoSeguridadPrestadoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
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

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = servicioDispositivoSeguridadPrestadoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzodosServicioDispositivoSeguridadPrestado.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzodosServicioDispositivoSeguridadPrestado.xlsx");
        }
    }

}