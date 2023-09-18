using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater;
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

    public class DibinfraterActosDisposicionFinalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ActosDisposicionFinal actosDisposicionFinalBL = new();
        Mes mesBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        ZonaNaval zonaNavalBL = new();
        TipoBien tipoBienBL = new();
        MedidaAdaptadaDisposicionFinal medidaAdaptadaDisposicionFinalBL = new();
        Carga cargaBL = new();

        public DibinfraterActosDisposicionFinalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Actos Disposición Final", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoBienDTO> tipoBienDTO = tipoBienBL.ObtenerTipoBiens();
            List<MedidaAdaptadaDisposicionFinalDTO> medidaAdaptadaDisposicionFinalDTO = medidaAdaptadaDisposicionFinalBL.ObtenerMedidaAdaptadaDisposicionFinals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ActoDisposicionFinal");
            return Json(new
            {
                data1 = mesDTO,
                data2 = areaDiperadmonDTO,
                data3 = zonaNavalDTO,
                data4 = tipoBienDTO,
                data5 = medidaAdaptadaDisposicionFinalDTO,
                data6 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<ActosDisposicionFinalDTO> select = actosDisposicionFinalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(int AnioActoDisposicionFinal, string NumeroMes, string IdentificacionDisposicionFinal, string CodigoAreaDiperadmon,
            string CodigoZonaNaval, string EstadoTramiteSolicitud, string CodigoTipoBien, string CodigoMedidaAdaptadaDisposicionFinal, int CantidadBienes, decimal Monto, int CargaId, string Fecha)
        {
            ActosDisposicionFinalDTO actosDisposicionFinalDTO = new();
            actosDisposicionFinalDTO.AnioActoDisposicionFinal = AnioActoDisposicionFinal;
            actosDisposicionFinalDTO.NumeroMes = NumeroMes;
            actosDisposicionFinalDTO.IdentificacionDisposicionFinal = IdentificacionDisposicionFinal;
            actosDisposicionFinalDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            actosDisposicionFinalDTO.CodigoZonaNaval = CodigoZonaNaval;
            actosDisposicionFinalDTO.EstadoTramiteSolicitud = EstadoTramiteSolicitud;
            actosDisposicionFinalDTO.CodigoTipoBien = CodigoTipoBien;
            actosDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal = CodigoMedidaAdaptadaDisposicionFinal;
            actosDisposicionFinalDTO.CantidadBienes = CantidadBienes;
            actosDisposicionFinalDTO.Monto = Monto;
            actosDisposicionFinalDTO.CargaId = CargaId;
            actosDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actosDisposicionFinalBL.AgregarRegistro(actosDisposicionFinalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actosDisposicionFinalBL.EditarFormado(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioActoDisposicionFinal, string NumeroMes, string IdentificacionDisposicionFinal, string CodigoAreaDiperadmon,
            string CodigoZonaNaval, string EstadoTramiteSolicitud, string CodigoTipoBien, string CodigoMedidaAdaptadaDisposicionFinal, int CantidadBienes, decimal Monto)
        {
            ActosDisposicionFinalDTO actosDisposicionFinalDTO = new();
            actosDisposicionFinalDTO.ActoDisposicionFinalId = Id;
            actosDisposicionFinalDTO.AnioActoDisposicionFinal = AnioActoDisposicionFinal;
            actosDisposicionFinalDTO.NumeroMes = NumeroMes;
            actosDisposicionFinalDTO.IdentificacionDisposicionFinal = IdentificacionDisposicionFinal;
            actosDisposicionFinalDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            actosDisposicionFinalDTO.CodigoZonaNaval = CodigoZonaNaval;
            actosDisposicionFinalDTO.EstadoTramiteSolicitud = EstadoTramiteSolicitud;
            actosDisposicionFinalDTO.CodigoTipoBien = CodigoTipoBien;
            actosDisposicionFinalDTO.CodigoMedidaAdaptadaDisposicionFinal = CodigoMedidaAdaptadaDisposicionFinal;
            actosDisposicionFinalDTO.CantidadBienes = CantidadBienes;
            actosDisposicionFinalDTO.Monto = Monto;
            actosDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actosDisposicionFinalBL.ActualizarFormato(actosDisposicionFinalDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {

            string mensaje = "";
            ActosDisposicionFinalDTO actosDisposicionFinalDTO = new();
            actosDisposicionFinalDTO.ActoDisposicionFinalId = Id;
            actosDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actosDisposicionFinalBL.EliminarFormato(actosDisposicionFinalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ActosDisposicionFinalDTO actosDisposicionFinalDTO = new();
            actosDisposicionFinalDTO.CargaId = Id;
            actosDisposicionFinalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (actosDisposicionFinalBL.EliminarCarga(actosDisposicionFinalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<ActosDisposicionFinalDTO> lista = new List<ActosDisposicionFinalDTO>();
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

                    lista.Add(new ActosDisposicionFinalDTO
                    {
                        AnioActoDisposicionFinal = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        IdentificacionDisposicionFinal = fila.GetCell(2).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(3).ToString(),
                        CodigoZonaNaval = fila.GetCell(4).ToString(),
                        EstadoTramiteSolicitud = fila.GetCell(5).ToString(),
                        CodigoTipoBien = fila.GetCell(6).ToString(),
                        CodigoMedidaAdaptadaDisposicionFinal = fila.GetCell(7).ToString(),
                        CantidadBienes = int.Parse(fila.GetCell(8).ToString()),
                        Monto = decimal.Parse(fila.GetCell(9).ToString())
                    });
                }
            }
            catch (Exception)
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
                    new DataColumn("AnioActoDisposicionFinal", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("IdentificacionDisposicionFinal", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("EstadoTramiteSolicitud", typeof(string)),
                    new DataColumn("CodigoTipoBien", typeof(string)),
                    new DataColumn("CodigoMedidaAdaptadaDisposicionFinal", typeof(string)),
                    new DataColumn("CantidadBienes", typeof(int)),
                    new DataColumn("Monto", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = actosDisposicionFinalBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DibinfraterActosDisposicionFinal.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DibinfraterActosDisposicionFinal.xlsx");
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = actosDisposicionFinalBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

     
    }
}

