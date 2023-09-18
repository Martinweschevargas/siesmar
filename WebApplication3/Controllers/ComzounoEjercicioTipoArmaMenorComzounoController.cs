using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzouno;
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
    public class ComzounoEjercicioTipoArmaMenorComzounoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        EjercicioTipoArmaMenorComzouno ejercicioTipoArmaMenorComzounoBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        TipoArmamento tipoArmamentoBL = new();
        PosicionTipoArma posicionTipoArmaBL = new();
        Carga cargaBL = new();

        public ComzounoEjercicioTipoArmaMenorComzounoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Ejercicios de Tiro con Armas Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<TipoArmamentoDTO> tipoArmamentoDTO = tipoArmamentoBL.ObtenerTipoArmamentos();
            List<PosicionTipoArmaDTO> posicionTipoArmaDTO = posicionTipoArmaBL.ObtenerPosicionTipoArmas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EjercicioTipoArmaMenorComzouno");

            return Json(new
            {
                data1 = tipoPersonalMilitarDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = tipoArmamentoDTO,
                data4 = posicionTipoArmaDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EjercicioTipoArmaMenorComzounoDTO> ejercicioTipoArmaMenorComzounoDTO = ejercicioTipoArmaMenorComzounoBL.ObtenerLista();
            return Json(new { data = ejercicioTipoArmaMenorComzounoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string FechaEjercicioTipo,
            string CodigoTipoArmamento, string CodigoPosicionTipoArma, decimal DistanciaMetros, int CantidadTiro, int CargaId, string Fecha)
        {
            EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO = new();
            ejercicioTipoArmaMenorComzounoDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            ejercicioTipoArmaMenorComzounoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ejercicioTipoArmaMenorComzounoDTO.FechaEjercicioTipo = FechaEjercicioTipo;
            ejercicioTipoArmaMenorComzounoDTO.CodigoTipoArmamento = CodigoTipoArmamento;
            ejercicioTipoArmaMenorComzounoDTO.CodigoPosicionTipoArma = CodigoPosicionTipoArma;
            ejercicioTipoArmaMenorComzounoDTO.DistanciaMetros = DistanciaMetros;
            ejercicioTipoArmaMenorComzounoDTO.CantidadTiro = CantidadTiro;
            ejercicioTipoArmaMenorComzounoDTO.CargaId = CargaId;
            ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioTipoArmaMenorComzounoBL.AgregarRegistro(ejercicioTipoArmaMenorComzounoDTO,Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ejercicioTipoArmaMenorComzounoBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int EjercicioTipoArmaMenorComzounoId, string CodigoTipoPersonalMilitar, string CodigoGradoPersonalMilitar, string FechaEjercicioTipo,
            string CodigoTipoArmamento, string CodigoPosicionTipoArma, decimal DistanciaMetros, int CantidadTiro)
        {
            EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO = new();
            ejercicioTipoArmaMenorComzounoDTO.EjercicioTipoArmaMenorComzounoId = EjercicioTipoArmaMenorComzounoId;
            ejercicioTipoArmaMenorComzounoDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            ejercicioTipoArmaMenorComzounoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            ejercicioTipoArmaMenorComzounoDTO.FechaEjercicioTipo = FechaEjercicioTipo;
            ejercicioTipoArmaMenorComzounoDTO.CodigoTipoArmamento = CodigoTipoArmamento;
            ejercicioTipoArmaMenorComzounoDTO.CodigoPosicionTipoArma = CodigoPosicionTipoArma;
            ejercicioTipoArmaMenorComzounoDTO.DistanciaMetros = DistanciaMetros;
            ejercicioTipoArmaMenorComzounoDTO.CantidadTiro = CantidadTiro;
            ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioTipoArmaMenorComzounoBL.ActualizarFormato(ejercicioTipoArmaMenorComzounoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO = new();
            ejercicioTipoArmaMenorComzounoDTO.EjercicioTipoArmaMenorComzounoId = Id;
            ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ejercicioTipoArmaMenorComzounoBL.EliminarFormato(ejercicioTipoArmaMenorComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EjercicioTipoArmaMenorComzounoDTO ejercicioTipoArmaMenorComzounoDTO = new();
            ejercicioTipoArmaMenorComzounoDTO.CargaId = Id;
            ejercicioTipoArmaMenorComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (ejercicioTipoArmaMenorComzounoBL.EliminarCarga(ejercicioTipoArmaMenorComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EjercicioTipoArmaMenorComzounoDTO> lista = new List<EjercicioTipoArmaMenorComzounoDTO>();
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

                    lista.Add(new EjercicioTipoArmaMenorComzounoDTO
                    {
                        CodigoTipoPersonalMilitar = fila.GetCell(0).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(1).ToString(),
                        FechaEjercicioTipo = UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                        CodigoTipoArmamento = fila.GetCell(3).ToString(),
                        CodigoPosicionTipoArma = fila.GetCell(4).ToString(),
                        DistanciaMetros = decimal.Parse(fila.GetCell(5).ToString()),
                        CantidadTiro = int.Parse(fila.GetCell(6).ToString())

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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("FechaEjercicioTipo", typeof(string)),
                    new DataColumn("CodigoTipoArmamento", typeof(string)),
                    new DataColumn("CodigoPosicionTipoArma", typeof(string)),
                    new DataColumn("DistanciaMetros", typeof(decimal)),
                    new DataColumn("CantidadTiro", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = ejercicioTipoArmaMenorComzounoBL.InsertarDatos(dt, Fecha);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = ejercicioTipoArmaMenorComzounoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzounoEjercicioTipoArmaMenorComzouno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzounoEjercicioTipoArmaMenorComzouno.xlsx");
        }
    }

}