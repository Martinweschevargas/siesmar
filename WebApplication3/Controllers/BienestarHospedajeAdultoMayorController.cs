using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Formatos.Diali;
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

    public class BienestarHospedajeAdultoMayorController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        HospedajeAdultoMayor hospedajeAdultoMayorBL = new();

        PersonalSolicitante personalSolicitanteBL = new();
        CondicionSolicitante condicionSolicitanteBL = new();
        PersonalBeneficiado personalBeneficiadoBL = new();
        Carga cargaBL = new();

        public BienestarHospedajeAdultoMayorController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Hospedaje Adulto Mayor Señor del Mar", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<PersonalSolicitanteDTO> personalSolicitanteDTO = personalSolicitanteBL.ObtenerPersonalSolicitantes();
            List<CondicionSolicitanteDTO> condicionSolicitanteDTO = condicionSolicitanteBL.ObtenerCondicionSolicitantes();
            List<PersonalBeneficiadoDTO> personalBeneficiadoDTO = personalBeneficiadoBL.ObtenerPersonalBeneficiados();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("HospedajeAdultoMayor");

            return Json(new { 
                data1 = personalSolicitanteDTO, 
                data2 = condicionSolicitanteDTO, 
                data3 = personalBeneficiadoDTO, 
                data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<HospedajeAdultoMayorDTO> select = hospedajeAdultoMayorBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            
            return View();
        }
        public ActionResult Insertar(string CodigoPersonalSolicitante, string DNIHospedado, string CodigoCondicionSolicitante, string CodigoPersonalBeneficiado,
            string CondicionHospedado, string TipoPermanencia, string ResultadoSolicitud, string FechaIngreso, int CargaId, string fecha)
        {
            HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO = new();
            hospedajeAdultoMayorDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            hospedajeAdultoMayorDTO.DNIHospedado = DNIHospedado;
            hospedajeAdultoMayorDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            hospedajeAdultoMayorDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            hospedajeAdultoMayorDTO.CondicionHospedado = CondicionHospedado;
            hospedajeAdultoMayorDTO.TipoPermanencia = TipoPermanencia;
            hospedajeAdultoMayorDTO.ResultadoSolicitud = ResultadoSolicitud;
            hospedajeAdultoMayorDTO.FechaIngreso = FechaIngreso;
            hospedajeAdultoMayorDTO.CargaId = CargaId;
            hospedajeAdultoMayorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = hospedajeAdultoMayorBL.AgregarRegistro(hospedajeAdultoMayorDTO, fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(hospedajeAdultoMayorBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoPersonalSolicitante, string DNIHospedado, string CodigoCondicionSolicitante,
            string CodigoPersonalBeneficiado, string CondicionHospedado, string TipoPermanencia, string ResultadoSolicitud, string FechaIngreso)
        {
            HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO = new();
            hospedajeAdultoMayorDTO.HospedajeAdultoMayorId = Id;
            hospedajeAdultoMayorDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            hospedajeAdultoMayorDTO.DNIHospedado = DNIHospedado;
            hospedajeAdultoMayorDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            hospedajeAdultoMayorDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            hospedajeAdultoMayorDTO.CondicionHospedado = CondicionHospedado;
            hospedajeAdultoMayorDTO.TipoPermanencia = TipoPermanencia;
            hospedajeAdultoMayorDTO.ResultadoSolicitud = ResultadoSolicitud;
            hospedajeAdultoMayorDTO.FechaIngreso = FechaIngreso;
            hospedajeAdultoMayorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = hospedajeAdultoMayorBL.ActualizarFormato(hospedajeAdultoMayorDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO = new();
            hospedajeAdultoMayorDTO.HospedajeAdultoMayorId = Id;
            hospedajeAdultoMayorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (hospedajeAdultoMayorBL.EliminarFormato(hospedajeAdultoMayorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO = new();
            hospedajeAdultoMayorDTO.CargaId = Id;
            hospedajeAdultoMayorDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (hospedajeAdultoMayorBL.EliminarCarga(hospedajeAdultoMayorDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<HospedajeAdultoMayorDTO> lista = new List<HospedajeAdultoMayorDTO>();
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

                    lista.Add(new HospedajeAdultoMayorDTO
                    {
                        CodigoPersonalSolicitante = fila.GetCell(0).ToString(),
                        DNIHospedado = fila.GetCell(1).ToString(),
                        CodigoCondicionSolicitante = fila.GetCell(2).ToString(),
                        CodigoPersonalBeneficiado = fila.GetCell(3).ToString(),
                        CondicionHospedado = fila.GetCell(4).ToString(),
                        TipoPermanencia = fila.GetCell(5).ToString(),
                        ResultadoSolicitud = fila.GetCell(6).ToString(),
                        FechaIngreso = fila.GetCell(7).ToString(),
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("PersonalSolicitanteId", typeof(string)),
                    new DataColumn("DNIHospedado", typeof(string)),
                    new DataColumn("CondicionSolicitanteId", typeof(string)),
                    new DataColumn("PersonalBeneficiadoId", typeof(string)),
                    new DataColumn("CondicionHospedado", typeof(string)),
                    new DataColumn("TipoPermanencia", typeof(string)),
                    new DataColumn("ResultadoSolicitud", typeof(string)),
                    new DataColumn("FechaIngreso", typeof(string)),
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
                    fila.GetCell(6).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = hospedajeAdultoMayorBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteHAM(int idCarga)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\HospedajeAdultoMayor.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var hospedajeAdultoMayor = hospedajeAdultoMayorBL.BienestarVisualizacionHospedajeAdultoMayor(idCarga);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("HospedajeAdultoMayor", hospedajeAdultoMayor);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarHospedajeAdultoMayor.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarHospedajeAdultoMayor.xlsx");
        }

    }

}

