using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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

    public class DintemarEstudioSeguridadInfraestructuraController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EstudioSeguridadInfraestructuraDAO estudioSeguridadInfraestructuraBL = new();

        MesDAO meaBL = new();
        ZonaNavalDAO zonaNavalBL = new();
        Carga cargaBL = new();

        public DintemarEstudioSeguridadInfraestructuraController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Estudios de Seguridad de Instalaciones y/o Infraestructuras Vigentes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = meaBL.ObtenerMess();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EstudioSeguridadInfraestructura");


            return Json(new { data1 = mesDTO, data2 = zonaNavalDTO, data3= listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EstudioSeguridadInfraestructuraDTO> select = estudioSeguridadInfraestructuraBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string numeroMes, int AnioEstudio, string CodigoZonaNaval,
           int EstudioSeguridadInfraestructura, int PorcentajeAvanceEstudio, int CargaId, string fecha)
        {
            EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO = new();
            estudioSeguridadInfraestructuraDTO.NumeroMes = numeroMes;
            estudioSeguridadInfraestructuraDTO.AnioEstudio = AnioEstudio;
            estudioSeguridadInfraestructuraDTO.CodigoZonaNaval = CodigoZonaNaval;
            estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructura = EstudioSeguridadInfraestructura;
            estudioSeguridadInfraestructuraDTO.PorcentajeAvanceEstudio = PorcentajeAvanceEstudio;
            estudioSeguridadInfraestructuraDTO.CargaId = CargaId;
            estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            estudioSeguridadInfraestructuraDTO.Fecha = fecha;

            var IND_OPERACION = estudioSeguridadInfraestructuraBL.AgregarRegistro(estudioSeguridadInfraestructuraDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(estudioSeguridadInfraestructuraBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string NumeroMes, int AnioEstudio, string CodigoZonaNaval,
           int EstudioSeguridadInfraestructura, int PorcentajeAvanceEstudio)
        {
            EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO = new();
            estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructuraId = Id;
            estudioSeguridadInfraestructuraDTO.NumeroMes = NumeroMes;
            estudioSeguridadInfraestructuraDTO.AnioEstudio = AnioEstudio;
            estudioSeguridadInfraestructuraDTO.CodigoZonaNaval = CodigoZonaNaval;
            estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructura = EstudioSeguridadInfraestructura;
            estudioSeguridadInfraestructuraDTO.PorcentajeAvanceEstudio = PorcentajeAvanceEstudio;
            estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estudioSeguridadInfraestructuraBL.ActualizaFormato(estudioSeguridadInfraestructuraDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO = new();
            estudioSeguridadInfraestructuraDTO.EstudioSeguridadInfraestructuraId = Id;
            estudioSeguridadInfraestructuraDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (estudioSeguridadInfraestructuraBL.EliminarFormato(estudioSeguridadInfraestructuraDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje;
            EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO = new()
            {
                CargaId = Id,
                UsuarioIngresoRegistro = User.obtenerUsuario()
            };

            if (estudioSeguridadInfraestructuraBL.EliminarCarga(estudioSeguridadInfraestructuraDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EstudioSeguridadInfraestructuraDTO> lista = new List<EstudioSeguridadInfraestructuraDTO>();
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

                    lista.Add(new EstudioSeguridadInfraestructuraDTO
                    {
                        NumeroMes = fila.GetCell(0).ToString(),
                        AnioEstudio = int.Parse(fila.GetCell(1).ToString()),
                        CodigoZonaNaval = fila.GetCell(2).ToString(),
                        EstudioSeguridadInfraestructura = int.Parse(fila.GetCell(3).ToString()),
                        PorcentajeAvanceEstudio = int.Parse(fila.GetCell(4).ToString()),

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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("NumeroMes", typeof(int)),
                    new DataColumn("AnioEstudio", typeof(int)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("EstudioSeguridadInfraestructura", typeof(int)),
                    new DataColumn("PorcentajeAvanceEstudio", typeof(int)),


                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                   int.Parse(fila.GetCell(0).ToString()),
                   int.Parse(fila.GetCell(1).ToString()),
                   fila.GetCell(2).ToString(),
                   int.Parse(fila.GetCell(3).ToString()),
                   int.Parse(fila.GetCell(4).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = estudioSeguridadInfraestructuraBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDESI(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\EstudioSeguridadInfraestructura.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = estudioSeguridadInfraestructuraBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioSeguridadInfraestructura", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\EstudioSeguridadInfraestructura.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "EstudioSeguridadInfraestructura.xlsx");
        }
    }

}

