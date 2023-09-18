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

    public class ComzounoAlistamientoMaterialComzounoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoMaterialComzouno alistamientoMaterialComzounoBL = new();
        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();
        Carga cargaBL = new();

        public ComzounoAlistamientoMaterialComzounoController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialComzouno");

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
            List<AlistamientoMaterialComzounoDTO> select = alistamientoMaterialComzounoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoCapacidadOperativa, string CodigoAlistamientoMaterialRequerido3N, 
            int Requerido, int Operativo, decimal PorcentajeOperativo, decimal PonderadoFuncional,
            decimal NivelAlistamientoParcial, int CargaId, string Fecha)
        {
            AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO = new();
            alistamientoMaterialComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComzounoDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComzounoDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComzounoDTO.Requerido = Requerido;
            alistamientoMaterialComzounoDTO.Operativo = Operativo;
            alistamientoMaterialComzounoDTO.PorcentajeOperatividad = PorcentajeOperativo;
            alistamientoMaterialComzounoDTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialComzounoDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComzounoDTO.CargaId = CargaId;
            alistamientoMaterialComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComzounoBL.AgregarRegistro(alistamientoMaterialComzounoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialComzounoBL.EditarFormado(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoCapacidadOperativa, string CodigoAlistamientoMaterialRequerido3N,
            int Requerido, int Operativo, decimal PorcentajeOperativo, decimal PonderadoFuncional,
            decimal NivelAlistamientoParcial)
        { 
            AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO = new();
            alistamientoMaterialComzounoDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComzounoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComzounoDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComzounoDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComzounoDTO.Requerido = Requerido;
            alistamientoMaterialComzounoDTO.Operativo = Operativo;
            alistamientoMaterialComzounoDTO.PorcentajeOperatividad = PorcentajeOperativo;
            alistamientoMaterialComzounoDTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialComzounoDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;

            alistamientoMaterialComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComzounoBL.ActualizarFormato(alistamientoMaterialComzounoDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO = new();
            alistamientoMaterialComzounoDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialComzounoBL.EliminarFormato(alistamientoMaterialComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComzounoDTO alistamientoMaterialComzounoDTO = new();
            alistamientoMaterialComzounoDTO.CargaId = Id;
            alistamientoMaterialComzounoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMaterialComzounoBL.EliminarCarga(alistamientoMaterialComzounoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMaterialComzounoDTO> lista = new List<AlistamientoMaterialComzounoDTO>();
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

                    lista.Add(new AlistamientoMaterialComzounoDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(2).ToString(),
                        Requerido = int.Parse(fila.GetCell(3).ToString()),
                        Operativo = int.Parse(fila.GetCell(4).ToString()),
                        PorcentajeOperatividad = decimal.Parse(fila.GetCell(5).ToString()),
                        PonderadoFuncional = decimal.Parse(fila.GetCell(6).ToString()),
                        NivelAlistamientoParcial = decimal.Parse(fila.GetCell(7).ToString())
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido3N", typeof(string)),
                    new DataColumn("Requerido", typeof(int)),
                    new DataColumn("Operativo", typeof(int)),
                    new DataColumn("PorcentajeOperatividad", typeof(decimal)),
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
                    int.Parse(fila.GetCell(3).ToString()),
                    int.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    decimal.Parse(fila.GetCell(7).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistamientoMaterialComzounoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzounoAlistamientoMaterialComzouno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzounoAlistamientoMaterialComzouno.xlsx");
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistamientoMaterialComzounoBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

    }

}

