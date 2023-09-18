using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirciten;
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

    public class DircitenInformacionDocenteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        InformacionDocente informacionDocenteBL = new();

        CondicionLaboralDocente condicionLaboralDBL = new();
        RegimenLaboral regimenLaboralBL = new();
        NivelEstudio nivelEstudioBL = new();
        CarreraUniversitariaEspecialidad carreatrBL = new();
        Carga cargaBL = new();

        public DircitenInformacionDocenteController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Información Docente", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CondicionLaboralDocenteDTO> condicionLaboralDocenteDTO = condicionLaboralDBL.ObtenerCondicionLaboralDocentes();
            List<RegimenLaboralDTO> regimenLaboralDTO = regimenLaboralBL.ObtenerRegimenLaborals();
            List<NivelEstudioDTO> nivelEstudioDTO = nivelEstudioBL.ObtenerNivelEstudios();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = carreatrBL.ObtenerCarreraUniversitariaEspecialidads();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InformacionDocente");

            return Json(new
            {
                data1 = condicionLaboralDocenteDTO,
                data2 = regimenLaboralDTO,
                data3 = nivelEstudioDTO,
                data4 = carreraUniversitariaEspecialidadDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<InformacionDocenteDTO> select = informacionDocenteBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIDocenteDirciten, string TipoDocenteDirciten, string CodigoCondicionLaboralDocente,
           string CodigoRegimenLaboral, string DedicacionDocente, string CodigoNivelEstudio, string CodigoCarreraUniversitariaEspecialidad,
           int CargaId, string Fecha)
        {
            InformacionDocenteDTO informacionDocenteDTO = new();
            informacionDocenteDTO.DNIDocenteDirciten = DNIDocenteDirciten;
            informacionDocenteDTO.TipoDocenteDirciten = TipoDocenteDirciten;
            informacionDocenteDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            informacionDocenteDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            informacionDocenteDTO.DedicacionDocente = DedicacionDocente;
            informacionDocenteDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            informacionDocenteDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            informacionDocenteDTO.CargaId = CargaId;
            informacionDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = informacionDocenteBL.AgregarRegistro(informacionDocenteDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(informacionDocenteBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIDocenteDirciten, string TipoDocenteDirciten, string CodigoCondicionLaboralDocente,
           string CodigoRegimenLaboral, string DedicacionDocente, string CodigoNivelEstudio, string CodigoCarreraUniversitariaEspecialidad)
        {
            InformacionDocenteDTO informacionDocenteDTO = new();
            informacionDocenteDTO.InformacionDocenteId = Id;
            informacionDocenteDTO.DNIDocenteDirciten = DNIDocenteDirciten;
            informacionDocenteDTO.TipoDocenteDirciten = TipoDocenteDirciten;
            informacionDocenteDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            informacionDocenteDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            informacionDocenteDTO.DedicacionDocente = DedicacionDocente;
            informacionDocenteDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            informacionDocenteDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            informacionDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = informacionDocenteBL.ActualizarFormato(informacionDocenteDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InformacionDocenteDTO informacionDocenteDTO = new();
            informacionDocenteDTO.InformacionDocenteId = Id;
            informacionDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (informacionDocenteBL.EliminarFormato(informacionDocenteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            InformacionDocenteDTO informacionDocenteDTO = new();
            informacionDocenteDTO.CargaId = Id;
            informacionDocenteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (informacionDocenteBL.EliminarCarga(informacionDocenteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InformacionDocenteDTO> lista = new List<InformacionDocenteDTO>();
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

                    lista.Add(new InformacionDocenteDTO
                    {
                        DNIDocenteDirciten = fila.GetCell(0).ToString(),
                        TipoDocenteDirciten = fila.GetCell(1).ToString(),
                        CodigoCondicionLaboralDocente = fila.GetCell(2).ToString(),
                        CodigoRegimenLaboral = fila.GetCell(3).ToString(),
                        DedicacionDocente = fila.GetCell(4).ToString(),
                        CodigoNivelEstudio = fila.GetCell(5).ToString(),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(6).ToString(),

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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("DNIDocenteDirciten", typeof(string)),
                    new DataColumn("TipoDocenteDirciten", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralDocente", typeof(string)),
                    new DataColumn("CodigoRegimenLaboral", typeof(string)),
                    new DataColumn("DedicacionDocente ", typeof(string)),
                    new DataColumn("CodigoNivelEstudio ", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad ", typeof(string)),

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
                    fila.GetCell(6).ToString(),


                    User.obtenerUsuario());
            }
            var IND_OPERACION = informacionDocenteBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDID(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirciten\\InformacionDocente.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = informacionDocenteBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("InformacionDocente", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DircitenInformacionDocente.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DircitenInformacionDocente.xlsx");
        }

    }
}

