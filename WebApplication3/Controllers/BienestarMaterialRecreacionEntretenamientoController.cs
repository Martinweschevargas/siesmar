using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Bienestar;
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

    public class BienestarMaterialRecreacionEntretenamientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        MaterialRecreacionEntretenamiento materialRecreacionEntretenamientoBL = new();

        Dependencia dependenciaBL = new();
        MaterialDeportivo materialDeportivoBL = new();
        MaterialRecreativo materialRecreativoBL = new();
        MaterialEntretenimiento materialEntretenimientoBL = new();
        Carga cargaBL = new();

        public BienestarMaterialRecreacionEntretenamientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Material de Recreación, Entretenimiento y Recreativo Asignado", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<MaterialDeportivoDTO> materialDeportivoDTO = materialDeportivoBL.ObtenerMaterialDeportivos();
            List<MaterialRecreativoDTO> materialRecreativoDTO = materialRecreativoBL.ObtenerMaterialRecreativos();
            List<MaterialEntretenimientoDTO> materialEntretenimientoDTO = materialEntretenimientoBL.ObtenerMaterialEntretenimientos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("MaterialRecreacionEntretenamiento");
            return Json(new { 
                data1 = dependenciaDTO, 
                data2 = materialDeportivoDTO,  
                data3 = materialRecreativoDTO,
                data4 = materialEntretenimientoDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<MaterialRecreacionEntretenamientoDTO> select = materialRecreacionEntretenamientoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }
        public ActionResult Insertar(string FechaSolicitud, string CodigoDependencia, string CodigoMaterialDeportivo, int CantidadSolicitadoDeportivo,
            int CantidadAtendidoDeportivo, decimal MontoSolesSolicitadoDeportivo, decimal MontoSolesAtendidoDeportivo, string CodigoMaterialRecreativo,
            int CantidadSolicitadoRecreativo, int CantidadAtendidoRecreativo, decimal MontoSolesSolicitanteRecreativo, decimal MontoSolesAtendidoRecreativo,
            string CodigoMaterialEntretenimiento, int CantidadSolicitadoEntretenimiento, int CantidadAtendidoEntretenimiento, decimal MontoSolesSolicitadoEntretenimiento,
            decimal MontoSolesAtendidoEntretenimiento, int CargaId, string fecha)
        {
            MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO = new();
            materialRecreacionEntretenamientoDTO.FechaSolicitud = FechaSolicitud;
            materialRecreacionEntretenamientoDTO.CodigoDependencia = CodigoDependencia;
            materialRecreacionEntretenamientoDTO.CodigoMaterialDeportivo = CodigoMaterialDeportivo;
            materialRecreacionEntretenamientoDTO.CantidadSolicitadoDeportivo = CantidadSolicitadoDeportivo;
            materialRecreacionEntretenamientoDTO.CantidadAtendidoDeportivo = CantidadAtendidoDeportivo;
            materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoDeportivo = MontoSolesSolicitadoDeportivo;
            materialRecreacionEntretenamientoDTO.MontoSolesAtendidoDeportivo = MontoSolesAtendidoDeportivo;
            materialRecreacionEntretenamientoDTO.CodigoMaterialRecreativo = CodigoMaterialRecreativo;
            materialRecreacionEntretenamientoDTO.CantidadSolicitadoRecreativo = CantidadSolicitadoRecreativo;
            materialRecreacionEntretenamientoDTO.CantidadAtendidoRecreativo = CantidadAtendidoRecreativo;
            materialRecreacionEntretenamientoDTO.MontoSolesSolicitanteRecreativo = MontoSolesSolicitanteRecreativo;
            materialRecreacionEntretenamientoDTO.MontoSolesAtendidoRecreativo = MontoSolesAtendidoRecreativo;
            materialRecreacionEntretenamientoDTO.CodigoMaterialEntretenimiento = CodigoMaterialEntretenimiento;
            materialRecreacionEntretenamientoDTO.CantidadSolicitadoEntretenimiento = CantidadSolicitadoEntretenimiento;
            materialRecreacionEntretenamientoDTO.CantidadAtendidoEntretenimiento = CantidadAtendidoEntretenimiento;
            materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoEntretenimiento = MontoSolesSolicitadoEntretenimiento;
            materialRecreacionEntretenamientoDTO.MontoSolesAtendidoEntretenimiento = MontoSolesAtendidoEntretenimiento;
            materialRecreacionEntretenamientoDTO.CargaId = CargaId;
            materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materialRecreacionEntretenamientoBL.AgregarRegistro(materialRecreacionEntretenamientoDTO, fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(materialRecreacionEntretenamientoBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaSolicitud, string CodigoDependencia, string CodigoMaterialDeportivo, int CantidadSolicitadoDeportivo,
            int CantidadAtendidoDeportivo, decimal MontoSolesSolicitadoDeportivo, decimal MontoSolesAtendidoDeportivo, string CodigoMaterialRecreativo,
            int CantidadSolicitadoRecreativo, int CantidadAtendidoRecreativo, decimal MontoSolesSolicitanteRecreativo, decimal MontoSolesAtendidoRecreativo,
            string CodigoMaterialEntretenimiento, int CantidadSolicitadoEntretenimiento, int CantidadAtendidoEntretenimiento, decimal MontoSolesSolicitadoEntretenimiento,
            decimal MontoSolesAtendidoEntretenimiento)
        {
            MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO = new();
            materialRecreacionEntretenamientoDTO.MaterialRecreacionEntretenamientoId = Id;
            materialRecreacionEntretenamientoDTO.FechaSolicitud = FechaSolicitud;
            materialRecreacionEntretenamientoDTO.CodigoDependencia = CodigoDependencia;
            materialRecreacionEntretenamientoDTO.CodigoMaterialDeportivo = CodigoMaterialDeportivo;
            materialRecreacionEntretenamientoDTO.CantidadSolicitadoDeportivo = CantidadSolicitadoDeportivo;
            materialRecreacionEntretenamientoDTO.CantidadAtendidoDeportivo = CantidadAtendidoDeportivo;
            materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoDeportivo = MontoSolesSolicitadoDeportivo;
            materialRecreacionEntretenamientoDTO.MontoSolesAtendidoDeportivo = MontoSolesAtendidoDeportivo;
            materialRecreacionEntretenamientoDTO.CodigoMaterialRecreativo = CodigoMaterialRecreativo;
            materialRecreacionEntretenamientoDTO.CantidadSolicitadoRecreativo = CantidadSolicitadoRecreativo;
            materialRecreacionEntretenamientoDTO.CantidadAtendidoRecreativo = CantidadAtendidoRecreativo;
            materialRecreacionEntretenamientoDTO.MontoSolesSolicitanteRecreativo = MontoSolesSolicitanteRecreativo;
            materialRecreacionEntretenamientoDTO.MontoSolesAtendidoRecreativo = MontoSolesAtendidoRecreativo;
            materialRecreacionEntretenamientoDTO.CodigoMaterialEntretenimiento = CodigoMaterialEntretenimiento;
            materialRecreacionEntretenamientoDTO.CantidadSolicitadoEntretenimiento = CantidadSolicitadoEntretenimiento;
            materialRecreacionEntretenamientoDTO.CantidadAtendidoEntretenimiento = CantidadAtendidoEntretenimiento;
            materialRecreacionEntretenamientoDTO.MontoSolesSolicitadoEntretenimiento = MontoSolesSolicitadoEntretenimiento;
            materialRecreacionEntretenamientoDTO.MontoSolesAtendidoEntretenimiento = MontoSolesAtendidoEntretenimiento;
            materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = materialRecreacionEntretenamientoBL.ActualizarFormato(materialRecreacionEntretenamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO = new();
            materialRecreacionEntretenamientoDTO.MaterialRecreacionEntretenamientoId = Id;
            materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (materialRecreacionEntretenamientoBL.EliminarFormato(materialRecreacionEntretenamientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            MaterialRecreacionEntretenamientoDTO materialRecreacionEntretenamientoDTO = new();
            materialRecreacionEntretenamientoDTO.CargaId = Id;
            materialRecreacionEntretenamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (materialRecreacionEntretenamientoBL.EliminarCarga(materialRecreacionEntretenamientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<MaterialRecreacionEntretenamientoDTO> lista = new List<MaterialRecreacionEntretenamientoDTO>();
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

                    lista.Add(new MaterialRecreacionEntretenamientoDTO
                    {
                        FechaSolicitud = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        CodigoMaterialDeportivo = fila.GetCell(2).ToString(),
                        CantidadSolicitadoDeportivo = int.Parse(fila.GetCell(3).ToString()),
                        CantidadAtendidoDeportivo = int.Parse(fila.GetCell(4).ToString()),
                        MontoSolesSolicitadoDeportivo = decimal.Parse(fila.GetCell(5).ToString()),
                        MontoSolesAtendidoDeportivo = decimal.Parse(fila.GetCell(6).ToString()),
                        CodigoMaterialRecreativo = fila.GetCell(7).ToString(),
                        CantidadSolicitadoRecreativo = int.Parse(fila.GetCell(8).ToString()),
                        CantidadAtendidoRecreativo = int.Parse(fila.GetCell(9).ToString()),
                        MontoSolesSolicitanteRecreativo = decimal.Parse(fila.GetCell(10).ToString()),
                        MontoSolesAtendidoRecreativo = decimal.Parse(fila.GetCell(11).ToString()),
                        CodigoMaterialEntretenimiento = fila.GetCell(12).ToString(),
                        CantidadSolicitadoEntretenimiento = int.Parse(fila.GetCell(13).ToString()),
                        CantidadAtendidoEntretenimiento = int.Parse(fila.GetCell(14).ToString()),
                        MontoSolesSolicitadoEntretenimiento = decimal.Parse(fila.GetCell(15).ToString()),
                        MontoSolesAtendidoEntretenimiento = decimal.Parse(fila.GetCell(16).ToString())
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

            dt.Columns.AddRange(new DataColumn[18]
            {
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoMaterialDeportivo", typeof(string)),
                    new DataColumn("CantidadSolicitadoDeportivo", typeof(int)),
                    new DataColumn("CantidadAtendidoDeportivo", typeof(int)),
                    new DataColumn("MontoSolesSolicitadoDeportivo", typeof(decimal)),
                    new DataColumn("MontoSolesAtendidoDeportivo", typeof(decimal)),
                    new DataColumn("CodigoMaterialRecreativo", typeof(string)),
                    new DataColumn("CantidadSolicitadoRecreativo", typeof(int)),
                    new DataColumn("CantidadAtendidoRecreativo", typeof(int)),
                    new DataColumn("MontoSolesSolicitanteRecreativo", typeof(decimal)),
                    new DataColumn("MontoSolesAtendidoRecreativo", typeof(decimal)),
                    new DataColumn("CodigoMaterialEntretenimiento", typeof(string)),
                    new DataColumn("CantidadSolicitadoEntretenimiento", typeof(int)),
                    new DataColumn("CantidadAtendidoEntretenimiento", typeof(int)),
                    new DataColumn("MontoSolesSolicitadoEntretenimiento", typeof(decimal)),
                    new DataColumn("MontoSolesAtendidoEntretenimiento", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    decimal.Parse(fila.GetCell(11).ToString()),
                    fila.GetCell(12).ToString(),
                    int.Parse(fila.GetCell(13).ToString()),
                    int.Parse(fila.GetCell(14).ToString()),
                    decimal.Parse(fila.GetCell(15).ToString()),
                    decimal.Parse(fila.GetCell(16).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = materialRecreacionEntretenamientoBL.InsertarDatos(dt, fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteBMRE(int idCarga)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\MaterialRecreacionEntretenimiento.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var materialRecreacionEntretenamiento = materialRecreacionEntretenamientoBL.BienestarVisualizacionMaterialRecreacionEntretenmiento(idCarga);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("MaterialRecreacionEntretenimiento", materialRecreacionEntretenamiento);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarMaterialRecreacionEntretenamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarMaterialRecreacionEntretenamiento.xlsx");
        }

    }

}

