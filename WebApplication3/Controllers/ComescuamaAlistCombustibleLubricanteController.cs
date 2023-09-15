using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comescuama;
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

    public class ComescuamaAlistCombustibleLubricanteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        AlistCombustibleLubricanteComescuama alistCombustibleLubricanteComescuamaBL = new();
        UnidadNaval unidadNavalBL = new();
        AlistamientoCombustibleLubricante2 alistamientoCombustibleLubricante2BL = new();
        Carga cargaBL = new();

        public ComescuamaAlistCombustibleLubricanteController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Situación de Combustibles Y Lubricantes (ACL)", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<AlistamientoCombustibleLubricante2DTO> alistamientoCombustibleLubricante2DTO = alistamientoCombustibleLubricante2BL.ObtenerAlistamientoCombustibleLubricante2s();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoCombustibleLubricanteComescuama");
            return Json(new { 
                data1 = unidadNavalDTO, 
                data2 = alistamientoCombustibleLubricante2DTO,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<AlistCombustibleLubricanteComescuamaDTO> select = alistCombustibleLubricanteComescuamaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        ////[AuthorizePermission(Formato: 157, Permiso: 1)]//Registrar
        public ActionResult Insertar(string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante2, 
            decimal PromedioPonderado, decimal SubPromedioParcial, int CargaId, string Fecha)
        {
            AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO = new();
            alistCombustibleLubricanteComescuamaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistCombustibleLubricanteComescuamaDTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            alistCombustibleLubricanteComescuamaDTO.PromedioPonderado = PromedioPonderado;
            alistCombustibleLubricanteComescuamaDTO.SubPromedioParcial = SubPromedioParcial;
            alistCombustibleLubricanteComescuamaDTO.CargaId = CargaId;
            alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistCombustibleLubricanteComescuamaBL.AgregarRegistro(alistCombustibleLubricanteComescuamaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistCombustibleLubricanteComescuamaBL.EditarFormato(Id));
        }
        ////[AuthorizePermission(Formato: 157, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante2,
            decimal PromedioPonderado, decimal SubPromedioParcial)
        {
            AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO = new();
            alistCombustibleLubricanteComescuamaDTO.AlistamientoCombustibleLubricanteId = Id;
            alistCombustibleLubricanteComescuamaDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistCombustibleLubricanteComescuamaDTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            alistCombustibleLubricanteComescuamaDTO.PromedioPonderado = PromedioPonderado;
            alistCombustibleLubricanteComescuamaDTO.SubPromedioParcial = SubPromedioParcial;
            alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistCombustibleLubricanteComescuamaBL.ActualizarFormato(alistCombustibleLubricanteComescuamaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO = new();
            alistCombustibleLubricanteComescuamaDTO.AlistamientoCombustibleLubricanteId = Id;
            alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistCombustibleLubricanteComescuamaBL.EliminarFormato(alistCombustibleLubricanteComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        ////[AuthorizePermission(Formato: 157, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO = new();
            alistCombustibleLubricanteComescuamaDTO.CargaId = Id;
            alistCombustibleLubricanteComescuamaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (alistCombustibleLubricanteComescuamaBL.EliminarCarga(alistCombustibleLubricanteComescuamaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistCombustibleLubricanteComescuamaDTO> lista = new List<AlistCombustibleLubricanteComescuamaDTO>();
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

                    lista.Add(new AlistCombustibleLubricanteComescuamaDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoCombustibleLubricante2 = fila.GetCell(1).ToString(),
                        PromedioPonderado = decimal.Parse(fila.GetCell(2).ToString()),
                        SubPromedioParcial = decimal.Parse(fila.GetCell(3).ToString())
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
        ////[AuthorizePermission(Formato: 157, Permiso: 4)]//Registrar Masivo
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
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoCombustibleLubricante2", typeof(string)),
                    new DataColumn("PromedioPonderado", typeof(decimal)),
                    new DataColumn("SubPromedioParcial", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    decimal.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = alistCombustibleLubricanteComescuamaBL.InsertarDatos(dt, Fecha);
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
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComescuamaAlistCombustibleLubricante.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComescuamaAlistCombustibleLubricante.xlsx");
        }
    }

}

