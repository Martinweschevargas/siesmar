using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavActividadDptoCartografiaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ActividadDptoCartografia actividadDptoCartografiaBL = new();
        TipoCarta tipoCartaBL = new();
        Carga cargaBL = new();

        public DihidronavActividadDptoCartografiaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Actividades del Departamento de Cartografía", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoCartaDTO> tipoCartaDTO = tipoCartaBL.ObtenerTipoCartas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ActividadDptoCartografia");


            return Json(new
            {
                data1 = tipoCartaDTO,
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ActividadDptoCartografiaDTO> actividadDptoCartografiaDTO = actividadDptoCartografiaBL.ObtenerLista();
            return Json(new { data = actividadDptoCartografiaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string Requerimiento, string CodigoTipoCarta, string Proceso, string Clasificacion, 
            string CodigoNombre, string Edicion, int Escala, int SituacionPorcentaje, string FechaAutorizacionProduccion, 
            string FechaTerminoCarta, int CargaId)
        {
            ActividadDptoCartografiaDTO actividadDptoCartografiaDTO = new();
            actividadDptoCartografiaDTO.NumeroOrden = NumeroOrden;
            actividadDptoCartografiaDTO.Requerimiento = Requerimiento;
            actividadDptoCartografiaDTO.CodigoTipoCarta = CodigoTipoCarta;
            actividadDptoCartografiaDTO.Proceso = Proceso;
            actividadDptoCartografiaDTO.Clasificacion = Clasificacion;
            actividadDptoCartografiaDTO.CodigoNombre = CodigoNombre;
            actividadDptoCartografiaDTO.Edicion = Edicion;
            actividadDptoCartografiaDTO.Escala = Escala;
            actividadDptoCartografiaDTO.SituacionPorcentaje = SituacionPorcentaje;
            actividadDptoCartografiaDTO.FechaAutorizacionProduccion = FechaAutorizacionProduccion;
            actividadDptoCartografiaDTO.FechaTerminoCarta = FechaTerminoCarta;
            actividadDptoCartografiaDTO.CargaId = CargaId;
            actividadDptoCartografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadDptoCartografiaBL.AgregarRegistro(actividadDptoCartografiaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividadDptoCartografiaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ActividadDptoCartografiaId, int NumeroOrden, string Requerimiento, string CodigoTipoCarta, string Proceso, string Clasificacion,
            string CodigoNombre, string Edicion, int Escala, int SituacionPorcentaje, string FechaAutorizacionProduccion,
            string FechaTerminoCarta)
        {
            ActividadDptoCartografiaDTO actividadDptoCartografiaDTO = new();
            actividadDptoCartografiaDTO.ActividadDptoCartografiaId = ActividadDptoCartografiaId;
            actividadDptoCartografiaDTO.NumeroOrden = NumeroOrden;
            actividadDptoCartografiaDTO.Requerimiento = Requerimiento;
            actividadDptoCartografiaDTO.CodigoTipoCarta = CodigoTipoCarta;
            actividadDptoCartografiaDTO.Proceso = Proceso;
            actividadDptoCartografiaDTO.Clasificacion = Clasificacion;
            actividadDptoCartografiaDTO.CodigoNombre = CodigoNombre;
            actividadDptoCartografiaDTO.Edicion = Edicion;
            actividadDptoCartografiaDTO.Escala = Escala;
            actividadDptoCartografiaDTO.SituacionPorcentaje = SituacionPorcentaje;
            actividadDptoCartografiaDTO.FechaAutorizacionProduccion = FechaAutorizacionProduccion;
            actividadDptoCartografiaDTO.FechaTerminoCarta = FechaTerminoCarta;
            actividadDptoCartografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadDptoCartografiaBL.ActualizarFormato(actividadDptoCartografiaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ActividadDptoCartografiaDTO actividadDptoCartografiaDTO = new();
            actividadDptoCartografiaDTO.ActividadDptoCartografiaId = Id;
            actividadDptoCartografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actividadDptoCartografiaBL.EliminarFormato(actividadDptoCartografiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ActividadDptoCartografiaDTO> lista = new List<ActividadDptoCartografiaDTO>();
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

                    lista.Add(new ActividadDptoCartografiaDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        Requerimiento = fila.GetCell(1).ToString(),
                        CodigoTipoCarta = fila.GetCell(2).ToString(),
                        Proceso = fila.GetCell(3).ToString(),
                        Clasificacion = fila.GetCell(4).ToString(),
                        CodigoNombre = fila.GetCell(5).ToString(),
                        Edicion = fila.GetCell(6).ToString(),
                        Escala = int.Parse(fila.GetCell(7).ToString()),
                        SituacionPorcentaje = int.Parse(fila.GetCell(8).ToString()),
                        FechaAutorizacionProduccion = fila.GetCell(9).ToString(),
                        FechaTerminoCarta = fila.GetCell(10).ToString()
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                        new DataColumn("NumeroOrden", typeof(int)),
                        new DataColumn("Requerimiento", typeof(string)),
                        new DataColumn("CodigoTipoCarta", typeof(string)),
                        new DataColumn("Proceso", typeof(string)),
                        new DataColumn("Clasificacion", typeof(string)),
                        new DataColumn("CodigoNombre", typeof(string)),
                        new DataColumn("Edicion", typeof(string)),
                        new DataColumn("Escala", typeof(int)),
                        new DataColumn("SituacionPorcentaje", typeof(int)),
                        new DataColumn("FechaAutorizacionProduccion", typeof(string)),
                        new DataColumn("FechaTerminoCarta", typeof(string)),

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
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = actividadDptoCartografiaBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavActividadDptoCartografia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavActividadDptoCartografia.xlsx");
        }
    }

}