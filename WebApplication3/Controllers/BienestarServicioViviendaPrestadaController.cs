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
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class BienestarServicioViviendaPrestadaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ServicioViviendaPrestada servicioViviendaPrestadaBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        VillaNaval villaNavalBL = new();
        BlockVillaNaval blockVillaNavalBL = new();
        TipoAsignacionCasaServicio tipoAsignacionCasaServicioBL = new();
        Carga cargaBL = new();

        public BienestarServicioViviendaPrestadaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<VillaNavalDTO> villaNavalDTO = villaNavalBL.ObtenerVillaNavals();
            List<BlockVillaNavalDTO> blockVillaNavalDTO = blockVillaNavalBL.ObtenerBlockVillaNavals();
            List<TipoAsignacionCasaServicioDTO> tipoAsignacionCasaServicioDTO = tipoAsignacionCasaServicioBL.ObtenerTipoAsignacionCasaServicios();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioViviendaPrestada");

            return Json(new { data1 = gradoPersonalMilitarDTO, data2 = villaNavalDTO, data3 = blockVillaNavalDTO, data4 = tipoAsignacionCasaServicioDTO,
            data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ServicioViviendaPrestadaDTO> select = servicioViviendaPrestadaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string CIPBeneficiario, string DNIBeneficiario, string CodigoGradoPersonalMilitar, string FechaSolicitud, string EstadoSolicitud,
            string CodigoVillaNaval, string CodigoBlockVillaNaval, int NumeroDepartamento, string FechaEntregaVivienda, string CodigoTipoAsignacionCasaServicio, 
            string PeriodoPermanencia, int CargaId, string Fecha)
        {
            ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO = new();
            servicioViviendaPrestadaDTO.CIPBeneficiario = CIPBeneficiario;
            servicioViviendaPrestadaDTO.DNIBeneficiario = DNIBeneficiario;
            servicioViviendaPrestadaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioViviendaPrestadaDTO.FechaSolicitud = FechaSolicitud;
            servicioViviendaPrestadaDTO.EstadoSolicitud = EstadoSolicitud;
            servicioViviendaPrestadaDTO.CodigoVillaNaval = CodigoVillaNaval;
            servicioViviendaPrestadaDTO.CodigoBlockVillaNaval = CodigoBlockVillaNaval;
            servicioViviendaPrestadaDTO.NumeroDepartamento = NumeroDepartamento;
            servicioViviendaPrestadaDTO.FechaEntregaVivienda = FechaEntregaVivienda;
            servicioViviendaPrestadaDTO.CodigoTipoAsignacionCasaServicio = CodigoTipoAsignacionCasaServicio;
            servicioViviendaPrestadaDTO.PeriodoPermanencia = PeriodoPermanencia;
            servicioViviendaPrestadaDTO.CargaId = CargaId;
            servicioViviendaPrestadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioViviendaPrestadaBL.AgregarRegistro(servicioViviendaPrestadaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioViviendaPrestadaBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]

        public ActionResult Actualizar(int Id, string CIPBeneficiario, string DNIBeneficiario, string CodigoGradoPersonalMilitar, string FechaSolicitud,
            string EstadoSolicitud, string CodigoVillaNaval, string CodigoBlockVillaNaval, int NumeroDepartamento, string FechaEntregaVivienda,
            string CodigoTipoAsignacionCasaServicio, string PeriodoPermanencia)
        {
            ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO = new();
            servicioViviendaPrestadaDTO.ServicioViviendaPrestadaId = Id;
            servicioViviendaPrestadaDTO.CIPBeneficiario = CIPBeneficiario;
            servicioViviendaPrestadaDTO.DNIBeneficiario = DNIBeneficiario;
            servicioViviendaPrestadaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioViviendaPrestadaDTO.FechaSolicitud = FechaSolicitud;
            servicioViviendaPrestadaDTO.EstadoSolicitud = EstadoSolicitud;
            servicioViviendaPrestadaDTO.CodigoVillaNaval = CodigoVillaNaval;
            servicioViviendaPrestadaDTO.CodigoBlockVillaNaval = CodigoBlockVillaNaval;
            servicioViviendaPrestadaDTO.NumeroDepartamento = NumeroDepartamento;
            servicioViviendaPrestadaDTO.FechaEntregaVivienda = FechaEntregaVivienda;
            servicioViviendaPrestadaDTO.CodigoTipoAsignacionCasaServicio = CodigoTipoAsignacionCasaServicio;
            servicioViviendaPrestadaDTO.PeriodoPermanencia = PeriodoPermanencia;
            servicioViviendaPrestadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioViviendaPrestadaBL.ActualizarFormato(servicioViviendaPrestadaDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO = new();
            servicioViviendaPrestadaDTO.ServicioViviendaPrestadaId = Id;
            servicioViviendaPrestadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioViviendaPrestadaBL.EliminarFormato(servicioViviendaPrestadaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioViviendaPrestadaDTO servicioViviendaPrestadaDTO = new();
            servicioViviendaPrestadaDTO.CargaId = Id;
            servicioViviendaPrestadaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioViviendaPrestadaBL.EliminarCarga(servicioViviendaPrestadaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioViviendaPrestadaDTO> lista = new List<ServicioViviendaPrestadaDTO>();
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

                    lista.Add(new ServicioViviendaPrestadaDTO
                    {
                        CIPBeneficiario = fila.GetCell(0).ToString(),
                        DNIBeneficiario = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        FechaSolicitud = UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                        EstadoSolicitud = fila.GetCell(4).ToString(),
                        CodigoVillaNaval = fila.GetCell(5).ToString(),
                        CodigoBlockVillaNaval = fila.GetCell(6).ToString(),
                        NumeroDepartamento = int.Parse(fila.GetCell(7).ToString()),
                        FechaEntregaVivienda = UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                        CodigoTipoAsignacionCasaServicio = fila.GetCell(9).ToString(),
                        PeriodoPermanencia = fila.GetCell(10).ToString()
                    });
                }
            }
            catch (Exception)
            {
                Mensaje = "0";
            }
            return Json(new { data = Mensaje, data1 = lista });
        }

        [HttpPost]
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string fecha)
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
                    new DataColumn("CIPBeneficiario", typeof(string)),
                    new DataColumn("DNIBeneficiario", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("EstadoSolicitud", typeof(string)),
                    new DataColumn("CodigoVillaNaval", typeof(string)),
                    new DataColumn("CodigoBlockVillaNaval", typeof(string)),
                    new DataColumn("NumeroDepartamento", typeof(int)),
                    new DataColumn("FechaEntregaVivienda", typeof(string)),
                    new DataColumn("CodigoTipoAsignacionCasaServicio", typeof(string)),
                    new DataColumn("PeriodoPermanencia", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    int.Parse(fila.GetCell(7).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioViviendaPrestadaBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }


        //public IActionResult ReporteBSVP(int? idCarga=null, string? fechaInicio=null, string? fechaFin=null)
        //{
        //    string mimtype = "";
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\ServicioViviendaPrestada.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var servicioViviendaPrestadas = servicioViviendaPrestadaBL.BienestarVisualizacionServicioViviendaPrestada(idCarga, fechaInicio, fechaFin);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("ServicioViviendaPrestada", servicioViviendaPrestadas);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarServicioViviendaPrestada.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarServicioViviendaPrestada.xlsx");
        }

       
    }

}

