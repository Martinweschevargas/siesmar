﻿using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comestre;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Formatos.Comestre;
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
    public class ComestreServicioSastreriaComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        ServicioSastreriaComestre servicioSastreriaComestreBL = new();

        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        Dependencia dependenciaBL = new ();
        TipoServicioSastreria tipoServicioSastreriaBL = new();


        public ComestreServicioSastreriaComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio de Sastreria", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<DependenciaDTO> dependenciaDTO = dependenciaBL.ObtenerDependencias();
            List<TipoServicioSastreriaDTO> tipoServicioSastreriaDTO = tipoServicioSastreriaBL.ObtenerTipoServicioSastrerias();


            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = especialidadGenericaPersonalDTO,
                data3 = dependenciaDTO,
                data4 = tipoServicioSastreriaDTO,

            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioSastreriaComestreDTO> servicioSastreriaComestreDTO = servicioSastreriaComestreBL.ObtenerLista();
            return Json(new { data = servicioSastreriaComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int EspecialidadGenericaPersonalId, int GradoPersonalMilitarId,   
            string Fecha, int CIPPersonal, int DependenciaId, string FechaIngreso, string FechaRecojo, int CIP
            , string SexoPersonal, int NumeroPrenda, int TipoServicioSastreriaId)
        {
            ServicioSastreriaComestreDTO servicioSastreriaComestreDTO = new();
            servicioSastreriaComestreDTO.FechaIngreso = FechaIngreso;
            servicioSastreriaComestreDTO.FechaRecojo = FechaRecojo;
            servicioSastreriaComestreDTO.CIP = CIP;
            servicioSastreriaComestreDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            servicioSastreriaComestreDTO.EspecialidadGenericaPersonalId = EspecialidadGenericaPersonalId;
            servicioSastreriaComestreDTO.SexoPersonal = SexoPersonal;
            servicioSastreriaComestreDTO.DependenciaId = DependenciaId;
            servicioSastreriaComestreDTO.NumeroPrenda = NumeroPrenda;
            servicioSastreriaComestreDTO.TipoServicioSastreriaId = TipoServicioSastreriaId;
            servicioSastreriaComestreDTO.Año = DateTime.Now.Year; ;
            servicioSastreriaComestreDTO.Mes = DateTime.Now.Month;
            servicioSastreriaComestreDTO.Dia = DateTime.Now.Day;
            servicioSastreriaComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioSastreriaComestreBL.AgregarRegistro(servicioSastreriaComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioSastreriaComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int ServicioSastreriaComestreId, int EspecialidadGenericaPersonalId, int GradoPersonalMilitarId,
            string Fecha, int CIPPersonal, int DependenciaId, string FechaIngreso, string FechaRecojo, int CIP
            , string SexoPersonal, int NumeroPrenda, int TipoServicioSastreriaId)
        {
            ServicioSastreriaComestreDTO servicioSastreriaComestreDTO = new();
            servicioSastreriaComestreDTO.ServicioSastreriaComestreId = ServicioSastreriaComestreId;
            servicioSastreriaComestreDTO.FechaIngreso = FechaIngreso;
            servicioSastreriaComestreDTO.FechaRecojo = FechaRecojo;
            servicioSastreriaComestreDTO.CIP = CIP;
            servicioSastreriaComestreDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            servicioSastreriaComestreDTO.EspecialidadGenericaPersonalId = EspecialidadGenericaPersonalId;
            servicioSastreriaComestreDTO.SexoPersonal = SexoPersonal;
            servicioSastreriaComestreDTO.DependenciaId = DependenciaId;
            servicioSastreriaComestreDTO.NumeroPrenda = NumeroPrenda;
            servicioSastreriaComestreDTO.TipoServicioSastreriaId = TipoServicioSastreriaId;
            servicioSastreriaComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioSastreriaComestreBL.ActualizarFormato(servicioSastreriaComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioSastreriaComestreDTO servicioSastreriaComestreDTO = new();
            servicioSastreriaComestreDTO.ServicioSastreriaComestreId = Id;
            servicioSastreriaComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioSastreriaComestreBL.EliminarFormato(servicioSastreriaComestreDTO) == true)
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

            List<ServicioSastreriaComestreDTO> lista = new List<ServicioSastreriaComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new ServicioSastreriaComestreDTO
                {/*
                    NombreActividadCultural = fila.GetCell(0).ToString(),
                    TipoActividadCulturalId = fila.GetCell(1).ToString(),
                    FechaInicioActCultural = fila.GetCell(2).ToString(),
                    FechaTerminoActCultural = fila.GetCell(3).ToString(),
                    LugarActCultural = fila.GetCell(4).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(5).ToString(),
                    NParticipantesActCultural = fila.GetCell(4).ToString(),
                    InversionActCultural = fila.GetCell(5).ToString()*/
                });
            }
            return StatusCode(StatusCodes.Status200OK, lista);
        }


        [HttpPost]
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
        {
            Stream stream = ArchivoExcel.OpenReadStream();
            var mensaje="";

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
            List<ServicioSastreriaComestreDTO> lista = new List<ServicioSastreriaComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new ServicioSastreriaComestreDTO
                {/*
                    NombreActividadCultural = fila.GetCell(0).ToString(),
                    TipoActividadCulturalId = fila.GetCell(1).ToString(),
                    FechaInicioActCultural = fila.GetCell(2).ToString(),
                    FechaTerminoActCultural = fila.GetCell(3).ToString(),
                    LugarActCultural = fila.GetCell(4).ToString(),
                    AuspiciadoresActCultural = fila.GetCell(5).ToString(),
                    NParticipantesActCultural = fila.GetCell(4).ToString(),
                    InversionActCultural = fila.GetCell(5).ToString(),
                    UsuarioIngresoRegistro = User.obtenerUsuario(),*/
                });
            }
            try
            {
                var estado = servicioSastreriaComestreBL.InsercionMasiva(lista);
                if (estado==true)
                {
                    mensaje = "ok";
                }
                else
                {
                    mensaje = "error";
                }
                 
            }
            catch(Exception e)
            {
                mensaje = e.Message;
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje });
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
            var Capitanias = servicioSastreriaComestreBL.ObtenerLista();
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