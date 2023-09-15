using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfoe;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfoe;
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

    public class ComfoeEvaluacionAlistamientoEntrenamientoComfoeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EvaluacionAlistamientoEntrenamientoComfoe evaluacionAlistamientoEntrenamientoComfoeBL = new();

        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        EjercicioEntrenamientoComfoe ejercicioEntrenamientoBL = new();
        Carga cargaBL = new();

        public ComfoeEvaluacionAlistamientoEntrenamientoComfoeController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento del entrenamiento (ALIENT)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<EjercicioEntrenamientoComfoeDTO> ejercicioEntrenamientoComfoeDTO = ejercicioEntrenamientoBL.ObtenerEjercicioEntrenamientoComfoes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoEntrenamientoComfoe");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = capacidadOperativaDTO,      
                data3 = ejercicioEntrenamientoComfoeDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoEntrenamientoComfoeDTO> select = evaluacionAlistamientoEntrenamientoComfoeBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoCapacidadOperativa, string CodigoEjercicioEntrenamientoComfoe, int PuntajeObtenidoEjercicio, string FechaPeriodoEvaluar, string FechaRealizacionEjercicio, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO = new();
            evaluacionAlistamientoEntrenamientoComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfoeDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe = CodigoEjercicioEntrenamientoComfoe;
            evaluacionAlistamientoEntrenamientoComfoeDTO.PuntajeObtenidoEjercicio = PuntajeObtenidoEjercicio;
            evaluacionAlistamientoEntrenamientoComfoeDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfoeDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;
            evaluacionAlistamientoEntrenamientoComfoeDTO.CargaId = CargaId;
            evaluacionAlistamientoEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfoeBL.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfoeDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoEntrenamientoComfoeBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoCapacidadOperativa, string CodigoEjercicioEntrenamientoComfoe, int PuntajeObtenidoEjercicio, string FechaPeriodoEvaluar, string FechaRealizacionEjercicio)
        {
            EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO = new();
            evaluacionAlistamientoEntrenamientoComfoeDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfoeDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoEntrenamientoComfoeDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            evaluacionAlistamientoEntrenamientoComfoeDTO.CodigoEjercicioEntrenamientoComfoe = CodigoEjercicioEntrenamientoComfoe;
            evaluacionAlistamientoEntrenamientoComfoeDTO.PuntajeObtenidoEjercicio = PuntajeObtenidoEjercicio;
            evaluacionAlistamientoEntrenamientoComfoeDTO.FechaPeriodoEvaluar = FechaPeriodoEvaluar;
            evaluacionAlistamientoEntrenamientoComfoeDTO.FechaRealizacionEjercicio = FechaRealizacionEjercicio;

            evaluacionAlistamientoEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfoeBL.ActualizarFormato(evaluacionAlistamientoEntrenamientoComfoeDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO = new();
            evaluacionAlistamientoEntrenamientoComfoeDTO.EvaluacionAlistamientoEntrenamientoId = Id;
            evaluacionAlistamientoEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoEntrenamientoComfoeBL.EliminarFormato(evaluacionAlistamientoEntrenamientoComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoEntrenamientoComfoeDTO evaluacionAlistamientoEntrenamientoComfoeDTO = new();
            evaluacionAlistamientoEntrenamientoComfoeDTO.CargaId = Id;
            evaluacionAlistamientoEntrenamientoComfoeDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoEntrenamientoComfoeBL.EliminarCarga(evaluacionAlistamientoEntrenamientoComfoeDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoEntrenamientoComfoeDTO> lista = new List<EvaluacionAlistamientoEntrenamientoComfoeDTO>();
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

                    lista.Add(new EvaluacionAlistamientoEntrenamientoComfoeDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoEjercicioEntrenamientoComfoe = fila.GetCell(2).ToString(),
                        PuntajeObtenidoEjercicio = int.Parse(fila.GetCell(3).ToString()),
                        FechaPeriodoEvaluar = UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                        FechaRealizacionEjercicio = UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString())

                    });
                }
            }
            catch (Exception)
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoEjercicioEntrenamientoComfoe", typeof(string)),
                    new DataColumn("PuntajeObtenidoEjercicio", typeof(int)),
                    new DataColumn("FechaPeriodoEvaluar", typeof(string)),
                    new DataColumn("FechaRealizacionEjercicio", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoEntrenamientoComfoeBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistamientoEntrenamientoComfoeBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfoeEvaluacionAlistamientoEntrenamientoComfoe.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfoeEvaluacionAlistamientoEntrenamientoComfoe.xlsx");
        }

    }

}

