using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Formatos.Jemgemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Dataset.Diperadmon;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DiperadmonPersonalMilitarMarineriaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        LogicaNegocios.Formatos.Diperadmon.PersonalMilitarMarineria personalmilitarmarBL = new();
        GradoPersonalMilitar gradopersonalmBL = new();
        Dependencia dependenciaBL = new();
        GradoEstudioAlcanzado gradoEstudioAlcanzadoBL = new();
        EspecialidadGenericaPersonal especialidadgenericaBL = new();
        CarreraUniversitariaEspecialidad carrerauniversitariaespecialidadBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        Carga cargaBL = new();

        public DiperadmonPersonalMilitarMarineriaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Personal Militar de Marinería ", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradopersonalmBL.ObtenerGradoPersonalMilitars();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoEstudioAlcanzadoDTO> gradoEstudioAlcanzadoDTO = gradoEstudioAlcanzadoBL.ObtenerGradoEstudioAlcanzados();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadgenericaBL.ObtenerEspecialidadGenericaPersonals();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaespeDTO = carrerauniversitariaespecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PersonalMilitarMarineria");
            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = dependenciaDTO,
                data3 = gradoEstudioAlcanzadoDTO,
                data4 = especialidadGenericaPersonalDTO,
                data5 = carreraUniversitariaespeDTO,
                data6 = distritoUbigeoDTO,
                data7 = provinciaUbigeoDTO,
                data8 = departamentoUbigeoDTO,
                data9 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<PersonalMilitarMarineriaDTO> select = personalmilitarmarBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string DNIPMilitarMar, string SexoPMilitarMar, string CodigoGradoPersonalMilitar,
           string UbigeoNacimiento, string FechaNacimientoPMilitarMar, string UbigeoLabora, string CodigoDependencia, string FechaIngresoInstPMilitarMar,
           string EstadoCivilPMilitarMar, string CodigoGradoEstudioAlcanzado, string GradoAñoEstudioPSPMilitarMar, string CodigoEspecialidadGenericaPersonal,
           string FechaAltaPMilitarMar, string FechaIngresoDepPMilitarMar, string FechaUltimoAscensoPMilitarMar, string FechaUltimoReenganchePMilitarMar,
           int PeriodoReenganchadoPMilitarMar, string CodigoCarreraUniversitariaEspecialidad, int CargaId,
           int mes, int anio)
        {
            PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO = new();
            personalMilitarMarineriaDTO.DNIPMilitarMar = DNIPMilitarMar;
            personalMilitarMarineriaDTO.SexoPMilitarMar = SexoPMilitarMar;
            personalMilitarMarineriaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            personalMilitarMarineriaDTO.UbigeoNacimiento = UbigeoNacimiento;
            personalMilitarMarineriaDTO.FechaNacimientoPMilitarMar = FechaNacimientoPMilitarMar;
            personalMilitarMarineriaDTO.UbigeoLabora = UbigeoLabora;
            personalMilitarMarineriaDTO.CodigoDependencia = CodigoDependencia;
            personalMilitarMarineriaDTO.FechaIngresoInstPMilitarMar = FechaIngresoInstPMilitarMar;
            personalMilitarMarineriaDTO.EstadoCivilPMilitarMar = EstadoCivilPMilitarMar;
            personalMilitarMarineriaDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            personalMilitarMarineriaDTO.GradoAñoEstudioPSPMilitarMar = GradoAñoEstudioPSPMilitarMar;
            personalMilitarMarineriaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            personalMilitarMarineriaDTO.FechaAltaPMilitarMar = FechaAltaPMilitarMar;
            personalMilitarMarineriaDTO.FechaIngresoDepPMilitarMar = FechaIngresoDepPMilitarMar;
            personalMilitarMarineriaDTO.FechaUltimoAscensoPMilitarMar = FechaUltimoAscensoPMilitarMar;
            personalMilitarMarineriaDTO.FechaUltimoReenganchePMilitarMar = FechaUltimoReenganchePMilitarMar;
            personalMilitarMarineriaDTO.PeriodoReenganchadoPMilitarMar = PeriodoReenganchadoPMilitarMar;
            personalMilitarMarineriaDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            personalMilitarMarineriaDTO.CargaId = CargaId;
            personalMilitarMarineriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalmilitarmarBL.AgregarRegistro(personalMilitarMarineriaDTO, mes, anio);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(personalmilitarmarBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIPMilitarMar, string SexoPMilitarMar, string CodigoGradoPersonalMilitar,
           string UbigeoNacimiento, string FechaNacimientoPMilitarMar, string UbigeoLabora, string CodigoDependencia, string FechaIngresoInstPMilitarMar,
           string EstadoCivilPMilitarMar, string CodigoGradoEstudioAlcanzado, string GradoAñoEstudioPSPMilitarMar, string CodigoEspecialidadGenericaPersonal,
           string FechaAltaPMilitarMar, string FechaIngresoDepPMilitarMar, string FechaUltimoAscensoPMilitarMar, string FechaUltimoReenganchePMilitarMar,
           int PeriodoReenganchadoPMilitarMar, string CodigoCarreraUniversitariaEspecialidad)
        {
            PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO = new();
            personalMilitarMarineriaDTO.PersonalMilitarMarineriaId = Id;
            personalMilitarMarineriaDTO.DNIPMilitarMar = DNIPMilitarMar;
            personalMilitarMarineriaDTO.SexoPMilitarMar = SexoPMilitarMar;
            personalMilitarMarineriaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            personalMilitarMarineriaDTO.UbigeoNacimiento = UbigeoNacimiento;
            personalMilitarMarineriaDTO.FechaNacimientoPMilitarMar = FechaNacimientoPMilitarMar;
            personalMilitarMarineriaDTO.UbigeoLabora = UbigeoLabora;
            personalMilitarMarineriaDTO.CodigoDependencia = CodigoDependencia;
            personalMilitarMarineriaDTO.FechaIngresoInstPMilitarMar = FechaIngresoInstPMilitarMar;
            personalMilitarMarineriaDTO.EstadoCivilPMilitarMar = EstadoCivilPMilitarMar;
            personalMilitarMarineriaDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            personalMilitarMarineriaDTO.GradoAñoEstudioPSPMilitarMar = GradoAñoEstudioPSPMilitarMar;
            personalMilitarMarineriaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            personalMilitarMarineriaDTO.FechaAltaPMilitarMar = FechaAltaPMilitarMar;
            personalMilitarMarineriaDTO.FechaIngresoDepPMilitarMar = FechaIngresoDepPMilitarMar;
            personalMilitarMarineriaDTO.FechaUltimoAscensoPMilitarMar = FechaUltimoAscensoPMilitarMar;
            personalMilitarMarineriaDTO.FechaUltimoReenganchePMilitarMar = FechaUltimoReenganchePMilitarMar;
            personalMilitarMarineriaDTO.PeriodoReenganchadoPMilitarMar = PeriodoReenganchadoPMilitarMar;
            personalMilitarMarineriaDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            personalMilitarMarineriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalmilitarmarBL.ActualizarFormato(personalMilitarMarineriaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO = new();
            personalMilitarMarineriaDTO.PersonalMilitarMarineriaId = Id;
            personalMilitarMarineriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalmilitarmarBL.EliminarFormato(personalMilitarMarineriaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PersonalMilitarMarineriaDTO personalMilitarMarineriaDTO = new();
            personalMilitarMarineriaDTO.CargaId = Id;
            personalMilitarMarineriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalmilitarmarBL.EliminarCarga(personalMilitarMarineriaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PersonalMilitarMarineriaDTO> lista = new List<PersonalMilitarMarineriaDTO>();
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

                    lista.Add(new PersonalMilitarMarineriaDTO
                    {
                        DNIPMilitarMar = fila.GetCell(0).ToString(),
                        SexoPMilitarMar = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        UbigeoNacimiento = fila.GetCell(3).ToString(),
                        FechaNacimientoPMilitarMar = fila.GetCell(4).ToString(),
                        UbigeoLabora = fila.GetCell(5).ToString(),
                        CodigoDependencia = fila.GetCell(6).ToString(),
                        FechaIngresoInstPMilitarMar = fila.GetCell(7).ToString(),
                        EstadoCivilPMilitarMar = fila.GetCell(8).ToString(),
                        CodigoGradoEstudioAlcanzado = fila.GetCell(9).ToString(),
                        GradoAñoEstudioPSPMilitarMar = fila.GetCell(10).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(11).ToString(),
                        FechaAltaPMilitarMar = fila.GetCell(12).ToString(),
                        FechaIngresoDepPMilitarMar = fila.GetCell(13).ToString(),
                        FechaUltimoAscensoPMilitarMar = fila.GetCell(14).ToString(),
                        FechaUltimoReenganchePMilitarMar = fila.GetCell(15).ToString(),
                        PeriodoReenganchadoPMilitarMar = int.Parse(fila.GetCell(16).ToString()),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(17).ToString()
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, int mes, int anio)
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

            dt.Columns.AddRange(new DataColumn[19]
            {
                    new DataColumn("DNIPMilitarMar", typeof(string)),
                    new DataColumn("SexoPMilitarMar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("UbigeoNacimiento", typeof(string)),
                    new DataColumn("FechaNacimientoPMilitarMar", typeof(string)),
                    new DataColumn("UbigeoLabora", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("FechaIngresoInstPMilitarMar", typeof(string)),
                    new DataColumn("EstadoCivilPMilitarMar", typeof(string)),
                    new DataColumn("CodigoGradoEstudioAlcanzado", typeof(string)),
                    new DataColumn("GradoAñoEstudioPSPMilitarMar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("FechaAltaPMilitarMar", typeof(string)),
                    new DataColumn("FechaIngresoDepPMilitarMar", typeof(string)),
                    new DataColumn("FechaUltimoAscensoPMilitarMar", typeof(string)),
                    new DataColumn("FechaUltimoReenganchePMilitarMar", typeof(string)),
                    new DataColumn("PeriodoReenganchadoPMilitarMar", typeof(int)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad", typeof(string)),

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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(12).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(13).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    int.Parse(fila.GetCell(16).ToString()),
                    fila.GetCell(17).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = personalmilitarmarBL.InsertarDatos(dt, mes, anio);
            return Content(IND_OPERACION);
        }

        ////public IActionResult ReporteDPMM(int? CargaId = null)
        ////{

        ////    string mimtype = "";
        ////    //int extension = 1;
        ////    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diperadmon\\PersonalMilitarMarineria.rdlc";
        ////    Dictionary<string, string> parameters = new Dictionary<string, string>();
        ////    var personalcivil = personalmilitarmarBL.ObtenerLista(CargaId);
        ////    LocalReport localReport = new LocalReport(path);
        ////    localReport.AddDataSource("PersonalMilitarMarineria", personalcivil);
        ////    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        ////    return File(result.MainStream, "application/pdf");
        ////}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiperadmonPersonalMilitarMarineria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiperadmonPersonalMilitarMarineria.xlsx");
        }
    }

}