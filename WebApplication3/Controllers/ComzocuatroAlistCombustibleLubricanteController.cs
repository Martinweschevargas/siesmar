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
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class ComzocuatroAlistCombustibleLubricanteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistCombustibleLubricanteComzocuatro alistCombustibleLubricanteComzocuatroBL = new();

        UnidadNaval unidadNavalBL = new();

        AlistamientoCombustibleLubricante2 alistamientoCombustibleLubricante2BL = new();

        Carga cargaBL = new();
        public ComzocuatroAlistCombustibleLubricanteController(IWebHostEnvironment webHostEnvironment)
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
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoCombustibleLubricante");

            return Json(new { data1 = unidadNavalDTO, data2 = alistamientoCombustibleLubricante2DTO, data3 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<AlistCombustibleLubricanteComzocuatroDTO> select = alistCombustibleLubricanteComzocuatroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar( string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante2, decimal PromedioPonderado, decimal SubPromedioParcial, int CargaId)
        {
            AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO = new();
            alistCombustibleLubricanteComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistCombustibleLubricanteComzocuatroDTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            alistCombustibleLubricanteComzocuatroDTO.PromedioPonderado = PromedioPonderado;
            alistCombustibleLubricanteComzocuatroDTO.SubPromedioParcial = SubPromedioParcial;
            alistCombustibleLubricanteComzocuatroDTO.CargaId = CargaId;
            alistCombustibleLubricanteComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistCombustibleLubricanteComzocuatroBL.AgregarRegistro(alistCombustibleLubricanteComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistCombustibleLubricanteComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoUnidadNaval, string CodigoAlistamientoCombustibleLubricante2, decimal PromedioPonderado, decimal SubPromedioParcial)
        {
            AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO = new();
            alistCombustibleLubricanteComzocuatroDTO.AlistamientoCombustibleLubricanteId = Id;
            alistCombustibleLubricanteComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistCombustibleLubricanteComzocuatroDTO.CodigoAlistamientoCombustibleLubricante2 = CodigoAlistamientoCombustibleLubricante2;
            alistCombustibleLubricanteComzocuatroDTO.PromedioPonderado = PromedioPonderado;
            alistCombustibleLubricanteComzocuatroDTO.SubPromedioParcial = SubPromedioParcial;
            alistCombustibleLubricanteComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistCombustibleLubricanteComzocuatroBL.ActualizarFormato(alistCombustibleLubricanteComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistCombustibleLubricanteComzocuatroDTO alistCombustibleLubricanteComzocuatroDTO = new();
            alistCombustibleLubricanteComzocuatroDTO.AlistamientoCombustibleLubricanteId = Id;
            alistCombustibleLubricanteComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistCombustibleLubricanteComzocuatroBL.EliminarFormato(alistCombustibleLubricanteComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<AlistCombustibleLubricanteComzocuatroDTO> lista = new List<AlistCombustibleLubricanteComzocuatroDTO>();
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

                    lista.Add(new AlistCombustibleLubricanteComzocuatroDTO
                    {

                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoAlistamientoCombustibleLubricante2 = fila.GetCell(1).ToString(),
                        PromedioPonderado = int.Parse(fila.GetCell(2).ToString()),
                        SubPromedioParcial = int.Parse(fila.GetCell(3).ToString())

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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(string)),
                    new DataColumn("CodigoAlistamientoCombustibleLubricante2", typeof(string)),
                    new DataColumn("PromedioPonderado", typeof(int)),
                    new DataColumn("SubPromedioParcial", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(

                         fila.GetCell(0).ToString(),
                         fila.GetCell(1).ToString(),
                         int.Parse(fila.GetCell(2).ToString()),
                         int.Parse(fila.GetCell(3).ToString()),
                        User.obtenerUsuario());
            }
            var IND_OPERACION = alistCombustibleLubricanteComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistCombustibleLubricanteComzocuatroBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

       
    }

}

