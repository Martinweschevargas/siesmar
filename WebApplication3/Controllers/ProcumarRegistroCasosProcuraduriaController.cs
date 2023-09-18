using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Procumar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Procumar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Procumar;
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
    public class ProcumarRegistroCasosProcuraduriaController : Controller
    {

        CapitaniaDAO capitaniaBL = new();
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        RegistroCasosProcuraduria registrocasosprocuraduriaBL = new();

        GradoPersonal gradopersonalBL = new();
        EspecialidadPersonal  especialidadPersonalBL = new();
        MateriaProcumar materiaprocumarBL = new();
        DistritoJudicial distritojudicialBL = new();
        InstanciaJudicial instanciajudicialBL = new();
        CasoExcepcional casoExcepcionalBL = new();
        EstadoProceso motivoterminocursoBL = new();

        //AreaProcumar areaProcumarBL = new();
        Carga cargaBL = new();
        public ProcumarRegistroCasosProcuraduriaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro de Casos de la Procuraduria", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            
            List<GradoPersonalDTO> gradoPersonalDTO = gradopersonalBL.ObtenerGradoPersonals();
            List<EspecialidadPersonalDTO> especialidadPersonalDTO = especialidadPersonalBL.ObtenerEspecialidadPersonals();
            List<MateriaProcumarDTO> materiaProcumarDTO = materiaprocumarBL.ObtenerMateriaProcumars();
            List<DistritoJudicialDTO> distritoJudicialDTO = distritojudicialBL.ObtenerDistritoJudiciales();
            List<InstanciaJudicialDTO> instanciaJudicialDTO = instanciajudicialBL.ObtenerInstanciaJudicials();
            List<CasoExcepcionalDTO> casoExcepcionalDTO = casoExcepcionalBL.ObtenerCasoExcepcionals();
            List<EstadoProcesoDTO> estadoProcesoDTO = motivoterminocursoBL.btenerEstadoProcesos();
            // List<MonedaDTO> monedaDTO = monedaBL.ObtenerMonedas(); se cambia a AreaProcumar
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroCasoProcuraduria");

            return Json(new { data1 = gradoPersonalDTO, data2 = especialidadPersonalDTO, data3 = materiaProcumarDTO,
            data4 = distritoJudicialDTO, data5 = instanciaJudicialDTO, data6 = casoExcepcionalDTO, data7 = estadoProcesoDTO,
            data8 = 0, data9 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroCasosProcuraduriaDTO> select = registrocasosprocuraduriaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(int AnioDemanda, string MesDemanda, string CodigoAreaProcumar,string NombreAbogado, string NroExpediente,
            string NroCodInterno,string NombreDemandante, string NombreDemandado, string CodigoGradoPersonal, string CodigoEspecialidadPersonal,
            string CodigoMateriaProcumar, string Petitorio, string CodigoDistritoJudicial, string CodigoInstanciaJudicial, string CodigoCasoExcepcional,
            string UltimoActuado, string CodigoEstadoProceso, string SentenciaEjecutoria,int AnioTerminoProceso, string MonedaId, int MontoPretencion,int CargaId)
        {
            RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO = new();
            registroCasosProcuraduriaDTO.AnioDemanda = AnioDemanda;
            registroCasosProcuraduriaDTO.MesDemanda = MesDemanda;
            registroCasosProcuraduriaDTO.CodigoAreaProcumar = CodigoAreaProcumar;
            registroCasosProcuraduriaDTO.NombreAbogado = NombreAbogado;
            registroCasosProcuraduriaDTO.NroExpediente = NroExpediente;
            registroCasosProcuraduriaDTO.NroCodInterno = NroCodInterno;
            registroCasosProcuraduriaDTO.NombreDemandante = NombreDemandante;
            registroCasosProcuraduriaDTO.NombreDemandado = NombreDemandado;
            registroCasosProcuraduriaDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            registroCasosProcuraduriaDTO.CodigoEspecialidadPersonal = CodigoEspecialidadPersonal;
            registroCasosProcuraduriaDTO.CodigoMateriaProcumar = CodigoMateriaProcumar;
            registroCasosProcuraduriaDTO.Petitorio = Petitorio;
            registroCasosProcuraduriaDTO.CodigoDistritoJudicial = CodigoDistritoJudicial;
            registroCasosProcuraduriaDTO.CodigoInstanciaJudicial = CodigoInstanciaJudicial;
            registroCasosProcuraduriaDTO.CodigoCasoExcepcional = CodigoCasoExcepcional;
            registroCasosProcuraduriaDTO.UltimoActuado = UltimoActuado;
            registroCasosProcuraduriaDTO.CodigoEstadoProceso = CodigoEstadoProceso;
            registroCasosProcuraduriaDTO.SentenciaEjecutoria = SentenciaEjecutoria;
            registroCasosProcuraduriaDTO.AnioTerminoProceso = AnioTerminoProceso;
            registroCasosProcuraduriaDTO.MonedaId = MonedaId;
            registroCasosProcuraduriaDTO.MontoPretencion = MontoPretencion;
            registroCasosProcuraduriaDTO.CargaId = CargaId;
            registroCasosProcuraduriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registrocasosprocuraduriaBL.AgregarRegistro(registroCasosProcuraduriaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registrocasosprocuraduriaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, int AnioDemanda, string MesDemanda, string CodigoAreaProcumar, string NombreAbogado, string NroExpediente,
            string NroCodInterno, string NombreDemandante, string NombreDemandado, string CodigoGradoPersonal, string CodigoEspecialidadPersonal,
            string CodigoMateriaProcumar, string Petitorio, string CodigoDistritoJudicial, string CodigoInstanciaJudicial, string CodigoCasoExcepcional,
            string UltimoActuado, string CodigoEstadoProceso, string SentenciaEjecutoria, int AnioTerminoProceso, string MonedaId, int MontoPretencion)
        {

            RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO = new();
            registroCasosProcuraduriaDTO.RegistroCasosProcuraduriaId = Id;
            registroCasosProcuraduriaDTO.AnioDemanda = AnioDemanda;
            registroCasosProcuraduriaDTO.MesDemanda = MesDemanda;
            registroCasosProcuraduriaDTO.CodigoAreaProcumar = CodigoAreaProcumar;
            registroCasosProcuraduriaDTO.NombreAbogado = NombreAbogado;
            registroCasosProcuraduriaDTO.NroExpediente = NroExpediente;
            registroCasosProcuraduriaDTO.NroCodInterno = NroCodInterno;
            registroCasosProcuraduriaDTO.NombreDemandante = NombreDemandante;
            registroCasosProcuraduriaDTO.NombreDemandado = NombreDemandado;
            registroCasosProcuraduriaDTO.CodigoGradoPersonal = CodigoGradoPersonal;
            registroCasosProcuraduriaDTO.CodigoEspecialidadPersonal = CodigoEspecialidadPersonal;
            registroCasosProcuraduriaDTO.CodigoMateriaProcumar = CodigoMateriaProcumar;
            registroCasosProcuraduriaDTO.Petitorio = Petitorio;
            registroCasosProcuraduriaDTO.CodigoDistritoJudicial = CodigoDistritoJudicial;
            registroCasosProcuraduriaDTO.CodigoInstanciaJudicial = CodigoInstanciaJudicial;
            registroCasosProcuraduriaDTO.CodigoCasoExcepcional = CodigoCasoExcepcional;
            registroCasosProcuraduriaDTO.UltimoActuado = UltimoActuado;
            registroCasosProcuraduriaDTO.CodigoEstadoProceso = CodigoEstadoProceso;
            registroCasosProcuraduriaDTO.SentenciaEjecutoria = SentenciaEjecutoria;
            registroCasosProcuraduriaDTO.AnioTerminoProceso = AnioTerminoProceso;
            registroCasosProcuraduriaDTO.MonedaId = MonedaId;
            registroCasosProcuraduriaDTO.MontoPretencion = MontoPretencion;
            registroCasosProcuraduriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registrocasosprocuraduriaBL.ActualizarFormato(registroCasosProcuraduriaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroCasosProcuraduriaDTO registroCasosProcuraduriaDTO = new();
            registroCasosProcuraduriaDTO.RegistroCasosProcuraduriaId = Id;
            registroCasosProcuraduriaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registrocasosprocuraduriaBL.EliminarFormato(registroCasosProcuraduriaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroCasosProcuraduriaDTO> lista = new List<RegistroCasosProcuraduriaDTO>();
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

                    lista.Add(new RegistroCasosProcuraduriaDTO
                    {
                        AnioDemanda = int.Parse(fila.GetCell(0).ToString()),
                        MesDemanda = fila.GetCell(1).ToString(),
                        CodigoAreaProcumar = fila.GetCell(2).ToString(),
                        NombreAbogado = fila.GetCell(3).ToString(),
                        NroExpediente = fila.GetCell(4).ToString(),
                        NroCodInterno = fila.GetCell(5).ToString(),
                        NombreDemandante = fila.GetCell(6).ToString(),
                        NombreDemandado = fila.GetCell(7).ToString(),
                        CodigoGradoPersonal = fila.GetCell(8).ToString(),
                        CodigoEspecialidadPersonal = fila.GetCell(9).ToString(),
                        CodigoMateriaProcumar = fila.GetCell(10).ToString(),
                        Petitorio = fila.GetCell(11).ToString(),
                        CodigoDistritoJudicial = fila.GetCell(12).ToString(),
                        CodigoInstanciaJudicial = fila.GetCell(13).ToString(),
                        CodigoCasoExcepcional = fila.GetCell(14).ToString(),
                        UltimoActuado = fila.GetCell(15).ToString(),
                        CodigoEstadoProceso = fila.GetCell(16).ToString(),
                        SentenciaEjecutoria = fila.GetCell(17).ToString(),
                        AnioTerminoProceso = int.Parse(fila.GetCell(18).ToString()),
                        MonedaId = fila.GetCell(19).ToString(),
                        MontoPretencion = decimal.Parse(fila.GetCell(20).ToString()),
 
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

            dt.Columns.AddRange(new DataColumn[22]
            {
                    new DataColumn("AnioDemanda", typeof(int)),
                    new DataColumn("MesDemanda", typeof(string)),
                    new DataColumn("CodigoAreaProcumar", typeof(string)),
                    new DataColumn("NombreAbogado", typeof(string)),
                    new DataColumn("NroExpediente", typeof(string)),
                    new DataColumn("NroCodInterno", typeof(string)),
                    new DataColumn("NombreDemandante", typeof(string)),
                    new DataColumn("NombreDemandado", typeof(string)),
                    new DataColumn("CodigoGradoPersonal", typeof(string)),
                    new DataColumn("CodigoEspecialidadPersonal", typeof(string)),
                    new DataColumn("CodigoMateriaProcumar", typeof(string)),
                    new DataColumn("Petitorio", typeof(string)),
                    new DataColumn("CodigoDistritoJudicial", typeof(string)),
                    new DataColumn("CodigoInstanciaJudicial", typeof(string)),
                    new DataColumn("CodigoCasoExcepcional", typeof(string)),
                    new DataColumn("UltimoActuado", typeof(string)),
                    new DataColumn("CodigoEstadoProceso", typeof(string)),
                    new DataColumn("SentenciaEjecutoria", typeof(string)),
                    new DataColumn("AnioTerminoProceso", typeof(int)),
                    new DataColumn("MonedaId", typeof(string)),
                    new DataColumn("MontoPretencion", typeof(decimal)),

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
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    fila.GetCell(11).ToString(),
                    fila.GetCell(12).ToString(),
                    fila.GetCell(13).ToString(),
                    fila.GetCell(14).ToString(),
                    fila.GetCell(15).ToString(),
                    fila.GetCell(16).ToString(),
                    fila.GetCell(17).ToString(),
                    int.Parse(fila.GetCell(18).ToString()),
                     fila.GetCell(19).ToString(),
                    decimal.Parse(fila.GetCell(20).ToString()),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = registrocasosprocuraduriaBL.InsertarDatos(dt);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ProcumarRegistroCasosProcuraduria.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ProcumarRegistroCasosProcuraduria.xlsx");
        }

    }

}