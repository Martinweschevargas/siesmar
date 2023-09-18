using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzodos;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzodos;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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
    public class ComzodosAntidisturbioAlistamientoLogisticoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        AntidisturbioAlistamientoLogistico antidisturbioAlistamientoLogisticoBL = new();
        DescripcionMaterial descripcionMaterialBL = new();
        CondicionAlistamientoLogistico condicionAlistamientoLogisticoBL = new();
        Carga cargaBL = new();

        public ComzodosAntidisturbioAlistamientoLogisticoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicios de Dispositivos de Seguridad Prestados", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<DescripcionMaterialDTO> descripcionMaterialDTO = descripcionMaterialBL.ObtenerDescripcionMaterials();
            List<CondicionAlistamientoLogisticoDTO> condicionAlistamientoLogisticoDTO = condicionAlistamientoLogisticoBL.ObtenerCondicionAlistamientoLogisticos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AntidisturbioAlistamientoLogistico");

            return Json(new
            {
                data1 = descripcionMaterialDTO,
                data2 = condicionAlistamientoLogisticoDTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AntidisturbioAlistamientoLogisticoDTO> antidisturbioAlistamientoLogisticoDTO = antidisturbioAlistamientoLogisticoBL.ObtenerLista();
            return Json(new { data = antidisturbioAlistamientoLogisticoDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar( int MaterialRequerido, int MaterialAsignado, string CodigoDescripcionMaterial, string CodigoCondicionAlistamientoLogistico,
            string ObservacionAlistamientoLogistico, int CargaId, string Fecha)
        {
            AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO = new();
            antidisturbioAlistamientoLogisticoDTO.CodigoDescripcionMaterial = CodigoDescripcionMaterial;
            antidisturbioAlistamientoLogisticoDTO.MaterialRequerido = MaterialRequerido;
            antidisturbioAlistamientoLogisticoDTO.MaterialAsignado = MaterialAsignado;
            antidisturbioAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico = CodigoCondicionAlistamientoLogistico;
            antidisturbioAlistamientoLogisticoDTO.ObservacionAlistamientoLogistico = ObservacionAlistamientoLogistico;
            antidisturbioAlistamientoLogisticoDTO.CargaId = CargaId;
            antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = antidisturbioAlistamientoLogisticoBL.AgregarRegistro(antidisturbioAlistamientoLogisticoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(antidisturbioAlistamientoLogisticoBL.EditarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int AntidisturbioAlistamientoLogisticoId, int MaterialRequerido, int MaterialAsignado, string CodigoDescripcionMaterial, string CodigoCondicionAlistamientoLogistico,
            string ObservacionAlistamientoLogistico)
        {
            AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO = new();
            antidisturbioAlistamientoLogisticoDTO.AntidisturbioAlistamientoLogisticoId = AntidisturbioAlistamientoLogisticoId;
            antidisturbioAlistamientoLogisticoDTO.CodigoDescripcionMaterial = CodigoDescripcionMaterial;
            antidisturbioAlistamientoLogisticoDTO.MaterialRequerido = MaterialRequerido;
            antidisturbioAlistamientoLogisticoDTO.MaterialAsignado = MaterialAsignado;
            antidisturbioAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico = CodigoCondicionAlistamientoLogistico;
            antidisturbioAlistamientoLogisticoDTO.ObservacionAlistamientoLogistico = ObservacionAlistamientoLogistico;
            antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = antidisturbioAlistamientoLogisticoBL.ActualizarFormato(antidisturbioAlistamientoLogisticoDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO = new();
            antidisturbioAlistamientoLogisticoDTO.AntidisturbioAlistamientoLogisticoId = Id;
            antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (antidisturbioAlistamientoLogisticoBL.EliminarFormato(antidisturbioAlistamientoLogisticoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AntidisturbioAlistamientoLogisticoDTO antidisturbioAlistamientoLogisticoDTO = new();
            antidisturbioAlistamientoLogisticoDTO.CargaId = Id;
            antidisturbioAlistamientoLogisticoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (antidisturbioAlistamientoLogisticoBL.EliminarCarga(antidisturbioAlistamientoLogisticoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AntidisturbioAlistamientoLogisticoDTO> lista = new List<AntidisturbioAlistamientoLogisticoDTO>();
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

                    lista.Add(new AntidisturbioAlistamientoLogisticoDTO
                    {
                        CodigoDescripcionMaterial = fila.GetCell(0).ToString(),
                        MaterialRequerido = int.Parse(fila.GetCell(1).ToString()),
                        MaterialAsignado = int.Parse(fila.GetCell(2).ToString()),
                        CodigoCondicionAlistamientoLogistico = fila.GetCell(3).ToString(),
                        ObservacionAlistamientoLogistico = fila.GetCell(4).ToString()
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

            dt.Columns.AddRange(new DataColumn[6]
            {
                    new DataColumn("CodigoDescripcionMaterial", typeof(string)),
                    new DataColumn("MaterialRequerido", typeof(int)),
                    new DataColumn("MaterialAsignado", typeof(int)),
                    new DataColumn("CodigoCondicionAlistamientoLogistico", typeof(string)),
                    new DataColumn("ObservacionAlistamientoLogistico", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    int.Parse(fila.GetCell(1).ToString()),
                    int.Parse(fila.GetCell(2).ToString()),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = antidisturbioAlistamientoLogisticoBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzodosAntidisturbioAlistamientoLogistico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzodosAntidisturbioAlistamientoLogistico.xlsx");
        }
    }

}