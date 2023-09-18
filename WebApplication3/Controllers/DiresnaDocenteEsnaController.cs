using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
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

    public class DiresnaDocenteEsnaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        DocenteEsna docenteEsnaBL = new();
        CondicionLaboralDocente condicionLaboralDocenteBL = new();
        RegimenLaboral regimenLaboralBL = new();
        NivelEstudio nivelEstudioBL = new();
        CarreraUniversitariaEspecialidad carreraUniversitariaEspecialidadBL = new();
        Carga cargaBL = new();

        public DiresnaDocenteEsnaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Docentes Diresna", FromController = typeof(HomeController))]
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DocenteEsna");

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
            List<DocenteEsnaDTO> select = docenteEsnaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIDocenteEsna, string TipoDocente, string CodigoCondicionLaboralDocente, string CodigoRegimenLaborar,
            string DedicacionDocente, string CodigoNivelEstudio, string CodigoCarreraUniversitariaEspecialidad, int ExperienciaDocente,
            int ExperienciaDocenteMarina, int CargaId, string Fecha)
        {
            DocenteEsnaDTO docenteEsnaDTO = new();
            docenteEsnaDTO.DNIDocenteEsna = DNIDocenteEsna;
            docenteEsnaDTO.TipoDocente = TipoDocente;
            docenteEsnaDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docenteEsnaDTO.CodigoRegimenLaboral = CodigoRegimenLaborar;
            docenteEsnaDTO.DedicacionDocente = DedicacionDocente;
            docenteEsnaDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            docenteEsnaDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docenteEsnaDTO.ExperienciaDocente = ExperienciaDocente;
            docenteEsnaDTO.ExperienciaDocenteMarina = ExperienciaDocenteMarina;
            docenteEsnaDTO.CargaId = CargaId;
            docenteEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docenteEsnaBL.AgregarRegistro(docenteEsnaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(docenteEsnaBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIDocenteEsna, string TipoDocente, string CodigoCondicionLaboralDocente, string CodigoRegimenLaborar,
            string DedicacionDocente, string CodigoNivelEstudio, string CodigoCarreraUniversitariaEspecialidad, int ExperienciaDocente,
            int ExperienciaDocenteMarina)
        {
            DocenteEsnaDTO docenteEsnaDTO = new();
            docenteEsnaDTO.DocenteEsnaId = Id;
            docenteEsnaDTO.DNIDocenteEsna = DNIDocenteEsna;
            docenteEsnaDTO.TipoDocente = TipoDocente;
            docenteEsnaDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docenteEsnaDTO.CodigoRegimenLaboral = CodigoRegimenLaborar;
            docenteEsnaDTO.DedicacionDocente = DedicacionDocente;
            docenteEsnaDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            docenteEsnaDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docenteEsnaDTO.ExperienciaDocente = ExperienciaDocente;
            docenteEsnaDTO.ExperienciaDocenteMarina = ExperienciaDocenteMarina;
            docenteEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docenteEsnaBL.ActualizarFormato(docenteEsnaDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DocenteEsnaDTO docenteEsnaDTO = new();
            docenteEsnaDTO.DocenteEsnaId = Id;
            docenteEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (docenteEsnaBL.EliminarFormato(docenteEsnaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DocenteEsnaDTO docenteEsnaDTO = new();
            docenteEsnaDTO.CargaId = Id;
            docenteEsnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (docenteEsnaBL.EliminarCarga(docenteEsnaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DocenteEsnaDTO> lista = new List<DocenteEsnaDTO>();
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

                    lista.Add(new DocenteEsnaDTO
                    {
                        DNIDocenteEsna = fila.GetCell(0).ToString(),
                        TipoDocente = fila.GetCell(1).ToString(),
                        CodigoCondicionLaboralDocente = fila.GetCell(2).ToString(),
                        CodigoRegimenLaboral = fila.GetCell(3).ToString(),
                        DedicacionDocente = fila.GetCell(4).ToString(),
                        CodigoNivelEstudio = fila.GetCell(5).ToString(),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(6).ToString(),
                        ExperienciaDocente = int.Parse(fila.GetCell(7).ToString()),
                        ExperienciaDocenteMarina = int.Parse(fila.GetCell(8).ToString()),

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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("DNIDocenteEsna", typeof(string)),
                    new DataColumn("TipoDocente", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralDocente", typeof(string)),
                    new DataColumn("CodigoRegimenLaboral", typeof(string)),
                    new DataColumn("DedicacionDocente", typeof(string)),
                    new DataColumn("CodigoNivelEstudio", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad", typeof(string)),
                    new DataColumn("ExperienciaDocente", typeof(string)),
                    new DataColumn("ExperienciaDocenteMarina", typeof(string)),

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
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = docenteEsnaBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDDE(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresna\\DocenteEsna.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = docenteEsnaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DocenteEsna", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiresnaDocenteEsna.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiresnaDocenteEsna.xlsx");
        }
    }

}
