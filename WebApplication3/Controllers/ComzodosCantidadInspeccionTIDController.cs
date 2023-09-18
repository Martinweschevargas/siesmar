using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzodos;
using Marina.Siesmar.LogicaNegocios.Formatos.Dircapen;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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
    public class ComzodosCantidadInspeccionTIDController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        CantidadInspeccionTID cantidadInspeccionTIDBL = new();
        ZonaNaval zonaNavalBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public ComzodosCantidadInspeccionTIDController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Cantidad de Inspecciones TID", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CantidadInspeccionTID");

            return Json(new
            {
                data1 = zonaNavalDTO,
                data2 = distritoUbigeoDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<CantidadInspeccionTIDDTO> cantidadInspeccionTIDDTO = cantidadInspeccionTIDBL.ObtenerLista();
            return Json(new { data = cantidadInspeccionTIDDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        [AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar(string FechaSolicitud, string CodigoZonaNaval, string DistritoUbigeo,
            string FechaHoraInicio, string FechaHoraTermino, int EfectivoParticipante, 
            int EfectivoUnidadCanina, string ObservacionInspeccionTID, int ComisionPorMes, int CargaId, string Fecha)
        {
            CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO = new();
            cantidadInspeccionTIDDTO.FechaSolicitud = FechaSolicitud;
            cantidadInspeccionTIDDTO.CodigoZonaNaval = CodigoZonaNaval;
            cantidadInspeccionTIDDTO.DistritoUbigeo = DistritoUbigeo;
            cantidadInspeccionTIDDTO.FechaHoraInicio = FechaHoraInicio;
            cantidadInspeccionTIDDTO.FechaHoraTermino = FechaHoraTermino;
            cantidadInspeccionTIDDTO.EfectivoParticipante = EfectivoParticipante;
            cantidadInspeccionTIDDTO.EfectivoUnidadCanina = EfectivoUnidadCanina;
            cantidadInspeccionTIDDTO.ObservacionInspeccionTID = ObservacionInspeccionTID;
            cantidadInspeccionTIDDTO.ComisionPorMes = ComisionPorMes;
            cantidadInspeccionTIDDTO.CargaId = CargaId;
            cantidadInspeccionTIDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cantidadInspeccionTIDBL.AgregarRegistro(cantidadInspeccionTIDDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(cantidadInspeccionTIDBL.BuscarFormato(Id));
        }

        [AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int CantidadInspeccionTIDId, string CodigoZonaNaval, int EfectivoParticipante,
            string FechaSolicitud, string FechaHoraInicio, string ObservacionInspeccionTID, string DistritoUbigeo,
            string FechaHoraTermino, int EfectivoUnidadCanina, int ComisionPorMes)
        {
            CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO = new();
            cantidadInspeccionTIDDTO.CantidadInspeccionTIDId = CantidadInspeccionTIDId;
            cantidadInspeccionTIDDTO.FechaSolicitud = FechaSolicitud;
            cantidadInspeccionTIDDTO.CodigoZonaNaval = CodigoZonaNaval;
            cantidadInspeccionTIDDTO.DistritoUbigeo = DistritoUbigeo;
            cantidadInspeccionTIDDTO.FechaHoraInicio = FechaHoraInicio;
            cantidadInspeccionTIDDTO.FechaHoraTermino = FechaHoraTermino;
            cantidadInspeccionTIDDTO.EfectivoParticipante = EfectivoParticipante;
            cantidadInspeccionTIDDTO.EfectivoUnidadCanina = EfectivoUnidadCanina;
            cantidadInspeccionTIDDTO.ObservacionInspeccionTID = ObservacionInspeccionTID;
            cantidadInspeccionTIDDTO.ComisionPorMes = ComisionPorMes;
            cantidadInspeccionTIDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cantidadInspeccionTIDBL.ActualizarFormato(cantidadInspeccionTIDDTO);

            return Content(IND_OPERACION);
        }

        [AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO = new();
            cantidadInspeccionTIDDTO.CantidadInspeccionTIDId = Id;
            cantidadInspeccionTIDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (cantidadInspeccionTIDBL.EliminarFormato(cantidadInspeccionTIDDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            CantidadInspeccionTIDDTO cantidadInspeccionTIDDTO = new();
            cantidadInspeccionTIDDTO.CargaId = Id;
            cantidadInspeccionTIDDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (cantidadInspeccionTIDBL.EliminarCarga(cantidadInspeccionTIDDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CantidadInspeccionTIDDTO> lista = new List<CantidadInspeccionTIDDTO>();
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

                    lista.Add(new CantidadInspeccionTIDDTO
                    {
                        FechaSolicitud = fila.GetCell(0).ToString(),
                        CodigoZonaNaval = fila.GetCell(1).ToString(),
                        DistritoUbigeo = fila.GetCell(2).ToString(),
                        FechaHoraInicio = fila.GetCell(3).ToString(),
                        FechaHoraTermino = fila.GetCell(4).ToString(),
                        EfectivoParticipante = int.Parse(fila.GetCell(5).ToString()),
                        EfectivoUnidadCanina = int.Parse(fila.GetCell(6).ToString()),
                        ObservacionInspeccionTID = fila.GetCell(7).ToString(),
                        ComisionPorMes = int.Parse(fila.GetCell(8).ToString()),
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
        [AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
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
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("FechaHoraInicio", typeof(string)),
                    new DataColumn("FechaHoraTermino", typeof(string)),
                    new DataColumn("EfectivoParticipante", typeof(int)),
                    new DataColumn("EfectivoUnidadCanina", typeof(int)),
                    new DataColumn("ObservacionInspeccionTID", typeof(string)),
                    new DataColumn("ComisionPorMes", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(3).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = cantidadInspeccionTIDBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDIDCN(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comzodos\\CantidadInspeccionTID.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = cantidadInspeccionTIDBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("IngresoDatoCapacitacionNaval", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzodosCantidadInspeccionTID.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzodosCantidadInspeccionTID.xlsx");
        }

    }
}