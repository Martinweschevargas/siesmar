using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresprom;
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

    public class DirespromPrograma2daEspecializacionSController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Programa2daEspecializacionSuperior programa2daEspecializacionSuperiorBL = new();
        EntidadMilitar EntidadMilitarBL = new();
        GradoPersonalMilitar GradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal EspecialidadGenericaPersonalBL = new();
        Dependencia DependenciaBL = new();
        ZonaNaval ZonaNavalBL = new();
        ProgramaEspecializacionGrupo ProgramaEspecializacionGrupoBL = new();
        ProgramaEspecializacionEspecifico ProgramaEspecializacionEspecificoBL = new();
        ModalidadPrograma ModalidadProgramaBL = new();
        Carga cargaBL = new();

        public DirespromPrograma2daEspecializacionSController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Programas de Segunda Especialización del Personal Superior de la Marina", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<EntidadMilitarDTO> EntidadMilitarDTO = EntidadMilitarBL.ObtenerEntidadMilitars();
            List<GradoPersonalMilitarDTO> GradoPersonalMilitarDTO = GradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> EspecialidadGenericaPersonalDTO = EspecialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<DependenciaDTO> DependenciaDTO = DependenciaBL.ObtenerDependencias();
            List<ZonaNavalDTO> ZonaNavalDTO = ZonaNavalBL.ObtenerZonaNavals();
            List<ProgramaEspecializacionGrupoDTO> ProgramaEspecializacionGrupoDTO = ProgramaEspecializacionGrupoBL.ObtenerProgramaEspecializacionGrupos();
            List<ProgramaEspecializacionEspecificoDTO> ProgramaEspecializacionEspecificoDTO = ProgramaEspecializacionEspecificoBL.ObtenerProgramaEspecializacionEspecificos();
            List<ModalidadProgramaDTO> ModalidadProgramaDTO = ModalidadProgramaBL.ObtenerModalidadProgramas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("Programa2daEspecializacionSuperior");
            return Json(new { 
                data1 = EntidadMilitarDTO, 
                data2 = GradoPersonalMilitarDTO,  
                data3 = EspecialidadGenericaPersonalDTO,
                data4 = DependenciaDTO,
                data5 = ZonaNavalDTO, 
                data6 = ProgramaEspecializacionGrupoDTO, 
                data7 = ProgramaEspecializacionEspecificoDTO,
                data8 = ModalidadProgramaDTO, 
                data9 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<Programa2daEspecializacionSuperiorDTO> select = programa2daEspecializacionSuperiorBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIPersonalSuperior, int EdadPersonalSuperior, string SexoPersonalSuperior,
            string CondicionPersonalSuperior, string CodigoEntidadMilitar, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal,
            string ProcedenciaPersonalSuperior, int AnioPromocionPersonalSuperior, string CodigoProgramaEspecializacionGrupo, string CodigoProgramaEspecializacionEspecifico,
            string CodigoDependencia, string CodigoZonaNaval, string FechaInicio, string FechaTermino,
            string FechaRegistro, string CodigoModalidadPrograma, string ConcluyoProgramaEstudios, string MotivosNoConcluir,
            decimal CalificacionFinalObtenida, string CertificacionTituloObtenido, int CargaId, string Fecha)
        {
            Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO = new();
            programa2daEspecializacionSuperiorDTO.DNIPersonalSuperior = DNIPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.EdadPersonalSuperior = EdadPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.SexoPersonalSuperior = SexoPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.CondicionPersonalSuperior = CondicionPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            programa2daEspecializacionSuperiorDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            programa2daEspecializacionSuperiorDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            programa2daEspecializacionSuperiorDTO.ProcedenciaPersonalSuperior = ProcedenciaPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.AnioPromocionPersonalSuperior = AnioPromocionPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.CodigoDependencia = CodigoDependencia;
            programa2daEspecializacionSuperiorDTO.CodigoZonaNaval = CodigoZonaNaval;
            programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionGrupo = CodigoProgramaEspecializacionGrupo;
            programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionEspecifico = CodigoProgramaEspecializacionEspecifico;
            programa2daEspecializacionSuperiorDTO.FechaInicio = FechaInicio;
            programa2daEspecializacionSuperiorDTO.FechaTermino = FechaTermino;
            programa2daEspecializacionSuperiorDTO.FechaRegistro = FechaRegistro;
            programa2daEspecializacionSuperiorDTO.CodigoModalidadPrograma = CodigoModalidadPrograma;
            programa2daEspecializacionSuperiorDTO.ConcluyoProgramaEstudios = ConcluyoProgramaEstudios;
            programa2daEspecializacionSuperiorDTO.MotivosNoConcluir = MotivosNoConcluir;
            programa2daEspecializacionSuperiorDTO.CalificacionFinalObtenida = CalificacionFinalObtenida;
            programa2daEspecializacionSuperiorDTO.CertificacionTituloObtenido = CertificacionTituloObtenido;
            programa2daEspecializacionSuperiorDTO.CargaId = CargaId;
            programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programa2daEspecializacionSuperiorBL.AgregarRegistro(programa2daEspecializacionSuperiorDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(programa2daEspecializacionSuperiorBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIPersonalSuperior, int EdadPersonalSuperior, string SexoPersonalSuperior,
            string CondicionPersonalSuperior, string CodigoEntidadMilitar, string CodigoGradoPersonalMilitar, string CodigoEspecialidadGenericaPersonal,
            string ProcedenciaPersonalSuperior, int AnioPromocionPersonalSuperior, string CodigoProgramaEspecializacionGrupo, string CodigoProgramaEspecializacionEspecifico,
            string CodigoDependencia, string CodigoZonaNaval, string FechaInicio, string FechaTermino,
            string FechaRegistro, string CodigoModalidadPrograma, string ConcluyoProgramaEstudios, string MotivosNoConcluir,
            decimal CalificacionFinalObtenida, string CertificacionTituloObtenido)
        {
            Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO = new();
            programa2daEspecializacionSuperiorDTO.Programa2daEspecializacionSuperiorId = Id;
            programa2daEspecializacionSuperiorDTO.DNIPersonalSuperior = DNIPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.EdadPersonalSuperior = EdadPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.SexoPersonalSuperior = SexoPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.CondicionPersonalSuperior = CondicionPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            programa2daEspecializacionSuperiorDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            programa2daEspecializacionSuperiorDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            programa2daEspecializacionSuperiorDTO.ProcedenciaPersonalSuperior = ProcedenciaPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.AnioPromocionPersonalSuperior = AnioPromocionPersonalSuperior;
            programa2daEspecializacionSuperiorDTO.CodigoDependencia = CodigoDependencia;
            programa2daEspecializacionSuperiorDTO.CodigoZonaNaval = CodigoZonaNaval;
            programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionGrupo = CodigoProgramaEspecializacionGrupo;
            programa2daEspecializacionSuperiorDTO.CodigoProgramaEspecializacionEspecifico = CodigoProgramaEspecializacionEspecifico;
            programa2daEspecializacionSuperiorDTO.FechaInicio = FechaInicio;
            programa2daEspecializacionSuperiorDTO.FechaTermino = FechaTermino;
            programa2daEspecializacionSuperiorDTO.FechaRegistro = FechaRegistro;
            programa2daEspecializacionSuperiorDTO.CodigoModalidadPrograma = CodigoModalidadPrograma;
            programa2daEspecializacionSuperiorDTO.ConcluyoProgramaEstudios = ConcluyoProgramaEstudios;
            programa2daEspecializacionSuperiorDTO.MotivosNoConcluir = MotivosNoConcluir;
            programa2daEspecializacionSuperiorDTO.CalificacionFinalObtenida = CalificacionFinalObtenida;
            programa2daEspecializacionSuperiorDTO.CertificacionTituloObtenido = CertificacionTituloObtenido;
            programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = programa2daEspecializacionSuperiorBL.ActualizarFormato(programa2daEspecializacionSuperiorDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO = new();
            programa2daEspecializacionSuperiorDTO.Programa2daEspecializacionSuperiorId = Id;
            programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (programa2daEspecializacionSuperiorBL.EliminarFormato(programa2daEspecializacionSuperiorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSuperiorDTO = new();
            programa2daEspecializacionSuperiorDTO.CargaId = Id;
            programa2daEspecializacionSuperiorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (programa2daEspecializacionSuperiorBL.EliminarCarga(programa2daEspecializacionSuperiorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<Programa2daEspecializacionSuperiorDTO> lista = new List<Programa2daEspecializacionSuperiorDTO>();
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

                    lista.Add(new Programa2daEspecializacionSuperiorDTO
                    {
                        DNIPersonalSuperior = fila.GetCell(0).ToString(),
                        EdadPersonalSuperior = int.Parse(fila.GetCell(1).ToString()),
                        SexoPersonalSuperior = fila.GetCell(2).ToString(),
                        CondicionPersonalSuperior = fila.GetCell(3).ToString(),
                        CodigoEntidadMilitar = fila.GetCell(4).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(5).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(6).ToString(),
                        ProcedenciaPersonalSuperior = fila.GetCell(7).ToString(),
                        AnioPromocionPersonalSuperior = int.Parse(fila.GetCell(8).ToString()),
                        CodigoDependencia = fila.GetCell(9).ToString(),
                        CodigoZonaNaval = fila.GetCell(10).ToString(),
                        CodigoProgramaEspecializacionGrupo = fila.GetCell(11).ToString(),
                        CodigoProgramaEspecializacionEspecifico = fila.GetCell(12).ToString(),
                        FechaInicio = fila.GetCell(13).ToString(),
                        FechaTermino = fila.GetCell(14).ToString(),
                        FechaRegistro = fila.GetCell(15).ToString(),
                        CodigoModalidadPrograma = fila.GetCell(16).ToString(),
                        ConcluyoProgramaEstudios = fila.GetCell(16).ToString(),
                        MotivosNoConcluir = fila.GetCell(18).ToString(),
                        CalificacionFinalObtenida = decimal.Parse(fila.GetCell(19).ToString()),
                        CertificacionTituloObtenido = fila.GetCell(20).ToString(),
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

            dt.Columns.AddRange(new DataColumn[22]
            {
                    new DataColumn("DNIPersonalSuperior", typeof(string)),
                    new DataColumn("EdadPersonalSuperior", typeof(int)),
                    new DataColumn("SexoPersonalSuperior", typeof(string)),
                    new DataColumn("CondicionPersonalSuperior", typeof(string)),
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("ProcedenciaPersonalSuperior", typeof(string)),
                    new DataColumn("AnioPromocionPersonalSuperior", typeof(int)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoProgramaEspecializacionGrupo", typeof(string)),
                    new DataColumn("CodigoProgramaEspecializacionEspecifico", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("FechaRegistro", typeof(string)),
                    new DataColumn("CodigoModalidadPrograma", typeof(string)),
                    new DataColumn("ConcluyoProgramaEstudios", typeof(string)),
                    new DataColumn("MotivosNoConcluir", typeof(string)),
                    new DataColumn("CalificacionFinalObtenida", typeof(decimal)),
                    new DataColumn("CertificacionTituloObtenido", typeof(string)),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(13).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    fila.GetCell(18).ToString(),
                    decimal.Parse(fila.GetCell(19).ToString()),
                    fila.GetCell(20).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = programa2daEspecializacionSuperiorBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDPES(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresprom\\Programa2daEspecializacionS.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capacitacionPerfeccionamientoExtraC = programa2daEspecializacionSuperiorBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Programa2daEspecializacionS", capacitacionPerfeccionamientoExtraC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirespromPrograma2daEspecializacionS.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirespromPrograma2daEspecializacionS.xlsx");
        }
    }

}

