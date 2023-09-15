using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfasub;
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

    public class ComfasubEvaluacionAlistamientoPersonalComfasubController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoPersonalComfasub evaluacionAlistamientoPersonalComfasubBL = new();

        UnidadNaval unidadNavalBL = new();
        Cargo cargoBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public ComfasubEvaluacionAlistamientoPersonalComfasubController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoPersonalComfasub");

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
            List<EvaluacionAlistamientoPersonalComfasubDTO> select = evaluacionAlistamientoPersonalComfasubBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, string CIPPersonal, string CodigoCargo,
            string CodigoGradoPersonalMilitarEsperado, string CodigoEspecialidadGenericaPersonalEsperado, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia, 
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, string DestaqueDependencia, string FechaInicioDestaque,
            string FechaFinDestaque, string TiempoEmbarque, string DespliegeComisionExtranjero , string NombresPersonal, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO = new();
            evaluacionAlistamientoPersonalComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComfasubDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComfasubDTO.NombresPersonal = NombresPersonal;
            evaluacionAlistamientoPersonalComfasubDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComfasubDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaPersonalEsperado = CodigoEspecialidadGenericaPersonalEsperado;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaActual = CodigoEspecialidadGenericaActual;
            evaluacionAlistamientoPersonalComfasubDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComfasubDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComfasubDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComfasubDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComfasubDTO.DestaqueDependencia = DestaqueDependencia;
            evaluacionAlistamientoPersonalComfasubDTO.FechaInicioDestaque = FechaInicioDestaque;
            evaluacionAlistamientoPersonalComfasubDTO.FechaFinDestaque = FechaFinDestaque;
            evaluacionAlistamientoPersonalComfasubDTO.TiempoEmbarque = TiempoEmbarque;
            evaluacionAlistamientoPersonalComfasubDTO.DespliegeComisionExtranjero = DespliegeComisionExtranjero;
            evaluacionAlistamientoPersonalComfasubDTO.CargaId = CargaId;
            evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComfasubBL.AgregarRegistro(evaluacionAlistamientoPersonalComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoPersonalComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, string CIPPersonal, string CodigoCargo,
            string CodigoGradoPersonalMilitarEsperado, string CodigoEspecialidadGenericaPersonalEsperado, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaActual, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, string DestaqueDependencia, string FechaInicioDestaque,
            string FechaFinDestaque, string TiempoEmbarque, string DespliegeComisionExtranjero, string NombresPersonal)
        { 
            EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO = new();
            evaluacionAlistamientoPersonalComfasubDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComfasubDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComfasubDTO.NombresPersonal = NombresPersonal;
            evaluacionAlistamientoPersonalComfasubDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComfasubDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaPersonalEsperado = CodigoEspecialidadGenericaPersonalEsperado;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistamientoPersonalComfasubDTO.CodigoEspecialidadGenericaActual = CodigoEspecialidadGenericaActual;
            evaluacionAlistamientoPersonalComfasubDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComfasubDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComfasubDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComfasubDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComfasubDTO.DestaqueDependencia = DestaqueDependencia;
            evaluacionAlistamientoPersonalComfasubDTO.FechaInicioDestaque = FechaInicioDestaque;
            evaluacionAlistamientoPersonalComfasubDTO.FechaFinDestaque = FechaFinDestaque;
            evaluacionAlistamientoPersonalComfasubDTO.TiempoEmbarque = TiempoEmbarque;
            evaluacionAlistamientoPersonalComfasubDTO.DespliegeComisionExtranjero = DespliegeComisionExtranjero;

            evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComfasubBL.ActualizarFormato(evaluacionAlistamientoPersonalComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO = new();
            evaluacionAlistamientoPersonalComfasubDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoPersonalComfasubBL.EliminarFormato(evaluacionAlistamientoPersonalComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO = new();
            evaluacionAlistamientoPersonalComfasubDTO.CargaId = Id;
            evaluacionAlistamientoPersonalComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoPersonalComfasubBL.EliminarCarga(evaluacionAlistamientoPersonalComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoPersonalComfasubDTO> lista = new List<EvaluacionAlistamientoPersonalComfasubDTO>();
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

                    lista.Add(new EvaluacionAlistamientoPersonalComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        FechaEvaluacion = UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                        NombresPersonal = fila.GetCell(2).ToString(),
                        DNIPersonal = fila.GetCell(3).ToString(),
                        CIPPersonal = fila.GetCell(4).ToString(),
                        CodigoCargo = fila.GetCell(5).ToString(),
                        CodigoGradoPersonalMilitarEsperado = fila.GetCell(6).ToString(),
                        CodigoEspecialidadGenericaPersonalEsperado = fila.GetCell(7).ToString(),
                        CodigoGradoPersonalMilitarActual = fila.GetCell(8).ToString(),
                        CodigoEspecialidadGenericaActual = fila.GetCell(9).ToString(),
                        GradoJerarquico = decimal.Parse(fila.GetCell(10).ToString()),
                        ServicioExperiencia = decimal.Parse(fila.GetCell(11).ToString()),
                        EspecializacionProfesional = decimal.Parse(fila.GetCell(12).ToString()),
                        CursoProfesionalRequerido = decimal.Parse(fila.GetCell(13).ToString()),
                        DestaqueDependencia = fila.GetCell(14).ToString(),
                        FechaInicioDestaque = UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                        FechaFinDestaque = UtilitariosGlobales.obtenerFecha(fila.GetCell(16).ToString()),
                        TiempoEmbarque = fila.GetCell(17).ToString(),
                        DespliegeComisionExtranjero = fila.GetCell(18).ToString()
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

            dt.Columns.AddRange(new DataColumn[20]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("NombresPersonal", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(string)),
                    new DataColumn("CIPPersonal", typeof(string)),
                    new DataColumn("CodigoCargo", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarEsperado", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonalEsperado", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarActual", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaActual", typeof(string)),
                    new DataColumn("GradoJerarquico", typeof(decimal)),
                    new DataColumn("ServicioExperiencia", typeof(decimal)),
                    new DataColumn("EspecializacionProfesional", typeof(decimal)),
                    new DataColumn("CursoProfesionalRequerido", typeof(decimal)),
                    new DataColumn("DestaqueDependencia", typeof(string)),
                    new DataColumn("FechaInicioDestaque", typeof(string)),
                    new DataColumn("FechaFinDestaque", typeof(string)),
                    new DataColumn("TiempoEmbarque", typeof(string)),
                    new DataColumn("DespliegeComisionExtranjero", typeof(string)),
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
                    fila.GetCell(9).ToString(),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    decimal.Parse(fila.GetCell(11).ToString()),
                    decimal.Parse(fila.GetCell(12).ToString()),
                    decimal.Parse(fila.GetCell(13).ToString()),
                    fila.GetCell(14).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(16).ToString()),
                    fila.GetCell(17).ToString(),
                    fila.GetCell(18).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoPersonalComfasubBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = evaluacionAlistamientoPersonalComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubEvaluacionAlistamientoPersonalComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubEvaluacionAlistamientoPersonalComfasub.xlsx");
        }
    }

}

