using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzouno;
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
    public class ComzounoBandaMusicoComzounoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        BandaMusicoComzouno bandaMusicoComzounoBL = new();
        TipoComision tipoComisionBL = new();
        Evento eventoBL = new();
        EntidadSolicitante entidadSolicitanteBL = new();
        GrupoComisionado grupoComisionadoBL = new();
        VestimentaUniforme vestimentaUniformeBL = new();
        Carga cargaBL = new();

        public ComzounoBandaMusicoComzounoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Banda de Musico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoComisionDTO> tipoComisionDTO = tipoComisionBL.ObtenerTipoComisions();
            List<EventoDTO> eventoDTO = eventoBL.ObtenerEventos();
            List<EntidadSolicitanteDTO> entidadSolicitanteDTO = entidadSolicitanteBL.ObtenerEntidadSolicitantes();
            List<GrupoComisionadoDTO> grupoComisionadoDTO = grupoComisionadoBL.ObtenerGrupoComisionados();
            List<VestimentaUniformeDTO> vestimentaUniformeDTO = vestimentaUniformeBL.ObtenerVestimentaUniformes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("BandaMusicoComzouno");

            return Json(new
            {
                data1 = tipoComisionDTO,
                data2 = eventoDTO,
                data3 = entidadSolicitanteDTO,
                data4 = grupoComisionadoDTO,
                data5 = vestimentaUniformeDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<BandaMusicoComzounoDTO> bandaMusicoComzounoDTO = bandaMusicoComzounoBL.ObtenerLista();
            return Json(new { data = bandaMusicoComzounoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoTipoComision, string CodigoEvento, string SolicitudDocumentoRef,
            string CodigoEntidadSolicitante, string CodigoGrupoComisionado, string CodigoVestimentaUniforme, string NombreEvento, 
            string Lugar, string FechaHoraSalida, string FechaHoraInicio, string FechaHoraTermino, string RequerimientoMovilidad, 
            string Observacion, int CargaId, string Fecha)
        {
            BandaMusicoComzounoDTO bandaMusicoComzounoDTO = new();
            bandaMusicoComzounoDTO.CodigoTipoComision = CodigoTipoComision;
            bandaMusicoComzounoDTO.CodigoEvento = CodigoEvento;
            bandaMusicoComzounoDTO.SolicitudDocumentoRef = SolicitudDocumentoRef;
            bandaMusicoComzounoDTO.CodigoEntidadSolicitante = CodigoEntidadSolicitante;
            bandaMusicoComzounoDTO.CodigoGrupoComisionado = CodigoGrupoComisionado;
            bandaMusicoComzounoDTO.CodigoVestimentaUniforme = CodigoVestimentaUniforme;
            bandaMusicoComzounoDTO.NombreEvento = NombreEvento;
            bandaMusicoComzounoDTO.Lugar = Lugar;
            bandaMusicoComzounoDTO.FechaHoraSalida = FechaHoraSalida;
            bandaMusicoComzounoDTO.FechaHoraInicio = FechaHoraInicio;
            bandaMusicoComzounoDTO.FechaHoraTermino = FechaHoraTermino;
            bandaMusicoComzounoDTO.RequerimientoMovilidad = RequerimientoMovilidad;
            bandaMusicoComzounoDTO.Observacion = Observacion;
            bandaMusicoComzounoDTO.CargaId = CargaId;
            bandaMusicoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = bandaMusicoComzounoBL.AgregarRegistro(bandaMusicoComzounoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(bandaMusicoComzounoBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int BandaMusicoComzounoId, string CodigoTipoComision, string CodigoEvento, string SolicitudDocumentoRef,
            string CodigoEntidadSolicitante, string CodigoGrupoComisionado, string CodigoVestimentaUniforme, string NombreEvento, 
            string Lugar, string FechaHoraSalida, string FechaHoraInicio, string FechaHoraTermino, string RequerimientoMovilidad, 
            string Observacion)
        {
            BandaMusicoComzounoDTO bandaMusicoComzounoDTO = new();
            bandaMusicoComzounoDTO.BandaMusicoComzounoId = BandaMusicoComzounoId;
            bandaMusicoComzounoDTO.CodigoTipoComision = CodigoTipoComision;
            bandaMusicoComzounoDTO.CodigoEvento = CodigoEvento;
            bandaMusicoComzounoDTO.SolicitudDocumentoRef = SolicitudDocumentoRef;
            bandaMusicoComzounoDTO.CodigoEntidadSolicitante = CodigoEntidadSolicitante;
            bandaMusicoComzounoDTO.CodigoGrupoComisionado = CodigoGrupoComisionado;
            bandaMusicoComzounoDTO.CodigoVestimentaUniforme = CodigoVestimentaUniforme;
            bandaMusicoComzounoDTO.NombreEvento = NombreEvento;
            bandaMusicoComzounoDTO.Lugar = Lugar;
            bandaMusicoComzounoDTO.FechaHoraSalida = FechaHoraSalida;
            bandaMusicoComzounoDTO.FechaHoraInicio = FechaHoraInicio;
            bandaMusicoComzounoDTO.FechaHoraTermino = FechaHoraTermino;
            bandaMusicoComzounoDTO.RequerimientoMovilidad = RequerimientoMovilidad;
            bandaMusicoComzounoDTO.Observacion = Observacion;
            bandaMusicoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = bandaMusicoComzounoBL.ActualizarFormato(bandaMusicoComzounoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            BandaMusicoComzounoDTO bandaMusicoComzounoDTO = new();
            bandaMusicoComzounoDTO.BandaMusicoComzounoId = Id;
            bandaMusicoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (bandaMusicoComzounoBL.EliminarFormato(bandaMusicoComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            BandaMusicoComzounoDTO bandaMusicoComzounoDTO = new();
            bandaMusicoComzounoDTO.CargaId = Id;
            bandaMusicoComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (bandaMusicoComzounoBL.EliminarCarga(bandaMusicoComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<BandaMusicoComzounoDTO> lista = new List<BandaMusicoComzounoDTO>();
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

                    lista.Add(new BandaMusicoComzounoDTO
                    {
                        CodigoTipoComision = fila.GetCell(0).ToString(),
                        CodigoEvento = fila.GetCell(1).ToString(),
                        SolicitudDocumentoRef = fila.GetCell(2).ToString(),
                        CodigoEntidadSolicitante = fila.GetCell(3).ToString(),
                        CodigoGrupoComisionado = fila.GetCell(4).ToString(),
                        CodigoVestimentaUniforme = fila.GetCell(5).ToString(),
                        NombreEvento = fila.GetCell(6).ToString(),
                        Lugar = fila.GetCell(7).ToString(),
                        FechaHoraSalida = fila.GetCell(8).ToString(),
                        FechaHoraInicio = fila.GetCell(9).ToString(),
                        FechaHoraTermino = fila.GetCell(10).ToString(),
                        RequerimientoMovilidad = fila.GetCell(11).ToString(),
                        Observacion = fila.GetCell(12).ToString()
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

            dt.Columns.AddRange(new DataColumn[14]
            {
                    new DataColumn("CodigoTipoComision", typeof(string)),
                    new DataColumn("CodigoEvento", typeof(string)),
                    new DataColumn("SolicitudDocumentoRef", typeof(string)),
                    new DataColumn("CodigoEntidadSolicitante", typeof(string)),
                    new DataColumn("CodigoGrupoComisionado", typeof(string)),
                    new DataColumn("CodigoVestimentaUniforme", typeof(string)),
                    new DataColumn("NombreEvento", typeof(string)),
                    new DataColumn("Lugar", typeof(string)),
                    new DataColumn("FechaHoraSalida", typeof(string)),
                    new DataColumn("FechaHoraInicio", typeof(string)),
                    new DataColumn("FechaHoraTermino", typeof(string)),
                    new DataColumn("RequerimientoMovilidad", typeof(string)),
                    new DataColumn("Observacion", typeof(string)),
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
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(8).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(9).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(10).ToString()),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = bandaMusicoComzounoBL.InsertarDatos(dt, Fecha);
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
            var Capitanias = bandaMusicoComzounoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzounoBandaMusicoComzouno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzounoBandaMusicoComzouno.xlsx");
        }
    }

}