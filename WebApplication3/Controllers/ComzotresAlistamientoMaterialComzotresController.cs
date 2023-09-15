using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzotres;
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

    public class ComzotresAlistamientoMaterialComzotresController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistamientoMaterialComzotres alistamientoMaterialComzotresBL = new();
        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();
        Carga cargaBL = new();

        public ComzotresAlistamientoMaterialComzotresController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialComzotres");
            return Json(new {
                data1 = unidadNavalDTO,
                data2 = capacidadOperativaDTO,
                data3 = alistamientoMaterialRequerido3NDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMaterialComzotresDTO> lista = alistamientoMaterialComzotresBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoCapacidadOperativa, 
            string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo, 
            decimal PorcentajeOperatividad, decimal PonderadoFuncional, decimal NivelAlistamientoParcial, 
            int CargaId, string Fecha)
        {
            AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO = new();
            alistamientoMaterialComzotresDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComzotresDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComzotresDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComzotresDTO.Requerido = Requerido;
            alistamientoMaterialComzotresDTO.Operativo = Operativo;
            alistamientoMaterialComzotresDTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialComzotresDTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialComzotresDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComzotresDTO.CargaId = CargaId;
            alistamientoMaterialComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComzotresBL.AgregarRegistro(alistamientoMaterialComzotresDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialComzotresBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoCapacidadOperativa,
            string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo, 
            decimal PorcentajeOperatividad, decimal PonderadoFuncional, decimal NivelAlistamientoParcial)
        { 
            AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO = new();
            alistamientoMaterialComzotresDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComzotresDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComzotresDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComzotresDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComzotresDTO.Requerido = Requerido;
            alistamientoMaterialComzotresDTO.Operativo = Operativo;
            alistamientoMaterialComzotresDTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialComzotresDTO.PonderadoFuncional = PonderadoFuncional;
            alistamientoMaterialComzotresDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComzotresBL.ActualizarFormato(alistamientoMaterialComzotresDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO = new();
            alistamientoMaterialComzotresDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialComzotresBL.EliminarFormato(alistamientoMaterialComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComzotresDTO alistamientoMaterialComzotresDTO = new();
            alistamientoMaterialComzotresDTO.CargaId = Id;
            alistamientoMaterialComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistamientoMaterialComzotresBL.EliminarCarga(alistamientoMaterialComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistamientoMaterialComzotresDTO> lista = new List<AlistamientoMaterialComzotresDTO>();
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

                    lista.Add(new AlistamientoMaterialComzotresDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(2).ToString(),
                        Requerido = int.Parse(fila.GetCell(3).ToString()),
                        Operativo = int.Parse(fila.GetCell(4).ToString()),
                        PorcentajeOperatividad = decimal.Parse(fila.GetCell(5).ToString()),
                        PonderadoFuncional = decimal.Parse(fila.GetCell(6).ToString()),
                        NivelAlistamientoParcial = decimal.Parse(fila.GetCell(7).ToString()),
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
            var IND_OPERACION = alistamientoMaterialComzotresBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzotresAlistamientoMaterialComzotres.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzotresAlistamientoMaterialComzotres.xlsx");
        }
    }
}

