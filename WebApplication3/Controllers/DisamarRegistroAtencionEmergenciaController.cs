using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Disamar;
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

    public class DisamarRegistroAtencionEmergenciaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroAtencionEmergencia registroAtencionEmergenciaBL = new();
        EntidadMilitar entidadMilitarBL = new();
        ZonaNaval zonaNavalBL = new();
        EstablecimientoSaludMGP establecimientoSaludMGPBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        EspecialidadMedicaNoMedica especialidadMedicaNoMedicaBL = new();
        UnidadDependencia unidadDependenciaBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        MotivoEmergencia motivoEmergenciaBL = new();
        CondicionAlta condicionAltaBL = new();
        DestinoPaciente destinoPacienteBL = new();
        Carga cargaBL = new();

        public DisamarRegistroAtencionEmergenciaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro de atención en emergencia", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadMilitarBL.ObtenerEntidadMilitars();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<EstablecimientoSaludMGPDTO> establecimientoSaludMGPDTO = establecimientoSaludMGPBL.ObtenerEstablecimientoSaludMGPs();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<EspecialidadMedicaNoMedicaDTO> especialidadMedicaNoMedicaDTO = especialidadMedicaNoMedicaBL.ObtenerEspecialidadMedicaNoMedicas();
            List<UnidadDependenciaDTO> unidadDependenciaDTO = unidadDependenciaBL.ObtenerUnidadDependencias();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<MotivoEmergenciaDTO> motivoEmergenciaDTO = motivoEmergenciaBL.ObtenerMotivoEmergencias();
            List<CondicionAltaDTO> condicionAltaDTO = condicionAltaBL.ObtenerCondicionAltas();
            List<DestinoPacienteDTO> destinoPacienteDTO = destinoPacienteBL.ObtenerDestinoPacientes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroAtencionEmergencia");

            return Json(new
            {
                data1 = entidadMilitarDTO,
                data2 = zonaNavalDTO,
                data3 = establecimientoSaludMGPDTO,
                data4 = departamentoUbigeoDTO,
                data5 = provinciaUbigeoDTO,
                data6 = distritoUbigeoDTO,
                data7 = especialidadMedicaNoMedicaDTO,
                data8 = unidadDependenciaDTO,
                data9 = tipoPersonalMilitarDTO,
                data10 = gradoPersonalMilitarDTO,
                data11 = motivoEmergenciaDTO,
                data12 = condicionAltaDTO,
                data13 = destinoPacienteDTO,
                data14 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroAtencionEmergenciaDTO> select = registroAtencionEmergenciaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string FechaAtencion, string HoraAtencion,
            string DistritoUbigeo, string CodigoUPS, string ResponsableRegistro, int NSACIP, int CMP, string Turno, string HoraInicio, 
            string HoraFin, int HistoriaClinica, string DNIPaciente, string CodigoUnidadNaval, string DistritoPaciente, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, 
            string SituacionPaciente, string CondicionPaciente, int EdadPaciente, string TipoEdad, string SexoPaciente, string DiagnosticoMotivoAtencion1, string TipoDX1, 
            string CIE10_1, string DiagnosticoMotivoAtencion2, string TipoDX2, string CIE10_2, string DiagnosticoMotivoAtencion3, string TipoDX3,
            string CIE10_3, string DiagnosticoMotivoAtencion4, string TipoDX4,  string CIE10_4, string DiagnosticoMotivoAtencion5, string TipoDX5, string CIE10_5,
            string DiagnosticoMotivoAtencion6, string TipoDX6,  string CIE10_6, string TipoEmergencia, string Interconsulta, int EspecialidadMedicaInterconsulta,
            string CodigoMotivoEmergencia, string Acompaniante, string DNIAcompaniante, string CodigoCondicionAlta, string CodigoDestinoPaciente,int CargaId)
        {
            RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO = new();
            registroAtencionEmergenciaDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroAtencionEmergenciaDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroAtencionEmergenciaDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroAtencionEmergenciaDTO.FechaAtencion = FechaAtencion;
            registroAtencionEmergenciaDTO.HoraAtencion = HoraAtencion;
            registroAtencionEmergenciaDTO.DistritoUbigeo = DistritoUbigeo;
            registroAtencionEmergenciaDTO.CodigoUPS = CodigoUPS;
            registroAtencionEmergenciaDTO.ResponsableRegistro = ResponsableRegistro;
            registroAtencionEmergenciaDTO.NSACIP = NSACIP;
            registroAtencionEmergenciaDTO.CMP = CMP;
            registroAtencionEmergenciaDTO.Turno = Turno;
            registroAtencionEmergenciaDTO.HoraInicio = HoraInicio;
            registroAtencionEmergenciaDTO.HoraFin = HoraFin;
            registroAtencionEmergenciaDTO.HistoriaClinica = HistoriaClinica;
            registroAtencionEmergenciaDTO.DNIPaciente = DNIPaciente;
            registroAtencionEmergenciaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            registroAtencionEmergenciaDTO.DistritoPaciente = DistritoPaciente;
            registroAtencionEmergenciaDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroAtencionEmergenciaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroAtencionEmergenciaDTO.SituacionPaciente = SituacionPaciente;
            registroAtencionEmergenciaDTO.CondicionPaciente = CondicionPaciente;
            registroAtencionEmergenciaDTO.EdadPaciente = EdadPaciente;
            registroAtencionEmergenciaDTO.TipoEdad = TipoEdad;
            registroAtencionEmergenciaDTO.SexoPaciente = SexoPaciente;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion1 = DiagnosticoMotivoAtencion1;
            registroAtencionEmergenciaDTO.TipoDX1 = TipoDX1;
            registroAtencionEmergenciaDTO.CIE10_1 = CIE10_1;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion2 = DiagnosticoMotivoAtencion2;
            registroAtencionEmergenciaDTO.TipoDX2 = TipoDX2;
            registroAtencionEmergenciaDTO.CIE10_2 = CIE10_2;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion3 = DiagnosticoMotivoAtencion3;
            registroAtencionEmergenciaDTO.TipoDX3 = TipoDX3;
            registroAtencionEmergenciaDTO.CIE10_3 = CIE10_3;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion4 = DiagnosticoMotivoAtencion4;
            registroAtencionEmergenciaDTO.TipoDX4 = TipoDX4;
            registroAtencionEmergenciaDTO.CIE10_4 = CIE10_4;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion5 = DiagnosticoMotivoAtencion5;
            registroAtencionEmergenciaDTO.TipoDX5 = TipoDX5;
            registroAtencionEmergenciaDTO.CIE10_5 = CIE10_5;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion6 = DiagnosticoMotivoAtencion6;
            registroAtencionEmergenciaDTO.TipoDX6 = TipoDX6;
            registroAtencionEmergenciaDTO.CIE10_6 = CIE10_6;
            registroAtencionEmergenciaDTO.TipoEmergencia = TipoEmergencia;
            registroAtencionEmergenciaDTO.Interconsulta = Interconsulta;
            registroAtencionEmergenciaDTO.EspecialidadMedicaInterconsulta = EspecialidadMedicaInterconsulta;
            registroAtencionEmergenciaDTO.CodigoMotivoEmergencia = CodigoMotivoEmergencia;
            registroAtencionEmergenciaDTO.Acompaniante = Acompaniante;
            registroAtencionEmergenciaDTO.DNIAcompaniante = DNIAcompaniante;
            registroAtencionEmergenciaDTO.CodigoCondicionAlta = CodigoCondicionAlta;
            registroAtencionEmergenciaDTO.CodigoDestinoPaciente = CodigoDestinoPaciente;
            registroAtencionEmergenciaDTO.CargaId = CargaId;
            
            registroAtencionEmergenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroAtencionEmergenciaBL.AgregarRegistro(registroAtencionEmergenciaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroAtencionEmergenciaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string FechaAtencion, string HoraAtencion,
            string DistritoUbigeo, string CodigoUPS, string ResponsableRegistro, int NSACIP, int CMP, string Turno, string HoraInicio,
            string HoraFin, int HistoriaClinica, string DNIPaciente, string CodigoUnidadNaval, string DistritoPaciente, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar,
            string SituacionPaciente, string CondicionPaciente, int EdadPaciente, string TipoEdad, string SexoPaciente, string DiagnosticoMotivoAtencion1, string TipoDX1,
            string CIE10_1, string DiagnosticoMotivoAtencion2, string TipoDX2, string CIE10_2, string DiagnosticoMotivoAtencion3, string TipoDX3,
            string CIE10_3, string DiagnosticoMotivoAtencion4, string TipoDX4, string CIE10_4, string DiagnosticoMotivoAtencion5, string TipoDX5, string CIE10_5,
            string DiagnosticoMotivoAtencion6, string TipoDX6, string CIE10_6, string TipoEmergencia, string Interconsulta, int EspecialidadMedicaInterconsulta,
            string CodigoMotivoEmergencia, string Acompaniante, string DNIAcompaniante, string CodigoCondicionAlta, string CodigoDestinoPaciente)
        {
            RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO = new();
            registroAtencionEmergenciaDTO.RegistroAtencionEmergenciaId = Id;
            registroAtencionEmergenciaDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroAtencionEmergenciaDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroAtencionEmergenciaDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroAtencionEmergenciaDTO.FechaAtencion = FechaAtencion;
            registroAtencionEmergenciaDTO.HoraAtencion = HoraAtencion;
            registroAtencionEmergenciaDTO.DistritoUbigeo = DistritoUbigeo;
            registroAtencionEmergenciaDTO.CodigoUPS = CodigoUPS;
            registroAtencionEmergenciaDTO.ResponsableRegistro = ResponsableRegistro;
            registroAtencionEmergenciaDTO.NSACIP = NSACIP;
            registroAtencionEmergenciaDTO.CMP = CMP;
            registroAtencionEmergenciaDTO.Turno = Turno;
            registroAtencionEmergenciaDTO.HoraInicio = HoraInicio;
            registroAtencionEmergenciaDTO.HoraFin = HoraFin;
            registroAtencionEmergenciaDTO.HistoriaClinica = HistoriaClinica;
            registroAtencionEmergenciaDTO.DNIPaciente = DNIPaciente;
            registroAtencionEmergenciaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            registroAtencionEmergenciaDTO.DistritoPaciente = DistritoPaciente;
            registroAtencionEmergenciaDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroAtencionEmergenciaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroAtencionEmergenciaDTO.SituacionPaciente = SituacionPaciente;
            registroAtencionEmergenciaDTO.CondicionPaciente = CondicionPaciente;
            registroAtencionEmergenciaDTO.EdadPaciente = EdadPaciente;
            registroAtencionEmergenciaDTO.TipoEdad = TipoEdad;
            registroAtencionEmergenciaDTO.SexoPaciente = SexoPaciente;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion1 = DiagnosticoMotivoAtencion1;
            registroAtencionEmergenciaDTO.TipoDX1 = TipoDX1;
            registroAtencionEmergenciaDTO.CIE10_1 = CIE10_1;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion2 = DiagnosticoMotivoAtencion2;
            registroAtencionEmergenciaDTO.TipoDX2 = TipoDX2;
            registroAtencionEmergenciaDTO.CIE10_2 = CIE10_2;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion3 = DiagnosticoMotivoAtencion3;
            registroAtencionEmergenciaDTO.TipoDX3 = TipoDX3;
            registroAtencionEmergenciaDTO.CIE10_3 = CIE10_3;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion4 = DiagnosticoMotivoAtencion4;
            registroAtencionEmergenciaDTO.TipoDX4 = TipoDX4;
            registroAtencionEmergenciaDTO.CIE10_4 = CIE10_4;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion5 = DiagnosticoMotivoAtencion5;
            registroAtencionEmergenciaDTO.TipoDX5 = TipoDX5;
            registroAtencionEmergenciaDTO.CIE10_5 = CIE10_5;
            registroAtencionEmergenciaDTO.DiagnosticoMotivoAtencion6 = DiagnosticoMotivoAtencion6;
            registroAtencionEmergenciaDTO.TipoDX6 = TipoDX6;
            registroAtencionEmergenciaDTO.CIE10_6 = CIE10_6;
            registroAtencionEmergenciaDTO.TipoEmergencia = TipoEmergencia;
            registroAtencionEmergenciaDTO.Interconsulta = Interconsulta;
            registroAtencionEmergenciaDTO.EspecialidadMedicaInterconsulta = EspecialidadMedicaInterconsulta;
            registroAtencionEmergenciaDTO.CodigoMotivoEmergencia = CodigoMotivoEmergencia;
            registroAtencionEmergenciaDTO.Acompaniante = Acompaniante;
            registroAtencionEmergenciaDTO.DNIAcompaniante = DNIAcompaniante;
            registroAtencionEmergenciaDTO.CodigoCondicionAlta = CodigoCondicionAlta;
            registroAtencionEmergenciaDTO.CodigoDestinoPaciente = CodigoDestinoPaciente;
            
            registroAtencionEmergenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroAtencionEmergenciaBL.ActualizarFormato(registroAtencionEmergenciaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO = new();
            registroAtencionEmergenciaDTO.RegistroAtencionEmergenciaId = Id;
            registroAtencionEmergenciaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroAtencionEmergenciaBL.EliminarFormato(registroAtencionEmergenciaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroAtencionEmergenciaDTO> lista = new List<RegistroAtencionEmergenciaDTO>();
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

                    lista.Add(new RegistroAtencionEmergenciaDTO
                    {
                        CodigoEntidadMilitar = fila.GetCell(0).ToString(),
                        CodigoZonaNaval = fila.GetCell(1).ToString(),
                        CodigoEstablecimientoSaludMGP = fila.GetCell(2).ToString(),
                        FechaAtencion = fila.GetCell(3).ToString(),
                        HoraAtencion = fila.GetCell(4).ToString(),
                        DistritoUbigeo = fila.GetCell(5).ToString(),
                        CodigoUPS = fila.GetCell(6).ToString(),
                        ResponsableRegistro = fila.GetCell(7).ToString(),
                        NSACIP = int.Parse(fila.GetCell(8).ToString()),
                        CMP = int.Parse(fila.GetCell(9).ToString()),
                        Turno = fila.GetCell(10).ToString(),
                        HoraInicio = fila.GetCell(11).ToString(),
                        HoraFin = fila.GetCell(12).ToString(),
                        HistoriaClinica = int.Parse(fila.GetCell(13).ToString()),
                        DNIPaciente = fila.GetCell(14).ToString(),
                        CodigoUnidadNaval = fila.GetCell(15).ToString(),
                        DistritoPaciente = fila.GetCell(16).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(17).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(18).ToString(),
                        SituacionPaciente = fila.GetCell(19).ToString(),
                        CondicionPaciente = fila.GetCell(20).ToString(),
                        EdadPaciente = int.Parse(fila.GetCell(21).ToString()),
                        TipoEdad = fila.GetCell(22).ToString(),
                        SexoPaciente = fila.GetCell(23).ToString(),
                        DiagnosticoMotivoAtencion1 = fila.GetCell(24).ToString(),
                        TipoDX1 = fila.GetCell(25).ToString(),
                        CIE10_1 = fila.GetCell(26).ToString(),
                        DiagnosticoMotivoAtencion2 = fila.GetCell(27).ToString(),
                        TipoDX2 = fila.GetCell(28).ToString(),
                        CIE10_2 = fila.GetCell(29).ToString(),
                        DiagnosticoMotivoAtencion3 = fila.GetCell(30).ToString(),
                        TipoDX3 = fila.GetCell(31).ToString(),
                        CIE10_3 = fila.GetCell(32).ToString(),
                        DiagnosticoMotivoAtencion4 = fila.GetCell(33).ToString(),
                        TipoDX4 = fila.GetCell(34).ToString(),
                        CIE10_4 = fila.GetCell(35).ToString(),
                        DiagnosticoMotivoAtencion5 = fila.GetCell(36).ToString(),
                        TipoDX5 = fila.GetCell(37).ToString(),
                        CIE10_5 = fila.GetCell(38).ToString(),
                        DiagnosticoMotivoAtencion6 = fila.GetCell(39).ToString(),
                        TipoDX6 = fila.GetCell(40).ToString(),
                        CIE10_6 = fila.GetCell(41).ToString(),
                        TipoEmergencia = fila.GetCell(42).ToString(),
                        Interconsulta = fila.GetCell(43).ToString(),
                        EspecialidadMedicaInterconsulta = int.Parse(fila.GetCell(44).ToString()),
                        CodigoMotivoEmergencia = fila.GetCell(45).ToString(),
                        Acompaniante = fila.GetCell(46).ToString(),
                        DNIAcompaniante = fila.GetCell(47).ToString(),
                        CodigoCondicionAlta = fila.GetCell(48).ToString(),
                        CodigoDestinoPaciente = fila.GetCell(49).ToString()
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

            dt.Columns.AddRange(new DataColumn[51]
            {
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoEstablecimientoSaludMGP", typeof(string)),
                    new DataColumn("FechaAtencion", typeof(string)),
                    new DataColumn("HoraAtencion", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoUPS", typeof(int)),
                    new DataColumn("ResponsableRegistro", typeof(string)),
                    new DataColumn("NSACIP", typeof(int)),
                    new DataColumn("CMP", typeof(int)),
                    new DataColumn("Turno", typeof(string)),
                    new DataColumn("HoraInicio", typeof(string)),
                    new DataColumn("HoraFin", typeof(string)),
                    new DataColumn("HistoriaClinica", typeof(string)),
                    new DataColumn("DNIPaciente", typeof(string)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("DistritoPaciente", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SituacionPaciente", typeof(string)),
                    new DataColumn("CondicionPaciente", typeof(string)),
                    new DataColumn("EdadPaciente", typeof(int)),
                    new DataColumn("TipoEdad", typeof(string)),
                    new DataColumn("SexoPaciente", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion1", typeof(string)),
                    new DataColumn("TipoDX1", typeof(string)),
                    new DataColumn("CIE10_1", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion2", typeof(string)),
                    new DataColumn("TipoDX2", typeof(string)),
                    new DataColumn("CIE10_2", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion3", typeof(string)),
                    new DataColumn("TipoDX3", typeof(string)),
                    new DataColumn("CIE10_3", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion4", typeof(string)),
                    new DataColumn("TipoDX4", typeof(string)),
                    new DataColumn("CIE10_4", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion5", typeof(string)),
                    new DataColumn("TipoDX5", typeof(string)),
                    new DataColumn("CIE10_5", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion6", typeof(string)),
                    new DataColumn("TipoDX6", typeof(string)),
                    new DataColumn("CIE10_6", typeof(string)),
                    new DataColumn("TipoEmergencia", typeof(string)),
                    new DataColumn("Interconsulta", typeof(string)),
                    new DataColumn("EspecialidadMedicaInterconsulta", typeof(int)),
                    new DataColumn("CodigoMotivoEmergencia", typeof(string)),
                    new DataColumn("Acompaniante", typeof(string)),
                    new DataColumn("DNIAcompaniante", typeof(string)),
                    new DataColumn("CodigoCondicionAlta", typeof(string)),
                    new DataColumn("CodigoDestinoPaciente", typeof(string)),
 
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
                    int.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    fila.GetCell(18).ToString(),
                    fila.GetCell(19).ToString(),
                    fila.GetCell(20).ToString(),
                    int.Parse(fila.GetCell(21).ToString()),
                    fila.GetCell(22).ToString(),
                    fila.GetCell(23).ToString(),
                    fila.GetCell(24).ToString(),
                    fila.GetCell(25).ToString(),
                    fila.GetCell(26).ToString(),
                    fila.GetCell(27).ToString(),
                    fila.GetCell(28).ToString(),
                    fila.GetCell(29).ToString(),
                    fila.GetCell(30).ToString(),
                    fila.GetCell(31).ToString(),
                    fila.GetCell(32).ToString(),
                    fila.GetCell(33).ToString(),
                    fila.GetCell(34).ToString(),
                    fila.GetCell(35).ToString(),
                    fila.GetCell(36).ToString(),
                    fila.GetCell(37).ToString(),
                    fila.GetCell(38).ToString(),
                    fila.GetCell(39).ToString(),
                    fila.GetCell(40).ToString(),
                    fila.GetCell(41).ToString(),
                    fila.GetCell(42).ToString(),
                    fila.GetCell(43).ToString(),
                    int.Parse(fila.GetCell(44).ToString()),
                    fila.GetCell(45).ToString(),
                    fila.GetCell(46).ToString(),
                    fila.GetCell(47).ToString(),
                    fila.GetCell(48).ToString(),
                    fila.GetCell(49).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroAtencionEmergenciaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = registroAtencionEmergenciaBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DisamarRegistroAtencionEmergencia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DisamarRegistroAtencionEmergencia.xlsx");
        }

    }

}

