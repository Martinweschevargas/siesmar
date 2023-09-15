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

    public class ComesnapiServicioLavanderiaComesnapiController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ServicioLavanderiaComesnapi servicioLavanderiaComesnapiBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        ServicioLavanderia servicioLavanderiaBL = new();
        Carga cargaBL = new();

        public ComesnapiServicioLavanderiaComesnapiController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio de lavandería", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ServicioLavanderiaDTO> servicioLavanderiaDTO = servicioLavanderiaBL.ObtenerServicioLavanderias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioLavanderiaComesnapi");


            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = especialidadGenericaPersonalDTO,
                data3 = dependenciaDTO,
                data4 = servicioLavanderiaDTO,
                data5 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioLavanderiaComesnapiDTO> select = servicioLavanderiaComesnapiBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string FechaIngreso, string FechaRecojo, string CIP, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string SexoPersonal,
            string CodigoDependencia, int NumeroPrenda, string CodigoServicioLavanderia, int CargaId)
        {
            ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO = new();
            servicioLavanderiaComesnapiDTO.FechaIngreso = FechaIngreso;
            servicioLavanderiaComesnapiDTO.FechaRecojo = FechaRecojo;
            servicioLavanderiaComesnapiDTO.CIP = CIP;
            servicioLavanderiaComesnapiDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioLavanderiaComesnapiDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            servicioLavanderiaComesnapiDTO.SexoPersonal = SexoPersonal;
            servicioLavanderiaComesnapiDTO.CodigoDependencia = CodigoDependencia;
            servicioLavanderiaComesnapiDTO.NumeroPrenda = NumeroPrenda;
            servicioLavanderiaComesnapiDTO.CodigoServicioLavanderia = CodigoServicioLavanderia;
            servicioLavanderiaComesnapiDTO.CargaId = CargaId;
            
            servicioLavanderiaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioLavanderiaComesnapiBL.AgregarRegistro(servicioLavanderiaComesnapiDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioLavanderiaComesnapiBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaIngreso, string FechaRecojo, string CIP, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string SexoPersonal,
            string CodigoDependencia, int NumeroPrenda, string CodigoServicioLavanderia)
        {
            ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO = new();
            servicioLavanderiaComesnapiDTO.ServicioLavanderiaComesnapiId = Id;
            servicioLavanderiaComesnapiDTO.FechaIngreso = FechaIngreso;
            servicioLavanderiaComesnapiDTO.FechaRecojo = FechaRecojo;
            servicioLavanderiaComesnapiDTO.CIP = CIP;
            servicioLavanderiaComesnapiDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioLavanderiaComesnapiDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            servicioLavanderiaComesnapiDTO.SexoPersonal = SexoPersonal;
            servicioLavanderiaComesnapiDTO.CodigoDependencia = CodigoDependencia;
            servicioLavanderiaComesnapiDTO.NumeroPrenda = NumeroPrenda;
            servicioLavanderiaComesnapiDTO.CodigoServicioLavanderia = CodigoServicioLavanderia;
            
            servicioLavanderiaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioLavanderiaComesnapiBL.ActualizarFormato(servicioLavanderiaComesnapiDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioLavanderiaComesnapiDTO servicioLavanderiaComesnapiDTO = new();
            servicioLavanderiaComesnapiDTO.ServicioLavanderiaComesnapiId = Id;
            servicioLavanderiaComesnapiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioLavanderiaComesnapiBL.EliminarFormato(servicioLavanderiaComesnapiDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioLavanderiaComesnapiDTO> lista = new List<ServicioLavanderiaComesnapiDTO>();
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

                    lista.Add(new ServicioLavanderiaComesnapiDTO
                    {
                        FechaIngreso = fila.GetCell(0).ToString(),
                        FechaRecojo = fila.GetCell(1).ToString(),
                        CIP = fila.GetCell(2).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(4).ToString(),
                        SexoPersonal = fila.GetCell(5).ToString(),
                        CodigoDependencia = fila.GetCell(6).ToString(),
                        NumeroPrenda = int.Parse(fila.GetCell(7).ToString()),
                        CodigoServicioLavanderia = fila.GetCell(8).ToString()
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
                    new DataColumn("SexoPersonal", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("NumeroPrenda", typeof(int)),
                    new DataColumn("CodigoServicioLavanderia", typeof(string)),
 
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
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioLavanderiaComesnapiBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }




        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = servicioLavanderiaComesnapiBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComesnapiServicioLavanderia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComesnapiServicioLavanderia.xlsx");
        }


    }

}

