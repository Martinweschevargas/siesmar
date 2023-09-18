using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diabaste;
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
    public class DiabasteDistribucionVestuarioController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        DistribucionVestuario distribucionVestuarioBL = new();
        Mes mesBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        TipoPrenda tipoPrendaBL = new();
        UnidadMedida unidadMedidaBL = new();
        Carga cargaBL = new();

        public DiabasteDistribucionVestuarioController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Distribución de Vestuario a las Unidades y Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess(); 
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<TipoPrendaDTO> tipoPrendaDTO = tipoPrendaBL.ObtenerTipoPrendas();
            List<UnidadMedidaDTO> unidadMedidaDTO = unidadMedidaBL.ObtenerUnidadMedidas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DistribucionVestuario");

            return Json(new
            {
                data1 = mesDTO,
                data2 = areaDiperadmonDTO,
                data3 = tipoPrendaDTO,
                data4 = unidadMedidaDTO,
                data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<DistribucionVestuarioDTO> distribucionVestuarioDTO = distribucionVestuarioBL.ObtenerLista();
            return Json(new { data = distribucionVestuarioDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int Anio, string CodigoAreaDiperadmon, string NumeroMes, string CodigoUnidadMedida, int CantidadPrendaEntregada,
            string CodigoTipoPrenda, string FechaEntrega, int CargaId, string Fecha)
        {
            DistribucionVestuarioDTO distribucionVestuarioDTO = new();
            distribucionVestuarioDTO.Anio = Anio;
            distribucionVestuarioDTO.NumeroMes = NumeroMes;
            distribucionVestuarioDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            distribucionVestuarioDTO.CodigoTipoPrenda = CodigoTipoPrenda;
            distribucionVestuarioDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            distribucionVestuarioDTO.CantidadPrendaEntregada = CantidadPrendaEntregada;
            distribucionVestuarioDTO.FechaEntrega = FechaEntrega;
            distribucionVestuarioDTO.CargaId = CargaId;
            distribucionVestuarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distribucionVestuarioBL.AgregarRegistro(distribucionVestuarioDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(distribucionVestuarioBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int DistribucionVestuarioId, int Anio, string CodigoAreaDiperadmon, string NumeroMes, string CodigoUnidadMedida, int CantidadPrendaEntregada,
            string CodigoTipoPrenda, string FechaEntrega)
        {
            DistribucionVestuarioDTO distribucionVestuarioDTO = new();
            distribucionVestuarioDTO.DistribucionVestuarioId = DistribucionVestuarioId;
            distribucionVestuarioDTO.Anio = Anio;
            distribucionVestuarioDTO.NumeroMes = NumeroMes;
            distribucionVestuarioDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            distribucionVestuarioDTO.CodigoTipoPrenda = CodigoTipoPrenda;
            distribucionVestuarioDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            distribucionVestuarioDTO.CantidadPrendaEntregada = CantidadPrendaEntregada;
            distribucionVestuarioDTO.FechaEntrega = FechaEntrega;
            distribucionVestuarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distribucionVestuarioBL.ActualizarFormato(distribucionVestuarioDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DistribucionVestuarioDTO distribucionVestuarioDTO = new();
            distribucionVestuarioDTO.DistribucionVestuarioId = Id;
            distribucionVestuarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (distribucionVestuarioBL.EliminarFormato(distribucionVestuarioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DistribucionVestuarioDTO distribucionVestuarioDTO = new();
            distribucionVestuarioDTO.CargaId = Id;
            distribucionVestuarioDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (distribucionVestuarioBL.EliminarCarga(distribucionVestuarioDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<DistribucionVestuarioDTO> lista = new List<DistribucionVestuarioDTO>();
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

                    lista.Add(new DistribucionVestuarioDTO
                    {
                        Anio = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(2).ToString(),
                        CodigoTipoPrenda = fila.GetCell(3).ToString(),
                        CodigoUnidadMedida = fila.GetCell(4).ToString(),
                        CantidadPrendaEntregada = int.Parse(fila.GetCell(5).ToString()),
                        FechaEntrega = fila.GetCell(6).ToString(),
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje = "";

            IWorkbook MiExcel = null;

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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("Anio", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoTipoPrenda", typeof(string)),
                    new DataColumn("CodigoUnidadMedida", typeof(string)),
                    new DataColumn("CantidadPrendaEntregada", typeof(int)),
                    new DataColumn("FechaEntrega", typeof(string)),
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
                    int.Parse(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = distribucionVestuarioBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDistribucionVestuario()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diabaste\\DistribucionVestuario.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var distribucionVestuario = distribucionVestuarioBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DistribucionVestuario", distribucionVestuario);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiabasteDistribucionVestuario.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiabasteDistribucionVestuario.xlsx");
        }

    }

}