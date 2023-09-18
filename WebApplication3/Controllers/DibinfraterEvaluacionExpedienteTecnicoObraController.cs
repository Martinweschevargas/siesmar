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

    public class DibinfraterEvaluacionExpedienteTecnicoObraController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionExpedienteTecnicoObra evaluacionExpedienteTecnicoObraBL = new();
        SituacionExpedienteTecnico situacionExpedienteTecnicoBL = new();
        TipoProceso tipoProcesoBL = new();
        TipoProyecto tipoProyectoBL=new();
        ZonaNaval zonaNavalBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        Carga cargaBL = new();

        public DibinfraterEvaluacionExpedienteTecnicoObraController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<SituacionExpedienteTecnicoDTO> situacionExpedienteTecnicoDTO = situacionExpedienteTecnicoBL.ObtenerSituacionExpedienteTecnicos();
            List<TipoProcesoDTO> tipoProcesoDTO = tipoProcesoBL.ObtenerTipoProcesos();
            List<TipoProyectoDTO> tipoProyectoDTO = tipoProyectoBL.ObtenerTipoProyectos();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionExpedienteTecnicoObra");
            return Json(new
            {
                data1 = situacionExpedienteTecnicoDTO,
                data2 = tipoProcesoDTO,
                data3 = tipoProyectoDTO,
                data4 = zonaNavalDTO,
                data5 = areaDiperadmonDTO,
                data6 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionExpedienteTecnicoObraDTO> select = evaluacionExpedienteTecnicoObraBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string NombreProyecto, string CodigoSituacionExpedienteTecnico, string CodigoTipoProceso, string CodigoTipoProyecto,
            string CodigoZonaNaval, string CodigoAreaDiperadmon, decimal MontoContractual, string FechaInicioEvaluacionProyecto, int PorcentajeAvanceProyecto, int CargaId, string Fecha)
        {
            EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO = new();
            evaluacionExpedienteTecnicoObraDTO.NombreProyecto = NombreProyecto;
            evaluacionExpedienteTecnicoObraDTO.CodigoSituacionExpedienteTecnico = CodigoSituacionExpedienteTecnico;
            evaluacionExpedienteTecnicoObraDTO.CodigoTipoProceso = CodigoTipoProceso;
            evaluacionExpedienteTecnicoObraDTO.CodigoTipoProyecto = CodigoTipoProyecto;
            evaluacionExpedienteTecnicoObraDTO.CodigoZonaNaval = CodigoZonaNaval;
            evaluacionExpedienteTecnicoObraDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            evaluacionExpedienteTecnicoObraDTO.MontoContractual = MontoContractual;
            evaluacionExpedienteTecnicoObraDTO.FechaInicioEvaluacionProyecto = FechaInicioEvaluacionProyecto;
            evaluacionExpedienteTecnicoObraDTO.PorcentajeAvanceProyecto = PorcentajeAvanceProyecto;
            evaluacionExpedienteTecnicoObraDTO.CargaId = CargaId;
            evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionExpedienteTecnicoObraBL.AgregarRegistro(evaluacionExpedienteTecnicoObraDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionExpedienteTecnicoObraBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string NombreProyecto, string CodigoSituacionExpedienteTecnico, string CodigoTipoProceso, string CodigoTipoProyecto,
            string CodigoZonaNaval, string CodigoAreaDiperadmon, decimal MontoContractual, string FechaInicioEvaluacionProyecto, int PorcentajeAvanceProyecto)
        {
            EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO = new();
            evaluacionExpedienteTecnicoObraDTO.EvaluacionExpedienteTecnicoObraId = Id;
            evaluacionExpedienteTecnicoObraDTO.NombreProyecto = NombreProyecto;
            evaluacionExpedienteTecnicoObraDTO.CodigoSituacionExpedienteTecnico = CodigoSituacionExpedienteTecnico;
            evaluacionExpedienteTecnicoObraDTO.CodigoTipoProceso = CodigoTipoProceso;
            evaluacionExpedienteTecnicoObraDTO.CodigoTipoProyecto = CodigoTipoProyecto;
            evaluacionExpedienteTecnicoObraDTO.CodigoZonaNaval = CodigoZonaNaval;
            evaluacionExpedienteTecnicoObraDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            evaluacionExpedienteTecnicoObraDTO.MontoContractual = MontoContractual;
            evaluacionExpedienteTecnicoObraDTO.FechaInicioEvaluacionProyecto = FechaInicioEvaluacionProyecto;
            evaluacionExpedienteTecnicoObraDTO.PorcentajeAvanceProyecto = PorcentajeAvanceProyecto;
            evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionExpedienteTecnicoObraBL.ActualizarFormato(evaluacionExpedienteTecnicoObraDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO = new();
            evaluacionExpedienteTecnicoObraDTO.EvaluacionExpedienteTecnicoObraId = Id;
            evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionExpedienteTecnicoObraBL.EliminarFormato(evaluacionExpedienteTecnicoObraDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionExpedienteTecnicoObraDTO evaluacionExpedienteTecnicoObraDTO = new();
            evaluacionExpedienteTecnicoObraDTO.CargaId = Id;
            evaluacionExpedienteTecnicoObraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionExpedienteTecnicoObraBL.EliminarCarga(evaluacionExpedienteTecnicoObraDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionExpedienteTecnicoObraDTO> lista = new List<EvaluacionExpedienteTecnicoObraDTO>();
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

                    lista.Add(new EvaluacionExpedienteTecnicoObraDTO
                    {
                        NombreProyecto = fila.GetCell(0).ToString(),
                        CodigoSituacionExpedienteTecnico = fila.GetCell(1).ToString(),
                        CodigoTipoProceso = fila.GetCell(2).ToString(),
                        CodigoTipoProyecto = fila.GetCell(3).ToString(),
                        CodigoZonaNaval = fila.GetCell(4).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(5).ToString(),
                        MontoContractual = decimal.Parse(fila.GetCell(6).ToString()),
                        FechaInicioEvaluacionProyecto = UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                        PorcentajeAvanceProyecto = int.Parse(fila.GetCell(8).ToString()),

                    });
                }
            }
            catch (Exception )
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("NombreProyecto", typeof(string)),
                    new DataColumn("CodigoSituacionExpedienteTecnico", typeof(string)),
                    new DataColumn("CodigoTipoProceso", typeof(string)),
                    new DataColumn("CodigoTipoProyecto", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("MontoContractual", typeof(decimal)),
                    new DataColumn("FechaInicioEvaluacionProyecto", typeof(string)),
                    new DataColumn("PorcentajeAvanceProyecto", typeof(int)),
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
                    decimal.Parse(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionExpedienteTecnicoObraBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionExpedienteTecnicoObraBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DibinfraterEvaluacionExpedienteTecnicoObra.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DibinfraterEvaluacionExpedienteTecnicoObra.xlsx");
        }


    }

}

