using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diali;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
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
    public class DialiMantRealizadoDependenciaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        MantenimientoRealizadoDependencia mantenimientorealizDepenBL = new();
        UnidadNaval unidadNavalBL = new();
        Mes mesBL = new();
        Carga cargaBL = new();
        public DialiMantRealizadoDependenciaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Mantenimiento Realizado a las Unidades y Dependencia Navales", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("MantenimientoRealizadoDependencia");
            return Json(new { data1 = unidadNavalDTO, data2 = mesDTO, data3 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<MantenimientoRealizadoDependenciaDTO> select = mantenimientorealizDepenBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string TipoUnidadMantenimiento, string CodigoUnidadNaval, string NumeroMes,
           int TareaProgramada, int TareaEjecutada, int TareaNoEjecutada, int TNEFaltapersonal,
           int TNEFaltaTiempo, int TNEFaltaRepuesto, int TNEFaltaMaterial, int TNEFaltaPresupuesto, int TNEFaltaHerramienta,
           int TNEFaltaInstrumento, int TNEFaltaConocimiento, int CargaId, string Fecha)
        {
            MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO = new();
            mantenimientoRealizadoDTO.TipoUnidadMantenimiento = TipoUnidadMantenimiento;
            mantenimientoRealizadoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            mantenimientoRealizadoDTO.NumeroMes = NumeroMes;
            mantenimientoRealizadoDTO.TareaProgramada = TareaProgramada;
            mantenimientoRealizadoDTO.TareaEjecutada = TareaEjecutada;
            mantenimientoRealizadoDTO.TareaNoEjecutada = TareaNoEjecutada;
            mantenimientoRealizadoDTO.TNEFaltapersonal = TNEFaltapersonal;
            mantenimientoRealizadoDTO.TNEFaltaTiempo = TNEFaltaTiempo;
            mantenimientoRealizadoDTO.TNEFaltaRepuesto = TNEFaltaRepuesto;
            mantenimientoRealizadoDTO.TNEFaltaMaterial = TNEFaltaMaterial;
            mantenimientoRealizadoDTO.TNEFaltaPresupuesto = TNEFaltaPresupuesto;
            mantenimientoRealizadoDTO.TNEFaltaHerramienta = TNEFaltaHerramienta;
            mantenimientoRealizadoDTO.TNEFaltaInstrumento = TNEFaltaInstrumento;
            mantenimientoRealizadoDTO.TNEFaltaConocimiento = TNEFaltaConocimiento;
            mantenimientoRealizadoDTO.CargaId = CargaId;
            mantenimientoRealizadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mantenimientorealizDepenBL.AgregarRegistro(mantenimientoRealizadoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(mantenimientorealizDepenBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string TipoUnidadMantenimiento, string CodigoUnidadNaval, string NumeroMes,
           int TareaProgramada, int TareaEjecutada, int TareaNoEjecutada, int TNEFaltapersonal,
           int TNEFaltaTiempo, int TNEFaltaRepuesto, int TNEFaltaMaterial, int TNEFaltaPresupuesto, int TNEFaltaHerramienta,
           int TNEFaltaInstrumento, int TNEFaltaConocimiento)
        {
            MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO = new();
            mantenimientoRealizadoDTO.MantenimientoDependUnidId = Id;
            mantenimientoRealizadoDTO.TipoUnidadMantenimiento = TipoUnidadMantenimiento;
            mantenimientoRealizadoDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            mantenimientoRealizadoDTO.NumeroMes = NumeroMes;
            mantenimientoRealizadoDTO.TareaProgramada = TareaProgramada;
            mantenimientoRealizadoDTO.TareaEjecutada = TareaEjecutada;
            mantenimientoRealizadoDTO.TareaNoEjecutada = TareaNoEjecutada;
            mantenimientoRealizadoDTO.TNEFaltapersonal = TNEFaltapersonal;
            mantenimientoRealizadoDTO.TNEFaltaTiempo = TNEFaltaTiempo;
            mantenimientoRealizadoDTO.TNEFaltaRepuesto = TNEFaltaRepuesto;
            mantenimientoRealizadoDTO.TNEFaltaMaterial = TNEFaltaMaterial;
            mantenimientoRealizadoDTO.TNEFaltaPresupuesto = TNEFaltaPresupuesto;
            mantenimientoRealizadoDTO.TNEFaltaHerramienta = TNEFaltaHerramienta;
            mantenimientoRealizadoDTO.TNEFaltaInstrumento = TNEFaltaInstrumento;
            mantenimientoRealizadoDTO.TNEFaltaConocimiento = TNEFaltaConocimiento;
            mantenimientoRealizadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = mantenimientorealizDepenBL.ActualizarFormato(mantenimientoRealizadoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO = new();
            mantenimientoRealizadoDTO.MantenimientoDependUnidId = Id;
            mantenimientoRealizadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (mantenimientorealizDepenBL.EliminarFormato(mantenimientoRealizadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO = new();
            mantenimientoRealizadoDTO.CargaId = Id;
            mantenimientoRealizadoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (mantenimientorealizDepenBL.EliminarCarga(mantenimientoRealizadoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<MantenimientoRealizadoDependenciaDTO> lista = new List<MantenimientoRealizadoDependenciaDTO>();
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

                    lista.Add(new MantenimientoRealizadoDependenciaDTO
                    {
                        TipoUnidadMantenimiento = fila.GetCell(1).ToString(),
                        CodigoUnidadNaval = fila.GetCell(2).ToString(),
                        NumeroMes = fila.GetCell(3).ToString(),
                        TareaProgramada = int.Parse(fila.GetCell(4).ToString()),
                        TareaEjecutada = int.Parse(fila.GetCell(5).ToString()),
                        TareaNoEjecutada = int.Parse(fila.GetCell(6).ToString()),
                        TNEFaltapersonal = int.Parse(fila.GetCell(7).ToString()),
                        TNEFaltaTiempo = int.Parse(fila.GetCell(8).ToString()),
                        TNEFaltaRepuesto = int.Parse(fila.GetCell(9).ToString()),
                        TNEFaltaMaterial = int.Parse(fila.GetCell(10).ToString()),
                        TNEFaltaPresupuesto = int.Parse(fila.GetCell(11).ToString()),
                        TNEFaltaHerramienta = int.Parse(fila.GetCell(12).ToString()),
                        TNEFaltaInstrumento = int.Parse(fila.GetCell(13).ToString()),
                        TNEFaltaConocimiento = int.Parse(fila.GetCell(14).ToString())
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

            dt.Columns.AddRange(new DataColumn[15]
            {
                    new DataColumn("TipoUnidadMantenimiento", typeof(string)),
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("TareaProgramada", typeof(int)),
                    new DataColumn("TareaEjecutada", typeof(int)),
                    new DataColumn("TareaNoEjecutada", typeof(int)),
                    new DataColumn("TNEFaltapersonal", typeof(int)),
                    new DataColumn("TNEFaltaTiempo", typeof(int)),
                    new DataColumn("TNEFaltaRepuesto", typeof(int)),
                    new DataColumn("TNEFaltaMaterial", typeof(int)),
                    new DataColumn("TNEFaltaPresupuesto", typeof(int)),
                    new DataColumn("TNEFaltaHerramienta", typeof(int)),
                    new DataColumn("TNEFaltaInstrumento", typeof(int)),
                    new DataColumn("TNEFaltaConocimiento", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    int.Parse(fila.GetCell(7).ToString()),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    int.Parse(fila.GetCell(13).ToString()),
                    int.Parse(fila.GetCell(14).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = mantenimientorealizDepenBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\prueba.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capitania = mantenimientorealizDepenBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", capitania);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DialiMantRealizadoDependencia.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DialiMantRealizadoDependencia.xlsx");
        }

    }

}