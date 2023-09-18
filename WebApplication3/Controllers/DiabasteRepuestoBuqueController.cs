using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diabaste;
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
    public class DiabasteRepuestoBuqueController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        RepuestoBuque repuestoBuqueBL = new();
        Mes mesBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        Condicion condicionBL = new();
        Carga cargaBL = new();

        public DiabasteRepuestoBuqueController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Repuestos para Buques (REBA)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess(); 
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions(); 
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RepuestoBuque");
            return Json(new
            {
                data1 = mesDTO,
                data2 = areaDiperadmonDTO,
                data3 = condicionDTO,
                data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<RepuestoBuqueDTO> repuestoBuqueDTO = repuestoBuqueBL.ObtenerLista();
            return Json(new { data = repuestoBuqueDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int Anio, string CodigoAreaDiperadmon, string NumeroMes, 
            int CantidadProducto, int TiempoCustodiaDia, string NombreProducto, string CodigoCondicion,
            string FechaIngreso, string FechaSalida, int CargaId, string Fecha)
        {
            RepuestoBuqueDTO repuestoBuqueDTO = new();
            repuestoBuqueDTO.Anio = Anio;
            repuestoBuqueDTO.NumeroMes = NumeroMes;
            repuestoBuqueDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            repuestoBuqueDTO.CodigoCondicion = CodigoCondicion;
            repuestoBuqueDTO.NombreProducto = NombreProducto;
            repuestoBuqueDTO.CantidadProducto = CantidadProducto;
            repuestoBuqueDTO.FechaIngreso = FechaIngreso;
            repuestoBuqueDTO.FechaSalida = FechaSalida;
            repuestoBuqueDTO.TiempoCustodiaDia = TiempoCustodiaDia;
            repuestoBuqueDTO.CargaId = CargaId;
            repuestoBuqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = repuestoBuqueBL.AgregarRegistro(repuestoBuqueDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(repuestoBuqueBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int Anio, string CodigoAreaDiperadmon, 
            string NumeroMes, int CantidadProducto, int TiempoCustodiaDia, string NombreProducto, 
            string CodigoCondicion, string FechaIngreso, string FechaSalida)
        {
            RepuestoBuqueDTO repuestoBuqueDTO = new();
            repuestoBuqueDTO.RepuestoBuqueId = Id;
            repuestoBuqueDTO.Anio = Anio;
            repuestoBuqueDTO.NumeroMes = NumeroMes;
            repuestoBuqueDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            repuestoBuqueDTO.CodigoCondicion = CodigoCondicion;
            repuestoBuqueDTO.NombreProducto = NombreProducto;
            repuestoBuqueDTO.CantidadProducto = CantidadProducto;
            repuestoBuqueDTO.FechaIngreso = FechaIngreso;
            repuestoBuqueDTO.FechaSalida = FechaSalida;
            repuestoBuqueDTO.TiempoCustodiaDia = TiempoCustodiaDia;
            repuestoBuqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = repuestoBuqueBL.ActualizarFormato(repuestoBuqueDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RepuestoBuqueDTO repuestoBuqueDTO = new();
            repuestoBuqueDTO.RepuestoBuqueId = Id;
            repuestoBuqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (repuestoBuqueBL.EliminarFormato(repuestoBuqueDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RepuestoBuqueDTO repuestoBuqueDTO = new();
            repuestoBuqueDTO.CargaId = Id;
            repuestoBuqueDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (repuestoBuqueBL.EliminarCarga(repuestoBuqueDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RepuestoBuqueDTO> lista = new List<RepuestoBuqueDTO>();
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

                    lista.Add(new RepuestoBuqueDTO
                    {
                        Anio = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(2).ToString(),
                        CodigoCondicion = fila.GetCell(3).ToString(),
                        NombreProducto = fila.GetCell(4).ToString(),
                        CantidadProducto = int.Parse(fila.GetCell(5).ToString()),
                        FechaIngreso = UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                        FechaSalida = UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                        TiempoCustodiaDia = int.Parse(fila.GetCell(8).ToString())
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
                    new DataColumn("Anio", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoCondicion", typeof(string)),
                    new DataColumn("NombreProducto", typeof(string)),
                    new DataColumn("CantidadProducto", typeof(int)),
                    new DataColumn("FechaIngreso", typeof(string)),
                    new DataColumn("FechaSalida", typeof(string)),
                    new DataColumn("TiempoCustodiaDia", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario()
                    );
            }
            var IND_OPERACION = repuestoBuqueBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiabasteRepuestoBuque.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiabasteRepuestoBuque.xlsx");
        }

    }

}