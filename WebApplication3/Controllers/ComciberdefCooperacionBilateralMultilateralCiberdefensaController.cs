    using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
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

    public class ComciberdefCooperacionBilateralMultilateralCiberdefensaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        CooperacionBilateralMultilateralCiberdefensa cooperacionBilateralMultilateralCiberdefensaBL = new();

        TipoAcuerdo tipoAcuerdoBL = new();
        Carga cargaBL = new();
        public ComciberdefCooperacionBilateralMultilateralCiberdefensaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Cooperación Bilateral y Multilateral en Ciberdefensa", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<TipoAcuerdoDTO> tipoAcuerdoDTO = tipoAcuerdoBL.ObtenerTipoAcuerdos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CooperacionBilateralMultilateralCiberdefensa");
            return Json(new { data1 = tipoAcuerdoDTO, data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<CooperacionBilateralMultilateralCiberdefensaDTO> select = cooperacionBilateralMultilateralCiberdefensaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaCooperacion, string CodigoTipoAcuerdo, string AsuntoCooperacion, int CargaId)
        {
            CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO = new();
            cooperacionBilateralMultilateralCiberdefensaDTO.FechaCooperacion = FechaCooperacion;
            cooperacionBilateralMultilateralCiberdefensaDTO.CodigoTipoAcuerdo = CodigoTipoAcuerdo;
            cooperacionBilateralMultilateralCiberdefensaDTO.AsuntoCooperacion = AsuntoCooperacion;
            cooperacionBilateralMultilateralCiberdefensaDTO.CargaId = CargaId;
            cooperacionBilateralMultilateralCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cooperacionBilateralMultilateralCiberdefensaBL.AgregarRegistro(cooperacionBilateralMultilateralCiberdefensaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(cooperacionBilateralMultilateralCiberdefensaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaCooperacion, string CodigoTipoAcuerdo, string AsuntoCooperacion)
        {
            CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO = new();
            cooperacionBilateralMultilateralCiberdefensaDTO.CooperacionBilateralMultilateralId = Id;
            cooperacionBilateralMultilateralCiberdefensaDTO.FechaCooperacion = FechaCooperacion;
            cooperacionBilateralMultilateralCiberdefensaDTO.CodigoTipoAcuerdo = CodigoTipoAcuerdo;
            cooperacionBilateralMultilateralCiberdefensaDTO.AsuntoCooperacion = AsuntoCooperacion;
            cooperacionBilateralMultilateralCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cooperacionBilateralMultilateralCiberdefensaBL.ActualizarFormato(cooperacionBilateralMultilateralCiberdefensaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO = new();
            cooperacionBilateralMultilateralCiberdefensaDTO.CooperacionBilateralMultilateralId = Id;
            cooperacionBilateralMultilateralCiberdefensaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (cooperacionBilateralMultilateralCiberdefensaBL.EliminarFormato(cooperacionBilateralMultilateralCiberdefensaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CooperacionBilateralMultilateralCiberdefensaDTO> lista = new List<CooperacionBilateralMultilateralCiberdefensaDTO>();
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
                    
                    lista.Add(new CooperacionBilateralMultilateralCiberdefensaDTO
                    {
                        FechaCooperacion = UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                        CodigoTipoAcuerdo = fila.GetCell(1).ToString(),
                        AsuntoCooperacion = fila.GetCell(2).ToString()
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

            dt.Columns.AddRange(new DataColumn[4]
            {
                    new DataColumn("FechaCooperacion", typeof(string)),
                    new DataColumn("CodigoTipoAcuerdo", typeof(string)),
                    new DataColumn("AsuntoCooperacion", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = cooperacionBilateralMultilateralCiberdefensaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCBMC(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comciberdef\\ComciberdefVCoopBilateralMultilateralCiberdefensa.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var reporteCBMC = cooperacionBilateralMultilateralCiberdefensaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComciberdefVCoopBilateralMultilateralCiberdefensa", reporteCBMC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComciberdefCooperacionBilateralMultiCD.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComciberdefCooperacionBilateralMultiCD.xlsx");
        }
        


    }

}

