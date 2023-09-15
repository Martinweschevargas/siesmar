using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirpronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirpronav;
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

    public class DirpronavInversionPIeIOARRController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        InversionPIeIOARR inversionPIeIOARRBL = new();

        ClaseInversion claseInversionBL = new();
        FaseInversion faseInversionBL = new();
        UnidadNaval unidadNavalBL = new();
        EstadoFase1FormEval estadoFase1FormEvalBL = new();
        EstadoFase2Ejecucion estadoFase2EjecucionBL = new();
        EstadoFase3Funcionamiento estadoFase3FuncionamientoBL = new();
        FuenteFinanciamiento fuenteFinanciamientoBL = new();
        Carga cargaBL = new();
        public DirpronavInversionPIeIOARRController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ClaseInversionDTO> claseInversionDTO = claseInversionBL.ObtenerClaseInversions();
            List<FaseInversionDTO> faseInversionDTO = faseInversionBL.ObtenerFaseInversions();
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<EstadoFase1FormEvalDTO> estadoFase1FormEvalDTO = estadoFase1FormEvalBL.ObtenerEstadoFase1FormEvals();
            List<EstadoFase2EjecucionDTO> estadoFase2EjecucionDTO = estadoFase2EjecucionBL.ObtenerEstadoFase2Ejecucions();
            List<EstadoFase3FuncionamientoDTO> estadoFase3FuncionamientoDTO = estadoFase3FuncionamientoBL.ObtenerEstadoFase3Funcionamientos();
            List<FuenteFinanciamientoDTO> fuenteFinanciamientoDTO = fuenteFinanciamientoBL.ObtenerFuenteFinanciamientos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InversionPIeIOARR");

            return Json(new { data1 = claseInversionDTO, data2 = faseInversionDTO, data3 = unidadNavalDTO, data4 = estadoFase1FormEvalDTO,
                            data5 = estadoFase2EjecucionDTO, data6 = estadoFase3FuncionamientoDTO, data7 = fuenteFinanciamientoDTO, data8= listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<InversionPIeIOARRDTO> select = inversionPIeIOARRBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(int CodigoUnificado, string NombreInversion, string CodigoClaseInversion, decimal MontoInversionInicial, decimal MontoInversionModificado, 
            string FechaViabilidadProyecto, string CodigoFaseInversion, string UnidadFormuladora, string UnidadEjecutora, string CodigoUnidadNaval, string CodigoEstadoFase1FormEval,
            string CodigoEstadoFase2Ejecucion, string CodigoEstadoFase3Funcionamiento, string CodigoFuenteFinanciamiento, string FechaTerminoEjecucionInversion, string FechaUltimaActualizacionProyecto,
            int CargaId, string Fecha)
        {
            InversionPIeIOARRDTO inversionPIeIOARRDTO = new();
            inversionPIeIOARRDTO.CodigoUnificado = CodigoUnificado;
            inversionPIeIOARRDTO.NombreInversion = NombreInversion;
            inversionPIeIOARRDTO.CodigoClaseInversion = CodigoClaseInversion;
            inversionPIeIOARRDTO.MontoInversionInicial = MontoInversionInicial;
            inversionPIeIOARRDTO.MontoInversionModificado = MontoInversionModificado;
            inversionPIeIOARRDTO.FechaViabilidadProyecto = FechaViabilidadProyecto;
            inversionPIeIOARRDTO.CodigoFaseInversion = CodigoFaseInversion;
            inversionPIeIOARRDTO.UnidadFormuladora = UnidadFormuladora;
            inversionPIeIOARRDTO.UnidadEjecutora = UnidadEjecutora;
            inversionPIeIOARRDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            inversionPIeIOARRDTO.CodigoEstadoFase1FormEval = CodigoEstadoFase1FormEval;
            inversionPIeIOARRDTO.CodigoEstadoFase2Ejecucion = CodigoEstadoFase2Ejecucion;
            inversionPIeIOARRDTO.CodigoEstadoFase3Funcionamiento = CodigoEstadoFase3Funcionamiento;
            inversionPIeIOARRDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            inversionPIeIOARRDTO.FechaTerminoEjecucionInversion = FechaTerminoEjecucionInversion;
            inversionPIeIOARRDTO.FechaUltimaActualizacionProyecto = FechaUltimaActualizacionProyecto;
            inversionPIeIOARRDTO.CargaId = CargaId;
            inversionPIeIOARRDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inversionPIeIOARRBL.AgregarRegistro(inversionPIeIOARRDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(inversionPIeIOARRBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int CodigoUnificado, string NombreInversion, string CodigoClaseInversion, decimal MontoInversionInicial, decimal MontoInversionModificado,
            string FechaViabilidadProyecto, string CodigoFaseInversion, string UnidadFormuladora, string UnidadEjecutora, string CodigoUnidadNaval, string CodigoEstadoFase1FormEval,
            string CodigoEstadoFase2Ejecucion, string CodigoEstadoFase3Funcionamiento, string CodigoFuenteFinanciamiento, string FechaTerminoEjecucionInversion, string FechaUltimaActualizacionProyecto,
            int CargaId)
        {
            InversionPIeIOARRDTO inversionPIeIOARRDTO = new();
            inversionPIeIOARRDTO.InversionPIeIOARRId = Id;
            inversionPIeIOARRDTO.CodigoUnificado = CodigoUnificado;
            inversionPIeIOARRDTO.NombreInversion = NombreInversion;
            inversionPIeIOARRDTO.CodigoClaseInversion = CodigoClaseInversion;
            inversionPIeIOARRDTO.MontoInversionInicial = MontoInversionInicial;
            inversionPIeIOARRDTO.MontoInversionModificado = MontoInversionModificado;
            inversionPIeIOARRDTO.FechaViabilidadProyecto = FechaViabilidadProyecto;
            inversionPIeIOARRDTO.CodigoFaseInversion = CodigoFaseInversion;
            inversionPIeIOARRDTO.UnidadFormuladora = UnidadFormuladora;
            inversionPIeIOARRDTO.UnidadEjecutora = UnidadEjecutora;
            inversionPIeIOARRDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            inversionPIeIOARRDTO.CodigoEstadoFase1FormEval = CodigoEstadoFase1FormEval;
            inversionPIeIOARRDTO.CodigoEstadoFase2Ejecucion = CodigoEstadoFase2Ejecucion;
            inversionPIeIOARRDTO.CodigoEstadoFase3Funcionamiento = CodigoEstadoFase3Funcionamiento;
            inversionPIeIOARRDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            inversionPIeIOARRDTO.FechaTerminoEjecucionInversion = FechaTerminoEjecucionInversion;
            inversionPIeIOARRDTO.FechaUltimaActualizacionProyecto = FechaUltimaActualizacionProyecto;
            
            inversionPIeIOARRDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inversionPIeIOARRBL.ActualizarFormato(inversionPIeIOARRDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InversionPIeIOARRDTO inversionPIeIOARRDTO = new();
            inversionPIeIOARRDTO.InversionPIeIOARRId = Id;
            inversionPIeIOARRDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (inversionPIeIOARRBL.EliminarFormato(inversionPIeIOARRDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            InversionPIeIOARRDTO inversionPIeIOARRDTO = new();
            inversionPIeIOARRDTO.CargaId = Id;
            inversionPIeIOARRDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (inversionPIeIOARRBL.EliminarCarga(inversionPIeIOARRDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InversionPIeIOARRDTO> lista = new List<InversionPIeIOARRDTO>();
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

                    lista.Add(new InversionPIeIOARRDTO
                    {
                        CodigoUnificado = int.Parse(fila.GetCell(0).ToString()),
                        NombreInversion = fila.GetCell(1).ToString(),
                        CodigoClaseInversion = fila.GetCell(2).ToString(),
                        MontoInversionInicial = decimal.Parse(fila.GetCell(3).ToString()),
                        MontoInversionModificado = decimal.Parse(fila.GetCell(4).ToString()),
                        FechaViabilidadProyecto = UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                        CodigoFaseInversion = fila.GetCell(6).ToString(),
                        UnidadFormuladora = fila.GetCell(7).ToString(),
                        UnidadEjecutora = fila.GetCell(8).ToString(),
                        CodigoUnidadNaval = fila.GetCell(9).ToString(),
                        CodigoEstadoFase1FormEval = fila.GetCell(10).ToString(),
                        CodigoEstadoFase2Ejecucion = fila.GetCell(11).ToString(),
                        CodigoEstadoFase3Funcionamiento = fila.GetCell(12).ToString(),
                        CodigoFuenteFinanciamiento = fila.GetCell(13).ToString(),
                        FechaTerminoEjecucionInversion = UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                        FechaUltimaActualizacionProyecto = UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),

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

            dt.Columns.AddRange(new DataColumn[17]
            {
                    new DataColumn("CodigoUnificado", typeof(int)),
                    new DataColumn("NombreInversion", typeof(string)),
                    new DataColumn("CodigoClaseInversion", typeof(string)),
                    new DataColumn("MontoInversionInicial", typeof(decimal)),
                    new DataColumn("MontoInversionModificado", typeof(decimal)),
                    new DataColumn("FechaViabilidadProyecto", typeof(string)),
                    new DataColumn("CodigoFaseInversion", typeof(string)),
                    new DataColumn("UnidadFormuladora", typeof(string)),
                    new DataColumn("UnidadEjecutora", typeof(string)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoEstadoFase1FormEval", typeof(string)),
                    new DataColumn("CodigoEstadoFase2Ejecucion", typeof(string)),
                    new DataColumn("CodigoEstadoFase3Funcionamiento", typeof(string)),
                    new DataColumn("CodigoFuenteFinanciamiento", typeof(string)),
                    new DataColumn("FechaTerminoEjecucionInversion", typeof(string)),
                    new DataColumn("FechaUltimaActualizacionProyecto", typeof(string)),
                     new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = inversionPIeIOARRBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = inversionPIeIOARRBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirpronavInversionPIeIOARR.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirpronavInversionPIeIOARR.xlsx");
        }

    }

}

