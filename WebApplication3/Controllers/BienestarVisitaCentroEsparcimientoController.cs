using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
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
using System.Net;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class BienestarVisitaCentroEsparcimientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        VisitaCentroEsparcimiento visitaCentroEsparcimientoBL = new();

        UsuarioCentroEsparcimiento usuarioCentroEsparcimientoBL = new();
        ClubEsparcimiento clubEsparcimientoBL = new();
        Carga cargaBL = new();

        public BienestarVisitaCentroEsparcimientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Visitas a Centros de Esparcimiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UsuarioCentroEsparcimientoDTO> usuarioCentroEsparcimientoDTO = usuarioCentroEsparcimientoBL.ObtenerUsuarioCentroEsparcimientos();
            List<ClubEsparcimientoDTO> clubEsparcimientoDTO = clubEsparcimientoBL.ObtenerClubEsparcimientos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("VisitaCentroEsparcimiento");

            return Json(new { data1 = usuarioCentroEsparcimientoDTO, data2 = clubEsparcimientoDTO, data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<VisitaCentroEsparcimientoDTO> select = visitaCentroEsparcimientoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string FechaVisitaCentro, string DNIUsuario, string CodigoUsuarioCentroEsparcimiento, string CodigoClubEsparcimiento, int NumeroHoras,
            int NumeroInvitados, decimal MontoFacturado, int CargaId, string Fecha)
        {
            VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO = new();

            visitaCentroEsparcimientoDTO.FechaVisitaCentro = FechaVisitaCentro;
            visitaCentroEsparcimientoDTO.DNIUsuario = DNIUsuario;
            visitaCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento = CodigoUsuarioCentroEsparcimiento;
            visitaCentroEsparcimientoDTO.CodigoClubEsparcimiento = CodigoClubEsparcimiento;
            visitaCentroEsparcimientoDTO.NumeroHoras = NumeroHoras;
            visitaCentroEsparcimientoDTO.NumeroInvitados = NumeroInvitados;
            visitaCentroEsparcimientoDTO.MontoFacturado = MontoFacturado;
            visitaCentroEsparcimientoDTO.CargaId = CargaId;
            visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = visitaCentroEsparcimientoBL.AgregarRegistro(visitaCentroEsparcimientoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(visitaCentroEsparcimientoBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string FechaVisitaCentro, string DNIUsuario, string CodigoUsuarioCentroEsparcimiento,
            string CodigoClubEsparcimiento, int NumeroHoras, int NumeroInvitados, decimal MontoFacturado)
        {
            VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO = new();
            visitaCentroEsparcimientoDTO.VisitaCentroEsparcimientoId = Id;
            visitaCentroEsparcimientoDTO.FechaVisitaCentro = FechaVisitaCentro;
            visitaCentroEsparcimientoDTO.DNIUsuario = DNIUsuario;
            visitaCentroEsparcimientoDTO.CodigoUsuarioCentroEsparcimiento = CodigoUsuarioCentroEsparcimiento;
            visitaCentroEsparcimientoDTO.CodigoClubEsparcimiento = CodigoClubEsparcimiento;
            visitaCentroEsparcimientoDTO.NumeroHoras = NumeroHoras;
            visitaCentroEsparcimientoDTO.NumeroInvitados = NumeroInvitados;
            visitaCentroEsparcimientoDTO.MontoFacturado = MontoFacturado;
            visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = visitaCentroEsparcimientoBL.ActualizarFormato(visitaCentroEsparcimientoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO = new();
            visitaCentroEsparcimientoDTO.VisitaCentroEsparcimientoId = Id;
            visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (visitaCentroEsparcimientoBL.EliminarFormato(visitaCentroEsparcimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            VisitaCentroEsparcimientoDTO visitaCentroEsparcimientoDTO = new();
            visitaCentroEsparcimientoDTO.CargaId = Id;
            visitaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (visitaCentroEsparcimientoBL.EliminarCarga(visitaCentroEsparcimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<VisitaCentroEsparcimientoDTO> lista = new List<VisitaCentroEsparcimientoDTO>();
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

                    lista.Add(new VisitaCentroEsparcimientoDTO
                    {
                        FechaVisitaCentro = fila.GetCell(0).ToString(),
                        DNIUsuario = fila.GetCell(1).ToString(),
                        CodigoUsuarioCentroEsparcimiento = fila.GetCell(2).ToString(),
                        CodigoClubEsparcimiento = fila.GetCell(3).ToString(),
                        NumeroHoras = int.Parse(fila.GetCell(4).ToString()),
                        NumeroInvitados = int.Parse(fila.GetCell(5).ToString()),
                        MontoFacturado = decimal.Parse(fila.GetCell(6).ToString())
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("FechaVisitaCentro", typeof(string)),
                    new DataColumn("DNIUsuario", typeof(string)),
                    new DataColumn("CodigoUsuarioCentroEsparcimiento", typeof(string)),
                    new DataColumn("CodigoClubEsparcimiento", typeof(string)),
                    new DataColumn("NumeroHoras", typeof(int)),
                    new DataColumn("NumeroInvitados", typeof(int)),
                    new DataColumn("MontoFacturado", typeof(decimal)),
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
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = visitaCentroEsparcimientoBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        //public IActionResult ReporteBVCE(int idCarga)
        //{
   
        //    string mimtype = "";
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\VisitaCentroEsparcimiento.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var visitaCentroEsparcimiento = visitaCentroEsparcimientoBL.BienestarVisualizacionVisitaCentroEsparcimiento(idCarga);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("VisitaCentroEsparcimiento", visitaCentroEsparcimiento);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteTVMCETU()
        //{
        //    string mimtype = "";
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\TotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("ReportParameter1", "7");
        //    parameters.Add("ReportParameter2", "2023");
            
        //    var visitaCentroEsparcimiento = visitaCentroEsparcimientoBL.TotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio(7, 2023);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("TotalVisitasMensualesCentrosEsparcimientosXTipoUsuarioAnio", visitaCentroEsparcimiento);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarVisitaCentroEsparcimiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarVisitaCentroEsparcimiento.xlsx");
        }

    }

}

