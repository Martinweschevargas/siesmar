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
    public class DiabasteConsumoRacionUnidadDependenciaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ConsumoRacionUnidadDependencia consumoRacionUnidadDependenciaBL = new();
        Mes mesBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        TipoRacion tipoRacionBL = new();
        Carga cargaBL = new();
        public DiabasteConsumoRacionUnidadDependenciaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Consumo de Raciones de las Unidades y Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<TipoRacionDTO> tipoRacionDTO = tipoRacionBL.ObtenerTipoRacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ConsumoRacionUnidadDependencia");
            return Json(new
            {
                data1 = mesDTO,
                data2 = areaDiperadmonDTO,
                data3 = tipoRacionDTO,
                data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ConsumoRacionUnidadDependenciaDTO> consumoRacionUnidadDependenciaDTO = consumoRacionUnidadDependenciaBL.ObtenerLista();
            return Json(new { data = consumoRacionUnidadDependenciaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(int Anio, string CodigoAreaDiperadmon, string NumeroMes, 
            string CodigoTipoRacion, int NumeroRacionRequerida, int NumeroRacionConsumida, 
            int NumeroPersonalSuperior, int NumeroPersonaSubalterno, int NumeroPersonalMineria,
            int NumeroPersonalCadete, int CargaId, string Fecha)
        {
            ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO = new();
            consumoRacionUnidadDependenciaDTO.Anio = Anio;
            consumoRacionUnidadDependenciaDTO.NumeroMes = NumeroMes;
            consumoRacionUnidadDependenciaDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            consumoRacionUnidadDependenciaDTO.CodigoTipoRacion = CodigoTipoRacion;
            consumoRacionUnidadDependenciaDTO.NumeroRacionRequerida = NumeroRacionRequerida;
            consumoRacionUnidadDependenciaDTO.NumeroRacionConsumida = NumeroRacionConsumida;
            consumoRacionUnidadDependenciaDTO.NumeroPersonalSuperior = NumeroPersonalSuperior;
            consumoRacionUnidadDependenciaDTO.NumeroPersonaSubalterno = NumeroPersonaSubalterno;
            consumoRacionUnidadDependenciaDTO.NumeroPersonalMineria = NumeroPersonalMineria;
            consumoRacionUnidadDependenciaDTO.NumeroPersonalCadete = NumeroPersonalCadete;
            consumoRacionUnidadDependenciaDTO.CargaId = CargaId;
            consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consumoRacionUnidadDependenciaBL.AgregarRegistro(consumoRacionUnidadDependenciaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(consumoRacionUnidadDependenciaBL.EditarFormado(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int ConsumoRacionUnidadDependenciaId, int Anio, 
            string CodigoAreaDiperadmon, string NumeroMes, string CodigoTipoRacion, 
            int NumeroRacionRequerida, int NumeroRacionConsumida, int NumeroPersonalSuperior, 
            int NumeroPersonaSubalterno, int NumeroPersonalMineria,  int NumeroPersonalCadete)
        {
            ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO = new();
            consumoRacionUnidadDependenciaDTO.ConsumoRacionUnidadDependenciaId = ConsumoRacionUnidadDependenciaId;
            consumoRacionUnidadDependenciaDTO.Anio = Anio;
            consumoRacionUnidadDependenciaDTO.NumeroMes = NumeroMes;
            consumoRacionUnidadDependenciaDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            consumoRacionUnidadDependenciaDTO.CodigoTipoRacion = CodigoTipoRacion;
            consumoRacionUnidadDependenciaDTO.NumeroRacionRequerida = NumeroRacionRequerida;
            consumoRacionUnidadDependenciaDTO.NumeroRacionConsumida = NumeroRacionConsumida;
            consumoRacionUnidadDependenciaDTO.NumeroPersonalSuperior = NumeroPersonalSuperior;
            consumoRacionUnidadDependenciaDTO.NumeroPersonaSubalterno = NumeroPersonaSubalterno;
            consumoRacionUnidadDependenciaDTO.NumeroPersonalMineria = NumeroPersonalMineria;
            consumoRacionUnidadDependenciaDTO.NumeroPersonalCadete = NumeroPersonalCadete;
            consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consumoRacionUnidadDependenciaBL.ActualizarFormato(consumoRacionUnidadDependenciaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO = new();
            consumoRacionUnidadDependenciaDTO.ConsumoRacionUnidadDependenciaId = Id;
            consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (consumoRacionUnidadDependenciaBL.EliminarFormato(consumoRacionUnidadDependenciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ConsumoRacionUnidadDependenciaDTO consumoRacionUnidadDependenciaDTO = new();
            consumoRacionUnidadDependenciaDTO.CargaId = Id;
            consumoRacionUnidadDependenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (consumoRacionUnidadDependenciaBL.EliminarCarga(consumoRacionUnidadDependenciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<ConsumoRacionUnidadDependenciaDTO> lista = new List<ConsumoRacionUnidadDependenciaDTO>();
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

                    lista.Add(new ConsumoRacionUnidadDependenciaDTO
                    {
                        Anio = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(2).ToString(),
                        CodigoTipoRacion = fila.GetCell(3).ToString(),
                        NumeroRacionRequerida = int.Parse(fila.GetCell(4).ToString()),
                        NumeroRacionConsumida = int.Parse(fila.GetCell(5).ToString()),
                        NumeroPersonalSuperior = int.Parse(fila.GetCell(6).ToString()),
                        NumeroPersonaSubalterno = int.Parse(fila.GetCell(7).ToString()),
                        NumeroPersonalMineria = int.Parse(fila.GetCell(8).ToString()),
                        NumeroPersonalCadete = int.Parse(fila.GetCell(9).ToString())
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("Anio", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoTipoRacion", typeof(string)),
                    new DataColumn("NumeroRacionRequerida", typeof(int)),
                    new DataColumn("NumeroRacionConsumida", typeof(int)),
                    new DataColumn("NumeroPersonalSuperior", typeof(int)),
                    new DataColumn("NumeroPersonaSubalterno", typeof(int)),
                    new DataColumn("NumeroPersonalMineria", typeof(int)),
                    new DataColumn("NumeroPersonalCadete", typeof(int)),
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
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = consumoRacionUnidadDependenciaBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiabasteConsumoRacionUnidadDependencia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiabasteConsumoRacionUnidadDependencia.xlsx");
        }

    }

}