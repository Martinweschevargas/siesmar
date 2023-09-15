using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dirciten;
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

    public class DircitenEgresoPromocionesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        EgresoPromociones egresoPromocionesBL = new();
        Carga cargaBL = new();


        public DircitenEgresoPromocionesController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Egreso por Promociones", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EgresoPromocionDirciten");

            return Json(new
            {
                data1 = listaCargas,

            });
        }

        public IActionResult CargaTabla()
        {
            List<EgresoPromocionesDTO> select = egresoPromocionesBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIEgresoPromocion, string GeneroEgresoPromocion, string FechaResolIngreso,
           string FechaResolEgreso, int CargaId, string Fecha)
        {
            EgresoPromocionesDTO egresoPromocionesDTO = new();
            egresoPromocionesDTO.DNIEgresoPromocion = DNIEgresoPromocion;
            egresoPromocionesDTO.GeneroEgresoPromocion = GeneroEgresoPromocion;
            egresoPromocionesDTO.FechaResolIngreso = FechaResolIngreso;
            egresoPromocionesDTO.FechaResolEgreso = FechaResolEgreso;
            egresoPromocionesDTO.CargaId = CargaId;
            egresoPromocionesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = egresoPromocionesBL.AgregarRegistro(egresoPromocionesDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(egresoPromocionesBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIEgresoPromocion, string GeneroEgresoPromocion, string FechaResolIngreso,
           string FechaResolEgreso)
        {
            EgresoPromocionesDTO egresoPromocionesDTO = new();
            egresoPromocionesDTO.EgresoPromocionId = Id;
            egresoPromocionesDTO.DNIEgresoPromocion = DNIEgresoPromocion;
            egresoPromocionesDTO.GeneroEgresoPromocion = GeneroEgresoPromocion;
            egresoPromocionesDTO.FechaResolIngreso = FechaResolIngreso;
            egresoPromocionesDTO.FechaResolEgreso = FechaResolEgreso;
            egresoPromocionesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = egresoPromocionesBL.ActualizarFormato(egresoPromocionesDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EgresoPromocionesDTO egresoPromocionesDTO = new();
            egresoPromocionesDTO.EgresoPromocionId = Id;
            egresoPromocionesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (egresoPromocionesBL.EliminarFormato(egresoPromocionesDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }


        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EgresoPromocionesDTO egresoPromocionesDTO = new();
            egresoPromocionesDTO.CargaId = Id;
            egresoPromocionesDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (egresoPromocionesBL.EliminarCarga(egresoPromocionesDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EgresoPromocionesDTO> lista = new List<EgresoPromocionesDTO>();
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

                    lista.Add(new EgresoPromocionesDTO
                    {
                        DNIEgresoPromocion = fila.GetCell(0).ToString(),
                        GeneroEgresoPromocion = fila.GetCell(1).ToString(),
                        FechaResolIngreso = fila.GetCell(2).ToString(),
                        FechaResolEgreso = fila.GetCell(3).ToString(),

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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("DNIEgresoPromocion", typeof(string)),
                    new DataColumn("GeneroEgresoPromocion", typeof(string)),
                    new DataColumn("FechaResolIngreso", typeof(string)),
                    new DataColumn("FechaResolEgreso", typeof(string)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(2).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),


                    User.obtenerUsuario());
            }
            var IND_OPERACION = egresoPromocionesBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDEP(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirciten\\DircitenEgresoPromociones.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = egresoPromocionesBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DircitenEgresoPromociones", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DircitenEgresoPromociones.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DircitenEgresoPromociones.xlsx");
        }

}
}

