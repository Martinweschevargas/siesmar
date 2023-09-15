using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diabaste;
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
    public class DiabasteDistribucionMaterialController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        DistribucionMaterial distribucionMaterialBL = new();
        Mes mesBL = new();
        AreaDiperadmon areaDiperadmonBL = new();
        TipoMaterial tipoMateriaBL = new();
        UnidadMedida unidadMedidaBL = new();
        Carga cargaBL = new();

        public DiabasteDistribucionMaterialController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Distribución de material a las unidades y dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess(); 
            List<AreaDiperadmonDTO> areaDiperadmonDTO = areaDiperadmonBL.ObtenerAreaDiperadmons();
            List<TipoMaterialDTO> tipoMaterialDTO = tipoMateriaBL.ObtenerTipoMaterials();
            List<UnidadMedidaDTO> unidadMedidaDTO = unidadMedidaBL.ObtenerUnidadMedidas();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DistribucionMaterial");
            return Json(new
            {
                data1 = mesDTO,
                data2 = areaDiperadmonDTO,
                data3 = tipoMaterialDTO,
                data4 = unidadMedidaDTO,
                data5 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<DistribucionMaterialDTO> distribucionMaterialDTO = distribucionMaterialBL.ObtenerLista();
            return Json(new { data = distribucionMaterialDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int Anio, string CodigoAreaDiperadmon, string NumeroMes, string CodigoUnidadMedida, int CantidadMaterialEntregado,
            string CodigoTipoMaterial, string FechaEntrega, int CargaId, string Fecha)
        {
            DistribucionMaterialDTO distribucionMaterialDTO = new();
            distribucionMaterialDTO.Anio = Anio;
            distribucionMaterialDTO.NumeroMes = NumeroMes;
            distribucionMaterialDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            distribucionMaterialDTO.CodigoTipoMaterial = CodigoTipoMaterial;
            distribucionMaterialDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            distribucionMaterialDTO.CantidadMaterialEntregado = CantidadMaterialEntregado;
            distribucionMaterialDTO.FechaEntrega = FechaEntrega;
            distribucionMaterialDTO.CargaId = CargaId;
            distribucionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distribucionMaterialBL.AgregarRegistro(distribucionMaterialDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(distribucionMaterialBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int DistribucionMaterialId, int Anio, string CodigoAreaDiperadmon, string NumeroMes, string CodigoUnidadMedida, int CantidadMaterialEntregado,
            string CodigoTipoMaterial, string FechaEntrega)
        {
            DistribucionMaterialDTO distribucionMaterialDTO = new();
            distribucionMaterialDTO.DistribucionMaterialId = DistribucionMaterialId;
            distribucionMaterialDTO.Anio = Anio;
            distribucionMaterialDTO.NumeroMes = NumeroMes;
            distribucionMaterialDTO.CodigoAreaDiperadmon = CodigoAreaDiperadmon;
            distribucionMaterialDTO.CodigoTipoMaterial = CodigoTipoMaterial;
            distribucionMaterialDTO.CodigoUnidadMedida = CodigoUnidadMedida;
            distribucionMaterialDTO.CantidadMaterialEntregado = CantidadMaterialEntregado;
            distribucionMaterialDTO.FechaEntrega = FechaEntrega;
            distribucionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = distribucionMaterialBL.ActualizarFormato(distribucionMaterialDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DistribucionMaterialDTO distribucionMaterialDTO = new();
            distribucionMaterialDTO.DistribucionMaterialId = Id;
            distribucionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (distribucionMaterialBL.EliminarFormato(distribucionMaterialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DistribucionMaterialDTO distribucionMaterialDTO = new();
            distribucionMaterialDTO.CargaId = Id;
            distribucionMaterialDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (distribucionMaterialBL.EliminarCarga(distribucionMaterialDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DistribucionMaterialDTO> lista = new List<DistribucionMaterialDTO>();
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

                    lista.Add(new DistribucionMaterialDTO
                    {
                        Anio = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoAreaDiperadmon = fila.GetCell(2).ToString(),
                        CodigoTipoMaterial = fila.GetCell(3).ToString(),
                        CodigoUnidadMedida = fila.GetCell(4).ToString(),
                        CantidadMaterialEntregado = int.Parse(fila.GetCell(5).ToString()),
                        FechaEntrega = fila.GetCell(6).ToString()

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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string Fecha)
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("Anio", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoAreaDiperadmon", typeof(string)),
                    new DataColumn("CodigoTipoMaterial", typeof(string)),
                    new DataColumn("CodigoUnidadMedida", typeof(string)),
                    new DataColumn("CantidadMaterialEntregado", typeof(int)),
                    new DataColumn ("FechaEntrega", typeof(string)),
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
                    fila.GetCell(4).ToString(),
                    int.Parse(fila.GetCell(5).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = distribucionMaterialBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDM()
        {
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diabaste\\DistribucionMaterial.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var distribucionMaterial = distribucionMaterialBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DistribucionMaterial", distribucionMaterial);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiabasteDistribucionMaterial.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiabasteDistribucionMaterial.xlsx");
        }

    }

}