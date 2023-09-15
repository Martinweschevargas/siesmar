using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
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

    public class DisamarRegistroAtencionCentroQuirurgicoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroAtencionCentroQuirurgico registroAtencionCentroQuirurgicoBL = new();
        EntidadMilitar entidadMilitarBL = new();
        ZonaNaval zonaNavalBL = new();
        EstablecimientoSaludMGP establecimientoSaludMGPBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        UnidadDependencia unidadDependenciaBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        OrigenPacienteIntervenido origenPacienteIntervenidoBL = new();
        DestinoPaciente destinoPacienteBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        Carga cargaBL = new();

        public DisamarRegistroAtencionCentroQuirurgicoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro de atención en Centro Quirúrgico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadMilitarBL.ObtenerEntidadMilitars();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<EstablecimientoSaludMGPDTO> establecimientoSaludMGPDTO = establecimientoSaludMGPBL.ObtenerEstablecimientoSaludMGPs();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<UnidadDependenciaDTO> unidadDependenciaDTO = unidadDependenciaBL.ObtenerUnidadDependencias();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<OrigenPacienteIntervenidoDTO> origenPacienteIntervenidoDTO = origenPacienteIntervenidoBL.ObtenerOrigenPacienteIntervenidos();
            List<DestinoPacienteDTO> destinoPacienteDTO = destinoPacienteBL.ObtenerDestinoPacientes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroAtencionCentroQuirurjico");
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            return Json(new
            {
                data1 = entidadMilitarDTO, data2 = zonaNavalDTO, data3 = establecimientoSaludMGPDTO,
                data4 = distritoUbigeoDTO,  data5 = unidadDependenciaDTO, data6 = tipoPersonalMilitarDTO,
                data7 = gradoPersonalMilitarDTO, data8 = origenPacienteIntervenidoDTO,
                data9 = destinoPacienteDTO, data10 = listaCargas,
                data11 = provinciaUbigeoDTO, data12 = departamentoUbigeoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroAtencionCentroQuirurgicoDTO> select = registroAtencionCentroQuirurgicoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
             return View();
        }
        public ActionResult Insertar(string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string DistritoUbigeo, string SalaOperacion, 
            string NombreMedicoIntervencion, int NSACIPMedicoIntervencion, int CMPMedicoIntervencion, string EspecialidadMedico, int NumeroIntervencion, int HistoriaClinica,
            string DNIPaciente, string CodigoUnidadDependencia, string DistritoPaciente, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string SituacionPaciente,
            string CondicionPaciente, int EdadPaciente, string TipoEdad, string SexoPaciente, string CodigoOrigenPacienteIntervenido, string DiagnosticoMotivoAtencion1, string TipoDX1, 
            string CIE10_1, string DiagnosticoMotivoAtencion2, string TipoDX2, string CIE10_2, string DiagnosticoMotivoAtencion3, string TipoDX3, 
            string CIE10_3, string IntervencionQuirurgicaEfectuada, string CodigoIntervencionEfectuada, string IntervencionQuirurgicaAdicional, string CodigoIntervencionAdicional,
            string FechaHoraInicio, string FechaHoraFin, string TipoIntervencion, string EstadoPaciente, string CodigoDestinoPaciente,int CargaId, int mes, int anio)
        {
            RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO = new();
            registroAtencionCentroQuirurgicoDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroAtencionCentroQuirurgicoDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroAtencionCentroQuirurgicoDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroAtencionCentroQuirurgicoDTO.DistritoUbigeo = DistritoUbigeo;
            registroAtencionCentroQuirurgicoDTO.SalaOperacion = SalaOperacion;
            registroAtencionCentroQuirurgicoDTO.NombreMedicoIntervencion = NombreMedicoIntervencion;
            registroAtencionCentroQuirurgicoDTO.NSACIPMedicoIntervencion = NSACIPMedicoIntervencion;
            registroAtencionCentroQuirurgicoDTO.CMPMedicoIntervencion = CMPMedicoIntervencion;
            registroAtencionCentroQuirurgicoDTO.EspecialidadMedico = EspecialidadMedico;
            registroAtencionCentroQuirurgicoDTO.NumeroIntervencion = NumeroIntervencion;
            registroAtencionCentroQuirurgicoDTO.HistoriaClinica = HistoriaClinica;
            registroAtencionCentroQuirurgicoDTO.DNIPaciente = DNIPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoUnidadDependencia = CodigoUnidadDependencia;
            registroAtencionCentroQuirurgicoDTO.DistritoPaciente = DistritoPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroAtencionCentroQuirurgicoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroAtencionCentroQuirurgicoDTO.SituacionPaciente = SituacionPaciente;
            registroAtencionCentroQuirurgicoDTO.CondicionPaciente = CondicionPaciente;
            registroAtencionCentroQuirurgicoDTO.EdadPaciente = EdadPaciente;
            registroAtencionCentroQuirurgicoDTO.TipoEdad = TipoEdad;
            registroAtencionCentroQuirurgicoDTO.SexoPaciente = SexoPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoOrigenPacienteIntervenido = CodigoOrigenPacienteIntervenido;
            registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion1 = DiagnosticoMotivoAtencion1;
            registroAtencionCentroQuirurgicoDTO.TipoDX1 = TipoDX1;
            registroAtencionCentroQuirurgicoDTO.CIE10_1 = CIE10_1;
            registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion2 = DiagnosticoMotivoAtencion2;
            registroAtencionCentroQuirurgicoDTO.TipoDX2 = TipoDX2;
            registroAtencionCentroQuirurgicoDTO.CIE10_2 = CIE10_2;
            registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion3 = DiagnosticoMotivoAtencion3;
            registroAtencionCentroQuirurgicoDTO.TipoDX3 = TipoDX3;
            registroAtencionCentroQuirurgicoDTO.CIE10_3 = CIE10_3;
            registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaEfectuada = IntervencionQuirurgicaEfectuada;
            registroAtencionCentroQuirurgicoDTO.CodigoIntervencionEfectuada = CodigoIntervencionEfectuada;
            registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaAdicional = IntervencionQuirurgicaAdicional;
            registroAtencionCentroQuirurgicoDTO.CodigoIntervencionAdicional = CodigoIntervencionAdicional;
            registroAtencionCentroQuirurgicoDTO.FechaHoraInicio = FechaHoraInicio;
            registroAtencionCentroQuirurgicoDTO.FechaHoraFin = FechaHoraFin;
            registroAtencionCentroQuirurgicoDTO.TipoIntervencion = TipoIntervencion;
            registroAtencionCentroQuirurgicoDTO.EstadoPaciente = EstadoPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoDestinoPaciente = CodigoDestinoPaciente;
            registroAtencionCentroQuirurgicoDTO.CargaId = CargaId;
            
            registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroAtencionCentroQuirurgicoBL.AgregarRegistro(registroAtencionCentroQuirurgicoDTO, mes, anio);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroAtencionCentroQuirurgicoBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string DistritoUbigeo, string SalaOperacion,
            string NombreMedicoIntervencion, int NSACIPMedicoIntervencion, int CMPMedicoIntervencion, string EspecialidadMedico, int NumeroIntervencion, int HistoriaClinica,
            string DNIPaciente, string CodigoUnidadDependencia, string DistritoPaciente, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string SituacionPaciente,
            string CondicionPaciente, int EdadPaciente, string TipoEdad, string SexoPaciente, string CodigoOrigenPacienteIntervenido, string DiagnosticoMotivoAtencion1, string TipoDX1,
            string CIE10_1, string DiagnosticoMotivoAtencion2, string TipoDX2, string CIE10_2, string DiagnosticoMotivoAtencion3, string TipoDX3,
            string CIE10_3, string IntervencionQuirurgicaEfectuada, string CodigoIntervencionEfectuada, string IntervencionQuirurgicaAdicional, string CodigoIntervencionAdicional,
            string FechaHoraInicio, string FechaHoraFin, string TipoIntervencion, string EstadoPaciente, string CodigoDestinoPaciente)
        { 
            RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO = new();
            registroAtencionCentroQuirurgicoDTO.RegistroAtencionCentroQuirurgicoId = Id;
            registroAtencionCentroQuirurgicoDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroAtencionCentroQuirurgicoDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroAtencionCentroQuirurgicoDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroAtencionCentroQuirurgicoDTO.DistritoUbigeo = DistritoUbigeo;
            registroAtencionCentroQuirurgicoDTO.SalaOperacion = SalaOperacion;
            registroAtencionCentroQuirurgicoDTO.NombreMedicoIntervencion = NombreMedicoIntervencion;
            registroAtencionCentroQuirurgicoDTO.NSACIPMedicoIntervencion = NSACIPMedicoIntervencion;
            registroAtencionCentroQuirurgicoDTO.CMPMedicoIntervencion = CMPMedicoIntervencion;
            registroAtencionCentroQuirurgicoDTO.EspecialidadMedico = EspecialidadMedico;
            registroAtencionCentroQuirurgicoDTO.NumeroIntervencion = NumeroIntervencion;
            registroAtencionCentroQuirurgicoDTO.HistoriaClinica = HistoriaClinica;
            registroAtencionCentroQuirurgicoDTO.DNIPaciente = DNIPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoUnidadDependencia = CodigoUnidadDependencia;
            registroAtencionCentroQuirurgicoDTO.DistritoPaciente = DistritoPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroAtencionCentroQuirurgicoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroAtencionCentroQuirurgicoDTO.SituacionPaciente = SituacionPaciente;
            registroAtencionCentroQuirurgicoDTO.CondicionPaciente = CondicionPaciente;
            registroAtencionCentroQuirurgicoDTO.EdadPaciente = EdadPaciente;
            registroAtencionCentroQuirurgicoDTO.TipoEdad = TipoEdad;
            registroAtencionCentroQuirurgicoDTO.SexoPaciente = SexoPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoOrigenPacienteIntervenido = CodigoOrigenPacienteIntervenido;
            registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion1 = DiagnosticoMotivoAtencion1;
            registroAtencionCentroQuirurgicoDTO.TipoDX1 = TipoDX1;
            registroAtencionCentroQuirurgicoDTO.CIE10_1 = CIE10_1;
            registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion2 = DiagnosticoMotivoAtencion2;
            registroAtencionCentroQuirurgicoDTO.TipoDX2 = TipoDX2;
            registroAtencionCentroQuirurgicoDTO.CIE10_2 = CIE10_2;
            registroAtencionCentroQuirurgicoDTO.DiagnosticoMotivoAtencion3 = DiagnosticoMotivoAtencion3;
            registroAtencionCentroQuirurgicoDTO.TipoDX3 = TipoDX3;
            registroAtencionCentroQuirurgicoDTO.CIE10_3 = CIE10_3;
            registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaEfectuada = IntervencionQuirurgicaEfectuada;
            registroAtencionCentroQuirurgicoDTO.CodigoIntervencionEfectuada = CodigoIntervencionEfectuada;
            registroAtencionCentroQuirurgicoDTO.IntervencionQuirurgicaAdicional = IntervencionQuirurgicaAdicional;
            registroAtencionCentroQuirurgicoDTO.CodigoIntervencionAdicional = CodigoIntervencionAdicional;
            registroAtencionCentroQuirurgicoDTO.FechaHoraInicio = FechaHoraInicio;
            registroAtencionCentroQuirurgicoDTO.FechaHoraFin = FechaHoraFin;
            registroAtencionCentroQuirurgicoDTO.TipoIntervencion = TipoIntervencion;
            registroAtencionCentroQuirurgicoDTO.EstadoPaciente = EstadoPaciente;
            registroAtencionCentroQuirurgicoDTO.CodigoDestinoPaciente = CodigoDestinoPaciente;
            
            registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroAtencionCentroQuirurgicoBL.ActualizarFormato(registroAtencionCentroQuirurgicoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO = new();
            registroAtencionCentroQuirurgicoDTO.RegistroAtencionCentroQuirurgicoId = Id;
            registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroAtencionCentroQuirurgicoBL.EliminarFormato(registroAtencionCentroQuirurgicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RegistroAtencionCentroQuirurgicoDTO registroAtencionCentroQuirurgicoDTO = new();
            registroAtencionCentroQuirurgicoDTO.CargaId = Id;
            registroAtencionCentroQuirurgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (registroAtencionCentroQuirurgicoBL.EliminarCarga(registroAtencionCentroQuirurgicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroAtencionCentroQuirurgicoDTO> lista = new List<RegistroAtencionCentroQuirurgicoDTO>();
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

                    lista.Add(new RegistroAtencionCentroQuirurgicoDTO
                    {
                        CodigoEntidadMilitar = fila.GetCell(0).ToString(),
                        CodigoZonaNaval = fila.GetCell(1).ToString(),
                        CodigoEstablecimientoSaludMGP = fila.GetCell(2).ToString(),
                        DistritoUbigeo = fila.GetCell(3).ToString(),
                        SalaOperacion = fila.GetCell(4).ToString(),
                        NombreMedicoIntervencion = fila.GetCell(5).ToString(),
                        NSACIPMedicoIntervencion = int.Parse(fila.GetCell(6).ToString()),
                        CMPMedicoIntervencion = int.Parse(fila.GetCell(7).ToString()),
                        EspecialidadMedico = fila.GetCell(8).ToString(),
                        NumeroIntervencion = int.Parse(fila.GetCell(9).ToString()),
                        HistoriaClinica = int.Parse(fila.GetCell(10).ToString()),
                        DNIPaciente = fila.GetCell(11).ToString(),
                        CodigoUnidadDependencia = fila.GetCell(12).ToString(),
                        DistritoPaciente = fila.GetCell(13).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(14).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(15).ToString(),
                        SituacionPaciente = fila.GetCell(16).ToString(),
                        CondicionPaciente = fila.GetCell(17).ToString(),
                        EdadPaciente = int.Parse(fila.GetCell(18).ToString()),
                        TipoEdad = fila.GetCell(19).ToString(),
                        SexoPaciente = fila.GetCell(20).ToString(),
                        CodigoOrigenPacienteIntervenido = fila.GetCell(21).ToString(),
                        DiagnosticoMotivoAtencion1 = fila.GetCell(22).ToString(),
                        TipoDX1 = fila.GetCell(23).ToString(),
                        CIE10_1 = fila.GetCell(24).ToString(),
                        DiagnosticoMotivoAtencion2 = fila.GetCell(25).ToString(),
                        TipoDX2 = fila.GetCell(26).ToString(),
                        CIE10_2 = fila.GetCell(27).ToString(),
                        DiagnosticoMotivoAtencion3 = fila.GetCell(28).ToString(),
                        TipoDX3 = fila.GetCell(29).ToString(),
                        CIE10_3 = fila.GetCell(30).ToString(),
                        IntervencionQuirurgicaEfectuada = fila.GetCell(31).ToString(),
                        CodigoIntervencionEfectuada = fila.GetCell(32).ToString(),
                        IntervencionQuirurgicaAdicional = fila.GetCell(33).ToString(),
                        CodigoIntervencionAdicional = fila.GetCell(34).ToString(),
                        FechaHoraInicio = fila.GetCell(35).ToString(),
                        FechaHoraFin = fila.GetCell(35).ToString(),
                        TipoIntervencion = fila.GetCell(37).ToString(),
                        EstadoPaciente = fila.GetCell(38).ToString(),
                        CodigoDestinoPaciente = fila.GetCell(39).ToString()
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, int mes, int anio)
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

            dt.Columns.AddRange(new DataColumn[41]
            {
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoEstablecimientoSaludMGP", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("SalaOperacion", typeof(string)),
                    new DataColumn("NombreMedicoIntervencion", typeof(string)),
                    new DataColumn("NSACIPMedicoIntervencion", typeof(int)),
                    new DataColumn("CMPMedicoIntervencion", typeof(int)),
                    new DataColumn("EspecialidadMedico", typeof(string)),
                    new DataColumn("NumeroIntervencion", typeof(int)),
                    new DataColumn("HistoriaClinica", typeof(int)),
                    new DataColumn("DNIPaciente", typeof(string)),
                    new DataColumn("CodigoUnidadDependencia", typeof(string)),
                    new DataColumn("DistritoPaciente", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SituacionPaciente", typeof(string)),
                    new DataColumn("CondicionPaciente", typeof(string)),
                    new DataColumn("EdadPaciente", typeof(int)),
                    new DataColumn("TipoEdad", typeof(string)),
                    new DataColumn("SexoPaciente", typeof(string)),
                    new DataColumn("CodigoOrigenPacienteIntervenido", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion1", typeof(string)),
                    new DataColumn("TipoDX1", typeof(string)),
                    new DataColumn("CIE10_1", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion2", typeof(string)),
                    new DataColumn("TipoDX2", typeof(string)),
                    new DataColumn("CIE10_2", typeof(string)),
                    new DataColumn("DiagnosticoMotivoAtencion3", typeof(string)),
                    new DataColumn("TipoDX3", typeof(string)),
                    new DataColumn("CIE10_3", typeof(string)),
                    new DataColumn("IntervencionQuirurgicaEfectuada", typeof(string)),
                    new DataColumn("CodigoIntervencionEfectuada", typeof(string)),
                    new DataColumn("IntervencionQuirurgicaAdicional", typeof(string)),
                    new DataColumn("CodigoIntervencionAdicional", typeof(string)),
                    new DataColumn("FechaHoraInicio", typeof(string)),
                    new DataColumn("FechaHoraFin", typeof(string)),
                    new DataColumn("TipoIntervencion", typeof(string)),
                    new DataColumn("EstadoPaciente", typeof(string)),
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
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    int.Parse(fila.GetCell(18).ToString()),
                    fila.GetCell(19).ToString(),
                    fila.GetCell(20).ToString(),
                    fila.GetCell(21).ToString(),
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
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroAtencionCentroQuirurgicoBL.InsertarDatos(dt, mes, anio);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = registroAtencionCentroQuirurgicoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ DisamarRegistroAtencionCentroQuirurgico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", " DisamarRegistroAtencionCentroQuirurgico.xlsx");
        }

    }

}

