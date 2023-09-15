using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
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
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class BienestarPoblacionEstudiantilMatriculadosController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        PoblacionEstudiantilMatriculados poblacionEstudiantilMatriculadoBL = new();
        InstitucionEducativa institucionEducativaBL = new();
        NivelEstudio nivelEstudioBL = new();
        SeccionEstudio seccionEstudioBL = new();
        CategoriaPago categoriaPagoBL = new();
        ResultadoEjercicioEducativo resultadoEjercicioEducativoBL = new();
        Carga cargaBL = new();

        public BienestarPoblacionEstudiantilMatriculadosController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Población Estudiantil Matriculados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<InstitucionEducativaDTO> institucionEducativaDTO = institucionEducativaBL.ObtenerInstitucionEducativas();
            List<NivelEstudioDTO> nivelEstudioDTO = nivelEstudioBL.ObtenerNivelEstudios();
            List<SeccionEstudioDTO> seccionEstudioDTO = seccionEstudioBL.ObtenerSeccionEstudios();
            List<CategoriaPagoDTO> categoriaPagoDTO = categoriaPagoBL.ObtenerCategoriaPagos();
            List<ResultadoEjercicioEducativoDTO> resultadoEjercicioEducativoDTO = resultadoEjercicioEducativoBL.ObtenerResultadoEjercicioEducativos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PoblacionEstudiantilMatriculado");

            return Json(new { 
                data1 = institucionEducativaDTO, 
                data2 = nivelEstudioDTO, 
                data3 = seccionEstudioDTO, 
                data4 = categoriaPagoDTO, 
                data5 = resultadoEjercicioEducativoDTO, 
                data6 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<PoblacionEstudiantilMatriculadosDTO> select = poblacionEstudiantilMatriculadoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIMatriculado, string FechaNacimiento, string SexoMatriculado, 
            string CodigoInstitucionEducativa, string CodigoNivelEstudio, string GradoEstudio, 
            string CodigoSeccionEstudio, string EspecificacionEstudio, string CodigoCategoriaPago, 
            string CodigoResultadoEjercicioEducativo, int CargaId, string Fecha)
        {
            PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO = new();
            poblacionEstudiantilMatriculadoDTO.DNIMatriculado = DNIMatriculado;
            poblacionEstudiantilMatriculadoDTO.FechaNacimiento = FechaNacimiento;
            poblacionEstudiantilMatriculadoDTO.SexoMatriculado = SexoMatriculado;
            poblacionEstudiantilMatriculadoDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            poblacionEstudiantilMatriculadoDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            poblacionEstudiantilMatriculadoDTO.GradoEstudio = GradoEstudio;
            poblacionEstudiantilMatriculadoDTO.CodigoSeccionEstudio = CodigoSeccionEstudio;
            poblacionEstudiantilMatriculadoDTO.EspecificacionEstudio = EspecificacionEstudio;
            poblacionEstudiantilMatriculadoDTO.CodigoCategoriaPago = CodigoCategoriaPago;
            poblacionEstudiantilMatriculadoDTO.CodigoResultadoEjercicioEducativo = CodigoResultadoEjercicioEducativo;
            poblacionEstudiantilMatriculadoDTO.CargaId = CargaId;
            poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = poblacionEstudiantilMatriculadoBL.AgregarRegistro(poblacionEstudiantilMatriculadoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(poblacionEstudiantilMatriculadoBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIMatriculado, string FechaNacimiento, string SexoMatriculado, 
            string CodigoInstitucionEducativa, string CodigoNivelEstudio, string GradoEstudio, string CodigoSeccionEstudio, 
            string EspecificacionEstudio, string CodigoCategoriaPago, string CodigoResultadoEjercicioEducativo)
        {
            PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO = new();
            poblacionEstudiantilMatriculadoDTO.PoblacionEstudiantilMatriculadoId = Id;
            poblacionEstudiantilMatriculadoDTO.DNIMatriculado = DNIMatriculado;
            poblacionEstudiantilMatriculadoDTO.FechaNacimiento = FechaNacimiento;
            poblacionEstudiantilMatriculadoDTO.SexoMatriculado = SexoMatriculado;
            poblacionEstudiantilMatriculadoDTO.CodigoInstitucionEducativa = CodigoInstitucionEducativa;
            poblacionEstudiantilMatriculadoDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            poblacionEstudiantilMatriculadoDTO.GradoEstudio = GradoEstudio;
            poblacionEstudiantilMatriculadoDTO.CodigoSeccionEstudio = CodigoSeccionEstudio;
            poblacionEstudiantilMatriculadoDTO.EspecificacionEstudio = EspecificacionEstudio;
            poblacionEstudiantilMatriculadoDTO.CodigoCategoriaPago = CodigoCategoriaPago;
            poblacionEstudiantilMatriculadoDTO.CodigoResultadoEjercicioEducativo = CodigoResultadoEjercicioEducativo;
            poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = poblacionEstudiantilMatriculadoBL.ActualizarFormato(poblacionEstudiantilMatriculadoDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO = new();
            poblacionEstudiantilMatriculadoDTO.PoblacionEstudiantilMatriculadoId = Id;
            poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (poblacionEstudiantilMatriculadoBL.EliminarFormato(poblacionEstudiantilMatriculadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PoblacionEstudiantilMatriculadosDTO poblacionEstudiantilMatriculadoDTO = new();
            poblacionEstudiantilMatriculadoDTO.CargaId = Id;
            poblacionEstudiantilMatriculadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (poblacionEstudiantilMatriculadoBL.EliminarCarga(poblacionEstudiantilMatriculadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PoblacionEstudiantilMatriculadosDTO> lista = new List<PoblacionEstudiantilMatriculadosDTO>();
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

                    lista.Add(new PoblacionEstudiantilMatriculadosDTO
                    {
                        DNIMatriculado = fila.GetCell(0).ToString(),
                        FechaNacimiento = fila.GetCell(1).ToString(),
                        SexoMatriculado = fila.GetCell(2).ToString(),
                        CodigoInstitucionEducativa = fila.GetCell(3).ToString(),
                        CodigoNivelEstudio = fila.GetCell(4).ToString(),
                        GradoEstudio = fila.GetCell(5).ToString(),
                        CodigoSeccionEstudio = fila.GetCell(6).ToString(),
                        EspecificacionEstudio = fila.GetCell(7).ToString(),
                        CodigoCategoriaPago = fila.GetCell(8).ToString(),
                        CodigoResultadoEjercicioEducativo = fila.GetCell(9).ToString()
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("DNIMatriculado", typeof(string)),
                    new DataColumn("FechaNacimiento", typeof(string)),
                    new DataColumn("SexoMatriculado", typeof(string)),
                    new DataColumn("CodigoInstitucionEducativa", typeof(string)),
                    new DataColumn("CodigoNivelEstudio", typeof(string)),
                    new DataColumn("GradoEstudio", typeof(string)),
                    new DataColumn("CodigoSeccionEstudio", typeof(string)),
                    new DataColumn("EspecificacionEstudio", typeof(string)),
                    new DataColumn("CodigoCategoriaPago", typeof(string)),
                    new DataColumn("CodigoResultadoEjercicioEducativo", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = poblacionEstudiantilMatriculadoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteBPEM(int idCarga)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\PoblacionEstudiantilMatriculado.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var poblacionEstudiantilMatriculados = poblacionEstudiantilMatriculadoBL.BienestarVisualizacionPoblacionEstudiantilMatriculado(idCarga);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PoblacionEstudiantilMatriculado", poblacionEstudiantilMatriculados);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarPoblacionEstudiantilMatriculados.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarPoblacionEstudiantilMatriculados.xlsx");
        }
    }

}

