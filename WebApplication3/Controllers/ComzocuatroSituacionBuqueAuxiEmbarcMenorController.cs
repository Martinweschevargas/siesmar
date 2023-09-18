using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using MathNet.Numerics.Distributions;
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
    public class ComzocuatroSituacionBuqueAuxiEmbarcMenorController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        SituacionBuqueAuxiEmbarcMenorComzocuatro situacionBuqueAuxiEmbarcMenorComzocuatroBL = new();
        TipoPlataformaNave tipoPlataformaNaveBL = new();
        Dependencia dependenciaBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        CapacidadOperativaRequerida capacidadOperativaRequeridaBL = new();
        Condicion condicionBL = new();
        Carga cargaBL = new();

        public ComzocuatroSituacionBuqueAuxiEmbarcMenorController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situación de Buques Auxiliares y Embarcaciones Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPlataformaNaveDTO> tipoPlataformaNaveDTO = tipoPlataformaNaveBL.ObtenerTipoPlataformaNaves();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CapacidadOperativaRequeridaDTO> capacidadOperativaRequeridaDTO = capacidadOperativaRequeridaBL.ObtenerCapacidadOperativaRequeridas();
            List<CondicionDTO> condicionDTO = condicionBL.ObtenerCondicions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("SituacionBuqueAuxiEmbarcMenorComzocuatro");

            return Json(new
            {
                data1 = tipoPlataformaNaveDTO,
                data2 = dependenciaDTO,
                data3 = departamentoUbigeoDTO,
                data4 = provinciaUbigeoDTO,
                data5 = distritoUbigeoDTO,
                data6 = capacidadOperativaRequeridaDTO,
                data7 = condicionDTO,
                data8 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO> situacionBuqueAuxiEmbarcMenorComzocuatroDTO = situacionBuqueAuxiEmbarcMenorComzocuatroBL.ObtenerLista();
            return Json(new { data = situacionBuqueAuxiEmbarcMenorComzocuatroDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoTipoNave, string CodigoPlataformaNave, string CodigoDepartamentoUbigeo, 
            string CodigoDependencia, string Ubicacion, string CodigoCapacidadOperativaRequerida, string CodigoProvinciaUbigeo, string DistritoUbigeo,
            string CodigoCondicion, string Observacion, int CargaId)
        {
            SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO = new();
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoTipoNave = CodigoTipoNave;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoPlataformaNave = CodigoPlataformaNave;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoDependencia = CodigoDependencia;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Ubicacion = Ubicacion;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.DistritoUbigeo = DistritoUbigeo;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCapacidadOperativaRequerida = CodigoCapacidadOperativaRequerida;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCondicion = CodigoCondicion;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Observacion = Observacion;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Año = DateTime.Now.Year; ;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Mes = DateTime.Now.Month;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Dia = DateTime.Now.Day;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CargaId = CargaId;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionBuqueAuxiEmbarcMenorComzocuatroBL.AgregarRegistro(situacionBuqueAuxiEmbarcMenorComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(situacionBuqueAuxiEmbarcMenorComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoTipoNave, string CodigoPlataformaNave, string CodigoDepartamentoUbigeo,
            string CodigoDependencia, string Ubicacion, string CodigoCapacidadOperativaRequerida, string CodigoProvinciaUbigeo, string DistritoUbigeo,
            string CodigoCondicion, string Observacion)
        {
            SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO = new();
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.SituacionBuqueAuxiliarEmbarcacionMenorId = Id;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoTipoNave = CodigoTipoNave;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoPlataformaNave = CodigoPlataformaNave;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoDependencia = CodigoDependencia;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Ubicacion = Ubicacion;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.DistritoUbigeo = DistritoUbigeo;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCapacidadOperativaRequerida = CodigoCapacidadOperativaRequerida;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.CodigoCondicion = CodigoCondicion;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.Observacion = Observacion;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = situacionBuqueAuxiEmbarcMenorComzocuatroBL.ActualizarFormato(situacionBuqueAuxiEmbarcMenorComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            SituacionBuqueAuxiEmbarcMenorComzocuatroDTO situacionBuqueAuxiEmbarcMenorComzocuatroDTO = new();
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.SituacionBuqueAuxiliarEmbarcacionMenorId = Id;
            situacionBuqueAuxiEmbarcMenorComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (situacionBuqueAuxiEmbarcMenorComzocuatroBL.EliminarFormato(situacionBuqueAuxiEmbarcMenorComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO> lista = new List<SituacionBuqueAuxiEmbarcMenorComzocuatroDTO>();
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

                    lista.Add(new SituacionBuqueAuxiEmbarcMenorComzocuatroDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoTipoNave = fila.GetCell(1).ToString(),
                        CodigoPlataformaNave = fila.GetCell(2).ToString(),
                        CodigoDependencia = fila.GetCell(3).ToString(),
                        Ubicacion = fila.GetCell(4).ToString(),
                        DistritoUbigeo = fila.GetCell(5).ToString(),
                        CodigoCapacidadOperativaRequerida = fila.GetCell(6).ToString(),
                        CodigoCondicion = fila.GetCell(7).ToString(),
                        Observacion = fila.GetCell(8).ToString(),   

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
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoTipoNave", typeof(string)),
                    new DataColumn("CodigoPlataformaNave", typeof(string)),
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
                            fila.GetCell(1).ToString(),
                            fila.GetCell(2).ToString(),
                            fila.GetCell(3).ToString(),
                            fila.GetCell(4).ToString(),
                            fila.GetCell(5).ToString(),
                            fila.GetCell(6).ToString(),
                            fila.GetCell(7).ToString(),
                            fila.GetCell(8).ToString(),
                            User.obtenerUsuario());
            }
            var IND_OPERACION = situacionBuqueAuxiEmbarcMenorComzocuatroBL.InsertarDatos(dt);
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
            var Capitanias = situacionBuqueAuxiEmbarcMenorComzocuatroBL.ObtenerLista();
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