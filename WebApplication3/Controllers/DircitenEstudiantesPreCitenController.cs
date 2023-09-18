using AspNetCore.Reporting;
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
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DircitenEstudiantesPreCitenController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EstudiantesPreCiten estudiantesPreCitenBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public DircitenEstudiantesPreCitenController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Estudiantes del Pre CITEN", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EstudiantePreCiten");
            return Json(new
            {
                data1 = distritoUbigeoDTO,
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EstudiantesPreCitenDTO> select = estudiantesPreCitenBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIEstudiantePreCiten, string GeneroEstudiantePreCiten, string FechaNacimiento,
           string LugarDomicilio, string TipoColegioProcedencia, string ColegioProcedencia, string LugarColegio, int CargaId, string Fecha)
        {
            EstudiantesPreCitenDTO estudiantesPreCitenDTO = new();
            estudiantesPreCitenDTO.DNIEstudiantePreCiten = DNIEstudiantePreCiten;
            estudiantesPreCitenDTO.GeneroEstudiantePreCiten = GeneroEstudiantePreCiten;
            estudiantesPreCitenDTO.FechaNacimiento = FechaNacimiento;
            estudiantesPreCitenDTO.LugarDomicilio = LugarDomicilio;
            estudiantesPreCitenDTO.TipoColegioProcedencia = TipoColegioProcedencia;
            estudiantesPreCitenDTO.ColegioProcedencia = ColegioProcedencia;
            estudiantesPreCitenDTO.LugarColegio = LugarColegio;
            estudiantesPreCitenDTO.CargaId = CargaId;
            estudiantesPreCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estudiantesPreCitenBL.AgregarRegistro(estudiantesPreCitenDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(estudiantesPreCitenBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIEstudiantePreCiten, string GeneroEstudiantePreCiten, string FechaNacimiento,
           string LugarDomicilio, string TipoColegioProcedencia, string ColegioProcedencia, string LugarColegio)
        {
            EstudiantesPreCitenDTO estudiantesPreCitenDTO = new();
            estudiantesPreCitenDTO.EstudiantePreCitenId = Id;
            estudiantesPreCitenDTO.DNIEstudiantePreCiten = DNIEstudiantePreCiten;
            estudiantesPreCitenDTO.GeneroEstudiantePreCiten = GeneroEstudiantePreCiten;
            estudiantesPreCitenDTO.FechaNacimiento = FechaNacimiento;
            estudiantesPreCitenDTO.LugarDomicilio = LugarDomicilio;
            estudiantesPreCitenDTO.TipoColegioProcedencia = TipoColegioProcedencia;
            estudiantesPreCitenDTO.ColegioProcedencia = ColegioProcedencia;
            estudiantesPreCitenDTO.LugarColegio = LugarColegio;
            estudiantesPreCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = estudiantesPreCitenBL.ActualizarFormato(estudiantesPreCitenDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EstudiantesPreCitenDTO estudiantesPreCitenDTO = new();
            estudiantesPreCitenDTO.EstudiantePreCitenId = Id;
            estudiantesPreCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (estudiantesPreCitenBL.EliminarFormato(estudiantesPreCitenDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EstudiantesPreCitenDTO estudiantesPreCitenDTO = new();
            estudiantesPreCitenDTO.CargaId = Id;
            estudiantesPreCitenDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (estudiantesPreCitenBL.EliminarCarga(estudiantesPreCitenDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EstudiantesPreCitenDTO> lista = new List<EstudiantesPreCitenDTO>();
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

                    lista.Add(new EstudiantesPreCitenDTO
                    {
                        DNIEstudiantePreCiten = fila.GetCell(0).ToString(),
                        GeneroEstudiantePreCiten = fila.GetCell(1).ToString(),
                        FechaNacimiento = fila.GetCell(2).ToString(),
                        LugarDomicilio = fila.GetCell(3).ToString(),
                        TipoColegioProcedencia = fila.GetCell(4).ToString(),
                        ColegioProcedencia = fila.GetCell(5).ToString(),
                        LugarColegio = fila.GetCell(6).ToString()
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje = "";

            IWorkbook MiExcel = null;

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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("DNIEstudiantePreCiten", typeof(string)),
                    new DataColumn("GeneroEstudiantePreCiten", typeof(string)),
                    new DataColumn("FechaNacimiento", typeof(string)),
                    new DataColumn("LugarDomicilio", typeof(string)),
                    new DataColumn("TipoColegioProcedencia", typeof(string)),
                    new DataColumn("ColegioProcedencia", typeof(string)),
                    new DataColumn("LugarColegio", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                             fila.GetCell(0).ToString(),
                             fila.GetCell(1).ToString(),
                            UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                             fila.GetCell(3).ToString(),
                             fila.GetCell(4).ToString(),
                             fila.GetCell(5).ToString(),
                             fila.GetCell(6).ToString(),
                             User.obtenerUsuario());
            }
            var IND_OPERACION = estudiantesPreCitenBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = estudiantesPreCitenBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DircitenEstudiantesPreCiten.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DircitenEstudiantesPreCiten.xlsx");
        }

    }

}

