using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Direcomar;
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

    public class DirecomarRendicionCuentasSBEGastosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        RendicionCuentasSBEGastos rendicionCuentasSBEGastosBL = new();

        Mes mesBL = new();
        SubUnidadEjecutora subUnidadEjecutoraBL = new();
        ClasificacionGenericaGasto clasificacionGenericaGastoBL = new();
        Carga cargaBL = new();

        public DirecomarRendicionCuentasSBEGastosController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> MesDTO = mesBL.ObtenerMess();
            List<SubUnidadEjecutoraDTO> SubUnidadEjecutoraDTO = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            List<ClasificacionGenericaGastoDTO> ClasificacionGenericaGastoDTO = clasificacionGenericaGastoBL.ObtenerClasificacionGenericaGastos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RendicionCuentaSUEGasto");

            return Json(new { data1 = MesDTO, data2 = SubUnidadEjecutoraDTO, data3 = ClasificacionGenericaGastoDTO , data4= listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<RendicionCuentasSBEGastosDTO> select = rendicionCuentasSBEGastosBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int AnioRendicionCuenta, int NumeroMes, string CodigoSubunidadEjecutora, string ClasificacionGenericaGasto
            , decimal Entregado, decimal Rendido, decimal Saldo, decimal EncargadoInterno,
            decimal GastoEncargo,decimal EncargoOtorgado, int CargaId, string Fecha)
        {
            RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO = new();
            rendicionCuentasSBEGastosDTO.AnioRendicionCuenta = AnioRendicionCuenta;
            rendicionCuentasSBEGastosDTO.NumeroMes = NumeroMes;
            rendicionCuentasSBEGastosDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            rendicionCuentasSBEGastosDTO.ClasificacionGenericaGasto = ClasificacionGenericaGasto;
            rendicionCuentasSBEGastosDTO.Entregado = Entregado;
            rendicionCuentasSBEGastosDTO.Rendido = Rendido;
            rendicionCuentasSBEGastosDTO.Saldo = Saldo;
            rendicionCuentasSBEGastosDTO.EncargadoInterno = EncargadoInterno;
            rendicionCuentasSBEGastosDTO.GastoEncargo = GastoEncargo;
            rendicionCuentasSBEGastosDTO.EncargoOtorgado = EncargoOtorgado;
            rendicionCuentasSBEGastosDTO.CargaId = CargaId;
            rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = rendicionCuentasSBEGastosBL.AgregarRegistro(rendicionCuentasSBEGastosDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(rendicionCuentasSBEGastosBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioRendicionCuenta, int NumeroMes, string CodigoSubunidadEjecutora, string ClasificacionGenericaGasto
            , decimal Entregado, decimal Rendido, decimal Saldo, decimal EncargadoInterno,
            decimal GastoEncargo,decimal EncargoOtorgado)
        {
            RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO = new();
            rendicionCuentasSBEGastosDTO.RendicionCuentaSBEGastoId = Id;
            rendicionCuentasSBEGastosDTO.AnioRendicionCuenta = AnioRendicionCuenta;
            rendicionCuentasSBEGastosDTO.NumeroMes = NumeroMes;
            rendicionCuentasSBEGastosDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            rendicionCuentasSBEGastosDTO.ClasificacionGenericaGasto = ClasificacionGenericaGasto;
            rendicionCuentasSBEGastosDTO.Entregado = Entregado;
            rendicionCuentasSBEGastosDTO.Rendido = Rendido;
            rendicionCuentasSBEGastosDTO.Saldo = Saldo;
            rendicionCuentasSBEGastosDTO.EncargadoInterno = EncargadoInterno;
            rendicionCuentasSBEGastosDTO.GastoEncargo = GastoEncargo;
            rendicionCuentasSBEGastosDTO.EncargoOtorgado = EncargoOtorgado;
            rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = rendicionCuentasSBEGastosBL.ActualizarFormato(rendicionCuentasSBEGastosDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO = new();
            rendicionCuentasSBEGastosDTO.RendicionCuentaSBEGastoId = Id;
            rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (rendicionCuentasSBEGastosBL.EliminarFormato(rendicionCuentasSBEGastosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RendicionCuentasSBEGastosDTO rendicionCuentasSBEGastosDTO = new();
            rendicionCuentasSBEGastosDTO.CargaId = Id;
            rendicionCuentasSBEGastosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (rendicionCuentasSBEGastosBL.EliminarCarga(rendicionCuentasSBEGastosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RendicionCuentasSBEGastosDTO> lista = new List<RendicionCuentasSBEGastosDTO>();
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

                    lista.Add(new RendicionCuentasSBEGastosDTO
                    {
                        AnioRendicionCuenta = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = int.Parse(fila.GetCell(1).ToString()),
                        CodigoSubunidadEjecutora = fila.GetCell(2).ToString(),
                        ClasificacionGenericaGasto = fila.GetCell(3).ToString(),
                        Entregado = decimal.Parse(fila.GetCell(4).ToString()),
                        Rendido = decimal.Parse(fila.GetCell(5).ToString()),
                        Saldo = decimal.Parse(fila.GetCell(6).ToString()),
                        EncargadoInterno = decimal.Parse(fila.GetCell(7).ToString()),
                        GastoEncargo = decimal.Parse(fila.GetCell(8).ToString()),
                        EncargoOtorgado = decimal.Parse(fila.GetCell(9).ToString())
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
        {
            Stream stream = ArchivoExcel.OpenReadStream();

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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("AnioRendicionCuenta", typeof(int)),
                    new DataColumn("NumeroMes", typeof(int)),
                    new DataColumn("CodigoSubunidadEjecutora", typeof(string)),
                    new DataColumn("ClasificacionGenericaGasto", typeof(string)),
                    new DataColumn("Entregado", typeof(decimal)),
                    new DataColumn("Rendido", typeof(decimal)),
                    new DataColumn("Saldo", typeof(decimal)),
                    new DataColumn("EncargadoInterno", typeof(decimal)),
                    new DataColumn("GastoEncargo", typeof(decimal)),
                    new DataColumn("EncargoOtorgado", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = rendicionCuentasSBEGastosBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDRCG(int? CargaId = null, string? fechaInicio= null, string fechaFin = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Direcomar\\RendicionCuentasSBEGastos.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var rendicionCuentasSBEGastos = rendicionCuentasSBEGastosBL.ObtenerLista(CargaId, fechaInicio, fechaFin);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RendicionCuentasSBEGastos", rendicionCuentasSBEGastos);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirecomarRendicionCuentasSBEGastos.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "RendicionCuentasSBEGastos.xlsx");
        }
    }

}
