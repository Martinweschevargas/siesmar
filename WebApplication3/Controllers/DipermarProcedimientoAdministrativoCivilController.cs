using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dipermar;
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

    public class DipermarProcedimientoAdministrativoCivilController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ProcedimientoAdministrativoCivil procedimientoAdministrativoCivilBL = new();
        GrupoOcupacionalCivil grupoOcupacionalCivilBL = new();
        Dependencia dependenciaBL = new();
        InfraccionDisciplinariaCivil infraccionDisciplinariaCivilBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL= new();
        SancionDisciplinariaCivil sancionDisciplinariaCivilBL = new();
        CondicionLaboralCivil condicionLaboralCivilBL = new();
        Cargo cargosBL = new();
        Carga cargoBL = new();

        public DipermarProcedimientoAdministrativoCivilController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Procedimiento Administrativo Disciplinario del Personal Civil", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GrupoOcupacionalCivilDTO> grupoOcupacionalCivilDTO = grupoOcupacionalCivilBL.ObtenerGrupoOcupacionalCivils();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<InfraccionDisciplinariaCivilDTO> infraccionDisciplinariaCivilDTO = infraccionDisciplinariaCivilBL.ObtenerInfraccionDisciplinariaCivils();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<SancionDisciplinariaCivilDTO> sancionDisciplinariaCivilDTO = sancionDisciplinariaCivilBL.ObtenerSancionDisciplinariaCivils();
            List<CondicionLaboralCivilDTO> condicionLaboralCivilDTO = condicionLaboralCivilBL.ObtenerCondicionLaboralCivils();
            List<CargoDTO> cargoDTO = cargosBL.ObtenerCargos();
            List<CargaDTO> listaCargas = cargoBL.ObtenerListaCargas("ProcedimientoAdministrativoCivil");

            return Json(new { data1 = grupoOcupacionalCivilDTO, data2 = dependenciaDTO,  data3 = infraccionDisciplinariaCivilDTO, 
                data4 = gradoPersonalMilitarDTO, data5 = sancionDisciplinariaCivilDTO, data6 = condicionLaboralCivilDTO,
                data7 = cargoDTO, data8 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ProcedimientoAdministrativoCivilDTO> select = procedimientoAdministrativoCivilBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar(string NroDocumentoProcedimientoAdm, string FechaDocumento, string CodigoCondicionLaboralCivil, string CodigoGrupoOcupacionalCivil,
           string CodigoCargo, string CodigoDependencia, string CodigoInfraccionDisciplinariaCivil, string SolicitanteSancion,
           string CodigoGradoPersonalMilitar, string CodigoCargoSolicitante, string CodigoGradoPersonalMilitarSansion, string CodigoCargoImponeSancion,
           string CodigoSancionDisciplinariaCivil, string InicioSancion, string TerminoSancion, int CargaId, string Fecha)
        {
            ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO = new();
            procedimientoAdministrativoCivilDTO.NroDocumentoProcedimientoAdm = NroDocumentoProcedimientoAdm;
            procedimientoAdministrativoCivilDTO.FechaDocumento = FechaDocumento;
            procedimientoAdministrativoCivilDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            procedimientoAdministrativoCivilDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            procedimientoAdministrativoCivilDTO.CodigoCargo = CodigoCargo;
            procedimientoAdministrativoCivilDTO.CodigoDependencia = CodigoDependencia;
            procedimientoAdministrativoCivilDTO.CodigoInfraccionDisciplinariaCivil = CodigoInfraccionDisciplinariaCivil;
            procedimientoAdministrativoCivilDTO.SolicitanteSancion = SolicitanteSancion;
            procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            procedimientoAdministrativoCivilDTO.CodigoCargoSolicitante = CodigoCargoSolicitante;
            procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitarSansion = CodigoGradoPersonalMilitarSansion;
            procedimientoAdministrativoCivilDTO.CodigoCargoImponeSancion = CodigoCargoImponeSancion;
            procedimientoAdministrativoCivilDTO.CodigoSancionDisciplinariaCivil = CodigoSancionDisciplinariaCivil;
            procedimientoAdministrativoCivilDTO.InicioSancion = InicioSancion;
            procedimientoAdministrativoCivilDTO.TerminoSancion = TerminoSancion;
            procedimientoAdministrativoCivilDTO.CargaId = CargaId;
            procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoAdministrativoCivilBL.AgregarRegistro(procedimientoAdministrativoCivilDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(procedimientoAdministrativoCivilBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id,string NroDocumentoProcedimientoAdm, string FechaDocumento, string CodigoCondicionLaboralCivil, string CodigoGrupoOcupacionalCivil,
           string CodigoCargo, string CodigoDependencia, string CodigoInfraccionDisciplinariaCivil, string SolicitanteSancion,
           string CodigoGradoPersonalMilitar, string CodigoCargoSolicitante, string CodigoGradoPersonalMilitarSansion, string CodigoCargoImponeSancion,
           string CodigoSancionDisciplinariaCivil, string InicioSancion, string TerminoSancion)
        {
            ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO = new();
            procedimientoAdministrativoCivilDTO.ProcedimientoAdministrativoCivilId = Id;
            procedimientoAdministrativoCivilDTO.NroDocumentoProcedimientoAdm = NroDocumentoProcedimientoAdm;
            procedimientoAdministrativoCivilDTO.FechaDocumento = FechaDocumento;
            procedimientoAdministrativoCivilDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            procedimientoAdministrativoCivilDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            procedimientoAdministrativoCivilDTO.CodigoCargo = CodigoCargo;
            procedimientoAdministrativoCivilDTO.CodigoDependencia = CodigoDependencia;
            procedimientoAdministrativoCivilDTO.CodigoInfraccionDisciplinariaCivil = CodigoInfraccionDisciplinariaCivil;
            procedimientoAdministrativoCivilDTO.SolicitanteSancion = SolicitanteSancion;
            procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            procedimientoAdministrativoCivilDTO.CodigoCargoSolicitante = CodigoCargoSolicitante;
            procedimientoAdministrativoCivilDTO.CodigoGradoPersonalMilitarSansion = CodigoGradoPersonalMilitarSansion;
            procedimientoAdministrativoCivilDTO.CodigoCargoImponeSancion = CodigoCargoImponeSancion;
            procedimientoAdministrativoCivilDTO.CodigoSancionDisciplinariaCivil = CodigoSancionDisciplinariaCivil;
            procedimientoAdministrativoCivilDTO.InicioSancion = InicioSancion;
            procedimientoAdministrativoCivilDTO.TerminoSancion = TerminoSancion;
            procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procedimientoAdministrativoCivilBL.ActualizarFormato(procedimientoAdministrativoCivilDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO = new();
            procedimientoAdministrativoCivilDTO.ProcedimientoAdministrativoCivilId = Id;
            procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (procedimientoAdministrativoCivilBL.EliminarFormato(procedimientoAdministrativoCivilDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO = new();
            procedimientoAdministrativoCivilDTO.CargaId = Id;
            procedimientoAdministrativoCivilDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (procedimientoAdministrativoCivilBL.EliminarCarga(procedimientoAdministrativoCivilDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ProcedimientoAdministrativoCivilDTO> lista = new List<ProcedimientoAdministrativoCivilDTO>();
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

                    lista.Add(new ProcedimientoAdministrativoCivilDTO
                    {
                        NroDocumentoProcedimientoAdm = fila.GetCell(0).ToString(),
                        FechaDocumento = fila.GetCell(1).ToString(),
                        CodigoCondicionLaboralCivil = fila.GetCell(2).ToString(),
                        CodigoGrupoOcupacionalCivil = fila.GetCell(3).ToString(),
                        CodigoCargo = fila.GetCell(4).ToString(),
                        CodigoDependencia = fila.GetCell(5).ToString(),
                        CodigoInfraccionDisciplinariaCivil = fila.GetCell(6).ToString(),
                        SolicitanteSancion = fila.GetCell(7).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(8).ToString(),
                        CodigoCargoSolicitante = fila.GetCell(9).ToString(),
                        CodigoGradoPersonalMilitarSansion = fila.GetCell(10).ToString(),
                        CodigoCargoImponeSancion = fila.GetCell(11).ToString(),
                        CodigoSancionDisciplinariaCivil = fila.GetCell(12).ToString(),
                        InicioSancion = fila.GetCell(13).ToString(),
                        TerminoSancion = fila.GetCell(14).ToString(),
 
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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
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

            dt.Columns.AddRange(new DataColumn[16]
            {
                    new DataColumn("NroDocumentoProcedimientoAdm", typeof(string)),
                    new DataColumn("FechaDocumento", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralCivil", typeof(string)),
                    new DataColumn("CodigoGrupoOcupacionalCivil", typeof(string)),
                    new DataColumn("CodigoCargo", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoInfraccionDisciplinariaCivil", typeof(string)),
                    new DataColumn("SolicitanteSancion", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoCargoSolicitante", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitarSansion", typeof(string)),
                    new DataColumn("CodigoCargoImponeSancion", typeof(string)),
                    new DataColumn("CodigoSancionDisciplinariaCivil", typeof(string)),
                    new DataColumn("InicioSancion", typeof(string)),
                    new DataColumn("TerminoSancion", typeof(string)),
 
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
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(1).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(1).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = procedimientoAdministrativoCivilBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReportePAC(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dipermar\\ProcedimientoAdministrativoCivil.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var procedimientoAdministrativoCivil = procedimientoAdministrativoCivilBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ProcedimientoAdministrativoCivil", procedimientoAdministrativoCivil);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DipermarProcedimientoAdministrativoCivil.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DipermarProcedimientoAdministrativoCivil.xlsx");
        }

    }

}

