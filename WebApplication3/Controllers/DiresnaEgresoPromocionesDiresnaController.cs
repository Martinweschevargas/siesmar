using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresna;
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

    public class DiresnaEgresoPromocionesDiresnaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EgresoPromocionesDiresna egresoPromocionesDiresnaBL = new();
        Carga cargaBL = new();

        public DiresnaEgresoPromocionesDiresnaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Egreso por Promociones Diresna", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EgresoPromocionDiresna");

            return Json(new
            {
                data1 = listaCargas,
              
            });
        }

        public IActionResult CargaTabla()
        {
            List<EgresoPromocionesDiresnaDTO> select = egresoPromocionesDiresnaBL.ObtenerLista();

            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIEgresado, string SexoEgresado, string FechaResolIngreso, 
            string FechaResolEgreso, string ConcursoAdminisionIngreso, int CargaId, string fecha)
        {
            EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO = new();
            egresoPromocionesDiresnaDTO.DNIEgresado = DNIEgresado;
            egresoPromocionesDiresnaDTO.SexoEgresado = SexoEgresado;
            egresoPromocionesDiresnaDTO.FechaResolIngreso = FechaResolIngreso;
            egresoPromocionesDiresnaDTO.FechaResolEgreso = FechaResolEgreso;
            egresoPromocionesDiresnaDTO.ConcursoAdminisionIngreso = ConcursoAdminisionIngreso;
            egresoPromocionesDiresnaDTO.CargaId = CargaId;
            egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = egresoPromocionesDiresnaBL.AgregarRegistro(egresoPromocionesDiresnaDTO, fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(egresoPromocionesDiresnaBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIEgresado, string SexoEgresado, string FechaResolIngreso, 
            string FechaResolEgreso, string ConcursoAdminisionIngreso)
        {
            EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO = new();
            egresoPromocionesDiresnaDTO.EgresoPromocionId = Id;
            egresoPromocionesDiresnaDTO.DNIEgresado = DNIEgresado;
            egresoPromocionesDiresnaDTO.SexoEgresado = SexoEgresado;
            egresoPromocionesDiresnaDTO.FechaResolIngreso = FechaResolIngreso;
            egresoPromocionesDiresnaDTO.FechaResolEgreso = FechaResolEgreso;
            egresoPromocionesDiresnaDTO.ConcursoAdminisionIngreso = ConcursoAdminisionIngreso;
            egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = egresoPromocionesDiresnaBL.ActualizarFormato(egresoPromocionesDiresnaDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO = new();
            egresoPromocionesDiresnaDTO.EgresoPromocionId = Id;
            egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (egresoPromocionesDiresnaBL.EliminarFormato(egresoPromocionesDiresnaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EgresoPromocionesDiresnaDTO egresoPromocionesDiresnaDTO = new();
            egresoPromocionesDiresnaDTO.CargaId = Id;
            egresoPromocionesDiresnaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (egresoPromocionesDiresnaBL.EliminarCarga(egresoPromocionesDiresnaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EgresoPromocionesDiresnaDTO> lista = new List<EgresoPromocionesDiresnaDTO>();
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

                    lista.Add(new EgresoPromocionesDiresnaDTO
                    {
                        DNIEgresado = fila.GetCell(0).ToString(),
                        SexoEgresado = fila.GetCell(1).ToString(),
                        FechaResolIngreso = fila.GetCell(2).ToString(),
                        FechaResolEgreso = fila.GetCell(3).ToString(),
                        ConcursoAdminisionIngreso = fila.GetCell(4).ToString(),

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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("DNIEgresado", typeof(string)),
                    new DataColumn("SexoEgresado", typeof(string)),
                    new DataColumn("FechaResolIngreso", typeof(string)),
                    new DataColumn("FechaResolEgreso", typeof(string)),
                    new DataColumn("ConcursoAdminisionIngreso", typeof(string)),

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
                    fila.GetCell(4).ToString(),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = egresoPromocionesDiresnaBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDEPD(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresna\\EgresoPromocionesDiresna.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = egresoPromocionesDiresnaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EgresoPromocionesDiresna", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiresnaEgresoPromocionesDiresna.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiresnaEgresoPromocionesDiresna.xlsx");
        }
    }

}

