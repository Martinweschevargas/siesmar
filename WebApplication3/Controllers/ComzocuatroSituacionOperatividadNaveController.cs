using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro;
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
    public class ComzocuatroSituacionOperatividadNaveController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        SituacionOperatividadNaveComzocuatro situacionOperativaNaveComzocuatroBL = new();
        TipoNave tipoNaveBL = new();
        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();
        Condicion condicionBL = new();
        Carga cargaBL = new();

        public ComzocuatroSituacionOperatividadNaveController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situacion de Operatividad de Naves", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoNaveDTO> tipoNaveDTO = tipoNaveBL.ObtenerTipoNaves();
            List<TipoPlataformaNaveDTO> tipoPlataformaNaveDTO = tipoPlataformaNaveBL.ObtenerTipoPlataformaNaves();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CapacidadOperativaRequeridaDTO> capacidadOperativaRequeridaDTO = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SituacionOperatividadNaveComzocuatro");

            return Json(new
            {
                data1 = tipoNaveDTO,
                data2 = tipoPlataformaNaveDTO,
                data3 = dependenciaDTO,
                data4 = departamentoUbigeoDTO,
                data5 = provinciaUbigeoDTO,
                data6 = distritoUbigeoDTO,
                data7 = capacidadOperativaRequeridaDTO,
                data8 = condicionDTO,
                data9 = listaCargas

            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionOperatividadNaveComzocuatroDTO> situacionOperativaNaveComzocuatroDTO = situacionOperativaNaveComzocuatroBL.ObtenerLista();
            return Json(new { data = situacionOperativaNaveComzocuatroDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int CascoNave, string CodigoTipoNave, string CodigoTipoPlataformaNave, int DepartamentoUbigeoId,
            string CodigoDependencia, string Ubicacion, string CodigoCapacidadOperativaRequerida, int ProvinciaUbigeoId, string DistritoUbigeo,
            string CodigoCondicion, string Observacion, int CargaId)
        {
            SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO = new();
            situacionOperativaNaveComzocuatroDTO.CodigoTipoNave = CodigoTipoNave;
            situacionOperativaNaveComzocuatroDTO.CascoNave = CascoNave;
            situacionOperativaNaveComzocuatroDTO.CodigoTipoPlataformaNave = CodigoTipoPlataformaNave;
            situacionOperativaNaveComzocuatroDTO.CodigoDependencia = CodigoDependencia;
            situacionOperativaNaveComzocuatroDTO.Ubicacion = Ubicacion;
            situacionOperativaNaveComzocuatroDTO.DistritoUbigeo = DistritoUbigeo;
            situacionOperativaNaveComzocuatroDTO.CodigoCapacidadOperativaRequerida = CodigoCapacidadOperativaRequerida;
            situacionOperativaNaveComzocuatroDTO.CodigoCondicion = CodigoCondicion;
            situacionOperativaNaveComzocuatroDTO.Observacion = Observacion;
            situacionOperativaNaveComzocuatroDTO.Año = DateTime.Now.Year; ;
            situacionOperativaNaveComzocuatroDTO.Mes = DateTime.Now.Month;
            situacionOperativaNaveComzocuatroDTO.Dia = DateTime.Now.Day;
            situacionOperativaNaveComzocuatroDTO.CargaId = CargaId;
            situacionOperativaNaveComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperativaNaveComzocuatroBL.AgregarRegistro(situacionOperativaNaveComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionOperativaNaveComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int CascoNave, string CodigoTipoNave, string CodigoTipoPlataformaNave, int DepartamentoUbigeoId,
            string CodigoDependencia, string Ubicacion, string CodigoCapacidadOperativaRequerida, int ProvinciaUbigeoId, string DistritoUbigeo,
            string CodigoCondicion, string Observacion)
        {
            SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO = new();
            situacionOperativaNaveComzocuatroDTO.SituacionOperativaNaveComzocuatroId = Id;
            situacionOperativaNaveComzocuatroDTO.CodigoTipoNave = CodigoTipoNave;
            situacionOperativaNaveComzocuatroDTO.CascoNave = CascoNave;
            situacionOperativaNaveComzocuatroDTO.CodigoTipoPlataformaNave = CodigoTipoPlataformaNave;
            situacionOperativaNaveComzocuatroDTO.CodigoDependencia = CodigoDependencia;
            situacionOperativaNaveComzocuatroDTO.Ubicacion = Ubicacion;
            situacionOperativaNaveComzocuatroDTO.DistritoUbigeo = DistritoUbigeo;
            situacionOperativaNaveComzocuatroDTO.CodigoCapacidadOperativaRequerida = CodigoCapacidadOperativaRequerida;
            situacionOperativaNaveComzocuatroDTO.CodigoCondicion = CodigoCondicion;
            situacionOperativaNaveComzocuatroDTO.Observacion = Observacion;
            situacionOperativaNaveComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionOperativaNaveComzocuatroBL.ActualizarFormato(situacionOperativaNaveComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionOperatividadNaveComzocuatroDTO situacionOperativaNaveComzocuatroDTO = new();
            situacionOperativaNaveComzocuatroDTO.SituacionOperativaNaveComzocuatroId = Id;
            situacionOperativaNaveComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionOperativaNaveComzocuatroBL.EliminarFormato(situacionOperativaNaveComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<SituacionOperatividadNaveComzocuatroDTO> lista = new List<SituacionOperatividadNaveComzocuatroDTO>();
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

                    lista.Add(new SituacionOperatividadNaveComzocuatroDTO
                    {
                        CodigoTipoNave = fila.GetCell(0).ToString(),
                        CascoNave = int.Parse(fila.GetCell(1).ToString()),
                        CodigoTipoPlataformaNave = fila.GetCell(2).ToString(),
                        CodigoDependencia = fila.GetCell(3).ToString(),
                        Ubicacion = fila.GetCell(4).ToString(),
                        DistritoUbigeo = fila.GetCell(1).ToString(),
                        CodigoCapacidadOperativaRequerida = fila.GetCell(2).ToString(),
                        CodigoCondicion = fila.GetCell(3).ToString(),
                        Observacion = fila.GetCell(4).ToString()
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje = "";

            IWorkbook MiExcel = null;

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
            DataTable dt = new();

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoTipoNave", typeof(string)),
                    new DataColumn("CascoNave", typeof(int)),
                    new DataColumn("CodigoTipoPlataformaNave", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("Ubicacion", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
                    new DataColumn("CodigoCapacidadOperativaRequerida", typeof(string)),
                    new DataColumn("CodigoCondicion", typeof(string)),
                    new DataColumn("Observacion", typeof(string)),
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
                            User.obtenerUsuario());
            }
            var IND_OPERACION = situacionOperativaNaveComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }
        public IActionResult Print()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report1.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            LocalReport localReport = new LocalReport(path);
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult Print2()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Report2.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("rpt1", "Welcome to FoxLearn");
            var Capitanias = situacionOperativaNaveComzocuatroBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("Capitania", Capitanias);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DirintemarActividadCultural.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DirintemarActividadCultural.xlsx");
        }
    }

}