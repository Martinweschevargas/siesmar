using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class DintemarEstudioContraintelPersonalExternoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EstudioContraintelPersonalExternoDAO estudiocontraintelPersonaExterBL = new();
        PaisUbigeoDAO paisUbigeoBL = new();
        TipoVinculoDAO tipoVinculoBL = new();
        DependenciaDAO dependenciaBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        ComandanciaDependenciaDAO comandanciaDependenciaBL = new();
        TipoEstudioContraInteligenciaDAO tipoEstudioContraInteligenciaBL = new();
        Carga cargaBL = new();

        public DintemarEstudioContraintelPersonalExternoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Estudios de Contrainteligencia a PersonaL Externo a la Institución", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<TipoVinculoDTO> tipoVinculoDTO = tipoVinculoBL.ObtenerTipoVinculos();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoEstudioContraInteligenciaDTO> tipoEstudioContraInteligenciaDTO = tipoEstudioContraInteligenciaBL.ObtenerTipoEstudioContraInteligencias();
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EstudioContraintelPersonalExterno");

            return Json(new { data1 = paisUbigeoDTO, data2 = tipoVinculoDTO,  data3 = dependenciaDTO, data4 = zonaNavalDTO, data5 = tipoEstudioContraInteligenciaDTO,
                data6 = comandanciaDependenciaDTO, data7= listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EstudioContraintelPersonalExternoDTO> select = estudiocontraintelPersonaExterBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string NumericoPais, string CodigoTipoVinculo, string CodigoDependencia, string CodigoZonaNaval, string CodigoComandanciaDependencia,
            int InvestigacionContrainteligenciaProducida, string CodigoTipoEstudioContrainteligencia, int CargaId)
        {
            EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO = new();
            estudioContraintelPersonalExternoDTO.NumericoPais = NumericoPais;
            estudioContraintelPersonalExternoDTO.CodigoTipoVinculo = CodigoTipoVinculo;
            estudioContraintelPersonalExternoDTO.CodigoDependencia = CodigoDependencia;
            estudioContraintelPersonalExternoDTO.CodigoZonaNaval = CodigoZonaNaval;
            estudioContraintelPersonalExternoDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            estudioContraintelPersonalExternoDTO.InvestigacionContrainteligenciaProducida = InvestigacionContrainteligenciaProducida;
            estudioContraintelPersonalExternoDTO.CodigoTipoEstudioContrainteligencia = CodigoTipoEstudioContrainteligencia;
            estudioContraintelPersonalExternoDTO.CargaId = CargaId;
            estudioContraintelPersonalExternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estudiocontraintelPersonaExterBL.AgregarRegistro(estudioContraintelPersonalExternoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(estudiocontraintelPersonaExterBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string NumericoPais, string CodigoTipoVinculo, string CodigoDependencia, string CodigoZonaNaval, string CodigoComandanciaDependencia,
            int InvestigacionContrainteligenciaProducida, string CodigoTipoEstudioContrainteligencia)
        {
            EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO = new();
            estudioContraintelPersonalExternoDTO.EstudioContrainteligenciaPersonalExternoId = Id;
            estudioContraintelPersonalExternoDTO.NumericoPais = NumericoPais;
            estudioContraintelPersonalExternoDTO.CodigoTipoVinculo = CodigoTipoVinculo;
            estudioContraintelPersonalExternoDTO.CodigoDependencia = CodigoDependencia;
            estudioContraintelPersonalExternoDTO.CodigoZonaNaval = CodigoZonaNaval;
            estudioContraintelPersonalExternoDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            estudioContraintelPersonalExternoDTO.InvestigacionContrainteligenciaProducida = InvestigacionContrainteligenciaProducida;
            estudioContraintelPersonalExternoDTO.CodigoTipoEstudioContrainteligencia = CodigoTipoEstudioContrainteligencia;
            estudioContraintelPersonalExternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estudiocontraintelPersonaExterBL.ActualizaFormato(estudioContraintelPersonalExternoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO = new();
            estudioContraintelPersonalExternoDTO.EstudioContrainteligenciaPersonalExternoId = Id;
            estudioContraintelPersonalExternoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (estudiocontraintelPersonaExterBL.EliminarFormato(estudioContraintelPersonalExternoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EstudioContraintelPersonalExternoDTO> lista = new List<EstudioContraintelPersonalExternoDTO>();
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

                    lista.Add(new EstudioContraintelPersonalExternoDTO
                    {
                        NumericoPais = fila.GetCell(0).ToString(),
                        CodigoTipoVinculo = fila.GetCell(1).ToString(),
                        CodigoDependencia = fila.GetCell(2).ToString(),
                        CodigoZonaNaval = fila.GetCell(3).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(4).ToString(),
                        InvestigacionContrainteligenciaProducida = int.Parse(fila.GetCell(5).ToString()),
                        CodigoTipoEstudioContrainteligencia = fila.GetCell(6).ToString(),

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
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("CodigoTipoVinculo  ", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("CodigoZonaNaval  ", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia  ", typeof(string)),
                    new DataColumn("InvestigacionContrainteligenciaProducida  ", typeof(int)),
                    new DataColumn("CodigoTipoEstudioContrainteligencia  ", typeof(string)),


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
                    int.Parse(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = estudiocontraintelPersonaExterBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDECPE(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\EstudioContraintelPersonalExterno.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = estudiocontraintelPersonaExterBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioContraintelPersonalExterno", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\EstudioContraintelPersonalExterno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "EstudioContraintelPersonalExterno.xlsx");
        }
    }

}


