using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar;
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

    public class IpecamarInvestigacionInstCaracterPrevioController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        InvestigacionInstCaracterPrevio investigacionInstCaracterPrevioBL = new();

        TipoInvestigacion tipoInvestigacionBL = new();
        MedioInvestigacion medioInvestigacionBL = new();
        MotivoInvestigacion motivoInvestigacionBL = new();
        ComandanciaDependencia comandanciaDependenciaBL = new();
        ZonaNaval zonaNavalBL = new();
        ResultadoInvestigacion resultadoInvestigacionBL = new();
        Carga cargaBL = new();

        public IpecamarInvestigacionInstCaracterPrevioController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Investigaciones Institucionales de Carácter Previo", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoInvestigacionDTO> tipoInvestigacionDTO = tipoInvestigacionBL.ObtenerTipoInvestigacions();
            List<MedioInvestigacionDTO> medioInvestigacionDTO = medioInvestigacionBL.ObtenerMedioInvestigacions();
            List<MotivoInvestigacionDTO> motivoInvestigacionDTO = motivoInvestigacionBL.ObtenerMotivoInvestigacions();
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<ResultadoInvestigacionDTO> resultadoInvestigacionDTO = resultadoInvestigacionBL.ObtenerResultadoInvestigacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InvestigacionInstCaracterPrevio");


            return Json(new { data1 = tipoInvestigacionDTO, data2 = medioInvestigacionDTO,  data3 = motivoInvestigacionDTO,
                data4 = comandanciaDependenciaDTO, data5 = zonaNavalDTO,  data6 = resultadoInvestigacionDTO, data7 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<InvestigacionInstCaracterPrevioDTO> select = investigacionInstCaracterPrevioBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoTipoInvestigacion, string CodigoMedioInvestigacion, string CodigoMotivoInvestigacion, string CodigoComandanciaDependencia,
           string FechaInicioInvestigacion, string FechaTermino, string CodigoZonaNaval, string SituacionInvestigacion, string CodigoResultadoInvestigacion)
        {
            InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO = new();
            investigacionInstCaracterPrevioDTO.CodigoTipoInvestigacion = CodigoTipoInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoMedioInvestigacion = CodigoMedioInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoMotivoInvestigacion = CodigoMotivoInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            investigacionInstCaracterPrevioDTO.FechaInicioInvestigacion = FechaInicioInvestigacion;
            investigacionInstCaracterPrevioDTO.FechaTermino = FechaTermino;
            investigacionInstCaracterPrevioDTO.CodigoZonaNaval = CodigoZonaNaval;        
            investigacionInstCaracterPrevioDTO.SituacionInvestigacion = SituacionInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoResultadoInvestigacion = CodigoResultadoInvestigacion;
            investigacionInstCaracterPrevioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = investigacionInstCaracterPrevioBL.AgregarRegistro(investigacionInstCaracterPrevioDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(investigacionInstCaracterPrevioBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoTipoInvestigacion, string CodigoMedioInvestigacion, string CodigoMotivoInvestigacion, string CodigoComandanciaDependencia,
           string FechaInicioInvestigacion, string FechaTermino, string CodigoZonaNaval, string SituacionInvestigacion, string CodigoResultadoInvestigacion)
        {
            InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO = new();
            investigacionInstCaracterPrevioDTO.InvestigacionInstCaracterPrevioId = Id;
            investigacionInstCaracterPrevioDTO.CodigoTipoInvestigacion = CodigoTipoInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoMedioInvestigacion = CodigoMedioInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoMotivoInvestigacion = CodigoMotivoInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            investigacionInstCaracterPrevioDTO.FechaInicioInvestigacion = FechaInicioInvestigacion;
            investigacionInstCaracterPrevioDTO.FechaTermino = FechaTermino;
            investigacionInstCaracterPrevioDTO.CodigoZonaNaval = CodigoZonaNaval;
            investigacionInstCaracterPrevioDTO.SituacionInvestigacion = SituacionInvestigacion;
            investigacionInstCaracterPrevioDTO.CodigoResultadoInvestigacion = CodigoResultadoInvestigacion;
            investigacionInstCaracterPrevioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = investigacionInstCaracterPrevioBL.ActualizarFormato(investigacionInstCaracterPrevioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InvestigacionInstCaracterPrevioDTO investigacionInstCaracterPrevioDTO = new();
            investigacionInstCaracterPrevioDTO.InvestigacionInstCaracterPrevioId = Id;
            investigacionInstCaracterPrevioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (investigacionInstCaracterPrevioBL.EliminarFormato(investigacionInstCaracterPrevioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InvestigacionInstCaracterPrevioDTO> lista = new List<InvestigacionInstCaracterPrevioDTO>();
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

                    lista.Add(new InvestigacionInstCaracterPrevioDTO
                    {
                        CodigoTipoInvestigacion = fila.GetCell(0).ToString(),
                        CodigoMedioInvestigacion = fila.GetCell(1).ToString(),
                        CodigoMotivoInvestigacion = fila.GetCell(2).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(3).ToString(),
                        FechaInicioInvestigacion = fila.GetCell(4).ToString(),
                        FechaTermino = fila.GetCell(5).ToString(),
                        CodigoZonaNaval = fila.GetCell(6).ToString(),
                        SituacionInvestigacion = fila.GetCell(7).ToString(),
                        CodigoResultadoInvestigacion = fila.GetCell(8).ToString()
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoTipoInvestigacion", typeof(string)),
                    new DataColumn("CodigoMedioInvestigacion", typeof(string)),
                    new DataColumn("CodigoMotivoInvestigacion    ", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("FechaInicioInvestigacion", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
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
                    fila.GetCell(3).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = investigacionInstCaracterPrevioBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }


        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = investigacionInstCaracterPrevioBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IpecamarInvestigacionInstCaracterPrevio.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IpecamarInvestigacionInstCaracterPrevio.xlsx");
        }

    }

}

