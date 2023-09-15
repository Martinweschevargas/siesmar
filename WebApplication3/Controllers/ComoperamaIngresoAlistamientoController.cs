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

    public class ComoperamaIngresoAlistamientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        IngresoAlistamiento ingresoAlistamientoBL = new();

        ComandanciaDependencia comandanciaDependenciaBL = new();
        Dependencia dependenciaBL = new();

        Carga cargaBL = new();
        public ComoperamaIngresoAlistamientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Formato de Ingreso para Alistamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ComandanciaDependenciaDTO> comandanciaDependenciaDTO = comandanciaDependenciaBL.ObtenerComandanciaDependencias();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EfectivoNivelEntrenamientoUnidad");

            return Json(new { data1 = comandanciaDependenciaDTO, data2 = dependenciaDTO, data3 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<IngresoAlistamientoDTO> select = ingresoAlistamientoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( string CodigoComandanciaDependencia, string CodigoDependencia, decimal Aliper, decimal Alient, decimal Alimat, decimal Alilog, 
            string FechaInicio, string FechaTermino,int CargaId)
        {
            IngresoAlistamientoDTO ingresoAlistamientoDTO = new();
            ingresoAlistamientoDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            ingresoAlistamientoDTO.CodigoDependencia = CodigoDependencia;
            ingresoAlistamientoDTO.Aliper = Aliper;
            ingresoAlistamientoDTO.Alient = Alient;
            ingresoAlistamientoDTO.Alimat = Alimat;
            ingresoAlistamientoDTO.Alilog = Alilog;
            ingresoAlistamientoDTO.FechaInicio = FechaInicio;
            ingresoAlistamientoDTO.FechaTermino = FechaTermino;
            ingresoAlistamientoDTO.CargaId = CargaId;

            ingresoAlistamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoAlistamientoBL.AgregarRegistro(ingresoAlistamientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ingresoAlistamientoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoComandanciaDependencia, string CodigoDependencia, decimal Aliper, decimal Alient,
            decimal Alimat, decimal Alilog, string FechaInicio, string FechaTermino)
        {
            IngresoAlistamientoDTO ingresoAlistamientoDTO = new();
            ingresoAlistamientoDTO.IngresoAlistamientoId = Id;
            ingresoAlistamientoDTO.CodigoComandanciaDependencia = CodigoComandanciaDependencia;
            ingresoAlistamientoDTO.CodigoDependencia = CodigoDependencia;
            ingresoAlistamientoDTO.Aliper = Aliper;
            ingresoAlistamientoDTO.Alient = Alient;
            ingresoAlistamientoDTO.Alimat = Alimat;
            ingresoAlistamientoDTO.Alilog = Alilog;
            ingresoAlistamientoDTO.FechaInicio = FechaInicio;
            ingresoAlistamientoDTO.FechaTermino = FechaTermino;
            ingresoAlistamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ingresoAlistamientoBL.ActualizarFormato(ingresoAlistamientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            IngresoAlistamientoDTO ingresoAlistamientoDTO = new();
            ingresoAlistamientoDTO.IngresoAlistamientoId = Id;
            ingresoAlistamientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ingresoAlistamientoBL.EliminarFormato(ingresoAlistamientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<IngresoAlistamientoDTO> lista = new List<IngresoAlistamientoDTO>();
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

                    lista.Add(new IngresoAlistamientoDTO
                    {
                        CodigoComandanciaDependencia = fila.GetCell(0).ToString(),
                        CodigoDependencia = fila.GetCell(1).ToString(),
                        Aliper = decimal.Parse(fila.GetCell(2).ToString()),
                        Alient = decimal.Parse(fila.GetCell(3).ToString()),
                        Alimat = decimal.Parse(fila.GetCell(4).ToString()),
                        Alilog = decimal.Parse(fila.GetCell(5).ToString()),
                        FechaInicio = fila.GetCell(6).ToString(),
                        FechaTermino = fila.GetCell(7).ToString()
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
                    new DataColumn("Aliper", typeof(decimal)),
                    new DataColumn("Alient", typeof(decimal)),
                    new DataColumn("Alimat", typeof(decimal)),
                    new DataColumn("Alilog", typeof(decimal)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    decimal.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = ingresoAlistamientoBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }


        public IActionResult ReporteEEU()
        {
         
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comoperama\\EfectivoNivelEntrenamientoUnidad.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var efectivoNivelEntrenamientoUnidad = ingresoAlistamientoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EfectivoNivelEntrenamientoUnidad", efectivoNivelEntrenamientoUnidad);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperamaIngresoAlistamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperamaIngresoAlistamiento.xlsx");
        }

    }

}

