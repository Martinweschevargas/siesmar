using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
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

    public class IpecamarInspeccionInstitucionalesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        InspeccionInstitucionales inspeccionInstitucionalesBL = new();

        Dependencia dependenciaBL = new();
        ComandanciaDependencia comandanciaDependenciaBL = new();
        NivelDependencia nivelDependenciaBL = new();
        ZonaNaval zonaNavalBL = new();
        InspeccionConocimiento inspeccionConocimientoBL = new();
        InspeccionExtension inspeccionExtensionBL = new();
        InspeccionFinalidad inspeccionFinalidadBL = new();
        OrganoControlInspeccion organoControlInspeccionBL=new();
        Carga cargaBL = new();

        public IpecamarInspeccionInstitucionalesController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Inspecciones Institucionales, Supervisión y Seguimiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<NivelDependenciaDTO> nivelDependenciaDTO = nivelDependenciaBL.ObtenerNivelDependencias();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<InspeccionConocimientoDTO> inspeccionConocimientoDTO = inspeccionConocimientoBL.ObtenerInspeccionConocimientos();
            List<InspeccionExtensionDTO> inspeccionExtensionDTO = inspeccionExtensionBL.ObtenerInspeccionExtensions();
            List<InspeccionFinalidadDTO> inspeccionFinalidadDTO = inspeccionFinalidadBL.ObtenerInspeccionFinalidads();
            List<OrganoControlInspeccionDTO> organoControlInspeccionDTO = organoControlInspeccionBL.ObtenerOrganoControlInspeccions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InspeccionInstitucional");


            return Json(new { data1 = dependenciaDTO, data2 = comandanciaDependenciaDTO,  data3 = nivelDependenciaDTO, data4 = zonaNavalDTO,
                data5 = inspeccionConocimientoDTO,  data6 = inspeccionExtensionDTO,  data7 = inspeccionFinalidadDTO,  data8 = organoControlInspeccionDTO,  data9 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<InspeccionInstitucionalesDTO> select = inspeccionInstitucionalesBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string FechaInicioInspeccion, string FechaTerminoInspeccion, int DuracionInspeccion, string CodigoDependencia,
            string CodigoComandanciaDependencia, string CodigoNivelDependencia, string CodigoZonaNaval, string CodigoInspeccionConocimiento, string CodigoInspeccionExtension,
            string CodigoInspeccionFinalidad, string CodigoOrganoControlInspeccion, int QInspectorParticipante, int DeficienciaOperAdm, int DeficienciaComunesOperAdm,
            int ApreciacionOperAdm, int ObservacionOperAdm, int IrregularidadOperAdm, int DeficienciaControlGestion, int DeficienciaComunControlG,
            int ApreciacionControlGestion, int ObservacionControlGestion, int IrregularidadControlGestion, int DeficienciaPendOperAdm,
            int DeficienciaComunPendOperAdm, int ApreciacionPendOperAdm, int ObservacionPendOperAdm, int IrregularidadPendOperAdm,
            int DeficienciaPendControlGestion, int DeficienciaComunPendControlGestion, int ApreciacionPendControlGestion,
            int ObservacionPendControlGestion, int IrregularidadPendControlGestion, int DeficienciaSuperadaOperAdm, int DeficienciaComunSuperadaOperAdm,
            int ApreciacionSuperadaOperAdm, int ObservacionSuperadaOperAdm, int IrregularidadSuperadaOperAdm, int DeficienciaSuperadaControlGestion,
            int DeficienciaComunSuperadaControlGestion, int ApreciacionSuperadaControlGestion, int ObservacionSuperadaControlGestion, 
            int IrregularidadSuperadaControlGestion, int FTotalDeficiencias, int FTotalApreciaciones, int FTotalObservaciones,
            int FTotalIrregularidades, int FTotalDeficienciaSuperadas, int FTotalApreciacionSuperadas, int FTotalObservacionSuperadas, 
            int FTotalIrregularidadSuperadas, int FTotalDeficienciasPendientes, int FTotalApreciacionesPendientes, int FTotalObservacionPendientes,
            int FTotalIrregularidadPendientes, int CargaId)
        {
            InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO = new();
            inspeccionInstitucionalesDTO.FechaInicioInspeccion = FechaInicioInspeccion;
            inspeccionInstitucionalesDTO.FechaTerminoInspeccion = FechaTerminoInspeccion;
            inspeccionInstitucionalesDTO.DuracionInspeccion = DuracionInspeccion;
            inspeccionInstitucionalesDTO.CodigoDependencia = CodigoDependencia;
            inspeccionInstitucionalesDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            inspeccionInstitucionalesDTO.CodigoNivelDependencia = CodigoNivelDependencia;
            inspeccionInstitucionalesDTO.CodigoZonaNaval = CodigoZonaNaval;
            inspeccionInstitucionalesDTO.CodigoInspeccionConocimiento = CodigoInspeccionConocimiento;
            inspeccionInstitucionalesDTO.CodigoInspeccionExtension = CodigoInspeccionExtension;
            inspeccionInstitucionalesDTO.CodigoInspeccionFinalidad = CodigoInspeccionFinalidad;
            inspeccionInstitucionalesDTO.CodigoOrganoControlInspeccion = CodigoOrganoControlInspeccion;
            inspeccionInstitucionalesDTO.QInspectorParticipante = QInspectorParticipante;
            inspeccionInstitucionalesDTO.DeficienciaOperAdm = DeficienciaOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaComunesOperAdm = DeficienciaComunesOperAdm;
            inspeccionInstitucionalesDTO.ApreciacionOperAdm = ApreciacionOperAdm;
            inspeccionInstitucionalesDTO.ObservacionOperAdm = ObservacionOperAdm;
            inspeccionInstitucionalesDTO.IrregularidadOperAdm = IrregularidadOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaControlGestion = DeficienciaControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaComunControlG = DeficienciaComunControlG;
            inspeccionInstitucionalesDTO.ApreciacionControlGestion = ApreciacionControlGestion;
            inspeccionInstitucionalesDTO.ObservacionControlGestion = ObservacionControlGestion;
            inspeccionInstitucionalesDTO.IrregularidadControlGestion = IrregularidadControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaPendOperAdm = DeficienciaPendOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaComunPendOperAdm = DeficienciaComunPendOperAdm;
            inspeccionInstitucionalesDTO.ApreciacionPendOperAdm = ApreciacionPendOperAdm;
            inspeccionInstitucionalesDTO.ObservacionPendOperAdm = ObservacionPendOperAdm;
            inspeccionInstitucionalesDTO.IrregularidadPendOperAdm = IrregularidadPendOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaPendControlGestion = DeficienciaPendControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaComunPendControlGestion = DeficienciaComunPendControlGestion;
            inspeccionInstitucionalesDTO.ApreciacionPendControlGestion = ApreciacionPendControlGestion;
            inspeccionInstitucionalesDTO.ObservacionPendControlGestion = ObservacionPendControlGestion;
            inspeccionInstitucionalesDTO.IrregularidadPendControlGestion = IrregularidadPendControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaSuperadaOperAdm = DeficienciaSuperadaOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaComunSuperadaOperAdm = DeficienciaComunSuperadaOperAdm;
            inspeccionInstitucionalesDTO.ApreciacionSuperadaOperAdm = ApreciacionSuperadaOperAdm;
            inspeccionInstitucionalesDTO.ObservacionSuperadaOperAdm = ObservacionSuperadaOperAdm;
            inspeccionInstitucionalesDTO.IrregularidadSuperadaOperAdm = IrregularidadSuperadaOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaSuperadaControlGestion = DeficienciaSuperadaControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaComunSuperadaControlGestion = DeficienciaComunSuperadaControlGestion;
            inspeccionInstitucionalesDTO.ApreciacionSuperadaControlGestion = ApreciacionSuperadaControlGestion;
            inspeccionInstitucionalesDTO.ObservacionSuperadaControlGestion = ObservacionSuperadaControlGestion;
            inspeccionInstitucionalesDTO.IrregularidadSuperadaControlGestion = IrregularidadSuperadaControlGestion;
            inspeccionInstitucionalesDTO.FTotalDeficiencias = FTotalDeficiencias;
            inspeccionInstitucionalesDTO.FTotalApreciaciones = FTotalApreciaciones;
            inspeccionInstitucionalesDTO.FTotalObservaciones = FTotalObservaciones;
            inspeccionInstitucionalesDTO.FTotalIrregularidades = FTotalIrregularidades;
            inspeccionInstitucionalesDTO.FTotalDeficienciaSuperadas = FTotalDeficienciaSuperadas;
            inspeccionInstitucionalesDTO.FTotalApreciacionSuperadas = FTotalApreciacionSuperadas;
            inspeccionInstitucionalesDTO.FTotalObservacionSuperadas = FTotalObservacionSuperadas;
            inspeccionInstitucionalesDTO.FTotalIrregularidadSuperadas = FTotalIrregularidadSuperadas;
            inspeccionInstitucionalesDTO.FTotalDeficienciasPendientes = FTotalDeficienciasPendientes;
            inspeccionInstitucionalesDTO.FTotalApreciacionesPendientes = FTotalApreciacionesPendientes;
            inspeccionInstitucionalesDTO.FTotalObservacionPendientes = FTotalObservacionPendientes;
            inspeccionInstitucionalesDTO.FTotalIrregularidadPendientes = FTotalIrregularidadPendientes;
            inspeccionInstitucionalesDTO.CargaId = CargaId;
            inspeccionInstitucionalesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionInstitucionalesBL.AgregarRegistro(inspeccionInstitucionalesDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(inspeccionInstitucionalesBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaInicioInspeccion, string FechaTerminoInspeccion, int DuracionInspeccion, string CodigoDependencia,
            string CodigoComandanciaDependencia, string CodigoNivelDependencia, string CodigoZonaNaval, string CodigoInspeccionConocimiento, string CodigoInspeccionExtension,
            string CodigoInspeccionFinalidad, string CodigoOrganoControlInspeccion, int QInspectorParticipante, int DeficienciaOperAdm,
            int DeficienciaComunesOperAdm, int ApreciacionOperAdm, int ObservacionOperAdm, int IrregularidadOperAdm, int DeficienciaControlGestion,
            int DeficienciaComunControlG, int ApreciacionControlGestion, int ObservacionControlGestion, int IrregularidadControlGestion, 
            int DeficienciaPendOperAdm, int DeficienciaComunPendOperAdm, int ApreciacionPendOperAdm, int ObservacionPendOperAdm,
            int IrregularidadPendOperAdm, int DeficienciaPendControlGestion, int DeficienciaComunPendControlGestion, int ApreciacionPendControlGestion,
            int ObservacionPendControlGestion, int IrregularidadPendControlGestion, int DeficienciaSuperadaOperAdm, int DeficienciaComunSuperadaOperAdm,
            int ApreciacionSuperadaOperAdm, int ObservacionSuperadaOperAdm, int IrregularidadSuperadaOperAdm, int DeficienciaSuperadaControlGestion,
            int DeficienciaComunSuperadaControlGestion, int ApreciacionSuperadaControlGestion, int ObservacionSuperadaControlGestion, 
            int IrregularidadSuperadaControlGestion, int FTotalDeficiencias, int FTotalApreciaciones, int FTotalObservaciones, 
            int FTotalIrregularidades, int FTotalDeficienciaSuperadas, int FTotalApreciacionSuperadas, int FTotalObservacionSuperadas, 
            int FTotalIrregularidadSuperadas, int FTotalDeficienciasPendientes, int FTotalApreciacionesPendientes, int FTotalObservacionPendientes,
            int FTotalIrregularidadPendientes)
        {
            InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO = new();
            inspeccionInstitucionalesDTO.InspeccionInstitucionalId = Id;
            inspeccionInstitucionalesDTO.FechaInicioInspeccion = FechaInicioInspeccion;
            inspeccionInstitucionalesDTO.FechaTerminoInspeccion = FechaTerminoInspeccion;
            inspeccionInstitucionalesDTO.DuracionInspeccion = DuracionInspeccion;
            inspeccionInstitucionalesDTO.CodigoDependencia = CodigoDependencia;
            inspeccionInstitucionalesDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            inspeccionInstitucionalesDTO.CodigoNivelDependencia = CodigoNivelDependencia;
            inspeccionInstitucionalesDTO.CodigoZonaNaval = CodigoZonaNaval;
            inspeccionInstitucionalesDTO.CodigoInspeccionConocimiento = CodigoInspeccionConocimiento;
            inspeccionInstitucionalesDTO.CodigoInspeccionExtension = CodigoInspeccionExtension;
            inspeccionInstitucionalesDTO.CodigoInspeccionFinalidad = CodigoInspeccionFinalidad;
            inspeccionInstitucionalesDTO.CodigoOrganoControlInspeccion = CodigoOrganoControlInspeccion;
            inspeccionInstitucionalesDTO.QInspectorParticipante = QInspectorParticipante;
            inspeccionInstitucionalesDTO.DeficienciaOperAdm = DeficienciaOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaComunesOperAdm = DeficienciaComunesOperAdm;
            inspeccionInstitucionalesDTO.ApreciacionOperAdm = ApreciacionOperAdm;
            inspeccionInstitucionalesDTO.ObservacionOperAdm = ObservacionOperAdm;
            inspeccionInstitucionalesDTO.IrregularidadOperAdm = IrregularidadOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaControlGestion = DeficienciaControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaComunControlG = DeficienciaComunControlG;
            inspeccionInstitucionalesDTO.ApreciacionControlGestion = ApreciacionControlGestion;
            inspeccionInstitucionalesDTO.ObservacionControlGestion = ObservacionControlGestion;
            inspeccionInstitucionalesDTO.IrregularidadControlGestion = IrregularidadControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaPendOperAdm = DeficienciaPendOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaComunPendOperAdm = DeficienciaComunPendOperAdm;
            inspeccionInstitucionalesDTO.ApreciacionPendOperAdm = ApreciacionPendOperAdm;
            inspeccionInstitucionalesDTO.ObservacionPendOperAdm = ObservacionPendOperAdm;
            inspeccionInstitucionalesDTO.IrregularidadPendOperAdm = IrregularidadPendOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaPendControlGestion = DeficienciaPendControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaComunPendControlGestion = DeficienciaComunPendControlGestion;
            inspeccionInstitucionalesDTO.ApreciacionPendControlGestion = ApreciacionPendControlGestion;
            inspeccionInstitucionalesDTO.ObservacionPendControlGestion = ObservacionPendControlGestion;
            inspeccionInstitucionalesDTO.IrregularidadPendControlGestion = IrregularidadPendControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaSuperadaOperAdm = DeficienciaSuperadaOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaComunSuperadaOperAdm = DeficienciaComunSuperadaOperAdm;
            inspeccionInstitucionalesDTO.ApreciacionSuperadaOperAdm = ApreciacionSuperadaOperAdm;
            inspeccionInstitucionalesDTO.ObservacionSuperadaOperAdm = ObservacionSuperadaOperAdm;
            inspeccionInstitucionalesDTO.IrregularidadSuperadaOperAdm = IrregularidadSuperadaOperAdm;
            inspeccionInstitucionalesDTO.DeficienciaSuperadaControlGestion = DeficienciaSuperadaControlGestion;
            inspeccionInstitucionalesDTO.DeficienciaComunSuperadaControlGestion = DeficienciaComunSuperadaControlGestion;
            inspeccionInstitucionalesDTO.ApreciacionSuperadaControlGestion = ApreciacionSuperadaControlGestion;
            inspeccionInstitucionalesDTO.ObservacionSuperadaControlGestion = ObservacionSuperadaControlGestion;
            inspeccionInstitucionalesDTO.IrregularidadSuperadaControlGestion = IrregularidadSuperadaControlGestion;
            inspeccionInstitucionalesDTO.FTotalDeficiencias = FTotalDeficiencias;
            inspeccionInstitucionalesDTO.FTotalApreciaciones = FTotalApreciaciones;
            inspeccionInstitucionalesDTO.FTotalObservaciones = FTotalObservaciones;
            inspeccionInstitucionalesDTO.FTotalIrregularidades = FTotalIrregularidades;
            inspeccionInstitucionalesDTO.FTotalDeficienciaSuperadas = FTotalDeficienciaSuperadas;
            inspeccionInstitucionalesDTO.FTotalApreciacionSuperadas = FTotalApreciacionSuperadas;
            inspeccionInstitucionalesDTO.FTotalObservacionSuperadas = FTotalObservacionSuperadas;
            inspeccionInstitucionalesDTO.FTotalIrregularidadSuperadas = FTotalIrregularidadSuperadas;
            inspeccionInstitucionalesDTO.FTotalDeficienciasPendientes = FTotalDeficienciasPendientes;
            inspeccionInstitucionalesDTO.FTotalApreciacionesPendientes = FTotalApreciacionesPendientes;
            inspeccionInstitucionalesDTO.FTotalObservacionPendientes = FTotalObservacionPendientes;
            inspeccionInstitucionalesDTO.FTotalIrregularidadPendientes = FTotalIrregularidadPendientes;
            inspeccionInstitucionalesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inspeccionInstitucionalesBL.ActualizarFormato(inspeccionInstitucionalesDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InspeccionInstitucionalesDTO inspeccionInstitucionalesDTO = new();
            inspeccionInstitucionalesDTO.InspeccionInstitucionalId = Id;
            inspeccionInstitucionalesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (inspeccionInstitucionalesBL.EliminarFormato(inspeccionInstitucionalesDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InspeccionInstitucionalesDTO> lista = new List<InspeccionInstitucionalesDTO>();
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

                    lista.Add(new InspeccionInstitucionalesDTO
                    {
                        FechaInicioInspeccion = fila.GetCell(0).ToString(),
                        FechaTerminoInspeccion = fila.GetCell(1).ToString(),
                        DuracionInspeccion = int.Parse(fila.GetCell(2).ToString()),
                        CodigoDependencia = fila.GetCell(3).ToString(),
                        CodigoComandanciaDependencia = fila.GetCell(4).ToString(),
                        CodigoNivelDependencia = fila.GetCell(5).ToString(),
                        CodigoZonaNaval = fila.GetCell(6).ToString(),
                        CodigoInspeccionConocimiento = fila.GetCell(7).ToString(),
                        CodigoInspeccionExtension = fila.GetCell(8).ToString(),
                        CodigoInspeccionFinalidad = fila.GetCell(9).ToString(),
                        CodigoOrganoControlInspeccion = fila.GetCell(10).ToString(),
                        QInspectorParticipante = int.Parse(fila.GetCell(11).ToString()),
                        DeficienciaOperAdm = int.Parse(fila.GetCell(12).ToString()),
                        DeficienciaComunesOperAdm = int.Parse(fila.GetCell(13).ToString()),
                        ApreciacionOperAdm = int.Parse(fila.GetCell(14).ToString()),
                        ObservacionOperAdm = int.Parse(fila.GetCell(15).ToString()),
                        IrregularidadOperAdm = int.Parse(fila.GetCell(16).ToString()),
                        DeficienciaControlGestion = int.Parse(fila.GetCell(17).ToString()),
                        DeficienciaComunControlG = int.Parse(fila.GetCell(18).ToString()),
                        ApreciacionControlGestion = int.Parse(fila.GetCell(19).ToString()),
                        ObservacionControlGestion = int.Parse(fila.GetCell(20).ToString()),
                        IrregularidadControlGestion = int.Parse(fila.GetCell(21).ToString()),
                        DeficienciaPendOperAdm = int.Parse(fila.GetCell(22).ToString()),
                        DeficienciaComunPendOperAdm = int.Parse(fila.GetCell(23).ToString()),
                        ApreciacionPendOperAdm = int.Parse(fila.GetCell(24).ToString()),
                        ObservacionPendOperAdm = int.Parse(fila.GetCell(25).ToString()),
                        IrregularidadPendOperAdm = int.Parse(fila.GetCell(26).ToString()),
                        DeficienciaPendControlGestion = int.Parse(fila.GetCell(27).ToString()),
                        DeficienciaComunPendControlGestion = int.Parse(fila.GetCell(28).ToString()),
                        ApreciacionPendControlGestion = int.Parse(fila.GetCell(29).ToString()),
                        ObservacionPendControlGestion = int.Parse(fila.GetCell(30).ToString()),
                        IrregularidadPendControlGestion = int.Parse(fila.GetCell(31).ToString()),
                        DeficienciaSuperadaOperAdm = int.Parse(fila.GetCell(32).ToString()),
                        DeficienciaComunSuperadaOperAdm = int.Parse(fila.GetCell(33).ToString()),
                        ApreciacionSuperadaOperAdm = int.Parse(fila.GetCell(34).ToString()),
                        ObservacionSuperadaOperAdm = int.Parse(fila.GetCell(35).ToString()),
                        IrregularidadSuperadaOperAdm = int.Parse(fila.GetCell(36).ToString()),
                        DeficienciaSuperadaControlGestion = int.Parse(fila.GetCell(37).ToString()),
                        DeficienciaComunSuperadaControlGestion = int.Parse(fila.GetCell(38).ToString()),
                        ApreciacionSuperadaControlGestion = int.Parse(fila.GetCell(39).ToString()),
                        ObservacionSuperadaControlGestion = int.Parse(fila.GetCell(40).ToString()),
                        IrregularidadSuperadaControlGestion = int.Parse(fila.GetCell(41).ToString()),
                        FTotalDeficiencias = int.Parse(fila.GetCell(42).ToString()),
                        FTotalApreciaciones = int.Parse(fila.GetCell(43).ToString()),
                        FTotalObservaciones = int.Parse(fila.GetCell(44).ToString()),
                        FTotalIrregularidades = int.Parse(fila.GetCell(45).ToString()),
                        FTotalDeficienciaSuperadas = int.Parse(fila.GetCell(46).ToString()),
                        FTotalApreciacionSuperadas = int.Parse(fila.GetCell(47).ToString()),
                        FTotalObservacionSuperadas = int.Parse(fila.GetCell(48).ToString()),
                        FTotalIrregularidadSuperadas = int.Parse(fila.GetCell(49).ToString()),
                        FTotalDeficienciasPendientes = int.Parse(fila.GetCell(50).ToString()),
                        FTotalApreciacionesPendientes = int.Parse(fila.GetCell(51).ToString()),
                        FTotalObservacionPendientes = int.Parse(fila.GetCell(52).ToString()),
                        FTotalIrregularidadPendientes = int.Parse(fila.GetCell(53).ToString())
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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

            dt.Columns.AddRange(new DataColumn[55]
            {
                   new DataColumn("FechaInicioInspeccion", typeof(string)),
                    new DataColumn("FechaTerminoInspeccion", typeof(string)),
                    new DataColumn("DuracionInspeccion", typeof(int)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("CodigoNivelDependencia", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoInspeccionConocimiento", typeof(string)),
                    new DataColumn("CodigoInspeccionExtension", typeof(string)),
                    new DataColumn("CodigoInspeccionFinalidad", typeof(string)),
                    new DataColumn("CodigoOrganoControlInspeccion", typeof(string)),
                    new DataColumn("QInspectorParticipante", typeof(int)),
                    new DataColumn("DeficienciaOperAdm", typeof(int)),
                    new DataColumn("DeficienciaComunesOperAdm", typeof(int)),
                    new DataColumn("ApreciacionOperAdm", typeof(int)),
                    new DataColumn("ObservacionOperAdm", typeof(int)),
                    new DataColumn("IrregularidadOperAdm", typeof(int)),
                    new DataColumn("DeficienciaControlGestion", typeof(int)),
                    new DataColumn("DeficienciaComunControlG", typeof(int)),
                    new DataColumn("ApreciacionControlGestion", typeof(int)),
                    new DataColumn("ObservacionControlGestion", typeof(int)),
                    new DataColumn("IrregularidadControlGestion", typeof(int)),
                    new DataColumn("DeficienciaPendOperAdm", typeof(int)),
                    new DataColumn("DeficienciaComunPendOperAdm", typeof(int)),
                    new DataColumn("ApreciacionPendOperAdm", typeof(int)),
                    new DataColumn("ObservacionPendOperAdm", typeof(int)),
                    new DataColumn("IrregularidadPendOperAdm", typeof(int)),
                    new DataColumn("DeficienciaPendControlGestion", typeof(int)),
                    new DataColumn("DeficienciaComunPendControlGestion", typeof(int)),
                    new DataColumn("ApreciacionPendControlGestion", typeof(int)),
                    new DataColumn("ObservacionPendControlGestion", typeof(int)),
                    new DataColumn("IrregularidadPendControlGestion", typeof(int)),
                    new DataColumn("DeficienciaSuperadaOperAdm", typeof(int)),
                    new DataColumn("DeficienciaComunSuperadaOperAdm", typeof(int)),
                    new DataColumn("ApreciacionSuperadaOperAdm", typeof(int)),
                    new DataColumn("ObservacionSuperadaOperAdm", typeof(int)),
                    new DataColumn("IrregularidadSuperadaOperAdm", typeof(int)),
                    new DataColumn("DeficienciaSuperadaControlGestion", typeof(int)),
                    new DataColumn("DeficienciaComunSuperadaControlGestion", typeof(int)),
                    new DataColumn("ApreciacionSuperadaControlGestion", typeof(int)),
                    new DataColumn("ObservacionSuperadaControlGestion", typeof(int)),
                    new DataColumn("IrregularidadSuperadaControlGestion", typeof(int)),
                    new DataColumn("FTotalDeficiencias", typeof(int)),
                    new DataColumn("FTotalApreciaciones", typeof(int)),
                    new DataColumn("FTotalObservaciones", typeof(int)),
                    new DataColumn("FTotalIrregularidades", typeof(int)),
                    new DataColumn("FTotalDeficienciaSuperadas", typeof(int)),
                    new DataColumn("FTotalApreciacionSuperadas", typeof(int)),
                    new DataColumn("FTotalObservacionSuperadas", typeof(int)),
                    new DataColumn("FTotalIrregularidadSuperadas", typeof(int)),
                    new DataColumn("FTotalDeficienciasPendientes", typeof(int)),
                    new DataColumn("FTotalApreciacionesPendientes", typeof(int)),
                    new DataColumn("FTotalObservacionPendientes", typeof(int)),
                    new DataColumn("FTotalIrregularidadPendientes", typeof(int)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    int.Parse(fila.GetCell(13).ToString()),
                    int.Parse(fila.GetCell(14).ToString()),
                    int.Parse(fila.GetCell(15).ToString()),
                    int.Parse(fila.GetCell(16).ToString()),
                    int.Parse(fila.GetCell(17).ToString()),
                    int.Parse(fila.GetCell(18).ToString()),
                    int.Parse(fila.GetCell(19).ToString()),
                    int.Parse(fila.GetCell(20).ToString()),
                    int.Parse(fila.GetCell(21).ToString()),
                    int.Parse(fila.GetCell(22).ToString()),
                    int.Parse(fila.GetCell(23).ToString()),
                    int.Parse(fila.GetCell(24).ToString()),
                    int.Parse(fila.GetCell(25).ToString()),
                    int.Parse(fila.GetCell(26).ToString()),
                    int.Parse(fila.GetCell(27).ToString()),
                    int.Parse(fila.GetCell(28).ToString()),
                    int.Parse(fila.GetCell(29).ToString()),
                    int.Parse(fila.GetCell(30).ToString()),
                    int.Parse(fila.GetCell(31).ToString()),
                    int.Parse(fila.GetCell(32).ToString()),
                    int.Parse(fila.GetCell(33).ToString()),
                    int.Parse(fila.GetCell(34).ToString()),
                    int.Parse(fila.GetCell(35).ToString()),
                    int.Parse(fila.GetCell(36).ToString()),
                    int.Parse(fila.GetCell(37).ToString()),
                    int.Parse(fila.GetCell(38).ToString()),
                    int.Parse(fila.GetCell(39).ToString()),
                    int.Parse(fila.GetCell(40).ToString()),
                    int.Parse(fila.GetCell(41).ToString()),
                    int.Parse(fila.GetCell(42).ToString()),
                    int.Parse(fila.GetCell(43).ToString()),
                    int.Parse(fila.GetCell(44).ToString()),
                    int.Parse(fila.GetCell(45).ToString()),
                    int.Parse(fila.GetCell(46).ToString()),
                    int.Parse(fila.GetCell(47).ToString()),
                    int.Parse(fila.GetCell(48).ToString()),
                    int.Parse(fila.GetCell(49).ToString()),
                    int.Parse(fila.GetCell(50).ToString()),
                    int.Parse(fila.GetCell(51).ToString()),
                    int.Parse(fila.GetCell(52).ToString()),
                    int.Parse(fila.GetCell(53).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = inspeccionInstitucionalesBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = inspeccionInstitucionalesBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IpecamarInspeccionInstitucionales.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IpecamarInspeccionInstitucionales.xlsx");
        }
    }

}

