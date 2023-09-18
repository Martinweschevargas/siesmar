using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavActividadDepartamentoHidrografiaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ActividadDepartamentoHidrografia actividadDepartamentoHidrografiaBL = new();
        TrabajoHidrografico trabajoHidrograficoBL = new();
        ZonaNautica zonaNauticaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        ProductoResultadoObtenido productoResultadoObtenidoBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        Carga cargaBL = new();

        public DihidronavActividadDepartamentoHidrografiaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Actividades del Departamento de Hidrografía", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TrabajoHidrograficoDTO> trabajoHidrograficoDTO = trabajoHidrograficoBL.ObtenerTrabajoHidrograficos(); 
            List<ZonaNauticaDTO> zonaNauticaDTO = zonaNauticaBL.ObtenerZonaNauticas();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<ProductoResultadoObtenidoDTO> productoResultadoObtenidoDTO = productoResultadoObtenidoBL.ObtenerProductoResultadoObtenidos();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ActividadDepartamentoHidrografia");

            return Json(new
            {
                data1 = trabajoHidrograficoDTO,
                data2 = zonaNauticaDTO,
                data3 = departamentoUbigeoDTO,
                data4 = provinciaUbigeoDTO,
                data5 = distritoUbigeoDTO,
                data6 = productoResultadoObtenidoDTO,
                data7 = gradoPersonalMilitarDTO,
                data8 = listaCargas
            
            });
        }

        public IActionResult CargaTabla()
        {
            List<ActividadDepartamentoHidrografiaDTO> actividadDepartamentoHidrografiaDTO = actividadDepartamentoHidrografiaBL.ObtenerLista();
            return Json(new { data = actividadDepartamentoHidrografiaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string CodigoTrabajoHidrografico, string CodigoZonaNautica, string DistritoUbigeo, string CodigoGradoPersonalMilitar, 
            string FechaTermino, string FechaInicio, string ResponsableActividad, string SituacionTrabajoEfectuado, string CodigoProductoResultadoObtenido, string TrabajoEfectuado,
            int CargaId)
        {
            ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO = new();
            actividadDepartamentoHidrografiaDTO.NumeroOrden = NumeroOrden;
            actividadDepartamentoHidrografiaDTO.TrabajoEfectuado = TrabajoEfectuado;
            actividadDepartamentoHidrografiaDTO.CodigoTrabajoHidrografico = CodigoTrabajoHidrografico;
            actividadDepartamentoHidrografiaDTO.CodigoZonaNautica = CodigoZonaNautica;
            actividadDepartamentoHidrografiaDTO.DistritoUbigeo = DistritoUbigeo;
            actividadDepartamentoHidrografiaDTO.CodigoProductoResultadoObtenido = CodigoProductoResultadoObtenido;
            actividadDepartamentoHidrografiaDTO.FechaInicio = FechaInicio;
            actividadDepartamentoHidrografiaDTO.FechaTermino = FechaTermino;
            actividadDepartamentoHidrografiaDTO.ResponsableActividad = ResponsableActividad;
            actividadDepartamentoHidrografiaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            actividadDepartamentoHidrografiaDTO.SituacionTrabajoEfectuado = SituacionTrabajoEfectuado;
            actividadDepartamentoHidrografiaDTO.CargaId = CargaId;
            actividadDepartamentoHidrografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadDepartamentoHidrografiaBL.AgregarRegistro(actividadDepartamentoHidrografiaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividadDepartamentoHidrografiaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ActividadDepartamentoHidrografiaId, int NumeroOrden, string CodigoTrabajoHidrografico, string CodigoZonaNautica, string DistritoUbigeo, string CodigoGradoPersonalMilitar,
            string FechaTermino, string FechaInicio, string ResponsableActividad, string SituacionTrabajoEfectuado, string CodigoProductoResultadoObtenido, string TrabajoEfectuado)
        {
            ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO = new();
            actividadDepartamentoHidrografiaDTO.ActividadDepartamentoHidrografiaId = ActividadDepartamentoHidrografiaId;
            actividadDepartamentoHidrografiaDTO.NumeroOrden = NumeroOrden;
            actividadDepartamentoHidrografiaDTO.TrabajoEfectuado = TrabajoEfectuado;
            actividadDepartamentoHidrografiaDTO.CodigoTrabajoHidrografico = CodigoTrabajoHidrografico;
            actividadDepartamentoHidrografiaDTO.CodigoZonaNautica = CodigoZonaNautica;
            actividadDepartamentoHidrografiaDTO.DistritoUbigeo = DistritoUbigeo;
            actividadDepartamentoHidrografiaDTO.CodigoProductoResultadoObtenido = CodigoProductoResultadoObtenido;
            actividadDepartamentoHidrografiaDTO.FechaInicio = FechaInicio;
            actividadDepartamentoHidrografiaDTO.FechaTermino = FechaTermino;
            actividadDepartamentoHidrografiaDTO.ResponsableActividad = ResponsableActividad;
            actividadDepartamentoHidrografiaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            actividadDepartamentoHidrografiaDTO.SituacionTrabajoEfectuado = SituacionTrabajoEfectuado;
            actividadDepartamentoHidrografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadDepartamentoHidrografiaBL.ActualizarFormato(actividadDepartamentoHidrografiaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO = new();
            actividadDepartamentoHidrografiaDTO.ActividadDepartamentoHidrografiaId = Id;
            actividadDepartamentoHidrografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actividadDepartamentoHidrografiaBL.EliminarFormato(actividadDepartamentoHidrografiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ActividadDepartamentoHidrografiaDTO> lista = new List<ActividadDepartamentoHidrografiaDTO>();
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

                    lista.Add(new ActividadDepartamentoHidrografiaDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        TrabajoEfectuado = fila.GetCell(1).ToString(),
                        CodigoTrabajoHidrografico = fila.GetCell(2).ToString(),
                        CodigoZonaNautica = fila.GetCell(3).ToString(),
                        DistritoUbigeo = fila.GetCell(4).ToString(),
                        CodigoProductoResultadoObtenido = fila.GetCell(5).ToString(),
                        FechaInicio = fila.GetCell(6).ToString(),
                        FechaTermino = fila.GetCell(7).ToString(),
                        ResponsableActividad = fila.GetCell(8).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(9).ToString(),
                        SituacionTrabajoEfectuado = fila.GetCell(10).ToString()
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("TrabajoEfectuado", typeof(string)),
                    new DataColumn("CodigoTrabajoHidrografico", typeof(string)),
                    new DataColumn("CodigoZonaNautica", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoProductoResultadoObtenido", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("ResponsableActividad", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SituacionTrabajoEfectuado", typeof(string)),

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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = actividadDepartamentoHidrografiaBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavActividadDepartamentoHidrografia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavActividadDepartamentoHidrografia.xlsx");
        }
    }

}