using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzotres;
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

    public class ComzotresEvaluacionAlistamientoEntrenamientoComzotresController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoEntrenamientoComzotres evaluacionAlistamientoEntrenamientoComzotresBL = new();
        UnidadNaval unidadNavalBL = new();
        NivelEntrenamiento nivelEntrenamientoBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Carga cargaBL = new();

        public ComzotresEvaluacionAlistamientoEntrenamientoComzotresController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento del entrenamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<NivelEntrenamientoDTO> nivelEntrenamientoDTO = nivelEntrenamientoBL.ObtenerNivelEntrenamientos();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoAspectoDTO> ejercicioEntrenamientoAspectoDTO = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComzotres");

            return Json(new {
                data1 = unidadNavalDTO,
                data2 = nivelEntrenamientoDTO,
                data3 = capacidadOperativaDTO,
                data4 = ejercicioEntrenamientoAspectoDTO,
                data5 = calificativoAsignadoEjercicioDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComzotresDTO> lista = evaluacionAlistamientoEntrenamientoComzotresBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa, 
            string TipoCapacidadOperativa, string CodigoEjercicioEntrenamientoAspecto, string CodigoCalificativoAsignadoEjercicio, 
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia, string FechaCaducidadEjercicio,
            int PuntajeObtenidoEjercicio, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO = new();
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzotresDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.PuntajeObtenidoEjercicio = PuntajeObtenidoEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComzotresDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComzotresDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CargaId = CargaId;
            evaluacionAlistamientoEntrenamientoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComzotresBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComzotresDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComzotresBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa,
            string TipoCapacidadOperativa, string CodigoEjercicioEntrenamientoAspecto, string CodigoCalificativoAsignadoEjercicio,
            string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int TiempoVigencia, string FechaCaducidadEjercicio,
           int PuntajeObtenidoEjercicio)
        {
            EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO = new();
            evaluacionAlistamientoEntrenamientoComzotresDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzotresDTO.TipoCapacidadOperativa = TipoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistamientoEntrenamientoComzotresDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.PuntajeObtenidoEjercicio = PuntajeObtenidoEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComzotresDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistamientoEntrenamientoComzotresDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistamientoEntrenamientoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();


            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComzotresBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComzotresDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO = new();
            evaluacionAlistamientoEntrenamientoComzotresDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComzotresBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComzotresDTO evaluacionAlistamientoEntrenamientoComzotresDTO = new();
            evaluacionAlistamientoEntrenamientoComzotresDTO.CargaId = Id;
            evaluacionAlistamientoEntrenamientoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComzotresBL.EliminarCarga(evaluacionAlistamientoEntrenamientoComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoEntrenamientoComzotresDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComzotresDTO>();
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

                    lista.Add(new EvaluacionAlistamientoEntrenamientoComzotresDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoNivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativa = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamientoAspecto = fila.GetCell(4).ToString(),
                        CodigoCalificativoAsignadoEjercicio = fila.GetCell(5).ToString(),
                        PuntajeObtenidoEjercicio = int.Parse(fila.GetCell(6).ToString()),
                        FechaPeriodoEvaluar = fila.GetCell(7).ToString(),
                        FechaRealizacionEjercicio = fila.GetCell(8).ToString(),
                        TiempoVigencia = int.Parse(fila.GetCell(9).ToString()),
                        FechaCaducidadEjercicio = fila.GetCell(10).ToString()
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
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoNivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoAspecto", typeof(string)),
                    new DataColumn("CodigoCalificativoAsignadoEjercicio", typeof(string)),
                    new DataColumn("PuntajeObtenidoEjercicio", typeof(int)),
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
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComzotresBL.InsertarDatos(dt, Fecha);
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
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzotresEvaluacionAlistamientoEntrenamientoComzotres.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzotresEvaluacionAlistamientoEntrenamientoComzotres.xlsx");
        }
    }
}

