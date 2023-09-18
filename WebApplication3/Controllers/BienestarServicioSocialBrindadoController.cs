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

    public class BienestarServicioSocialBrindadoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ServicioSocialBrindado servicioSocialBrindadoBL = new();
        PersonalSolicitante personalSolicitanteBL = new();
        CondicionSolicitante condicionSolicitanteBL = new();
        PersonalBeneficiado personalBeneficiadoBL = new();
        TipoApoyoSocial tipoApoyoSocialBL = new();
        TipoAtencion tipoAtencionBL = new();
        TipoEvaluacionSocial tipoEvaluacionSocialBL = new();
        Carga cargaBL = new();

        public BienestarServicioSocialBrindadoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio Social Brindado al Personal", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<PersonalSolicitanteDTO> personalSolicitanteDTO = personalSolicitanteBL.ObtenerPersonalSolicitantes();
            List<CondicionSolicitanteDTO> condicionSolicitanteDTO = condicionSolicitanteBL.ObtenerCondicionSolicitantes();
            List<PersonalBeneficiadoDTO> personalBeneficiadoDTO = personalBeneficiadoBL.ObtenerPersonalBeneficiados();
            List<TipoApoyoSocialDTO> tipoApoyoSocialDTO = tipoApoyoSocialBL.ObtenerTipoApoyoSocials();
            List<TipoAtencionDTO> tipoAtencionDTO = tipoAtencionBL.ObtenerTipoAtencions();
            List<TipoEvaluacionSocialDTO> tipoEvaluacionSocialDTO = tipoEvaluacionSocialBL.ObtenerTipoEvaluacionSocials();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioSocialBrindado");

            return Json(new { data1 = personalSolicitanteDTO, data2 = condicionSolicitanteDTO, data3 = personalBeneficiadoDTO,
                data4 = tipoApoyoSocialDTO, data5 = tipoAtencionDTO, data6 = tipoEvaluacionSocialDTO,
                data7 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ServicioSocialBrindadoDTO> select = servicioSocialBrindadoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string FechaSolicitud, string DNIPersonal, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoPersonalBeneficiado, string CodigoTipoApoyoSocial, string CodigoTipoAtencion, string CodigoTipoEvaluacionSocial, string OtroTipoApoyo,
            string ResultadoSolicitud, string FechaResultadoSolicitud, int CargaId, string Fecha)
        {
            ServicioSocialBrindadoDTO servicioSocialBrindadoDTO = new();
            servicioSocialBrindadoDTO.FechaSolicitud = FechaSolicitud;
            servicioSocialBrindadoDTO.DNIPersonal = DNIPersonal;
            servicioSocialBrindadoDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            servicioSocialBrindadoDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            servicioSocialBrindadoDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            servicioSocialBrindadoDTO.CodigoTipoApoyoSocial = CodigoTipoApoyoSocial;
            servicioSocialBrindadoDTO.CodigoTipoAtencion = CodigoTipoAtencion;
            servicioSocialBrindadoDTO.CodigoTipoEvaluacionSocial = CodigoTipoEvaluacionSocial;
            servicioSocialBrindadoDTO.OtroTipoApoyo = OtroTipoApoyo;
            servicioSocialBrindadoDTO.ResultadoSolicitud = ResultadoSolicitud;
            servicioSocialBrindadoDTO.FechaResultadoSolicitud = FechaResultadoSolicitud;
            servicioSocialBrindadoDTO.CargaId = CargaId;
            servicioSocialBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioSocialBrindadoBL.AgregarRegistro(servicioSocialBrindadoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioSocialBrindadoBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string FechaSolicitud, string DNIPersonal, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoPersonalBeneficiado, string CodigoTipoApoyoSocial, string CodigoTipoAtencion, string CodigoTipoEvaluacionSocial, string OtroTipoApoyo,
            string ResultadoSolicitud, string FechaResultadoSolicitud)
        {
            ServicioSocialBrindadoDTO servicioSocialBrindadoDTO = new();
            servicioSocialBrindadoDTO.ServicioSocialBrindadoId = Id;
            servicioSocialBrindadoDTO.FechaSolicitud = FechaSolicitud;
            servicioSocialBrindadoDTO.DNIPersonal = DNIPersonal;
            servicioSocialBrindadoDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            servicioSocialBrindadoDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            servicioSocialBrindadoDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            servicioSocialBrindadoDTO.CodigoTipoApoyoSocial = CodigoTipoApoyoSocial;
            servicioSocialBrindadoDTO.CodigoTipoAtencion = CodigoTipoAtencion;
            servicioSocialBrindadoDTO.CodigoTipoEvaluacionSocial = CodigoTipoEvaluacionSocial;
            servicioSocialBrindadoDTO.OtroTipoApoyo = OtroTipoApoyo;
            servicioSocialBrindadoDTO.ResultadoSolicitud = ResultadoSolicitud;
            servicioSocialBrindadoDTO.FechaResultadoSolicitud = FechaResultadoSolicitud;
            servicioSocialBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioSocialBrindadoBL.ActualizarFormato(servicioSocialBrindadoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioSocialBrindadoDTO servicioSocialBrindadoDTO = new();
            servicioSocialBrindadoDTO.ServicioSocialBrindadoId = Id;
            servicioSocialBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioSocialBrindadoBL.EliminarFormato(servicioSocialBrindadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioSocialBrindadoDTO servicioSocialBrindadoDTO = new();
            servicioSocialBrindadoDTO.CargaId = Id;
            servicioSocialBrindadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioSocialBrindadoBL.EliminarCarga(servicioSocialBrindadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioSocialBrindadoDTO> lista = new List<ServicioSocialBrindadoDTO>();
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

                    lista.Add(new ServicioSocialBrindadoDTO
                    {
                        FechaSolicitud = fila.GetCell(0).ToString(),
                        DNIPersonal = fila.GetCell(1).ToString(),
                        CodigoPersonalSolicitante = fila.GetCell(2).ToString(),
                        CodigoCondicionSolicitante = fila.GetCell(3).ToString(),
                        CodigoPersonalBeneficiado = fila.GetCell(4).ToString(),
                        CodigoTipoApoyoSocial = fila.GetCell(5).ToString(),
                        CodigoTipoAtencion = fila.GetCell(6).ToString(),
                        CodigoTipoEvaluacionSocial = fila.GetCell(7).ToString(),
                        OtroTipoApoyo = fila.GetCell(8).ToString(),
                        ResultadoSolicitud = fila.GetCell(9).ToString(),
                        FechaResultadoSolicitud = fila.GetCell(10).ToString()
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
                    new DataColumn("FechaSolicitud", typeof(string)),
                    new DataColumn("DNIPersonal", typeof(string)),
                    new DataColumn("CodigoPersonalSolicitante", typeof(string)),
                    new DataColumn("CodigoCondicionSolicitante", typeof(string)),
                    new DataColumn("CodigoPersonalBeneficiado", typeof(string)),
                    new DataColumn("CodigoTipoApoyoSocial", typeof(string)),
                    new DataColumn("CodigoTipoAtencion", typeof(string)),
                    new DataColumn("CodigoTipoEvaluacionSocial", typeof(string)),
                    new DataColumn("OtroTipoApoyo", typeof(string)),
                    new DataColumn("ResultadoSolicitud", typeof(string)),
                    new DataColumn("FechaResultadoSolicitud", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(10).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioSocialBrindadoBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }
        public IActionResult ReporteSSB(int? idCarga=null, string? fechaInicio=null, string fechaFin=null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\ServicioSocialBrindado.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var servicioSocialBrindado = servicioSocialBrindadoBL.BienestarVisualizacionServicioSocialBrindadoPersonal(idCarga, fechaInicio, fechaFin);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ServicioSocialBrindado", servicioSocialBrindado);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarServicioSocialBrindado.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarServicioSocialBrindado.xlsx");
        }

     
    }

}

