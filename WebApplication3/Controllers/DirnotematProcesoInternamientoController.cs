using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.AccesoDatos.Formatos.Dirnotemat;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirnotemat;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
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
    public class DirnotematProcesoInternamientoController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        ProcesoInternamientoDAO procesoInternamientoBL = new();
        TipoProcesoDirnotematDAO tipoProcesoDirnotematBL = new();
        Carga cargaBL = new();

        public DirnotematProcesoInternamientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Proceso de Internamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoProcesoDirnotematDTO> TipoProcesoDirnotematDTO = tipoProcesoDirnotematBL.ObtenerTipoProcesoDirnotemats();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ProcesoInternamiento");

            return Json(new
            {
                data1 = TipoProcesoDirnotematDTO,
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ProcesoInternamientoDTO> select = procesoInternamientoBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string NombreProceso, string NroContratoProceso, string CodigoTipoProcesoDirnotemat, 
            string NroProcesoInternamiento, string NroguiaProceso, string FechaIngresoProceso,
            string TiempoEvaluacion, string ResultadoEvaluacion, string LaboratorioProcesoInternamiento, int CargaId, string Fecha)
        {
            ProcesoInternamientoDTO procesoInternamientoDTO = new();
            procesoInternamientoDTO.NombreProceso = NombreProceso;
            procesoInternamientoDTO.NroContratoProceso = NroContratoProceso;
            procesoInternamientoDTO.CodigoTipoProcesoDirnotemat = CodigoTipoProcesoDirnotemat;
            procesoInternamientoDTO.NroProcesoInternamiento = NroProcesoInternamiento;
            procesoInternamientoDTO.NroguiaProceso = NroguiaProceso;
            procesoInternamientoDTO.FechaIngresoProceso = FechaIngresoProceso;
            procesoInternamientoDTO.TiempoEvaluacion = TiempoEvaluacion;
            procesoInternamientoDTO.ResultadoEvaluacion = ResultadoEvaluacion;
            procesoInternamientoDTO.LaboratorioProcesoInternamiento = LaboratorioProcesoInternamiento;
            procesoInternamientoDTO.CargaId = CargaId;
            procesoInternamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procesoInternamientoBL.AgregarRegistro(procesoInternamientoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(procesoInternamientoBL.BuscarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string NombreProceso, string NroContratoProceso, string CodigoTipoProcesoDirnotemat,
            string NroProcesoInternamiento, string NroguiaProceso, string FechaIngresoProceso,
            string TiempoEvaluacion, string ResultadoEvaluacion, string LaboratorioProcesoInternamiento)
        {

            ProcesoInternamientoDTO procesoInternamientoDTO = new();
            procesoInternamientoDTO.ProcesoInternamientoId = Id;
            procesoInternamientoDTO.NombreProceso = NombreProceso;
            procesoInternamientoDTO.NroContratoProceso = NroContratoProceso;
            procesoInternamientoDTO.CodigoTipoProcesoDirnotemat = CodigoTipoProcesoDirnotemat;
            procesoInternamientoDTO.NroProcesoInternamiento = NroProcesoInternamiento;
            procesoInternamientoDTO.NroguiaProceso = NroguiaProceso;
            procesoInternamientoDTO.FechaIngresoProceso = FechaIngresoProceso;
            procesoInternamientoDTO.TiempoEvaluacion = TiempoEvaluacion;
            procesoInternamientoDTO.ResultadoEvaluacion = ResultadoEvaluacion;
            procesoInternamientoDTO.LaboratorioProcesoInternamiento = LaboratorioProcesoInternamiento;
            procesoInternamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = procesoInternamientoBL.ActualizaFormato(procesoInternamientoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ProcesoInternamientoDTO procesoInternamientoDTO = new();
            procesoInternamientoDTO.ProcesoInternamientoId = Id;
            procesoInternamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (procesoInternamientoBL.EliminarFormato(procesoInternamientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ProcesoInternamientoDTO procesoInternamientoDTO = new();
            procesoInternamientoDTO.CargaId = Id;
            procesoInternamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (procesoInternamientoBL.EliminarCarga(procesoInternamientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ProcesoInternamientoDTO> lista = new List<ProcesoInternamientoDTO>();
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

                    lista.Add(new ProcesoInternamientoDTO
                    {
                        NombreProceso = fila.GetCell(0).ToString(),
                        NroContratoProceso = fila.GetCell(1).ToString(),
                        CodigoTipoProcesoDirnotemat = fila.GetCell(2).ToString(),
                        NroProcesoInternamiento = fila.GetCell(3).ToString(),
                        NroguiaProceso = fila.GetCell(4).ToString(),
                        FechaIngresoProceso = fila.GetCell(5).ToString(),
                        TiempoEvaluacion = fila.GetCell(6).ToString(),
                        ResultadoEvaluacion = fila.GetCell(7).ToString(),
                        LaboratorioProcesoInternamiento = fila.GetCell(8).ToString()
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("NombreProceso", typeof(string)),
                    new DataColumn("NroContratoProceso", typeof(string)),
                    new DataColumn("CodigoTipoProcesoDirnotemat", typeof(string)),
                    new DataColumn("NroProcesoInternamiento", typeof(string)),
                    new DataColumn("NroguiaProceso", typeof(string)),
                    new DataColumn("FechaIngresoProceso", typeof(string)),
                    new DataColumn("TiempoEvaluacion", typeof(string)),
                    new DataColumn("ResultadoEvaluacion", typeof(string)),
                    new DataColumn("LaboratorioProcesoInternamiento", typeof(string)),
 
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = procesoInternamientoBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirnotematProcesoInternamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirnotematProcesoInternamiento.xlsx");
        }
    }

}