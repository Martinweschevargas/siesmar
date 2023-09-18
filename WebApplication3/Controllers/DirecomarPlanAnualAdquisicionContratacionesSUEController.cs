using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Direcomar;
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

    public class DirecomarPlanAnualAdquisicionContratacionesSUEController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PlanAnualAdquisicionContratacionesSUE planAnualAdquisicionContratacionesBL = new();
        Mes mesBL = new();
        SubUnidadEjecutora subUnidadEjecutoraBL = new();
        Carga cargaBL = new();

        public DirecomarPlanAnualAdquisicionContratacionesSUEController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> MesDTO = mesBL.ObtenerMess();
            List<SubUnidadEjecutoraDTO> SubUnidadEjecutoraDTO = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PlanAnualAdquisicionContratacionSUE");
            return Json(new { 
                data1 = MesDTO, 
                data2 = SubUnidadEjecutoraDTO, 
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<PlanAnualAdquisicionContratacionesSUEDTO> select = planAnualAdquisicionContratacionesBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        { 
            return View();
        }

        public ActionResult Insertar(int AnioAdquisicion, string NumeroMes, string CodigoSubunidadEjecutora, int IncluidosAdquisicion, 
            decimal ImporteIncluidosAdquisicion, int ConvocadosAdquisicion, decimal ImporteConvocadosAdquisicion, int ExcluidosAdquisicion,
            decimal ImporteExcluidoAdquisicion, int CargaId, string Fecha)
        {
            PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO = new();
            planAnualAdquisicionContratacionSUEDTO.AnioAdquisicion = AnioAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.NumeroMes = NumeroMes;
            planAnualAdquisicionContratacionSUEDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            planAnualAdquisicionContratacionSUEDTO.IncluidosAdquisicion = IncluidosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ImporteIncluidosAdquisicion = ImporteIncluidosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ConvocadosAdquisicion = ConvocadosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ImporteConvocadosAdquisicion = ImporteConvocadosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ExcluidosAdquisicion = ExcluidosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ImporteExcluidoAdquisicion = ImporteExcluidoAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.CargaId = CargaId;
            planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = planAnualAdquisicionContratacionesBL.AgregarRegistro(planAnualAdquisicionContratacionSUEDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(planAnualAdquisicionContratacionesBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioAdquisicion, string NumeroMes, string CodigoSubunidadEjecutora, int IncluidosAdquisicion,
            decimal ImporteIncluidosAdquisicion, int ConvocadosAdquisicion, decimal ImporteConvocadosAdquisicion, int ExcluidosAdquisicion, 
            decimal ImporteExcluidoAdquisicion)
        {
            PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO = new();
            planAnualAdquisicionContratacionSUEDTO.PlanAnualAdquisicionContratacionId = Id;
            planAnualAdquisicionContratacionSUEDTO.AnioAdquisicion = AnioAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.NumeroMes = NumeroMes;
            planAnualAdquisicionContratacionSUEDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            planAnualAdquisicionContratacionSUEDTO.IncluidosAdquisicion = IncluidosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ImporteIncluidosAdquisicion = ImporteIncluidosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ConvocadosAdquisicion = ConvocadosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ImporteConvocadosAdquisicion = ImporteConvocadosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ExcluidosAdquisicion = ExcluidosAdquisicion;
            planAnualAdquisicionContratacionSUEDTO.ImporteExcluidoAdquisicion = ImporteExcluidoAdquisicion;
   
            planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = planAnualAdquisicionContratacionesBL.ActualizarFormato(planAnualAdquisicionContratacionSUEDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO = new();
            planAnualAdquisicionContratacionSUEDTO.PlanAnualAdquisicionContratacionId = Id;
            planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (planAnualAdquisicionContratacionesBL.EliminarFormato(planAnualAdquisicionContratacionSUEDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PlanAnualAdquisicionContratacionesSUEDTO planAnualAdquisicionContratacionSUEDTO = new();
            planAnualAdquisicionContratacionSUEDTO.CargaId = Id;
            planAnualAdquisicionContratacionSUEDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (planAnualAdquisicionContratacionesBL.EliminarCarga(planAnualAdquisicionContratacionSUEDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PlanAnualAdquisicionContratacionesSUEDTO> lista = new List<PlanAnualAdquisicionContratacionesSUEDTO>();
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

                    lista.Add(new PlanAnualAdquisicionContratacionesSUEDTO
                    {
                        AnioAdquisicion = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoSubunidadEjecutora = fila.GetCell(2).ToString(),
                        IncluidosAdquisicion = int.Parse(fila.GetCell(3).ToString()),
                        ImporteIncluidosAdquisicion = decimal.Parse(fila.GetCell(4).ToString()),
                        ConvocadosAdquisicion = int.Parse(fila.GetCell(5).ToString()),
                        ImporteConvocadosAdquisicion = decimal.Parse(fila.GetCell(6).ToString()),
                        ExcluidosAdquisicion = int.Parse(fila.GetCell(7).ToString()),
                        ImporteExcluidoAdquisicion = decimal.Parse(fila.GetCell(8).ToString()),

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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("AnioAdquisicion", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoSubunidadEjecutora", typeof(string)),
                    new DataColumn("IncluidosAdquisicion", typeof(int)),
                    new DataColumn("ImporteIncluidosAdquisicion", typeof(decimal)),
                    new DataColumn("ConvocadosAdquisicion", typeof(int)),
                    new DataColumn("ImporteConvocadosAdquisicion", typeof(decimal)),
                    new DataColumn("ExcluidosAdquisicion", typeof(int)),
                    new DataColumn("ImporteExcluidoAdquisicion", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario()
                    );
            }
            var IND_OPERACION = planAnualAdquisicionContratacionesBL.InsertarDatos(dt, Fecha);
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
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirecomarPlanAnualAdquisicionContratacionesSUE.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirecomarPlanAnualAdquisicionContratacionesSUE.xlsx");
        }
    }

}

