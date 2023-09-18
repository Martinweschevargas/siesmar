using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dipermar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DipermarDesarrolloAccionesClimaLaboralController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        DesarrolloAccionesClimaLaboral desarrolloAccionesClimaLaboralBL = new();
        ActClimaLaboralGeneral actClimaLaboralBL = new();
        ActClimaLaboralEspecifica actClimaLaboralEspecificaBL = new();
        Dependencia dependenciaBL = new();
        Carga cargaBL = new();

        public DipermarDesarrolloAccionesClimaLaboralController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Desarrollo de Acciones para Mejora de Clima Laboral del Personal Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<ActClimaLaboralGeneralDTO> actClimaLaboralGeneralDTO = actClimaLaboralBL.ObtenerActClimaLaboralGenerals();
            List<ActClimaLaboralEspecificaDTO> actClimaLaboralEspecificaDTO = actClimaLaboralEspecificaBL.ObtenerActClimaLaboralEspecificas();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DesarrolloAccionesClimaLaboral");

            return Json(new { data1 = actClimaLaboralGeneralDTO, data2 = actClimaLaboralEspecificaDTO,  data3 = dependenciaDTO ,  data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<DesarrolloAccionesClimaLaboralDTO> select = desarrolloAccionesClimaLaboralBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 623, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoActClimaLaboralGeneral, string CodigoActClimaLaboralEspecifica, string TematicaActividad,
            string LugarActividad, string FechaInicioActividad, string FechaTerminoActividad, int NroHorasActividad, 
            int NumeroPersonalSuperior, string CodigoDependencia, int NroPersonalSubalterno, int NroPersonalMarineria, int NroPersonalCivil, int CargaId, string Fecha)
        {
            DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO = new();
            desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralGeneral = CodigoActClimaLaboralGeneral;
            desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralEspecifica = CodigoActClimaLaboralEspecifica;
            desarrolloAccionesClimaLaboralDTO.TematicaActividad = TematicaActividad;
            desarrolloAccionesClimaLaboralDTO.LugarActividad = LugarActividad;
            desarrolloAccionesClimaLaboralDTO.FechaInicioActividad = FechaInicioActividad;
            desarrolloAccionesClimaLaboralDTO.FechaTerminoActividad = FechaTerminoActividad;
            desarrolloAccionesClimaLaboralDTO.NroHorasActividad = NroHorasActividad;
            desarrolloAccionesClimaLaboralDTO.NumeroPersonalSuperior = NumeroPersonalSuperior;
            desarrolloAccionesClimaLaboralDTO.CodigoDependencia = CodigoDependencia;
            desarrolloAccionesClimaLaboralDTO.NroPersonalSubalterno = NroPersonalSubalterno;
            desarrolloAccionesClimaLaboralDTO.NroPersonalMarineria = NroPersonalMarineria;
            desarrolloAccionesClimaLaboralDTO.NroPersonalCivil = NroPersonalCivil;
            desarrolloAccionesClimaLaboralDTO.CargaId = CargaId;
            desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = desarrolloAccionesClimaLaboralBL.AgregarRegistro(desarrolloAccionesClimaLaboralDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(desarrolloAccionesClimaLaboralBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 623, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoActClimaLaboralGeneral,
            string CodigoActClimaLaboralEspecifica, string TematicaActividad, string LugarActividad, string FechaInicioActividad,
            string FechaTerminoActividad, int NroHorasActividad, int NumeroPersonalSuperior, string CodigoDependencia, int NroPersonalSubalterno, 
            int NroPersonalMarineria, int NroPersonalCivil)
        {
            DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO = new();
            desarrolloAccionesClimaLaboralDTO.DesarrolloAccionClimaLaboralId = Id;
            desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralGeneral = CodigoActClimaLaboralGeneral;
            desarrolloAccionesClimaLaboralDTO.CodigoActClimaLaboralEspecifica = CodigoActClimaLaboralEspecifica;
            desarrolloAccionesClimaLaboralDTO.TematicaActividad = TematicaActividad;
            desarrolloAccionesClimaLaboralDTO.LugarActividad = LugarActividad;
            desarrolloAccionesClimaLaboralDTO.FechaInicioActividad = FechaInicioActividad;
            desarrolloAccionesClimaLaboralDTO.FechaTerminoActividad = FechaTerminoActividad;
            desarrolloAccionesClimaLaboralDTO.NroHorasActividad = NroHorasActividad;
            desarrolloAccionesClimaLaboralDTO.NumeroPersonalSuperior = NumeroPersonalSuperior;
            desarrolloAccionesClimaLaboralDTO.CodigoDependencia = CodigoDependencia;
            desarrolloAccionesClimaLaboralDTO.NroPersonalSubalterno = NroPersonalSubalterno;
            desarrolloAccionesClimaLaboralDTO.NroPersonalMarineria = NroPersonalMarineria;
            desarrolloAccionesClimaLaboralDTO.NroPersonalCivil = NroPersonalCivil;
            desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = desarrolloAccionesClimaLaboralBL.ActualizarFormato(desarrolloAccionesClimaLaboralDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 623, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO = new();
            desarrolloAccionesClimaLaboralDTO.DesarrolloAccionClimaLaboralId = Id;
            desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (desarrolloAccionesClimaLaboralBL.EliminarFormato(desarrolloAccionesClimaLaboralDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 623, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DesarrolloAccionesClimaLaboralDTO desarrolloAccionesClimaLaboralDTO = new();
            desarrolloAccionesClimaLaboralDTO.CargaId = Id;
            desarrolloAccionesClimaLaboralDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (desarrolloAccionesClimaLaboralBL.EliminarCarga(desarrolloAccionesClimaLaboralDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DesarrolloAccionesClimaLaboralDTO> lista = new List<DesarrolloAccionesClimaLaboralDTO>();
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

                    lista.Add(new DesarrolloAccionesClimaLaboralDTO
                    {
                        CodigoActClimaLaboralGeneral = fila.GetCell(0).ToString(),
                        CodigoActClimaLaboralEspecifica = fila.GetCell(1).ToString(),
                        TematicaActividad = fila.GetCell(2).ToString(),
                        LugarActividad = fila.GetCell(3).ToString(),
                        FechaInicioActividad = fila.GetCell(4).ToString(),
                        FechaTerminoActividad = fila.GetCell(5).ToString(),
                        NroHorasActividad = int.Parse(fila.GetCell(6).ToString()),
                        NumeroPersonalSuperior = int.Parse(fila.GetCell(7).ToString()),
                        CodigoDependencia = fila.GetCell(8).ToString(),
                        NroPersonalSubalterno = int.Parse(fila.GetCell(9).ToString()),
                        NroPersonalMarineria = int.Parse(fila.GetCell(10).ToString()),
                        NroPersonalCivil = int.Parse(fila.GetCell(11).ToString())

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
        //[AuthorizePermission(Formato: 623, Permiso: 4)]//Registrar Masivo
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

            dt.Columns.AddRange(new DataColumn[13]
            {
                    new DataColumn("CodigoActClimaLaboralGeneral", typeof(string)),
                    new DataColumn("CodigoActClimaLaboralEspecifica", typeof(string)),
                    new DataColumn("TematicaActividad", typeof(string)),
                    new DataColumn("LugarActividad", typeof(string)),
                    new DataColumn("FechaInicioActividad", typeof(string)),
                    new DataColumn("FechaTerminoActividad", typeof(string)),
                    new DataColumn("NroHorasActividad", typeof(int)),
                    new DataColumn("NumeroPersonalSuperior", typeof(int)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("NroPersonalSubalterno", typeof(int)),
                    new DataColumn("NroPersonalMarineria", typeof(int)),
                    new DataColumn("NroPersonalCivil", typeof(int)),
 
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = desarrolloAccionesClimaLaboralBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDACL(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dipermar\\DesarrolloAccionesClimaLaboral.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var desarrolloAccionesClimaLaboral = desarrolloAccionesClimaLaboralBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DesarrolloAccionesClimaLaboral", desarrolloAccionesClimaLaboral);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DipermarDesarrolloAccionesClimaLaboral.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DipermarDesarrolloAccionesClimaLaboral.xlsx");
        }

    }

}

