using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Difoserece;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Difoserece;
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
    public class DifosereceAportFondoRetiroCesacionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        AportacionesFondoRetiroCesacion aportFondoRetiroCesacionBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        Dependencia dependenciaBL = new();
        GradoRemunerativo gradoRemunerativoBL = new();
        SituacionPersonalNaval situacionPersonalNavalBL = new();
        CausalLiquidacion causaLiquidacionBL = new();
        Carga cargaBL = new();
        public DifosereceAportFondoRetiroCesacionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Aportaciones al Fondo de Seguro Retiro y CesaciÓn del Personal Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoRemunerativoDTO> gradoRemunerativoDTO = gradoRemunerativoBL.ObtenerGradoRemunerativos();
            List<SituacionPersonalNavalDTO> situacionPersonalNavalDTO = situacionPersonalNavalBL.ObtenerSituacionPersonalNavals();
            List<CausalLiquidacionDTO> causalLiquidacionDTO = causaLiquidacionBL.ObtenerCausalLiquidacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AportacionFondoRetiroCesacion");

            return Json(new { 
                data1 = tipoPersonalMilitarDTO, 
                data2 = dependenciaDTO, 
                data3 = gradoRemunerativoDTO,
                data4 = situacionPersonalNavalDTO, 
                data5 = causalLiquidacionDTO, 
                data6= listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AportFondoRetiroCesacionDTO> select = aportFondoRetiroCesacionBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoTipoPersonalMilitar, string DNIPersonalRetiro, 
            string SexoPersonalRetiro, string CodigoDependencia, string CodigoGradoRemunerativo, 
            string CodigoSituacionPersonalNaval, string FechaNacimientoPersonalR, string FechaIngresoPersonalR,
            string FechaNombramientoPersonalR, string FechaPaseRetiroPersonalR, string FechaReincorporacionPersonalR, 
            string FechaPrimerAportePersonalR, string FechaUltimoAportePersonalR, int NumeroCuotasAportadasPersonalR, 
            decimal AporteMensualUltimoPersonalR, string TipoLiquidacionPersonalR, int DevolucionAportePersonalR, 
            string FechaLiquidacionPersonalR, string CodigoCausalLiquidacion, int CargaId, string Fecha)
        {
            AportFondoRetiroCesacionDTO aportFondoRetiroCesacionDTO = new();
            aportFondoRetiroCesacionDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            aportFondoRetiroCesacionDTO.DNIPersonalRetiro = DNIPersonalRetiro;
            aportFondoRetiroCesacionDTO.SexoPersonalRetiro = SexoPersonalRetiro;
            aportFondoRetiroCesacionDTO.CodigoDependencia = CodigoDependencia;
            aportFondoRetiroCesacionDTO.CodigoGradoRemunerativo = CodigoGradoRemunerativo;
            aportFondoRetiroCesacionDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            aportFondoRetiroCesacionDTO.FechaNacimientoPersonalR = FechaNacimientoPersonalR;
            aportFondoRetiroCesacionDTO.FechaIngresoPersonalR = FechaIngresoPersonalR;
            aportFondoRetiroCesacionDTO.FechaNombramientoPersonalR = FechaNombramientoPersonalR;
            aportFondoRetiroCesacionDTO.FechaPaseRetiroPersonalR = FechaPaseRetiroPersonalR;
            aportFondoRetiroCesacionDTO.FechaReincorporacionPersonalR = FechaReincorporacionPersonalR;
            aportFondoRetiroCesacionDTO.FechaPrimerAportePersonalR = FechaPrimerAportePersonalR;
            aportFondoRetiroCesacionDTO.FechaUltimoAportePersonalR = FechaUltimoAportePersonalR;
            aportFondoRetiroCesacionDTO.NumeroCuotasAportadasPersonalR = NumeroCuotasAportadasPersonalR;
            aportFondoRetiroCesacionDTO.AporteMensualUltimoPersonalR = AporteMensualUltimoPersonalR;
            aportFondoRetiroCesacionDTO.TipoLiquidacionPersonalR = TipoLiquidacionPersonalR;
            aportFondoRetiroCesacionDTO.DevolucionAportePersonalR = DevolucionAportePersonalR;
            aportFondoRetiroCesacionDTO.FechaLiquidacionPersonalR = FechaLiquidacionPersonalR;
            aportFondoRetiroCesacionDTO.CodigoCausalLiquidacion = CodigoCausalLiquidacion;
            aportFondoRetiroCesacionDTO.CargaId = CargaId;
            aportFondoRetiroCesacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = aportFondoRetiroCesacionBL.AgregarRegistro(aportFondoRetiroCesacionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(aportFondoRetiroCesacionBL.EditarFormato(Id));
        }


        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoTipoPersonalMilitar, string DNIPersonalRetiro,
            string SexoPersonalRetiro, string CodigoDependencia, string CodigoGradoRemunerativo,
            string CodigoSituacionPersonalNaval, string FechaNacimientoPersonalR, string FechaIngresoPersonalR,
            string FechaNombramientoPersonalR, string FechaPaseRetiroPersonalR, string FechaReincorporacionPersonalR,
            string FechaPrimerAportePersonalR, string FechaUltimoAportePersonalR, int NumeroCuotasAportadasPersonalR,
            decimal AporteMensualUltimoPersonalR, string TipoLiquidacionPersonalR, int DevolucionAportePersonalR,
            string FechaLiquidacionPersonalR, string CodigoCausalLiquidacion)
        {

            AportFondoRetiroCesacionDTO aportFondoRetiroCesacionDTO = new();
            aportFondoRetiroCesacionDTO.AportacionFondoRetiroCesacionId = Id;
            aportFondoRetiroCesacionDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            aportFondoRetiroCesacionDTO.DNIPersonalRetiro = DNIPersonalRetiro;
            aportFondoRetiroCesacionDTO.SexoPersonalRetiro = SexoPersonalRetiro;
            aportFondoRetiroCesacionDTO.CodigoDependencia = CodigoDependencia;
            aportFondoRetiroCesacionDTO.CodigoGradoRemunerativo = CodigoGradoRemunerativo;
            aportFondoRetiroCesacionDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            aportFondoRetiroCesacionDTO.FechaNacimientoPersonalR = FechaNacimientoPersonalR;
            aportFondoRetiroCesacionDTO.FechaIngresoPersonalR = FechaIngresoPersonalR;
            aportFondoRetiroCesacionDTO.FechaNombramientoPersonalR = FechaNombramientoPersonalR;
            aportFondoRetiroCesacionDTO.FechaPaseRetiroPersonalR = FechaPaseRetiroPersonalR;
            aportFondoRetiroCesacionDTO.FechaReincorporacionPersonalR = FechaReincorporacionPersonalR;
            aportFondoRetiroCesacionDTO.FechaPrimerAportePersonalR = FechaPrimerAportePersonalR;
            aportFondoRetiroCesacionDTO.FechaUltimoAportePersonalR = FechaUltimoAportePersonalR;
            aportFondoRetiroCesacionDTO.NumeroCuotasAportadasPersonalR = NumeroCuotasAportadasPersonalR;
            aportFondoRetiroCesacionDTO.AporteMensualUltimoPersonalR = AporteMensualUltimoPersonalR;
            aportFondoRetiroCesacionDTO.TipoLiquidacionPersonalR = TipoLiquidacionPersonalR;
            aportFondoRetiroCesacionDTO.DevolucionAportePersonalR = DevolucionAportePersonalR;
            aportFondoRetiroCesacionDTO.FechaLiquidacionPersonalR = FechaLiquidacionPersonalR;
            aportFondoRetiroCesacionDTO.CodigoCausalLiquidacion = CodigoCausalLiquidacion;
            aportFondoRetiroCesacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = aportFondoRetiroCesacionBL.ActualizarFormato(aportFondoRetiroCesacionDTO);

            return Content(IND_OPERACION);
        }


        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AportFondoRetiroCesacionDTO aportFondoRetiroCesacionDTO = new();
            aportFondoRetiroCesacionDTO.AportacionFondoRetiroCesacionId = Id;
            aportFondoRetiroCesacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (aportFondoRetiroCesacionBL.EliminarFormato(aportFondoRetiroCesacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AportFondoRetiroCesacionDTO aportFondoRetiroCesacionDTO = new();
            aportFondoRetiroCesacionDTO.CargaId = Id;
            aportFondoRetiroCesacionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (aportFondoRetiroCesacionBL.EliminarCarga(aportFondoRetiroCesacionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AportFondoRetiroCesacionDTO> lista = new List<AportFondoRetiroCesacionDTO>();
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

                    lista.Add(new AportFondoRetiroCesacionDTO
                    {
                        CodigoTipoPersonalMilitar = fila.GetCell(0).ToString(),
                        DNIPersonalRetiro = fila.GetCell(1).ToString(),
                        SexoPersonalRetiro = fila.GetCell(2).ToString(),
                        CodigoDependencia = fila.GetCell(3).ToString(),
                        CodigoGradoRemunerativo = fila.GetCell(4).ToString(),
                        CodigoSituacionPersonalNaval = fila.GetCell(5).ToString(),
                        FechaNacimientoPersonalR = fila.GetCell(6).ToString(),
                        FechaIngresoPersonalR = fila.GetCell(7).ToString(),
                        FechaNombramientoPersonalR = fila.GetCell(8).ToString(),
                        FechaPaseRetiroPersonalR = fila.GetCell(9).ToString(),
                        FechaReincorporacionPersonalR = fila.GetCell(10).ToString(),
                        FechaPrimerAportePersonalR = fila.GetCell(11).ToString(),
                        FechaUltimoAportePersonalR = fila.GetCell(12).ToString(),
                        NumeroCuotasAportadasPersonalR = int.Parse(fila.GetCell(13).ToString()),
                        AporteMensualUltimoPersonalR = decimal.Parse(fila.GetCell(14).ToString()),
                        TipoLiquidacionPersonalR = fila.GetCell(15).ToString(),
                        DevolucionAportePersonalR = int.Parse(fila.GetCell(16).ToString()),
                        FechaLiquidacionPersonalR = fila.GetCell(17).ToString(),
                        CodigoCausalLiquidacion = fila.GetCell(18).ToString(),

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

            dt.Columns.AddRange(new DataColumn[20]
            {
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("DNIPersonalRetiro", typeof(string)),
                    new DataColumn("SexoPersonalRetiro", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("CodigoGradoRemunerativo", typeof(string)),
                    new DataColumn("CodigoSituacionPersonalNaval", typeof(string)),
                    new DataColumn("FechaNacimientoPersonalR", typeof(string)),
                    new DataColumn("FechaIngresoPersonalR", typeof(string)),
                    new DataColumn("FechaNombramientoPersonalR", typeof(string)),
                    new DataColumn("FechaPaseRetiroPersonalR", typeof(string)),
                    new DataColumn("FechaReincorporacionPersonalR", typeof(string)),
                    new DataColumn("FechaPrimerAportePersonalR", typeof(string)),
                    new DataColumn("FechaUltimoAportePersonalR", typeof(string)),
                    new DataColumn("NumeroCuotasAportadasPersonalR", typeof(int)),
                    new DataColumn("AporteMensualUltimoPersonalR", typeof(decimal)),
                    new DataColumn("TipoLiquidacionPersonalR", typeof(string)),
                    new DataColumn("DevolucionAportePersonalR", typeof(int)),
                    new DataColumn("FechaLiquidacionPersonalR", typeof(string)),
                    new DataColumn("CodigoCausalLiquidacion", typeof(string)),
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
                    fila.GetCell(5).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(11).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(12).ToString()),
                    int.Parse(fila.GetCell(13).ToString()),
                    decimal.Parse(fila.GetCell(14).ToString()),
                    fila.GetCell(15).ToString(),
                    int.Parse(fila.GetCell(16).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(17).ToString()),
                    fila.GetCell(18).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = aportFondoRetiroCesacionBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DifosereceAportFondoRetiroCesacion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DifosereceAportFondoRetiroCesacion.xlsx");
        }
    }

}
