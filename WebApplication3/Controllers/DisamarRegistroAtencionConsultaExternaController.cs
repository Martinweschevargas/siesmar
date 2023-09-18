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

    public class DisamarRegistroAtencionConsultaExternaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        RegistroAtencionConsultaExterna registroAtencionConsultaExternaBL = new();

        EntidadMilitar entidadMilitarBL = new();
        ZonaNaval zonaNavalBL = new();
        EstablecimientoSaludMGP establecimientoSaludMGPBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        EspecialidadMedicaNoMedica especialidadMedicaNoMedicaBL = new();
        UnidadNaval unidadnavalBl = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        Carga cargaBL = new();
        public DisamarRegistroAtencionConsultaExternaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro de Atenciones en Consulta Externa", FromController = typeof(HomeController))]
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
            List<UnidadNavalDTO> unidadNavalDTO = unidadnavalBl.ObtenerUnidadNavals();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroAtencionConsultaExterna");

            return Json(new
            {
                data1 = entidadMilitarDTO,
                data2 = zonaNavalDTO,
                data3 = establecimientoSaludMGPDTO,
                data4 = departamentoUbigeoDTO,
                data5 = provinciaUbigeoDTO,
                data6 = distritoUbigeoDTO,
                data7 = especialidadMedicaNoMedicaDTO,
                data8 = unidadNavalDTO,
                data9 = tipoPersonalMilitarDTO,
                data10 = gradoPersonalMilitarDTO,
                data11 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroAtencionConsultaExternaDTO> select = registroAtencionConsultaExternaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string FechaRegistro,
            string DistritoUbigeo, string CodigoUPSMedicaNoMedica, string ResponsableAtencionMedica, int NSACIP, int NumeroCMP, string Turno, 
            string HoraInicio, string HoraTermino, int HistoriaClinica, string DNIPaciente, string CodigoUnidadNaval, string DistritoPaciente, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, string SituacionPaciente, string CondicionPaciente, int EdadPaciente,string TipoEdad,
            string SexoPaciente, string AlEstablecimiento, string AlServicio, string CodigoDiagnosticoMotivoAtencion1, string TipoDX1, string Lab1, 
            string CodigoCIE10_1, string CodigoDiagnosticoMotivoAtencion2, string TipoDX2, string Lab2, string CodigoCIE10_2, string CodigoDiagnosticoMotivoAtencion3, string TipoDX3, string Lab3,
            string CodigoCIE10_3, string CodigoDiagnosticoMotivoAtencion4, string TipoDX4, string Lab4, string CodigoCIE10_4, string CodigoDiagnosticoMotivoAtencion5, string TipoDX5, string Lab5,
            string CodigoCIE10_5, string CodigoDiagnosticoMotivoAtencion6, string TipoDX6, string Lab6, string CodigoCIE10_6, string Interconsulta, string CodigoUPSEspecialidadInterconsulta,
            int CargaId)
        {
            RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO = new();
            registroAtencionConsultaExternaDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroAtencionConsultaExternaDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroAtencionConsultaExternaDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroAtencionConsultaExternaDTO.FechaRegistro = FechaRegistro;
            registroAtencionConsultaExternaDTO.DistritoUbigeo = DistritoUbigeo;
            registroAtencionConsultaExternaDTO.CodigoUPSMedicaNoMedica = CodigoUPSMedicaNoMedica;
            registroAtencionConsultaExternaDTO.ResponsableAtencionMedica = ResponsableAtencionMedica;
            registroAtencionConsultaExternaDTO.NSACIP = NSACIP;
            registroAtencionConsultaExternaDTO.NumeroCMP = NumeroCMP;
            registroAtencionConsultaExternaDTO.Turno = Turno;
            registroAtencionConsultaExternaDTO.HoraInicio = HoraInicio;
            registroAtencionConsultaExternaDTO.HoraTermino = HoraTermino;
            registroAtencionConsultaExternaDTO.HistoriaClinica = HistoriaClinica;
            registroAtencionConsultaExternaDTO.DNIPaciente = DNIPaciente;
            registroAtencionConsultaExternaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            registroAtencionConsultaExternaDTO.DistritoPaciente = DistritoPaciente;
            registroAtencionConsultaExternaDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroAtencionConsultaExternaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroAtencionConsultaExternaDTO.SituacionPaciente = SituacionPaciente;
            registroAtencionConsultaExternaDTO.CondicionPaciente = CondicionPaciente;
            registroAtencionConsultaExternaDTO.EdadPaciente = EdadPaciente;
            registroAtencionConsultaExternaDTO.TipoEdad = TipoEdad;
            registroAtencionConsultaExternaDTO.SexoPaciente = SexoPaciente;
            registroAtencionConsultaExternaDTO.AlEstablecimiento = AlEstablecimiento;
            registroAtencionConsultaExternaDTO.AlServicio = AlServicio;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion1 = CodigoDiagnosticoMotivoAtencion1;
            registroAtencionConsultaExternaDTO.TipoDX1 = TipoDX1;
            registroAtencionConsultaExternaDTO.Lab1 = Lab1;
            registroAtencionConsultaExternaDTO.CodigoCIE10_1 = CodigoCIE10_1;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion2 = CodigoDiagnosticoMotivoAtencion2;
            registroAtencionConsultaExternaDTO.TipoDX2 = TipoDX2;
            registroAtencionConsultaExternaDTO.Lab2 = Lab2;
            registroAtencionConsultaExternaDTO.CodigoCIE10_2 = CodigoCIE10_2;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion3 = CodigoDiagnosticoMotivoAtencion3;
            registroAtencionConsultaExternaDTO.TipoDX3 = TipoDX3;
            registroAtencionConsultaExternaDTO.Lab3 = Lab3;
            registroAtencionConsultaExternaDTO.CodigoCIE10_3 = CodigoCIE10_3;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion4 = CodigoDiagnosticoMotivoAtencion4;
            registroAtencionConsultaExternaDTO.TipoDX4 = TipoDX4;
            registroAtencionConsultaExternaDTO.Lab4 = Lab4;
            registroAtencionConsultaExternaDTO.CodigoCIE10_4 = CodigoCIE10_4;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion5 = CodigoDiagnosticoMotivoAtencion5;
            registroAtencionConsultaExternaDTO.TipoDX5 = TipoDX5;
            registroAtencionConsultaExternaDTO.Lab5 = Lab5;
            registroAtencionConsultaExternaDTO.CodigoCIE10_5 = CodigoCIE10_5;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion6 = CodigoDiagnosticoMotivoAtencion6;
            registroAtencionConsultaExternaDTO.TipoDX6 = TipoDX6;
            registroAtencionConsultaExternaDTO.Lab6 = Lab6;
            registroAtencionConsultaExternaDTO.CodigoCIE10_6 = CodigoCIE10_6;
            registroAtencionConsultaExternaDTO.Interconsulta = Interconsulta;
            registroAtencionConsultaExternaDTO.CodigoUPSEspecialidadInterconsulta = CodigoUPSEspecialidadInterconsulta;
            registroAtencionConsultaExternaDTO.CargaId = CargaId;

            registroAtencionConsultaExternaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroAtencionConsultaExternaBL.AgregarRegistro(registroAtencionConsultaExternaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroAtencionConsultaExternaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string FechaRegistro,
            string DistritoUbigeo, string CodigoUPSMedicaNoMedica, string ResponsableAtencionMedica, int NSACIP, int NumeroCMP, string Turno,
            string HoraInicio, string HoraTermino, int HistoriaClinica, string DNIPaciente, string CodigoUnidadNaval, string DistritoPaciente, string CodigoTipoPersonalMilitar,
            string CodigoGradoPersonalMilitar, string SituacionPaciente, string CondicionPaciente, int EdadPaciente, string TipoEdad,
            string SexoPaciente, string AlEstablecimiento, string AlServicio, string CodigoDiagnosticoMotivoAtencion1, string TipoDX1, string Lab1,
            string CodigoCIE10_1, string CodigoDiagnosticoMotivoAtencion2, string TipoDX2, string Lab2, string CodigoCIE10_2, string CodigoDiagnosticoMotivoAtencion3, string TipoDX3, string Lab3,
            string CodigoCIE10_3, string CodigoDiagnosticoMotivoAtencion4, string TipoDX4, string Lab4, string CodigoCIE10_4, string CodigoDiagnosticoMotivoAtencion5, string TipoDX5, string Lab5,
            string CodigoCIE10_5, string CodigoDiagnosticoMotivoAtencion6, string TipoDX6, string Lab6, string CodigoCIE10_6, string Interconsulta, string CodigoUPSEspecialidadInterconsulta)
        {
            RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO = new();
            registroAtencionConsultaExternaDTO.RegistroAtencionConsultaExternaId = Id;
            registroAtencionConsultaExternaDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroAtencionConsultaExternaDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroAtencionConsultaExternaDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroAtencionConsultaExternaDTO.FechaRegistro = FechaRegistro;
            registroAtencionConsultaExternaDTO.DistritoUbigeo = DistritoUbigeo;
            registroAtencionConsultaExternaDTO.CodigoUPSMedicaNoMedica = CodigoUPSMedicaNoMedica;
            registroAtencionConsultaExternaDTO.ResponsableAtencionMedica = ResponsableAtencionMedica;
            registroAtencionConsultaExternaDTO.NSACIP = NSACIP;
            registroAtencionConsultaExternaDTO.NumeroCMP = NumeroCMP;
            registroAtencionConsultaExternaDTO.Turno = Turno;
            registroAtencionConsultaExternaDTO.HoraInicio = HoraInicio;
            registroAtencionConsultaExternaDTO.HoraTermino = HoraTermino;
            registroAtencionConsultaExternaDTO.HistoriaClinica = HistoriaClinica;
            registroAtencionConsultaExternaDTO.DNIPaciente = DNIPaciente;
            registroAtencionConsultaExternaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            registroAtencionConsultaExternaDTO.DistritoPaciente = DistritoPaciente;
            registroAtencionConsultaExternaDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroAtencionConsultaExternaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroAtencionConsultaExternaDTO.SituacionPaciente = SituacionPaciente;
            registroAtencionConsultaExternaDTO.CondicionPaciente = CondicionPaciente;
            registroAtencionConsultaExternaDTO.EdadPaciente = EdadPaciente;
            registroAtencionConsultaExternaDTO.TipoEdad = TipoEdad;
            registroAtencionConsultaExternaDTO.SexoPaciente = SexoPaciente;
            registroAtencionConsultaExternaDTO.AlEstablecimiento = AlEstablecimiento;
            registroAtencionConsultaExternaDTO.AlServicio = AlServicio;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion1 = CodigoDiagnosticoMotivoAtencion1;
            registroAtencionConsultaExternaDTO.TipoDX1 = TipoDX1;
            registroAtencionConsultaExternaDTO.Lab1 = Lab1;
            registroAtencionConsultaExternaDTO.CodigoCIE10_1 = CodigoCIE10_1;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion2 = CodigoDiagnosticoMotivoAtencion2;
            registroAtencionConsultaExternaDTO.TipoDX2 = TipoDX2;
            registroAtencionConsultaExternaDTO.Lab2 = Lab2;
            registroAtencionConsultaExternaDTO.CodigoCIE10_2 = CodigoCIE10_2;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion3 = CodigoDiagnosticoMotivoAtencion3;
            registroAtencionConsultaExternaDTO.TipoDX3 = TipoDX3;
            registroAtencionConsultaExternaDTO.Lab3 = Lab3;
            registroAtencionConsultaExternaDTO.CodigoCIE10_3 = CodigoCIE10_3;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion4 = CodigoDiagnosticoMotivoAtencion4;
            registroAtencionConsultaExternaDTO.TipoDX4 = TipoDX4;
            registroAtencionConsultaExternaDTO.Lab4 = Lab4;
            registroAtencionConsultaExternaDTO.CodigoCIE10_4 = CodigoCIE10_4;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion5 = CodigoDiagnosticoMotivoAtencion5;
            registroAtencionConsultaExternaDTO.TipoDX5 = TipoDX5;
            registroAtencionConsultaExternaDTO.Lab5 = Lab5;
            registroAtencionConsultaExternaDTO.CodigoCIE10_5 = CodigoCIE10_5;
            registroAtencionConsultaExternaDTO.CodigoDiagnosticoMotivoAtencion6 = CodigoDiagnosticoMotivoAtencion6;
            registroAtencionConsultaExternaDTO.TipoDX6 = TipoDX6;
            registroAtencionConsultaExternaDTO.Lab6 = Lab6;
            registroAtencionConsultaExternaDTO.CodigoCIE10_6 = CodigoCIE10_6;
            registroAtencionConsultaExternaDTO.Interconsulta = Interconsulta;
            registroAtencionConsultaExternaDTO.CodigoUPSEspecialidadInterconsulta = CodigoUPSEspecialidadInterconsulta;
            
            registroAtencionConsultaExternaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroAtencionConsultaExternaBL.ActualizarFormato(registroAtencionConsultaExternaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO = new();
            registroAtencionConsultaExternaDTO.RegistroAtencionConsultaExternaId = Id;
            registroAtencionConsultaExternaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroAtencionConsultaExternaBL.EliminarFormato(registroAtencionConsultaExternaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroAtencionConsultaExternaDTO> lista = new List<RegistroAtencionConsultaExternaDTO>();
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

                    lista.Add(new RegistroAtencionConsultaExternaDTO
                    {
                        CodigoEntidadMilitar = fila.GetCell(0).ToString(),
                        CodigoZonaNaval = fila.GetCell(1).ToString(),
                        CodigoEstablecimientoSaludMGP = fila.GetCell(2).ToString(),
                        FechaRegistro = fila.GetCell(3).ToString(),
                        DistritoUbigeo = fila.GetCell(4).ToString(),
                        CodigoUPSMedicaNoMedica = fila.GetCell(5).ToString(),
                        ResponsableAtencionMedica = fila.GetCell(6).ToString(),
                        NSACIP = int.Parse(fila.GetCell(7).ToString()),
                        NumeroCMP = int.Parse(fila.GetCell(8).ToString()),
                        Turno = fila.GetCell(9).ToString(),
                        HoraInicio = fila.GetCell(10).ToString(),
                        HoraTermino = fila.GetCell(11).ToString(),
                        HistoriaClinica = int.Parse(fila.GetCell(12).ToString()),
                        DNIPaciente = fila.GetCell(13).ToString(),
                        CodigoUnidadNaval = fila.GetCell(14).ToString(),
                        DistritoPaciente = fila.GetCell(15).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(16).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(17).ToString(),
                        SituacionPaciente = fila.GetCell(18).ToString(),
                        CondicionPaciente = fila.GetCell(19).ToString(),
                        EdadPaciente = int.Parse(fila.GetCell(20).ToString()),
                        TipoEdad = fila.GetCell(21).ToString(),
                        SexoPaciente = fila.GetCell(22).ToString(),
                        AlEstablecimiento = fila.GetCell(23).ToString(),
                        AlServicio = fila.GetCell(24).ToString(),
                        CodigoDiagnosticoMotivoAtencion1 = fila.GetCell(25).ToString(),
                        TipoDX1 = fila.GetCell(26).ToString(),
                        Lab1 = fila.GetCell(27).ToString(),
                        CodigoCIE10_1 = fila.GetCell(28).ToString(),
                        CodigoDiagnosticoMotivoAtencion2 = fila.GetCell(29).ToString(),
                        TipoDX2 = fila.GetCell(30).ToString(),
                        Lab2 = fila.GetCell(31).ToString(),
                        CodigoCIE10_2 = fila.GetCell(32).ToString(),
                        CodigoDiagnosticoMotivoAtencion3 = fila.GetCell(33).ToString(),
                        TipoDX3 = fila.GetCell(34).ToString(),
                        Lab3 = fila.GetCell(35).ToString(),
                        CodigoCIE10_3 = fila.GetCell(36).ToString(),
                        CodigoDiagnosticoMotivoAtencion4 = fila.GetCell(37).ToString(),
                        TipoDX4 = fila.GetCell(38).ToString(),
                        Lab4 = fila.GetCell(39).ToString(),
                        CodigoCIE10_4 = fila.GetCell(40).ToString(),
                        CodigoDiagnosticoMotivoAtencion5 = fila.GetCell(41).ToString(),
                        TipoDX5 = fila.GetCell(42).ToString(),
                        Lab5 = fila.GetCell(43).ToString(),
                        CodigoCIE10_5 = fila.GetCell(44).ToString(),
                        CodigoDiagnosticoMotivoAtencion6 = fila.GetCell(45).ToString(),
                        TipoDX6 = fila.GetCell(46).ToString(),
                        Lab6 = fila.GetCell(47).ToString(),
                        CodigoCIE10_6 = fila.GetCell(48).ToString(),
                        Interconsulta = fila.GetCell(49).ToString(),
                        CodigoUPSEspecialidadInterconsulta = fila.GetCell(50).ToString(),
 
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

            dt.Columns.AddRange(new DataColumn[52]
            {
                    new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoEstablecimientoSaludMGP", typeof(string)),
                    new DataColumn("FechaRegistro", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoUPSMedicaNoMedica", typeof(string)),
                    new DataColumn("ResponsableAtencionMedica", typeof(string)),
                    new DataColumn("NSACIP", typeof(int)),
                    new DataColumn("NumeroCMP", typeof(int)),
                    new DataColumn("Turno", typeof(string)),
                    new DataColumn("HoraInicio", typeof(string)),
                    new DataColumn("HoraTermino", typeof(string)),
                    new DataColumn("HistoriaClinica", typeof(int)),
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
                    new DataColumn("AlEstablecimiento", typeof(string)),
                    new DataColumn("AlServicio", typeof(string)),
                    new DataColumn("CodigoDiagnosticoMotivoAtencion1", typeof(string)),
                    new DataColumn("TipoDX1", typeof(string)),
                    new DataColumn("Lab1", typeof(string)),
                    new DataColumn("CodigoCIE10_1", typeof(string)),
                    new DataColumn("CodigoDiagnosticoMotivoAtencion2", typeof(string)),
                    new DataColumn("TipoDX2", typeof(string)),
                    new DataColumn("Lab2", typeof(string)),
                    new DataColumn("CodigoCIE10_2", typeof(string)),
                    new DataColumn("CodigoDiagnosticoMotivoAtencion3", typeof(string)),
                    new DataColumn("TipoDX3", typeof(string)),
                    new DataColumn("Lab3", typeof(string)),
                    new DataColumn("CodigoCIE10_3", typeof(string)),
                    new DataColumn("CodigoDiagnosticoMotivoAtencion4", typeof(string)),
                    new DataColumn("TipoDX4", typeof(string)),
                    new DataColumn("Lab4", typeof(string)),
                    new DataColumn("CodigoCIE10_4", typeof(string)),
                    new DataColumn("CodigoDiagnosticoMotivoAtencion5", typeof(string)),
                    new DataColumn("TipoDX5", typeof(string)),
                    new DataColumn("Lab5", typeof(string)),
                    new DataColumn("CodigoCIE10_5", typeof(string)),
                    new DataColumn("CodigoDiagnosticoMotivoAtencion6", typeof(string)),
                    new DataColumn("TipoDX6", typeof(string)),
                    new DataColumn("Lab6", typeof(string)),
                    new DataColumn("CodigoCIE10_6", typeof(string)),
                    new DataColumn("Interconsulta", typeof(string)),
                    new DataColumn("CodigoUPSEspecialidadInterconsulta", typeof(string)),

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
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    int.Parse(fila.GetCell(12).ToString()),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    fila.GetCell(18).ToString(),
                    fila.GetCell(19).ToString(),
                    int.Parse(fila.GetCell(20).ToString()),
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
                    fila.GetCell(40).ToString(),
                    fila.GetCell(41).ToString(),
                    fila.GetCell(42).ToString(),
                    fila.GetCell(43).ToString(),
                    fila.GetCell(44).ToString(),
                    fila.GetCell(45).ToString(),
                    fila.GetCell(46).ToString(),
                    fila.GetCell(47).ToString(),
                    fila.GetCell(48).ToString(),
                    fila.GetCell(49).ToString(),
                    fila.GetCell(50).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroAtencionConsultaExternaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = registroAtencionConsultaExternaBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DisamarRegistroAtencionConsultaExterna.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DisamarRegistroAtencionConsultaExterna.xlsx");
        }
    }

}

