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

    public class ComesguardIngresoDatoServicioAlimentacionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        IngresoDatoServicioAlimentacion ingresoDatoServicioAlimentacionBL = new();

        Mes mesBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public ComesguardIngresoDatoServicioAlimentacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato para el ingreso de datos del servicio de alimentación", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("IngresoDatoServicioAlimentacion");

            return Json(new
            {
                data1 = mesDTO,
                data2 = dependenciaDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<IngresoDatoServicioAlimentacionDTO> select = ingresoDatoServicioAlimentacionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int NumeroRacion, int MesId, int PeriodoDias, string CodigoDependencia,
            int CantidadPersupe, int CantidadPersuba, int CantidadPermar, int TotalPersonalVacaciones, 
            int TotalPersonalDiaHabil, int TotalPersonalDiaNoHabil, int DiaHabil, int DiaNoHabil, int CargaId)
        {
            IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO = new();
            ingresoDatoServicioAlimentacionDTO.NumeroRacion = NumeroRacion;
            ingresoDatoServicioAlimentacionDTO.MesId = MesId;
            ingresoDatoServicioAlimentacionDTO.PeriodoDias = PeriodoDias;
            ingresoDatoServicioAlimentacionDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioAlimentacionDTO.CantidadPersupe = CantidadPersupe;
            ingresoDatoServicioAlimentacionDTO.CantidadPersuba = CantidadPersuba;
            ingresoDatoServicioAlimentacionDTO.CantidadPermar = CantidadPermar;
            ingresoDatoServicioAlimentacionDTO.TotalPersonalVacaciones = TotalPersonalVacaciones;
            ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaHabil = TotalPersonalDiaHabil;
            ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaNoHabil = TotalPersonalDiaNoHabil;
            ingresoDatoServicioAlimentacionDTO.DiaHabil = DiaHabil;
            ingresoDatoServicioAlimentacionDTO.DiaNoHabil = DiaNoHabil;
            ingresoDatoServicioAlimentacionDTO.CargaId = CargaId;
            ingresoDatoServicioAlimentacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioAlimentacionBL.AgregarRegistro(ingresoDatoServicioAlimentacionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ingresoDatoServicioAlimentacionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int NumeroRacion, int MesId, int PeriodoDias, string CodigoDependencia, 
            int CantidadPersupe, int CantidadPersuba, int CantidadPermar, int TotalPersonalVacaciones, 
            int TotalPersonalDiaHabil, int TotalPersonalDiaNoHabil, int DiaHabil, int DiaNoHabil)
        {
            IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO = new();
            ingresoDatoServicioAlimentacionDTO.IngresoDatoServicioAlimentacionId = Id;
            ingresoDatoServicioAlimentacionDTO.NumeroRacion = NumeroRacion;
            ingresoDatoServicioAlimentacionDTO.MesId = MesId;
            ingresoDatoServicioAlimentacionDTO.PeriodoDias = PeriodoDias;
            ingresoDatoServicioAlimentacionDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatoServicioAlimentacionDTO.CantidadPersupe = CantidadPersupe;
            ingresoDatoServicioAlimentacionDTO.CantidadPersuba = CantidadPersuba;
            ingresoDatoServicioAlimentacionDTO.CantidadPermar = CantidadPermar;
            ingresoDatoServicioAlimentacionDTO.TotalPersonalVacaciones = TotalPersonalVacaciones;
            ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaHabil = TotalPersonalDiaHabil;
            ingresoDatoServicioAlimentacionDTO.TotalPersonalDiaNoHabil = TotalPersonalDiaNoHabil;
            ingresoDatoServicioAlimentacionDTO.DiaHabil = DiaHabil;
            ingresoDatoServicioAlimentacionDTO.DiaNoHabil = DiaNoHabil;
            
            ingresoDatoServicioAlimentacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatoServicioAlimentacionBL.ActualizarFormato(ingresoDatoServicioAlimentacionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            IngresoDatoServicioAlimentacionDTO ingresoDatoServicioAlimentacionDTO = new();
            ingresoDatoServicioAlimentacionDTO.IngresoDatoServicioAlimentacionId = Id;
            ingresoDatoServicioAlimentacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ingresoDatoServicioAlimentacionBL.EliminarFormato(ingresoDatoServicioAlimentacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
    
        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<IngresoDatoServicioAlimentacionDTO> lista = new List<IngresoDatoServicioAlimentacionDTO>();
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

                    lista.Add(new IngresoDatoServicioAlimentacionDTO
                    {
                        NumeroRacion = int.Parse(fila.GetCell(0).ToString()),
                        MesId = int.Parse(fila.GetCell(1).ToString()),
                        PeriodoDias = int.Parse(fila.GetCell(2).ToString()),
                        CodigoDependencia = fila.GetCell(3).ToString(),
                        CantidadPersupe = int.Parse(fila.GetCell(4).ToString()),
                        CantidadPersuba = int.Parse(fila.GetCell(5).ToString()),
                        CantidadPermar = int.Parse(fila.GetCell(6).ToString()),
                        TotalPersonalVacaciones = int.Parse(fila.GetCell(7).ToString()),
                        TotalPersonalDiaHabil = int.Parse(fila.GetCell(8).ToString()),
                        TotalPersonalDiaNoHabil = int.Parse(fila.GetCell(9).ToString()),
                        DiaHabil = int.Parse(fila.GetCell(10).ToString()),
                        DiaNoHabil = int.Parse(fila.GetCell(11).ToString()),

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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("NumeroRacion", typeof(int)),
                    new DataColumn("MesId", typeof(int)),
                    new DataColumn("PeriodoDias", typeof(int)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CantidadPersupe", typeof(int)),
                    new DataColumn("CantidadPersuba", typeof(int)),
                    new DataColumn("CantidadPermar", typeof(int)),
                    new DataColumn("TotalPersonalVacaciones", typeof(int)),
                    new DataColumn("TotalPersonalDiaHabil", typeof(int)),
                    new DataColumn("TotalPersonalDiaNoHabil", typeof(int)),
                    new DataColumn("DiaHabil", typeof(int)),
                    new DataColumn("DiaNoHabil", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = ingresoDatoServicioAlimentacionBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteCIDSA(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comesguard\\IngresoDatoServicioAlimentacion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = ingresoDatoServicioAlimentacionBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("IngresoDatoServicioAlimentacion", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IngresoDatoServicioAlimentacion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IngresoDatoServicioAlimentacion.xlsx");
        }
    }

}


