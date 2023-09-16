using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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

    public class ComfuavinavAlistamientoMaterialController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoMaterialComfuavinav alistamientoMaterialComfuavinavBL = new();

        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();
        Carga cargaBL = new();

        public ComfuavinavAlistamientoMaterialController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de Material", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<AlistamientoMaterialRequerido3NDTO> alistamientoMaterialRequerido3NDTO = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialComfuavinav");
            return Json(new { data1 = unidadNavalDTO, data2 = capacidadOperativaDTO, data3 = alistamientoMaterialRequerido3NDTO, data4 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMaterialComfuavinavDTO> select = alistamientoMaterialComfuavinavBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 150, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoCapacidadOperativa, string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo,
             decimal PorcentajeOperativo, int CargaId, string Fecha)
        {
            AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO = new();
            alistamientoMaterialComfuavinavDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComfuavinavDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComfuavinavDTO.Requerido = Requerido;
            alistamientoMaterialComfuavinavDTO.Operativo = Operativo;
            alistamientoMaterialComfuavinavDTO.PorcentajeOperativo = PorcentajeOperativo;
            alistamientoMaterialComfuavinavDTO.CargaId = CargaId;
            alistamientoMaterialComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComfuavinavBL.AgregarRegistro(alistamientoMaterialComfuavinavDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialComfuavinavBL.EditarFormado(Id));
        }

        //[AuthorizePermission(Formato: 150, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoCapacidadOperativa, string CodigoUnidadNaval,string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo,
            decimal PorcentajeOperativo)
        {
            AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO = new();
            alistamientoMaterialComfuavinavDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComfuavinavDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComfuavinavDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComfuavinavDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComfuavinavDTO.Requerido = Requerido;
            alistamientoMaterialComfuavinavDTO.Operativo = Operativo;
            alistamientoMaterialComfuavinavDTO.PorcentajeOperativo = PorcentajeOperativo;
            alistamientoMaterialComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComfuavinavBL.ActualizarFormato(alistamientoMaterialComfuavinavDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 150, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO = new();
            alistamientoMaterialComfuavinavDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialComfuavinavBL.EliminarFormato(alistamientoMaterialComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 150, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO = new();
            alistamientoMaterialComfuavinavDTO.CargaId = Id;
            alistamientoMaterialComfuavinavDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMaterialComfuavinavBL.EliminarCarga(alistamientoMaterialComfuavinavDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMaterialComfuavinavDTO> lista = new List<AlistamientoMaterialComfuavinavDTO>();
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

                    lista.Add(new AlistamientoMaterialComfuavinavDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(2).ToString(),
                        Requerido = int.Parse(fila.GetCell(3).ToString()),
                        Operativo = int.Parse(fila.GetCell(4).ToString()),
                        PorcentajeOperativo = decimal.Parse(fila.GetCell(5).ToString())
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
        //[AuthorizePermission(Formato: 150, Permiso: 4)]//Registrar Masivo
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido3N", typeof(string)),
                    new DataColumn("Requerido", typeof(int)),
                    new DataColumn("Operativo", typeof(int)),
                    new DataColumn("PorcentajeOperativo", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),

                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoMaterialComfuavinavBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfuavinavAlistamientoMaterial.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfuavinavAlistamientoMaterial.xlsx");
        }
    }

}

