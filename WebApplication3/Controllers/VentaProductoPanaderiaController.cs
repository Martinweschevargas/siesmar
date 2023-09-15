using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diabaste;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
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
    public class VentaProductoPanaderiaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        VentaProductoPanaderia ventaProductoPanaderiaBL = new();
        PuntoDistribucionPanificacion puntoDistribucionPanificacionBL = new();
        ProductoPanificacion productoPanificacionBL = new();
        Carga cargaBL = new();

        public VentaProductoPanaderiaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Venta de Productos de Panadería", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<PuntoDistribucionPanificacionDTO> puntoDistribucionPanificacionDTO = puntoDistribucionPanificacionBL.ObtenerPuntoDistribucionPanificacions();
            List<ProductoPanificacionDTO> productoPanificacionDTO = productoPanificacionBL.ObtenerProductos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("VentaProductoPanaderia");
            return Json(new
            {
                data1 = puntoDistribucionPanificacionDTO,
                data2 = productoPanificacionDTO,
                data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<VentaProductoPanaderiaDTO> ventaProductoPanaderiaDTO = ventaProductoPanaderiaBL.ObtenerLista();
            return Json(new { data = ventaProductoPanaderiaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string FechaVenta, string CodigoPuntoDistribucionPanificacion, 
            string CodigoProductoPanificacion, int CantidadProducidaConsumida, int CargaId, string Fecha)
        {
            VentaProductoPanaderiaDTO ventaProductoPanaderiaDTO = new();
            ventaProductoPanaderiaDTO.FechaVenta = FechaVenta;
            ventaProductoPanaderiaDTO.CodigoPuntoDistribucionPanificacion = CodigoPuntoDistribucionPanificacion;
            ventaProductoPanaderiaDTO.CodigoProductoPanificacion = CodigoProductoPanificacion;
            ventaProductoPanaderiaDTO.CantidadProducidaConsumida = CantidadProducidaConsumida;
            ventaProductoPanaderiaDTO.CargaId = CargaId;
            ventaProductoPanaderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ventaProductoPanaderiaBL.AgregarRegistro(ventaProductoPanaderiaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ventaProductoPanaderiaBL.EditarFormado(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string FechaVenta, string CodigoPuntoDistribucionPanificacion, 
            string CodigoProductoPanificacion, int CantidadProducidaConsumida)
        {
            VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO = new();
            VentaProductoPanaderiaDTO.VentaProductoPanaderiaId = Id;
            VentaProductoPanaderiaDTO.FechaVenta = FechaVenta;
            VentaProductoPanaderiaDTO.CodigoPuntoDistribucionPanificacion = CodigoPuntoDistribucionPanificacion;
            VentaProductoPanaderiaDTO.CodigoProductoPanificacion = CodigoProductoPanificacion;
            VentaProductoPanaderiaDTO.CantidadProducidaConsumida = CantidadProducidaConsumida;
            VentaProductoPanaderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ventaProductoPanaderiaBL.ActualizarFormato(VentaProductoPanaderiaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO = new();
            VentaProductoPanaderiaDTO.VentaProductoPanaderiaId = Id;
            VentaProductoPanaderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ventaProductoPanaderiaBL.EliminarFormato(VentaProductoPanaderiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            VentaProductoPanaderiaDTO VentaProductoPanaderiaDTO = new();
            VentaProductoPanaderiaDTO.CargaId = Id;
            VentaProductoPanaderiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (ventaProductoPanaderiaBL.EliminarCarga(VentaProductoPanaderiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<VentaProductoPanaderiaDTO> lista = new List<VentaProductoPanaderiaDTO>();
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

                    lista.Add(new VentaProductoPanaderiaDTO
                    {
                        FechaVenta = fila.GetCell(0).ToString(),
                        CodigoPuntoDistribucionPanificacion = fila.GetCell(1).ToString(),
                        CodigoProductoPanificacion = fila.GetCell(2).ToString(),
                        CantidadProducidaConsumida = int.Parse(fila.GetCell(3).ToString()),
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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("FechaVenta", typeof(string)),
                    new DataColumn("CodigoPuntoDistribucionPanificacion", typeof(string)),
                    new DataColumn("CodigoProductoPanificacion", typeof(string)),
                    new DataColumn("CantidadProducidaConsumida", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = ventaProductoPanaderiaBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\VentaProductoPanaderia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "VentaProductoPanaderia.xlsx");
        }
    }
}
