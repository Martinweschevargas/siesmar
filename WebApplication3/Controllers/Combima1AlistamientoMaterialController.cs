using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Combima1;
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
    public class Combima1AlistamientoMaterialController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoMaterialCombima1 alistamientoMaterialCombima1BL = new();
        UnidadNaval unidadNavalBL = new();
        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();
        Carga cargaBL = new();

        public Combima1AlistamientoMaterialController(IWebHostEnvironment webHostEnvironment)
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
            List<AlistamientoMaterialRequerido3NDTO> alistamientoMaterialRequerido3NDTO = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialCombima1");

            return Json(new
            {
                data1 = unidadNavalDTO,
                data2 = alistamientoMaterialRequerido3NDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMaterialCombima1DTO> select = alistamientoMaterialCombima1BL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CapacidadOperativa, string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo, int Existencia,
             decimal PorcentajeOperatividad, decimal PonderadoFuncional, decimal NivelAlistamientoParcial, int CargaId, string Fecha)
        {
            AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO = new();
            alistamientoMaterialCombima1DTO.CapacidadOperativa = CapacidadOperativa;
            alistamientoMaterialCombima1DTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialCombima1DTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialCombima1DTO.Requerido = Requerido;
            alistamientoMaterialCombima1DTO.Operativo = Operativo;
            alistamientoMaterialCombima1DTO.Existencia = Existencia;
            alistamientoMaterialCombima1DTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialCombima1DTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialCombima1DTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialCombima1DTO.CargaId = CargaId;
            alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialCombima1BL.AgregarRegistro(alistamientoMaterialCombima1DTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialCombima1BL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CapacidadOperativa, string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo, int Existencia,
             decimal PorcentajeOperatividad, decimal PonderadoFuncional, decimal NivelAlistamientoParcial)
        {
            AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO = new();
            alistamientoMaterialCombima1DTO.AlistamientoMaterialId = Id;
            alistamientoMaterialCombima1DTO.CapacidadOperativa = CapacidadOperativa;
            alistamientoMaterialCombima1DTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialCombima1DTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialCombima1DTO.Requerido = Requerido;
            alistamientoMaterialCombima1DTO.Operativo = Operativo;
            alistamientoMaterialCombima1DTO.Existencia = Existencia;
            alistamientoMaterialCombima1DTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialCombima1DTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialCombima1DTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialCombima1BL.ActualizarFormato(alistamientoMaterialCombima1DTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO = new();
            alistamientoMaterialCombima1DTO.AlistamientoMaterialId = Id;
            alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialCombima1BL.EliminarFormato(alistamientoMaterialCombima1DTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialCombima1DTO alistamientoMaterialCombima1DTO = new();
            alistamientoMaterialCombima1DTO.CargaId = Id;
            alistamientoMaterialCombima1DTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMaterialCombima1BL.EliminarCarga(alistamientoMaterialCombima1DTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMaterialCombima1DTO> lista = new List<AlistamientoMaterialCombima1DTO>();
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

                    lista.Add(new AlistamientoMaterialCombima1DTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(2).ToString(),
                        Requerido = int.Parse(fila.GetCell(3).ToString()),
                        Existencia = int.Parse(fila.GetCell(4).ToString()),
                        Operativo = int.Parse(fila.GetCell(5).ToString()),
                        PorcentajeOperatividad = decimal.Parse(fila.GetCell(6).ToString()),
                        PonderadoFuncional = decimal.Parse(fila.GetCell(7).ToString()),
                        NivelAlistamientoParcial = decimal.Parse(fila.GetCell(8).ToString())
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido3N", typeof(string)),
                    new DataColumn("Requerido", typeof(string)),
                    new DataColumn("Existencia", typeof(string)),
                    new DataColumn("Operativo", typeof(string)),
                    new DataColumn("PorcentajeOperatividad", typeof(string)),
                    new DataColumn("PonderadoFuncional", typeof(string)),
                    new DataColumn("NivelAlistamientoParcial", typeof(string)),
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
                    int.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    decimal.Parse(fila.GetCell(8).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoMaterialCombima1BL.InsertarDatos(dt, Fecha);
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

        //public IActionResult ReporteEIHN()
        //{
        //    //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
        //    string mimtype = "";
        //    //int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    var estudioInvestigacionesHistoricasNavales = alistamientoMaterialCombima1BL.ObtenerLista();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
        //    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\Combima1AlistamientoMaterial.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "Combima1AlistamientoMaterial.xlsx");
        }

    }

}

