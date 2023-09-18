using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DircitenPoblacionCentroIntruccionTNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PoblacionCentroIntruccionTNavalDAO poblacioncentroBL = new();
        CausalBajaDAO causalbajaBL = new();
        Carga cargaBL = new();

        public DircitenPoblacionCentroIntruccionTNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Población Centro Instrucción Técnica Naval ", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CausalBajaDTO> causalBajaDTO = causalbajaBL.ObtenerCausalBajas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PoblacionCentroIntruccionTNaval");
            return Json(new { data1 = causalBajaDTO, data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<PoblacionCentroIntruccionTNavalDTO> select = poblacioncentroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string DNIIntruccionTNaval, string GeneroIntruccionTNaval, string FechaNacimientoIntruccionTNaval,
           string LugarNacimiento, string LugarDomicilio, string FechaIngresoIntruccionTNaval, string AnoAcademico, string SemestreAcademico,
           int IndiceRendimientoIRAS, int NotaCaracterMilitar, int NotaFormacionFisica, int NotaConductaIntruccionTNaval, string ResultadoTerminoTrimestre,
           string CodigoCausalBaja, int CargaId)
        {
            PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO = new();
            poblacionCentroIntruccionTNavalDTO.DNIIntruccionTNaval = DNIIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.GeneroIntruccionTNaval = GeneroIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.FechaNacimientoIntruccionTNaval = FechaNacimientoIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.LugarNacimiento = LugarNacimiento;
            poblacionCentroIntruccionTNavalDTO.LugarDomicilio = LugarDomicilio;
            poblacionCentroIntruccionTNavalDTO.FechaIngresoIntruccionTNaval = FechaIngresoIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.AnoAcademico = AnoAcademico;
            poblacionCentroIntruccionTNavalDTO.SemestreAcademico = SemestreAcademico;
            poblacionCentroIntruccionTNavalDTO.IndiceRendimientoIRAS = IndiceRendimientoIRAS;
            poblacionCentroIntruccionTNavalDTO.NotaCaracterMilitar = NotaCaracterMilitar;
            poblacionCentroIntruccionTNavalDTO.NotaFormacionFisica = NotaFormacionFisica;
            poblacionCentroIntruccionTNavalDTO.NotaConductaIntruccionTNaval = NotaConductaIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.ResultadoTerminoTrimestre = ResultadoTerminoTrimestre;
            poblacionCentroIntruccionTNavalDTO.CodigoCausalBaja = CodigoCausalBaja;
            poblacionCentroIntruccionTNavalDTO.CargaId = CargaId;
            poblacionCentroIntruccionTNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = poblacioncentroBL.AgregarRegistro(poblacionCentroIntruccionTNavalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(poblacioncentroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIIntruccionTNaval, string GeneroIntruccionTNaval, string FechaNacimientoIntruccionTNaval,
           string LugarNacimiento, string LugarDomicilio, string FechaIngresoIntruccionTNaval, string AnoAcademico, string SemestreAcademico,
           int IndiceRendimientoIRAS, int NotaCaracterMilitar, int NotaFormacionFisica, int NotaConductaIntruccionTNaval, string ResultadoTerminoTrimestre,
           string CodigoCausalBaja)
        {
            PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO = new();
            poblacionCentroIntruccionTNavalDTO.PoblacionCentroIntruccionTNavalId = Id;
            poblacionCentroIntruccionTNavalDTO.DNIIntruccionTNaval = DNIIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.GeneroIntruccionTNaval = GeneroIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.FechaNacimientoIntruccionTNaval = FechaNacimientoIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.LugarNacimiento = LugarNacimiento;
            poblacionCentroIntruccionTNavalDTO.LugarDomicilio = LugarDomicilio;
            poblacionCentroIntruccionTNavalDTO.FechaIngresoIntruccionTNaval = FechaIngresoIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.AnoAcademico = AnoAcademico;
            poblacionCentroIntruccionTNavalDTO.SemestreAcademico = SemestreAcademico;
            poblacionCentroIntruccionTNavalDTO.IndiceRendimientoIRAS = IndiceRendimientoIRAS;
            poblacionCentroIntruccionTNavalDTO.NotaCaracterMilitar = NotaCaracterMilitar;
            poblacionCentroIntruccionTNavalDTO.NotaFormacionFisica = NotaFormacionFisica;
            poblacionCentroIntruccionTNavalDTO.NotaConductaIntruccionTNaval = NotaConductaIntruccionTNaval;
            poblacionCentroIntruccionTNavalDTO.ResultadoTerminoTrimestre = ResultadoTerminoTrimestre;
            poblacionCentroIntruccionTNavalDTO.CodigoCausalBaja = CodigoCausalBaja;
            poblacionCentroIntruccionTNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = poblacioncentroBL.ActualizaFormato(poblacionCentroIntruccionTNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO = new();
            poblacionCentroIntruccionTNavalDTO.PoblacionCentroIntruccionTNavalId = Id;
            poblacionCentroIntruccionTNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (poblacioncentroBL.EliminarFormato(poblacionCentroIntruccionTNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PoblacionCentroIntruccionTNavalDTO> lista = new List<PoblacionCentroIntruccionTNavalDTO>();
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

                    lista.Add(new PoblacionCentroIntruccionTNavalDTO
                    {
                        DNIIntruccionTNaval = fila.GetCell(0).ToString(),
                        GeneroIntruccionTNaval = fila.GetCell(1).ToString(),
                        FechaNacimientoIntruccionTNaval = fila.GetCell(2).ToString(),
                        LugarNacimiento = fila.GetCell(3).ToString(),
                        LugarDomicilio = fila.GetCell(4).ToString(),
                        FechaIngresoIntruccionTNaval = fila.GetCell(5).ToString(),
                        AnoAcademico = fila.GetCell(6).ToString(),
                        SemestreAcademico = fila.GetCell(7).ToString(),
                        IndiceRendimientoIRAS = int.Parse(fila.GetCell(8).ToString()),
                        NotaCaracterMilitar = int.Parse(fila.GetCell(9).ToString()),
                        NotaFormacionFisica = int.Parse(fila.GetCell(10).ToString()),
                        NotaConductaIntruccionTNaval = int.Parse(fila.GetCell(11).ToString()),
                        ResultadoTerminoTrimestre = fila.GetCell(12).ToString(),
                        CodigoCausalBaja = fila.GetCell(13).ToString()

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
                    new DataColumn("DNIIntruccionTNaval", typeof(string)),
                    new DataColumn("GeneroIntruccionTNaval", typeof(string)),
                    new DataColumn("FechaNacimientoIntruccionTNaval", typeof(string)),
                    new DataColumn("LugarNacimiento", typeof(string)),
                    new DataColumn("LugarDomicilio", typeof(string)),
                    new DataColumn("FechaIngresoIntruccionTNaval", typeof(string)),
                    new DataColumn("AnoAcademico", typeof(string)),
                    new DataColumn("SemestreAcademico", typeof(string)),
                    new DataColumn("IndiceRendimientoIRAS", typeof(int)),
                    new DataColumn("NotaCaracterMilitar", typeof(int)),
                    new DataColumn("NotaFormacionFisica", typeof(int)),
                    new DataColumn("NotaConductaIntruccionTNaval", typeof(int)),
                    new DataColumn("ResultadoTerminoTrimestre", typeof(string)),
                    new DataColumn("CodigoCausalBaja", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                             fila.GetCell(0).ToString(),
                             fila.GetCell(1).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                             fila.GetCell(3).ToString(),
                             fila.GetCell(4).ToString(),
                             UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                             fila.GetCell(6).ToString(),
                             fila.GetCell(7).ToString(),
                             int.Parse(fila.GetCell(8).ToString()),
                             int.Parse(fila.GetCell(9).ToString()),
                             int.Parse(fila.GetCell(10).ToString()),
                             int.Parse(fila.GetCell(11).ToString()),
                             fila.GetCell(12).ToString(),
                             fila.GetCell(13).ToString(),
                             User.obtenerUsuario());
            }
            var IND_OPERACION = poblacioncentroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = poblacioncentroBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


    }

}

