using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comesguard;
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

    public class ComesguardIngresoDatoServicioSastreriaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        IngresoDatoServicioSastreria ingresoDatoServicioSastreriaBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        TipoServicioSastreria tipoServicioSastreriaBL = new();
        Carga cargaBL = new();
        public ComesguardIngresoDatoServicioSastreriaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato para el ingreso de datos del servicio de sastrería", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<TipoServicioSastreriaDTO> tipoServicioSastreriaDTO = tipoServicioSastreriaBL.ObtenerTipoServicioSastrerias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("IngresoDatoServicioSastreria");
            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = especialidadGenericaPersonalDTO,
                data3 = dependenciaDTO,
                data4 = tipoServicioSastreriaDTO,
                data5 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<IngresoDatoServicioSastreriaDTO> select = ingresoDatoServicioSastreriaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaIngreso, string FechaRecojo, string CIP, string CodigoGradoPersonalMilitar,
            string CodigoEspecialidadGenericaPersonal, string Sexo, string CodigoDependencia, string CodigoTipoServicioSastreria,
            int CantidadPrendas, int CargaId)
        {
            IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO = new();
            ingresoDatoServicioPeluqueriaDTO.FechaIngreso = FechaIngreso;
            ingresoDatoServicioPeluqueriaDTO.FechaRecojo = FechaRecojo;
            ingresoDatoServicioPeluqueriaDTO.CIP = CIP;
            ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            ingresoDatoServicioPeluqueriaDTO.Sexo = Sexo;
            ingresoDatoServicioPeluqueriaDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioPeluqueriaDTO.CodigoTipoServicioSastreria = CodigoTipoServicioSastreria;
            ingresoDatoServicioPeluqueriaDTO.CantidadPrendas = CantidadPrendas;
            ingresoDatoServicioPeluqueriaDTO.CargaId = CargaId;

            ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioSastreriaBL.AgregarRegistro(ingresoDatoServicioPeluqueriaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ingresoDatoServicioSastreriaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaIngreso, string FechaRecojo, string CIP, string CodigoGradoPersonalMilitar,
            string CodigoEspecialidadGenericaPersonal, string Sexo, string CodigoDependencia, string CodigoTipoServicioSastreria,
            int CantidadPrendas)
        {
            IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO = new();
            ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioSastreriaId = Id;
            ingresoDatoServicioPeluqueriaDTO.FechaIngreso = FechaIngreso;
            ingresoDatoServicioPeluqueriaDTO.FechaRecojo = FechaRecojo;
            ingresoDatoServicioPeluqueriaDTO.CIP = CIP;
            ingresoDatoServicioPeluqueriaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ingresoDatoServicioPeluqueriaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            ingresoDatoServicioPeluqueriaDTO.Sexo = Sexo;
            ingresoDatoServicioPeluqueriaDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioPeluqueriaDTO.CodigoTipoServicioSastreria = CodigoTipoServicioSastreria;
            ingresoDatoServicioPeluqueriaDTO.CantidadPrendas = CantidadPrendas;

            ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioSastreriaBL.ActualizarFormato(ingresoDatoServicioPeluqueriaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            IngresoDatoServicioSastreriaDTO ingresoDatoServicioPeluqueriaDTO = new();
            ingresoDatoServicioPeluqueriaDTO.IngresoDatoServicioSastreriaId = Id;
            ingresoDatoServicioPeluqueriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ingresoDatoServicioSastreriaBL.EliminarFormato(ingresoDatoServicioPeluqueriaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<IngresoDatoServicioSastreriaDTO> lista = new List<IngresoDatoServicioSastreriaDTO>();
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

                    lista.Add(new IngresoDatoServicioSastreriaDTO
                    {
                        FechaIngreso = fila.GetCell(0).ToString(),
                        FechaRecojo = fila.GetCell(1).ToString(),
                        CIP = fila.GetCell(2).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(4).ToString(),
                        Sexo = fila.GetCell(5).ToString(),
                        CodigoDependencia = fila.GetCell(6).ToString(),
                        CodigoTipoServicioSastreria = fila.GetCell(7).ToString(),
                        CantidadPrendas = int.Parse(fila.GetCell(8).ToString()),
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
                    new DataColumn("FechaIngreso", typeof(string)),
                    new DataColumn("FechaRecojo", typeof(string)),
                    new DataColumn("CIP", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("Sexo ", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("CodigoTipoServicioSastreria ", typeof(string)),
                    new DataColumn("CantidadPrendas", typeof(int)),

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
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = ingresoDatoServicioSastreriaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCIDSS(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comesguard\\IngresoDatoServicioSastreria.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = ingresoDatoServicioSastreriaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("IngresoDatoServicioSastreria", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IngresoDatoServicioSastreria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IngresoDatoServicioSastreria.xlsx");
        }
    }

}

