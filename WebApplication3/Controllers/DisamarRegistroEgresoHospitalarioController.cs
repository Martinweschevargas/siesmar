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

    public class DisamarRegistroEgresoHospitalarioController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroEgresoHospitalario registroEgresoHospitalarioBL = new();
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
        CondicionEgresoHospitalizacion condicionEgresoHospitalizacionBL = new();
        Carga cargaBL = new();

        public DisamarRegistroEgresoHospitalarioController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro de Egresos Hospitalarios", FromController = typeof(HomeController))]
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
            List<CondicionEgresoHospitalizacionDTO> condicionEgresoHospitalizacionDTO = condicionEgresoHospitalizacionBL.ObtenerCondicionEgresoHospitalizacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroEgresoHospitalario");

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
                data11 = condicionEgresoHospitalizacionDTO,
                data12 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroEgresoHospitalarioDTO> select = registroEgresoHospitalarioBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string DistritoUbigeo, string CodigoUPS,
            string ResponsableRegistro, int NSACIP, string DNIResponsableSalud, int HistoriaClinica, string DNIPaciente, string CodigoUnidadNaval, string DistritoPaciente,
            string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string SituacionPaciente, string CondicionPaciente, string OrigenPaciente, int EdadPaciente,
            string TipoEdad, string SexoPaciente, string DiagnosticoMotivoAtencion1, string TipoDX1,  string CIE10_1, string DiagnosticoMotivoAtencion2,
            string TipoDX2, string CIE10_2, string DiagnosticoMotivoAtencion3, string TipoDX3, string CIE10_3, string DiagnosticoMotivoAtencion4,
            string TipoDX4,  string CIE10_4, string DiagnosticoMotivoAtencion5, string TipoDX5,  string CIE10_5, string DiagnosticoMotivoAtencion6,
            string TipoDX6,  string CIE10_6, string CodigoCondicionEgresoHospitalizacion, string FechaIngreso, string HoraIngreso, string FechaEgreso, string HoraEgreso,
            string EspecialidadMedicoTratanteIngreso, string NombreMedicoIngreso, string DiagnosticoIngreso, string EspecialidadMedicoTratanteEgreso, string NombreMedicoEgreso,
            int CargaId)
        {
            RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO = new();
            registroEgresoHospitalarioDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroEgresoHospitalarioDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroEgresoHospitalarioDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroEgresoHospitalarioDTO.DistritoUbigeo = DistritoUbigeo;
            registroEgresoHospitalarioDTO.CodigoUPS = CodigoUPS;
            registroEgresoHospitalarioDTO.ResponsableRegistro = ResponsableRegistro;
            registroEgresoHospitalarioDTO.NSACIP = NSACIP;
            registroEgresoHospitalarioDTO.DNIResponsableSalud = DNIResponsableSalud;
            registroEgresoHospitalarioDTO.HistoriaClinica = HistoriaClinica;
            registroEgresoHospitalarioDTO.DNIPaciente = DNIPaciente;
            registroEgresoHospitalarioDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            registroEgresoHospitalarioDTO.DistritoPaciente = DistritoPaciente;
            registroEgresoHospitalarioDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroEgresoHospitalarioDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroEgresoHospitalarioDTO.SituacionPaciente = SituacionPaciente;
            registroEgresoHospitalarioDTO.CondicionPaciente = CondicionPaciente;
            registroEgresoHospitalarioDTO.OrigenPaciente = OrigenPaciente;
            registroEgresoHospitalarioDTO.EdadPaciente = EdadPaciente;
            registroEgresoHospitalarioDTO.TipoEdad = TipoEdad;
            registroEgresoHospitalarioDTO.SexoPaciente = SexoPaciente;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion1 = DiagnosticoMotivoAtencion1;
            registroEgresoHospitalarioDTO.TipoDX1 = TipoDX1;
            registroEgresoHospitalarioDTO.CIE10_1 = CIE10_1;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion2 = DiagnosticoMotivoAtencion2;
            registroEgresoHospitalarioDTO.TipoDX2 = TipoDX2;
            registroEgresoHospitalarioDTO.CIE10_2 = CIE10_2;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion3 = DiagnosticoMotivoAtencion3;
            registroEgresoHospitalarioDTO.TipoDX3 = TipoDX3;
            registroEgresoHospitalarioDTO.CIE10_3 = CIE10_3;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion4 = DiagnosticoMotivoAtencion4;
            registroEgresoHospitalarioDTO.TipoDX4 = TipoDX4;
            registroEgresoHospitalarioDTO.CIE10_4 = CIE10_4;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion5 = DiagnosticoMotivoAtencion5;
            registroEgresoHospitalarioDTO.TipoDX5 = TipoDX5;
            registroEgresoHospitalarioDTO.CIE10_5 = CIE10_5;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion6 = DiagnosticoMotivoAtencion6;
            registroEgresoHospitalarioDTO.TipoDX6 = TipoDX6;
            registroEgresoHospitalarioDTO.CIE10_6 = CIE10_6;
            registroEgresoHospitalarioDTO.CodigoCondicionEgresoHospitalizacion = CodigoCondicionEgresoHospitalizacion;
            registroEgresoHospitalarioDTO.FechaIngreso = FechaIngreso;
            registroEgresoHospitalarioDTO.HoraIngreso = HoraIngreso;
            registroEgresoHospitalarioDTO.FechaEgreso = FechaEgreso;
            registroEgresoHospitalarioDTO.HoraEgreso = HoraEgreso;
            registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteIngreso = EspecialidadMedicoTratanteIngreso;
            registroEgresoHospitalarioDTO.NombreMedicoIngreso = NombreMedicoIngreso;
            registroEgresoHospitalarioDTO.DiagnosticoIngreso = DiagnosticoIngreso;
            registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteEgreso = EspecialidadMedicoTratanteEgreso;
            registroEgresoHospitalarioDTO.NombreMedicoEgreso = NombreMedicoEgreso;
            registroEgresoHospitalarioDTO.CargaId = CargaId;

            registroEgresoHospitalarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroEgresoHospitalarioBL.AgregarRegistro(registroEgresoHospitalarioDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroEgresoHospitalarioBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoEntidadMilitar, string CodigoZonaNaval, string CodigoEstablecimientoSaludMGP, string DistritoUbigeo, string CodigoUPS,
            string ResponsableRegistro, int NSACIP, string DNIResponsableSalud, int HistoriaClinica, string DNIPaciente, string CodigoUnidadNaval, string DistritoPaciente,
            string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string SituacionPaciente, string CondicionPaciente, string OrigenPaciente, int EdadPaciente,
            string TipoEdad, string SexoPaciente, string DiagnosticoMotivoAtencion1, string TipoDX1, string CIE10_1, string DiagnosticoMotivoAtencion2,
            string TipoDX2, string CIE10_2, string DiagnosticoMotivoAtencion3, string TipoDX3, string CIE10_3, string DiagnosticoMotivoAtencion4,
            string TipoDX4, string CIE10_4, string DiagnosticoMotivoAtencion5, string TipoDX5, string CIE10_5, string DiagnosticoMotivoAtencion6,
            string TipoDX6, string CIE10_6, string CodigoCondicionEgresoHospitalizacion, string FechaIngreso, string HoraIngreso, string FechaEgreso, string HoraEgreso,
            string EspecialidadMedicoTratanteIngreso, string NombreMedicoIngreso, string DiagnosticoIngreso, string EspecialidadMedicoTratanteEgreso, string NombreMedicoEgreso)
            { 
            RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO = new();
            registroEgresoHospitalarioDTO.RegistroEgresoHospitalarioId = Id;
            registroEgresoHospitalarioDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            registroEgresoHospitalarioDTO.CodigoZonaNaval = CodigoZonaNaval;
            registroEgresoHospitalarioDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroEgresoHospitalarioDTO.DistritoUbigeo = DistritoUbigeo;
            registroEgresoHospitalarioDTO.CodigoUPS = CodigoUPS;
            registroEgresoHospitalarioDTO.ResponsableRegistro = ResponsableRegistro;
            registroEgresoHospitalarioDTO.NSACIP = NSACIP;
            registroEgresoHospitalarioDTO.DNIResponsableSalud = DNIResponsableSalud;
            registroEgresoHospitalarioDTO.HistoriaClinica = HistoriaClinica;
            registroEgresoHospitalarioDTO.DNIPaciente = DNIPaciente;
            registroEgresoHospitalarioDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            registroEgresoHospitalarioDTO.DistritoPaciente = DistritoPaciente;
            registroEgresoHospitalarioDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            registroEgresoHospitalarioDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroEgresoHospitalarioDTO.SituacionPaciente = SituacionPaciente;
            registroEgresoHospitalarioDTO.CondicionPaciente = CondicionPaciente;
            registroEgresoHospitalarioDTO.OrigenPaciente = OrigenPaciente;
            registroEgresoHospitalarioDTO.EdadPaciente = EdadPaciente;
            registroEgresoHospitalarioDTO.TipoEdad = TipoEdad;
            registroEgresoHospitalarioDTO.SexoPaciente = SexoPaciente;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion1 = DiagnosticoMotivoAtencion1;
            registroEgresoHospitalarioDTO.TipoDX1 = TipoDX1;
            registroEgresoHospitalarioDTO.CIE10_1 = CIE10_1;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion2 = DiagnosticoMotivoAtencion2;
            registroEgresoHospitalarioDTO.TipoDX2 = TipoDX2;
            registroEgresoHospitalarioDTO.CIE10_2 = CIE10_2;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion3 = DiagnosticoMotivoAtencion3;
            registroEgresoHospitalarioDTO.TipoDX3 = TipoDX3;
            registroEgresoHospitalarioDTO.CIE10_3 = CIE10_3;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion4 = DiagnosticoMotivoAtencion4;
            registroEgresoHospitalarioDTO.TipoDX4 = TipoDX4;
            registroEgresoHospitalarioDTO.CIE10_4 = CIE10_4;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion5 = DiagnosticoMotivoAtencion5;
            registroEgresoHospitalarioDTO.TipoDX5 = TipoDX5;
            registroEgresoHospitalarioDTO.CIE10_5 = CIE10_5;
            registroEgresoHospitalarioDTO.DiagnosticoMotivoAtencion6 = DiagnosticoMotivoAtencion6;
            registroEgresoHospitalarioDTO.TipoDX6 = TipoDX6;
            registroEgresoHospitalarioDTO.CIE10_6 = CIE10_6;
            registroEgresoHospitalarioDTO.CodigoCondicionEgresoHospitalizacion = CodigoCondicionEgresoHospitalizacion;
            registroEgresoHospitalarioDTO.FechaIngreso = FechaIngreso;
            registroEgresoHospitalarioDTO.HoraIngreso = HoraIngreso;
            registroEgresoHospitalarioDTO.FechaEgreso = FechaEgreso;
            registroEgresoHospitalarioDTO.HoraEgreso = HoraEgreso;
            registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteIngreso = EspecialidadMedicoTratanteIngreso;
            registroEgresoHospitalarioDTO.NombreMedicoIngreso = NombreMedicoIngreso;
            registroEgresoHospitalarioDTO.DiagnosticoIngreso = DiagnosticoIngreso;
            registroEgresoHospitalarioDTO.EspecialidadMedicoTratanteEgreso = EspecialidadMedicoTratanteEgreso;
            registroEgresoHospitalarioDTO.NombreMedicoEgreso = NombreMedicoEgreso;
            
            registroEgresoHospitalarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroEgresoHospitalarioBL.ActualizarFormato(registroEgresoHospitalarioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO = new();
            registroEgresoHospitalarioDTO.RegistroEgresoHospitalarioId = Id;
            registroEgresoHospitalarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroEgresoHospitalarioBL.EliminarFormato(registroEgresoHospitalarioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroEgresoHospitalarioDTO> lista = new List<RegistroEgresoHospitalarioDTO>();
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

                    lista.Add(new RegistroEgresoHospitalarioDTO
                    {
                        CodigoEntidadMilitar = fila.GetCell(0).ToString(),
                        CodigoZonaNaval = fila.GetCell(1).ToString(),
                        CodigoEstablecimientoSaludMGP = fila.GetCell(2).ToString(),
                        DistritoUbigeo = fila.GetCell(3).ToString(),
                        CodigoUPS = fila.GetCell(4).ToString(),
                        ResponsableRegistro = fila.GetCell(5).ToString(),
                        NSACIP = int.Parse(fila.GetCell(6).ToString()),
                        DNIResponsableSalud = fila.GetCell(7).ToString(),
                        HistoriaClinica = int.Parse(fila.GetCell(8).ToString()),
                        DNIPaciente = fila.GetCell(9).ToString(),
                        CodigoUnidadNaval = fila.GetCell(10).ToString(),
                        DistritoPaciente = fila.GetCell(11).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(12).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(13).ToString(),
                        SituacionPaciente = fila.GetCell(14).ToString(),
                        CondicionPaciente = fila.GetCell(15).ToString(),
                        OrigenPaciente = fila.GetCell(16).ToString(),
                        EdadPaciente = int.Parse(fila.GetCell(17).ToString()),
                        TipoEdad = fila.GetCell(18).ToString(),
                        SexoPaciente = fila.GetCell(19).ToString(),
                        DiagnosticoMotivoAtencion1 = fila.GetCell(20).ToString(),
                        TipoDX1 = fila.GetCell(21).ToString(),
                        CIE10_1 = fila.GetCell(22).ToString(),
                        DiagnosticoMotivoAtencion2 = fila.GetCell(23).ToString(),
                        TipoDX2 = fila.GetCell(24).ToString(),
                        CIE10_2 = fila.GetCell(25).ToString(),
                        DiagnosticoMotivoAtencion3 = fila.GetCell(26).ToString(),
                        TipoDX3 = fila.GetCell(27).ToString(),
                        CIE10_3 = fila.GetCell(28).ToString(),
                        DiagnosticoMotivoAtencion4 = fila.GetCell(29).ToString(),
                        TipoDX4 = fila.GetCell(30).ToString(),
                        CIE10_4 = fila.GetCell(31).ToString(),
                        DiagnosticoMotivoAtencion5 = fila.GetCell(32).ToString(),
                        TipoDX5 = fila.GetCell(33).ToString(),
                        CIE10_5 = fila.GetCell(34).ToString(),
                        DiagnosticoMotivoAtencion6 = fila.GetCell(35).ToString(),
                        TipoDX6 = fila.GetCell(36).ToString(),
                        CIE10_6 = fila.GetCell(37).ToString(),
                        CodigoCondicionEgresoHospitalizacion = fila.GetCell(38).ToString(),
                        FechaIngreso = fila.GetCell(39).ToString(),
                        HoraIngreso = fila.GetCell(40).ToString(),
                        FechaEgreso = fila.GetCell(41).ToString(),
                        HoraEgreso = fila.GetCell(42).ToString(),
                        EspecialidadMedicoTratanteIngreso = fila.GetCell(43).ToString(),
                        NombreMedicoIngreso = fila.GetCell(44).ToString(),
                        DiagnosticoIngreso = fila.GetCell(45).ToString(),
                        EspecialidadMedicoTratanteEgreso = fila.GetCell(46).ToString(),
                        NombreMedicoEgreso = fila.GetCell(47).ToString()
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

            dt.Columns.AddRange(new DataColumn[49]
            {
                     new DataColumn("CodigoEntidadMilitar", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("CodigoEstablecimientoSaludMGP", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoUPS", typeof(string)),
                    new DataColumn("ResponsableRegistro", typeof(string)),
                    new DataColumn("NSACIP", typeof(int)),
                    new DataColumn("DNIResponsableSalud", typeof(string)),
                    new DataColumn("HistoriaClinica", typeof(string)),
                    new DataColumn("DNIPaciente", typeof(string)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("DistritoPaciente", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SituacionPaciente", typeof(string)),
                    new DataColumn("CondicionPaciente", typeof(string)),
                    new DataColumn("OrigenPaciente", typeof(string)),
                    new DataColumn("EdadPaciente", typeof(string)),
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
                    new DataColumn("CodigoCondicionEgresoHospitalizacion", typeof(string)),
                    new DataColumn("FechaIngreso", typeof(string)),
                    new DataColumn("HoraIngreso", typeof(string)),
                    new DataColumn("FechaEgreso", typeof(string)),
                    new DataColumn("HoraEgreso", typeof(string)),
                    new DataColumn("EspecialidadMedicoTratanteIngreso", typeof(string)),
                    new DataColumn("NombreMedicoIngreso", typeof(string)),
                    new DataColumn("DiagnosticoIngreso", typeof(string)),
                    new DataColumn("EspecialidadMedicoTratanteEgreso", typeof(string)),
                    new DataColumn("NombreMedicoEgreso", typeof(string)),
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
                    fila.GetCell(18).ToString(),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(39).ToString()),
                    fila.GetCell(40).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(41).ToString()),
                    fila.GetCell(42).ToString(),
                    fila.GetCell(43).ToString(),
                    fila.GetCell(44).ToString(),
                    fila.GetCell(45).ToString(),
                    fila.GetCell(46).ToString(),
                    fila.GetCell(47).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroEgresoHospitalarioBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }


        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\DisamarRegistroEgresoHospitalario.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = registroEgresoHospitalarioBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DisamarRegistroEgresoHospitalario.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DisamarRegistroEgresoHospitalario.xlsx");
        }

    }

}

