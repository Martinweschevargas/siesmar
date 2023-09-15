using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diredumar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diredumar;
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
    public class DiredumarSegEspecialidadPersonalSupSubController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        SegEspecialidadPersonalSupSub segEspecialidadPersonalSupSubBL = new();
        Dependencia dependenciaBL = new();
        GradoPersonalMilitar gradopersonalmBL = new();
        EspecialidadGenericaPersonal especialidadgenericaBL = new();
        PaisUbigeo paisubigeoBL = new();
        EntidadMilitar entidadmilitarBL = new();
        CodigoEscuela codigoescuelaBL = new();
        MotivoTerminoCurso motivoterminocursoBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        Carga cargaBL = new();

        public DiredumarSegEspecialidadPersonalSupSubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno", FromController = typeof(HomeController))]

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
            List<MotivoTerminoCursoDTO> motivoTerminoCursoDTO = motivoterminocursoBL.ObtenerMotivoTerminoCursos();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitar = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SegEspecialidadPersonalSupSub");
            return Json(new
            {
                data1 = dependenciaDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = especialidadGenericaPersonalDTO,
                data4 = paisUbigeoDTO,
                data5 = entidadMilitarDTO,
                data6 = codigoEscuelaDTO,
                data7 = motivoTerminoCursoDTO,
                data8 = tipoPersonalMilitar,
                data9 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<SegEspecialidadPersonalSupSubDTO> select = segEspecialidadPersonalSupSubBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CIPSegEspecialidad, string DNISegEspecialidad, string NombreSegEspecialidad,
            string FechaNacimientoSegEspecialidad, string SexoSegEspecialidad, string CodigoDependencia,
           string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string TipoProgramaCapSegEspecialidad,
            string NumericoPais, string CodigoEntidadMilitar, string CodigoCodigoEscuela, string MencionCursoSegEspecialidad, string FinanciamientoSegEspecialidad,
            string FechaInicioSegEspecialidad, string FechaTerminoSegEspecialidad, string FechaRegistroSegEspecialidad,
           int HorasCapacitacionSegEspecialidad, string CalificacionSegEspecialidad, string CodigoMotivoTerminoCurso, int CargaId, string Fecha)
        {
            SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO = new();
            segEspecialidadPersonalSupSubDTO.CIPSegEspecialidad = CIPSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.DNISegEspecialidad = DNISegEspecialidad;
            segEspecialidadPersonalSupSubDTO.NombreSegEspecialidad = NombreSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaNacimientoSegEspecialidad = FechaNacimientoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.SexoSegEspecialidad = SexoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.CodigoDependencia = CodigoDependencia;
            segEspecialidadPersonalSupSubDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            segEspecialidadPersonalSupSubDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            segEspecialidadPersonalSupSubDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            segEspecialidadPersonalSupSubDTO.TipoProgramaCapSegEspecialidad = TipoProgramaCapSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.NumericoPais = NumericoPais;
            segEspecialidadPersonalSupSubDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            segEspecialidadPersonalSupSubDTO.CodigoEscuela = CodigoCodigoEscuela;
            segEspecialidadPersonalSupSubDTO.MencionCursoSegEspecialidad = MencionCursoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FinanciamientoSegEspecialidad = FinanciamientoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaInicioSegEspecialidad = FechaInicioSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaTerminoSegEspecialidad = FechaTerminoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaRegistroSegEspecialidad = FechaRegistroSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.HorasCapacitacionSegEspecialidad = HorasCapacitacionSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.CalificacionSegEspecialidad = CalificacionSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.CodigoMotivoTerminoCurso = CodigoMotivoTerminoCurso;
            segEspecialidadPersonalSupSubDTO.CargaId = CargaId;
            segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = segEspecialidadPersonalSupSubBL.AgregarRegistro(segEspecialidadPersonalSupSubDTO, Fecha);
            return Content(IND_OPERACION);
        }
        
        public ActionResult Mostrar(int Id)
        {
            return Json(segEspecialidadPersonalSupSubBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CIPSegEspecialidad, string DNISegEspecialidad, string NombreSegEspecialidad,
            string FechaNacimientoSegEspecialidad, string SexoSegEspecialidad, string CodigoDependencia,
           string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal, string TipoProgramaCapSegEspecialidad,
            string NumericoPais, string CodigoEntidadMilitar, string CodigoCodigoEscuela, string MencionCursoSegEspecialidad, string FinanciamientoSegEspecialidad,
            string FechaInicioSegEspecialidad, string FechaTerminoSegEspecialidad, string FechaRegistroSegEspecialidad,
           int HorasCapacitacionSegEspecialidad, string CalificacionSegEspecialidad, string CodigoMotivoTerminoCurso)
        {

            SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO = new();
            segEspecialidadPersonalSupSubDTO.SegEspecialidadPersonalSupSubId = Id;
            segEspecialidadPersonalSupSubDTO.CIPSegEspecialidad = CIPSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.DNISegEspecialidad = DNISegEspecialidad;
            segEspecialidadPersonalSupSubDTO.NombreSegEspecialidad = NombreSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaNacimientoSegEspecialidad = FechaNacimientoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.SexoSegEspecialidad = SexoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.CodigoDependencia = CodigoDependencia;
            segEspecialidadPersonalSupSubDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            segEspecialidadPersonalSupSubDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            segEspecialidadPersonalSupSubDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            segEspecialidadPersonalSupSubDTO.TipoProgramaCapSegEspecialidad = TipoProgramaCapSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.NumericoPais = NumericoPais;
            segEspecialidadPersonalSupSubDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            segEspecialidadPersonalSupSubDTO.CodigoEscuela = CodigoCodigoEscuela;
            segEspecialidadPersonalSupSubDTO.MencionCursoSegEspecialidad = MencionCursoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FinanciamientoSegEspecialidad = FinanciamientoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaInicioSegEspecialidad = FechaInicioSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaTerminoSegEspecialidad = FechaTerminoSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.FechaRegistroSegEspecialidad = FechaRegistroSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.HorasCapacitacionSegEspecialidad = HorasCapacitacionSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.CalificacionSegEspecialidad = CalificacionSegEspecialidad;
            segEspecialidadPersonalSupSubDTO.CodigoMotivoTerminoCurso = CodigoMotivoTerminoCurso;
            segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = segEspecialidadPersonalSupSubBL.ActualizarFormato(segEspecialidadPersonalSupSubDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO = new();
            segEspecialidadPersonalSupSubDTO.SegEspecialidadPersonalSupSubId = Id;
            segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (segEspecialidadPersonalSupSubBL.EliminarFormato(segEspecialidadPersonalSupSubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            SegEspecialidadPersonalSupSubDTO segEspecialidadPersonalSupSubDTO = new();
            segEspecialidadPersonalSupSubDTO.CargaId = Id;
            segEspecialidadPersonalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (segEspecialidadPersonalSupSubBL.EliminarCarga(segEspecialidadPersonalSupSubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<SegEspecialidadPersonalSupSubDTO> lista = new List<SegEspecialidadPersonalSupSubDTO>();
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

                    lista.Add(new SegEspecialidadPersonalSupSubDTO
                    {
                        CIPSegEspecialidad = fila.GetCell(0).ToString(),
                        DNISegEspecialidad = fila.GetCell(1).ToString(),
                        NombreSegEspecialidad = fila.GetCell(2).ToString(),
                        FechaNacimientoSegEspecialidad = UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                        SexoSegEspecialidad = fila.GetCell(4).ToString(),
                        CodigoDependencia = fila.GetCell(5).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(6).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(7).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(8).ToString(),
                        TipoProgramaCapSegEspecialidad = fila.GetCell(9).ToString(),
                        NumericoPais = fila.GetCell(10).ToString(),
                        CodigoEntidadMilitar = fila.GetCell(11).ToString(),
                        CodigoEscuela = fila.GetCell(12).ToString(),
                        MencionCursoSegEspecialidad = fila.GetCell(13).ToString(),
                        FinanciamientoSegEspecialidad = fila.GetCell(14).ToString(),
                        FechaInicioSegEspecialidad = UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                        FechaTerminoSegEspecialidad = UtilitariosGlobales.obtenerFecha(fila.GetCell(16).ToString()),
                        FechaRegistroSegEspecialidad = UtilitariosGlobales.obtenerFecha(fila.GetCell(17).ToString()),
                        HorasCapacitacionSegEspecialidad = int.Parse(fila.GetCell(18).ToString()),
                        CalificacionSegEspecialidad = fila.GetCell(19).ToString(),
                        CodigoMotivoTerminoCurso = fila.GetCell(20).ToString()
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

            dt.Columns.AddRange(new DataColumn[22]
            {
                    new DataColumn("CIPSegEspecialidad", typeof(string)),
                    new DataColumn("DNISegEspecialidad", typeof(string)),
                    new DataColumn("NombreSegEspecialidad", typeof(string)),
                    new DataColumn("FechaNacimientoSegEspecialidad", typeof(string)),
                    new DataColumn("SexoSegEspecialidad", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("TipoProgramaCapSegEspecialidad", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoCodigoEscuela", typeof(string)),
                    new DataColumn("MencionCursoSegEspecialidad", typeof(string)),
                    new DataColumn("FinanciamientoSegEspecialidad", typeof(string)),
                    new DataColumn("FechaInicioSegEspecialidad", typeof(string)),
                    new DataColumn("FechaTerminoSegEspecialidad", typeof(string)),
                    new DataColumn("FechaRegistroSegEspecialidad", typeof(string)),
                    new DataColumn("HorasCapacitacionSegEspecialidad", typeof(int)),
                    new DataColumn("CalificacionSegEspecialidad", typeof(string)),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(16).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(17).ToString()),
                    int.Parse(fila.GetCell(18).ToString()),
                    fila.GetCell(19).ToString(),
                    fila.GetCell(20).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = segEspecialidadPersonalSupSubBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiredumarSegEspecialidadPersonalSupSub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiredumarSegEspecialidadPersonalSupSub.xlsx");
        }
    }

}