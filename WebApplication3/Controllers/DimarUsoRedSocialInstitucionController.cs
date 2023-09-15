using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dimar;
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

    public class DimarUsoRedSocialInstitucionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        UsoRedSocialInstitucion usoRedSocialInstitucionBL = new();
        RedSocial redSocialBL = new();
        PublicoObjetivo publicObjetivoBL = new();
        Carga cargaBL = new();

        public DimarUsoRedSocialInstitucionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Uso de Redes Sociales de la Institución", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<RedSocialDTO> redSocialDTO = redSocialBL.ObtenerRedSocials();
            List<PublicoObjetivoDTO> publicoObjetivoDTO = publicObjetivoBL.ObtenerPublicoObjetivos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("UsoRedSocialInstitucion");

            return Json(new
            {
                data1 = redSocialDTO,
                data2 = publicoObjetivoDTO,
                data3 = listaCargas,
            });
        }

        public IActionResult CargaTabla()
        {
            List<UsoRedSocialInstitucionDTO> select = usoRedSocialInstitucionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoRedSocial, string FechaEmision, int NumeroSeguidores, int IncrementoSeguidores,
            string TemaMasComentado, string CodigoPublicoObjetivo, int NumeroPublicaciones, int TotalSeguidoresCreacion, int CargaId)
        {
            UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO = new();
            usoRedSocialInstitucionDTO.CodigoRedSocial = CodigoRedSocial;
            usoRedSocialInstitucionDTO.FechaEmision = FechaEmision;
            usoRedSocialInstitucionDTO.NumeroSeguidores = NumeroSeguidores;
            usoRedSocialInstitucionDTO.IncrementoSeguidores = IncrementoSeguidores;
            usoRedSocialInstitucionDTO.TemaMasComentado = TemaMasComentado;
            usoRedSocialInstitucionDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            usoRedSocialInstitucionDTO.NumeroPublicaciones = NumeroPublicaciones;
            usoRedSocialInstitucionDTO.TotalSeguidoresCreacion = TotalSeguidoresCreacion;
            usoRedSocialInstitucionDTO.CargaId = CargaId;
            usoRedSocialInstitucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usoRedSocialInstitucionBL.AgregarRegistro(usoRedSocialInstitucionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(usoRedSocialInstitucionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoRedSocial, string FechaEmision, int NumeroSeguidores, int IncrementoSeguidores,
            string TemaMasComentado, string CodigoPublicoObjetivo, int NumeroPublicaciones, int TotalSeguidoresCreacion)
        {
            UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO = new();
            usoRedSocialInstitucionDTO.UsoRedSocialInstitucionId = Id;
            usoRedSocialInstitucionDTO.CodigoRedSocial = CodigoRedSocial;
            usoRedSocialInstitucionDTO.FechaEmision = FechaEmision;
            usoRedSocialInstitucionDTO.NumeroSeguidores = NumeroSeguidores;
            usoRedSocialInstitucionDTO.IncrementoSeguidores = IncrementoSeguidores;
            usoRedSocialInstitucionDTO.TemaMasComentado = TemaMasComentado;
            usoRedSocialInstitucionDTO.CodigoPublicoObjetivo = CodigoPublicoObjetivo;
            usoRedSocialInstitucionDTO.NumeroPublicaciones = NumeroPublicaciones;
            usoRedSocialInstitucionDTO.TotalSeguidoresCreacion = TotalSeguidoresCreacion;

            usoRedSocialInstitucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = usoRedSocialInstitucionBL.ActualizarFormato(usoRedSocialInstitucionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            UsoRedSocialInstitucionDTO usoRedSocialInstitucionDTO = new();
            usoRedSocialInstitucionDTO.UsoRedSocialInstitucionId = Id;
            usoRedSocialInstitucionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (usoRedSocialInstitucionBL.EliminarFormato(usoRedSocialInstitucionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<UsoRedSocialInstitucionDTO> lista = new List<UsoRedSocialInstitucionDTO>();
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

                    lista.Add(new UsoRedSocialInstitucionDTO
                    {
                        CodigoRedSocial = fila.GetCell(0).ToString(),
                        FechaEmision = fila.GetCell(1).ToString(),
                        NumeroSeguidores = int.Parse(fila.GetCell(2).ToString()),
                        IncrementoSeguidores = int.Parse(fila.GetCell(3).ToString()),
                        TemaMasComentado = fila.GetCell(4).ToString(),
                        CodigoPublicoObjetivo = fila.GetCell(5).ToString(),
                        NumeroPublicaciones = int.Parse(fila.GetCell(6).ToString()),
                        TotalSeguidoresCreacion = int.Parse(fila.GetCell(7).ToString()),

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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("CodigoRedSocial", typeof(string)),
                    new DataColumn("FechaEmision ", typeof(string)),
                    new DataColumn("NumeroSeguidores", typeof(int)),
                    new DataColumn("IncrementoSeguidores ", typeof(int)),
                    new DataColumn("TemaMasComentado ", typeof(string)),
                    new DataColumn("CodigoPublicoObjetivo ", typeof(string)),
                    new DataColumn("NumeroPublicaciones ", typeof(int)),
                    new DataColumn("TotalSeguidoresCreacion ", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                    fila.GetCell(0).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    int.Parse(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),


                    User.obtenerUsuario());
            }
            var IND_OPERACION = usoRedSocialInstitucionBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDURSI(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dimar\\UsoRedSocialInstitucion.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = usoRedSocialInstitucionBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("UsoRedSocialInstitucion", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\UsoRedSocialInstitucion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "UsoRedSocialInstitucion.xlsx");
        }
    }

}



