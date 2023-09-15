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

    public class ComzotresEvaluacionAlistamientoPersonalComzotresController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionAlistamientoPersonalComzotres evaluacionAlistamientoPersonalComzotresBL = new();
        UnidadNaval unidadNavalBL = new();
        Cargo cargoBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        Carga cargaBL = new();

        public ComzotresEvaluacionAlistamientoPersonalComzotresController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionAlistamientoPersonalComzotres");
            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = cargoDTO,
                data3 = gradoPersonalMilitarDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionAlistamientoPersonalComzotresDTO> select = evaluacionAlistamientoPersonalComzotresBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal, 
            string CIPPersonal, string CodigoCargo, string CodigoGradoPersonalMilitar, decimal GradoJerarquico, 
            decimal ServicioExperiencia, decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, 
            decimal PuntajeTotalPersonal, int CargaId, string Fecha)
        {
            EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO = new();
            evaluacionAlistamientoPersonalComzotresDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComzotresDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComzotresDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComzotresDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComzotresDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComzotresDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            evaluacionAlistamientoPersonalComzotresDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComzotresDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComzotresDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComzotresDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComzotresDTO.PuntajeTotalPersonal = PuntajeTotalPersonal;
            evaluacionAlistamientoPersonalComzotresDTO.CargaId = CargaId;
            evaluacionAlistamientoPersonalComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComzotresBL.AgregarRegistro(evaluacionAlistamientoPersonalComzotresDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionAlistamientoPersonalComzotresBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string FechaEvaluacion, string DNIPersonal,
            string CIPPersonal, string CodigoCargo, string CodigoGradoPersonalMilitar, decimal GradoJerarquico, decimal ServicioExperiencia,
            decimal EspecializacionProfesional, decimal CursoProfesionalRequerido, decimal PuntajeTotalPersonal)
        { 
            EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO = new();
            evaluacionAlistamientoPersonalComzotresDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComzotresDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            evaluacionAlistamientoPersonalComzotresDTO.FechaEvaluacion = FechaEvaluacion;
            evaluacionAlistamientoPersonalComzotresDTO.DNIPersonal = DNIPersonal;
            evaluacionAlistamientoPersonalComzotresDTO.CIPPersonal = CIPPersonal;
            evaluacionAlistamientoPersonalComzotresDTO.CodigoCargo = CodigoCargo;
            evaluacionAlistamientoPersonalComzotresDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            evaluacionAlistamientoPersonalComzotresDTO.GradoJerarquico = GradoJerarquico;
            evaluacionAlistamientoPersonalComzotresDTO.ServicioExperiencia = ServicioExperiencia;
            evaluacionAlistamientoPersonalComzotresDTO.EspecializacionProfesional = EspecializacionProfesional;
            evaluacionAlistamientoPersonalComzotresDTO.CursoProfesionalRequerido = CursoProfesionalRequerido;
            evaluacionAlistamientoPersonalComzotresDTO.PuntajeTotalPersonal = PuntajeTotalPersonal;
            evaluacionAlistamientoPersonalComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionAlistamientoPersonalComzotresBL.ActualizarFormato(evaluacionAlistamientoPersonalComzotresDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO = new();
            evaluacionAlistamientoPersonalComzotresDTO.EvaluacionAlistamientoPersonalId = Id;
            evaluacionAlistamientoPersonalComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionAlistamientoPersonalComzotresBL.EliminarFormato(evaluacionAlistamientoPersonalComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionAlistamientoPersonalComzotresDTO evaluacionAlistamientoPersonalComzotresDTO = new();
            evaluacionAlistamientoPersonalComzotresDTO.CargaId = Id;
            evaluacionAlistamientoPersonalComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionAlistamientoPersonalComzotresBL.EliminarCarga(evaluacionAlistamientoPersonalComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionAlistamientoPersonalComzotresDTO> lista = new List<EvaluacionAlistamientoPersonalComzotresDTO>();
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

                    lista.Add(new EvaluacionAlistamientoPersonalComzotresDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        FechaEvaluacion = fila.GetCell(1).ToString(),
                        DNIPersonal = fila.GetCell(2).ToString(),
                        CIPPersonal = fila.GetCell(3).ToString(),
                        CodigoCargo = fila.GetCell(4).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(5).ToString(),
                        GradoJerarquico = decimal.Parse(fila.GetCell(6).ToString()),
                        ServicioExperiencia = decimal.Parse(fila.GetCell(7).ToString()),
                        EspecializacionProfesional = decimal.Parse(fila.GetCell(8).ToString()),
                        CursoProfesionalRequerido = decimal.Parse(fila.GetCell(9).ToString()),
                        PuntajeTotalPersonal = decimal.Parse(fila.GetCell(10).ToString()),
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
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(string)),
                    new DataColumn("CIPPersonal", typeof(string)),
                    new DataColumn("CodigoCargo", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
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
                    decimal.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = evaluacionAlistamientoPersonalComzotresBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzotresEvaluacionAlistamientoPersonalComzotres.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzotresEvaluacionAlistamientoPersonalComzotres.xlsx");
        }
    }
}

