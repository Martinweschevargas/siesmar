using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav;
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
    public class DihidronavInformeTecnicoInspeccionController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        InformeTecnicoInspeccion informeTecnicoInspeccionBL = new();

        TipoObra tipoObraBL = new();
        DepartamentoUbigeo departamentoUbigeoBL = new();
        ProvinciaUbigeo provinciaUbigeoBL = new();
        DistritoUbigeo distritoUbigeoBL = new();
        Carga cargaBL = new();

        public DihidronavInformeTecnicoInspeccionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Informes técnicos por inspección de término de obra", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoObraDTO> tipoObraDTO = tipoObraBL.ObtenerTipoObras(); 
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoUbigeoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaUbigeoBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoUbigeoBL.ObtenerDistritoUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InformeTecnicoInspeccion");


            return Json(new
            {
                data1 = tipoObraDTO,
                data2 = departamentoUbigeoDTO,
                data3 = provinciaUbigeoDTO,
                data4 = distritoUbigeoDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<InformeTecnicoInspeccionDTO> informeTecnicoInspeccionDTO = informeTecnicoInspeccionBL.ObtenerLista();
            return Json(new { data = informeTecnicoInspeccionDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int NumeroOrden, string NumeroInformeTecnico, string CodigoTipoObra,  
            string DescripcionInspeccion, string FechaEvaluacion, string EmpresaPersonaSolicitante,
            string DistritoUbigeo)
        {
            InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO = new();
            informeTecnicoInspeccionDTO.NumeroOrden = NumeroOrden;
            informeTecnicoInspeccionDTO.NumeroInformeTecnico = NumeroInformeTecnico;
            informeTecnicoInspeccionDTO.CodigoTipoObra = CodigoTipoObra;
            informeTecnicoInspeccionDTO.DescripcionInspeccion = DescripcionInspeccion;
            informeTecnicoInspeccionDTO.FechaEvaluacion = FechaEvaluacion;
            informeTecnicoInspeccionDTO.EmpresaPersonaSolicitante = EmpresaPersonaSolicitante;
            informeTecnicoInspeccionDTO.DistritoUbigeo = DistritoUbigeo;
            informeTecnicoInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = informeTecnicoInspeccionBL.AgregarRegistro(informeTecnicoInspeccionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(informeTecnicoInspeccionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int InformeTecnicoInspeccionId, int NumeroOrden, string NumeroInformeTecnico, string CodigoTipoObra,
            string DescripcionInspeccion, string FechaEvaluacion, string EmpresaPersonaSolicitante,
            string DistritoUbigeo)
        {
            InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO = new();
            informeTecnicoInspeccionDTO.InformeTecnicoInspeccionId = InformeTecnicoInspeccionId;
            informeTecnicoInspeccionDTO.NumeroOrden = NumeroOrden;
            informeTecnicoInspeccionDTO.NumeroInformeTecnico = NumeroInformeTecnico;
            informeTecnicoInspeccionDTO.CodigoTipoObra = CodigoTipoObra;
            informeTecnicoInspeccionDTO.DescripcionInspeccion = DescripcionInspeccion;
            informeTecnicoInspeccionDTO.FechaEvaluacion = FechaEvaluacion;
            informeTecnicoInspeccionDTO.EmpresaPersonaSolicitante = EmpresaPersonaSolicitante;
            informeTecnicoInspeccionDTO.DistritoUbigeo = DistritoUbigeo;
            informeTecnicoInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = informeTecnicoInspeccionBL.ActualizarFormato(informeTecnicoInspeccionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO = new();
            informeTecnicoInspeccionDTO.InformeTecnicoInspeccionId = Id;
            informeTecnicoInspeccionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (informeTecnicoInspeccionBL.EliminarFormato(informeTecnicoInspeccionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InformeTecnicoInspeccionDTO> lista = new List<InformeTecnicoInspeccionDTO>();
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

                    lista.Add(new InformeTecnicoInspeccionDTO
                    {
                        NumeroOrden = int.Parse(fila.GetCell(0).ToString()),
                        NumeroInformeTecnico = fila.GetCell(1).ToString(),
                        CodigoTipoObra = fila.GetCell(2).ToString(),
                        DescripcionInspeccion = fila.GetCell(3).ToString(),
                        FechaEvaluacion = fila.GetCell(4).ToString(),
                        EmpresaPersonaSolicitante = fila.GetCell(5).ToString(),
                        DistritoUbigeo = fila.GetCell(6).ToString()
 
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("NumeroOrden", typeof(int)),
                    new DataColumn("NumeroInformeTecnico", typeof(string)),
                    new DataColumn("CodigoTipoObra", typeof(string)),
                    new DataColumn("DescripcionInspeccion", typeof(string)),
                    new DataColumn("FechaEvaluacion", typeof(string)),
                    new DataColumn("EmpresaPersonaSolicitante", typeof(string)),
                    new DataColumn("DistritoUbigeo", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(4).ToString()),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = informeTecnicoInspeccionBL.InsertarDatos(dt);
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


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DihidronavInformeTecnicoInspeccion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DihidronavInformeTecnicoInspeccion.xlsx");
        }
    }

}