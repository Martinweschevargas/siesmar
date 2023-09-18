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
    public class DihidronavMillaNavegadaCombustibleHidrografiaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        MillaNavegadaCombustibleHidrografia millaNavegadaCombustibleHidrografiaBL = new();
        UnidadNaval unidadNavalBL = new();
        Mes mesBL = new();
        Carga cargaBL = new();

        public DihidronavMillaNavegadaCombustibleHidrografiaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Millas navegadas y consumo de combustible de las unidades hidrográficas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals(); 
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("MillaNavegadaCombustibleHidrografia");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = mesDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<MillaNavegadaCombustibleHidrografiaDTO> millaNavegadaCombustibleHidrografiaDTO = millaNavegadaCombustibleHidrografiaBL.ObtenerLista();
            return Json(new { data = millaNavegadaCombustibleHidrografiaDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string CodigoUnidadNaval, string NumeroCascoUnidad, string NumeroMes,
            decimal Milla, decimal Hora, decimal CombustibleGalon,int CargaId)
        {
            MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO = new();
            millaNavegadaCombustibleHidrografiaDTO.NumeroOrden = NumeroOrden;
            millaNavegadaCombustibleHidrografiaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            millaNavegadaCombustibleHidrografiaDTO.NumeroCascoUnidad = NumeroCascoUnidad;
            millaNavegadaCombustibleHidrografiaDTO.NumeroMes = NumeroMes;
            millaNavegadaCombustibleHidrografiaDTO.Milla = Milla;
            millaNavegadaCombustibleHidrografiaDTO.Hora = Hora;
            millaNavegadaCombustibleHidrografiaDTO.CombustibleGalon = CombustibleGalon;
            millaNavegadaCombustibleHidrografiaDTO.CargaId = CargaId;
            millaNavegadaCombustibleHidrografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = millaNavegadaCombustibleHidrografiaBL.AgregarRegistro(millaNavegadaCombustibleHidrografiaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(millaNavegadaCombustibleHidrografiaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int MillaNavegadaCombustibleHidrografiaId, int NumeroOrden, string CodigoUnidadNaval, string NumeroCascoUnidad, string NumeroMes,
            decimal Milla, decimal Hora, decimal CombustibleGalon)
        {
            MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO = new();
            millaNavegadaCombustibleHidrografiaDTO.MillaNavegadaCombustibleHidrografiaId = MillaNavegadaCombustibleHidrografiaId;
            millaNavegadaCombustibleHidrografiaDTO.NumeroOrden = NumeroOrden;
            millaNavegadaCombustibleHidrografiaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            millaNavegadaCombustibleHidrografiaDTO.NumeroCascoUnidad = NumeroCascoUnidad;
            millaNavegadaCombustibleHidrografiaDTO.NumeroMes = NumeroMes;
            millaNavegadaCombustibleHidrografiaDTO.Milla = Milla;
            millaNavegadaCombustibleHidrografiaDTO.Hora = Hora;
            millaNavegadaCombustibleHidrografiaDTO.CombustibleGalon = CombustibleGalon;
            millaNavegadaCombustibleHidrografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = millaNavegadaCombustibleHidrografiaBL.ActualizarFormato(millaNavegadaCombustibleHidrografiaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MillaNavegadaCombustibleHidrografiaDTO millaNavegadaCombustibleHidrografiaDTO = new();
            millaNavegadaCombustibleHidrografiaDTO.MillaNavegadaCombustibleHidrografiaId = Id;
            millaNavegadaCombustibleHidrografiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (millaNavegadaCombustibleHidrografiaBL.EliminarFormato(millaNavegadaCombustibleHidrografiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<MillaNavegadaCombustibleHidrografiaDTO> lista = new List<MillaNavegadaCombustibleHidrografiaDTO>();
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

                    lista.Add(new MillaNavegadaCombustibleHidrografiaDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        CodigoUnidadNaval = fila.GetCell(1).ToString(),
                        NumeroCascoUnidad = fila.GetCell(2).ToString(),
                        NumeroMes = fila.GetCell(3).ToString(),
                        Milla = decimal.Parse(fila.GetCell(4).ToString()),
                        Hora = decimal.Parse(fila.GetCell(5).ToString()),
                        CombustibleGalon = decimal.Parse(fila.GetCell(6).ToString())
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("NumeroCascoUnidad", typeof(string)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("Milla", typeof(decimal)),
                    new DataColumn("Hora", typeof(decimal)),
                    new DataColumn("CombustibleGalon", typeof(decimal)),
 
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
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = millaNavegadaCombustibleHidrografiaBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavMillaNavegadaCombustibleHidrografia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavMillaNavegadaCombustibleHidrografia.xlsx");
        }
    }

}