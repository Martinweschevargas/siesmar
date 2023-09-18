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
    public class ComfasubHoraFuncionamientoPropulsionComfasubController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        HoraFuncionamientoPropulsionComfasub horaFuncionamientoPropulsionComfasubBL = new();

        UnidadNaval unidadNavalBL = new();
        SistemaPropulsion sistemaPropulsionBL = new();
        EquipoSistemaPropulsion equipoSistemaPropulsionBL = new();
        Carga cargaBL = new();

        public ComfasubHoraFuncionamientoPropulsionComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Horas Funcionamiento Motor de Propulsion", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<EquipoSistemaPropulsionDTO> equipoSistemaPropulsionDTO = equipoSistemaPropulsionBL.ObtenerEquipoSistemaPropulsions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("HoraFuncionamientoPropulsionComfasub");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = equipoSistemaPropulsionDTO,
                data3 = listaCargas

            });
        }

        public IActionResult CargaTabla()
        {
            List<HoraFuncionamientoPropulsionComfasubDTO> horaFuncionamientoPropulsionComfasubDTO = horaFuncionamientoPropulsionComfasubBL.ObtenerLista();
            return Json(new { data = horaFuncionamientoPropulsionComfasubDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            
            return View();
        }

        public ActionResult Insertar(string CodigoUnidadNaval, string FechaUltimoRecorrdio, 
            int HoraUltimoRecorrido, string CodigoEquipoSistemaPropulsion, int HoraFijadaRecorridoTotal, int HoraFijadaRecorridoParcial,  
            int HoraTotalInstalacion, int CargaId, string Fecha)
        {
            HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO = new();
            horaFuncionamientoPropulsionComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            horaFuncionamientoPropulsionComfasubDTO.CodigoEquipoSistemaPropulsion = CodigoEquipoSistemaPropulsion;
            horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoTotal = HoraFijadaRecorridoTotal;
            horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoParcial = HoraFijadaRecorridoParcial;
            horaFuncionamientoPropulsionComfasubDTO.FechaUltimoRecorrdio = FechaUltimoRecorrdio;
            horaFuncionamientoPropulsionComfasubDTO.HoraUltimoRecorrido = HoraUltimoRecorrido;
            horaFuncionamientoPropulsionComfasubDTO.HoraTotalInstalacion = HoraTotalInstalacion;
            horaFuncionamientoPropulsionComfasubDTO.CargaId = CargaId;
            horaFuncionamientoPropulsionComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = horaFuncionamientoPropulsionComfasubBL.AgregarRegistro(horaFuncionamientoPropulsionComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(horaFuncionamientoPropulsionComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int HoraFuncionamientoPropulsionComfasubId, string CodigoUnidadNaval, string FechaUltimoRecorrdio,
            int HoraUltimoRecorrido, string CodigoEquipoSistemaPropulsion, int HoraFijadaRecorridoTotal, int HoraFijadaRecorridoParcial,
            int HoraTotalInstalacion)
        {
            HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionComfasubDTO = new();
            horaFuncionamientoPropulsionComfasubDTO.HoraFuncionamientoPropulsionComfasubId = HoraFuncionamientoPropulsionComfasubId;
            horaFuncionamientoPropulsionComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            horaFuncionamientoPropulsionComfasubDTO.CodigoEquipoSistemaPropulsion = CodigoEquipoSistemaPropulsion;
            horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoTotal = HoraFijadaRecorridoTotal;
            horaFuncionamientoPropulsionComfasubDTO.HoraFijadaRecorridoParcial = HoraFijadaRecorridoParcial;
            horaFuncionamientoPropulsionComfasubDTO.FechaUltimoRecorrdio = FechaUltimoRecorrdio;
            horaFuncionamientoPropulsionComfasubDTO.HoraUltimoRecorrido = HoraUltimoRecorrido;
            horaFuncionamientoPropulsionComfasubDTO.HoraTotalInstalacion = HoraTotalInstalacion;
            horaFuncionamientoPropulsionComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = horaFuncionamientoPropulsionComfasubBL.ActualizarFormato(horaFuncionamientoPropulsionComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionDTO = new();
            horaFuncionamientoPropulsionDTO.HoraFuncionamientoPropulsionComfasubId = Id;
            horaFuncionamientoPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (horaFuncionamientoPropulsionComfasubBL.EliminarFormato(horaFuncionamientoPropulsionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            HoraFuncionamientoPropulsionComfasubDTO horaFuncionamientoPropulsionDTO = new();
            horaFuncionamientoPropulsionDTO.CargaId = Id;
            horaFuncionamientoPropulsionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (horaFuncionamientoPropulsionComfasubBL.EliminarCarga(horaFuncionamientoPropulsionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<HoraFuncionamientoPropulsionComfasubDTO> lista = new List<HoraFuncionamientoPropulsionComfasubDTO>();
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

                    lista.Add(new HoraFuncionamientoPropulsionComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoEquipoSistemaPropulsion = fila.GetCell(1).ToString(),
                        HoraFijadaRecorridoTotal = int.Parse(fila.GetCell(2).ToString()),
                        HoraFijadaRecorridoParcial = int.Parse(fila.GetCell(3).ToString()),
                        FechaUltimoRecorrdio = UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                        HoraUltimoRecorrido = int.Parse(fila.GetCell(5).ToString()),
                        HoraTotalInstalacion = int.Parse(fila.GetCell(6).ToString())
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoEquipoSistemaPropulsion", typeof(string)),
                    new DataColumn("HoraFijadaRecorridoTotal", typeof(int)),
                    new DataColumn("HoraFijadaRecorridoParcial", typeof(int)),
                    new DataColumn("FechaUltimoRecorrdio", typeof(string)),
                    new DataColumn("HoraUltimoRecorrido", typeof(int)),
                    new DataColumn("HoraTotalInstalacion", typeof(int)),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = horaFuncionamientoPropulsionComfasubBL.InsertarDatos(dt, Fecha);
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
            var Capitanias = horaFuncionamientoPropulsionComfasubBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubHoraFuncionamientoPropulsionComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubHoraFuncionamientoPropulsionComfasub.xlsx");
        }
    }

}