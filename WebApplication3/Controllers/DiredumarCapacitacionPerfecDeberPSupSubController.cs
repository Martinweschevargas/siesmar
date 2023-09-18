
using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
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
    public class DiredumarCapacitacionPerfecDeberPSupSubController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        CapacitacionPerfecDeberPSupSubDAO capacitacionperfedeberBL = new();
        Dependencia dependenciaBL = new();
        GradoPersonalMilitar gradopersonalmBL = new();
        EspecialidadGenericaPersonal especialidadgenericaBL = new();
        PaisUbigeo paisubigeoBL = new();
        EntidadMilitar entidadmilitarBL = new();
        CodigoEscuela codigoescuelaBL = new();
        ClasificacionCurso clasificacioncursoBL = new();
        MotivoTerminoCurso motivoterminocursoBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        Carga cargaBL = new();

        public DiredumarCapacitacionPerfecDeberPSupSubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Capacitación y Perfeccionamiento del Personal Superior y Subalterno de acuerdo linea de carrera", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradopersonalmBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadgenericaBL.ObtenerEspecialidadGenericaPersonals();
            List<PaisUbigeoDTO> paisUbigeoDTO = paisubigeoBL.ObtenerPaisUbigeos();
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadmilitarBL.ObtenerEntidadMilitars();
            List<CodigoEscuelaDTO> codigoEscuelaDTO = codigoescuelaBL.ObtenerCodigoEscuelas();
            List<ClasificacionCursoDTO> clasificacionCursoDTO = clasificacioncursoBL.ObtenerClasificacionCursos();
            List<MotivoTerminoCursoDTO> motivoTerminoCursoDTO = motivoterminocursoBL.ObtenerMotivoTerminoCursos();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitar = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CapacitacionPerfeccionamientoDeber");

            return Json(new
            {
                data1 = dependenciaDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = especialidadGenericaPersonalDTO,
                data4 = paisUbigeoDTO,
                data5 = entidadMilitarDTO,
                data6 = codigoEscuelaDTO,
                data7 = clasificacionCursoDTO,
                data8 = motivoTerminoCursoDTO,
                data9 = tipoPersonalMilitar,
                data10 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<CapacitacionPerfecDeberPSupSubDTO> select = capacitacionperfedeberBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CIPCapaPerfDeber, string DNICapaPerfDeber, string NombreCapaPerfDeber,
            string FechaNacimientoCapaPerfDeber, string SexoCapaPerfDeber, string CodigoDependencia,
           string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string CapacitacioLineaCapaPerfDeber,
            string InscripcionCapaPerfDeber, string TipoProgramaCapaPerfDeber, string NumericoPais,
           string CodigoEntidadMilitar, string CodigoCodigoEscuela, string MencionCursoCapacitacion, string CodigoClasificacionCurso,
            string FinanciamientoCapaPerfDeber, string FechaInicioCapaPerfDeber, string FechaTerminoCapaPerfDeber,
           string FechaRegistroCapaPerfDeber, int HoraCapacitacionCapaPerfDeber, string CodigoMotivoTerminoCurso, int CargaId, string fecha)
        {
            CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO = new();
            capacitacionPerfecDeberPSupSubDTO.CIPCapaPerfDeber = CIPCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.DNICapaPerfDeber = DNICapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.NombreCapaPerfDeber = NombreCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaNacimientoCapaPerfDeber = FechaNacimientoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.SexoCapaPerfDeber = SexoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.CodigoDependencia = CodigoDependencia;
            capacitacionPerfecDeberPSupSubDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            capacitacionPerfecDeberPSupSubDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            capacitacionPerfecDeberPSupSubDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            capacitacionPerfecDeberPSupSubDTO.CapacitacioLineaCapaPerfDeber = CapacitacioLineaCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.InscripcionCapaPerfDeber = InscripcionCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.TipoProgramaCapaPerfDeber = TipoProgramaCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.NumericoPais = NumericoPais;
            capacitacionPerfecDeberPSupSubDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            capacitacionPerfecDeberPSupSubDTO.CodigoCodigoEscuela = CodigoCodigoEscuela;
            capacitacionPerfecDeberPSupSubDTO.MencionCursoCapacitacion = MencionCursoCapacitacion;
            capacitacionPerfecDeberPSupSubDTO.CodigoClasificacionCurso = CodigoClasificacionCurso;
            capacitacionPerfecDeberPSupSubDTO.FinanciamientoCapaPerfDeber = FinanciamientoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaInicioCapaPerfDeber = FechaInicioCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaTerminoCapaPerfDeber = FechaTerminoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaRegistroCapaPerfDeber = FechaRegistroCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.HoraCapacitacionCapaPerfDeber = HoraCapacitacionCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.CodigoMotivoTerminoCurso = CodigoMotivoTerminoCurso;
            capacitacionPerfecDeberPSupSubDTO.CargaId = CargaId;
            capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionperfedeberBL.AgregarRegistro(capacitacionPerfecDeberPSupSubDTO, fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(capacitacionperfedeberBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CIPCapaPerfDeber, string DNICapaPerfDeber, string NombreCapaPerfDeber,
            string FechaNacimientoCapaPerfDeber, string SexoCapaPerfDeber, string CodigoDependencia,
           string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string CapacitacioLineaCapaPerfDeber,
            string InscripcionCapaPerfDeber, string TipoProgramaCapaPerfDeber, string NumericoPais,
           string CodigoEntidadMilitar, string CodigoCodigoEscuela, string MencionCursoCapacitacion, string CodigoClasificacionCurso,
            string FinanciamientoCapaPerfDeber, string FechaInicioCapaPerfDeber, string FechaTerminoCapaPerfDeber,
           string FechaRegistroCapaPerfDeber, int HoraCapacitacionCapaPerfDeber, string CodigoMotivoTerminoCurso)
        {

            CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO = new();
            capacitacionPerfecDeberPSupSubDTO.CapacitacionPerfeccionamientoDeberId = Id;
            capacitacionPerfecDeberPSupSubDTO.CIPCapaPerfDeber = CIPCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.DNICapaPerfDeber = DNICapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.NombreCapaPerfDeber = NombreCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaNacimientoCapaPerfDeber = FechaNacimientoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.SexoCapaPerfDeber = SexoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.CodigoDependencia = CodigoDependencia;
            capacitacionPerfecDeberPSupSubDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            capacitacionPerfecDeberPSupSubDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            capacitacionPerfecDeberPSupSubDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            capacitacionPerfecDeberPSupSubDTO.CapacitacioLineaCapaPerfDeber = CapacitacioLineaCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.InscripcionCapaPerfDeber = InscripcionCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.TipoProgramaCapaPerfDeber = TipoProgramaCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.NumericoPais = NumericoPais;
            capacitacionPerfecDeberPSupSubDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            capacitacionPerfecDeberPSupSubDTO.CodigoCodigoEscuela = CodigoCodigoEscuela;
            capacitacionPerfecDeberPSupSubDTO.MencionCursoCapacitacion = MencionCursoCapacitacion;
            capacitacionPerfecDeberPSupSubDTO.CodigoClasificacionCurso = CodigoClasificacionCurso;
            capacitacionPerfecDeberPSupSubDTO.FinanciamientoCapaPerfDeber = FinanciamientoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaInicioCapaPerfDeber = FechaInicioCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaTerminoCapaPerfDeber = FechaTerminoCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.FechaRegistroCapaPerfDeber = FechaRegistroCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.HoraCapacitacionCapaPerfDeber = HoraCapacitacionCapaPerfDeber;
            capacitacionPerfecDeberPSupSubDTO.CodigoMotivoTerminoCurso = CodigoMotivoTerminoCurso;
            capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = capacitacionperfedeberBL.ActualizaFormato(capacitacionPerfecDeberPSupSubDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO = new();
            capacitacionPerfecDeberPSupSubDTO.CapacitacionPerfeccionamientoDeberId = Id;
            capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionperfedeberBL.EliminarFormato(capacitacionPerfecDeberPSupSubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            CapacitacionPerfecDeberPSupSubDTO capacitacionPerfecDeberPSupSubDTO = new();
            capacitacionPerfecDeberPSupSubDTO.CargaId = Id;
            capacitacionPerfecDeberPSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (capacitacionperfedeberBL.EliminarCarga(capacitacionPerfecDeberPSupSubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CapacitacionPerfecDeberPSupSubDTO> lista = new List<CapacitacionPerfecDeberPSupSubDTO>();
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

                    lista.Add(new CapacitacionPerfecDeberPSupSubDTO
                    {
                        CIPCapaPerfDeber = fila.GetCell(0).ToString(),
                        DNICapaPerfDeber = fila.GetCell(1).ToString(),
                        NombreCapaPerfDeber = fila.GetCell(2).ToString(),
                        FechaNacimientoCapaPerfDeber = fila.GetCell(3).ToString(),
                        SexoCapaPerfDeber = fila.GetCell(4).ToString(),
                        CodigoDependencia = fila.GetCell(5).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(6).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(7).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(8).ToString(),
                        CapacitacioLineaCapaPerfDeber = fila.GetCell(9).ToString(),
                        InscripcionCapaPerfDeber = fila.GetCell(10).ToString(),
                        TipoProgramaCapaPerfDeber = fila.GetCell(11).ToString(),
                        NumericoPais = fila.GetCell(12).ToString(),
                        CodigoEntidadMilitar = fila.GetCell(13).ToString(),
                        CodigoCodigoEscuela = fila.GetCell(14).ToString(),
                        MencionCursoCapacitacion = fila.GetCell(15).ToString(),
                        CodigoClasificacionCurso = fila.GetCell(16).ToString(),
                        FinanciamientoCapaPerfDeber = fila.GetCell(17).ToString(),
                        FechaInicioCapaPerfDeber = fila.GetCell(18).ToString(),
                        FechaTerminoCapaPerfDeber = fila.GetCell(19).ToString(),
                        FechaRegistroCapaPerfDeber = fila.GetCell(20).ToString(),
                        HoraCapacitacionCapaPerfDeber = int.Parse(fila.GetCell(21).ToString()),
                        CodigoMotivoTerminoCurso = fila.GetCell(22).ToString()
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

            dt.Columns.AddRange(new DataColumn[24]
            {
                    new DataColumn("CIPCapaPerfDeber", typeof(string)),
                    new DataColumn("DNICapaPerfDeber", typeof(string)),
                    new DataColumn("NombreCapaPerfDeber", typeof(string)),
                    new DataColumn("FechaNacimientoCapaPerfDeber", typeof(string)),
                    new DataColumn("SexoCapaPerfDeber", typeof(string)),
                    new DataColumn("CodigoDependencia ", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar ", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar ", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal ", typeof(string)),
                    new DataColumn("CapacitacioLineaCapaPerfDeber", typeof(string)),
                    new DataColumn("InscripcionCapaPerfDeber", typeof(string)),
                    new DataColumn("TipoProgramaCapaPerfDeber", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("CodigoEntidadMilitar ", typeof(string)),
                    new DataColumn("CodigoCodigoEscuela ", typeof(string)),
                    new DataColumn("MencionCursoCapacitacion", typeof(string)),
                    new DataColumn("CodigoClasificacionCurso ", typeof(string)),
                    new DataColumn("FinanciamientoCapaPerfDeber", typeof(string)),
                    new DataColumn("FechaInicioCapaPerfDeber", typeof(string)),
                    new DataColumn("FechaTerminoCapaPerfDeber", typeof(string)),
                    new DataColumn("FechaRegistroCapaPerfDeber", typeof(string)),
                    new DataColumn("HoraCapacitacionCapaPerfDeber", typeof(int)),
                    new DataColumn("CodigoMotivoTerminoCurso ", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(18).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(19).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(20).ToString()),
                    int.Parse(fila.GetCell(21).ToString()),
                    fila.GetCell(22).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = capacitacionperfedeberBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiredumarCapacitacionPerfecDeberPSupSub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiredumarCapacitacionPerfecDeberPSupSub.xlsx");
        }
        
    }

}