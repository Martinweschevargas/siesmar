using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperama;
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

    public class ComoperamaEfectivoNivelEntrenamientoUnidadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EfectivoNivelEntrenamientoUnidad efectivoNivelEntrenamientoUnidadBL = new();

        ComandanciaDependencia comandanciaDependenciaBL = new();
        Dependencia dependenciaBL = new();
        GradoPersonal gradoPersonalBL = new();
        Carga cargaBL = new();
        public ComoperamaEfectivoNivelEntrenamientoUnidadController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Efectivos de la Marina Según Nivel de Entrenamiento por Unidades", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoPersonalDTO> gradoPersonalDTO = gradoPersonalBL.ObtenerGradoPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EfectivoNivelEntrenamientoUnidad");

            return Json(new { data1 = comandanciaDependenciaDTO, data2 = dependenciaDTO, data3 = gradoPersonalDTO, data4 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<EfectivoNivelEntrenamientoUnidadDTO> select = efectivoNivelEntrenamientoUnidadBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoComandanciaDependencia, string CodigoDependencia, string CodigoGradoPersonal, decimal NivelElemental,
            decimal NivelBasico, decimal NivelIntermedio, decimal NivelAvanzado, decimal NivelConjunto,int CargaId)
        {
            EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO = new();
            efectivoNivelEntrenamientoUnidadDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            efectivoNivelEntrenamientoUnidadDTO.CodigoDependencia = CodigoDependencia;
            efectivoNivelEntrenamientoUnidadDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            efectivoNivelEntrenamientoUnidadDTO.NivelElemental = NivelElemental;
            efectivoNivelEntrenamientoUnidadDTO.NivelBasico = NivelBasico;
            efectivoNivelEntrenamientoUnidadDTO.NivelIntermedio = NivelIntermedio;
            efectivoNivelEntrenamientoUnidadDTO.NivelAvanzado = NivelAvanzado;
            efectivoNivelEntrenamientoUnidadDTO.NivelConjunto = NivelConjunto;
            efectivoNivelEntrenamientoUnidadDTO.CargaId = CargaId;
            efectivoNivelEntrenamientoUnidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoNivelEntrenamientoUnidadBL.AgregarRegistro(efectivoNivelEntrenamientoUnidadDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(efectivoNivelEntrenamientoUnidadBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoComandanciaDependencia, string CodigoDependencia, string CodigoGradoPersonal, decimal NivelElemental,
            decimal NivelBasico, decimal NivelIntermedio, decimal NivelAvanzado, decimal NivelConjunto)
        {
            EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO = new();
            efectivoNivelEntrenamientoUnidadDTO.EfectivoNivelEntrenamientoUnidadId = Id;
            efectivoNivelEntrenamientoUnidadDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            efectivoNivelEntrenamientoUnidadDTO.CodigoDependencia = CodigoDependencia;
            efectivoNivelEntrenamientoUnidadDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            efectivoNivelEntrenamientoUnidadDTO.NivelElemental = NivelElemental;
            efectivoNivelEntrenamientoUnidadDTO.NivelBasico = NivelBasico;
            efectivoNivelEntrenamientoUnidadDTO.NivelIntermedio = NivelIntermedio;
            efectivoNivelEntrenamientoUnidadDTO.NivelAvanzado = NivelAvanzado;
            efectivoNivelEntrenamientoUnidadDTO.NivelConjunto = NivelConjunto;
            efectivoNivelEntrenamientoUnidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoNivelEntrenamientoUnidadBL.ActualizarFormato(efectivoNivelEntrenamientoUnidadDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO = new();
            efectivoNivelEntrenamientoUnidadDTO.EfectivoNivelEntrenamientoUnidadId = Id;
            efectivoNivelEntrenamientoUnidadDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (efectivoNivelEntrenamientoUnidadBL.EliminarFormato(efectivoNivelEntrenamientoUnidadDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EfectivoNivelEntrenamientoUnidadDTO> lista = new List<EfectivoNivelEntrenamientoUnidadDTO>();
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

                    lista.Add(new EfectivoNivelEntrenamientoUnidadDTO
                    {
                        CodigoComandanciaDependencia = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        CodigoGradoPersonal = fila.GetCell(2).ToString(),
                        NivelElemental = decimal.Parse(fila.GetCell(3).ToString()),
                        NivelBasico = decimal.Parse(fila.GetCell(4).ToString()),
                        NivelIntermedio = decimal.Parse(fila.GetCell(5).ToString()),
                        NivelAvanzado = decimal.Parse(fila.GetCell(6).ToString()),
                        NivelConjunto = decimal.Parse(fila.GetCell(7).ToString()),

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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                         new DataColumn("CodigoDependencia", typeof(string)),
                         new DataColumn("CodigoGradoPersonal", typeof(string)),
                         new DataColumn("NivelElemental", typeof(decimal)),
                         new DataColumn("NivelBasico", typeof(decimal)),
                         new DataColumn("NivelIntermedio", typeof(decimal)),
                         new DataColumn("NivelAvanzado", typeof(decimal)),
                         new DataColumn("NivelConjunto", typeof(decimal)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = efectivoNivelEntrenamientoUnidadBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEEU()
        {
         
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comoperama\\EfectivoNivelEntrenamientoUnidad.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var efectivoNivelEntrenamientoUnidad = efectivoNivelEntrenamientoUnidadBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EfectivoNivelEntrenamientoUnidad", efectivoNivelEntrenamientoUnidad);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperamaEfectivoNivelEntrenamientoUnidad.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperamaEfectivoNivelEntrenamientoUnidad.xlsx");
        }
    }

}

