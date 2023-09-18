using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
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
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComescuamaEvaluacionAlistPersonalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EvaluacionAlistPersonalComescuama evaluacionAlistPersonalComescuamaBL = new();

        UnidadNaval unidadNavalBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Carga cargaBL = new();


        public ComescuamaEvaluacionAlistPersonalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación del Alistamiento de Personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitaroDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ComescuamaEvaluacionAlistPersonal");

            return Json(new { data1 = unidadNavalDTO, data2 = gradoPersonalMilitaroDTO, data3 = especialidadGenericaPersonalDTO, data4= listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistPersonalComescuamaDTO> select = evaluacionAlistPersonalComescuamaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, string CIPPersonal, string CodigoCargo, 
            string CodigoGradoPersonalMilitarEsperado, string CodigoEspecialidadGenericaActual, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaEsperado, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal TotalPuntaje, int CargaId)
        {
            EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO = new();
            evaluacionAlistPersonalComescuamaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistPersonalComescuamaDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistPersonalComescuamaDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistPersonalComescuamaDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistPersonalComescuamaDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaEsperado = CodigoEspecialidadGenericaEsperado;
            evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaActual = CodigoEspecialidadGenericaActual;
            evaluacionAlistPersonalComescuamaDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistPersonalComescuamaDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistPersonalComescuamaDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistPersonalComescuamaDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistPersonalComescuamaDTO.TotalPuntaje = TotalPuntaje;
            evaluacionAlistPersonalComescuamaDTO.CargaId = CargaId;
            evaluacionAlistPersonalComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistPersonalComescuamaBL.AgregarRegistro(evaluacionAlistPersonalComescuamaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistPersonalComescuamaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, string CIPPersonal, string CodigoCargo,
            string CodigoGradoPersonalMilitarEsperado, string CodigoEspecialidadGenericaActual, string CodigoGradoPersonalMilitarActual,
            string CodigoEspecialidadGenericaEsperado, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal TotalPuntaje)
        {
            EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO = new();
            evaluacionAlistPersonalComescuamaDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistPersonalComescuamaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistPersonalComescuamaDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistPersonalComescuamaDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistPersonalComescuamaDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistPersonalComescuamaDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarEsperado = CodigoGradoPersonalMilitarEsperado;
            evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaEsperado = CodigoEspecialidadGenericaEsperado;
            evaluacionAlistPersonalComescuamaDTO.CodigoGradoPersonalMilitarActual = CodigoGradoPersonalMilitarActual;
            evaluacionAlistPersonalComescuamaDTO.CodigoEspecialidadGenericaActual = CodigoEspecialidadGenericaActual;
            evaluacionAlistPersonalComescuamaDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistPersonalComescuamaDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistPersonalComescuamaDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistPersonalComescuamaDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistPersonalComescuamaDTO.TotalPuntaje = TotalPuntaje;
            evaluacionAlistPersonalComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistPersonalComescuamaBL.ActualizarFormato(evaluacionAlistPersonalComescuamaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistPersonalComescuamaDTO evaluacionAlistPersonalComescuamaDTO = new();
            evaluacionAlistPersonalComescuamaDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistPersonalComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistPersonalComescuamaBL.EliminarFormato(evaluacionAlistPersonalComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistPersonalComescuamaDTO> lista = new List<EvaluacionAlistPersonalComescuamaDTO>();
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

                    lista.Add(new EvaluacionAlistPersonalComescuamaDTO
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
                        TotalPuntaje = decimal.Parse(fila.GetCell(13).ToString()),
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("CodigoUnidadNaval   ", typeof(string)),
                    new DataColumn("FechaEvaluacion  ", typeof(string)),
                    new DataColumn("DNIPersonal  ", typeof(string)),
                    new DataColumn("CIPPersonal  ", typeof(string)),
                    new DataColumn("CodigoCargo  ", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarEsperado  ", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaEsperado  ", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarActual  ", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaActual  ", typeof(string)),
                    new DataColumn("GradoJerarquico  ", typeof(decimal)),
                    new DataColumn("ServicioExperiencia  ", typeof(decimal)),
                    new DataColumn("EspecializacionProfesional  ", typeof(decimal)),
                    new DataColumn("CursoProfesionalRequerido  ", typeof(decimal)),
                    new DataColumn("TotalPuntaje  ", typeof(decimal)),

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

                    User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionAlistPersonalComescuamaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCEAP(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comescuama\\ComescuamaEvaluacionAlistEntrenamiento.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = evaluacionAlistPersonalComescuamaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComescuamaEvaluacionAlistEntrenamiento", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComescuamaEvaluacionAlistPersonal.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComescuamaEvaluacionAlistPersonal.xlsx");
        }
    }

}

