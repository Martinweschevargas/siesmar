using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavImpresionPublicacionAyudaNavegacionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ImpresionPublicacionAyudaNavegacion impresionPublicacionAyudaNavegacionBL = new();
        Producto tipoProductoBL = new();
        Frecuencia frecuenciaBL = new();
        Carga cargaBL = new();

        public DihidronavImpresionPublicacionAyudaNavegacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Impresión de publicaciones de ayudas a la navegación", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ProductoDTO> productoDTO = tipoProductoBL.ObtenerProductos(); 
            List<FrecuenciaDTO> frecuenciaDTO = frecuenciaBL.ObtenerFrecuencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ImpresionPublicacionAyudaNavegacion");

            return Json(new
            {
                data1 = productoDTO,
                data2 = frecuenciaDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ImpresionPublicacionAyudaNavegacionDTO> impresionPublicacionAyudaNavegacionDTO = impresionPublicacionAyudaNavegacionBL.ObtenerLista();
            return Json(new { data = impresionPublicacionAyudaNavegacionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string FechaEmision, string CodigoProducto , 
            string NumeroEdicion, string CodigoFrecuencia, int HidronavNumero, int CantidadProducida, int CargaId)
        {
            ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO = new();
            impresionPublicacionAyudaNavegacionDTO.NumeroOrden = NumeroOrden;
            impresionPublicacionAyudaNavegacionDTO.CodigoProducto  = CodigoProducto ;
            impresionPublicacionAyudaNavegacionDTO.HidronavNumero = HidronavNumero;
            impresionPublicacionAyudaNavegacionDTO.FechaEmision = FechaEmision;
            impresionPublicacionAyudaNavegacionDTO.NumeroEdicion = NumeroEdicion;
            impresionPublicacionAyudaNavegacionDTO.CantidadProducida = CantidadProducida;
            impresionPublicacionAyudaNavegacionDTO.CodigoFrecuencia = CodigoFrecuencia;
            impresionPublicacionAyudaNavegacionDTO.CargaId = CargaId;
            impresionPublicacionAyudaNavegacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = impresionPublicacionAyudaNavegacionBL.AgregarRegistro(impresionPublicacionAyudaNavegacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(impresionPublicacionAyudaNavegacionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ImpresionPublicacionAyudaNavegacionId, int NumeroOrden, string FechaEmision, string CodigoProducto ,
            string NumeroEdicion, string CodigoFrecuencia, int HidronavNumero, int CantidadProducida)
        {
            ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO = new();
            impresionPublicacionAyudaNavegacionDTO.ImpresionPublicacionAyudaNavegacionId = ImpresionPublicacionAyudaNavegacionId;
            impresionPublicacionAyudaNavegacionDTO.NumeroOrden = NumeroOrden;
            impresionPublicacionAyudaNavegacionDTO.CodigoProducto  = CodigoProducto ;
            impresionPublicacionAyudaNavegacionDTO.HidronavNumero = HidronavNumero;
            impresionPublicacionAyudaNavegacionDTO.FechaEmision = FechaEmision;
            impresionPublicacionAyudaNavegacionDTO.NumeroEdicion = NumeroEdicion;
            impresionPublicacionAyudaNavegacionDTO.CantidadProducida = CantidadProducida;
            impresionPublicacionAyudaNavegacionDTO.CodigoFrecuencia = CodigoFrecuencia;
            impresionPublicacionAyudaNavegacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = impresionPublicacionAyudaNavegacionBL.ActualizarFormato(impresionPublicacionAyudaNavegacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO = new();
            impresionPublicacionAyudaNavegacionDTO.ImpresionPublicacionAyudaNavegacionId = Id;
            impresionPublicacionAyudaNavegacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (impresionPublicacionAyudaNavegacionBL.EliminarFormato(impresionPublicacionAyudaNavegacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ImpresionPublicacionAyudaNavegacionDTO> lista = new List<ImpresionPublicacionAyudaNavegacionDTO>();
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

                    lista.Add(new ImpresionPublicacionAyudaNavegacionDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        CodigoProducto = fila.GetCell(1).ToString(),
                        HidronavNumero = int.Parse(fila.GetCell(2).ToString()),
                        FechaEmision = fila.GetCell(3).ToString(),
                        NumeroEdicion = fila.GetCell(4).ToString(),
                        CantidadProducida = int.Parse(fila.GetCell(5).ToString()),
                        CodigoFrecuencia = fila.GetCell(6).ToString()
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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
                  new DataColumn("NumeroOrden", typeof(int)),
                new DataColumn("CodigoProducto", typeof(string)),
                new DataColumn("HidronavNumero", typeof(int)),
                new DataColumn("FechaEmision", typeof(string)),
                new DataColumn("NumeroEdicion", typeof(string)),
                new DataColumn("CantidadProducida", typeof(int)),
                new DataColumn("CodigoFrecuencia", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = impresionPublicacionAyudaNavegacionBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }



        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavImpresionPublicacionAyudaNavegacion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavImpresionPublicacionAyudaNavegacion.xlsx");
        }
    }

}