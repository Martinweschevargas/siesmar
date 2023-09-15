using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dincydet;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dincydet;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dincydet;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Atp;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Data;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{
    public class DincydetArchivoPersonalCTecnologiaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoPersonalCienciaTecnologia archivoPersonalCienciaTecnologiaBL = new();
        FormacionAcademica formacionAcademicaBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        TituloProfesionalObtenido tituloProfesionalObtenidoBL = new();
        AreaCT areaCTBL = new();
        Carga cargaBL = new();

        public DincydetArchivoPersonalCTecnologiaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo para Personal en Ciencia y Tecnología", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<FormacionAcademicaDTO> formacionAcademicaDTO = formacionAcademicaBL.ObtenerFormacionAcademicas();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<TituloProfesionalObtenidoDTO> tituloProfesionalObtenidoDTO = tituloProfesionalObtenidoBL.ObtenerTituloProfesionalObtenidos();
            List<AreaCTDTO> areaCTDTO = areaCTBL.ObtenerAreaCTs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoPersonalCienciaTecnologia");
            return Json(new { data1 = formacionAcademicaDTO, data2 = gradoPersonalMilitarDTO, data3 = tituloProfesionalObtenidoDTO, data4 = areaCTDTO, data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoPersonalCienciaTecnologiaDTO> select = archivoPersonalCienciaTecnologiaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//registrar
        public ActionResult Insertar(string DNIPersonalCT, int AniosTrabajoPersonalCT, string SexoPersonalCT, string CodigoFormacionAcademica,
            string CodigoGradoPersonalMilitar, string CodigoTituloProfesionalObtenido, string NaturalezaTrabajoPersonalCT, string EspecializacionPersonaCT,
            string CodigoAreaCT, string DedicacionTiempoPersonalCT, string ParticipacionProgramas, int CargaId, string Fecha)
        {
            ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO = new();
            archivoPersonalCienciaTecnologiaDTO.DNIPersonalCT = DNIPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.AniosTrabajoPersonalCT = AniosTrabajoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.SexoPersonalCT = SexoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.CodigoFormacionAcademica = CodigoFormacionAcademica;
            archivoPersonalCienciaTecnologiaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            archivoPersonalCienciaTecnologiaDTO.CodigoTituloProfesionalObtenido = CodigoTituloProfesionalObtenido;
            archivoPersonalCienciaTecnologiaDTO.NaturalezaTrabajoPersonalCT = NaturalezaTrabajoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.EspecializacionPersonaCT = EspecializacionPersonaCT;
            archivoPersonalCienciaTecnologiaDTO.CodigoAreaCT = CodigoAreaCT;
            archivoPersonalCienciaTecnologiaDTO.DedicacionTiempoPersonalCT = DedicacionTiempoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.ParticipacionProgramas = ParticipacionProgramas;
            archivoPersonalCienciaTecnologiaDTO.CargaId = CargaId;
            archivoPersonalCienciaTecnologiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoPersonalCienciaTecnologiaBL.AgregarRegistro(archivoPersonalCienciaTecnologiaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoPersonalCienciaTecnologiaBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DNIPersonalCT, int AniosTrabajoPersonalCT, string SexoPersonalCT, string CodigoFormacionAcademica,
            string CodigoGradoPersonalMilitar, string CodigoTituloProfesionalObtenido, string NaturalezaTrabajoPersonalCT, string EspecializacionPersonaCT,
            string CodigoAreaCT, string DedicacionTiempoPersonalCT, string ParticipacionProgramas)
        {

            ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO = new();
            archivoPersonalCienciaTecnologiaDTO.ArchivoPersonalCienciaTecnologiaId = Id;
            archivoPersonalCienciaTecnologiaDTO.DNIPersonalCT = DNIPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.AniosTrabajoPersonalCT = AniosTrabajoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.SexoPersonalCT = SexoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.CodigoFormacionAcademica = CodigoFormacionAcademica;
            archivoPersonalCienciaTecnologiaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            archivoPersonalCienciaTecnologiaDTO.CodigoTituloProfesionalObtenido = CodigoTituloProfesionalObtenido;
            archivoPersonalCienciaTecnologiaDTO.NaturalezaTrabajoPersonalCT = NaturalezaTrabajoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.EspecializacionPersonaCT = EspecializacionPersonaCT;
            archivoPersonalCienciaTecnologiaDTO.CodigoAreaCT = CodigoAreaCT;
            archivoPersonalCienciaTecnologiaDTO.DedicacionTiempoPersonalCT = DedicacionTiempoPersonalCT;
            archivoPersonalCienciaTecnologiaDTO.ParticipacionProgramas = ParticipacionProgramas;
            archivoPersonalCienciaTecnologiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoPersonalCienciaTecnologiaBL.ActualizarFormato(archivoPersonalCienciaTecnologiaDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO = new();
            archivoPersonalCienciaTecnologiaDTO.ArchivoPersonalCienciaTecnologiaId = Id;
            archivoPersonalCienciaTecnologiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (archivoPersonalCienciaTecnologiaBL.EliminarFormato(archivoPersonalCienciaTecnologiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoPersonalCienciaTecnologiaDTO archivoPersonalCienciaTecnologiaDTO = new();
            archivoPersonalCienciaTecnologiaDTO.CargaId = Id;
            archivoPersonalCienciaTecnologiaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoPersonalCienciaTecnologiaBL.EliminarCarga(archivoPersonalCienciaTecnologiaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoPersonalCienciaTecnologiaDTO> lista = new List<ArchivoPersonalCienciaTecnologiaDTO>();
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

                    lista.Add(new ArchivoPersonalCienciaTecnologiaDTO
                    {
                        DNIPersonalCT = fila.GetCell(0).ToString(),
                        AniosTrabajoPersonalCT = int.Parse(fila.GetCell(1).ToString()),
                        SexoPersonalCT = fila.GetCell(2).ToString(),
                        CodigoFormacionAcademica = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        CodigoTituloProfesionalObtenido = fila.GetCell(5).ToString(),
                        NaturalezaTrabajoPersonalCT = fila.GetCell(6).ToString(),
                        EspecializacionPersonaCT = fila.GetCell(7).ToString(),
                        CodigoAreaCT = fila.GetCell(8).ToString(),
                        DedicacionTiempoPersonalCT = fila.GetCell(9).ToString(),
                        ParticipacionProgramas = fila.GetCell(10).ToString()

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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
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
                    new DataColumn("DNIPersonalCT", typeof(string)),
                    new DataColumn("AniosTrabajoPersonalCT", typeof(int)),
                    new DataColumn("SexoPersonalCT", typeof(string)),
                    new DataColumn("CodigoFormacionAcademica", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoTituloProfesionalObtenido", typeof(string)),
                    new DataColumn("NaturalezaTrabajoPersonalCT", typeof(string)),
                    new DataColumn("EspecializacionPersonaCT", typeof(string)),
                    new DataColumn("CodigoAreaCT", typeof(string)),
                    new DataColumn("DedicacionTiempoPersonalCT", typeof(string)),
                    new DataColumn("ParticipacionProgramas", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    int.Parse(fila.GetCell(1).ToString()),
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
            var IND_OPERACION = archivoPersonalCienciaTecnologiaBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }
        public IActionResult ReporteAPCT(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dincydet\\ArchivoPersonalCTecnologia.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var archivoPersonalCTecnologia = archivoPersonalCienciaTecnologiaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ArchivoPersonalCTecnologia", archivoPersonalCTecnologia);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DincydetArchivoPersonalCTecnologia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DincydetArchivoPersonalCTecnologia.xlsx");
        }
    }

}