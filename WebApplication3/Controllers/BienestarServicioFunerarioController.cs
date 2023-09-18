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

    public class BienestarServicioFunerarioController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        ServicioFunerario servicioFunerarioBL = new();

        PersonalSolicitante personalSolicitanteBL = new();
        CondicionSolicitante condicionSolicitanteBL = new();
        PersonalBeneficiado personalBeneficiadoBL = new();
        CategoriaPago categoriaPagoBL = new();
        Carga cargaBL = new();

        public BienestarServicioFunerarioController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio Funerario", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<PersonalSolicitanteDTO> personalSolicitanteDTO = personalSolicitanteBL.ObtenerPersonalSolicitantes();
            List<CondicionSolicitanteDTO> condicionSolicitanteDTO = condicionSolicitanteBL.ObtenerCondicionSolicitantes();
            List<PersonalBeneficiadoDTO> personalBeneficiadoDTO = personalBeneficiadoBL.ObtenerPersonalBeneficiados();
            List<CategoriaPagoDTO> categoriaPagoDTO = categoriaPagoBL.ObtenerCategoriaPagos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioFunerario");

            return Json(new
            {
                data1 = personalSolicitanteDTO,
                data2 = condicionSolicitanteDTO,
                data3 = personalBeneficiadoDTO,
                data4 = categoriaPagoDTO,
                data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ServicioFunerarioDTO> select = servicioFunerarioBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }
        public ActionResult Insertar(string FechaServicioFunerario, string DNISolicitante, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoPersonalBeneficiado, string CodigoCategoriaPago, string ServicioTramiteSepelio, string ServicioAlquilerAtaud, string ServicioVentaAtaud,
            string ServicioCremacion, string ServicioSalonVelatorio, string ServicioCapillaArdiente, string ServicioAlquilerCarroza,
            string ServicioAlquilerCarroServicio, string ServicioAlquilerCarroFlores, decimal MontoTotalServicio, int CargaId, string Fecha)
        {
            ServicioFunerarioDTO servicioFunerarioDTO = new();
            servicioFunerarioDTO.FechaServicioFunerario = FechaServicioFunerario;
            servicioFunerarioDTO.DNISolicitante = DNISolicitante;
            servicioFunerarioDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            servicioFunerarioDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            servicioFunerarioDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            servicioFunerarioDTO.CodigoCategoriaPago = CodigoCategoriaPago;
            servicioFunerarioDTO.ServicioTramiteSepelio = ServicioTramiteSepelio;
            servicioFunerarioDTO.ServicioAlquilerAtaud = ServicioAlquilerAtaud;
            servicioFunerarioDTO.ServicioVentaAtaud = ServicioVentaAtaud;
            servicioFunerarioDTO.ServicioCremacion = ServicioCremacion;
            servicioFunerarioDTO.ServicioSalonVelatorio = ServicioSalonVelatorio;
            servicioFunerarioDTO.ServicioCapillaArdiente = ServicioCapillaArdiente;
            servicioFunerarioDTO.ServicioAlquilerCarroza = ServicioAlquilerCarroza;
            servicioFunerarioDTO.ServicioAlquilerCarroServicio = ServicioAlquilerCarroServicio;
            servicioFunerarioDTO.ServicioAlquilerCarroFlores = ServicioAlquilerCarroFlores;
            servicioFunerarioDTO.MontoTotalServicio = MontoTotalServicio;
            servicioFunerarioDTO.CargaId = CargaId;
            servicioFunerarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioFunerarioBL.AgregarRegistro(servicioFunerarioDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioFunerarioBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaServicioFunerario, string DNISolicitante, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoPersonalBeneficiado, string CodigoCategoriaPago, string ServicioTramiteSepelio, string ServicioAlquilerAtaud, string ServicioVentaAtaud,
            string ServicioCremacion, string ServicioSalonVelatorio, string ServicioCapillaArdiente, string ServicioAlquilerCarroza,
            string ServicioAlquilerCarroServicio, string ServicioAlquilerCarroFlores, decimal MontoTotalServicio)
        {
            ServicioFunerarioDTO servicioFunerarioDTO = new();
            servicioFunerarioDTO.ServicioFunerarioId = Id;
            servicioFunerarioDTO.FechaServicioFunerario = FechaServicioFunerario;
            servicioFunerarioDTO.DNISolicitante = DNISolicitante;
            servicioFunerarioDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            servicioFunerarioDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            servicioFunerarioDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            servicioFunerarioDTO.CodigoCategoriaPago = CodigoCategoriaPago;
            servicioFunerarioDTO.ServicioTramiteSepelio = ServicioTramiteSepelio;
            servicioFunerarioDTO.ServicioAlquilerAtaud = ServicioAlquilerAtaud;
            servicioFunerarioDTO.ServicioVentaAtaud = ServicioVentaAtaud;
            servicioFunerarioDTO.ServicioCremacion = ServicioCremacion;
            servicioFunerarioDTO.ServicioSalonVelatorio = ServicioSalonVelatorio;
            servicioFunerarioDTO.ServicioCapillaArdiente = ServicioCapillaArdiente;
            servicioFunerarioDTO.ServicioAlquilerCarroza = ServicioAlquilerCarroza;
            servicioFunerarioDTO.ServicioAlquilerCarroServicio = ServicioAlquilerCarroServicio;
            servicioFunerarioDTO.ServicioAlquilerCarroFlores = ServicioAlquilerCarroFlores;
            servicioFunerarioDTO.MontoTotalServicio = MontoTotalServicio;
            servicioFunerarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioFunerarioBL.ActualizarFormato(servicioFunerarioDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioFunerarioDTO servicioFunerarioDTO = new();
            servicioFunerarioDTO.ServicioFunerarioId = Id;
            servicioFunerarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioFunerarioBL.EliminarFormato(servicioFunerarioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioFunerarioDTO servicioFunerarioDTO = new();
            servicioFunerarioDTO.CargaId = Id;
            servicioFunerarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioFunerarioBL.EliminarCarga(servicioFunerarioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            
            string Mensaje = "1";
            List<ServicioFunerarioDTO> lista = new List<ServicioFunerarioDTO>();
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

                    lista.Add(new ServicioFunerarioDTO
                    {
                        FechaServicioFunerario = UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                        DNISolicitante = fila.GetCell(1).ToString(),
                        CodigoPersonalSolicitante = fila.GetCell(2).ToString(),
                        CodigoCondicionSolicitante = fila.GetCell(3).ToString(),
                        CodigoPersonalBeneficiado = fila.GetCell(4).ToString(),
                        CodigoCategoriaPago = fila.GetCell(5).ToString(),
                        ServicioTramiteSepelio = fila.GetCell(6).ToString(),
                        ServicioAlquilerAtaud = fila.GetCell(7).ToString(),
                        ServicioVentaAtaud = fila.GetCell(8).ToString(),
                        ServicioCremacion = fila.GetCell(9).ToString(),
                        ServicioSalonVelatorio = fila.GetCell(10).ToString(),
                        ServicioCapillaArdiente = fila.GetCell(11).ToString(),
                        ServicioAlquilerCarroza = fila.GetCell(12).ToString(),
                        ServicioAlquilerCarroServicio = fila.GetCell(13).ToString(),
                        ServicioAlquilerCarroFlores = fila.GetCell(14).ToString(),
                        MontoTotalServicio = decimal.Parse(fila.GetCell(15).ToString())
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

            dt.Columns.AddRange(new DataColumn[17]
            {
                    new DataColumn("FechaServicioFunerario", typeof(string)),
                    new DataColumn("DNISolicitante", typeof(string)),
                    new DataColumn("CodigoPersonalSolicitante", typeof(string)),
                    new DataColumn("CodigoCondicionSolicitante", typeof(string)),
                    new DataColumn("CodigoPersonalBeneficiado", typeof(string)),
                    new DataColumn("CodigoCategoriaPago", typeof(string)),
                    new DataColumn("ServicioTramiteSepelio", typeof(string)),
                    new DataColumn("ServicioAlquilerAtaud", typeof(string)),
                    new DataColumn("ServicioVentaAtaud", typeof(string)),
                    new DataColumn("ServicioCremacion", typeof(string)),
                    new DataColumn("ServicioSalonVelatorio", typeof(string)),
                    new DataColumn("ServicioCapillaArdiente", typeof(string)),
                    new DataColumn("ServicioAlquilerCarroza", typeof(string)),
                    new DataColumn("ServicioAlquilerCarroServicio", typeof(string)),
                    new DataColumn("ServicioAlquilerCarroFlores", typeof(string)),
                    new DataColumn("MontoTotalServicio", typeof(decimal)),
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
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    decimal.Parse(fila.GetCell(15).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioFunerarioBL.InsertarDatos(dt, Fecha);

            return Content(IND_OPERACION);

                return Content(IND_OPERACION);
        }

        //public IActionResult ReporteSF(int idCarga)
        //{
        //    string mimtype = "";
        //    //int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\ServicioFunerario.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var servicioFunerario = servicioFunerarioBL.BienestarVisualizacionServicioFunerario(idCarga);
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("ServicioFunerario", servicioFunerario);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarServicioFunerario.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarServicioFunerario.xlsx");
        }

       
    }

}

