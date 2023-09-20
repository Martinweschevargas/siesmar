using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comescuama;
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

    public class ComescuamaEvaluacionAlistEntrenamientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistEntrenamientoComescuama evaluacionAlistEntrenamientoComescuamaBL = new();
        UnidadComescuamaDAO unidadComescuamaBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Carga cargaBL = new();

        public ComescuamaEvaluacionAlistEntrenamientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento del Entrenamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadComescuamaDTO> unidadComescuamaDTO = unidadComescuamaBL.ObtenerUnidadComescuamas();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoAspectoDTO> ejercicioEntrenamientoAspectoDTO = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComescuama");

            return Json(new { 
                data1 = unidadComescuamaDTO, 
                data2 = capacidadOperativaDTO,
                data3 = ejercicioEntrenamientoAspectoDTO,
                data4 = calificativoAsignadoEjercicioDTO, 
                data5 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistEntrenamientoComescuamaDTO> lista = evaluacionAlistEntrenamientoComescuamaBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadComescuama, string NivelEntrenamiento, string CodigoCapacidadOperativa, string TipoCapacidadOperativo,
             string CodigoEjercicioEntrenamientoAspecto, int PuntajeObtenido, string FechaPeriodoEvaluar,
            string FechaRealizacionEjercicio, int TiempoVigencia, string FechaCaducidadEjercicio, string CodigoCalificativoAsignadoEjercicio, 
            int CargaId, string Fecha)
        {
            EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO = new();
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoUnidadComescuama = CodigoUnidadComescuama;
            evaluacionAlistEntrenamientoComescuamaDTO.NivelEntrenamiento = NivelEntrenamiento;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistEntrenamientoComescuamaDTO.TipoCapacidadOperativo = TipoCapacidadOperativo;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistEntrenamientoComescuamaDTO.PuntajeObtenido = PuntajeObtenido;
            evaluacionAlistEntrenamientoComescuamaDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistEntrenamientoComescuamaDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistEntrenamientoComescuamaDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistEntrenamientoComescuamaDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistEntrenamientoComescuamaDTO.CargaId = CargaId;
            evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistEntrenamientoComescuamaBL.AgregarRegistro(evaluacionAlistEntrenamientoComescuamaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistEntrenamientoComescuamaBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadComescuama, string NivelEntrenamiento, string CodigoCapacidadOperativa, string TipoCapacidadOperativo,
            string CodigoEjercicioEntrenamientoAspecto, int PuntajeObtenido, string FechaPeriodoEvaluar,
            string FechaRealizacionEjercicio, int TiempoVigencia, string FechaCaducidadEjercicio, string CodigoCalificativoAsignadoEjercicio)
        {
            EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO = new();
            evaluacionAlistEntrenamientoComescuamaDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoUnidadComescuama = CodigoUnidadComescuama;
            evaluacionAlistEntrenamientoComescuamaDTO.NivelEntrenamiento = NivelEntrenamiento;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistEntrenamientoComescuamaDTO.TipoCapacidadOperativo = TipoCapacidadOperativo;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistEntrenamientoComescuamaDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistEntrenamientoComescuamaDTO.PuntajeObtenido = PuntajeObtenido;
            evaluacionAlistEntrenamientoComescuamaDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistEntrenamientoComescuamaDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistEntrenamientoComescuamaDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistEntrenamientoComescuamaDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistEntrenamientoComescuamaBL.ActualizarFormato(evaluacionAlistEntrenamientoComescuamaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO = new();
            evaluacionAlistEntrenamientoComescuamaDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistEntrenamientoComescuamaBL.EliminarFormato(evaluacionAlistEntrenamientoComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistEntrenamientoComescuamaDTO evaluacionAlistEntrenamientoComescuamaDTO = new();
            evaluacionAlistEntrenamientoComescuamaDTO.CargaId = Id;
            evaluacionAlistEntrenamientoComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistEntrenamientoComescuamaBL.EliminarCarga(evaluacionAlistEntrenamientoComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistEntrenamientoComescuamaDTO> lista = new List<EvaluacionAlistEntrenamientoComescuamaDTO>();
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

                    lista.Add(new EvaluacionAlistEntrenamientoComescuamaDTO
                    {
                        CodigoUnidadComescuama = fila.GetCell(0).ToString(),
                        NivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativo = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamientoAspecto = fila.GetCell(4).ToString(),
                        CodigoCalificativoAsignadoEjercicio = fila.GetCell(5).ToString(),
                        PuntajeObtenido = int.Parse(fila.GetCell(6).ToString()),
                        FechaPeriodoEvaluar = fila.GetCell(7).ToString(),
                        FechaRealizacionEjercicio = fila.GetCell(8).ToString(),
                        TiempoVigencia = int.Parse(fila.GetCell(9).ToString()),
                        FechaCaducidadEjercicio = fila.GetCell(10).ToString(),
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("CodigoUnidadComescuama", typeof(string)),
                    new DataColumn("NivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativo", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoAspecto", typeof(string)),
                    new DataColumn("CodigoCalificativoAsignadoEjercicio", typeof(string)),
                    new DataColumn("PuntajeObtenido", typeof(int)),
                    new DataColumn("FechaPeriodoEvaluar", typeof(string)),
                    new DataColumn("FechaRealizacionEjercicio", typeof(string)),
                    new DataColumn("TiempoVigencia", typeof(int)),
                    new DataColumn("FechaCaducidadEjercicio", typeof(string)),
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
                    int.Parse(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),


                    User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionAlistEntrenamientoComescuamaBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteCEAE(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comescuama\\ComescuamaEvaluacionAlistEntrenamiento.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = evaluacionAlistEntrenamientoComescuamaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComescuamaEvaluacionAlistEntrenamiento", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComescuamaEvaluacionAlistEntrenamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComescuamaEvaluacionAlistEntrenamiento.xlsx");
        }
    }

}

