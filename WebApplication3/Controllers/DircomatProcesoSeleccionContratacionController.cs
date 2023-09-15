using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dircomat;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dircomat;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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
    public class DircomatProcesoSeleccionContratacionController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        ProcesoSeleccionContratacionDAO  procesoSeleccionContratacionBL = new();
        MesDAO mesBL = new();
        TipoSeleccionDAO tiposelecionBL = new();
        EntidadConvocanteDAO entidadConvocanteBL = new();
        FuenteFinanciamientoDAO fuenteFinanciamientoBL = new();
        ObjetoContratacionDAO objetoContratacionBL = new();
        MonedaDAO monedaBL = new();
        SubUnidadEjecutoraDAO subUnidadEjecutoraBL = new();
        AreaTecnicaDAO areatecnicaBL = new();
        ObservacionProcesoDAO observacionProcesoBL = new();
        AreaDiperadmonDAO areaDiperadmonBL = new();
        Carga cargaBL = new();

        public DircomatProcesoSeleccionContratacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Proceso de Selección y Contrataciones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<TipoSeleccionDTO> tipoSeleccionDTO = tiposelecionBL.ObtenerTipoSeleccions();
            List<EntidadConvocanteDTO> entidadConvocanteDTO = entidadConvocanteBL.ObtenerEntidadConvocantes();
            List<FuenteFinanciamientoDTO> FuenteFinanciamientoDTO = fuenteFinanciamientoBL.ObtenerFuenteFinanciamientos();
            List<ObjetoContratacionDTO> objetoContratacionDTO = objetoContratacionBL.ObtenerObjetoContratacions();
            List<MonedaDTO> monedaDTO = monedaBL.ObtenerMonedas();
            List<SubUnidadEjecutoraDTO> subUnidadEjecutoraDTO = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            List<AreaTecnicaDTO> areaTecnicaDTO = areatecnicaBL.ObtenerAreaTecnicas();
            List<ObservacionProcesoDTO> observacionProcesoDTO = observacionProcesoBL.ObtenerObservacionProcesos();
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ProcesoSeleccionContratacion");

            return Json(new { data1 = mesDTO, data2 = tipoSeleccionDTO ,data3 = entidadConvocanteDTO,
                data4 = FuenteFinanciamientoDTO,
                data5 = objetoContratacionDTO,
                data6 = monedaDTO,
                data7 = subUnidadEjecutoraDTO,
                data8 = areaTecnicaDTO,
                data9 = observacionProcesoDTO,
                data10 = areaDiperadmonDTO,
                data11 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ProcesoSeleccionContratacionDTO> lista = procesoSeleccionContratacionBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string NumeroMes, string NroPAC, string CodigoTipoSeleccion, string CodigoEntidadConvocante,
            string CodigoFuenteFinanciamiento, string CodigoObjetoContratacion, string CodigoMoneda,decimal MontoProcesoSiacomar,
            string CodigoSubUnidadEjecutora, string CodigoAreaTecnica, string CodigoAreaDiperadmon, decimal ValorReferencia, string CodigoObservacionProceso,
            string FechaConvocatoria, string FechaBuenaPro, string CodigoMonedaReferencia, string CodigoMonedaAdjudicado,  decimal MontoAdjudicado,int CargaId, string Fecha)
        {
            ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO = new();
            procesoSeleccionContratacionDTO.NumeroMes = NumeroMes;
            procesoSeleccionContratacionDTO.NroPAC = NroPAC;
            procesoSeleccionContratacionDTO.CodigoTipoSeleccion = CodigoTipoSeleccion;
            procesoSeleccionContratacionDTO.CodigoEntidadConvocante = CodigoEntidadConvocante;
            procesoSeleccionContratacionDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            procesoSeleccionContratacionDTO.CodigoObjetoContratacion = CodigoObjetoContratacion;
            procesoSeleccionContratacionDTO.CodigoMoneda = CodigoMoneda;
            procesoSeleccionContratacionDTO.MontoProcesoSiacomar = MontoProcesoSiacomar;
            procesoSeleccionContratacionDTO.CodigoSubUnidadEjecutora = CodigoSubUnidadEjecutora;
            procesoSeleccionContratacionDTO.CodigoAreaTecnica = CodigoAreaTecnica;
            procesoSeleccionContratacionDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            procesoSeleccionContratacionDTO.CodigoMonedaReferencia = CodigoMonedaReferencia;
            procesoSeleccionContratacionDTO.ValorReferencia = ValorReferencia;
            procesoSeleccionContratacionDTO.CodigoObservacionProceso = CodigoObservacionProceso;
            procesoSeleccionContratacionDTO.FechaConvocatoria = FechaConvocatoria;
            procesoSeleccionContratacionDTO.FechaBuenaPro = FechaBuenaPro;
            procesoSeleccionContratacionDTO.CodigoMonedaAdjudicado = CodigoMonedaAdjudicado;
            procesoSeleccionContratacionDTO.MontoAdjudicado = MontoAdjudicado;
            procesoSeleccionContratacionDTO.CargaId = CargaId;
            procesoSeleccionContratacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procesoSeleccionContratacionBL.AgregarRegistro(procesoSeleccionContratacionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(procesoSeleccionContratacionBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string NumeroMes, string NroPAC, string CodigoTipoSeleccion, string CodigoEntidadConvocante,
            string CodigoFuenteFinanciamiento, string CodigoObjetoContratacion, string CodigoMoneda, decimal MontoProcesoSiacomar,
            string CodigoSubUnidadEjecutora, string CodigoAreaTecnica, string CodigoAreaDiperadmon, string CodigoMonedaReferencia, decimal ValorReferencia, string CodigoObservacionProceso,
            string FechaConvocatoria, string FechaBuenaPro,  string CodigoMonedaAdjudicado, decimal MontoAdjudicado)
        {
            
            ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO = new();
            procesoSeleccionContratacionDTO.ProcesoSeleccionContratacionId = Id;
            procesoSeleccionContratacionDTO.NumeroMes = NumeroMes;
            procesoSeleccionContratacionDTO.NroPAC = NroPAC;
            procesoSeleccionContratacionDTO.CodigoTipoSeleccion = CodigoTipoSeleccion;
            procesoSeleccionContratacionDTO.CodigoEntidadConvocante = CodigoEntidadConvocante;
            procesoSeleccionContratacionDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            procesoSeleccionContratacionDTO.CodigoObjetoContratacion = CodigoObjetoContratacion;
            procesoSeleccionContratacionDTO.CodigoMoneda = CodigoMoneda;
            procesoSeleccionContratacionDTO.MontoProcesoSiacomar = MontoProcesoSiacomar;
            procesoSeleccionContratacionDTO.CodigoSubUnidadEjecutora = CodigoSubUnidadEjecutora;
            procesoSeleccionContratacionDTO.CodigoAreaTecnica = CodigoAreaTecnica;
            procesoSeleccionContratacionDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            procesoSeleccionContratacionDTO.CodigoMonedaReferencia = CodigoMonedaReferencia;
            procesoSeleccionContratacionDTO.ValorReferencia = ValorReferencia;
            procesoSeleccionContratacionDTO.CodigoObservacionProceso = CodigoObservacionProceso;
            procesoSeleccionContratacionDTO.FechaConvocatoria = FechaConvocatoria;
            procesoSeleccionContratacionDTO.FechaBuenaPro = FechaBuenaPro;
            procesoSeleccionContratacionDTO.CodigoMonedaAdjudicado = CodigoMonedaAdjudicado;
            procesoSeleccionContratacionDTO.MontoAdjudicado = MontoAdjudicado;
            procesoSeleccionContratacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procesoSeleccionContratacionBL.ActualizaFormato(procesoSeleccionContratacionDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO = new();
            procesoSeleccionContratacionDTO.ProcesoSeleccionContratacionId = Id;
            procesoSeleccionContratacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (procesoSeleccionContratacionBL.EliminarFormato(procesoSeleccionContratacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO = new();
            procesoSeleccionContratacionDTO.CargaId = Id;
            procesoSeleccionContratacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (procesoSeleccionContratacionBL.EliminarCarga(procesoSeleccionContratacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ProcesoSeleccionContratacionDTO> lista = new List<ProcesoSeleccionContratacionDTO>();
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

                    lista.Add(new ProcesoSeleccionContratacionDTO
                    {
                        NumeroMes = fila.GetCell(0).ToString(),
                        NroPAC = fila.GetCell(1).ToString(),
                        CodigoTipoSeleccion = fila.GetCell(2).ToString(),
                        CodigoEntidadConvocante = fila.GetCell(3).ToString(),
                        CodigoFuenteFinanciamiento = fila.GetCell(4).ToString(),
                        CodigoObjetoContratacion = fila.GetCell(5).ToString(),
                        CodigoMoneda = fila.GetCell(6).ToString(),
                        MontoProcesoSiacomar = decimal.Parse(fila.GetCell(7).ToString()),
                        CodigoSubUnidadEjecutora = fila.GetCell(8).ToString(),
                        CodigoAreaTecnica = fila.GetCell(9).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(10).ToString(),
                        CodigoMonedaReferencia = fila.GetCell(11).ToString(),
                        ValorReferencia = decimal.Parse(fila.GetCell(12).ToString()),
                        CodigoObservacionProceso = fila.GetCell(13).ToString(),
                        FechaConvocatoria = fila.GetCell(14).ToString(),
                        FechaBuenaPro = fila.GetCell(15).ToString(),
                        CodigoMonedaAdjudicado = fila.GetCell(16).ToString(),
                        MontoAdjudicado = decimal.Parse(fila.GetCell(17).ToString()),

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

            dt.Columns.AddRange(new DataColumn[19]
            {
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("NroPAC", typeof(string)),
                    new DataColumn("CodigoTipoSeleccion", typeof(string)),
                    new DataColumn("CodigoEntidadConvocante", typeof(string)),
                    new DataColumn("CodigoFuenteFinanciamiento", typeof(string)),
                    new DataColumn("CodigoObjetoContratacion", typeof(string)),
                    new DataColumn("CodigoMoneda", typeof(string)),
                    new DataColumn("MontoProcesoSiacomar", typeof(decimal)),
                    new DataColumn("CodigoSubUnidadEjecutora", typeof(string)),
                    new DataColumn("CodigoAreaTecnica", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoMonedaReferencia", typeof(string)),
                    new DataColumn("ValorReferencia", typeof(decimal)),
                    new DataColumn("CodigoObservacionProceso", typeof(string)),
                    new DataColumn("FechaConvocatoria", typeof(string)),
                    new DataColumn("FechaBuenaPro", typeof(string)),
                    new DataColumn("CodigoMonedaAdjudicado", typeof(string)),
                    new DataColumn("MontoAdjudicado", typeof(decimal)),

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
                    decimal.Parse(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    decimal.Parse(fila.GetCell(12).ToString()),
                    fila.GetCell(13).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    fila.GetCell(16).ToString(),
                    decimal.Parse(fila.GetCell(17).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = procesoSeleccionContratacionBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DircomatProcesoSeleccionContratacion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DircomatProcesoSeleccionContratacion.xlsx");
        }
    }

}