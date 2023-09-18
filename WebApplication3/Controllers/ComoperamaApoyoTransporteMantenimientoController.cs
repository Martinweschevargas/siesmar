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

    public class ComoperamaApoyoTransporteMantenimientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ApoyoTransporteMantenimiento apoyoTransporteMantenimientoBL = new();

        ZonaNaval zonaNavalBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        TipoActividadDenominacion tipoActividadDenominacionBL = new();

        TipoAccionCivica tipoAccionCivicaBL = new();

        Carga cargaBL = new();
        public ComoperamaApoyoTransporteMantenimientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<TipoActividadDenominacionDTO> tipoActividadDenominacionDTO = tipoActividadDenominacionBL.ObtenerTipoActividadDenominacions();
            List<TipoAccionCivicaDTO> tipoAccionCivicaDTO = tipoAccionCivicaBL.ObtenerTipoAccionCivicas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ApoyoTransporteMantenimiento");

            return Json(new { data1 = zonaNavalDTO, data2 = departamentoUbigeoDTO, data3 = provinciaUbigeoDTO, data4 = distritoUbigeoDTO, 
            data5 = tipoActividadDenominacionDTO, data6= tipoAccionCivicaDTO,
                data7 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ApoyoTransporteMantenimientoDTO> select = apoyoTransporteMantenimientoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoZonaNaval,   string DistritoUbigeo, string CodigoTipoActividadDenominacion, 
            string FechaInicio, string FechaTermino, int NumeroBeneficiados, decimal Valor , string CodigoTipoAccionCivica, int CargaId)
        {
            ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO = new();
            apoyoTransporteMantenimientoDTO.CodigoZonaNaval = CodigoZonaNaval;
            apoyoTransporteMantenimientoDTO.DistritoUbigeo = DistritoUbigeo;
            apoyoTransporteMantenimientoDTO.CodigoTipoActividadDenominacion = CodigoTipoActividadDenominacion;
            apoyoTransporteMantenimientoDTO.FechaInicio = FechaInicio;
            apoyoTransporteMantenimientoDTO.FechaTermino = FechaTermino;
            apoyoTransporteMantenimientoDTO.NumeroBeneficiados = NumeroBeneficiados;
            apoyoTransporteMantenimientoDTO.Valor = Valor;
            apoyoTransporteMantenimientoDTO.CodigoTipoAccionCivica = CodigoTipoAccionCivica;
            apoyoTransporteMantenimientoDTO.CargaId = CargaId;
            apoyoTransporteMantenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = apoyoTransporteMantenimientoBL.AgregarRegistro(apoyoTransporteMantenimientoDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(apoyoTransporteMantenimientoBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int ApoyoTransporteMantenimientoId, string CodigoZonaNaval,  string DistritoUbigeo, 
            string CodigoTipoActividadDenominacion, string FechaInicio, string FechaTermino, int NumeroBeneficiados, decimal Valor, string CodigoTipoAccionCivica)
        {
            ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO = new();
            apoyoTransporteMantenimientoDTO.ApoyoTransporteMantenimientoId = ApoyoTransporteMantenimientoId;
            apoyoTransporteMantenimientoDTO.CodigoZonaNaval = CodigoZonaNaval;
            apoyoTransporteMantenimientoDTO.DistritoUbigeo = DistritoUbigeo;
            apoyoTransporteMantenimientoDTO.CodigoTipoActividadDenominacion = CodigoTipoActividadDenominacion;
            apoyoTransporteMantenimientoDTO.FechaInicio = FechaInicio;
            apoyoTransporteMantenimientoDTO.FechaTermino = FechaTermino;
            apoyoTransporteMantenimientoDTO.NumeroBeneficiados = NumeroBeneficiados;
            apoyoTransporteMantenimientoDTO.Valor = Valor;
            apoyoTransporteMantenimientoDTO.CodigoTipoAccionCivica = CodigoTipoAccionCivica;
    
            
            apoyoTransporteMantenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = apoyoTransporteMantenimientoBL.ActualizarFormato(apoyoTransporteMantenimientoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ApoyoTransporteMantenimientoDTO apoyoTransporteMantenimientoDTO = new();
            apoyoTransporteMantenimientoDTO.ApoyoTransporteMantenimientoId = Id;
            apoyoTransporteMantenimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (apoyoTransporteMantenimientoBL.EliminarFormato(apoyoTransporteMantenimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ApoyoTransporteMantenimientoDTO> lista = new List<ApoyoTransporteMantenimientoDTO>();
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

                    lista.Add(new ApoyoTransporteMantenimientoDTO
                    {
                        CodigoZonaNaval = fila.GetCell(0).ToString(),
                        DistritoUbigeo = fila.GetCell(1).ToString(),
                        CodigoTipoActividadDenominacion = fila.GetCell(2).ToString(),
                        FechaInicio = fila.GetCell(3).ToString(),
                        FechaTermino = fila.GetCell(4).ToString(),
                        NumeroBeneficiados = int.Parse(fila.GetCell(5).ToString()),
                        Valor = decimal.Parse(fila.GetCell(6).ToString()),
                        CodigoTipoAccionCivica = fila.GetCell(7).ToString()
 
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
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoTipoActividadDenominacion", typeof(string)),
                    new DataColumn("FechaInicio", typeof(string)),
                    new DataColumn("FechaTermino", typeof(string)),
                    new DataColumn("NumeroBeneficiados", typeof(int)),
                    new DataColumn("Valor", typeof(decimal)),
                    new DataColumn("CodigoTipoAccionCivica", typeof(string)),
 
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = apoyoTransporteMantenimientoBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }




        public IActionResult ReporteEEU()
        {
         
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Comoperama\\EfectivoNivelEntrenamientoUnidad.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var efectivoNivelEntrenamientoUnidad = apoyoTransporteMantenimientoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EfectivoNivelEntrenamientoUnidad", efectivoNivelEntrenamientoUnidad);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperamaApoyoTransporteMantenimiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperamaApoyoTransporteMantenimiento.xlsx");
        }

    }

}

