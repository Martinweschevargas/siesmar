using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirtel;
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
    public class DirtelRegistroHardwareSoftwareSIController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroHardwareSoftwareSI registroHardwareSoftwareSIBL = new();
        Marca marcaBL = new();
        ModeloBienServicioSubcampo modeloBienServicioSubcampoBL = new();
        ModeloBienServicioDenominacion modeloBienServicioDenominacionBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public DirtelRegistroHardwareSoftwareSIController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Hardware y Software de Seguridad de la Informacion", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MarcaDTO> marcaDTO = marcaBL.ObtenerMarcas();
            List<ModeloBienServicioSubcampoDTO> modeloBienServicioSubcampoDTO = modeloBienServicioSubcampoBL.ObtenerModeloBienServicioSubcampos();
            List<ModeloBienServicioDenominacionDTO> modeloBienServicioDenominacionDTO = modeloBienServicioDenominacionBL.ObtenerModeloBienServicioDenominacions();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroHardwareSoftwareSI");


            return Json(new
            {
                data1 = modeloBienServicioSubcampoDTO,
                data2 = modeloBienServicioDenominacionDTO,
                data3 = marcaDTO,
                data4 = dependenciaDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroHardwareSoftwareSIDTO> registroHardwareSoftwareSIDTO = registroHardwareSoftwareSIBL.ObtenerLista();
            return Json(new { data = registroHardwareSoftwareSIDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoIBPHardwareSoftwareSI, string CodigoModeloBienServicioSubcampo, string CodigoModeloBienServicioDenominacion,
            string CodigoMarca, string AnioAdquisicionHardwareSoftwareSI, string CodigoDependencia, int CargaId)
        {
            RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO = new();
            registroHardwareSoftwareSIDTO.CodigoIBPHardwareSoftwareSI = CodigoIBPHardwareSoftwareSI;
            registroHardwareSoftwareSIDTO.CodigoMarca = CodigoMarca;
            registroHardwareSoftwareSIDTO.CodigoModeloBienServicioSubcampo = CodigoModeloBienServicioSubcampo;
            registroHardwareSoftwareSIDTO.CodigoModeloBienServicioDenominacion = CodigoModeloBienServicioDenominacion;
            registroHardwareSoftwareSIDTO.CodigoDependencia = CodigoDependencia;
            registroHardwareSoftwareSIDTO.AnioAdquisicionHardwareSoftwareSI = AnioAdquisicionHardwareSoftwareSI;
            registroHardwareSoftwareSIDTO.CargaId = CargaId;
            registroHardwareSoftwareSIDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroHardwareSoftwareSIBL.AgregarRegistro(registroHardwareSoftwareSIDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroHardwareSoftwareSIBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int RegistroHardwareSoftwareSIId, string CodigoIBPHardwareSoftwareSI, string CodigoModeloBienServicioSubcampo, string CodigoModeloBienServicioDenominacion,
            string CodigoMarca, string AnioAdquisicionHardwareSoftwareSI, string CodigoDependencia)
        {
            RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO = new();
            registroHardwareSoftwareSIDTO.RegistroHardwareSoftwareSIId = RegistroHardwareSoftwareSIId;
            registroHardwareSoftwareSIDTO.CodigoIBPHardwareSoftwareSI = CodigoIBPHardwareSoftwareSI;
            registroHardwareSoftwareSIDTO.CodigoMarca = CodigoMarca;
            registroHardwareSoftwareSIDTO.CodigoModeloBienServicioSubcampo = CodigoModeloBienServicioSubcampo;
            registroHardwareSoftwareSIDTO.CodigoModeloBienServicioDenominacion = CodigoModeloBienServicioDenominacion;
            registroHardwareSoftwareSIDTO.CodigoDependencia = CodigoDependencia;
            registroHardwareSoftwareSIDTO.AnioAdquisicionHardwareSoftwareSI = AnioAdquisicionHardwareSoftwareSI;
            registroHardwareSoftwareSIDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroHardwareSoftwareSIBL.ActualizarFormato(registroHardwareSoftwareSIDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO = new();
            registroHardwareSoftwareSIDTO.RegistroHardwareSoftwareSIId = Id;
            registroHardwareSoftwareSIDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroHardwareSoftwareSIBL.EliminarFormato(registroHardwareSoftwareSIDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroHardwareSoftwareSIDTO> lista = new List<RegistroHardwareSoftwareSIDTO>();
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

                    lista.Add(new RegistroHardwareSoftwareSIDTO
                    {
                        CodigoIBPHardwareSoftwareSI = fila.GetCell(0).ToString(),
                        CodigoModeloBienServicioSubcampo = fila.GetCell(1).ToString(),
                        CodigoModeloBienServicioDenominacion = fila.GetCell(2).ToString(),
                        CodigoMarca = fila.GetCell(3).ToString(),
                        AnioAdquisicionHardwareSoftwareSI = fila.GetCell(4).ToString(),
                        CodigoDependencia = fila.GetCell(5).ToString(),
                  
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("CodigoIBPHardwareSoftwareSI ", typeof(string)),
                    new DataColumn("CodigoModeloBienServicioSubcampo ", typeof(string)),
                    new DataColumn("CodigoModeloBienServicioDenominacion ", typeof(string)),
                    new DataColumn("CodigoMarca ", typeof(string)),
                    new DataColumn("AnioAdquisicionHardwareSoftwareSI ", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(string)),

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


                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroHardwareSoftwareSIBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDRHS(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirtel\\RegistroHardwareSoftwareSI.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = registroHardwareSoftwareSIBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RegistroHardwareSoftwareSI", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\RegistroHardwareSoftwareSI.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "RegistroHardwareSoftwareSI.xlsx");
        }
    }

}