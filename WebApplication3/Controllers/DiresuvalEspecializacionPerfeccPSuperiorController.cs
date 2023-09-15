using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diresuval;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresuval;
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

    public class DiresuvalEspecializacionPerfeccPSuperiorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EspecializacionPerfeccionamientoPSuperior especializacionPerfecPSuperiorBL = new();
        EntidadMilitar entidadMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new();
        ZonaNaval zonaNavalBL = new();
        ProgramaEspecializacionGrupo programaEspecializacionGrupoBL = new();
        ProgramaEspecializacionEspecifico programaEspecializacionEspecificacionBL = new();
        Carga cargaBL = new();

        public DiresuvalEspecializacionPerfeccPSuperiorController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Especialización y Perfeccionamiento del Personal Superior de la Marina", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadMilitarBL.ObtenerEntidadMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<ProgramaEspecializacionGrupoDTO> programaEspecializacionGrupoDTO = programaEspecializacionGrupoBL.ObtenerProgramaEspecializacionGrupos();
            List<ProgramaEspecializacionEspecificoDTO> programaEspecializacionEspecificoDTO = programaEspecializacionEspecificacionBL.ObtenerProgramaEspecializacionEspecificos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EspecializacionPerfeccionamientoPSuperior");

            return Json(new { data1 = entidadMilitarDTO, data2 = gradoPersonalMilitarDTO, data3 = especialidadGenericaPersonalDTO, data4 = dependenciaDTO,
                data5 = zonaNavalDTO, data6 = programaEspecializacionGrupoDTO, data7 = programaEspecializacionEspecificoDTO,
                data8 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EspecializacionPerfeccionamientoPSuperiorDTO> select = especializacionPerfecPSuperiorBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar(string DNIPersonalSuperior, int EdadAnios, string Sexo, string Condicion, string CodigoEntidadMilitar, string CodigoGradoPersonalMilitar,
            string CodigoZonaNaval, string Procedencia, int AnioPromocion, string CodigoDependencia, string CodigoEspecialidadGenericaPersonal, string CodigoProgramaEspecializacionEspecifico,
            string CodigoProgramaEspecializacionGrupo, string FechaInicio, string FechaTermino, string FechaRegistro, string ModalidadEspecializacion, 
            string ConcluyoPrograma, string MotivoNoConcluir, decimal CalificacionObtenida, string CertificacionObtenido, int CargaId, string Fecha)
        {
            EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO = new();
            especializacionPerfecPSuperiorDTO.DNIPersonalSuperior = DNIPersonalSuperior;
            especializacionPerfecPSuperiorDTO.EdadAnios = EdadAnios;
            especializacionPerfecPSuperiorDTO.Sexo = Sexo;
            especializacionPerfecPSuperiorDTO.Condicion = Condicion;
            especializacionPerfecPSuperiorDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            especializacionPerfecPSuperiorDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            especializacionPerfecPSuperiorDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            especializacionPerfecPSuperiorDTO.Procedencia = Procedencia;
            especializacionPerfecPSuperiorDTO.AnioPromocion = AnioPromocion;
            especializacionPerfecPSuperiorDTO.CodigoDependencia = CodigoDependencia;
            especializacionPerfecPSuperiorDTO.CodigoZonaNaval = CodigoZonaNaval;
            especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionGrupo = CodigoProgramaEspecializacionGrupo;
            especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionEspecifico = CodigoProgramaEspecializacionEspecifico;
            especializacionPerfecPSuperiorDTO.FechaInicio = FechaInicio;
            especializacionPerfecPSuperiorDTO.FechaTermino = FechaTermino;
            especializacionPerfecPSuperiorDTO.FechaRegistro = FechaRegistro;
            especializacionPerfecPSuperiorDTO.ModalidadEspecializacion = ModalidadEspecializacion;
            especializacionPerfecPSuperiorDTO.ConcluyoPrograma = ConcluyoPrograma;
            especializacionPerfecPSuperiorDTO.MotivoNoConcluir = MotivoNoConcluir;
            especializacionPerfecPSuperiorDTO.CalificacionObtenida = CalificacionObtenida;
            especializacionPerfecPSuperiorDTO.CertificacionObtenido = CertificacionObtenido;
            especializacionPerfecPSuperiorDTO.CargaId = CargaId;
            especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especializacionPerfecPSuperiorBL.AgregarRegistro(especializacionPerfecPSuperiorDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(especializacionPerfecPSuperiorBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DNIPersonalSuperior, int EdadAnios, string Sexo, string Condicion, string CodigoEntidadMilitar, string CodigoGradoPersonalMilitar,
            string CodigoZonaNaval, string Procedencia, int AnioPromocion, string CodigoDependencia, string CodigoEspecialidadGenericaPersonal, string CodigoProgramaEspecializacionEspecifico,
            string CodigoProgramaEspecializacionGrupo, string FechaInicio, string FechaTermino, string FechaRegistro, string ModalidadEspecializacion,
            string ConcluyoPrograma, string MotivoNoConcluir, decimal CalificacionObtenida, string CertificacionObtenido)
        {
            EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO = new();
            especializacionPerfecPSuperiorDTO.EspecializacionPerfeccionamientoId = Id;
            especializacionPerfecPSuperiorDTO.DNIPersonalSuperior = DNIPersonalSuperior;
            especializacionPerfecPSuperiorDTO.EdadAnios = EdadAnios;
            especializacionPerfecPSuperiorDTO.Sexo = Sexo;
            especializacionPerfecPSuperiorDTO.Condicion = Condicion;
            especializacionPerfecPSuperiorDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            especializacionPerfecPSuperiorDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            especializacionPerfecPSuperiorDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            especializacionPerfecPSuperiorDTO.Procedencia = Procedencia;
            especializacionPerfecPSuperiorDTO.AnioPromocion = AnioPromocion;
            especializacionPerfecPSuperiorDTO.CodigoDependencia = CodigoDependencia;
            especializacionPerfecPSuperiorDTO.CodigoZonaNaval = CodigoZonaNaval;
            especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionGrupo = CodigoProgramaEspecializacionGrupo;
            especializacionPerfecPSuperiorDTO.CodigoProgramaEspecializacionEspecifico = CodigoProgramaEspecializacionEspecifico;
            especializacionPerfecPSuperiorDTO.FechaInicio = FechaInicio;
            especializacionPerfecPSuperiorDTO.FechaTermino = FechaTermino;
            especializacionPerfecPSuperiorDTO.FechaRegistro = FechaRegistro;
            especializacionPerfecPSuperiorDTO.ModalidadEspecializacion = ModalidadEspecializacion;
            especializacionPerfecPSuperiorDTO.ConcluyoPrograma = ConcluyoPrograma;
            especializacionPerfecPSuperiorDTO.MotivoNoConcluir = MotivoNoConcluir;
            especializacionPerfecPSuperiorDTO.CalificacionObtenida = CalificacionObtenida;
            especializacionPerfecPSuperiorDTO.CertificacionObtenido = CertificacionObtenido;
            especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = especializacionPerfecPSuperiorBL.ActualizarFormato(especializacionPerfecPSuperiorDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO = new();
            especializacionPerfecPSuperiorDTO.EspecializacionPerfeccionamientoId = Id;
            especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (especializacionPerfecPSuperiorBL.EliminarFormato(especializacionPerfecPSuperiorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EspecializacionPerfeccionamientoPSuperiorDTO especializacionPerfecPSuperiorDTO = new();
            especializacionPerfecPSuperiorDTO.CargaId = Id;
            especializacionPerfecPSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (especializacionPerfecPSuperiorBL.EliminarCarga(especializacionPerfecPSuperiorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EspecializacionPerfeccionamientoPSuperiorDTO> lista = new List<EspecializacionPerfeccionamientoPSuperiorDTO>();
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

                    lista.Add(new EspecializacionPerfeccionamientoPSuperiorDTO
                    {
                        DNIPersonalSuperior = fila.GetCell(0).ToString(),
                        EdadAnios = int.Parse(fila.GetCell(1).ToString()),
                        Sexo = fila.GetCell(2).ToString(),
                        Condicion = fila.GetCell(3).ToString(),
                        CodigoEntidadMilitar = fila.GetCell(4).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(5).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(6).ToString(),
                        Procedencia = fila.GetCell(7).ToString(),
                        AnioPromocion = int.Parse(fila.GetCell(8).ToString()),
                        CodigoDependencia = fila.GetCell(9).ToString(),
                        CodigoZonaNaval = fila.GetCell(10).ToString(),
                        CodigoProgramaEspecializacionGrupo = fila.GetCell(11).ToString(),
                        CodigoProgramaEspecializacionEspecifico = fila.GetCell(12).ToString(),
                        FechaInicio = fila.GetCell(13).ToString(),
                        FechaTermino = fila.GetCell(14).ToString(),
                        FechaRegistro = fila.GetCell(15).ToString(),
                        ModalidadEspecializacion = fila.GetCell(16).ToString(),
                        ConcluyoPrograma = fila.GetCell(17).ToString(),
                        MotivoNoConcluir = fila.GetCell(18).ToString(),
                        CalificacionObtenida = int.Parse(fila.GetCell(19).ToString()),
                        CertificacionObtenido = fila.GetCell(20).ToString(),
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

            dt.Columns.AddRange(new DataColumn[22]
            {
                    new DataColumn("DNIPersonalSuperior", typeof(string)),
                    new DataColumn("EdadAnios", typeof(int)),
                    new DataColumn("Sexo", typeof(string)),
                    new DataColumn("Condicion", typeof(string)),
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("Procedencia", typeof(string)),
                    new DataColumn("AnioPromocion", typeof(int)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoProgramaEspecializacionGrupo", typeof(string)),
                    new DataColumn("CodigoProgramaEspecializacionEspecifico", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("FechaRegistro", typeof(string)),
                    new DataColumn("ModalidadEspecializacion", typeof(string)),
                    new DataColumn("ConcluyoPrograma", typeof(string)),
                    new DataColumn("MotivoNoConcluir", typeof(string)),
                    new DataColumn("CalificacionObtenida", typeof(int)),
                    new DataColumn("CertificacionObtenido", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    fila.GetCell(18).ToString(),
                    int.Parse(fila.GetCell(19).ToString()),
                    fila.GetCell(20).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = especializacionPerfecPSuperiorBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDEPPS(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresuval\\EspecializacionPerfeccPSuperior.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capacitacionPerfeccionamientoExtraC = especializacionPerfecPSuperiorBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EspecializacionPerfeccPSuperior", capacitacionPerfeccionamientoExtraC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiresuvalEspecializacionPerfeccPSuperior.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiresuvalEspecializacionPerfeccPSuperior.xlsx");
        }

    }

}

