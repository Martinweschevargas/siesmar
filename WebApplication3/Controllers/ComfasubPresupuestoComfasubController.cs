using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfasub;
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
    public class ComfasubPresupuestoComfasubController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        PresupuestoComfasub presupuestoComfasubBL = new();

        UnidadNaval unidadNavalBL = new();
        SistemaPropulsion sistemaPropulsionBL = new();
        SubSistemaPropulsion subSistemaPropulsionBL = new();
        FuenteFinanciamiento fuenteFinanciamientoBL = new();
        SubUnidadEjecutora subUnidadEjecutoraBL = new();
        CentroGasto centroGastoBL = new();
        Partida partidaBL = new();
        Carga cargaBL = new();

        public ComfasubPresupuestoComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Presupuesto", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<SistemaPropulsionDTO> sistemaPropulsionDTO = sistemaPropulsionBL.ObtenerSistemaPropulsions();
            List<SubSistemaPropulsionDTO> subSistemaPropulsionDTO = subSistemaPropulsionBL.ObtenerSubSistemaPropulsions();
            List<FuenteFinanciamientoDTO> fuenteFinanciamientoDTO = fuenteFinanciamientoBL.ObtenerFuenteFinanciamientos();
            List<SubUnidadEjecutoraDTO> subUnidadEjecutoraDTO = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            List<CentroGastoDTO> centroGastoDTO = centroGastoBL.ObtenerCentroGastos();
            List<PartidaDTO> partidaDTO = partidaBL.ObtenerPartidas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PresupuestoComfasub");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = sistemaPropulsionDTO,
                data3 = subSistemaPropulsionDTO,
                data4 = fuenteFinanciamientoDTO,
                data5 = subUnidadEjecutoraDTO,
                data6 = centroGastoDTO,
                data7 = partidaDTO,
                data8 = listaCargas

            });
        }

        public IActionResult CargaTabla()
        {
            List<PresupuestoComfasubDTO> presupuestoComfasubDTO = presupuestoComfasubBL.ObtenerLista();
            return Json(new { data = presupuestoComfasubDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoSistemaPropulsion, string CodigoSubSistemaPropulsion,
            string CodigoFuenteFinanciamiento, string CodigoSubUnidadEjecutora, string CodigoCentroGasto, string CodigoPartida,  
            decimal PresupuestoAsignado, int CargaId, string Fecha)
        {
            PresupuestoComfasubDTO presupuestoComfasubDTO = new();
            presupuestoComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            presupuestoComfasubDTO.CodigoSistemaPropulsion = CodigoSistemaPropulsion;
            presupuestoComfasubDTO.CodigoSubSistemaPropulsion = CodigoSubSistemaPropulsion;
            presupuestoComfasubDTO.PresupuestoAsignado = PresupuestoAsignado;
            presupuestoComfasubDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            presupuestoComfasubDTO.CodigoSubUnidadEjecutora = CodigoSubUnidadEjecutora;
            presupuestoComfasubDTO.CodigoCentroGasto = CodigoCentroGasto;
            presupuestoComfasubDTO.CodigoPartida = CodigoPartida;
            presupuestoComfasubDTO.CargaId = CargaId;
            presupuestoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = presupuestoComfasubBL.AgregarRegistro(presupuestoComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(presupuestoComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int PresupuestoComfasubId, string CodigoUnidadNaval, string CodigoSistemaPropulsion, string CodigoSubSistemaPropulsion,
            string CodigoFuenteFinanciamiento, string CodigoSubUnidadEjecutora, string CodigoCentroGasto, string CodigoPartida,
            decimal PresupuestoAsignado)
        {
            PresupuestoComfasubDTO presupuestoComfasubDTO = new();
            presupuestoComfasubDTO.PresupuestoComfasubId = PresupuestoComfasubId;
            presupuestoComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            presupuestoComfasubDTO.CodigoSistemaPropulsion = CodigoSistemaPropulsion;
            presupuestoComfasubDTO.CodigoSubSistemaPropulsion = CodigoSubSistemaPropulsion;
            presupuestoComfasubDTO.PresupuestoAsignado = PresupuestoAsignado;
            presupuestoComfasubDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            presupuestoComfasubDTO.CodigoSubUnidadEjecutora = CodigoSubUnidadEjecutora;
            presupuestoComfasubDTO.CodigoCentroGasto = CodigoCentroGasto;
            presupuestoComfasubDTO.CodigoPartida = CodigoPartida;
            presupuestoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = presupuestoComfasubBL.ActualizarFormato(presupuestoComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PresupuestoComfasubDTO presupuestoComfasubDTO = new();
            presupuestoComfasubDTO.PresupuestoComfasubId = Id;
            presupuestoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (presupuestoComfasubBL.EliminarFormato(presupuestoComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PresupuestoComfasubDTO presupuestoComfasubDTO = new();
            presupuestoComfasubDTO.CargaId = Id;
            presupuestoComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (presupuestoComfasubBL.EliminarCarga(presupuestoComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PresupuestoComfasubDTO> lista = new List<PresupuestoComfasubDTO>();
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

                    lista.Add(new PresupuestoComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoSistemaPropulsion = fila.GetCell(1).ToString(),
                        CodigoSubSistemaPropulsion = fila.GetCell(2).ToString(),
                        PresupuestoAsignado = decimal.Parse(fila.GetCell(3).ToString()),
                        CodigoFuenteFinanciamiento = fila.GetCell(4).ToString(),
                        CodigoSubUnidadEjecutora = fila.GetCell(5).ToString(),
                        CodigoCentroGasto = fila.GetCell(6).ToString(),
                        CodigoPartida = fila.GetCell(7).ToString()
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoSistemaPropulsion", typeof(string)),
                    new DataColumn("CodigoSubSistemaPropulsion", typeof(string)),
                    new DataColumn("PresupuestoAsignado", typeof(decimal)),
                    new DataColumn("CodigoFuenteFinanciamiento", typeof(string)),
                    new DataColumn("CodigoSubUnidadEjecutora", typeof(string)),
                    new DataColumn("CodigoCentroGasto", typeof(string)),
                    new DataColumn("CodigoPartida", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = presupuestoComfasubBL.InsertarDatos(dt, Fecha);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = presupuestoComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubPresupuestoComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubPresupuestoComfasub.xlsx");
        }
    }

}