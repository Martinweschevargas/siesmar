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
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class BienestarMovilidadEscolarController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        MovilidadEscolar movilidadEscolarBL = new();
        InstitucionEducativa institucionEducativaBL = new();
        MarcaVehiculo marcaVehiculoBL = new();
        Carga cargaBL = new();

        public BienestarMovilidadEscolarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Movilidad Escolar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<InstitucionEducativaDTO> institucionEducativaDTO = institucionEducativaBL.ObtenerInstitucionEducativas();
            List<MarcaVehiculoDTO> marcaVehiculo = marcaVehiculoBL.ObtenerMarcaVehiculos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("MovilidadEscolar");
            return Json(new { 
                data1 = institucionEducativaDTO, 
                data2 = marcaVehiculo, 
                data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<MovilidadEscolarDTO> select = movilidadEscolarBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
          
            return View();
        }
        public ActionResult Insertar(string Fecha, string NumeroPlaca, string CodigoMarcaVehiculo, int AnioFabricacion, int CapacidadTransporte,
            string CodigoInstitucionEducativa, int CantidadPersonasTransportadas, int CargaId, string fechaCarga)
        {
            MovilidadEscolarDTO movilidadEscolarDTO = new();
            movilidadEscolarDTO.Fecha = Fecha;
            movilidadEscolarDTO.NumeroPlaca = NumeroPlaca;
            movilidadEscolarDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            movilidadEscolarDTO.AnioFabricacion = AnioFabricacion;
            movilidadEscolarDTO.CapacidadTransporte = CapacidadTransporte;
            movilidadEscolarDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            movilidadEscolarDTO.CantidadPersonasTransportadas = CantidadPersonasTransportadas;
            movilidadEscolarDTO.CargaId = CargaId;
            movilidadEscolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = movilidadEscolarBL.AgregarRegistro(movilidadEscolarDTO, fechaCarga);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(movilidadEscolarBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string Fecha, string NumeroPlaca, string CodigoMarcaVehiculo, int AnioFabricacion, int CapacidadTransporte,
            string CodigoInstitucionEducativa, int CantidadPersonasTransportadas)
        {
            MovilidadEscolarDTO movilidadEscolarDTO = new();
            movilidadEscolarDTO.MovilidadEscolarId = Id;
            movilidadEscolarDTO.Fecha = Fecha;
            movilidadEscolarDTO.NumeroPlaca = NumeroPlaca;
            movilidadEscolarDTO.CodigoMarcaVehiculo = CodigoMarcaVehiculo;
            movilidadEscolarDTO.AnioFabricacion = AnioFabricacion;
            movilidadEscolarDTO.CapacidadTransporte = CapacidadTransporte;
            movilidadEscolarDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            movilidadEscolarDTO.CantidadPersonasTransportadas = CantidadPersonasTransportadas;
            movilidadEscolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = movilidadEscolarBL.ActualizarFormato(movilidadEscolarDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MovilidadEscolarDTO movilidadEscolarDTO = new();
            movilidadEscolarDTO.MovilidadEscolarId = Id;
            movilidadEscolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (movilidadEscolarBL.EliminarFormato(movilidadEscolarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            MovilidadEscolarDTO movilidadEscolarDTO = new();
            movilidadEscolarDTO.CargaId = Id;
            movilidadEscolarDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (movilidadEscolarBL.EliminarCarga(movilidadEscolarDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<MovilidadEscolarDTO> lista = new List<MovilidadEscolarDTO>();
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

                    lista.Add(new MovilidadEscolarDTO
                    {
                        Fecha = fila.GetCell(0).ToString(),
                        NumeroPlaca = fila.GetCell(1).ToString(),
                        CodigoMarcaVehiculo = fila.GetCell(2).ToString(),
                        AnioFabricacion = int.Parse(fila.GetCell(3).ToString()),
                        CapacidadTransporte = int.Parse(fila.GetCell(4).ToString()),
                        CodigoInstitucionEducativa = fila.GetCell(5).ToString(),
                        CantidadPersonasTransportadas = int.Parse(fila.GetCell(6).ToString())
                    });
                }
            }
            catch (Exception e)
            {
                Mensaje = "0";
            }
            return Json(new { data=Mensaje, data1=lista });
        }

        [HttpPost]
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
                    new DataColumn("Fecha", typeof(string)),
                    new DataColumn("NumeroPlaca", typeof(string)),
                    new DataColumn("CodigoMarcaVehiculo", typeof(string)),
                    new DataColumn("AnioFabricacion", typeof(int)),
                    new DataColumn("CapacidadTransporte", typeof(int)),
                    new DataColumn("CodigoInstitucionEducativa", typeof(string)),
                    new DataColumn("CantidadPersonasTransportadas", typeof(int)),
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
                    int.Parse(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    int.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = movilidadEscolarBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public ActionResult ReporteME(int? idCarga=null, string? fechaInicio=null, string fechaFin=null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\MovilidadEscolar.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var movilidadEscolar = movilidadEscolarBL.BienestarVisualizacionMovilidadEscolar(idCarga, fechaInicio, fechaFin);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("MovilidadEscolar", movilidadEscolar);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarMovilidadEscolar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarMovilidadEscolar.xlsx");
        }

    }

}

