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

    public class DirecomarEvaluacionPresupuestalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EvaluacionPresupuestal evaluacionPresupuestalBL = new();
        Mes mesBL = new();
        SubUnidadEjecutora subUnidadEjecutoraBL = new();
        FuenteFinanciamiento fuenteFinanciamientoBL = new();
        ClasificacionGenericaGasto clasificacionGenericaGastoBL = new();
        Carga cargaBL = new();

        public DirecomarEvaluacionPresupuestalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Evaluación Presupuestal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> MesDTO = mesBL.ObtenerMess();
            List<SubUnidadEjecutoraDTO> SubUnidadEjecutoraDTO = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            List<FuenteFinanciamientoDTO> FuenteFinanciamientoDTO = fuenteFinanciamientoBL.ObtenerFuenteFinanciamientos();
            List<ClasificacionGenericaGastoDTO> ClasificacionGenericaGastoDTO = clasificacionGenericaGastoBL.ObtenerClasificacionGenericaGastos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EvaluacionPresupuestal");
            return Json(new { data1 = MesDTO, data2 = SubUnidadEjecutoraDTO, data3 = FuenteFinanciamientoDTO, data4 = ClasificacionGenericaGastoDTO, data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<EvaluacionPresupuestalDTO> select = evaluacionPresupuestalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(int AnioEvaluacionPresupuesta, string NumeroMes, string CodigoSubunidadEjecutora, string CodigoFuenteFinanciamiento,
            string ClasificacionGenericaGasto, decimal ASIGPIMPresupuestal, decimal PCAPresupuestal,
            decimal CertificadoPresupuestal, decimal CompromisoPresupuestal, decimal DevengadoPresupuestal, decimal GiradoPresupuestal,
            int AvancePresupuestal, int CargaId, string Fecha)
        {
            EvaluacionPresupuestalDTO evaluacionPresupuestalDTO = new();
            evaluacionPresupuestalDTO.AnioEvaluacionPresupuesta = AnioEvaluacionPresupuesta;
            evaluacionPresupuestalDTO.NumeroMes = NumeroMes;
            evaluacionPresupuestalDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            evaluacionPresupuestalDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            evaluacionPresupuestalDTO.ClasificacionGenericaGasto = ClasificacionGenericaGasto;
            evaluacionPresupuestalDTO.ASIGPIMPresupuestal = ASIGPIMPresupuestal;
            evaluacionPresupuestalDTO.PCAPresupuestal = PCAPresupuestal;
            evaluacionPresupuestalDTO.CertificadoPresupuestal = CertificadoPresupuestal;
            evaluacionPresupuestalDTO.CompromisoPresupuestal = CompromisoPresupuestal;
            evaluacionPresupuestalDTO.DevengadoPresupuestal = DevengadoPresupuestal;
            evaluacionPresupuestalDTO.GiradoPresupuestal = GiradoPresupuestal;
            evaluacionPresupuestalDTO.AvancePresupuestal = AvancePresupuestal;
            evaluacionPresupuestalDTO.CargaId = CargaId;
            evaluacionPresupuestalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionPresupuestalBL.AgregarRegistro(evaluacionPresupuestalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(evaluacionPresupuestalBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioEvaluacionPresupuesta, string NumeroMes, string CodigoSubunidadEjecutora, string CodigoFuenteFinanciamiento,
            string ClasificacionGenericaGasto, decimal ASIGPIMPresupuestal, decimal PCAPresupuestal,
            decimal CertificadoPresupuestal, decimal CompromisoPresupuestal, decimal DevengadoPresupuestal, decimal GiradoPresupuestal,
            int AvancePresupuestal)
        {
            EvaluacionPresupuestalDTO evaluacionPresupuestalDTO = new();
            evaluacionPresupuestalDTO.EvaluacionPresupuestalId = Id;
            evaluacionPresupuestalDTO.AnioEvaluacionPresupuesta = AnioEvaluacionPresupuesta;
            evaluacionPresupuestalDTO.NumeroMes = NumeroMes;
            evaluacionPresupuestalDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            evaluacionPresupuestalDTO.CodigoFuenteFinanciamiento = CodigoFuenteFinanciamiento;
            evaluacionPresupuestalDTO.ClasificacionGenericaGasto = ClasificacionGenericaGasto;
            evaluacionPresupuestalDTO.ASIGPIMPresupuestal = ASIGPIMPresupuestal;
            evaluacionPresupuestalDTO.PCAPresupuestal = PCAPresupuestal;
            evaluacionPresupuestalDTO.CertificadoPresupuestal = CertificadoPresupuestal;
            evaluacionPresupuestalDTO.CompromisoPresupuestal = CompromisoPresupuestal;
            evaluacionPresupuestalDTO.DevengadoPresupuestal = DevengadoPresupuestal;
            evaluacionPresupuestalDTO.GiradoPresupuestal = GiradoPresupuestal;
            evaluacionPresupuestalDTO.AvancePresupuestal = AvancePresupuestal;
            evaluacionPresupuestalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = evaluacionPresupuestalBL.ActualizarFormato(evaluacionPresupuestalDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EvaluacionPresupuestalDTO evaluacionPresupuestalDTO = new();
            evaluacionPresupuestalDTO.EvaluacionPresupuestalId = Id;
            evaluacionPresupuestalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (evaluacionPresupuestalBL.EliminarFormato(evaluacionPresupuestalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EvaluacionPresupuestalDTO evaluacionPresupuestalDTO = new();
            evaluacionPresupuestalDTO.CargaId = Id;
            evaluacionPresupuestalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (evaluacionPresupuestalBL.EliminarCarga(evaluacionPresupuestalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EvaluacionPresupuestalDTO> lista = new List<EvaluacionPresupuestalDTO>();
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

                    lista.Add(new EvaluacionPresupuestalDTO
                    {
                        AnioEvaluacionPresupuesta = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoSubunidadEjecutora = fila.GetCell(2).ToString(),
                        CodigoFuenteFinanciamiento = fila.GetCell(3).ToString(),
                        ClasificacionGenericaGasto = fila.GetCell(4).ToString(),
                        ASIGPIMPresupuestal = decimal.Parse(fila.GetCell(5).ToString()),
                        PCAPresupuestal = decimal.Parse(fila.GetCell(6).ToString()),
                        CertificadoPresupuestal = decimal.Parse(fila.GetCell(7).ToString()),
                        CompromisoPresupuestal = decimal.Parse(fila.GetCell(8).ToString()),
                        DevengadoPresupuestal = decimal.Parse(fila.GetCell(9).ToString()),
                        GiradoPresupuestal = decimal.Parse(fila.GetCell(10).ToString()),
                        AvancePresupuestal = int.Parse(fila.GetCell(11).ToString()),

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
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }
            ISheet HojaExcel = MiExcel.GetSheetAt(0);
            int cantidadFilas = HojaExcel.LastRowNum;
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("AnioEvaluacionPresupuesta", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoSubunidadEjecutora", typeof(string)),
                    new DataColumn("CodigoFuenteFinanciamiento", typeof(string)),
                    new DataColumn("ClasificacionGenericaGasto", typeof(string)),
                    new DataColumn("ASIGPIMPresupuestal", typeof(decimal)),
                    new DataColumn("PCAPresupuestal", typeof(decimal)),
                    new DataColumn("CertificadoPresupuestal", typeof(decimal)),
                    new DataColumn("CompromisoPresupuestal", typeof(decimal)),
                    new DataColumn("DevengadoPresupuestal", typeof(decimal)),
                    new DataColumn("GiradoPresupuestal", typeof(decimal)),
                    new DataColumn("AvancePresupuestal", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    decimal.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = evaluacionPresupuestalBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }


        public IActionResult ReporteDEP(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Direcomar\\EvaluacionPresupuestal.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var archivoRelacionTipoReunion = evaluacionPresupuestalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EvaluacionPresupuestal", archivoRelacionTipoReunion);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }



        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirecomarEvaluacionPresupuestal.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirecomarEvaluacionPresupuestal.xlsx");
        }
    }

}
