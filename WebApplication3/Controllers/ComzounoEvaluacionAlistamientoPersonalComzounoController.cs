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

    public class ComzounoEvaluacionAlistamientoPersonalComzounoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoPersonalComzouno evaluacionAlistamientoPersonalComzounoBL = new();
        UnidadNaval unidadNavalBL = new();
        Cargo cargoBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Carga cargaBL = new();

        public ComzounoEvaluacionAlistamientoPersonalComzounoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del alistamiento de personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CargoDTO> cargoDTO = cargoBL.ObtenerCargos();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoPersonalComzouno");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = cargoDTO,
                data3 = gradoPersonalMilitarDTO,
                data4 = especialidadGenericaPersonalDTO,
                data5 = listaCargas

            });
        }


        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoPersonalComzounoDTO> select = evaluacionAlistamientoPersonalComzounoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, string CIPPersonal, string CodigoCargo,
            string CodigoGradoPersonalMilitarEsperado, string CodigoEspecialidadGenericaEsperado, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia, 
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal PuntajeTotalPersonal, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO = new();
            evaluacionAlistamientoPersonalComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComzounoDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComzounoDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComzounoDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaEsperado = CodigoEspecialidadGenericaEsperado;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaActual = CodigoEspecialidadGenericaActual;
            evaluacionAlistamientoPersonalComzounoDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComzounoDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComzounoDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComzounoDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComzounoDTO.PuntajeTotalPersonal = PuntajeTotalPersonal;
            evaluacionAlistamientoPersonalComzounoDTO.CargaId = CargaId;
            evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComzounoBL.AgregarRegistro(evaluacionAlistamientoPersonalComzounoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoPersonalComzounoBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, string CIPPersonal, string CodigoCargo,
            string CodigoGradoPersonalMilitarEsperado, string CodigoEspecialidadGenericaEsperado, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal PuntajeTotalPersonal)
        { 
            EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO = new();
            evaluacionAlistamientoPersonalComzounoDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComzounoDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComzounoDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComzounoDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaEsperado = CodigoEspecialidadGenericaEsperado;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComzounoDTO.CodigoEspecialidadGenericaActual = CodigoEspecialidadGenericaActual;
            evaluacionAlistamientoPersonalComzounoDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComzounoDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComzounoDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComzounoDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComzounoDTO.PuntajeTotalPersonal = PuntajeTotalPersonal;
            evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComzounoBL.ActualizarFormato(evaluacionAlistamientoPersonalComzounoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO = new();
            evaluacionAlistamientoPersonalComzounoDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoPersonalComzounoBL.EliminarFormato(evaluacionAlistamientoPersonalComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComzounoDTO evaluacionAlistamientoPersonalComzounoDTO = new();
            evaluacionAlistamientoPersonalComzounoDTO.CargaId = Id;
            evaluacionAlistamientoPersonalComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoPersonalComzounoBL.EliminarCarga(evaluacionAlistamientoPersonalComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoPersonalComzounoDTO> lista = new List<EvaluacionAlistamientoPersonalComzounoDTO>();
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

                    lista.Add(new EvaluacionAlistamientoPersonalComzounoDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        FechaEvaluacion = UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                        DNIPersonal = fila.GetCell(2).ToString(),
                        CIPPersonal = fila.GetCell(3).ToString(),
                        CodigoCargo = fila.GetCell(4).ToString(),
                        CodigoGradoPersonalMilitarEsperado = fila.GetCell(5).ToString(),
                        CodigoEspecialidadGenericaEsperado = fila.GetCell(6).ToString(),
                        CodigoGradoPersonalMilitarActual = fila.GetCell(7).ToString(),
                        CodigoEspecialidadGenericaActual = fila.GetCell(8).ToString(),
                        GradoJerarquico = decimal.Parse(fila.GetCell(9).ToString()),
                        ServicioExperiencia = decimal.Parse(fila.GetCell(10).ToString()),
                        EspecializacionProfesional = decimal.Parse(fila.GetCell(11).ToString()),
                        CursoProfesionalRequerido = decimal.Parse(fila.GetCell(12).ToString()),
                        PuntajeTotalPersonal = decimal.Parse(fila.GetCell(13).ToString())
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(string)),
                    new DataColumn("CIPPersonal", typeof(string)),
                    new DataColumn("CodigoCargo", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarEsperado", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaEsperado", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarActual", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaActual", typeof(string)),
                    new DataColumn("GradoJerarquico", typeof(decimal)),
                    new DataColumn("ServicioExperiencia", typeof(decimal)),
                    new DataColumn("EspecializacionProfesional", typeof(decimal)),
                    new DataColumn("CursoProfesionalRequerido", typeof(decimal)),
                    new DataColumn("PuntajeTotalPersonal", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    decimal.Parse(fila.GetCell(11).ToString()),
                    decimal.Parse(fila.GetCell(12).ToString()),
                    decimal.Parse(fila.GetCell(13).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoPersonalComzounoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistamientoPersonalComzounoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzounoEvaluacionAlistamientoPersonalComzouno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzounoEvaluacionAlistamientoPersonalComzouno.xlsx");
        }
    }

}

