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
    public class ComestreEjercicioTipoArmaMenorComestreController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();
        EjercicioTipoArmaMenorComestre ejercicioTipoArmaMenorComestreBL = new();

        EspecialidadGenericaPersonal especialidadGenericaPersonalBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        TipoArmamento tipoArmamentoBL = new();

        public ComestreEjercicioTipoArmaMenorComestreController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Ejercicios de Tiro con Armas Menores", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDTO = especialidadGenericaPersonalBL.ObtenerEspecialidadGenericaPersonals();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<TipoArmamentoDTO> tipoArmamentoDTO = tipoArmamentoBL.ObtenerTipoArmamentos();

            return Json(new
            {
                data1 = especialidadGenericaPersonalDTO,
                data2 = gradoPersonalMilitarDTO,
                data3 = tipoArmamentoDTO,
            });
        }

        public IActionResult CargaTabla()
        {
            List<EjercicioTipoArmaMenorComestreDTO> ejercicioTipoArmaMenorComestreDTO = ejercicioTipoArmaMenorComestreBL.ObtenerLista();
            return Json(new { data = ejercicioTipoArmaMenorComestreDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( int EspecialidadGenericaPersonalId, int GradoPersonalMilitarId, int TipoArmamentoId,  
            string FechaEjercicio, string Posicion, int DistanciaMetro, int CantidadTipo)
        {
            EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO = new();
            ejercicioTipoArmaMenorComestreDTO.EspecialidadGenericaPersonalId = EspecialidadGenericaPersonalId;
            ejercicioTipoArmaMenorComestreDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            ejercicioTipoArmaMenorComestreDTO.FechaEjercicio = FechaEjercicio;
            ejercicioTipoArmaMenorComestreDTO.TipoArmamentoId = TipoArmamentoId;
            ejercicioTipoArmaMenorComestreDTO.Posicion = Posicion;
            ejercicioTipoArmaMenorComestreDTO.DistanciaMetro = DistanciaMetro;
            ejercicioTipoArmaMenorComestreDTO.CantidadTipo = CantidadTipo;
            ejercicioTipoArmaMenorComestreDTO.Año = DateTime.Now.Year; ;
            ejercicioTipoArmaMenorComestreDTO.Mes = DateTime.Now.Month;
            ejercicioTipoArmaMenorComestreDTO.Dia = DateTime.Now.Day;
            ejercicioTipoArmaMenorComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioTipoArmaMenorComestreBL.AgregarRegistro(ejercicioTipoArmaMenorComestreDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(ejercicioTipoArmaMenorComestreBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int EjercicioTipoArmaMenorComestreId, int EspecialidadGenericaPersonalId, int GradoPersonalMilitarId, int TipoArmamentoId,
            string FechaEjercicio, string Posicion, int DistanciaMetro, int CantidadTipo)
        {
            EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO = new();
            ejercicioTipoArmaMenorComestreDTO.EjercicioTipoArmaMenorComestreId = EjercicioTipoArmaMenorComestreId;
            ejercicioTipoArmaMenorComestreDTO.EspecialidadGenericaPersonalId = EspecialidadGenericaPersonalId;
            ejercicioTipoArmaMenorComestreDTO.GradoPersonalMilitarId = GradoPersonalMilitarId;
            ejercicioTipoArmaMenorComestreDTO.FechaEjercicio = FechaEjercicio;
            ejercicioTipoArmaMenorComestreDTO.TipoArmamentoId = TipoArmamentoId;
            ejercicioTipoArmaMenorComestreDTO.Posicion = Posicion;
            ejercicioTipoArmaMenorComestreDTO.DistanciaMetro = DistanciaMetro;
            ejercicioTipoArmaMenorComestreDTO.CantidadTipo = CantidadTipo;
            ejercicioTipoArmaMenorComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = ejercicioTipoArmaMenorComestreBL.ActualizarFormato(ejercicioTipoArmaMenorComestreDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO = new();
            ejercicioTipoArmaMenorComestreDTO.EjercicioTipoArmaMenorComestreId = Id;
            ejercicioTipoArmaMenorComestreDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (ejercicioTipoArmaMenorComestreBL.EliminarFormato(ejercicioTipoArmaMenorComestreDTO) == true)
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

            List<EjercicioTipoArmaMenorComestreDTO> lista = new List<EjercicioTipoArmaMenorComestreDTO>();

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                lista.Add(new EjercicioTipoArmaMenorComestreDTO
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
            List<EjercicioTipoArmaMenorComestreDTO> lista = new List<EjercicioTipoArmaMenorComestreDTO>();
            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                lista.Add(new EjercicioTipoArmaMenorComestreDTO
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
                var estado = ejercicioTipoArmaMenorComestreBL.InsercionMasiva(lista);
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
            var Capitanias = ejercicioTipoArmaMenorComestreBL.ObtenerLista();
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