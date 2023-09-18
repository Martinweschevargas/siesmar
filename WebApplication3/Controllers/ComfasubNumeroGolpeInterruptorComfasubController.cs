using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfasub;
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
    public class ComfasubNumeroGolpeInterruptorComfasubController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        NumeroGolpeInterruptorComfasub numeroGolpeInterruptorComfasubBL = new();
        UnidadNaval unidadNavalBL = new();
        EquipoSistemaPropulsion equipoSistemaPropulsionBL = new();
        Carga cargaBL = new();

        public ComfasubNumeroGolpeInterruptorComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Número de Golpes de Interruptores Principales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<EquipoSistemaPropulsionDTO> equipoSistemaPropulsionDTO = equipoSistemaPropulsionBL.ObtenerEquipoSistemaPropulsions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("NumeroGolpeInterruptorComfasub");
            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = equipoSistemaPropulsionDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<NumeroGolpeInterruptorComfasubDTO> numeroGolpeInterruptorComfasubDTO = numeroGolpeInterruptorComfasubBL.ObtenerLista();
            return Json(new { data = numeroGolpeInterruptorComfasubDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoUnidadNaval, int GolpeFijadoRecorridoParcial, string CodigoEquipoSistemaPropulsion, int GolpeUltimoRecorrido, int GolpeTotalInstalacion,  
            int GolpeFijadoRecorridoTotal, int CargaId, string Fecha)
        {
            NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO = new();
            numeroGolpeInterruptorComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            numeroGolpeInterruptorComfasubDTO.CodigoEquipoSistemaPropulsion = CodigoEquipoSistemaPropulsion;
            numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoTotal = GolpeFijadoRecorridoTotal;
            numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoParcial = GolpeFijadoRecorridoParcial;
            numeroGolpeInterruptorComfasubDTO.GolpeUltimoRecorrido = GolpeUltimoRecorrido;
            numeroGolpeInterruptorComfasubDTO.GolpeTotalInstalacion = GolpeTotalInstalacion;
            numeroGolpeInterruptorComfasubDTO.CargaId = CargaId;
            numeroGolpeInterruptorComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = numeroGolpeInterruptorComfasubBL.AgregarRegistro(numeroGolpeInterruptorComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(numeroGolpeInterruptorComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int NumeroGolpeInterruptorComfasubId, string CodigoUnidadNaval, int GolpeFijadoRecorridoParcial, string CodigoEquipoSistemaPropulsion, int GolpeUltimoRecorrido, int GolpeTotalInstalacion,
            int GolpeFijadoRecorridoTotal)
        {
            NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorComfasubDTO = new();
            numeroGolpeInterruptorComfasubDTO.NumeroGolpeInterruptorComfasubId = NumeroGolpeInterruptorComfasubId;
            numeroGolpeInterruptorComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            numeroGolpeInterruptorComfasubDTO.CodigoEquipoSistemaPropulsion = CodigoEquipoSistemaPropulsion;
            numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoTotal = GolpeFijadoRecorridoTotal;
            numeroGolpeInterruptorComfasubDTO.GolpeFijadoRecorridoParcial = GolpeFijadoRecorridoParcial;
            numeroGolpeInterruptorComfasubDTO.GolpeUltimoRecorrido = GolpeUltimoRecorrido;
            numeroGolpeInterruptorComfasubDTO.GolpeTotalInstalacion = GolpeTotalInstalacion;
            numeroGolpeInterruptorComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = numeroGolpeInterruptorComfasubBL.ActualizarFormato(numeroGolpeInterruptorComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorDTO = new();
            numeroGolpeInterruptorDTO.NumeroGolpeInterruptorComfasubId = Id;
            numeroGolpeInterruptorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (numeroGolpeInterruptorComfasubBL.EliminarFormato(numeroGolpeInterruptorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            NumeroGolpeInterruptorComfasubDTO numeroGolpeInterruptorDTO = new();
            numeroGolpeInterruptorDTO.CargaId = Id;
            numeroGolpeInterruptorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (numeroGolpeInterruptorComfasubBL.EliminarCarga(numeroGolpeInterruptorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<NumeroGolpeInterruptorComfasubDTO> lista = new List<NumeroGolpeInterruptorComfasubDTO>();
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

                    lista.Add(new NumeroGolpeInterruptorComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoEquipoSistemaPropulsion = fila.GetCell(1).ToString(),
                        GolpeFijadoRecorridoTotal = int.Parse(fila.GetCell(2).ToString()),
                        GolpeFijadoRecorridoParcial = int.Parse(fila.GetCell(3).ToString()),
                        GolpeUltimoRecorrido = int.Parse(fila.GetCell(4).ToString()),
                        GolpeTotalInstalacion = int.Parse(fila.GetCell(5).ToString()),

                    });
                }
            }
            catch (Exception)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoEquipoSistemaPropulsion", typeof(string)),
                    new DataColumn("GolpeFijadoRecorridoTotal", typeof(int)),
                    new DataColumn("GolpeFijadoRecorridoParcial", typeof(int)),
                    new DataColumn("GolpeUltimoRecorrido", typeof(int)),
                    new DataColumn("GolpeTotalInstalacion", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = numeroGolpeInterruptorComfasubBL.InsertarDatos(dt, Fecha);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = numeroGolpeInterruptorComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubNumeroGolpeInterruptorComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubNumeroGolpeInterruptorComfasub.xlsx");
        }
    }

}