using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Bienestar;
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

    public class BienestarDocenteInstitucioesEducativasController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        DocenteInstitucioesEducativas docenteInstitucioesEducativasBL = new();

        CondicionLaboralDocente condicionLaboralDocenteBL = new();
        DocenteCategoria docenteCategoriaBL = new();
        GradoEstudioAlcanzado gradoEstudioAlcanzadoBL = new();
        InstitucionEducativa institucionEducativaBL = new();
        Carga cargaBL = new();

        public BienestarDocenteInstitucioesEducativasController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Docentes de las Instituciones Educativas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CondicionLaboralDocenteDTO> condicionLaboralDocenteDTO = condicionLaboralDocenteBL.ObtenerCondicionLaboralDocentes();
            List<DocenteCategoriaDTO> docenteCategoriaDTO = docenteCategoriaBL.ObtenerDocenteCategorias();
            List<GradoEstudioAlcanzadoDTO> gradoEstudioAlcanzadoDTO = gradoEstudioAlcanzadoBL.ObtenerGradoEstudioAlcanzados();
            List<InstitucionEducativaDTO> institucionEducativaDTO = institucionEducativaBL.ObtenerInstitucionEducativas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DocenteInstitucionEducativa");

            return Json(new { data1 = condicionLaboralDocenteDTO, data2 = docenteCategoriaDTO, data3 = gradoEstudioAlcanzadoDTO ,
                data4 = institucionEducativaDTO, data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<DocenteInstitucioesEducativasDTO> select = docenteInstitucioesEducativasBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }
        public ActionResult Insertar(string DNIDocente, string SexoDocente, string JornadaLaboral, string CodigoDocenteCategoria, string CodigoGradoEstudioAlcanzado,
            string CodigoInstitucionEducativa, string CodigoCondicionLaboralDocente, int CargaId, string fecha)
        {
            DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO = new();
            docenteInstitucioesEducativasDTO.DNIDocente = DNIDocente;
            docenteInstitucioesEducativasDTO.SexoDocente = SexoDocente;
            docenteInstitucioesEducativasDTO.JornadaLaboral = JornadaLaboral;
            docenteInstitucioesEducativasDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docenteInstitucioesEducativasDTO.CodigoDocenteCategoria = CodigoDocenteCategoria;
            docenteInstitucioesEducativasDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            docenteInstitucioesEducativasDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            docenteInstitucioesEducativasDTO.CargaId = CargaId;
            docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docenteInstitucioesEducativasBL.AgregarRegistro(docenteInstitucioesEducativasDTO, fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(docenteInstitucioesEducativasBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIDocente, string SexoDocente, string JornadaLaboral, string CodigoDocenteCategoria, string CodigoGradoEstudioAlcanzado,
            string CodigoInstitucionEducativa, string CodigoCondicionLaboralDocente)
        {
            DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO = new();
            docenteInstitucioesEducativasDTO.DocenteInstitucionEducativaId = Id;
            docenteInstitucioesEducativasDTO.DNIDocente = DNIDocente;
            docenteInstitucioesEducativasDTO.SexoDocente = SexoDocente;
            docenteInstitucioesEducativasDTO.JornadaLaboral = JornadaLaboral;
            docenteInstitucioesEducativasDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docenteInstitucioesEducativasDTO.CodigoDocenteCategoria = CodigoDocenteCategoria;
            docenteInstitucioesEducativasDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            docenteInstitucioesEducativasDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docenteInstitucioesEducativasBL.ActualizarFormato(docenteInstitucioesEducativasDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO = new();
            docenteInstitucioesEducativasDTO.DocenteInstitucionEducativaId = Id;
            docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (docenteInstitucioesEducativasBL.EliminarFormato(docenteInstitucioesEducativasDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DocenteInstitucioesEducativasDTO docenteInstitucioesEducativasDTO = new();
            docenteInstitucioesEducativasDTO.CargaId = Id;
            docenteInstitucioesEducativasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (docenteInstitucioesEducativasBL.EliminarCarga(docenteInstitucioesEducativasDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DocenteInstitucioesEducativasDTO> lista = new List<DocenteInstitucioesEducativasDTO>();
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

                    lista.Add(new DocenteInstitucioesEducativasDTO
                    {
                        DNIDocente = fila.GetCell(0).ToString(),
                        SexoDocente = fila.GetCell(1).ToString(),
                        JornadaLaboral = fila.GetCell(2).ToString(),
                        CodigoCondicionLaboralDocente = fila.GetCell(3).ToString(),
                        CodigoDocenteCategoria = fila.GetCell(4).ToString(),
                        CodigoGradoEstudioAlcanzado = fila.GetCell(5).ToString(),
                        CodigoInstitucionEducativa = fila.GetCell(6).ToString()
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
                    new DataColumn("DNIDocente", typeof(string)),
                    new DataColumn("SexoDocente", typeof(string)),
                    new DataColumn("JornadaLaboral", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralDocente", typeof(string)),
                    new DataColumn("CodigoDocenteCategoria", typeof(string)),
                    new DataColumn("CodigoGradoEstudioAlcanzado", typeof(string)),
                    new DataColumn("CodigoInstitucionEducativa", typeof(string)),
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
            var IND_OPERACION = docenteInstitucioesEducativasBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        //public IActionResult ReporteDIE(int? idCarga=null, string fechaInicio=null, string fechaFin=null)
        //{
        //    string mimtype = "";
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\DocenteInstitucionEducativa.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var docenteInstitucionEducativa = docenteInstitucioesEducativasBL.BienestarVisualizacionDocenteInstitucionEducativa(idCarga, fechaInicio, fechaFin);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("DocenteInstitucionEducativa", docenteInstitucionEducativa);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarDocenteInstitucioesEducativas.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarDocenteInstitucioesEducativas.xlsx");
        }
    }

}

