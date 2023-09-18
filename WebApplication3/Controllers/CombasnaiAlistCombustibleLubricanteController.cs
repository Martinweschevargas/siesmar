﻿using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Combasnai;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SmartBreadcrumbs.Attributes;
using System.Security.Claims;
using WebApplication3.Controllers;

namespace Marina.Siesmar.Presentacion.Controllers
{

    public class CombasnaiAlistCombustibleLubricanteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistCombustibleLubricanteCombasnai alistCombustibleLubricanteCombasnaiBL = new();

        UnidadNaval unidadNavalBL = new();
        AlistamientoCombustibleLubricante2 alistamientoCombustibleLubricante2BL = new();
        public CombasnaiAlistCombustibleLubricanteController(IWebHostEnvironment webHostEnvironment)
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

            return Json(new { data1 = unidadNavalDTO, data2 = alistamientoCombustibleLubricante2DTO });
        }

        public IActionResult CargaTabla()
        {
            List<AlistCombustibleLubricanteCombasnaiDTO> select = alistCombustibleLubricanteCombasnaiBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
         
            return View();
        }
        public ActionResult Insertar( int UnidadNavalId, int AlistamientoCombustibleLubricante2Id)
        {
            AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO = new();
            alistCombustibleLubricanteCombasnaiDTO.UnidadNavalId = UnidadNavalId;
            alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricante2Id = AlistamientoCombustibleLubricante2Id;
            alistCombustibleLubricanteCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistCombustibleLubricanteCombasnaiBL.AgregarRegistro(alistCombustibleLubricanteCombasnaiDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistCombustibleLubricanteCombasnaiBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int UnidadNavalId, int AlistamientoCombustibleLubricante2Id)
        {
            AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO = new();
            alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricanteId = Id;
            alistCombustibleLubricanteCombasnaiDTO.UnidadNavalId = UnidadNavalId;
            alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricante2Id = AlistamientoCombustibleLubricante2Id;
            alistCombustibleLubricanteCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistCombustibleLubricanteCombasnaiBL.ActualizarFormato(alistCombustibleLubricanteCombasnaiDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO = new();
            alistCombustibleLubricanteCombasnaiDTO.AlistamientoCombustibleLubricanteId = Id;
            alistCombustibleLubricanteCombasnaiDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistCombustibleLubricanteCombasnaiBL.EliminarFormato(alistCombustibleLubricanteCombasnaiDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
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

            List<AlistCombustibleLubricanteCombasnaiDTO> lista = new List<AlistCombustibleLubricanteCombasnaiDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new AlistCombustibleLubricanteCombasnaiDTO
                {
                    //NombreTemaEstudioInvestigacion = fila.GetCell(0).ToString(),
                    //TipoEstudioInvestigacionIds = fila.GetCell(1).ToString(),
                    //FechaInicio = fila.GetCell(2).ToString(),
                    //FechaTermino = fila.GetCell(3).ToString(),
                    //Responsable = fila.GetCell(4).ToString(),
                    //Solicitante = fila.GetCell(5).ToString()
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
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
            List<AlistCombustibleLubricanteCombasnaiDTO> lista = new List<AlistCombustibleLubricanteCombasnaiDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new AlistCombustibleLubricanteCombasnaiDTO
                {
                    //NombreTemaEstudioInvestigacion = fila.GetCell(0).ToString(),
                    //TipoEstudioInvestigacionIds = fila.GetCell(1).ToString(),
                    //FechaInicio = fila.GetCell(2).ToString(),
                    //FechaTermino = fila.GetCell(3).ToString(),
                    //Responsable = fila.GetCell(4).ToString(),
                    //Solicitante = fila.GetCell(5).ToString(),
                    //UsuarioIngresoRegistro = User.obtenerUsuario(),                    
                });
            }
            try
            {
                /*var estado = alistCombustibleLubricanteCombasnaiBL.InsertarDatos(lista);
				if (estado == true)
				{
					mensaje = "ok";
				}
				else
				{
					mensaje = "error";
				}
*/
            }
            catch (Exception e)
            {
                mensaje = e.Message;
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje });
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = alistCombustibleLubricanteCombasnaiBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        //public IActionResult ReportePMPIACR()
        //{
        //    //PROMEDIO MENSUAL DE PARTICIPANTES Y DE INVERSIÓN EN ACTIVIDADES CULTURALES REALIZADAS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPIACR.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePII()
        //{
        //    //PUBLICACIONES DE INTERÉS INSTITUCIONAL
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePII.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMCB()
        //{
        //    //PROMEDIO MENSUAL DE CONSULTAS BIBLIOGRÁFICAS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMCB.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMVAHM()
        //{
        //    //PROMEDIO MENSUAL DE VISITAS AL ARCHIVO HISTÓRICO DE LA MARINA
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVAHM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMVRMN()
        //{
        //    //PROMEDIO MENSUAL DE VISITAS REGISTRADAS A LOS MUSEOS NAVALES
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVRMN.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteTRC()
        //{
        //    //TRABAJOS DE RESTAURACIÓN Y/O CONSERVACIÓN
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteTRC.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteRMHPRM()
        //{
        //    //REPRESENTACIÓN Y/ O MONUMENTOS HISTORICOS EN EL PAIS RELACIONADOS A LA MARINA
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteRMHPRM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReporteAAD()
        //{
        //    //APOYO A LAS ACTIVIDADES DE DIFUSIÓN
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteAAD.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMPADRIM()
        //{
        //    //PROMEDIO MENSUAL DE PARTICIPANTES A ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPADRIM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    //var Capitanias = capitaniaBL.ObtenerCapitanias();
        //    LocalReport localReport = new LocalReport(path);
        //    //localReport.AddDataSource("Capitania", Capitanias);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}

        //public IActionResult ReportePMPOADRIM()
        //{
        //    //PROMEDIO MENSUAL DE PARTICIPANTES A OTRAS ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
        //    string mimtype = "";
        //    int extension = 1;
        //    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPOADRIM.rdlc";
        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    parameters.Add("rpt1", "Welcome to FoxLearn");
        //    var estudioInvestigacionesHistoricasNavales = documentoIntelFrenteInternoBL.ObtenerLista();
        //    LocalReport localReport = new LocalReport(path);
        //    localReport.AddDataSource("EstudioInvestigacionHistoricasNavales", estudioInvestigacionesHistoricasNavales);
        //    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
        //    return File(result.MainStream, "application/pdf");
        //}


    }
}

//public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
//{
//    Stream stream = ArchivoExcel.OpenReadStream();
//    var mensaje = "";

//    IWorkbook MiExcel = null;

//    if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
//    {
//        MiExcel = new XSSFWorkbook(stream);
//    }
//    else
//    {
//        MiExcel = new HSSFWorkbook(stream);
//    }
//    ISheet HojaExcel = MiExcel.GetSheetAt(0);
//    int cantidadFilas = HojaExcel.LastRowNum;
//    List<AlistCombustibleLubricanteCombasnaiDTO> lista = new List<AlistCombustibleLubricanteCombasnaiDTO>();
//    for (int i = 1; i <= cantidadFilas; i++)
//    {
//        IRow fila = HojaExcel.GetRow(i);
//        lista.Add(new AlistCombustibleLubricanteCombasnaiDTO
//        {
//            //NombreTemaEstudioInvestigacion = fila.GetCell(0).ToString(),
//            //TipoEstudioInvestigacionIds = fila.GetCell(1).ToString(),
//            //FechaInicio = fila.GetCell(2).ToString(),
//            //FechaTermino = fila.GetCell(3).ToString(),
//            //Responsable = fila.GetCell(4).ToString(),
//            //Solicitante = fila.GetCell(5).ToString(),
//            //UsuarioIngresoRegistro = User.obtenerUsuario(),                    
//        });
//    }
//    try
//    {
//        var estado = alistCombustibleLubricanteCombasnaiBL.InsertarDatos(lista);
//        if (estado == true)
//        {
//            mensaje = "ok";
//        }
//        else
//        {
//            mensaje = "error";
//        }

//    }
//    catch (Exception e)
//    {
//        mensaje = e.Message;
//    }
//    return StatusCode(StatusCodes.Status200OK, new { mensaje });
//}

//public IActionResult ReporteEIHN()
//{
//    //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
//    string mimtype = "";
//    //int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    var estudioInvestigacionesHistoricasNavales = alistCombustibleLubricanteCombasnaiBL.ObtenerLista();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
//    var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMPIACR()
//{
//    //PROMEDIO MENSUAL DE PARTICIPANTES Y DE INVERSIÓN EN ACTIVIDADES CULTURALES REALIZADAS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPIACR.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePII()
//{
//    //PUBLICACIONES DE INTERÉS INSTITUCIONAL
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePII.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMCB()
//{
//    //PROMEDIO MENSUAL DE CONSULTAS BIBLIOGRÁFICAS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMCB.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMVAHM()
//{
//    //PROMEDIO MENSUAL DE VISITAS AL ARCHIVO HISTÓRICO DE LA MARINA
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVAHM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMVRMN()
//{
//    //PROMEDIO MENSUAL DE VISITAS REGISTRADAS A LOS MUSEOS NAVALES
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMVRMN.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReporteTRC()
//{
//    //TRABAJOS DE RESTAURACIÓN Y/O CONSERVACIÓN
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteTRC.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReporteRMHPRM()
//{
//    //REPRESENTACIÓN Y/ O MONUMENTOS HISTORICOS EN EL PAIS RELACIONADOS A LA MARINA
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteRMHPRM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReporteAAD()
//{
//    //APOYO A LAS ACTIVIDADES DE DIFUSIÓN
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReporteAAD.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMPADRIM()
//{
//    //PROMEDIO MENSUAL DE PARTICIPANTES A ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPADRIM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    //var Capitanias = capitaniaBL.ObtenerCapitanias();
//    LocalReport localReport = new LocalReport(path);
//    //localReport.AddDataSource("Capitania", Capitanias);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}

//public IActionResult ReportePMPOADRIM()
//{
//    //PROMEDIO MENSUAL DE PARTICIPANTES A OTRAS ACTIVIDADES DE DIFUSIÓN DE REALIDAD E INTERESES MARITIMOS
//    string mimtype = "";
//    int extension = 1;
//    var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\ReportePMPOADRIM.rdlc";
//    Dictionary<string, string> parameters = new Dictionary<string, string>();
//    parameters.Add("rpt1", "Welcome to FoxLearn");
//    var estudioInvestigacionesHistoricasNavales = documentoIntelFrenteInternoBL.ObtenerLista();
//    LocalReport localReport = new LocalReport(path);
//    localReport.AddDataSource("EstudioInvestigacionHistoricasNavales", estudioInvestigacionesHistoricasNavales);
//    var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
//    return File(result.MainStream, "application/pdf");
//}


