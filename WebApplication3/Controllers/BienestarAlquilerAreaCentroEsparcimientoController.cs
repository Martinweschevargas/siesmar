using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
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

    public class BienestarAlquilerAreaCentroEsparcimientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlquilerAreaCentroEsparcimiento alquilerAreaCentroEsparcimientoBL = new();
        UsuarioAlquilerCentroEsparcimiento usuarioAlquilerCentroEsparcimientoBL = new();
        ClubEsparcimiento clubEsparcimientoBL = new();
        AreaSalonClubEsparcimiento areaSalonClubEsparcimientoBL = new();
        TipoEventoDAO tipoEventoBL = new();
        Carga cargaBL = new();

        public BienestarAlquilerAreaCentroEsparcimientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alquiler de Areas y Salones de los Centros de Esparcimiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UsuarioAlquilerCentroEsparcimientoDTO> usuarioAlquilerCentroEsparcimientoDTO = usuarioAlquilerCentroEsparcimientoBL.ObtenerUsuarioAlquilerCentroEsparcimientos();
            List<ClubEsparcimientoDTO> clubEsparcimientoDTO = clubEsparcimientoBL.ObtenerClubEsparcimientos();
            List<TipoEventoDTO> tipoEventoDTO = tipoEventoBL.ObtenerTipoEventos();
            List<AreaSalonClubEsparcimientoDTO> areaSalonClubEsparcimientoDTO = areaSalonClubEsparcimientoBL.ObtenerAreaSalonClubEsparcimientos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlquilerAreaCentroEsparcimiento");

            return Json(new { 
                data1 = usuarioAlquilerCentroEsparcimientoDTO, 
                data2 = clubEsparcimientoDTO, 
                data3 = tipoEventoDTO ,
                data4 = areaSalonClubEsparcimientoDTO, 
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlquilerAreaCentroEsparcimientoDTO> select = alquilerAreaCentroEsparcimientoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( string FechaAlquiler, string DNIUsuario, string CodigoUsuarioAlquilerCentroEsparcimiento, string CodigoClubEsparcimiento,
            string CodigoAreaSalonClubEsparcimiento, string CodigoTipoEvento, string HoraInicio, string HoraTermino, int NumeroHoras, int NumeroInvitados,
            decimal MontoFacturado, int CargaId, string Fecha)
        {
            AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO = new();
            alquilerAreaCentroEsparcimientoDTO.FechaAlquiler = FechaAlquiler;
            alquilerAreaCentroEsparcimientoDTO.DNIUsuario = DNIUsuario;
            alquilerAreaCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento = CodigoUsuarioAlquilerCentroEsparcimiento;
            alquilerAreaCentroEsparcimientoDTO.CodigoClubEsparcimiento = CodigoClubEsparcimiento;
            alquilerAreaCentroEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento = CodigoAreaSalonClubEsparcimiento;
            alquilerAreaCentroEsparcimientoDTO.CodigoTipoEvento = CodigoTipoEvento;
            alquilerAreaCentroEsparcimientoDTO.HoraInicio = HoraInicio;
            alquilerAreaCentroEsparcimientoDTO.HoraTermino = HoraTermino;
            alquilerAreaCentroEsparcimientoDTO.NumeroHoras = NumeroHoras;
            alquilerAreaCentroEsparcimientoDTO.NumeroInvitados = NumeroInvitados;
            alquilerAreaCentroEsparcimientoDTO.MontoFacturado = MontoFacturado;
            alquilerAreaCentroEsparcimientoDTO.CargaId = CargaId;
            alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alquilerAreaCentroEsparcimientoBL.AgregarRegistro(alquilerAreaCentroEsparcimientoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alquilerAreaCentroEsparcimientoBL.EditarFormado(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string FechaAlquiler, string DNIUsuario, string CodigoUsuarioAlquilerCentroEsparcimiento, string CodigoClubEsparcimiento,
            string CodigoAreaSalonClubEsparcimiento, string CodigoTipoEvento, string HoraInicio, string HoraTermino, int NumeroHoras, int NumeroInvitados,
            decimal MontoFacturado)
        {
            AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO = new();
            alquilerAreaCentroEsparcimientoDTO.AlquilerAreaCentroEsparcimientoId = Id;
            alquilerAreaCentroEsparcimientoDTO.FechaAlquiler = FechaAlquiler;
            alquilerAreaCentroEsparcimientoDTO.DNIUsuario = DNIUsuario;
            alquilerAreaCentroEsparcimientoDTO.CodigoUsuarioAlquilerCentroEsparcimiento = CodigoUsuarioAlquilerCentroEsparcimiento;
            alquilerAreaCentroEsparcimientoDTO.CodigoClubEsparcimiento = CodigoClubEsparcimiento;
            alquilerAreaCentroEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento = CodigoAreaSalonClubEsparcimiento;
            alquilerAreaCentroEsparcimientoDTO.CodigoTipoEvento = CodigoTipoEvento;
            alquilerAreaCentroEsparcimientoDTO.HoraInicio = HoraInicio;
            alquilerAreaCentroEsparcimientoDTO.HoraTermino = HoraTermino;
            alquilerAreaCentroEsparcimientoDTO.NumeroHoras = NumeroHoras;
            alquilerAreaCentroEsparcimientoDTO.NumeroInvitados = NumeroInvitados;
            alquilerAreaCentroEsparcimientoDTO.MontoFacturado = MontoFacturado;
            alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alquilerAreaCentroEsparcimientoBL.ActualizarFormato(alquilerAreaCentroEsparcimientoDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO = new();
            alquilerAreaCentroEsparcimientoDTO.AlquilerAreaCentroEsparcimientoId = Id;
            alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alquilerAreaCentroEsparcimientoBL.EliminarFormato(alquilerAreaCentroEsparcimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlquilerAreaCentroEsparcimientoDTO alquilerAreaCentroEsparcimientoDTO = new();
            alquilerAreaCentroEsparcimientoDTO.CargaId = Id;
            alquilerAreaCentroEsparcimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alquilerAreaCentroEsparcimientoBL.EliminarCarga(alquilerAreaCentroEsparcimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlquilerAreaCentroEsparcimientoDTO> lista = new List<AlquilerAreaCentroEsparcimientoDTO>();
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

                    lista.Add(new AlquilerAreaCentroEsparcimientoDTO
                    {
                        FechaAlquiler = fila.GetCell(0).ToString(),
                        DNIUsuario = fila.GetCell(1).ToString(),
                        CodigoUsuarioAlquilerCentroEsparcimiento = fila.GetCell(2).ToString(),
                        CodigoClubEsparcimiento = fila.GetCell(3).ToString(),
                        CodigoAreaSalonClubEsparcimiento = fila.GetCell(4).ToString(),
                        CodigoTipoEvento = fila.GetCell(5).ToString(),
                        HoraInicio = fila.GetCell(6).ToString(),
                        HoraTermino = fila.GetCell(7).ToString(),
                        NumeroHoras = int.Parse(fila.GetCell(8).ToString()),
                        NumeroInvitados = int.Parse(fila.GetCell(9).ToString()),
                        MontoFacturado = decimal.Parse(fila.GetCell(10).ToString())
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("FechaAlquiler", typeof(string)),
                    new DataColumn("DNIUsuario", typeof(string)),
                    new DataColumn("CodigoUsuarioAlquilerCentroEsparcimiento", typeof(string)),
                    new DataColumn("CodigoClubEsparcimiento", typeof(string)),
                    new DataColumn("CodigoAreaSalonClubEsparcimiento", typeof(string)),
                    new DataColumn("CodigoTipoEvento", typeof(string)),
                    new DataColumn("HoraInicio", typeof(string)),
                    new DataColumn("HoraTermino", typeof(string)),
                    new DataColumn("NumeroHoras", typeof(int)),
                    new DataColumn("NumeroInvitados", typeof(int)),
                    new DataColumn("MontoFacturado", typeof(decimal)),
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
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    decimal.Parse(fila.GetCell(10).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = alquilerAreaCentroEsparcimientoBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarAlquilerAreaCentroEsparcimiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarAlquilerAreaCentroEsparcimiento.xlsx");
        }
    }

}

