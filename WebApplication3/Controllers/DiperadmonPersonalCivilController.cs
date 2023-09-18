using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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
    public class DiperadmonPersonalCivilController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        LogicaNegocios.Formatos.Diperadmon.PersonalCivil personalCivilBL = new();
        CondicionLaboralCivil condicionLaboralCivilBL = new();
        GrupoOcupacionalCivil grupoOcupacionalCivilBL = new();
        GrupoRemunerativo gruporemunerativoBL = new();
        GradoRemunerativo gradoremunerativoBL = new();
        RegimenLaboral regimenlaboralBL = new();
        CarreraUniversitariaEspecialidad carrerauniversespeBL = new();
        SistemaPension sistemapension = new();
        Dependencia dependenciaBL = new();
        GradoEstudioAlcanzado gradoestudioalcanzadoBL = new();
        DepartamentoUbigeo departamentoBL = new();
        ProvinciaUbigeo provinciaBL = new();
        DistritoUbigeo distritoBL = new();
        Carga cargaBL = new();

        public DiperadmonPersonalCivilController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }


        //[AuthorizePermission(Formato: 43, Permiso: 2)]


        [Breadcrumb(FromAction = "Index", Title = "Personal Civil", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WsPercivi()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CondicionLaboralCivilDTO> condicionLaboralCivilDTO = condicionLaboralCivilBL.ObtenerCondicionLaboralCivils();
            List<GrupoOcupacionalCivilDTO> grupoOcupacionalCivilDTO = grupoOcupacionalCivilBL.ObtenerGrupoOcupacionalCivils();
            List<GrupoRemunerativoDTO> grupoRemunerativoDTO = gruporemunerativoBL.ObtenerGrupoRemunerativos();
            List<GradoRemunerativoDTO> gradoRemunerativoDTO = gradoremunerativoBL.ObtenerGradoRemunerativos();
            List<RegimenLaboralDTO> regimenLaboralDTO = regimenlaboralBL.ObtenerRegimenLaborals();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = carrerauniversespeBL.ObtenerCarreraUniversitariaEspecialidads();
            List<SistemaPensionDTO> sistemaPensionDTO = sistemapension.ObtenerSistemaPensions();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoEstudioAlcanzadoDTO> gradoEstudioAlcanzadoDTO = gradoestudioalcanzadoBL.ObtenerGradoEstudioAlcanzados();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PersonalCivil");
            return Json(new
            {
                data1 = grupoRemunerativoDTO,
                data2 = gradoRemunerativoDTO,
                data3 = regimenLaboralDTO,
                data4 = carreraUniversitariaEspecialidadDTO,
                data5 = sistemaPensionDTO,
                data6 = dependenciaDTO,
                data7 = gradoEstudioAlcanzadoDTO,
                data8 = distritoUbigeoDTO,
                data9 = provinciaUbigeoDTO,
                data10 = departamentoUbigeoDTO,
                data11 = condicionLaboralCivilDTO,
                data12 = grupoOcupacionalCivilDTO,
                data13 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<PersonalCivilDTO> select = personalCivilBL.ObtenerLista();
            return Json(new { data = select });
        }

        [AuthorizePermission(Formato: 612, Permiso: 2)]
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        [AuthorizePermission(Formato: 612, Permiso: 2)]
        public ActionResult Insertar(string TipoDocumentoPCivil, string DNIPCivil, string SexoPCivil,
            string CodigoCondicionLaboralCivil, string CodigoGrupoOcupacionalCivil, string NivelCargoPCivil,
           string CodigoGrupoRemunerativo, string CodigoGradoRemunerativo, string CodigoRegimenLaboral, string CodigoCarreraUniversitariaEspecialidad,
            string CodigoSistemaPension, string FechaIngresoInstPCivil, string CodigoDependencia,
           string DistritoLaboraPCivil, string FechaIngresoPCivil, string FechaNacimientoPCivil, string DistritoNacimientoPCivil,
            string EstadoCivilPCivil, string CodigoGradoEstudioAlcanzado, string GradoAñoEstudioPSPCivil,
           int AnioServicioPCivil, int CargaId, string fechacarga)
        {
            PersonalCivilDTO personalCivilDTO = new();
            personalCivilDTO.TipoDocumentoPCivil = TipoDocumentoPCivil;
            personalCivilDTO.DNIPCivil = DNIPCivil;
            personalCivilDTO.SexoPCivil = SexoPCivil;
            personalCivilDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            personalCivilDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            personalCivilDTO.NivelCargoPCivil = NivelCargoPCivil;
            personalCivilDTO.CodigoGrupoRemunerativo = CodigoGrupoRemunerativo;
            personalCivilDTO.CodigoGradoRemunerativo = CodigoGradoRemunerativo;
            personalCivilDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            personalCivilDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            personalCivilDTO.CodigoSistemaPension = CodigoSistemaPension;
            personalCivilDTO.FechaIngresoInstPCivil = FechaIngresoInstPCivil;
            personalCivilDTO.CodigoDependencia = CodigoDependencia;
            personalCivilDTO.DistritoLaboraPCivil = DistritoLaboraPCivil;
            personalCivilDTO.FechaIngresoPCivil = FechaIngresoPCivil;
            personalCivilDTO.FechaNacimientoPCivil = FechaNacimientoPCivil;
            personalCivilDTO.DistritoNacimientoPCivil = DistritoNacimientoPCivil;
            personalCivilDTO.EstadoCivilPCivil = EstadoCivilPCivil;
            personalCivilDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            personalCivilDTO.GradoAñoEstudioPSPCivil = GradoAñoEstudioPSPCivil;
            personalCivilDTO.AnioServicioPCivil = AnioServicioPCivil;
            personalCivilDTO.CargaId = CargaId;
            personalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalCivilBL.AgregarRegistro(personalCivilDTO, fechacarga);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(personalCivilBL.EditarFormado(Id));
        }

        [AuthorizePermission(Formato: 612, Permiso: 2)]
        public ActionResult Actualizar(int Id, string TipoDocumentoPCivil, string DNIPCivil, string SexoPCivil,
            string CodigoCondicionLaboralCivil, string CodigoGrupoOcupacionalCivil, string NivelCargoPCivil,
           string CodigoGrupoRemunerativo, string CodigoGradoRemunerativo, string CodigoRegimenLaboral, string CodigoCarreraUniversitariaEspecialidad,
            string CodigoSistemaPension, string FechaIngresoInstPCivil, string CodigoDependencia,
           string DistritoLaboraPCivil, string FechaIngresoPCivil, string FechaNacimientoPCivil, string DistritoNacimientoPCivil,
            string EstadoCivilPCivil, string CodigoGradoEstudioAlcanzado, string GradoAñoEstudioPSPCivil,
           int AnioServicioPCivil)
        {

            PersonalCivilDTO personalCivilDTO = new();
            personalCivilDTO.PersonalCivilId = Id;
            personalCivilDTO.TipoDocumentoPCivil = TipoDocumentoPCivil;
            personalCivilDTO.DNIPCivil = DNIPCivil;
            personalCivilDTO.SexoPCivil = SexoPCivil;
            personalCivilDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            personalCivilDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            personalCivilDTO.NivelCargoPCivil = NivelCargoPCivil;
            personalCivilDTO.CodigoGrupoRemunerativo = CodigoGrupoRemunerativo;
            personalCivilDTO.CodigoGradoRemunerativo = CodigoGradoRemunerativo;
            personalCivilDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            personalCivilDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            personalCivilDTO.CodigoSistemaPension = CodigoSistemaPension;
            personalCivilDTO.FechaIngresoInstPCivil = FechaIngresoInstPCivil;
            personalCivilDTO.CodigoDependencia = CodigoDependencia;
            personalCivilDTO.DistritoLaboraPCivil = DistritoLaboraPCivil;
            personalCivilDTO.FechaIngresoPCivil = FechaIngresoPCivil;
            personalCivilDTO.FechaNacimientoPCivil = FechaNacimientoPCivil;
            personalCivilDTO.DistritoNacimientoPCivil = DistritoNacimientoPCivil;
            personalCivilDTO.EstadoCivilPCivil = EstadoCivilPCivil;
            personalCivilDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            personalCivilDTO.GradoAñoEstudioPSPCivil = GradoAñoEstudioPSPCivil;
            personalCivilDTO.AnioServicioPCivil = AnioServicioPCivil;
            personalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalCivilBL.ActualizarFormato(personalCivilDTO);

            return Content(IND_OPERACION);
        }


        [AuthorizePermission(Formato: 612, Permiso: 2)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PersonalCivilDTO personalCivilDTO = new();
            personalCivilDTO.PersonalCivilId = Id;
            personalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalCivilBL.EliminarFormato(personalCivilDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [AuthorizePermission(Formato: 612, Permiso: 2)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PersonalCivilDTO personalCivilDTO = new();
            personalCivilDTO.CargaId = Id;
            personalCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalCivilBL.EliminarCarga(personalCivilDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<PersonalCivilDTO> lista = new List<PersonalCivilDTO>();
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

                    lista.Add(new PersonalCivilDTO
                    {
                        TipoDocumentoPCivil = fila.GetCell(0).ToString(),
                        DNIPCivil = fila.GetCell(1).ToString(),
                        SexoPCivil = fila.GetCell(2).ToString(),
                        CodigoCondicionLaboralCivil = fila.GetCell(3).ToString(),
                        CodigoGrupoOcupacionalCivil = fila.GetCell(4).ToString(),
                        NivelCargoPCivil = fila.GetCell(5).ToString(),
                        CodigoGrupoRemunerativo = fila.GetCell(6).ToString(),
                        CodigoGradoRemunerativo = fila.GetCell(7).ToString(),
                        CodigoRegimenLaboral = fila.GetCell(8).ToString(),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(9).ToString(),
                        CodigoSistemaPension = fila.GetCell(10).ToString(),
                        FechaIngresoInstPCivil = fila.GetCell(11).ToString(),
                        CodigoDependencia = fila.GetCell(12).ToString(),
                        DistritoLaboraPCivil = fila.GetCell(13).ToString(),
                        FechaIngresoPCivil = fila.GetCell(14).ToString(),
                        FechaNacimientoPCivil = fila.GetCell(15).ToString(),
                        DistritoNacimientoPCivil = fila.GetCell(16).ToString(),
                        EstadoCivilPCivil = fila.GetCell(17).ToString(),
                        CodigoGradoEstudioAlcanzado = fila.GetCell(18).ToString(),
                        GradoAñoEstudioPSPCivil = fila.GetCell(19).ToString(),
                        AnioServicioPCivil = int.Parse(fila.GetCell(20).ToString())
                    });
                }
            }
            catch (Exception e)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [AuthorizePermission(Formato: 612, Permiso: 2)]
        [HttpPost]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string fechacarga)
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

            dt.Columns.AddRange(new DataColumn[22]
            {
                    new DataColumn("TipoDocumentoPCivil", typeof(string)),
                    new DataColumn("DNIPCivil", typeof(string)),
                    new DataColumn("SexoPCivil", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralCivil", typeof(string)),
                    new DataColumn("CodigoGrupoOcupacionalCivil", typeof(string)),
                    new DataColumn("NivelCargoPCivil", typeof(string)),
                    new DataColumn("CodigoGrupoRemunerativo", typeof(string)),
                    new DataColumn("CodigoGradoRemunerativo", typeof(string)),
                    new DataColumn("CodigoRegimenLaboral", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad", typeof(string)),
                    new DataColumn("CodigoSistemaPension", typeof(string)),
                    new DataColumn("FechaIngresoInstPCivil", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("DistritoLaboraPCivil", typeof(string)),
                    new DataColumn("FechaIngresoPCivil", typeof(string)),
                    new DataColumn("FechaNacimientoPCivil", typeof(string)),
                    new DataColumn("DistritoNacimientoPCivil", typeof(string)),
                    new DataColumn("EstadoCivilPCivil", typeof(string)),
                    new DataColumn("CodigoGradoEstudioAlcanzado", typeof(string)),
                    new DataColumn("GradoAñoEstudioPSPCivil", typeof(string)),
                    new DataColumn("AnioServicioPCivil", typeof(int)),
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
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(11).ToString()),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    fila.GetCell(18).ToString(),
                    fila.GetCell(19).ToString(),
                    int.Parse(fila.GetCell(20).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = personalCivilBL.InsertarDatos(dt, fechacarga);
            return Content(IND_OPERACION);
        }

        //public IActionResult ReporteDPC(int? CargaId = null)
        //{

        //    string mimtype = "";
        //    //int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diperadmon\\PersonalCivil.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var personalcivil = personalCivilBL.ObtenerLista(CargaId);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("PersonalCivil", personalcivil);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [AuthorizePermission(Formato: 612, Permiso: 2)]
        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiperadmonPersonalCivil.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiperadmonPersonalCivil.xlsx");
        }
    }

}