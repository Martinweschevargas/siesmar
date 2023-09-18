using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresna;
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

    public class DiresnaPoblacionEscuelaNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PoblacionEscuelaNaval poblacionEscuelaNavalBL = new();
        AñoAcademicoEsna añoAcademicoEsnaBL = new();
        ResultadoTerminoSemestre resultadoTerminoSemestreBL = new();
        CausalBaja causalBajaBL = new();
        TipoAdmisionIngreso admisionIngresoBL = new();
        DepartamentoUbigeo departamentoBL = new();
        ProvinciaUbigeo provinciaBL = new();
        DistritoUbigeo distritoBL = new();
        Carga cargaBL = new();

        public DiresnaPoblacionEscuelaNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Población Escuela Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AñoAcademicoEsnaDTO> añoAcademicoEsnaDTO = añoAcademicoEsnaBL.ObtenerAñoAcademicoEsnas();
            List<ResultadoTerminoSemestreDTO> resultadoTerminoSemestreDTO = resultadoTerminoSemestreBL.ObtenerResultadoTerminoSemestres();
            List<CausalBajaDTO> causalBajaDTO = causalBajaBL.ObtenerCausalBajas();
            List<TipoAdmisionIngresoDTO> tipoAdmisionIngresoDTO = admisionIngresoBL.ObtenerTipoAdmisionIngresos();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PoblacionEscuelaNaval");

            return Json(new { data1 = añoAcademicoEsnaDTO, 
                data2 = resultadoTerminoSemestreDTO,  
                data3 = causalBajaDTO,
                data4 = tipoAdmisionIngresoDTO,
                data5 = distritoUbigeoDTO,
                data6 = provinciaUbigeoDTO,
                data7 = departamentoUbigeoDTO,
                data8 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<PoblacionEscuelaNavalDTO> select = poblacionEscuelaNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string DNIEstudianteEsna, string SexoEstudianteEsna, string FechaNacimientoEstudiante, 
            decimal TallaEstudianteEsna, decimal PesoEstudianteEsna, string DistritoNacimientoEstudiante, string DistritoDomicilioEstudiante,
            string FechaIngresoEstudiante, string BecadoEsna, string DistritoProcedencia, string CodigoAnioAcademicoEsna, string SemestreAcademico,
            decimal IRASEstudianteEsna, decimal NotaCaracterMilitar, decimal NotaFormacionFisica, decimal NotaConductaEstudiante,
            decimal IRGSEstudianteEsna, decimal IRGASEstudianteEsna, int OrdenMerito, string CodigoResultadoTerminoSemestre,
            string CodigoCausalBaja, string CodigoTipoAdmisionIngreso, int CargaId, string Fecha)
        {
            PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO = new();
            poblacionEscuelaNavalDTO.DNIEstudianteEsna = DNIEstudianteEsna;
            poblacionEscuelaNavalDTO.SexoEstudianteEsna = SexoEstudianteEsna;
            poblacionEscuelaNavalDTO.FechaNacimientoEstudiante = FechaNacimientoEstudiante;
            poblacionEscuelaNavalDTO.TallaEstudianteEsna = TallaEstudianteEsna;
            poblacionEscuelaNavalDTO.PesoEstudianteEsna = PesoEstudianteEsna;
            poblacionEscuelaNavalDTO.DistritoNacimientoEstudiante = DistritoNacimientoEstudiante;
            poblacionEscuelaNavalDTO.DistritoDomicilioEstudiante = DistritoDomicilioEstudiante;
            poblacionEscuelaNavalDTO.FechaIngresoEstudiante = FechaIngresoEstudiante;
            poblacionEscuelaNavalDTO.BecadoEsna = BecadoEsna;
            poblacionEscuelaNavalDTO.DistritoProcedencia = DistritoProcedencia;
            poblacionEscuelaNavalDTO.CodigoAnioAcademicoEsna = CodigoAnioAcademicoEsna;
            poblacionEscuelaNavalDTO.SemestreAcademico = SemestreAcademico;
            poblacionEscuelaNavalDTO.IRASEstudianteEsna = IRASEstudianteEsna;
            poblacionEscuelaNavalDTO.NotaCaracterMilitar = NotaCaracterMilitar;
            poblacionEscuelaNavalDTO.NotaFormacionFisica = NotaFormacionFisica;
            poblacionEscuelaNavalDTO.NotaConductaEstudiante = NotaConductaEstudiante;
            poblacionEscuelaNavalDTO.IRGSEstudianteEsna = IRGSEstudianteEsna;
            poblacionEscuelaNavalDTO.IRGASEstudianteEsna = IRGASEstudianteEsna;
            poblacionEscuelaNavalDTO.OrdenMerito = OrdenMerito;
            poblacionEscuelaNavalDTO.CodigoResultadoTerminoSemestre = CodigoResultadoTerminoSemestre;
            poblacionEscuelaNavalDTO.CodigoCausalBaja = CodigoCausalBaja;
            poblacionEscuelaNavalDTO.CodigoTipoAdmisionIngreso = CodigoTipoAdmisionIngreso;
            poblacionEscuelaNavalDTO.CargaId = CargaId;
            poblacionEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = poblacionEscuelaNavalBL.AgregarRegistro(poblacionEscuelaNavalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(poblacionEscuelaNavalBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIEstudianteEsna, string SexoEstudianteEsna, string FechaNacimientoEstudiante,
            decimal TallaEstudianteEsna, decimal PesoEstudianteEsna, string DistritoNacimientoEstudiante, string DistritoDomicilioEstudiante,
            string FechaIngresoEstudiante, string BecadoEsna, string DistritoProcedencia, string CodigoAnioAcademicoEsna, string SemestreAcademico,
            decimal IRASEstudianteEsna, decimal NotaCaracterMilitar, decimal NotaFormacionFisica, decimal NotaConductaEstudiante,
            decimal IRGSEstudianteEsna, decimal IRGASEstudianteEsna, int OrdenMerito, string CodigoResultadoTerminoSemestre,
            string CodigoCausalBaja, string CodigoTipoAdmisionIngreso)
        {
            PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO = new();
            poblacionEscuelaNavalDTO.PoblacionEscuelaNavalId = Id;
            poblacionEscuelaNavalDTO.DNIEstudianteEsna = DNIEstudianteEsna;
            poblacionEscuelaNavalDTO.SexoEstudianteEsna = SexoEstudianteEsna;
            poblacionEscuelaNavalDTO.FechaNacimientoEstudiante = FechaNacimientoEstudiante;
            poblacionEscuelaNavalDTO.TallaEstudianteEsna = TallaEstudianteEsna;
            poblacionEscuelaNavalDTO.PesoEstudianteEsna = PesoEstudianteEsna;
            poblacionEscuelaNavalDTO.DistritoNacimientoEstudiante = DistritoNacimientoEstudiante;
            poblacionEscuelaNavalDTO.DistritoDomicilioEstudiante = DistritoDomicilioEstudiante;
            poblacionEscuelaNavalDTO.FechaIngresoEstudiante = FechaIngresoEstudiante;
            poblacionEscuelaNavalDTO.BecadoEsna = BecadoEsna;
            poblacionEscuelaNavalDTO.DistritoProcedencia = DistritoProcedencia;
            poblacionEscuelaNavalDTO.CodigoAnioAcademicoEsna = CodigoAnioAcademicoEsna;
            poblacionEscuelaNavalDTO.SemestreAcademico = SemestreAcademico;
            poblacionEscuelaNavalDTO.IRASEstudianteEsna = IRASEstudianteEsna;
            poblacionEscuelaNavalDTO.NotaCaracterMilitar = NotaCaracterMilitar;
            poblacionEscuelaNavalDTO.NotaFormacionFisica = NotaFormacionFisica;
            poblacionEscuelaNavalDTO.NotaConductaEstudiante = NotaConductaEstudiante;
            poblacionEscuelaNavalDTO.IRGSEstudianteEsna = IRGSEstudianteEsna;
            poblacionEscuelaNavalDTO.IRGASEstudianteEsna = IRGASEstudianteEsna;
            poblacionEscuelaNavalDTO.OrdenMerito = OrdenMerito;
            poblacionEscuelaNavalDTO.CodigoResultadoTerminoSemestre = CodigoResultadoTerminoSemestre;
            poblacionEscuelaNavalDTO.CodigoCausalBaja = CodigoCausalBaja;
            poblacionEscuelaNavalDTO.CodigoTipoAdmisionIngreso = CodigoTipoAdmisionIngreso;
            poblacionEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = poblacionEscuelaNavalBL.ActualizarFormato(poblacionEscuelaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO = new();
            poblacionEscuelaNavalDTO.PoblacionEscuelaNavalId = Id;
            poblacionEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (poblacionEscuelaNavalBL.EliminarFormato(poblacionEscuelaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PoblacionEscuelaNavalDTO poblacionEscuelaNavalDTO = new();
            poblacionEscuelaNavalDTO.CargaId = Id;
            poblacionEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (poblacionEscuelaNavalBL.EliminarCarga(poblacionEscuelaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PoblacionEscuelaNavalDTO> lista = new List<PoblacionEscuelaNavalDTO>();
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

                    lista.Add(new PoblacionEscuelaNavalDTO
                    {
                        DNIEstudianteEsna = fila.GetCell(0).ToString(),
                        SexoEstudianteEsna = fila.GetCell(1).ToString(),
                        FechaNacimientoEstudiante = fila.GetCell(2).ToString(),
                        TallaEstudianteEsna = decimal.Parse(fila.GetCell(3).ToString()),
                        PesoEstudianteEsna = decimal.Parse(fila.GetCell(4).ToString()),
                        DistritoNacimientoEstudiante = fila.GetCell(5).ToString(),
                        DistritoDomicilioEstudiante = fila.GetCell(6).ToString(),
                        FechaIngresoEstudiante = fila.GetCell(7).ToString(),
                        BecadoEsna = fila.GetCell(8).ToString(),
                        DistritoProcedencia = fila.GetCell(9).ToString(),
                        CodigoAnioAcademicoEsna = fila.GetCell(10).ToString(),
                        SemestreAcademico = fila.GetCell(11).ToString(),
                        IRASEstudianteEsna = decimal.Parse(fila.GetCell(12).ToString()),
                        NotaCaracterMilitar = decimal.Parse(fila.GetCell(13).ToString()),
                        NotaFormacionFisica = decimal.Parse(fila.GetCell(14).ToString()),
                        NotaConductaEstudiante = decimal.Parse(fila.GetCell(15).ToString()),
                        IRGSEstudianteEsna = decimal.Parse(fila.GetCell(16).ToString()),
                        IRGASEstudianteEsna = decimal.Parse(fila.GetCell(17).ToString()),
                        OrdenMerito = int.Parse(fila.GetCell(18).ToString()),
                        CodigoResultadoTerminoSemestre = fila.GetCell(19).ToString(),
                        CodigoCausalBaja = fila.GetCell(20).ToString(),
                        CodigoTipoAdmisionIngreso = fila.GetCell(21).ToString(),

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

            dt.Columns.AddRange(new DataColumn[23]
            {
                    new DataColumn("DNIEstudianteEsna ", typeof(string)),
                    new DataColumn("SexoEstudianteEsna ", typeof(string)),
                    new DataColumn("FechaNacimientoEstudiante ", typeof(string)),
                    new DataColumn("TallaEstudianteEsna ", typeof(decimal)),
                    new DataColumn("PesoEstudianteEsna ", typeof(decimal)),
                    new DataColumn("DistritoNacimientoEstudiante ", typeof(string)),
                    new DataColumn("DistritoDomicilioEstudiante", typeof(string)),
                    new DataColumn("FechaIngresoEstudiante ", typeof(string)),
                    new DataColumn("BecadoEsna ", typeof(string)),
                    new DataColumn("DistritoProcedencia ", typeof(string)),
                    new DataColumn("CodigoAnioAcademicoEsna ", typeof(string)),
                    new DataColumn("SemestreAcademico ", typeof(string)),
                    new DataColumn("IRASEstudianteEsna ", typeof(decimal)),
                    new DataColumn("NotaCaracterMilitar ", typeof(decimal)),
                    new DataColumn("NotaFormacionFisica ", typeof(decimal)),
                    new DataColumn("NotaConductaEstudiante ", typeof(decimal)),
                    new DataColumn("IRGSEstudianteEsna ", typeof(decimal)),
                    new DataColumn("IRGASEstudianteEsna ", typeof(decimal)),
                    new DataColumn("OrdenMerito ", typeof(int)),
                    new DataColumn("CodigoResultadoTerminoSemestre ", typeof(string)),
                    new DataColumn("CodigoCausalBaja ", typeof(string)),
                    new DataColumn("CodigoTipoAdmisionIngreso ", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    decimal.Parse(fila.GetCell(12).ToString()),
                    decimal.Parse(fila.GetCell(13).ToString()),
                    decimal.Parse(fila.GetCell(14).ToString()),
                    decimal.Parse(fila.GetCell(15).ToString()),
                    decimal.Parse(fila.GetCell(16).ToString()),
                    decimal.Parse(fila.GetCell(17).ToString()),
                    int.Parse(fila.GetCell(18).ToString()),
                    fila.GetCell(19).ToString(),
                    fila.GetCell(20).ToString(),
                    fila.GetCell(21).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = poblacionEscuelaNavalBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }



        public IActionResult ReporteDPEN()
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresna\\PoblacionEscuelaNaval.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var personalSuperiorSubalterno = poblacionEscuelaNavalBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PoblacionEscuelaNaval", personalSuperiorSubalterno);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiresnaPoblacionEscuelaNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiresnaPoblacionEscuelaNaval.xlsx");
        }
    }

}