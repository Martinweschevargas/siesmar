using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresprom;
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

    public class DirespromDocente2daEspecializacionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Docente2daEspecializacion docente2daEspecializacionBL = new();
        CondicionLaboralDocenteDAO condicionLaboralDocenteBL = new();
        RegimenLaboralDAO regimenLaboralBL = new();
        NivelEstudioDAO nivelEstudioBL = new();
        CarreraUniversitariaEspecialidadDAO carreraUniversitariaEspecialidadBL = new();
        Carga cargaBL = new();

        public DirespromDocente2daEspecializacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina - DIRESPROM", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CondicionLaboralDocenteDTO> condicionLaboralDocenteDTO = condicionLaboralDocenteBL.ObtenerCondicionLaboralDocentes();
            List<RegimenLaboralDTO> regimenLaboralDTO = regimenLaboralBL.ObtenerRegimenLaborals();
            List<NivelEstudioDTO> nivelEstudioDTO = nivelEstudioBL.ObtenerNivelEstudios();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = carreraUniversitariaEspecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("Docente2daEspecializacion");

            return Json(new { 
                data1 = condicionLaboralDocenteDTO, 
                data2 = regimenLaboralDTO,  
                data3 = nivelEstudioDTO,
                data4 = carreraUniversitariaEspecialidadDTO, 
                data5 = listaCargas

            });
        }

        public IActionResult CargaTabla()
        {
            List<Docente2daEspecializacionDTO> select = docente2daEspecializacionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(int DNIPersonalDocente, string TipoPersonalDocente, string CodigoCondicionLaboralDocente, 
            string CodigoRegimenLaboral, string DedicacionTiempoDocente, string CodigoNivelEstudio,
            string CodigoCarreraUniversitariaEspecialidad, int CargaId, string Fecha)
        {
            Docente2daEspecializacionDTO docente2daEspecializacionDTO = new();
            docente2daEspecializacionDTO.DNIPersonalDocente = DNIPersonalDocente;
            docente2daEspecializacionDTO.TipoPersonalDocente = TipoPersonalDocente;
            docente2daEspecializacionDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docente2daEspecializacionDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            docente2daEspecializacionDTO.DedicacionTiempoDocente = DedicacionTiempoDocente;
            docente2daEspecializacionDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            docente2daEspecializacionDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docente2daEspecializacionDTO.CargaId = CargaId;
            docente2daEspecializacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docente2daEspecializacionBL.AgregarRegistro(docente2daEspecializacionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(docente2daEspecializacionBL.EditarFormado(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int DNIPersonalDocente, string TipoPersonalDocente, string CodigoCondicionLaboralDocente,
            string CodigoRegimenLaboral, string DedicacionTiempoDocente, string CodigoNivelEstudio,
            string CodigoCarreraUniversitariaEspecialidad)
        {
            Docente2daEspecializacionDTO docente2daEspecializacionDTO = new();
            docente2daEspecializacionDTO.Docente2daEspecializacionId = Id;
            docente2daEspecializacionDTO.DNIPersonalDocente = DNIPersonalDocente;
            docente2daEspecializacionDTO.TipoPersonalDocente = TipoPersonalDocente;
            docente2daEspecializacionDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docente2daEspecializacionDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            docente2daEspecializacionDTO.DedicacionTiempoDocente = DedicacionTiempoDocente;
            docente2daEspecializacionDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            docente2daEspecializacionDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docente2daEspecializacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docente2daEspecializacionBL.ActualizarFormato(docente2daEspecializacionDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            Docente2daEspecializacionDTO docente2daEspecializacionDTO = new();
            docente2daEspecializacionDTO.Docente2daEspecializacionId = Id;
            docente2daEspecializacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (docente2daEspecializacionBL.EliminarFormato(docente2daEspecializacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            Docente2daEspecializacionDTO docente2daEspecializacionDTO = new();
            docente2daEspecializacionDTO.CargaId = Id;
            docente2daEspecializacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (docente2daEspecializacionBL.EliminarCarga(docente2daEspecializacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<Docente2daEspecializacionDTO> lista = new List<Docente2daEspecializacionDTO>();
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

                    lista.Add(new Docente2daEspecializacionDTO
                    {
                        DNIPersonalDocente = int.Parse(fila.GetCell(0).ToString()),
                        TipoPersonalDocente = fila.GetCell(1).ToString(),
                        CodigoCondicionLaboralDocente = fila.GetCell(2).ToString(),
                        CodigoRegimenLaboral = fila.GetCell(3).ToString(),
                        DedicacionTiempoDocente = fila.GetCell(4).ToString(),
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
                    new DataColumn("DNIPersonalDocente", typeof(string)),
                    new DataColumn("TipoPersonalDocente", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralDocente", typeof(string)),
                    new DataColumn("CodigoRegimenLaboral", typeof(string)),
                    new DataColumn("DedicacionTiempoDocente", typeof(string)),
                    new DataColumn("CodigoNivelEstudio", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = docente2daEspecializacionBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirespromDocente2daEspecializacion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirespromDocente2daEspecializacion.xlsx");
        }
    }

}

