using AspNetCore.Reporting;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzodos;
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
    public class ComzodosServicioBrindadoBaseCallaoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ServicioBrindadoBaseCallao servicioBrindadoBaseCallaoBL = new();
        ServicioBrindado ServicioBrindadoBL = new();
        Carga cargaBL = new();


        public ComzodosServicioBrindadoBaseCallaoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicios Brindados por la Base Naval del Callao - COMBACA", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ServicioBrindadoDTO> servicioBrindadoDTO = ServicioBrindadoBL.ObtenerServicioBrindados();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioBrindadoBaseCallao");
            return Json(new
            {
                data1 = servicioBrindadoDTO,
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioBrindadoBaseCallaoDTO> servicioBrindadoBaseCallaoDTO = servicioBrindadoBaseCallaoBL.ObtenerLista();
            return Json(new { data = servicioBrindadoBaseCallaoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string TiempoEmpleado, string CodigoServicioBrindado, 
            string FechaServicio, string EmpresaReceptoraServicio, int CargaId, string Fecha)
        {
            ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO = new();
            servicioBrindadoBaseCallaoDTO.FechaServicio = FechaServicio;
            servicioBrindadoBaseCallaoDTO.EmpresaReceptoraServicio = EmpresaReceptoraServicio;
            servicioBrindadoBaseCallaoDTO.CodigoServicioBrindado = CodigoServicioBrindado;
            servicioBrindadoBaseCallaoDTO.TiempoEmpleado = TiempoEmpleado;
            servicioBrindadoBaseCallaoDTO.CargaId = CargaId;
            servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioBrindadoBaseCallaoBL.AgregarRegistro(servicioBrindadoBaseCallaoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioBrindadoBaseCallaoBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int ServicioBrindadoBaseCallaoId, string TiempoEmpleado, string CodigoServicioBrindado,
            string FechaServicio, string EmpresaReceptoraServicio)
        {
            ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO = new();
            servicioBrindadoBaseCallaoDTO.ServicioBrindadoBaseCallaoId = ServicioBrindadoBaseCallaoId;
            servicioBrindadoBaseCallaoDTO.FechaServicio = FechaServicio;
            servicioBrindadoBaseCallaoDTO.EmpresaReceptoraServicio = EmpresaReceptoraServicio;
            servicioBrindadoBaseCallaoDTO.CodigoServicioBrindado = CodigoServicioBrindado;
            servicioBrindadoBaseCallaoDTO.TiempoEmpleado = TiempoEmpleado;
            servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioBrindadoBaseCallaoBL.ActualizarFormato(servicioBrindadoBaseCallaoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO = new();
            servicioBrindadoBaseCallaoDTO.ServicioBrindadoBaseCallaoId = Id;
            servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioBrindadoBaseCallaoBL.EliminarFormato(servicioBrindadoBaseCallaoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //EliminarCarga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioBrindadoBaseCallaoDTO servicioBrindadoBaseCallaoDTO = new();
            servicioBrindadoBaseCallaoDTO.CargaId = Id;
            servicioBrindadoBaseCallaoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioBrindadoBaseCallaoBL.EliminarCarga(servicioBrindadoBaseCallaoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioBrindadoBaseCallaoDTO> lista = new List<ServicioBrindadoBaseCallaoDTO>();
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

                    lista.Add(new ServicioBrindadoBaseCallaoDTO
                    {
                        FechaServicio = fila.GetCell(0).ToString(),
                        EmpresaReceptoraServicio = fila.GetCell(1).ToString(),
                        CodigoServicioBrindado = fila.GetCell(2).ToString(),
                        TiempoEmpleado = fila.GetCell(3).ToString()
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
        //EnviarDatos[AuthorizePermission(Formato: 43, Permiso: 4)]
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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("FechaServicio", typeof(string)),
                    new DataColumn("EmpresaReceptoraServicio", typeof(string)),
                    new DataColumn("CodigoServicioBrindado", typeof(string)),
                    new DataColumn("TiempoEmpleado", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    TimeSpan.Parse(fila.GetCell(3).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = servicioBrindadoBaseCallaoBL.InsertarDatos(dt, Fecha);
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
            var Capitanias = servicioBrindadoBaseCallaoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzodosServicioBrindadoBaseCallao.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzodosServicioBrindadoBaseCallao.xlsx");
        }
    }

}