using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comciberdef;
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

    public class ComciberdefCiberataqueController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        Ciberataque ciberataqueBL = new();

        AccionAnteCiberataque accionAnteCiberataqueBL = new();
        TipoCiberataque tipoCiberataqueBL = new();
        SeveridadCiberataque severidadCiberataqueBL = new();
        Carga cargaBL = new();

        public ComciberdefCiberataqueController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Ciberataques", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {


            List<AccionAnteCiberataqueDTO> accionAnteCiberataqueDTO = accionAnteCiberataqueBL.ObtenerAccionAnteCiberataques();
            List<TipoCiberataqueDTO> tipoCiberataqueDTO = tipoCiberataqueBL.ObtenerTipoCiberataques();
            List<SeveridadCiberataqueDTO> severidadCiberAtaqueDTO = severidadCiberataqueBL.ObtenerSeveridadCiberataques();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("Ciberataque");

            return Json(new { data1 = accionAnteCiberataqueDTO, data2 = tipoCiberataqueDTO, data3 = severidadCiberAtaqueDTO, data4 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<CiberataqueDTO> select = ciberataqueBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(int IdentificadorCiberataque, string CodigoAccionAnteCiberataque, string FechaCiberataques, string CodigoTipoCiberataque,
            string CodigoSeveridadCiberataque, int CargaId)
        {
            CiberataqueDTO ciberataqueDTO = new();
            ciberataqueDTO.IdentificadorCiberataque = IdentificadorCiberataque;
            ciberataqueDTO.CodigoAccionAnteCiberataque = CodigoAccionAnteCiberataque;
            ciberataqueDTO.FechaCiberataques = FechaCiberataques;
            ciberataqueDTO.CodigoTipoCiberataque = CodigoTipoCiberataque;
            ciberataqueDTO.CodigoSeveridadCiberataque = CodigoSeveridadCiberataque;
            ciberataqueDTO.CargaId = CargaId;
            ciberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ciberataqueBL.AgregarRegistro(ciberataqueDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ciberataqueBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int IdentificadorCiberataque, string CodigoAccionAnteCiberataque, string FechaCiberataques,
            string CodigoTipoCiberataque, string CodigoSeveridadCiberataque)
        {
            CiberataqueDTO ciberataqueDTO = new();
            ciberataqueDTO.CiberataqueId = Id;
            ciberataqueDTO.IdentificadorCiberataque = IdentificadorCiberataque;
            ciberataqueDTO.CodigoAccionAnteCiberataque = CodigoAccionAnteCiberataque;
            ciberataqueDTO.FechaCiberataques = FechaCiberataques;
            ciberataqueDTO.CodigoTipoCiberataque = CodigoTipoCiberataque;
            ciberataqueDTO.CodigoSeveridadCiberataque = CodigoSeveridadCiberataque;
            ciberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ciberataqueBL.ActualizarFormato(ciberataqueDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CiberataqueDTO ciberataqueDTO = new();
            ciberataqueDTO.CiberataqueId = Id;
            ciberataqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ciberataqueBL.EliminarFormato(ciberataqueDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CiberataqueDTO> lista = new List<CiberataqueDTO>();
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

                    lista.Add(new CiberataqueDTO
                    {
                        IdentificadorCiberataque = int.Parse(fila.GetCell(0).ToString()),
                        CodigoAccionAnteCiberataque = fila.GetCell(1).ToString(),
                        FechaCiberataques = UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                        CodigoTipoCiberataque = fila.GetCell(3).ToString(),
                        CodigoSeveridadCiberataque = fila.GetCell(4).ToString()
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("IdentificadorCiberataque", typeof(int)),
                    new DataColumn("CodigoAccionAnteCiberataque", typeof(string)),
                    new DataColumn("FechaCiberataques", typeof(string)),
                    new DataColumn("CodigoTipoCiberataque", typeof(string)),
                    new DataColumn("CodigoSeveridadCiberataque", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = ciberataqueBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCA(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comciberdef\\ComciberdefVisualizacionCiberataque.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var reporteCA = ciberataqueBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComciberdefVisualizacionCiberataque", reporteCA);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult ReporteCCXSSA(string? accionAnteCiberataque = null, string? fecha_inicio = null, string? fecha_fin = null, int? CargaId=null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comciberdef\\ComciberdefCantCiberAtaqueXSeveridadSegunAccion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var reporteCCXSSA = ciberataqueBL.CantidadCiberataquesXSeveridadSegunAccion(accionAnteCiberataque, fecha_inicio, fecha_fin, CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComciberdefCantCiberAtaqueXSeveridadSegunAccion", reporteCCXSSA);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult ReporteCCATCA(string? tipoCiberataque = null, string? fecha_inicio = null, string? fecha_fin = null, int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comciberdef\\ComciberdefCantidadCiberAXtipoAccionSTCiberAtaques.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var reporteCCATCA = ciberataqueBL.CantidadCiberataquesXtipoAccionSegunTiposCiberataques(tipoCiberataque, fecha_inicio, fecha_fin, CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComciberdefCantidadCiberAXtipoAccionSTCiberAtaques", reporteCCATCA);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComciberdefCiberataque.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComciberdefCiberataque.xlsx");
        }




    }

}

