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

    public class DintemarEstudioContraintelPersonaNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EstudioContrainteligenciaPersonaNavalDAO estudiocontraintelPersonaBL = new();

        DependenciaDAO dependenciaBL = new();
        ComandanciaDependenciaDAO comandanciaDependenciaBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        TipoEstudioContraInteligenciaDAO tipoEstudioContraInteligenciaBL = new();
        Carga cargaBL = new();

        public DintemarEstudioContraintelPersonaNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Estudios de Contrainteligencia al Personal Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoEstudioContraInteligenciaDTO> tipoEstudioContraInteligenciaDTO = tipoEstudioContraInteligenciaBL.ObtenerTipoEstudioContraInteligencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EstudioContrainteligenciaPersonaNaval");

            return Json(new { data1 = dependenciaDTO, data2 = comandanciaDependenciaDTO,  data3 = zonaNavalDTO, data4 = tipoEstudioContraInteligenciaDTO, data5= listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EstudioContrainteligenciaPersonaNavalDTO> select = estudiocontraintelPersonaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoDependencia, string CodigoComandanciaDependencia, string CodigoZonaNaval,
           int EstudioContrainteligenciaProducida, string CodigoTipoEstudioContrainteligencia, int CargaId, string fecha)
        {
            EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavallDTO = new();
            estudioContraintelPersonaNavallDTO.CodigoDependencia = CodigoDependencia;
            estudioContraintelPersonaNavallDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            estudioContraintelPersonaNavallDTO.CodigoZonaNaval = CodigoZonaNaval;
            estudioContraintelPersonaNavallDTO.EstudioContrainteligenciaProducida = EstudioContrainteligenciaProducida;
            estudioContraintelPersonaNavallDTO.CodigoTipoEstudioContrainteligencia = CodigoTipoEstudioContrainteligencia;
            estudioContraintelPersonaNavallDTO.CargaId = CargaId;
            estudioContraintelPersonaNavallDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            estudioContraintelPersonaNavallDTO.Fecha = fecha;

            var IND_OPERACION = estudiocontraintelPersonaBL.AgregarRegistro(estudioContraintelPersonaNavallDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(estudiocontraintelPersonaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoDependencia, string CodigoComandanciaDependencia, string CodigoZonaNaval,
           int EstudioContrainteligenciaProducida, string CodigoTipoEstudioContrainteligencia)
        {
            EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavallDTO = new();
            estudioContraintelPersonaNavallDTO.EstudioContrainteligenciaPersonaNavalId = Id;
            estudioContraintelPersonaNavallDTO.CodigoDependencia = CodigoDependencia;
            estudioContraintelPersonaNavallDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            estudioContraintelPersonaNavallDTO.CodigoZonaNaval = CodigoZonaNaval;
            estudioContraintelPersonaNavallDTO.EstudioContrainteligenciaProducida = EstudioContrainteligenciaProducida;
            estudioContraintelPersonaNavallDTO.CodigoTipoEstudioContrainteligencia = CodigoTipoEstudioContrainteligencia;

            estudioContraintelPersonaNavallDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estudiocontraintelPersonaBL.ActualizaFormato(estudioContraintelPersonaNavallDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaNavallDTO = new();
            estudioContraintelPersonaNavallDTO.EstudioContrainteligenciaPersonaNavalId = Id;
            estudioContraintelPersonaNavallDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (estudiocontraintelPersonaBL.EliminarFormato(estudioContraintelPersonaNavallDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje;
            EstudioContrainteligenciaPersonaNavalDTO estudioContrainteligenciaPersonaNavalDTO = new()
            {
                CargaId = Id,
                UsuarioIngresoRegistro = User.obtenerUsuario()
            };

            if (estudiocontraintelPersonaBL.EliminarCarga(estudioContrainteligenciaPersonaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EstudioContrainteligenciaPersonaNavalDTO> lista = new List<EstudioContrainteligenciaPersonaNavalDTO>();
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

                    lista.Add(new EstudioContrainteligenciaPersonaNavalDTO
                    {
                        CodigoDependencia = fila.GetCell(0).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(1).ToString(),
                        CodigoZonaNaval = fila.GetCell(2).ToString(),
                        EstudioContrainteligenciaProducida = int.Parse(fila.GetCell(3).ToString()),
                        CodigoTipoEstudioContrainteligencia = fila.GetCell(4).ToString(),
                 
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string fecha)
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia  ", typeof(string)),
                    new DataColumn("CodigoZonaNaval ", typeof(string)),
                    new DataColumn("EstudioContrainteligenciaProducida  ", typeof(int)),
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
                    int.Parse(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    
                    User.obtenerUsuario());
            }
            var IND_OPERACION = estudiocontraintelPersonaBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDECPN(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\EstudioContraintelPersonaNaval.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = estudiocontraintelPersonaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioContraintelPersonaNaval", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\EstudioContraintelPersonaNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "EstudioContraintelPersonaNaval.xlsx");
        }
    }

}
