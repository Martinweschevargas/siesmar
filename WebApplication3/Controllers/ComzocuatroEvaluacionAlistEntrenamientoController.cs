using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro;
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

    public class ComzocuatroEvaluacionAlistEntrenamientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistEntrenamientoComzocuatro evaluacionAlistEntrenamientoComzocuatroBL = new();
        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoAspecto ejercicioEntrenamientoAspectoBL = new();
        CalificativoAsignadoEjercicio calificativoAsignadoEjercicioBL = new();
        Carga cargaBL = new();

        public ComzocuatroEvaluacionAlistEntrenamientoController(IWebHostEnvironment webHostEnvironment)
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
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoAspectoDTO> ejercicioEntrenamientoAspectoDTO = ejercicioEntrenamientoAspectoBL.ObtenerEjercicioEntrenamientoAspectos();
            List<CalificativoAsignadoEjercicioDTO> calificativoAsignadoEjercicioDTO = calificativoAsignadoEjercicioBL.ObtenerCalificativoAsignadoEjercicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComzocuatro");

            return Json(new { data1 = unidadNavalDTO, data2 = capacidadOperativaDTO, data3 = ejercicioEntrenamientoAspectoDTO, data4 = calificativoAsignadoEjercicioDTO, data5 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistEntrenamientoComzocuatroDTO> select = evaluacionAlistEntrenamientoComzocuatroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa, string TipoCapacidadOperativo,
            string CodigoEjercicioEntrenamientoAspecto, string CodigoCalificativoAsignadoEjercicio,  int PuntajeObtenido, string FechaPeriodoEvaluar, string FechaRealizacionEjercicio,
            int TiempoVigencia, string FechaCaducidadEjercicio, int CargaId)
        {
            EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO = new();
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistEntrenamientoComzocuatroDTO.TipoCapacidadOperativo = TipoCapacidadOperativo;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistEntrenamientoComzocuatroDTO.PuntajeObtenido = PuntajeObtenido;
            evaluacionAlistEntrenamientoComzocuatroDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistEntrenamientoComzocuatroDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistEntrenamientoComzocuatroDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistEntrenamientoComzocuatroDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistEntrenamientoComzocuatroDTO.CargaId = CargaId;
            evaluacionAlistEntrenamientoComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistEntrenamientoComzocuatroBL.AgregarRegistro(evaluacionAlistEntrenamientoComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistEntrenamientoComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoNivelEntrenamiento, string CodigoCapacidadOperativa, string TipoCapacidadOperativo,
            string CodigoEjercicioEntrenamientoAspecto, string CodigoCalificativoAsignadoEjercicio, int PuntajeObtenido, string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, 
            int TiempoVigencia, string FechaCaducidadEjercicio)
        {
            EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO = new();
            evaluacionAlistEntrenamientoComzocuatroDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoNivelEntrenamiento = CodigoNivelEntrenamiento;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistEntrenamientoComzocuatroDTO.TipoCapacidadOperativo = TipoCapacidadOperativo;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoEjercicioEntrenamientoAspecto = CodigoEjercicioEntrenamientoAspecto;
            evaluacionAlistEntrenamientoComzocuatroDTO.CodigoCalificativoAsignadoEjercicio = CodigoCalificativoAsignadoEjercicio;
            evaluacionAlistEntrenamientoComzocuatroDTO.PuntajeObtenido = PuntajeObtenido;
            evaluacionAlistEntrenamientoComzocuatroDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistEntrenamientoComzocuatroDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistEntrenamientoComzocuatroDTO.TiempoVigencia = TiempoVigencia;
            evaluacionAlistEntrenamientoComzocuatroDTO.FechaCaducidadEjercicio = FechaCaducidadEjercicio;
            evaluacionAlistEntrenamientoComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistEntrenamientoComzocuatroBL.ActualizarFormato(evaluacionAlistEntrenamientoComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistEntrenamientoComzocuatroDTO evaluacionAlistEntrenamientoComzocuatroDTO = new();
            evaluacionAlistEntrenamientoComzocuatroDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistEntrenamientoComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistEntrenamientoComzocuatroBL.EliminarFormato(evaluacionAlistEntrenamientoComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistEntrenamientoComzocuatroDTO> lista = new List<EvaluacionAlistEntrenamientoComzocuatroDTO>();
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

                    lista.Add(new EvaluacionAlistEntrenamientoComzocuatroDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoNivelEntrenamiento = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        TipoCapacidadOperativo = fila.GetCell(3).ToString(),
                        CodigoEjercicioEntrenamientoAspecto = fila.GetCell(4).ToString(),
                        CodigoCalificativoAsignadoEjercicio = fila.GetCell(5).ToString(),
                        PuntajeObtenido = int.Parse(fila.GetCell(6).ToString()),
                        FechaPeriodoEvaluar =fila.GetCell(7).ToString(),
                        FechaRealizacionEjercicio =fila.GetCell(8).ToString(),
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoNivelEntrenamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("TipoCapacidadOperativo", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoAspecto", typeof(string)),
                    new DataColumn("CodigoCalificativoAsignadoEjercicio", typeof(int)),
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
            var IND_OPERACION = evaluacionAlistEntrenamientoComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistEntrenamientoComzocuatroBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

    }

}

