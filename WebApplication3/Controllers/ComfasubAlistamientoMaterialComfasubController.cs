using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comfasub;
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

    public class ComfasubAlistamientoMaterialComfasubController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoMaterialComfasub alistamientoMaterialComfasubBL = new();
        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();
        Carga cargaBL = new();

        public ComfasubAlistamientoMaterialComfasubController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de material", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {

            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<AlistamientoMaterialRequerido3NDTO> alistamientoMaterialRequerido3NDTO = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialComfasub");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = capacidadOperativaDTO,
                data3 = alistamientoMaterialRequerido3NDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMaterialComfasubDTO> select = alistamientoMaterialComfasubBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string FechaAlistamiento, string CodigoCapacidadOperativa, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo, decimal PorcentajeOperativo, int CargaId, string Fecha)
        {
            AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO = new();
            alistamientoMaterialComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComfasubDTO.FechaAlistamiento = FechaAlistamiento;
            alistamientoMaterialComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComfasubDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComfasubDTO.Requerido = Requerido;
            alistamientoMaterialComfasubDTO.Operativo = Operativo;
            alistamientoMaterialComfasubDTO.PorcentajeOperatividad = PorcentajeOperativo;
            alistamientoMaterialComfasubDTO.CargaId = CargaId;
            alistamientoMaterialComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            var IND_OPERACION = alistamientoMaterialComfasubBL.AgregarRegistro(alistamientoMaterialComfasubDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialComfasubBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string FechaAlistamiento,  string CodigoCapacidadOperativa, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo, decimal PorcentajeOperativo)
        {
            AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO = new();
            alistamientoMaterialComfasubDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComfasubDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComfasubDTO.FechaAlistamiento = FechaAlistamiento;
            alistamientoMaterialComfasubDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComfasubDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComfasubDTO.Requerido = Requerido;
            alistamientoMaterialComfasubDTO.Operativo = Operativo;
            alistamientoMaterialComfasubDTO.PorcentajeOperatividad = PorcentajeOperativo;

            alistamientoMaterialComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComfasubBL.ActualizarFormato(alistamientoMaterialComfasubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO = new();
            alistamientoMaterialComfasubDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialComfasubBL.EliminarFormato(alistamientoMaterialComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComfasubDTO alistamientoMaterialComfasubDTO = new();
            alistamientoMaterialComfasubDTO.CargaId = Id;
            alistamientoMaterialComfasubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMaterialComfasubBL.EliminarCarga(alistamientoMaterialComfasubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMaterialComfasubDTO> lista = new List<AlistamientoMaterialComfasubDTO>();
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

                    lista.Add(new AlistamientoMaterialComfasubDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        FechaAlistamiento = UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                        CodigoCapacidadOperativa = fila.GetCell(2).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(3).ToString(),
                        Requerido = int.Parse(fila.GetCell(4).ToString()),
                        Operativo = int.Parse(fila.GetCell(5).ToString()),
                        PorcentajeOperatividad = decimal.Parse(fila.GetCell(6).ToString()),

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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("FechaAlistamiento", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido3N", typeof(string)),
                    new DataColumn("Requerido", typeof(int)),
                    new DataColumn("Operativo", typeof(int)),
                    new DataColumn("PorcentajeOperatividad", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoMaterialComfasubBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComfasubAlistamientoMaterialComfasub.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComfasubAlistamientoMaterialComfasub.xlsx");
        }
    }

}

