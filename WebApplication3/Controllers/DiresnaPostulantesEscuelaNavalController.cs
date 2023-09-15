using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresna;
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

    public class DiresnaPostulantesEscuelaNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PostulantesEscuelaNaval postulantesEscuelaNavalBL = new();
        InstitucionEducativa institucionEducativaBL = new();
        EntidadMilitar entidadMilitarBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        CarreraUniversitariaEspecialidad carreraUniversitariaEspecialidadBL = new();
        ModalidadIngresoEsna modalidadIngresoEsnaBL = new();
        ZonaNaval zonaNavalBL = new();
        PublicidadEsna publicidadEsnaBL = new();
        DepartamentoUbigeo departamentoBL = new();
        ProvinciaUbigeo provinciaBL = new();
        DistritoUbigeo distritoBL = new();
        Carga cargaBL = new();

        public DiresnaPostulantesEscuelaNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Postulantes a la Escuela Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<InstitucionEducativaDTO> institucionEducativaDTO = institucionEducativaBL.ObtenerInstitucionEducativas();
            List<EntidadMilitarDTO> entidadMilitarDTO = entidadMilitarBL.ObtenerEntidadMilitars();
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = carreraUniversitariaEspecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            List<ModalidadIngresoEsnaDTO> modalidadIngresoEsnaDTO = modalidadIngresoEsnaBL.ObtenerModalidadIngresoEsnas();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<PublicidadEsnaDTO> publicidadEsnaDTO = publicidadEsnaBL.ObtenerPublicidadEsnas();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PostulantesEscuelaNaval");

            return Json(new { data1 = institucionEducativaDTO, data2 = entidadMilitarDTO,  data3 = tipoPersonalMilitarDTO,
                data4 = carreraUniversitariaEspecialidadDTO, data5 = modalidadIngresoEsnaDTO, data6 = zonaNavalDTO, 
                data7 = publicidadEsnaDTO,
                data8 = distritoUbigeoDTO,
                data9 = provinciaUbigeoDTO,
                data10 = departamentoUbigeoDTO,
                data11 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<PostulantesEscuelaNavalDTO> select = postulantesEscuelaNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string DNIPostulante, string SexoPostulante, string FechaNacimientoPostulante, decimal TallaPostulante,
            decimal PesoPostulante, string UbigeoNacimiento, string UbigeoDomicilio, string TipoInstitucionEducativa,
            string CodigoInstitucionEducativa, string UbigeoInstitucion, string PadresMilitar, string CodigoEntidadMilitar, string CodigoTipoPersonalMilitar,
            string CodigoCarreraUniversitariaEspecialidad, string ConcursoAdmision, string CodigoModalidadIngresoEsna, string TipoPreparacion,
            string DeportistaCalificado, string CodigoZonaNaval, int QVecesPostulacion, string CodigoPublicidadEsna,
            string SituacionIngreso, int CargaId)
        {
            PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO = new();
            postulantesEscuelaNavalDTO.DNIPostulante = DNIPostulante;
            postulantesEscuelaNavalDTO.SexoPostulante = SexoPostulante;
            postulantesEscuelaNavalDTO.FechaNacimientoPostulante = FechaNacimientoPostulante;
            postulantesEscuelaNavalDTO.TallaPostulante = TallaPostulante;
            postulantesEscuelaNavalDTO.PesoPostulante = PesoPostulante;
            postulantesEscuelaNavalDTO.UbigeoNacimiento = UbigeoNacimiento;
            postulantesEscuelaNavalDTO.UbigeoDomicilio = UbigeoDomicilio;
            postulantesEscuelaNavalDTO.TipoInstitucionEducativa = TipoInstitucionEducativa;
            postulantesEscuelaNavalDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            postulantesEscuelaNavalDTO.UbigeoInstitucion = UbigeoInstitucion;
            postulantesEscuelaNavalDTO.PadresMilitar = PadresMilitar;
            postulantesEscuelaNavalDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            postulantesEscuelaNavalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            postulantesEscuelaNavalDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            postulantesEscuelaNavalDTO.ConcursoAdmision = ConcursoAdmision;
            postulantesEscuelaNavalDTO.CodigoModalidadIngresoEsna = CodigoModalidadIngresoEsna;
            postulantesEscuelaNavalDTO.TipoPreparacion = TipoPreparacion;
            postulantesEscuelaNavalDTO.DeportistaCalificado = DeportistaCalificado;
            postulantesEscuelaNavalDTO.CodigoZonaNaval = CodigoZonaNaval;
            postulantesEscuelaNavalDTO.QVecesPostulacion = QVecesPostulacion;
            postulantesEscuelaNavalDTO.CodigoPublicidadEsna = CodigoPublicidadEsna;
            postulantesEscuelaNavalDTO.SituacionIngreso = SituacionIngreso;
            postulantesEscuelaNavalDTO.CargaId = CargaId;
            postulantesEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = postulantesEscuelaNavalBL.AgregarRegistro(postulantesEscuelaNavalDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(postulantesEscuelaNavalBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIPostulante, string SexoPostulante, string FechaNacimientoPostulante, decimal TallaPostulante,
            decimal PesoPostulante, string UbigeoNacimiento, string UbigeoDomicilio, string TipoInstitucionEducativa,
            string CodigoInstitucionEducativa, string UbigeoInstitucion, string PadresMilitar, string CodigoEntidadMilitar, string CodigoTipoPersonalMilitar,
            string CodigoCarreraUniversitariaEspecialidad, string ConcursoAdmision, string CodigoModalidadIngresoEsna, string TipoPreparacion,
            string DeportistaCalificado, string CodigoZonaNaval, int QVecesPostulacion, string CodigoPublicidadEsna, string SituacionIngreso)
        {
            PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO = new();
            postulantesEscuelaNavalDTO.PostulanteEscuelaNavalId = Id;
            postulantesEscuelaNavalDTO.DNIPostulante = DNIPostulante;
            postulantesEscuelaNavalDTO.SexoPostulante = SexoPostulante;
            postulantesEscuelaNavalDTO.FechaNacimientoPostulante = FechaNacimientoPostulante;
            postulantesEscuelaNavalDTO.TallaPostulante = TallaPostulante;
            postulantesEscuelaNavalDTO.PesoPostulante = PesoPostulante;
            postulantesEscuelaNavalDTO.UbigeoNacimiento = UbigeoNacimiento;
            postulantesEscuelaNavalDTO.UbigeoDomicilio = UbigeoDomicilio;
            postulantesEscuelaNavalDTO.TipoInstitucionEducativa = TipoInstitucionEducativa;
            postulantesEscuelaNavalDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            postulantesEscuelaNavalDTO.UbigeoInstitucion = UbigeoInstitucion;
            postulantesEscuelaNavalDTO.PadresMilitar = PadresMilitar;
            postulantesEscuelaNavalDTO.CodigoEntidadMilitar = CodigoEntidadMilitar;
            postulantesEscuelaNavalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            postulantesEscuelaNavalDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            postulantesEscuelaNavalDTO.ConcursoAdmision = ConcursoAdmision;
            postulantesEscuelaNavalDTO.CodigoModalidadIngresoEsna = CodigoModalidadIngresoEsna;
            postulantesEscuelaNavalDTO.TipoPreparacion = TipoPreparacion;
            postulantesEscuelaNavalDTO.DeportistaCalificado = DeportistaCalificado;
            postulantesEscuelaNavalDTO.CodigoZonaNaval = CodigoZonaNaval;
            postulantesEscuelaNavalDTO.QVecesPostulacion = QVecesPostulacion;
            postulantesEscuelaNavalDTO.CodigoPublicidadEsna = CodigoPublicidadEsna;
            postulantesEscuelaNavalDTO.SituacionIngreso = SituacionIngreso;
            postulantesEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = postulantesEscuelaNavalBL.ActualizarFormato(postulantesEscuelaNavalDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO = new();
            postulantesEscuelaNavalDTO.PostulanteEscuelaNavalId = Id;
            postulantesEscuelaNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (postulantesEscuelaNavalBL.EliminarFormato(postulantesEscuelaNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PostulantesEscuelaNavalDTO> lista = new List<PostulantesEscuelaNavalDTO>();
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

                    lista.Add(new PostulantesEscuelaNavalDTO
                    {
                        DNIPostulante = fila.GetCell(0).ToString(),
                        SexoPostulante = fila.GetCell(1).ToString(),
                        FechaNacimientoPostulante = fila.GetCell(2).ToString(),
                        TallaPostulante = decimal.Parse(fila.GetCell(3).ToString()),
                        PesoPostulante = decimal.Parse(fila.GetCell(4).ToString()),
                        UbigeoNacimiento = fila.GetCell(5).ToString(),
                        UbigeoDomicilio = fila.GetCell(6).ToString(),
                        TipoInstitucionEducativa = fila.GetCell(7).ToString(),
                        CodigoInstitucionEducativa = fila.GetCell(8).ToString(),
                        UbigeoInstitucion = fila.GetCell(9).ToString(),
                        PadresMilitar = fila.GetCell(10).ToString(),
                        CodigoEntidadMilitar = fila.GetCell(11).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(12).ToString(),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(13).ToString(),
                        ConcursoAdmision = fila.GetCell(14).ToString(),
                        CodigoModalidadIngresoEsna = fila.GetCell(15).ToString(),
                        TipoPreparacion = fila.GetCell(16).ToString(),
                        DeportistaCalificado = fila.GetCell(17).ToString(),
                        CodigoZonaNaval = fila.GetCell(18).ToString(),
                        QVecesPostulacion = int.Parse(fila.GetCell(19).ToString()),
                        CodigoPublicidadEsna  = fila.GetCell(20).ToString(),
                        SituacionIngreso = fila.GetCell(21).ToString(),

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

            dt.Columns.AddRange(new DataColumn[23]
            {
                    new DataColumn("DNIPostulante ", typeof(string)),
                    new DataColumn("SexoPostulante ", typeof(string)),
                    new DataColumn("FechaNacimientoPostulante ", typeof(string)),
                    new DataColumn("TallaPostulante ", typeof(decimal)),
                    new DataColumn("PesoPostulante ", typeof(decimal)),
                    new DataColumn("UbigeoNacimiento ", typeof(string)),
                    new DataColumn("UbigeoDomicilio ", typeof(string)),
                    new DataColumn("TipoInstitucionEducativa ", typeof(int)),
                    new DataColumn("CodigoInstitucionEducativa ", typeof(string)),
                    new DataColumn("UbigeoInstitucion ", typeof(string)),
                    new DataColumn("PadresMilitar", typeof(string)),
                    new DataColumn("CodigoEntidadMilitar ", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar ", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad ", typeof(string)),
                    new DataColumn("ConcursoAdmision ", typeof(string)),
                    new DataColumn("CodigoModalidadIngresoEsna", typeof(string)),
                    new DataColumn("TipoPreparacion ", typeof(string)),
                    new DataColumn("DeportistaCalificado ", typeof(string)),
                    new DataColumn("CodigoZonaNaval ", typeof(string)),
                    new DataColumn("QVecesPostulacion ", typeof(int)),
                    new DataColumn("CodigoPublicidadEsna", typeof(string)),
                    new DataColumn("SituacionIngreso", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
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
                    fila.GetCell(18).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    fila.GetCell(20).ToString(),
                    fila.GetCell(21).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = postulantesEscuelaNavalBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }



        public IActionResult ReporteDPEN()
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresna\\PostulantesEscuelaNaval.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var personalSuperiorSubalterno = postulantesEscuelaNavalBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PostulantesEscuelaNaval", personalSuperiorSubalterno);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\PostulantesEscuelaNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "PostulantesEscuelaNaval.xlsx");
        }
    }

}