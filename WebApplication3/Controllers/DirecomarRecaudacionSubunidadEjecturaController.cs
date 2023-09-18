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

    public class DirecomarRecaudacionSubunidadEjecturaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        RecaudacionSubunidadEjectura recaudacionSubunidadEjecturaBL = new();
        Mes mesBL = new();
        SubUnidadEjecutora subUnidadEjecutoraBL = new();
        Carga cargaBL = new();

        public DirecomarRecaudacionSubunidadEjecturaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Recaudación por Sub Unidad Ejecutora", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> MesDTO = mesBL.ObtenerMess();
            List<SubUnidadEjecutoraDTO> SubUnidadEjecutoraDTO = subUnidadEjecutoraBL.ObtenerSubUnidadEjecutoras();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RecaudacionSubunidadEjectura");

            return Json(new { data1 = MesDTO, data2 = SubUnidadEjecutoraDTO, data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<RecaudacionSubunidadEjecturaDTO> select = recaudacionSubunidadEjecturaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int AnioRecaudacionSUE, string NumeroMes, string CodigoSubunidadEjecutora, decimal ProyeccionRecaudacionSUE,
            decimal RecaudadoRecaudacionSUE, int MetaRecaudacionSUE, int CargaId, string Fecha)
        {
            RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO = new();
            recaudacionSubunidadEjecturaDTO.AnioRecaudacionSUE = AnioRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.NumeroMes = NumeroMes;
            recaudacionSubunidadEjecturaDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            recaudacionSubunidadEjecturaDTO.ProyeccionRecaudacionSUE = ProyeccionRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.RecaudadoRecaudacionSUE = RecaudadoRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.MetaRecaudacionSUE = MetaRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.CargaId = CargaId;
            recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = recaudacionSubunidadEjecturaBL.AgregarRegistro(recaudacionSubunidadEjecturaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(recaudacionSubunidadEjecturaBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioRecaudacionSUE, string NumeroMes, string CodigoSubunidadEjecutora, decimal ProyeccionRecaudacionSUE,
            decimal RecaudadoRecaudacionSUE, int MetaRecaudacionSUE)
        {
            RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO = new();
            recaudacionSubunidadEjecturaDTO.RecaudacionSubunidadEjecturaId = Id;
            recaudacionSubunidadEjecturaDTO.AnioRecaudacionSUE = AnioRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.NumeroMes = NumeroMes;
            recaudacionSubunidadEjecturaDTO.CodigoSubunidadEjecutora = CodigoSubunidadEjecutora;
            recaudacionSubunidadEjecturaDTO.ProyeccionRecaudacionSUE = ProyeccionRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.RecaudadoRecaudacionSUE = RecaudadoRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.MetaRecaudacionSUE = MetaRecaudacionSUE;
            recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = recaudacionSubunidadEjecturaBL.ActualizarFormato(recaudacionSubunidadEjecturaDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO = new();
            recaudacionSubunidadEjecturaDTO.RecaudacionSubunidadEjecturaId = Id;
            recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (recaudacionSubunidadEjecturaBL.EliminarFormato(recaudacionSubunidadEjecturaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RecaudacionSubunidadEjecturaDTO recaudacionSubunidadEjecturaDTO = new();
            recaudacionSubunidadEjecturaDTO.CargaId = Id;
            recaudacionSubunidadEjecturaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (recaudacionSubunidadEjecturaBL.EliminarCarga(recaudacionSubunidadEjecturaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RecaudacionSubunidadEjecturaDTO> lista = new List<RecaudacionSubunidadEjecturaDTO>();
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

                    lista.Add(new RecaudacionSubunidadEjecturaDTO
                    {
                        AnioRecaudacionSUE = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoSubunidadEjecutora = fila.GetCell(2).ToString(),
                        ProyeccionRecaudacionSUE = decimal.Parse(fila.GetCell(3).ToString()),
                        RecaudadoRecaudacionSUE = decimal.Parse(fila.GetCell(4).ToString()),
                        MetaRecaudacionSUE = int.Parse(fila.GetCell(5).ToString()),
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("AnioRecaudacionSUE", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoSubunidadEjecutora", typeof(string)),
                    new DataColumn("ProyeccionRecaudacionSUE", typeof(decimal)),
                    new DataColumn("RecaudadoRecaudacionSUE", typeof(decimal)),
                    new DataColumn("MetaRecaudacionSUE", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = recaudacionSubunidadEjecturaBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteRSE(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Direcomar\\RecaudacionSubunidadEjectura.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var recaudacionSubunidadEjectura = recaudacionSubunidadEjecturaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("RecaudacionSubunidadEjectura", recaudacionSubunidadEjectura);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirecomarRecaudacionSubunidadEjectura.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirecomarRecaudacionSubunidadEjectura.xlsx");
        }
    }

}