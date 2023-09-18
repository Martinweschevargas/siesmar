using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater;
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

    public class DibinfraterServicioPublicoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ServicioPublico servicioPublicoBL = new();
        Mes mesBL = new();
        FuenteFinanciamiento fuenteFinanciamientoBL = new();
        ZonaNaval zonaNavalBL = new();
        Dependencia dependenciaBL = new();
        TipoServicioPublico tipoServicioPublicoBL = new();
        Carga cargaBL = new();

        public DibinfraterServicioPublicoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicios Públicos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<FuenteFinanciamientoDTO> fuenteFinanciamientoDTO = fuenteFinanciamientoBL.ObtenerFuenteFinanciamientos();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<TipoServicioPublicoDTO> tipoServicioPublicoDTO = tipoServicioPublicoBL.ObtenerCapintanias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioPublico");

            return Json(new
            {
                data1 = mesDTO,
                data2 = fuenteFinanciamientoDTO,
                data3 = zonaNavalDTO,
                data4 = dependenciaDTO,
                data5 = tipoServicioPublicoDTO,
                data6 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ServicioPublicoDTO> select = servicioPublicoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int AnioPagoServicio, string NumericoMes, string CodigoFuenteFinanciamiento, string CodigoZonaNaval, string CodigoDependencia,
            string CodigoTipoServicioPublico, int SuministroUnico, decimal AsignacionMensual, decimal ConsumoMensual, string ConsumoUnidadMedida, int CargaId, string Fecha)
        {
            ServicioPublicoDTO servicioPublicoDTO = new();
            servicioPublicoDTO.AnioPagoServicio = AnioPagoServicio;
            servicioPublicoDTO.NumericoMes = NumericoMes;
            servicioPublicoDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            servicioPublicoDTO.CodigoZonaNaval = CodigoZonaNaval;
            servicioPublicoDTO.CodigoDependencia = CodigoDependencia;
            servicioPublicoDTO.CodigoTipoServicioPublico = CodigoTipoServicioPublico;
            servicioPublicoDTO.SuministroUnico = SuministroUnico;
            servicioPublicoDTO.AsignacionMensual = AsignacionMensual;
            servicioPublicoDTO.ConsumoMensual = ConsumoMensual;
            servicioPublicoDTO.ConsumoUnidadMedida = ConsumoUnidadMedida;
            servicioPublicoDTO.CargaId = CargaId;
            servicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioPublicoBL.AgregarRegistro(servicioPublicoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioPublicoBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioPagoServicio, string NumericoMes, string CodigoFuenteFinanciamiento, string CodigoZonaNaval, string CodigoDependencia,
            string CodigoTipoServicioPublico, int SuministroUnico, decimal AsignacionMensual, decimal ConsumoMensual, string ConsumoUnidadMedida)
        {
            ServicioPublicoDTO servicioPublicoDTO = new();
            servicioPublicoDTO.ServicioPublicoId = Id;
            servicioPublicoDTO.AnioPagoServicio = AnioPagoServicio;
            servicioPublicoDTO.NumericoMes = NumericoMes;
            servicioPublicoDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            servicioPublicoDTO.CodigoZonaNaval = CodigoZonaNaval;
            servicioPublicoDTO.CodigoDependencia = CodigoDependencia;
            servicioPublicoDTO.CodigoTipoServicioPublico = CodigoTipoServicioPublico;
            servicioPublicoDTO.SuministroUnico = SuministroUnico;
            servicioPublicoDTO.AsignacionMensual = AsignacionMensual;
            servicioPublicoDTO.ConsumoMensual = ConsumoMensual;
            servicioPublicoDTO.ConsumoUnidadMedida = ConsumoUnidadMedida;
            servicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioPublicoBL.ActualizarFormato(servicioPublicoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioPublicoDTO servicioPublicoDTO = new();
            servicioPublicoDTO.ServicioPublicoId = Id;
            servicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioPublicoBL.EliminarFormato(servicioPublicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioPublicoDTO servicioPublicoDTO = new();
            servicioPublicoDTO.CargaId = Id;
            servicioPublicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioPublicoBL.EliminarCarga(servicioPublicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioPublicoDTO> lista = new List<ServicioPublicoDTO>();
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

                    lista.Add(new ServicioPublicoDTO
                    {
                        AnioPagoServicio = int.Parse(fila.GetCell(0).ToString()),
                        NumericoMes = fila.GetCell(1).ToString(),
                        CodigoFuenteFinanciamiento = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        CodigoDependencia = fila.GetCell(4).ToString(),
                        CodigoTipoServicioPublico = fila.GetCell(5).ToString(),
                        SuministroUnico = int.Parse(fila.GetCell(6).ToString()),
                        AsignacionMensual = int.Parse(fila.GetCell(7).ToString()),
                        ConsumoMensual = int.Parse(fila.GetCell(8).ToString()),
                        ConsumoUnidadMedida = fila.GetCell(9).ToString()

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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje = "";

            IWorkbook MiExcel = null;

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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("AnioPagoServicio", typeof(int)),
                    new DataColumn("CodigoAccionAnteCiberataque", typeof(string)),
                    new DataColumn("NumericoMes", typeof(string)),
                    new DataColumn("CodigoFuenteFinanciamiento", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(int)),
                    new DataColumn("CodigoTipoServicioPublico", typeof(string)),
                    new DataColumn("SuministroUnico", typeof(int)),
                    new DataColumn("AsignacionMensual", typeof(int)),
                    new DataColumn("ConsumoMensual", typeof(int)),
                    new DataColumn("ConsumoUnidadMedida", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                                   int.Parse(fila.GetCell(0).ToString()),
                                   fila.GetCell(1).ToString(),
                                    fila.GetCell(2).ToString(),
                                     fila.GetCell(3).ToString(),
                                    fila.GetCell(4).ToString(),
                                     fila.GetCell(5).ToString(),
                                    int.Parse(fila.GetCell(6).ToString()),
                                   int.Parse(fila.GetCell(7).ToString()),
                                    int.Parse(fila.GetCell(8).ToString()),
                                     fila.GetCell(9).ToString(),
                                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioPublicoBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = servicioPublicoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DibinfraterServicioPublico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DibinfraterServicioPublico.xlsx");
        }

    }

}

