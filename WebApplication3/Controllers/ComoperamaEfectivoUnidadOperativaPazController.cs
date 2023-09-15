using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
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

    public class ComoperamaEfectivoUnidadOperativaPazController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EfectivoUnidadOperativaPaz efectivoUnidadOperativaPazBL = new();
        ComandanciaDependencia comandanciaDependenciaBL = new();
        Dependencia dependenciaBL = new();
        GradoPersonal gradoPersonalBL = new();
        Carga cargaBL = new();
        public ComoperamaEfectivoUnidadOperativaPazController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Efectivos por Unidades Operativas en Tiempo de Paz", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoPersonalDTO> gradoPersonalDTO = gradoPersonalBL.ObtenerGradoPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EfectivoUnidadOperativaPaz");

            return Json(new {
                data1 = comandanciaDependenciaDTO,
                data2 = dependenciaDTO,
                data3 = gradoPersonalDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EfectivoUnidadOperativaPazDTO> select = efectivoUnidadOperativaPazBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoComandanciaDependencia, string CodigoDependencia, string CodigoGradoPersonal, int NumeroEfectivosRequeridos,
            int NumeroEfectivosAsignados, int CargaId)
        {
            EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO = new();
            efectivoUnidadOperativaPazDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            efectivoUnidadOperativaPazDTO.CodigoDependencia = CodigoDependencia;
            efectivoUnidadOperativaPazDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            efectivoUnidadOperativaPazDTO.NumeroEfectivosRequeridos = NumeroEfectivosRequeridos;
            efectivoUnidadOperativaPazDTO.NumeroEfectivosAsignados = NumeroEfectivosAsignados;
            efectivoUnidadOperativaPazDTO.CargaId = CargaId;

            efectivoUnidadOperativaPazDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoUnidadOperativaPazBL.AgregarRegistro(efectivoUnidadOperativaPazDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(efectivoUnidadOperativaPazBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoComandanciaDependencia, string CodigoDependencia, string CodigoGradoPersonal, int NumeroEfectivosRequeridos,
            int NumeroEfectivosAsignados)
        {
            EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO = new();
            efectivoUnidadOperativaPazDTO.EfectivoUnidadOperativaPazId = Id;
            efectivoUnidadOperativaPazDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            efectivoUnidadOperativaPazDTO.CodigoDependencia = CodigoDependencia;
            efectivoUnidadOperativaPazDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            efectivoUnidadOperativaPazDTO.NumeroEfectivosRequeridos = NumeroEfectivosRequeridos;
            efectivoUnidadOperativaPazDTO.NumeroEfectivosAsignados = NumeroEfectivosAsignados;
            
            efectivoUnidadOperativaPazDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoUnidadOperativaPazBL.ActualizarFormato(efectivoUnidadOperativaPazDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO = new();
            efectivoUnidadOperativaPazDTO.EfectivoUnidadOperativaPazId = Id;
            efectivoUnidadOperativaPazDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (efectivoUnidadOperativaPazBL.EliminarFormato(efectivoUnidadOperativaPazDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EfectivoUnidadOperativaPazDTO> lista = new List<EfectivoUnidadOperativaPazDTO>();
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

                    lista.Add(new EfectivoUnidadOperativaPazDTO
                    {
                        CodigoComandanciaDependencia = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        CodigoGradoPersonal = fila.GetCell(2).ToString(),
                        NumeroEfectivosRequeridos = int.Parse(fila.GetCell(3).ToString()),
                        NumeroEfectivosAsignados = int.Parse(fila.GetCell(4).ToString())
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("CodigoComandanciaDependencia", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoGradoPersonal", typeof(string)),
                    new DataColumn("NumeroEfectivosRequeridos", typeof(int)),
                    new DataColumn("NumeroEfectivosAsignados", typeof(int)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = efectivoUnidadOperativaPazBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }



        public IActionResult ReporteEEU()
        {
         
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comoperama\\EfectivoNivelEntrenamientoUnidad.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var efectivoNivelEntrenamientoUnidad = efectivoUnidadOperativaPazBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EfectivoNivelEntrenamientoUnidad", efectivoNivelEntrenamientoUnidad);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperamaEfectivoUnidadOperativaPaz.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperamaEfectivoUnidadOperativaPaz.xlsx");
        }

    }

}

