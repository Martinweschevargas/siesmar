using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dipermar;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.ColorSpaces;
using SmartBreadcrumbs.Attributes;
using System.Data;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class DipermarInvestigacionDisciplinariaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        InvestigacionDisciplinaria investigacionDisciplinariaBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        InfraccionDisciplinariaGenerica infraccionDisciplinariaGenericaBL = new();
        SancionDisciplinariaNaval sancionDisciplinariaNavalBL = new();
        InfraccionDisciplinariaEspecifica infraccionDisciplinariaEspecifica = new();
        Carga cargaBL = new();

        public DipermarInvestigacionDisciplinariaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Investigación Disciplinarias (PERSUPE-PERSUBA)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<InfraccionDisciplinariaGenericaDTO> infraccionDisciplinariaGenericaDTO = infraccionDisciplinariaGenericaBL.ObtenerInfraccionDisciplinariaGenericas();
            List<SancionDisciplinariaNavalDTO> sancionDisciplinariaNavalDTO = sancionDisciplinariaNavalBL.ObtenerSancionDisciplinariaNavals();
            List<InfraccionDisciplinariaEspecificaDTO>  InfraccionDisciplinariaEspecifica = infraccionDisciplinariaEspecifica.ObtenerInfraccionDisciplinariaEspecificas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InvestigacionDisciplinaria");
            return Json(new { data1 = gradoPersonalMilitarDTO, data2 = infraccionDisciplinariaGenericaDTO,  data3 = sancionDisciplinariaNavalDTO, data4= InfraccionDisciplinariaEspecifica,
                data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<InvestigacionDisciplinariaDTO> select = investigacionDisciplinariaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 624, Permiso: 1)]//Registrar
        public ActionResult Insertar(string FechaInicioInvestigacion, string CodigoGradoPersonalMilitar, string SexoPersonal, string CodigoInfraccionDisciplinariaGenerica,
           string CodigoInfraccionDisciplinariaEspecifica, string NivelInfraccion, string CodigoGradoPresidenteJunta, string NombrePresidenteJunta,
           string ConclusionFinal, string ConclusionFinalDescripcion, string CodigoSancionDisciplinariaNaval, int CargaId, string Fecha)
        {
            InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO = new();
            investigacionDisciplinariaDTO.FechaInicioInvestigacion = FechaInicioInvestigacion;
            investigacionDisciplinariaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            investigacionDisciplinariaDTO.SexoPersonal = SexoPersonal;
            investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaGenerica = CodigoInfraccionDisciplinariaGenerica;
            investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaEspecifica = CodigoInfraccionDisciplinariaEspecifica;
            investigacionDisciplinariaDTO.NivelInfraccion = NivelInfraccion;
            investigacionDisciplinariaDTO.CodigoGradoPresidenteJunta = CodigoGradoPresidenteJunta;
            investigacionDisciplinariaDTO.NombrePresidenteJunta = NombrePresidenteJunta;
            investigacionDisciplinariaDTO.ConclusionFinal = ConclusionFinal;
            investigacionDisciplinariaDTO.ConclusionFinalDescripcion = ConclusionFinalDescripcion;
            investigacionDisciplinariaDTO.CodigoSancionDisciplinariaNaval = CodigoSancionDisciplinariaNaval;
            investigacionDisciplinariaDTO.CargaId = CargaId;
            investigacionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = investigacionDisciplinariaBL.AgregarRegistro(investigacionDisciplinariaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(investigacionDisciplinariaBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 624, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string FechaInicioInvestigacion, string CodigoGradoPersonalMilitar, string SexoPersonal, string CodigoInfraccionDisciplinariaGenerica,
           string CodigoInfraccionDisciplinariaEspecifica, string NivelInfraccion, string CodigoGradoPresidenteJunta, string NombrePresidenteJunta,
           string ConclusionFinal, string ConclusionFinalDescripcion, string CodigoSancionDisciplinariaNaval)
        {
            InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO = new();
            investigacionDisciplinariaDTO.InvestigacionDisciplinariaId = Id;
            investigacionDisciplinariaDTO.FechaInicioInvestigacion = FechaInicioInvestigacion;
            investigacionDisciplinariaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            investigacionDisciplinariaDTO.SexoPersonal = SexoPersonal;
            investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaGenerica = CodigoInfraccionDisciplinariaGenerica;
            investigacionDisciplinariaDTO.CodigoInfraccionDisciplinariaEspecifica = CodigoInfraccionDisciplinariaEspecifica;
            investigacionDisciplinariaDTO.NivelInfraccion = NivelInfraccion;
            investigacionDisciplinariaDTO.CodigoGradoPresidenteJunta = CodigoGradoPresidenteJunta;
            investigacionDisciplinariaDTO.NombrePresidenteJunta = NombrePresidenteJunta;
            investigacionDisciplinariaDTO.ConclusionFinal = ConclusionFinal;
            investigacionDisciplinariaDTO.ConclusionFinalDescripcion = ConclusionFinalDescripcion;
            investigacionDisciplinariaDTO.CodigoSancionDisciplinariaNaval = CodigoSancionDisciplinariaNaval;
            investigacionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = investigacionDisciplinariaBL.ActualizarFormato(investigacionDisciplinariaDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 624, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO = new();
            investigacionDisciplinariaDTO.InvestigacionDisciplinariaId = Id;
            investigacionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (investigacionDisciplinariaBL.EliminarFormato(investigacionDisciplinariaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 624, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO = new();
            investigacionDisciplinariaDTO.CargaId = Id;
            investigacionDisciplinariaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (investigacionDisciplinariaBL.EliminarCarga(investigacionDisciplinariaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InvestigacionDisciplinariaDTO> lista = new List<InvestigacionDisciplinariaDTO>();
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

                    lista.Add(new InvestigacionDisciplinariaDTO
                    {
                        FechaInicioInvestigacion = fila.GetCell(0).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(1).ToString(),
                        SexoPersonal = fila.GetCell(2).ToString(),
                        CodigoInfraccionDisciplinariaGenerica = fila.GetCell(3).ToString(),
                        CodigoInfraccionDisciplinariaEspecifica = fila.GetCell(4).ToString(),
                        NivelInfraccion = fila.GetCell(5).ToString(),
                        CodigoGradoPresidenteJunta = fila.GetCell(6).ToString(),
                        NombrePresidenteJunta = fila.GetCell(7).ToString(),
                        ConclusionFinal = fila.GetCell(8).ToString(),
                        ConclusionFinalDescripcion = fila.GetCell(9).ToString(),
                        CodigoSancionDisciplinariaNaval = fila.GetCell(10).ToString()

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
        //[AuthorizePermission(Formato: 624, Permiso: 4)]//Registrar Masivo

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
                    new DataColumn("FechaInicioInvestigacion", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SexoPersonal", typeof(string)),
                    new DataColumn("CodigoInfraccionDisciplinariaGenerica", typeof(string)),
                    new DataColumn("CodigoInfraccionDisciplinariaEspecifica", typeof(string)),
                    new DataColumn("NivelInfraccion", typeof(string)),
                    new DataColumn("CodigoGradoPresidenteJunta", typeof(string)),
                    new DataColumn("NombrePresidenteJunta", typeof(string)),
                    new DataColumn("ConclusionFinal", typeof(string)),
                    new DataColumn("ConclusionFinalDescripcion", typeof(string)),
                    new DataColumn("CodigoSancionDisciplinariaNaval", typeof(string)),
 
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
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = investigacionDisciplinariaBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteID(int? CargaId = null)
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dipermar\\InvestigacionDisciplinaria.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var investigacionDisciplinaria = investigacionDisciplinariaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("InvestigacionDisciplinaria", investigacionDisciplinaria);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DipermarInvestigacionDisciplinaria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DipermarInvestigacionDisciplinaria.xlsx");
        }

    }

}

