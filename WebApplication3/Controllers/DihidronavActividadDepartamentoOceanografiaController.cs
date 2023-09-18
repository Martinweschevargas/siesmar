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
    public class DihidronavActividadDepartamentoOceanografiaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ActividadDepartamentoOceanografia actividadDepartamentoOceanografiaBL = new();
        TrabajoOceanografico trabajoOceanograficoBL = new();
        ZonaNautica zonaNauticaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public DihidronavActividadDepartamentoOceanografiaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Actividades del Departamento de Oceanografía", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TrabajoOceanograficoDTO> trabajoOceanograficoDTO = trabajoOceanograficoBL.ObtenerTrabajoOceanograficos(); 
            List<ZonaNauticaDTO> zonaNauticaDTO = zonaNauticaBL.ObtenerZonaNauticas();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ActividadDepartamentoOceanografia");


            return Json(new
            {
                data1 = trabajoOceanograficoDTO,
                data2 = zonaNauticaDTO,
                data3 = departamentoUbigeoDTO,
                data4 = provinciaUbigeoDTO,
                data5 = distritoUbigeoDTO,
                data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ActividadDepartamentoOceanografiaDTO> actividadDepartamentoOceanografiaDTO = actividadDepartamentoOceanografiaBL.ObtenerLista();
            return Json(new { data = actividadDepartamentoOceanografiaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string CodigoTrabajoOceanografico, string CodigoZonaNautica, 
            string FechaTermino, string FechaInicio, string DescripcionTrabajoEfectuado, string DistritoUbigeo, 
            string SituacionTrabajoEfectuado, int CargaId)
        {
            ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO = new();
            actividadDepartamentoOceanografiaDTO.NumeroOrden = NumeroOrden;
            actividadDepartamentoOceanografiaDTO.CodigoTrabajoOceanografico = CodigoTrabajoOceanografico;
            actividadDepartamentoOceanografiaDTO.CodigoZonaNautica = CodigoZonaNautica;

            actividadDepartamentoOceanografiaDTO.DescripcionTrabajoEfectuado = DescripcionTrabajoEfectuado;
            actividadDepartamentoOceanografiaDTO.DistritoUbigeo = DistritoUbigeo;
            actividadDepartamentoOceanografiaDTO.FechaInicio = FechaInicio;
            actividadDepartamentoOceanografiaDTO.FechaTermino = FechaTermino;
            actividadDepartamentoOceanografiaDTO.SituacionTrabajoEfectuado = SituacionTrabajoEfectuado;
            actividadDepartamentoOceanografiaDTO.CargaId = CargaId;
            actividadDepartamentoOceanografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadDepartamentoOceanografiaBL.AgregarRegistro(actividadDepartamentoOceanografiaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(actividadDepartamentoOceanografiaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ActividadDepartamentoOceanografiaId, int NumeroOrden, string CodigoTrabajoOceanografico, string CodigoZonaNautica,
            string FechaTermino, string FechaInicio, string DescripcionTrabajoEfectuado, string DistritoUbigeo,
            string SituacionTrabajoEfectuado)
        {
            ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO = new();
            actividadDepartamentoOceanografiaDTO.ActividadDepartamentoOceanografiaId = ActividadDepartamentoOceanografiaId;
            actividadDepartamentoOceanografiaDTO.NumeroOrden = NumeroOrden;
            actividadDepartamentoOceanografiaDTO.CodigoTrabajoOceanografico = CodigoTrabajoOceanografico;
            actividadDepartamentoOceanografiaDTO.DescripcionTrabajoEfectuado = DescripcionTrabajoEfectuado;
            actividadDepartamentoOceanografiaDTO.CodigoZonaNautica = CodigoZonaNautica;
            actividadDepartamentoOceanografiaDTO.DistritoUbigeo = DistritoUbigeo;
            actividadDepartamentoOceanografiaDTO.FechaInicio = FechaInicio;
            actividadDepartamentoOceanografiaDTO.FechaTermino = FechaTermino;
            actividadDepartamentoOceanografiaDTO.SituacionTrabajoEfectuado = SituacionTrabajoEfectuado;
            actividadDepartamentoOceanografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = actividadDepartamentoOceanografiaBL.ActualizarFormato(actividadDepartamentoOceanografiaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO = new();
            actividadDepartamentoOceanografiaDTO.ActividadDepartamentoOceanografiaId = Id;
            actividadDepartamentoOceanografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (actividadDepartamentoOceanografiaBL.EliminarFormato(actividadDepartamentoOceanografiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ActividadDepartamentoOceanografiaDTO> lista = new List<ActividadDepartamentoOceanografiaDTO>();
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

                    lista.Add(new ActividadDepartamentoOceanografiaDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        CodigoTrabajoOceanografico = fila.GetCell(1).ToString(),
                        DescripcionTrabajoEfectuado = fila.GetCell(2).ToString(),
                        CodigoZonaNautica = fila.GetCell(3).ToString(),
                        DistritoUbigeo = fila.GetCell(4).ToString(),
                        FechaInicio = fila.GetCell(5).ToString(),
                        FechaTermino = fila.GetCell(6).ToString(),
                        SituacionTrabajoEfectuado = fila.GetCell(7).ToString()
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
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("CodigoTrabajoOceanografico", typeof(string)),
                    new DataColumn("DescripcionTrabajoEfectuado", typeof(string)),
                    new DataColumn("CodigoZonaNautica", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
 
                    User.obtenerUsuario());
            }
            // string IND_OPERACION = actividadDepartamentoOceanografiaBL.InsercionMasiva(dt);
            string IND_OPERACION = "";
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavActividadDepartamentoOceanografia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavActividadDepartamentoOceanografia.xlsx");
        }
    }

}