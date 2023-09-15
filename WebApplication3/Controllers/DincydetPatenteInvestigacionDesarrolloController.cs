using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dincydet;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DincydetPatenteInvestigacionDesarrolloController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        PatenteInvestigacionDesarrollo patenteInvestigacionDesarrolloBL = new();
        AreaCT areaCTBL = new();
        Carga cargaBL = new();

        public DincydetPatenteInvestigacionDesarrolloController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo Patentes Solicitadas y Otorgados por Indecopi en Investigación y Desarrollo", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaCTDTO> AreaCTDTO = areaCTBL.ObtenerAreaCTs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PatenteInvestigacionDesarrollo");
            return Json(new { data1 = AreaCTDTO, data2 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<PatenteInvestigacionDesarrolloDTO> select = patenteInvestigacionDesarrolloBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar(string DenominacionPatenteInvestigacion, string EstadoPatenteInvestigacion, string CodigoAreaCT, int CargaId, string Fecha)
        {
            PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO  = new();
            patenteInvestigacionDesarrolloDTO.DenominacionPatenteInvestigacion = DenominacionPatenteInvestigacion;
            patenteInvestigacionDesarrolloDTO.EstadoPatenteInvestigacion = EstadoPatenteInvestigacion;
            patenteInvestigacionDesarrolloDTO.CodigoAreaCT = CodigoAreaCT;
            patenteInvestigacionDesarrolloDTO.CargaId = CargaId;
            patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = patenteInvestigacionDesarrolloBL.AgregarRegistro(patenteInvestigacionDesarrolloDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(patenteInvestigacionDesarrolloBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DenominacionPatenteInvestigacion, string EstadoPatenteInvestigacion, string CodigoAreaCT)
        {

            PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO = new();
            patenteInvestigacionDesarrolloDTO.PatenteInvestigacionDesarrolloId = Id;
            patenteInvestigacionDesarrolloDTO.DenominacionPatenteInvestigacion = DenominacionPatenteInvestigacion;
            patenteInvestigacionDesarrolloDTO.EstadoPatenteInvestigacion = EstadoPatenteInvestigacion;
            patenteInvestigacionDesarrolloDTO.CodigoAreaCT = CodigoAreaCT;
            patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = patenteInvestigacionDesarrolloBL.ActualizarFormato(patenteInvestigacionDesarrolloDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO = new();
            patenteInvestigacionDesarrolloDTO.PatenteInvestigacionDesarrolloId = Id;
            patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (patenteInvestigacionDesarrolloBL.EliminarFormato(patenteInvestigacionDesarrolloDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PatenteInvestigacionDesarrolloDTO patenteInvestigacionDesarrolloDTO = new();
            patenteInvestigacionDesarrolloDTO.CargaId = Id;
            patenteInvestigacionDesarrolloDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (patenteInvestigacionDesarrolloBL.EliminarCarga(patenteInvestigacionDesarrolloDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PatenteInvestigacionDesarrolloDTO> lista = new List<PatenteInvestigacionDesarrolloDTO>();
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

                    lista.Add(new PatenteInvestigacionDesarrolloDTO
                    {
                        DenominacionPatenteInvestigacion = fila.GetCell(0).ToString(),
                        EstadoPatenteInvestigacion = fila.GetCell(1).ToString(),
                        CodigoAreaCT = fila.GetCell(2).ToString()
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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
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

            dt.Columns.AddRange(new DataColumn[4]
            {
                 new DataColumn("DenominacionPatenteInvestigacion", typeof(string)),
                 new DataColumn("EstadoPatenteInvestigacion", typeof(string)),
                 new DataColumn("CodigoAreaCT", typeof(string)),
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
            var IND_OPERACION = patenteInvestigacionDesarrolloBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetPatenteInvestigacionDesarrollo.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetPatenteInvestigacionDesarrollo.xlsx");
        }
    }

}