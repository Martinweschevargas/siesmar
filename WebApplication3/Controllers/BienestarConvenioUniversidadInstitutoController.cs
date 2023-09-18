using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Bienestar;
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

    public class BienestarConvenioUniversidadInstitutoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ConvenioUniversidadInstituto conveniosUniversidadesInstitutosBL = new();

        PersonalSolicitante personalSolicitanteBL = new();
        CondicionSolicitante condicionSolicitanteBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        PersonalBeneficiado personalBeneficiadoBL = new();
        InstitucionEducativaSuperior institucionEducativaSuperiorBL = new();
        Carga cargaBL = new();

        public BienestarConvenioUniversidadInstitutoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Convenios con Universidades e Institutos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<PersonalSolicitanteDTO> personalSolicitanteDTO = personalSolicitanteBL.ObtenerPersonalSolicitantes();
            List<CondicionSolicitanteDTO> condicionSolicitanteDTO = condicionSolicitanteBL.ObtenerCondicionSolicitantes();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<PersonalBeneficiadoDTO> personalBeneficiadoDTO = personalBeneficiadoBL.ObtenerPersonalBeneficiados();
            List<InstitucionEducativaSuperiorDTO> institucionEducativaSuperior = institucionEducativaSuperiorBL.ObtenerInstitucionEducativaSuperiors();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ConvenioUniversidadInstituto");

            return Json(new { data1 = personalSolicitanteDTO, data2 = condicionSolicitanteDTO, data3 = gradoPersonalMilitarDTO,
                data4 = personalBeneficiadoDTO, data5 = institucionEducativaSuperior, data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ConvenioUniversidadInstitutoDTO> select = conveniosUniversidadesInstitutosBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }
        public ActionResult Insertar(string FechaSolicitudConvenio, string DNISolicitante, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoGradoPersonalMilitar, string CodigoPersonalBeneficiado, string NivelEstudioConvenio, string TipoEntidadAcademica,
            string CodigoInstitucionEducativaSuperior, string ResultadoSolicitud, string FechaResultadoSolicitud, int CargaId, string fechaCarga)
        {
            ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO = new();
            conveniosUniversidadesInstitutosDTO.FechaSolicitudConvenio = FechaSolicitudConvenio;
            conveniosUniversidadesInstitutosDTO.DNISolicitante = DNISolicitante;
            conveniosUniversidadesInstitutosDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            conveniosUniversidadesInstitutosDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            conveniosUniversidadesInstitutosDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            conveniosUniversidadesInstitutosDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            conveniosUniversidadesInstitutosDTO.NivelEstudioConvenio = NivelEstudioConvenio;
            conveniosUniversidadesInstitutosDTO.TipoEntidadAcademica = TipoEntidadAcademica;
            conveniosUniversidadesInstitutosDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            conveniosUniversidadesInstitutosDTO.ResultadoSolicitud = ResultadoSolicitud;
            conveniosUniversidadesInstitutosDTO.FechaResultadoSolicitud = FechaResultadoSolicitud;
            conveniosUniversidadesInstitutosDTO.CargaId = CargaId;
            conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = conveniosUniversidadesInstitutosBL.AgregarRegistro(conveniosUniversidadesInstitutosDTO, fechaCarga);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(conveniosUniversidadesInstitutosBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaSolicitudConvenio, string DNISolicitante, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoGradoPersonalMilitar, string CodigoPersonalBeneficiado, string NivelEstudioConvenio, string TipoEntidadAcademica,
            string CodigoInstitucionEducativaSuperior, string ResultadoSolicitud, string FechaResultadoSolicitud)
        {
            ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO = new();
            conveniosUniversidadesInstitutosDTO.ConvenioUniversidadInstitutoId = Id;
            conveniosUniversidadesInstitutosDTO.FechaSolicitudConvenio = FechaSolicitudConvenio;
            conveniosUniversidadesInstitutosDTO.DNISolicitante = DNISolicitante;
            conveniosUniversidadesInstitutosDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            conveniosUniversidadesInstitutosDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            conveniosUniversidadesInstitutosDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            conveniosUniversidadesInstitutosDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            conveniosUniversidadesInstitutosDTO.NivelEstudioConvenio = NivelEstudioConvenio;
            conveniosUniversidadesInstitutosDTO.TipoEntidadAcademica = TipoEntidadAcademica;
            conveniosUniversidadesInstitutosDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            conveniosUniversidadesInstitutosDTO.ResultadoSolicitud = ResultadoSolicitud;
            conveniosUniversidadesInstitutosDTO.FechaResultadoSolicitud = FechaResultadoSolicitud;
            conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = conveniosUniversidadesInstitutosBL.ActualizarFormato(conveniosUniversidadesInstitutosDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO = new();
            conveniosUniversidadesInstitutosDTO.ConvenioUniversidadInstitutoId = Id;
            conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (conveniosUniversidadesInstitutosBL.EliminarFormato(conveniosUniversidadesInstitutosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ConvenioUniversidadInstitutoDTO conveniosUniversidadesInstitutosDTO = new();
            conveniosUniversidadesInstitutosDTO.CargaId = Id;
            conveniosUniversidadesInstitutosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (conveniosUniversidadesInstitutosBL.EliminarCarga(conveniosUniversidadesInstitutosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ConvenioUniversidadInstitutoDTO> lista = new List<ConvenioUniversidadInstitutoDTO>();
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

                    lista.Add(new ConvenioUniversidadInstitutoDTO
                    {
                        FechaSolicitudConvenio = fila.GetCell(0).ToString(),
                        DNISolicitante = fila.GetCell(1).ToString(),
                        CodigoPersonalSolicitante = fila.GetCell(2).ToString(),
                        CodigoCondicionSolicitante = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        CodigoPersonalBeneficiado = fila.GetCell(5).ToString(),
                        NivelEstudioConvenio = fila.GetCell(6).ToString(),
                        TipoEntidadAcademica = fila.GetCell(7).ToString(),
                        CodigoInstitucionEducativaSuperior = fila.GetCell(8).ToString(),
                        ResultadoSolicitud = fila.GetCell(9).ToString(),
                        FechaResultadoSolicitud = fila.GetCell(10).ToString()
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string fechaCarga)
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
                    new DataColumn("FechaSolicitudConvenio", typeof(string)),
                    new DataColumn("DNISolicitante", typeof(string)),
                    new DataColumn("CodigoPersonalSolicitante", typeof(string)),
                    new DataColumn("CodigoCondicionSolicitante", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoPersonalBeneficiado", typeof(string)),
                    new DataColumn("NivelEstudioConvenio", typeof(string)),
                    new DataColumn("TipoEntidadAcademica", typeof(string)),
                    new DataColumn("CodigoInstitucionEducativaSuperior", typeof(string)),
                    new DataColumn("ResultadoSolicitud", typeof(string)),
                    new DataColumn("FechaResultadoSolicitud", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = conveniosUniversidadesInstitutosBL.InsertarDatos(dt, fechaCarga);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCUI(int? CargaId= null, string? fechaInicio=null, string? fechaFin=null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\ConvenioUniversidadInstituto.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var convenioUniversidadInstituto = conveniosUniversidadesInstitutosBL.BienestarVisualizacionConvenioUniversidadInstituto(CargaId, fechaInicio, fechaFin);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ConvenioUniversidadInstituto", convenioUniversidadInstituto);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DibiermarConveniosUniversidadesInstitutos.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DibiermarConveniosUniversidadesInstitutos.xlsx");
        }
    }

}

