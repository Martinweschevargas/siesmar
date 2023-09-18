using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComoperpacNumeroUnidadFuerzaNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        NumeroUnidadFuerzaNaval numeroUnidadFuerzaNavalBL = new();
        ComandanciaDependencia comandanciaDependenciaBL = new();
        UnidadBelica unidadBelicaBL = new();
        EstadoOperativo estadoOperativoBL = new();
        Carga cargaBL = new();

        public ComoperpacNumeroUnidadFuerzaNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<UnidadBelicaDTO> unidadBelicaDTO = unidadBelicaBL.ObtenerUnidadBelicas();
            List<EstadoOperativoDTO> estadoOperativoDTO = estadoOperativoBL.ObtenerEstadoOperativos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("NumeroUnidadFuerzaNaval");
            return Json(new { 
                data1 = comandanciaDependenciaDTO, 
                data2 = unidadBelicaDTO, 
                data3 = estadoOperativoDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<NumeroUnidadFuerzaNavalDTO> select = numeroUnidadFuerzaNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoComandanciaDependencia, 
            string CodigoUnidadBelica, string CodigoEstadoOperativo, int CargaId, string Fecha)
        {
            NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO = new();
            numeroUnidadFuerzaNavalDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            numeroUnidadFuerzaNavalDTO.CodigoUnidadBelica = CodigoUnidadBelica;
            numeroUnidadFuerzaNavalDTO.CodigoEstadoOperativo = CodigoEstadoOperativo;
            numeroUnidadFuerzaNavalDTO.CargaId = CargaId;
            numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = numeroUnidadFuerzaNavalBL.AgregarRegistro(numeroUnidadFuerzaNavalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(numeroUnidadFuerzaNavalBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoComandanciaDependencia, string CodigoUnidadBelica, 
            string CodigoEstadoOperativo)
        {
            NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO = new();
            numeroUnidadFuerzaNavalDTO.NumeroUnidadFuerzaNavalId = Id;
            numeroUnidadFuerzaNavalDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            numeroUnidadFuerzaNavalDTO.CodigoUnidadBelica = CodigoUnidadBelica;
            numeroUnidadFuerzaNavalDTO.CodigoEstadoOperativo = CodigoEstadoOperativo;
            numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = numeroUnidadFuerzaNavalBL.ActualizarFormato(numeroUnidadFuerzaNavalDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO = new();
            numeroUnidadFuerzaNavalDTO.NumeroUnidadFuerzaNavalId = Id;
            numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (numeroUnidadFuerzaNavalBL.EliminarFormato(numeroUnidadFuerzaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            NumeroUnidadFuerzaNavalDTO numeroUnidadFuerzaNavalDTO = new();
            numeroUnidadFuerzaNavalDTO.CargaId = Id;
            numeroUnidadFuerzaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (numeroUnidadFuerzaNavalBL.EliminarCarga(numeroUnidadFuerzaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<NumeroUnidadFuerzaNavalDTO> lista = new List<NumeroUnidadFuerzaNavalDTO>();
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

                    lista.Add(new NumeroUnidadFuerzaNavalDTO
                    {
                        CodigoComandanciaDependencia = fila.GetCell(0).ToString(),
                        CodigoUnidadBelica = fila.GetCell(1).ToString(),
                        CodigoEstadoOperativo = fila.GetCell(2).ToString()
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[4]
            {
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("CodigoUnidadBelica", typeof(string)),
                    new DataColumn("CodigoEstadoOperativo", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = numeroUnidadFuerzaNavalBL.InsertarDatos(dt, Fecha);
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
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperpacNumeroUnidadFuerzaNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperpacNumeroUnidadFuerzaNaval.xlsx");
        }
    }
}

