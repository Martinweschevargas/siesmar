using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diredumar;
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
    public class DiredumarCapacitacionPerfeccionamientoExtraCController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        CapacitacionPerfeccionamientoExtraC capacitacionPerfeccionamientoExtraCBL = new();

        GrupoOcupacionalCivil grupoOcupacionalCivilBL = new();
        NivelEstudio nivelEstudioBL = new();
        InstitucionEducativaSuperior institucionEducativaSuperiorBL = new();
        CondicionLaboralCivil condicionLaboralCivilBL = new();
        PaisUbigeo paisUbigeoBL = new();
        Carga cargaBL = new();

        public DiredumarCapacitacionPerfeccionamientoExtraCController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Capacitación y Perfeccionamiento del Personal Civil", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<GrupoOcupacionalCivilDTO> grupoOcupacionalCivilDTO = grupoOcupacionalCivilBL.ObtenerGrupoOcupacionalCivils();
            List<NivelEstudioDTO> nivelEstudioDTO = nivelEstudioBL.ObtenerNivelEstudios();
            List<InstitucionEducativaSuperiorDTO> institucionEducativaSuperiorDTO = institucionEducativaSuperiorBL.ObtenerInstitucionEducativaSuperiors();
            List<CondicionLaboralCivilDTO> condicionLaboralCivilDTO = condicionLaboralCivilBL.ObtenerCondicionLaboralCivils();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CapacitacionPerfeccionamientoExtraC");

            return Json(new
            {
                data1 = grupoOcupacionalCivilDTO,
                data2 = nivelEstudioDTO,
                data3 = institucionEducativaSuperiorDTO,
                data4 = condicionLaboralCivilDTO,
                data5 = paisUbigeoDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<CapacitacionPerfeccionamientoExtraCDTO> select = capacitacionPerfeccionamientoExtraCBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CIPCapaPerfPCivil, string TipoDocumento, string DNICapaPerfPCivil, string CodigoGrupoOcupacionalCivil,
            string CodigoNivelEstudio, string CodigoInstitucionEducativaSuperior, string MencionCapacitacion, 
            string FinanciamientoCapacitacion, string CodigoCondicionLaboralCivil, string NumericoPais, int CargaId, string Fecha)
        {
            CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO = new();
            capacitacionPerfeccionamientoExtraCDTO.CIPCapaPerfPCivil = CIPCapaPerfPCivil;
            capacitacionPerfeccionamientoExtraCDTO.TipoDocumento = TipoDocumento;
            capacitacionPerfeccionamientoExtraCDTO.DNICapaPerfPCivil = DNICapaPerfPCivil;
            capacitacionPerfeccionamientoExtraCDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            capacitacionPerfeccionamientoExtraCDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            capacitacionPerfeccionamientoExtraCDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            capacitacionPerfeccionamientoExtraCDTO.MencionCapacitacion = MencionCapacitacion;
            capacitacionPerfeccionamientoExtraCDTO.FinanciamientoCapacitacion = FinanciamientoCapacitacion;
            capacitacionPerfeccionamientoExtraCDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            capacitacionPerfeccionamientoExtraCDTO.NumericoPais = NumericoPais;
            capacitacionPerfeccionamientoExtraCDTO.CargaId = CargaId;
            capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionPerfeccionamientoExtraCBL.AgregarRegistro(capacitacionPerfeccionamientoExtraCDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(capacitacionPerfeccionamientoExtraCBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CIPCapaPerfPCivil, string TipoDocumento, string DNICapaPerfPCivil, string CodigoGrupoOcupacionalCivil,
            string CodigoNivelEstudio, string CodigoInstitucionEducativaSuperior, string MencionCapacitacion,
            string FinanciamientoCapacitacion, string CodigoCondicionLaboralCivil, string NumericoPais)
        {
            CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO = new();
            capacitacionPerfeccionamientoExtraCDTO.CapacitacionPerfeccionamientoExtraCId = Id;
            capacitacionPerfeccionamientoExtraCDTO.CIPCapaPerfPCivil = CIPCapaPerfPCivil;
            capacitacionPerfeccionamientoExtraCDTO.TipoDocumento = TipoDocumento;
            capacitacionPerfeccionamientoExtraCDTO.DNICapaPerfPCivil = DNICapaPerfPCivil;
            capacitacionPerfeccionamientoExtraCDTO.CodigoGrupoOcupacionalCivil = CodigoGrupoOcupacionalCivil;
            capacitacionPerfeccionamientoExtraCDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            capacitacionPerfeccionamientoExtraCDTO.CodigoInstitucionEducativaSuperior = CodigoInstitucionEducativaSuperior;
            capacitacionPerfeccionamientoExtraCDTO.MencionCapacitacion = MencionCapacitacion;
            capacitacionPerfeccionamientoExtraCDTO.FinanciamientoCapacitacion = FinanciamientoCapacitacion;
            capacitacionPerfeccionamientoExtraCDTO.CodigoCondicionLaboralCivil = CodigoCondicionLaboralCivil;
            capacitacionPerfeccionamientoExtraCDTO.NumericoPais = NumericoPais;
            capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionPerfeccionamientoExtraCBL.ActualizarFormato(capacitacionPerfeccionamientoExtraCDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO = new();
            capacitacionPerfeccionamientoExtraCDTO.CapacitacionPerfeccionamientoExtraCId = Id;
            capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (capacitacionPerfeccionamientoExtraCBL.EliminarFormato(capacitacionPerfeccionamientoExtraCDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            CapacitacionPerfeccionamientoExtraCDTO capacitacionPerfeccionamientoExtraCDTO = new();
            capacitacionPerfeccionamientoExtraCDTO.CargaId = Id;
            capacitacionPerfeccionamientoExtraCDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionPerfeccionamientoExtraCBL.EliminarCarga(capacitacionPerfeccionamientoExtraCDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CapacitacionPerfeccionamientoExtraCDTO> lista = new List<CapacitacionPerfeccionamientoExtraCDTO>();
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

                    lista.Add(new CapacitacionPerfeccionamientoExtraCDTO
                    {

                        CIPCapaPerfPCivil = fila.GetCell(0).ToString(),
                        TipoDocumento = fila.GetCell(1).ToString(),
                        DNICapaPerfPCivil = fila.GetCell(2).ToString(),
                        CodigoGrupoOcupacionalCivil = fila.GetCell(3).ToString(),
                        CodigoNivelEstudio = fila.GetCell(4).ToString(),
                        CodigoInstitucionEducativaSuperior = fila.GetCell(5).ToString(),
                        MencionCapacitacion = fila.GetCell(6).ToString(),
                        FinanciamientoCapacitacion = fila.GetCell(7).ToString(),
                        CodigoCondicionLaboralCivil = fila.GetCell(8).ToString(),
                        NumericoPais = fila.GetCell(9).ToString(),
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("CIPCapaPerfPCivil", typeof(string)),
                    new DataColumn("TipoDocumento", typeof(string)),
                    new DataColumn("DNICapaPerfPCivil", typeof(string)),
                    new DataColumn("CodigoGrupoOcupacionalCivil", typeof(string)),
                    new DataColumn("CodigoNivelEstudio", typeof(string)),
                    new DataColumn("CodigoInstitucionEducativaSuperior", typeof(string)),
                    new DataColumn("MencionCapacitacion", typeof(string)),
                    new DataColumn("FinanciamientoCapacitacion", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralCivil", typeof(string)),
                    new DataColumn("NumericoPais", typeof(int)),
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

                    User.obtenerUsuario());
            }
            var IND_OPERACION = capacitacionPerfeccionamientoExtraCBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDCPEC(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diredumar\\CapacitacionPerfeccionamientoExtraPCivil.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capacitacionPerfeccionamientoExtraC = capacitacionPerfeccionamientoExtraCBL.DiredumarVisualizacionCapacitacionPerfeccionamientoExtraPCivil(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("CapacitacionPerfeccionamientoExtraPCivil", capacitacionPerfeccionamientoExtraC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiredumarCapacitacionPerfeccionamientoExtraC.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiredumarCapacitacionPerfeccionamientoExtraC.xlsx");
        }

    }

}