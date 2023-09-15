using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comesnapi;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comesnapi;
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

    public class ComesnapiServicioSastreriaComesnapiController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ServicioSastreriaComesnapi servicioSastreriaComesnapiBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        TipoPrenda tipoPrendaBL = new();
        TipoServicioSastreria tipoServicioSastreriaBL = new();
        Carga cargaBL = new();

        public ComesnapiServicioSastreriaComesnapiController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicios de sastrería", FromController = typeof(HomeController))]
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult cargaCombs()
        {

            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<TipoPrendaDTO> tipoPrendaDTO = tipoPrendaBL.ObtenerTipoPrendas();
            List<TipoServicioSastreriaDTO> tipoServicioSastreriaDTO = tipoServicioSastreriaBL.ObtenerTipoServicioSastrerias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioSastreriaComesnapi");


            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = especialidadGenericaPersonalDTO,
                data3 = dependenciaDTO,
                data4 = tipoPrendaDTO,
                data5 = tipoServicioSastreriaDTO,            
                data6 = listaCargas,            
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioSastreriaComesnapiDTO> select = servicioSastreriaComesnapiBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaIngreso, string FechaRecojo, string CIP, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal,
            string SexoPersonal, string CodigoDependencia, int NumeroPrenda, string CodigoTipoPrenda, string CodigoTipoServicioSastreria,int CargaId)
        {
            ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO = new();
            servicioSastreriaComesnapiDTO.FechaIngreso = FechaIngreso;
            servicioSastreriaComesnapiDTO.FechaRecojo = FechaRecojo;
            servicioSastreriaComesnapiDTO.CIP = CIP;
            servicioSastreriaComesnapiDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioSastreriaComesnapiDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            servicioSastreriaComesnapiDTO.SexoPersonal = SexoPersonal;
            servicioSastreriaComesnapiDTO.CodigoDependencia = CodigoDependencia;
            servicioSastreriaComesnapiDTO.NumeroPrenda = NumeroPrenda;
            servicioSastreriaComesnapiDTO.CodigoTipoPrenda = CodigoTipoPrenda;
            servicioSastreriaComesnapiDTO.CodigoTipoServicioSastreria = CodigoTipoServicioSastreria;
            servicioSastreriaComesnapiDTO.CargaId = CargaId;
            
            servicioSastreriaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioSastreriaComesnapiBL.AgregarRegistro(servicioSastreriaComesnapiDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioSastreriaComesnapiBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaIngreso, string FechaRecojo, string CIP, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal,
            string SexoPersonal, string CodigoDependencia, int NumeroPrenda, string CodigoTipoPrenda, string CodigoTipoServicioSastreria)
        {
            ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO = new();
            servicioSastreriaComesnapiDTO.ServicioSastreriaComesnapiId = Id;
            servicioSastreriaComesnapiDTO.FechaIngreso = FechaIngreso;
            servicioSastreriaComesnapiDTO.FechaRecojo = FechaRecojo;
            servicioSastreriaComesnapiDTO.CIP = CIP;
            servicioSastreriaComesnapiDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioSastreriaComesnapiDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            servicioSastreriaComesnapiDTO.SexoPersonal = SexoPersonal;
            servicioSastreriaComesnapiDTO.CodigoDependencia = CodigoDependencia;
            servicioSastreriaComesnapiDTO.NumeroPrenda = NumeroPrenda;
            servicioSastreriaComesnapiDTO.CodigoTipoPrenda = CodigoTipoPrenda;
            servicioSastreriaComesnapiDTO.CodigoTipoServicioSastreria = CodigoTipoServicioSastreria;
            
            servicioSastreriaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioSastreriaComesnapiBL.ActualizarFormato(servicioSastreriaComesnapiDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioSastreriaComesnapiDTO servicioSastreriaComesnapiDTO = new();
            servicioSastreriaComesnapiDTO.ServicioSastreriaComesnapiId = Id;
            servicioSastreriaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioSastreriaComesnapiBL.EliminarFormato(servicioSastreriaComesnapiDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioSastreriaComesnapiDTO> lista = new List<ServicioSastreriaComesnapiDTO>();
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

                    lista.Add(new ServicioSastreriaComesnapiDTO
                    {
                        FechaIngreso = fila.GetCell(0).ToString(),
                        FechaRecojo = fila.GetCell(1).ToString(),
                        CIP = fila.GetCell(2).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(4).ToString(),
                        SexoPersonal = fila.GetCell(5).ToString(),
                        CodigoDependencia = fila.GetCell(6).ToString(),
                        NumeroPrenda = int.Parse(fila.GetCell(7).ToString()),
                        CodigoTipoPrenda = fila.GetCell(8).ToString(),
                        CodigoTipoServicioSastreria = fila.GetCell(9).ToString()
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("FechaIngreso", typeof(string)),
                    new DataColumn("FechaRecojo", typeof(string)),
                    new DataColumn("CIP", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("SexoPersonal", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("NumeroPrenda", typeof(int)),
                    new DataColumn("CodigoTipoPrenda", typeof(string)),
                    new DataColumn("CodigoTipoServicioSastreria", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    int.Parse(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioSastreriaComesnapiBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }


        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = servicioSastreriaComesnapiBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComesnapiServicioSastreria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComesnapiServicioSastreria.xlsx");
        }

    }

}

