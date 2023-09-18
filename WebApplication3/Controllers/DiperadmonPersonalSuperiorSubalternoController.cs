using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Diperadmon;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon;
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
    public class DiperadmonPersonalSuperiorSubalternoController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        PersonalSuperiorSubalternoDAO personalsupsubBL = new();

        GradoPersonalMilitar gradopersonalmBL = new();
        Dependencia dependenciaBL = new();
        GradoEstudioAlcanzado gradoEstudioAlcanzadoBL = new();
        SistemaPension sistemaPensionBL = new();
        EspecialidadGenericaPersonal especialidadgenericaBL = new();
        DepartamentoUbigeo departamentoBL = new();
        ProvinciaUbigeo provinciaBL = new();
        DistritoUbigeo distritoBL = new();
        Procedencia procedenciaBL = new();
        
        Carga cargaBL = new();
        public DiperadmonPersonalSuperiorSubalternoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Personal Militar Superior y Subalterno", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradopersonalmBL.ObtenerGradoPersonalMilitars();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<GradoEstudioAlcanzadoDTO> gradoEstudioAlcanzadoDTO = gradoEstudioAlcanzadoBL.ObtenerGradoEstudioAlcanzados();
            List<SistemaPensionDTO> sistemaPensionDTO = sistemaPensionBL.ObtenerSistemaPensions();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadgenericaBL.ObtenerEspecialidadGenericaPersonals();
            List<DepartamentoUbigeoDTO> departamentoUbigeoDTO = departamentoBL.ObtenerDepartamentoUbigeos();
            List<ProvinciaUbigeoDTO> provinciaUbigeoDTO = provinciaBL.ObtenerProvinciaUbigeos();
            List<DistritoUbigeoDTO> distritoUbigeoDTO = distritoBL.ObtenerDistritoUbigeos();
            List<ProcedenciaDTO> procedenciaDTO = procedenciaBL.ObtenerProcedencias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PersonalSuperiorSubalterno");

            return Json(new { data1 = gradoPersonalMilitarDTO, data2 = dependenciaDTO, data3 = gradoEstudioAlcanzadoDTO, data4 = sistemaPensionDTO,
                data5 = especialidadGenericaPersonalDTO, data6 = distritoUbigeoDTO,data7 = provinciaUbigeoDTO,  data8 = departamentoUbigeoDTO,
                data9 = listaCargas,
                data10 = procedenciaDTO
            });
        }

        public IActionResult CargaTabla()
        {
            List<PersonalSuperiorSubalternoDTO> select = personalsupsubBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string DNIPSupSub, string CodigoProcedencia, string CodigoGradoPersonalMilitar,
           string SexoPSupSub, string UbigeoNacimiento, string FechaNacimientoPSupSub, string UbigeoLabora,
           string CodigoDependencia, string FechaIngresoDepPSupSub, string EstadoCivilPSupSub, string CodigoGradoEstudioAlcanzado,
           string CodigoSistemaPension, string CodigoEspecialidadGenericaPersonal, string FechaIngresoInstitucionPSupSub, string FechaAltaPSupSub,
           string FechaUltimoAscensoPSupSub,int CargaId)
        {
            PersonalSuperiorSubalternoDTO personalSupSubDTO = new();
            personalSupSubDTO.DNIPSupSub = DNIPSupSub;
            personalSupSubDTO.CodigoProcedencia  = CodigoProcedencia;
            personalSupSubDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            personalSupSubDTO.Sexo = SexoPSupSub;
            personalSupSubDTO.UbigeoNacimiento = UbigeoNacimiento;
            personalSupSubDTO.FechaNacimientoPSupSub = FechaNacimientoPSupSub;
            personalSupSubDTO.UbigeoLabora = UbigeoLabora;
            personalSupSubDTO.CodigoDependencia = CodigoDependencia;
            personalSupSubDTO.FechaIngresoDepPSupSub = FechaIngresoDepPSupSub;
            personalSupSubDTO.EstadoCivilPSupSub = EstadoCivilPSupSub;
            personalSupSubDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            personalSupSubDTO.CodigoSistemaPension = CodigoSistemaPension;
            personalSupSubDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            personalSupSubDTO.FechaIngresoInstitucion = FechaIngresoInstitucionPSupSub;
            personalSupSubDTO.FechaAltaPSupSub = FechaAltaPSupSub;
            personalSupSubDTO.FechaUltimoAscensoPSupSub = FechaUltimoAscensoPSupSub;
            personalSupSubDTO.CargaId = CargaId;
            personalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalsupsubBL.AgregarRegistro(personalSupSubDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(personalsupsubBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string DNIPSupSub, string CodigoProcedencia, string CodigoGradoPersonalMilitar,
           string SexoPSupSub, string UbigeoNacimiento, string FechaNacimientoPSupSub, string UbigeoLabora,
           string CodigoDependencia, string FechaIngresoDepPSupSub, string EstadoCivilPSupSub, string CodigoGradoEstudioAlcanzado,
           string CodigoSistemaPension, string CodigoEspecialidadGenericaPersonal, string FechaIngresoInstitucionPSupSub, string FechaAltaPSupSub,
           string FechaUltimoAscensoPSupSub)
        {
            PersonalSuperiorSubalternoDTO personalSupSubDTO = new();
            personalSupSubDTO.PersonalSuperiorSubalternoId = Id;
            personalSupSubDTO.DNIPSupSub = DNIPSupSub;
            personalSupSubDTO.CodigoProcedencia = CodigoProcedencia;
            personalSupSubDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            personalSupSubDTO.Sexo = SexoPSupSub;
            personalSupSubDTO.UbigeoNacimiento = UbigeoNacimiento;
            personalSupSubDTO.FechaNacimientoPSupSub = FechaNacimientoPSupSub;
            personalSupSubDTO.UbigeoLabora = UbigeoLabora;
            personalSupSubDTO.CodigoDependencia = CodigoDependencia;
            personalSupSubDTO.FechaIngresoDepPSupSub = FechaIngresoDepPSupSub;
            personalSupSubDTO.EstadoCivilPSupSub = EstadoCivilPSupSub;
            personalSupSubDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            personalSupSubDTO.CodigoSistemaPension = CodigoSistemaPension;
            personalSupSubDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            personalSupSubDTO.FechaIngresoInstitucion = FechaIngresoInstitucionPSupSub;
            personalSupSubDTO.FechaAltaPSupSub = FechaAltaPSupSub;
            personalSupSubDTO.FechaUltimoAscensoPSupSub = FechaUltimoAscensoPSupSub;
            personalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalsupsubBL.ActualizaFormato(personalSupSubDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PersonalSuperiorSubalternoDTO personalSupSubDTO = new();
            personalSupSubDTO.PersonalSuperiorSubalternoId = Id;
            personalSupSubDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalsupsubBL.EliminarFormato(personalSupSubDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PersonalSuperiorSubalternoDTO> lista = new List<PersonalSuperiorSubalternoDTO>();
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

                    lista.Add(new PersonalSuperiorSubalternoDTO
                    {
                        DNIPSupSub = fila.GetCell(0).ToString(),
                        CodigoProcedencia = fila.GetCell(1).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(2).ToString(),
                        Sexo = fila.GetCell(3).ToString(),
                        UbigeoNacimiento = fila.GetCell(4).ToString(),
                        FechaNacimientoPSupSub = fila.GetCell(5).ToString(),
                        UbigeoLabora = fila.GetCell(6).ToString(),
                        CodigoDependencia = fila.GetCell(7).ToString(),
                        FechaIngresoDepPSupSub = fila.GetCell(8).ToString(),
                        EstadoCivilPSupSub = fila.GetCell(9).ToString(),
                        CodigoGradoEstudioAlcanzado = fila.GetCell(10).ToString(),
                        CodigoSistemaPension = fila.GetCell(11).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(12).ToString(),
                        FechaIngresoInstitucion = fila.GetCell(13).ToString(),
                        FechaAltaPSupSub = fila.GetCell(14).ToString(),
                        FechaUltimoAscensoPSupSub = fila.GetCell(15).ToString()

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

            dt.Columns.AddRange(new DataColumn[17]
            {
                    new DataColumn("DNIPSupSub", typeof(string)),
                    new DataColumn("CodigoProcedencia", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SexoPSupSub", typeof(string)),
                    new DataColumn("UbigeoNacimiento", typeof(string)),
                    new DataColumn("FechaNacimientoPSupSub", typeof(string)),
                    new DataColumn("UbigeoLabora", typeof(string)),
                    new DataColumn("CodigoDependencia", typeof(string)),
                    new DataColumn("FechaIngresoDepPSupSub", typeof(string)),
                    new DataColumn("EstadoCivilPSupSub", typeof(string)),
                    new DataColumn("CodigoGradoEstudioAlcanzado", typeof(string)),
                    new DataColumn("CodigoSistemaPension", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("FechaIngresoInstitucionPSupSub", typeof(string)),
                    new DataColumn("FechaAltaPSupSub", typeof(string)),
                    new DataColumn("FechaUltimoAscensoPSupSub", typeof(string)),
 
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(8).ToString()),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(13).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(14).ToString()),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(15).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = personalsupsubBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }



        public IActionResult ReporteDPSS(int? CargaId = null)
        {

            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diperadmon\\PersonalSuperiorSubalterno.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var personalcivil = personalsupsubBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("PersonalSuperiorSubalterno", personalcivil);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiperadmonPersonalSuperiorSubalterno.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiperadmonPersonalSuperiorSubalterno.xlsx");
        }
    }

}