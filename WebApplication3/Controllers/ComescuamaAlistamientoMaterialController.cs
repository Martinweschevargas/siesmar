using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comescuama;
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

    public class ComescuamaAlistamientoMaterialController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoMaterialComescuama alistamientoMaterialComescuamaBL = new();
        UnidadComescuamaDAO unidadComescuamaBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        AlistamientoMaterialRequerido3NDAO alistamientoMaterialRequerido3NBL = new();
        AlistamientoMaterialRequeridoComescuama alistMaterialRequeridoComescuamaBL = new();
        Carga cargaBL = new();

        public ComescuamaAlistamientoMaterialController(IWebHostEnvironment webHostEnvironment)
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
            List<UnidadComescuamaDTO> unidadComescuamaDTO = unidadComescuamaBL.ObtenerUnidadComescuamas();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<AlistamientoMaterialRequerido3NDTO> alistamientoMaterialRequerido3NDTO = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();
            List<AlistamientoMaterialRequeridoComescuamaDTO> alistMaterialRequeridoComescuamaDTO = alistMaterialRequeridoComescuamaBL.ObtenerAlistamientoMaterialRequeridoComescuamas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialComescuama");
            return Json(new { 
                data1 = unidadComescuamaDTO, 
                data2 = capacidadOperativaDTO, 
                data3 = alistamientoMaterialRequerido3NDTO,
                data4 = alistMaterialRequeridoComescuamaDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMaterialComescuamaDTO> lista = alistamientoMaterialComescuamaBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadComescuama, string CodigoCapacidadOperativa, 
            string CodigoAlistamientoMaterialRequerido3N, string CodigoAlistamientoMaterialRequeridoComescuama, 
            decimal PonderadoFuncional, decimal NivelAlistamientoParcial, int CargaId, string Fecha)
        {
            AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO = new();
            alistamientoMaterialComescuamaDTO.CodigoUnidadComescuama = CodigoUnidadComescuama;
            alistamientoMaterialComescuamaDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama = CodigoAlistamientoMaterialRequeridoComescuama;
            alistamientoMaterialComescuamaDTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialComescuamaDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComescuamaDTO.CargaId = CargaId;
            alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComescuamaBL.AgregarRegistro(alistamientoMaterialComescuamaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialComescuamaBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadComescuama, string CodigoCapacidadOperativa,
            string CodigoAlistamientoMaterialRequerido3N, string CodigoAlistamientoMaterialRequeridoComescuama,
            decimal PonderadoFuncional, decimal NivelAlistamientoParcial)
        {
            AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO = new();
            alistamientoMaterialComescuamaDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComescuamaDTO.CodigoUnidadComescuama = CodigoUnidadComescuama;
            alistamientoMaterialComescuamaDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama = CodigoAlistamientoMaterialRequeridoComescuama;
            alistamientoMaterialComescuamaDTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialComescuamaDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComescuamaBL.ActualizarFormato(alistamientoMaterialComescuamaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO = new();
            alistamientoMaterialComescuamaDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialComescuamaBL.EliminarFormato(alistamientoMaterialComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO = new();
            alistamientoMaterialComescuamaDTO.CargaId = Id;
            alistamientoMaterialComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMaterialComescuamaBL.EliminarCarga(alistamientoMaterialComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMaterialComescuamaDTO> lista = new List<AlistamientoMaterialComescuamaDTO>();
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

                    lista.Add(new AlistamientoMaterialComescuamaDTO
                    {
                        CodigoUnidadComescuama = fila.GetCell(0).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(2).ToString(),
                        CodigoAlistamientoMaterialRequeridoComescuama = fila.GetCell(3).ToString(),
                        PonderadoFuncional = decimal.Parse(fila.GetCell(4).ToString()),
                        NivelAlistamientoParcial = decimal.Parse(fila.GetCell(5).ToString()),
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

            dt.Columns.AddRange(new DataColumn[7]
            {
                    new DataColumn("CodigoUnidadComescuama", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido3N", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequeridoComescuama", typeof(string)),
                    new DataColumn("PonderadoFuncional", typeof(decimal)),
                    new DataColumn("NivelAlistamientoParcial", typeof(decimal)),
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
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoMaterialComescuamaBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComescuamaAlistamientoMaterial.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComescuamaAlistamientoMaterial.xlsx");
        }
    }
}

