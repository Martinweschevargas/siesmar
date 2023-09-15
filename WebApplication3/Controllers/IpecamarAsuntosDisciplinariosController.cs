using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class IpecamarAsuntosDisciplinariosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AsuntosDisciplinariosDAO asuntosDisciplinariosBL = new();
        MotivoInvestigacionDAO motivoInvestigacionBL = new();
        DetalleInfraccionDAO detalleInfraccionBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        TipoPersonalMilitarDAO tipoPersonalMilitarBL = new();
        GradoPersonalMilitarDAO gradoPersonalMilitarBL = new();
        ResultadoInvestigacionDAO resultadoInvestigacionBL = new();
        Carga cargaBL = new();

        public IpecamarAsuntosDisciplinariosController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MotivoInvestigacionDTO> motivoInvestigacionDTO = motivoInvestigacionBL.ObtenerMotivoInvestigacions();
            List<DetalleInfraccionDTO> detalleInfraccionDTO = detalleInfraccionBL.ObtenerDetalleInfraccions();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<ResultadoInvestigacionDTO> resultadoInvestigacionDTO = resultadoInvestigacionBL.ObtenerResultadoInvestigacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AsuntosDisciplinarios");


            return Json(new { data1 = motivoInvestigacionDTO, data2 = detalleInfraccionDTO,  data3 = zonaNavalDTO,
                data4 = tipoPersonalMilitarDTO, data5 = gradoPersonalMilitarDTO,  data6 = resultadoInvestigacionDTO, data7 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AsuntosDisciplinariosDTO> select = asuntosDisciplinariosBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string UUDDConvocante, string CodigoMotivoInvestigacion, string CodigoDetalleInfraccion, string FechaInicioInvestigacion,
           string FechaTerminoInvestigacion, int PlazoInvestigacion, string CodigoZonaNaval, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
           string SituacionInvestigacion, string CodigoResultadoInvestigacion,int CargaId)
        {
            AsuntosDisciplinariosDTO asuntosDisciplinariosDTO = new();
            asuntosDisciplinariosDTO.UUDDConvocante = UUDDConvocante;
            asuntosDisciplinariosDTO.CodigoMotivoInvestigacion = CodigoMotivoInvestigacion;
            asuntosDisciplinariosDTO.CodigoDetalleInfraccion = CodigoDetalleInfraccion;
            asuntosDisciplinariosDTO.FechaInicioInvestigacion = FechaInicioInvestigacion;
            asuntosDisciplinariosDTO.FechaTerminoInvestigacion = FechaTerminoInvestigacion;
            asuntosDisciplinariosDTO.PlazoInvestigacion = PlazoInvestigacion;
            asuntosDisciplinariosDTO.CodigoZonaNaval = CodigoZonaNaval;        
            asuntosDisciplinariosDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            asuntosDisciplinariosDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            asuntosDisciplinariosDTO.SituacionInvestigacion = SituacionInvestigacion;
            asuntosDisciplinariosDTO.CodigoResultadoInvestigacion = CodigoResultadoInvestigacion;
            asuntosDisciplinariosDTO.CargaId = CargaId;
            asuntosDisciplinariosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = asuntosDisciplinariosBL.AgregarRegistro(asuntosDisciplinariosDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(asuntosDisciplinariosBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string UUDDConvocante, string CodigoMotivoInvestigacion, string CodigoDetalleInfraccion, string FechaInicioInvestigacion,
           string FechaTerminoInvestigacion, int PlazoInvestigacion, string CodigoZonaNaval, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
           string SituacionInvestigacion, string CodigoResultadoInvestigacion)
        {
            AsuntosDisciplinariosDTO asuntosDisciplinariosDTO = new();
            asuntosDisciplinariosDTO.AsuntoDisciplinarioId= Id;
            asuntosDisciplinariosDTO.UUDDConvocante = UUDDConvocante;
            asuntosDisciplinariosDTO.CodigoMotivoInvestigacion = CodigoMotivoInvestigacion;
            asuntosDisciplinariosDTO.CodigoDetalleInfraccion = CodigoDetalleInfraccion;
            asuntosDisciplinariosDTO.FechaInicioInvestigacion = FechaInicioInvestigacion;
            asuntosDisciplinariosDTO.FechaTerminoInvestigacion = FechaTerminoInvestigacion;
            asuntosDisciplinariosDTO.PlazoInvestigacion = PlazoInvestigacion;
            asuntosDisciplinariosDTO.CodigoZonaNaval = CodigoZonaNaval;
            asuntosDisciplinariosDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            asuntosDisciplinariosDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            asuntosDisciplinariosDTO.SituacionInvestigacion = SituacionInvestigacion;
            asuntosDisciplinariosDTO.CodigoResultadoInvestigacion = CodigoResultadoInvestigacion;
            asuntosDisciplinariosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = asuntosDisciplinariosBL.ActualizaFormato(asuntosDisciplinariosDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AsuntosDisciplinariosDTO asuntosDisciplinariosDTO = new();
            asuntosDisciplinariosDTO.AsuntoDisciplinarioId = Id;
            asuntosDisciplinariosDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (asuntosDisciplinariosBL.EliminarFormato(asuntosDisciplinariosDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AsuntosDisciplinariosDTO> lista = new List<AsuntosDisciplinariosDTO>();
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

                    lista.Add(new AsuntosDisciplinariosDTO
                    {
                        UUDDConvocante = fila.GetCell(0).ToString(),
                        CodigoMotivoInvestigacion = fila.GetCell(1).ToString(),
                        CodigoDetalleInfraccion = fila.GetCell(2).ToString(),
                        FechaInicioInvestigacion = fila.GetCell(3).ToString(),
                        FechaTerminoInvestigacion = fila.GetCell(4).ToString(),
                        PlazoInvestigacion = int.Parse(fila.GetCell(5).ToString()),
                        CodigoZonaNaval = fila.GetCell(6).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(7).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(8).ToString(),
                        SituacionInvestigacion = fila.GetCell(9).ToString(),
                        CodigoResultadoInvestigacion = fila.GetCell(10).ToString()
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("UUDDConvocante", typeof(string)),
                    new DataColumn("CodigoMotivoInvestigacion", typeof(string)),
                    new DataColumn("CodigoDetalleInfraccion", typeof(string)),
                    new DataColumn("FechaInicioInvestigacion", typeof(string)),
                    new DataColumn("FechaTerminoInvestigacion", typeof(string)),
                    new DataColumn("PlazoInvestigacion", typeof(int)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SituacionInvestigacion", typeof(string)),
                    new DataColumn("CodigoResultadoInvestigacion", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = asuntosDisciplinariosBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = asuntosDisciplinariosBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IpecamarAsuntosDisciplinarios.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IpecamarAsuntosDisciplinarios.xlsx");
        }

    }

}

