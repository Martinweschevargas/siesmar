using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirtel;
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
    public class DirtelPerfilProfesionalSistemaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        PerfilProfesionalSistema perfilProfesionalSistemaBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        PerfilProfesional perfilProfesionalBL = new();
        Carga cargaBL = new();

        public DirtelPerfilProfesionalSistemaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Perfiles Profesionales del Personal que Labora en el Area de Desarrollo de Sistemas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<PerfilProfesionalDTO> perfilProfesionalDTO = perfilProfesionalBL.ObtenerPerfilProfesionals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PerfilProfesionalSistema");

            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = perfilProfesionalDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<PerfilProfesionalSistemaDTO> perfilProfesionalSistemaDTO = perfilProfesionalSistemaBL.ObtenerLista();

            return Json(new { data = perfilProfesionalSistemaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string DNIProfesionaleSistema, string CodigoPerfilProfesional, string CodigoGradoPersonalMilitar,
            int AnioExperienciaSistema, string TipoPersonalProfesional, string NivelEspecializacionSistema, 
            int TiempoServicioInstitucion, int CargaId)
        {
            PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO = new();
            perfilProfesionalSistemaDTO.DNIProfesionaleSistema = DNIProfesionaleSistema;
            perfilProfesionalSistemaDTO.TipoPersonalProfesional = TipoPersonalProfesional;
            perfilProfesionalSistemaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            perfilProfesionalSistemaDTO.NivelEspecializacionSistema = NivelEspecializacionSistema;
            perfilProfesionalSistemaDTO.CodigoPerfilProfesional = CodigoPerfilProfesional;
            perfilProfesionalSistemaDTO.AnioExperienciaSistema = AnioExperienciaSistema;
            perfilProfesionalSistemaDTO.TiempoServicioInstitucion = TiempoServicioInstitucion;
            perfilProfesionalSistemaDTO.CargaId = CargaId;
            perfilProfesionalSistemaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = perfilProfesionalSistemaBL.AgregarRegistro(perfilProfesionalSistemaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(perfilProfesionalSistemaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int PerfilProfesionalSistemaId , string DNIProfesionaleSistema, string CodigoPerfilProfesional, string CodigoGradoPersonalMilitar,
            int AnioExperienciaSistema, string TipoPersonalProfesional, string NivelEspecializacionSistema,
            int TiempoServicioInstitucion)
        {
            PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO = new();
            perfilProfesionalSistemaDTO.PerfilProfesionalSistemaId = PerfilProfesionalSistemaId;
            perfilProfesionalSistemaDTO.DNIProfesionaleSistema = DNIProfesionaleSistema;
            perfilProfesionalSistemaDTO.TipoPersonalProfesional = TipoPersonalProfesional;
            perfilProfesionalSistemaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            perfilProfesionalSistemaDTO.NivelEspecializacionSistema = NivelEspecializacionSistema;
            perfilProfesionalSistemaDTO.CodigoPerfilProfesional = CodigoPerfilProfesional;
            perfilProfesionalSistemaDTO.AnioExperienciaSistema = AnioExperienciaSistema;
            perfilProfesionalSistemaDTO.TiempoServicioInstitucion = TiempoServicioInstitucion;
            perfilProfesionalSistemaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = perfilProfesionalSistemaBL.ActualizarFormato(perfilProfesionalSistemaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PerfilProfesionalSistemaDTO perfilProfesionalSistemaDTO = new();
            perfilProfesionalSistemaDTO.PerfilProfesionalSistemaId = Id;
            perfilProfesionalSistemaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (perfilProfesionalSistemaBL.EliminarFormato(perfilProfesionalSistemaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PerfilProfesionalSistemaDTO> lista = new List<PerfilProfesionalSistemaDTO>();
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

                    lista.Add(new PerfilProfesionalSistemaDTO
                    {
                        DNIProfesionaleSistema = fila.GetCell(0).ToString(),
                        TipoPersonalProfesional = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        NivelEspecializacionSistema = fila.GetCell(3).ToString(),
                        CodigoPerfilProfesional = fila.GetCell(4).ToString(),
                        AnioExperienciaSistema = int.Parse(fila.GetCell(5).ToString()),
                        TiempoServicioInstitucion = int.Parse(fila.GetCell(6).ToString()),

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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("DNIProfesionaleSistema ", typeof(string)),
                    new DataColumn("TipoPersonalProfesional  ", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar  ", typeof(string)),
                    new DataColumn("NivelEspecializacionSistema  ", typeof(string)),
                    new DataColumn("CodigoPerfilProfesional  ", typeof(string)),
                    new DataColumn("AnioExperienciaSistema  ", typeof(int)),
                    new DataColumn("TiempoServicioInstitucion   ", typeof(int)),

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
                   int.Parse(fila.GetCell(5).ToString()),
                   int.Parse(fila.GetCell(6).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = perfilProfesionalSistemaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDPPS(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirtel\\PerfilProfesionalSistema.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = perfilProfesionalSistemaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PerfilProfesionalSistema", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\PerfilProfesionalSistema.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "PerfilProfesionalSistema.xlsx");
        }
    }

}
