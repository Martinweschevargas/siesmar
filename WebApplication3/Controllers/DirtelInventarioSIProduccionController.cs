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
    public class DirtelInventarioSIProduccionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        InventarioSIProduccion inventarioSIProduccionBL = new();
        AreaSatisfaceDirtel areaSatisfaceDirtelBL = new();
        CicloDesarrolloSoftware cicloDesarrolloSoftwareBL = new();
        DenominacionBaseDato denominacionBaseDatoBL = new();
        DenominacionLenguajeProgramacion denominacionLenguajeProgramacionBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public DirtelInventarioSIProduccionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Inventario de Sistemas de Informacion en Producción", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AreaSatisfaceDirtelDTO> areaSatisfaceDirtelDTO = areaSatisfaceDirtelBL.ObtenerAreaSatisfaceDirtels();
            List<CicloDesarrolloSoftwareDTO> cicloDesarrolloSoftwareDTO = cicloDesarrolloSoftwareBL.ObtenerCicloDesarrolloSoftwares();
            List<DenominacionBaseDatoDTO> denominacionBaseDatoDTO = denominacionBaseDatoBL.ObtenerDenominacionBaseDatos();
            List<DenominacionLenguajeProgramacionDTO> denominacionLenguajeProgramacionDTO = denominacionLenguajeProgramacionBL.ObtenerDenominacionLenguajeProgramacions();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InventarioSIProduccion");

            return Json(new
            {
                data1 = areaSatisfaceDirtelDTO,
                data2 = cicloDesarrolloSoftwareDTO,
                data3 = denominacionBaseDatoDTO,
                data4 = denominacionLenguajeProgramacionDTO,
                data5 = dependenciaDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<InventarioSIProduccionDTO> inventarioSIProduccionDTO = inventarioSIProduccionBL.ObtenerLista();
            return Json(new { data = inventarioSIProduccionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string SiglasSIProduccion, string CodigoAreaSatisfaceDirtel, string DescripcionFuncionalidad,
            string CodigoCicloDesarrolloSoftware, string NombreSIProduccion, string ServidorBDSIProduccion, string ProcedenciaSIProduccion,
            string CodigoDenominacionBaseDato, string AlcanceSIProduccion, string ServidorWebSIProduccion,
            string CodigoDenominacionLenguajeProgramacion, string CodigoDependencia, int CargaId)
        {

            InventarioSIProduccionDTO inventarioSIProduccionDTO = new();
            inventarioSIProduccionDTO.NombreSIProduccion = NombreSIProduccion;
            inventarioSIProduccionDTO.SiglasSIProduccion = SiglasSIProduccion;
            inventarioSIProduccionDTO.CodigoAreaSatisfaceDirtel = CodigoAreaSatisfaceDirtel;
            inventarioSIProduccionDTO.DescripcionFuncionalidad = DescripcionFuncionalidad;
            inventarioSIProduccionDTO.CodigoCicloDesarrolloSoftware = CodigoCicloDesarrolloSoftware;
            inventarioSIProduccionDTO.ServidorBDSIProduccion = ServidorBDSIProduccion;
            inventarioSIProduccionDTO.AlcanceSIProduccion = AlcanceSIProduccion;
            inventarioSIProduccionDTO.ProcedenciaSIProduccion = ProcedenciaSIProduccion;
            inventarioSIProduccionDTO.CodigoDenominacionBaseDato = CodigoDenominacionBaseDato;
            inventarioSIProduccionDTO.CodigoDenominacionLenguajeProgramacion = CodigoDenominacionLenguajeProgramacion;
            inventarioSIProduccionDTO.ServidorWebSIProduccion = ServidorWebSIProduccion;
            inventarioSIProduccionDTO.CodigoDependencia = CodigoDependencia;
            inventarioSIProduccionDTO.CargaId = CargaId;
            inventarioSIProduccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();


            var IND_OPERACION = inventarioSIProduccionBL.AgregarRegistro(inventarioSIProduccionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(inventarioSIProduccionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int InventarioSIProduccionId, string SiglasSIProduccion, string CodigoAreaSatisfaceDirtel, string DescripcionFuncionalidad,
            string CodigoCicloDesarrolloSoftware, string NombreSIProduccion, string ServidorBDSIProduccion, string ProcedenciaSIProduccion,
            string CodigoDenominacionBaseDato, string AlcanceSIProduccion, string ServidorWebSIProduccion,
            string CodigoDenominacionLenguajeProgramacion, string CodigoDependencia)
        {
            InventarioSIProduccionDTO inventarioSIProduccionDTO = new();
            inventarioSIProduccionDTO.InventarioSIProduccionId = InventarioSIProduccionId;
            inventarioSIProduccionDTO.NombreSIProduccion = NombreSIProduccion;
            inventarioSIProduccionDTO.SiglasSIProduccion = SiglasSIProduccion;
            inventarioSIProduccionDTO.CodigoAreaSatisfaceDirtel = CodigoAreaSatisfaceDirtel;
            inventarioSIProduccionDTO.DescripcionFuncionalidad = DescripcionFuncionalidad;
            inventarioSIProduccionDTO.CodigoCicloDesarrolloSoftware = CodigoCicloDesarrolloSoftware;
            inventarioSIProduccionDTO.ServidorBDSIProduccion = ServidorBDSIProduccion;
            inventarioSIProduccionDTO.AlcanceSIProduccion = AlcanceSIProduccion;
            inventarioSIProduccionDTO.ProcedenciaSIProduccion = ProcedenciaSIProduccion;
            inventarioSIProduccionDTO.CodigoDenominacionBaseDato = CodigoDenominacionBaseDato;
            inventarioSIProduccionDTO.CodigoDenominacionLenguajeProgramacion = CodigoDenominacionLenguajeProgramacion;
            inventarioSIProduccionDTO.ServidorWebSIProduccion = ServidorWebSIProduccion;
            inventarioSIProduccionDTO.CodigoDependencia = CodigoDependencia;
            inventarioSIProduccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inventarioSIProduccionBL.ActualizarFormato(inventarioSIProduccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InventarioSIProduccionDTO inventarioSIProduccionDTO = new();
            inventarioSIProduccionDTO.InventarioSIProduccionId = Id;
            inventarioSIProduccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (inventarioSIProduccionBL.EliminarFormato(inventarioSIProduccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InventarioSIProduccionDTO> lista = new List<InventarioSIProduccionDTO>();
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

                    lista.Add(new InventarioSIProduccionDTO
                    {
                        NombreSIProduccion = fila.GetCell(0).ToString(),
                        SiglasSIProduccion = fila.GetCell(1).ToString(),
                        CodigoAreaSatisfaceDirtel = fila.GetCell(2).ToString(),
                        DescripcionFuncionalidad = fila.GetCell(3).ToString(),
                        CodigoCicloDesarrolloSoftware = fila.GetCell(4).ToString(),
                        AlcanceSIProduccion = fila.GetCell(5).ToString(),
                        ProcedenciaSIProduccion = fila.GetCell(6).ToString(),
                        CodigoDenominacionBaseDato = fila.GetCell(7).ToString(),
                        ServidorBDSIProduccion = fila.GetCell(8).ToString(),
                        CodigoDenominacionLenguajeProgramacion = fila.GetCell(9).ToString(),
                        ServidorWebSIProduccion = fila.GetCell(10).ToString(),
                        CodigoDependencia = fila.GetCell(11).ToString(),

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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("NombreSIProduccion ", typeof(string)),
                    new DataColumn("SiglasSIProduccion ", typeof(string)),
                    new DataColumn("CodigoAreaSatisfaceDirtel ", typeof(string)),
                    new DataColumn("DescripcionFuncionalidad ", typeof(string)),
                    new DataColumn("CodigoCicloDesarrolloSoftware ", typeof(string)),
                    new DataColumn("AlcanceSIProduccion ", typeof(string)),
                    new DataColumn("ProcedenciaSIProduccion  ", typeof(string)),
                    new DataColumn("CodigoDenominacionBaseDato ", typeof(string)),
                    new DataColumn("ServidorBDSIProduccion  ", typeof(string)),
                    new DataColumn("CodigoDenominacionLenguajeProgramacion  ", typeof(string)),
                    new DataColumn("ServidorWebSIProduccion  ", typeof(string)),
                    new DataColumn("CodigoDependencia  ", typeof(string)),

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
                   fila.GetCell(6).ToString(),
                   fila.GetCell(7).ToString(),
                   fila.GetCell(8).ToString(),
                   fila.GetCell(9).ToString(),
                   fila.GetCell(10).ToString(),
                   fila.GetCell(11).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = inventarioSIProduccionBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDISIP(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirtel\\InventarioSIProduccion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = inventarioSIProduccionBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("InventarioSIProduccion", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\InventarioSIProduccion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "InventarioSIProduccion.xlsx");
        }
    }

}

