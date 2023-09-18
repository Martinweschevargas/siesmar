using AspNetCore.Reporting;

using Marina.Siesmar.Entidades.Formatos.Iafas;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Iafas;
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
    public class IafasPersonalAfiliadoProgramaSaludController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        PersonalAfiliadoProgramaSalud personalAfiliadoProgramaSaludBL = new();

        SituacionPersonalNaval situacionPersonalNavalBL = new();
        ParentescoAfiliado parentescoAfiliadoBL = new();
        TipoAfiliacion tipoAfiliacionBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        ZonaNaval zonaNavalBL = new();
        FormaContactoAfiliado formaContactoAfiliadoBL = new();
        Carga cargaBL = new();
        public IafasPersonalAfiliadoProgramaSaludController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Personal Afiliado a los Programas de Salud Basico, Oncológico y Segunda Capa", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<SituacionPersonalNavalDTO> situacionPersonalNavalDTO = situacionPersonalNavalBL.ObtenerSituacionPersonalNavals();
            List<ParentescoAfiliadoDTO> parentescoAfiliadoDTO = parentescoAfiliadoBL.ObtenerParentescoAfiliados();
            List<TipoAfiliacionDTO> tipoAfiliacionDTO = tipoAfiliacionBL.ObtenerTipoAfiliacions();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<ZonaNavalDTO> zonaNavalDTO = zonaNavalBL.ObtenerZonaNavals();
            List<FormaContactoAfiliadoDTO> formaContactoAfiliadoDTO = formaContactoAfiliadoBL.ObtenerFormaContactoAfiliados();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PersonalAfiliadoProgramaSalud");


            return Json(new
            {
                data1 = situacionPersonalNavalDTO,
                data2 = parentescoAfiliadoDTO,
                data3 = tipoAfiliacionDTO,
                data4 = distritoUbigeoDTO,
                data5 = provinciaUbigeoDTO,
                data6 = zonaNavalDTO,
                data7 = formaContactoAfiliadoDTO,
                data8 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<PersonalAfiliadoProgramaSaludDTO> personalAfiliadoProgramaSaludDTO = personalAfiliadoProgramaSaludBL.ObtenerLista();
            return Json(new { data = personalAfiliadoProgramaSaludDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual() 
        {
            return View();
        }


        public ActionResult Insertar( string SexoPersonalAfiliado, string DocumentoAfiliado, string CodigoSituacionPersonalNaval,
            string CodigoParentescoAfiliado, string FechaAfiliacion, string FechaDesafiliacion, string MantieneAfiliado, string MotivoDesafiliacion, string DistritoUbigeo,
            string CodigoTipoAfiliacion, string CodigoZonaNaval, string CodigoFormaContactoAfiliado, string ActivacionSeguroOncologico, string ActivacionSeguroSegundaCapa,
            int CargaId)
        {
            PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO = new();
            personalAfiliadoProgramaSaludDTO.DocumentoAfiliado = DocumentoAfiliado;
            personalAfiliadoProgramaSaludDTO.SexoPersonalAfiliado = SexoPersonalAfiliado;
            personalAfiliadoProgramaSaludDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            personalAfiliadoProgramaSaludDTO.FechaAfiliacion = FechaAfiliacion;
            personalAfiliadoProgramaSaludDTO.CodigoParentescoAfiliado = CodigoParentescoAfiliado;
            personalAfiliadoProgramaSaludDTO.CodigoTipoAfiliacion = CodigoTipoAfiliacion;
            personalAfiliadoProgramaSaludDTO.DistritoUbigeo = DistritoUbigeo;
            personalAfiliadoProgramaSaludDTO.CodigoZonaNaval = CodigoZonaNaval;
            personalAfiliadoProgramaSaludDTO.MantieneAfiliado = MantieneAfiliado;
            personalAfiliadoProgramaSaludDTO.FechaDesafiliacion = FechaDesafiliacion;
            personalAfiliadoProgramaSaludDTO.MotivoDesafiliacion = MotivoDesafiliacion;
            personalAfiliadoProgramaSaludDTO.CodigoFormaContactoAfiliado = CodigoFormaContactoAfiliado;
            personalAfiliadoProgramaSaludDTO.ActivacionSeguroOncologico = ActivacionSeguroOncologico;
            personalAfiliadoProgramaSaludDTO.ActivacionSeguroSegundaCapa = ActivacionSeguroSegundaCapa;
            personalAfiliadoProgramaSaludDTO.CargaId = CargaId;
            personalAfiliadoProgramaSaludDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalAfiliadoProgramaSaludBL.AgregarRegistro(personalAfiliadoProgramaSaludDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(personalAfiliadoProgramaSaludBL.BuscarFormato(Id));
        }


        public ActionResult Actualizar(int PersonalAfiliadoProgramaSaludId, string SexoPersonalAfiliado, string DocumentoAfiliado, string CodigoSituacionPersonalNaval,
            string CodigoParentescoAfiliado, string FechaAfiliacion, string FechaDesafiliacion, string MantieneAfiliado, string MotivoDesafiliacion, string DistritoUbigeo,
            string CodigoTipoAfiliacion, string CodigoZonaNaval, string CodigoFormaContactoAfiliado, string ActivacionSeguroOncologico, string ActivacionSeguroSegundaCapa)
        {
            PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO = new();
            personalAfiliadoProgramaSaludDTO.PersonalAfiliadoProgramaSaludId = PersonalAfiliadoProgramaSaludId;
            personalAfiliadoProgramaSaludDTO.DocumentoAfiliado = DocumentoAfiliado;
            personalAfiliadoProgramaSaludDTO.SexoPersonalAfiliado = SexoPersonalAfiliado;
            personalAfiliadoProgramaSaludDTO.CodigoSituacionPersonalNaval = CodigoSituacionPersonalNaval;
            personalAfiliadoProgramaSaludDTO.FechaAfiliacion = FechaAfiliacion;
            personalAfiliadoProgramaSaludDTO.CodigoParentescoAfiliado = CodigoParentescoAfiliado;
            personalAfiliadoProgramaSaludDTO.CodigoTipoAfiliacion = CodigoTipoAfiliacion;
            personalAfiliadoProgramaSaludDTO.DistritoUbigeo = DistritoUbigeo;
            personalAfiliadoProgramaSaludDTO.CodigoZonaNaval = CodigoZonaNaval;
            personalAfiliadoProgramaSaludDTO.MantieneAfiliado = MantieneAfiliado;
            personalAfiliadoProgramaSaludDTO.FechaDesafiliacion = FechaDesafiliacion;
            personalAfiliadoProgramaSaludDTO.MotivoDesafiliacion = MotivoDesafiliacion;
            personalAfiliadoProgramaSaludDTO.CodigoFormaContactoAfiliado = CodigoFormaContactoAfiliado;
            personalAfiliadoProgramaSaludDTO.ActivacionSeguroOncologico = ActivacionSeguroOncologico;
            personalAfiliadoProgramaSaludDTO.ActivacionSeguroSegundaCapa = ActivacionSeguroSegundaCapa;
            personalAfiliadoProgramaSaludDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalAfiliadoProgramaSaludBL.ActualizarFormato(personalAfiliadoProgramaSaludDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PersonalAfiliadoProgramaSaludDTO personalAfiliadoProgramaSaludDTO = new();
            personalAfiliadoProgramaSaludDTO.PersonalAfiliadoProgramaSaludId = Id;
            personalAfiliadoProgramaSaludDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (personalAfiliadoProgramaSaludBL.EliminarFormato(personalAfiliadoProgramaSaludDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PersonalAfiliadoProgramaSaludDTO> lista = new List<PersonalAfiliadoProgramaSaludDTO>();
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

                    lista.Add(new PersonalAfiliadoProgramaSaludDTO
                    {
                        DocumentoAfiliado = fila.GetCell(0).ToString(),
                        SexoPersonalAfiliado = fila.GetCell(1).ToString(),
                        CodigoSituacionPersonalNaval = fila.GetCell(2).ToString(),
                        FechaAfiliacion = fila.GetCell(3).ToString(),
                        CodigoParentescoAfiliado = fila.GetCell(4).ToString(),
                        CodigoTipoAfiliacion = fila.GetCell(5).ToString(),
                        DistritoUbigeo = fila.GetCell(6).ToString(),
                        CodigoZonaNaval = fila.GetCell(7).ToString(),
                        MantieneAfiliado = fila.GetCell(8).ToString(),
                        FechaDesafiliacion = fila.GetCell(9).ToString(),
                        MotivoDesafiliacion = fila.GetCell(10).ToString(),
                        CodigoFormaContactoAfiliado = fila.GetCell(11).ToString(),
                        ActivacionSeguroOncologico = fila.GetCell(12).ToString(),
                        ActivacionSeguroSegundaCapa = fila.GetCell(13).ToString()
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("DocumentoAfiliado", typeof(string)),
                    new DataColumn("SexoPersonalAfiliado", typeof(string)),
                    new DataColumn("CodigoSituacionPersonalNaval", typeof(string)),
                    new DataColumn("FechaAfiliacion ", typeof(string)),
                    new DataColumn("CodigoParentescoAfiliado", typeof(string)),
                    new DataColumn("CodigoTipoAfiliacion", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoZonaNaval", typeof(string)),
                    new DataColumn("MantieneAfiliado", typeof(string)),
                    new DataColumn("FechaDesafiliacion", typeof(string)),
                    new DataColumn("MotivoDesafiliacion", typeof(string)),
                    new DataColumn("CodigoFormaContactoAfiliado", typeof(string)),
                    new DataColumn("ActivacionSeguroOncologico", typeof(string)),
                    new DataColumn("ActivacionSeguroSegundaCapa", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(9).ToString()),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = personalAfiliadoProgramaSaludBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteIPAPS(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Iafas\\IafasPersonalAfiliadoProgramaSalud.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = personalAfiliadoProgramaSaludBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ComescuamaEvaluacionAlistEntrenamiento", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IafasPersonalAfiliadoProgramaSalud.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IafasPersonalAfiliadoProgramaSalud.xlsx");
        }
    }

}