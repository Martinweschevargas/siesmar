using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dircapen;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DircapenIngresoDatosCapacitacionNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        IngresoDatosCapacitacionNaval ingresoDatosCapacitacionNavalBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciabl = new();
        ZonaNaval zonaNavalBL = new();
        TipoModalidad tipoModalidadBL = new();
        ProgramaEspecializacionEspecifico programaEspecializacionEspecificoBL = new();
        ProgramaEspecializacionGrupo programaEspecializacionGrupoBL = new ();
        Carga cargaBL = new();

        public DircapenIngresoDatosCapacitacionNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciabl.ObtenerDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<TipoModalidadDTO> tipoModalidadDTO = tipoModalidadBL.ObtenerTipoModalidads();
            List<ProgramaEspecializacionEspecificoDTO> programaEspecializacionEspecificoDTO = programaEspecializacionEspecificoBL.ObtenerProgramaEspecializacionEspecificos();
            List<ProgramaEspecializacionGrupoDTO> programaEspecializacionGrupoDTO = programaEspecializacionGrupoBL.ObtenerProgramaEspecializacionGrupos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("IngresoDatoCapacitacionNaval");

            return Json(new { data1 = gradoPersonalMilitarDTO, data2 = tipoPersonalMilitarDTO,  data3 = especialidadGenericaPersonalDTO,
                data4 = dependenciaDTO,data5 = zonaNavalDTO,data6 = tipoModalidadDTO, data7 = programaEspecializacionEspecificoDTO, data8 = programaEspecializacionGrupoDTO,
                data9 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<IngresoDatosCapacitacionNavalDTO> select = ingresoDatosCapacitacionNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CIPPersonal, string DNIPersonal, string SexoPersonal, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, string CodigoDependencia, string CodigoProgramaEspecializacionEspecifico, string CodigoProgramaEspecializacionGrupo,
            string CodigoEspecialidadGenericaPersonal, string CodigoZonaNaval, string FechaInicio, string FechaTemino,
            string CodigoTipoModalidad, string ConcluyoProgramaEstudios, int TotalCredito, string MotivosNoConcluir, 
            decimal CalificacionFinalObtenida, string NombreDiploma, int CargaId, string Fecha)
        {
            IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO = new();
            ingresoDatosCapacitacionNavalDTO.CIPPersonal = CIPPersonal;
            ingresoDatosCapacitacionNavalDTO.DNIPersonal = DNIPersonal;
            ingresoDatosCapacitacionNavalDTO.SexoPersonal = SexoPersonal;
            ingresoDatosCapacitacionNavalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            ingresoDatosCapacitacionNavalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ingresoDatosCapacitacionNavalDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            ingresoDatosCapacitacionNavalDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatosCapacitacionNavalDTO.CodigoZonaNaval = CodigoZonaNaval;
            ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionEspecifico = CodigoProgramaEspecializacionEspecifico;
            ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionGrupo = CodigoProgramaEspecializacionGrupo;
            ingresoDatosCapacitacionNavalDTO.FechaInicio = FechaInicio;
            ingresoDatosCapacitacionNavalDTO.FechaTemino = FechaTemino;
            ingresoDatosCapacitacionNavalDTO.CodigoTipoModalidad = CodigoTipoModalidad;
            ingresoDatosCapacitacionNavalDTO.ConcluyoProgramaEstudios = ConcluyoProgramaEstudios;
            ingresoDatosCapacitacionNavalDTO.TotalCredito = TotalCredito;
            ingresoDatosCapacitacionNavalDTO.MotivosNoConcluir = MotivosNoConcluir;
            ingresoDatosCapacitacionNavalDTO.CalificacionFinalObtenida = CalificacionFinalObtenida;
            ingresoDatosCapacitacionNavalDTO.NombreDiploma = NombreDiploma;
            ingresoDatosCapacitacionNavalDTO.CargaId = CargaId;
            ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatosCapacitacionNavalBL.AgregarRegistro(ingresoDatosCapacitacionNavalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ingresoDatosCapacitacionNavalBL.EditarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CIPPersonal, string DNIPersonal, string SexoPersonal, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, string CodigoDependencia, string CodigoProgramaEspecializacionEspecifico, string CodigoProgramaEspecializacionGrupo,
            string CodigoEspecialidadGenericaPersonal, string CodigoZonaNaval, string FechaInicio, string FechaTemino,
            string CodigoTipoModalidad, string ConcluyoProgramaEstudios, int TotalCredito, string MotivosNoConcluir,
            decimal CalificacionFinalObtenida, string NombreDiploma)
        {
            IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO = new();
            ingresoDatosCapacitacionNavalDTO.IngresoDatoCapacitacionNavalId = Id;
            ingresoDatosCapacitacionNavalDTO.CIPPersonal = CIPPersonal;
            ingresoDatosCapacitacionNavalDTO.DNIPersonal = DNIPersonal;
            ingresoDatosCapacitacionNavalDTO.SexoPersonal = SexoPersonal;
            ingresoDatosCapacitacionNavalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            ingresoDatosCapacitacionNavalDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ingresoDatosCapacitacionNavalDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            ingresoDatosCapacitacionNavalDTO.CodigoDependencia = CodigoDependencia;
            ingresoDatosCapacitacionNavalDTO.CodigoZonaNaval = CodigoZonaNaval;
            ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionEspecifico = CodigoProgramaEspecializacionEspecifico;
            ingresoDatosCapacitacionNavalDTO.CodigoProgramaEspecializacionGrupo = CodigoProgramaEspecializacionGrupo;
            ingresoDatosCapacitacionNavalDTO.FechaInicio = FechaInicio;
            ingresoDatosCapacitacionNavalDTO.FechaTemino = FechaTemino;
            ingresoDatosCapacitacionNavalDTO.CodigoTipoModalidad = CodigoTipoModalidad;
            ingresoDatosCapacitacionNavalDTO.ConcluyoProgramaEstudios = ConcluyoProgramaEstudios;
            ingresoDatosCapacitacionNavalDTO.TotalCredito = TotalCredito;
            ingresoDatosCapacitacionNavalDTO.MotivosNoConcluir = MotivosNoConcluir;
            ingresoDatosCapacitacionNavalDTO.CalificacionFinalObtenida = CalificacionFinalObtenida;
            ingresoDatosCapacitacionNavalDTO.NombreDiploma = NombreDiploma;
            ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoDatosCapacitacionNavalBL.ActualizarFormato(ingresoDatosCapacitacionNavalDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO = new();
            ingresoDatosCapacitacionNavalDTO.IngresoDatoCapacitacionNavalId = Id;
            ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ingresoDatosCapacitacionNavalBL.EliminarFormato(ingresoDatosCapacitacionNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            IngresoDatosCapacitacionNavalDTO ingresoDatosCapacitacionNavalDTO = new();
            ingresoDatosCapacitacionNavalDTO.CargaId = Id;
            ingresoDatosCapacitacionNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (ingresoDatosCapacitacionNavalBL.EliminarCarga(ingresoDatosCapacitacionNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<IngresoDatosCapacitacionNavalDTO> lista = new List<IngresoDatosCapacitacionNavalDTO>();
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

                    lista.Add(new IngresoDatosCapacitacionNavalDTO
                    {
                        CIPPersonal = fila.GetCell(0).ToString(),
                        DNIPersonal = fila.GetCell(1).ToString(),
                        SexoPersonal = fila.GetCell(2).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(5).ToString(),
                        CodigoDependencia = fila.GetCell(6).ToString(),
                        CodigoZonaNaval = fila.GetCell(7).ToString(),
                        CodigoProgramaEspecializacionEspecifico = fila.GetCell(8).ToString(),
                        CodigoProgramaEspecializacionGrupo = fila.GetCell(9).ToString(),
                        FechaInicio = fila.GetCell(10).ToString(),
                        FechaTemino = fila.GetCell(11).ToString(),
                        CodigoTipoModalidad = fila.GetCell(12).ToString(),
                        ConcluyoProgramaEstudios = fila.GetCell(13).ToString(),
                        TotalCredito = int.Parse(fila.GetCell(14).ToString()),
                        MotivosNoConcluir = fila.GetCell(15).ToString(),
                        CalificacionFinalObtenida = decimal.Parse(fila.GetCell(16).ToString()),
                        NombreDiploma = fila.GetCell(17).ToString(),

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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo

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

            dt.Columns.AddRange(new DataColumn[19]
            {
                    new DataColumn("CIPPersonal", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(string)),
                    new DataColumn("SexoPersonal", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoProgramaEspecializacionEspecifico", typeof(string)),
                    new DataColumn("CodigoProgramaEspecializacionGrupo", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTemino", typeof(string)),
                    new DataColumn("CodigoTipoModalidad", typeof(string)),
                    new DataColumn("ConcluyoProgramaEstudios", typeof(string)),
                    new DataColumn("TotalCredito", typeof(int)),
                    new DataColumn("MotivosNoConcluir", typeof(string)),
                    new DataColumn("CalificacionFinalObtenida", typeof(decimal)),
                    new DataColumn("NombreDiploma", typeof(string)),

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
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(11).ToString()),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    int.Parse(fila.GetCell(14).ToString()),
                    fila.GetCell(15).ToString(),
                    int.Parse(fila.GetCell(16).ToString()),
                    fila.GetCell(17).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = ingresoDatosCapacitacionNavalBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDIDCN(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dircapen\\IngresoDatosCapacitacionNaval.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = ingresoDatosCapacitacionNavalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("IngresoDatoCapacitacionNaval", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DircapenIngresoDatosCapacitacionNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DircapenIngresoDatosCapacitacionNaval.xlsx");
        }

    }
}

