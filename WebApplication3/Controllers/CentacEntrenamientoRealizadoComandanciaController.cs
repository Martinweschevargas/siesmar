using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
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

    public class CentacEntrenamientoRealizadoComandanciaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        LogicaNegocios.Formatos.Centac.EntrenamientoRealizadoComandancia entrenamientoRealizadoComandanciaBL = new();
        Dependencia dependenciaBL = new();
        UnidadNaval unidadNavalBL = new();
        TipoOperacion tipoOperacionBL = new();
        TipoEjercicio tipoEjercicioBL = new();
        Formula2CalificativoCentacDAO formula2CalificativoCentacBL = new();
        Carga cargaBL = new();

        public CentacEntrenamientoRealizadoComandanciaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Entrenamiento Realizado por las Comandancias de las Fuerzas Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        { 
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<TipoOperacionDTO> tipoOperacionDTO = tipoOperacionBL.ObtenerTipoOperacions();
            List<TipoEjercicioDTO> tipoEjercicioDTO = tipoEjercicioBL.ObtenerTipoEjercicios();
            List<Formula2CalificativoCentacDTO> formula2CalificativoCentacDTO = formula2CalificativoCentacBL.ObtenerFormula2CalificativoCentacs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EntrenamientoRealizadoComandancia");
            return Json(new { 
                data1 = dependenciaDTO, 
                data2 = unidadNavalDTO, 
                data3 = tipoOperacionDTO,
                data4 = tipoEjercicioDTO, 
                data5 = formula2CalificativoCentacDTO, 
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EntrenamientoRealizadoComandanciaDTO> select = entrenamientoRealizadoComandanciaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string EventoEntrenamiento, string FechaEvento, int NumeroHoras, string EventoProgramado, string CodigoDependencia,
            string CodigoUnidadNaval, string CodigoTipoOperacion, string NivelEntrenamiento, string CodigoTipoEjercicio, int FcComunicaciones, int FcPosicionInicial, int FcFunciones, 
            int FcAcciones, int FcAtaque, int PorcentajeFinalEvaluacion, string CodigoFormula2CalificativoCentac, int CargaId, string Fecha)
        {
            EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO = new();
            entrenamientoRealizadoComandanciaDTO.EventoEntrenamiento = EventoEntrenamiento;
            entrenamientoRealizadoComandanciaDTO.FechaEvento = FechaEvento;
            entrenamientoRealizadoComandanciaDTO.NumeroHoras = NumeroHoras;
            entrenamientoRealizadoComandanciaDTO.EventoProgramado = EventoProgramado;
            entrenamientoRealizadoComandanciaDTO.CodigoDependencia = CodigoDependencia;
            entrenamientoRealizadoComandanciaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            entrenamientoRealizadoComandanciaDTO.CodigoTipoOperacion = CodigoTipoOperacion;
            entrenamientoRealizadoComandanciaDTO.NivelEntrenamiento = NivelEntrenamiento;
            entrenamientoRealizadoComandanciaDTO.CodigoTipoEjercicio = CodigoTipoEjercicio;
            entrenamientoRealizadoComandanciaDTO.FcComunicaciones = FcComunicaciones;
            entrenamientoRealizadoComandanciaDTO.FcPosicionInicial = FcPosicionInicial;
            entrenamientoRealizadoComandanciaDTO.FcFunciones = FcFunciones;
            entrenamientoRealizadoComandanciaDTO.FcAcciones = FcAcciones;
            entrenamientoRealizadoComandanciaDTO.FcAtaque = FcAtaque;
            entrenamientoRealizadoComandanciaDTO.PorcentajeFinalEvaluacion = PorcentajeFinalEvaluacion;
            entrenamientoRealizadoComandanciaDTO.CodigoFormula2CalificativoCentac = CodigoFormula2CalificativoCentac;
            entrenamientoRealizadoComandanciaDTO.CargaId = CargaId;
            entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entrenamientoRealizadoComandanciaBL.AgregarRegistro(entrenamientoRealizadoComandanciaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(entrenamientoRealizadoComandanciaBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string EventoEntrenamiento, string FechaEvento, int NumeroHoras, string EventoProgramado, string CodigoDependencia,
            string CodigoUnidadNaval, string CodigoTipoOperacion, string NivelEntrenamiento, string CodigoTipoEjercicio, int FcComunicaciones, int FcPosicionInicial, 
            int FcFunciones, int FcAcciones, int FcAtaque, int PorcentajeFinalEvaluacion, string CodigoFormula2CalificativoCentac)
        {
            EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO = new();
            entrenamientoRealizadoComandanciaDTO.EntrenamientoRealizadoComandanciaId = Id;
            entrenamientoRealizadoComandanciaDTO.EventoEntrenamiento = EventoEntrenamiento;
            entrenamientoRealizadoComandanciaDTO.FechaEvento = FechaEvento;
            entrenamientoRealizadoComandanciaDTO.NumeroHoras = NumeroHoras;
            entrenamientoRealizadoComandanciaDTO.EventoProgramado = EventoProgramado;
            entrenamientoRealizadoComandanciaDTO.CodigoDependencia = CodigoDependencia;
            entrenamientoRealizadoComandanciaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            entrenamientoRealizadoComandanciaDTO.CodigoTipoOperacion = CodigoTipoOperacion;
            entrenamientoRealizadoComandanciaDTO.NivelEntrenamiento = NivelEntrenamiento;
            entrenamientoRealizadoComandanciaDTO.CodigoTipoEjercicio = CodigoTipoEjercicio;
            entrenamientoRealizadoComandanciaDTO.FcComunicaciones = FcComunicaciones;
            entrenamientoRealizadoComandanciaDTO.FcPosicionInicial = FcPosicionInicial;
            entrenamientoRealizadoComandanciaDTO.FcFunciones = FcFunciones;
            entrenamientoRealizadoComandanciaDTO.FcAcciones = FcAcciones;
            entrenamientoRealizadoComandanciaDTO.FcAtaque = FcAtaque;
            entrenamientoRealizadoComandanciaDTO.PorcentajeFinalEvaluacion = PorcentajeFinalEvaluacion;
            entrenamientoRealizadoComandanciaDTO.CodigoFormula2CalificativoCentac = CodigoFormula2CalificativoCentac;
            entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = entrenamientoRealizadoComandanciaBL.ActualizarFormato(entrenamientoRealizadoComandanciaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO = new();
            entrenamientoRealizadoComandanciaDTO.EntrenamientoRealizadoComandanciaId = Id;
            entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (entrenamientoRealizadoComandanciaBL.EliminarFormato(entrenamientoRealizadoComandanciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EntrenamientoRealizadoComandanciaDTO entrenamientoRealizadoComandanciaDTO = new();
            entrenamientoRealizadoComandanciaDTO.CargaId = Id;
            entrenamientoRealizadoComandanciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (entrenamientoRealizadoComandanciaBL.EliminarCarga(entrenamientoRealizadoComandanciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EntrenamientoRealizadoComandanciaDTO> lista = new List<EntrenamientoRealizadoComandanciaDTO>();
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

                    lista.Add(new EntrenamientoRealizadoComandanciaDTO
                    {
                        EventoEntrenamiento = fila.GetCell(0).ToString(),
                        FechaEvento = fila.GetCell(1).ToString(),
                        NumeroHoras = int.Parse(fila.GetCell(2).ToString()),
                        EventoProgramado = fila.GetCell(3).ToString(),
                        CodigoDependencia = fila.GetCell(4).ToString(),
                        CodigoUnidadNaval = fila.GetCell(5).ToString(),
                        CodigoTipoOperacion = fila.GetCell(6).ToString(),
                        NivelEntrenamiento = fila.GetCell(7).ToString(),
                        CodigoTipoEjercicio = fila.GetCell(8).ToString(),
                        FcComunicaciones = int.Parse(fila.GetCell(9).ToString()),
                        FcPosicionInicial = int.Parse(fila.GetCell(10).ToString()),
                        FcFunciones = int.Parse(fila.GetCell(11).ToString()),
                        FcAcciones = int.Parse(fila.GetCell(12).ToString()),
                        FcAtaque = int.Parse(fila.GetCell(13).ToString()),
                        PorcentajeFinalEvaluacion = int.Parse(fila.GetCell(14).ToString()),
                        CodigoFormula2CalificativoCentac = fila.GetCell(15).ToString().ToString(),
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

            dt.Columns.AddRange(new DataColumn[17]
            {
                    new DataColumn("EventoEntrenamiento", typeof(string)),
                    new DataColumn("FechaEvento", typeof(string)),
                    new DataColumn("NumeroHoras", typeof(int)),
                    new DataColumn("EventoProgramado", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoTipoOperacion", typeof(string)),
                    new DataColumn("NivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoTipoEjercicio", typeof(string)),
                    new DataColumn("FcComunicaciones", typeof(int)),
                    new DataColumn("FcPosicionInicial", typeof(int)),
                    new DataColumn("FcFunciones", typeof(int)),
                    new DataColumn("FcAcciones", typeof(int)),
                    new DataColumn("FcAtaque", typeof(int)),
                    new DataColumn("PorcentajeFinalEvaluacion", typeof(int)),
                    new DataColumn("CodigoFormula2CalificativoCentac", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    int.Parse(fila.GetCell(13).ToString()),
                    int.Parse(fila.GetCell(14).ToString()),
                    fila.GetCell(15).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = entrenamientoRealizadoComandanciaBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }


        public IActionResult ReporteCERC(int CargaId)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Centac\\EntrenamientoRealizadoComandancia.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var alquilerAreaCentroEsparcimientoS = entrenamientoRealizadoComandanciaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EntrenamientoRealizadoComandancia", alquilerAreaCentroEsparcimientoS);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\CentacEntrenamientoRealizadoComandancia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "CentacEntrenamientoRealizadoComandancia.xlsx");
        }
    }

}
