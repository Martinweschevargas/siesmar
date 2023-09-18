using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Jemgemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Jemgemar;
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

    public class JemgemarArchivoRelacionTipoReunionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        ArchivoRelacionTipoReunion archivoRelacionTipoReunionBL = new();
        PaisUbigeoDAO paisUbigeoBL = new();
        Carga cargaBL = new();

        public JemgemarArchivoRelacionTipoReunionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Archivo para Relaciones Bilaterales y Multilaterales por tipo de Reunión", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<PaisUbigeoDTO> paisUbigeoDTO = paisUbigeoBL.ObtenerPaisUbigeos();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ArchivoRelacionTipoReunion");
            return Json(new { 
                data1 = paisUbigeoDTO,
                data2 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ArchivoRelacionTipoReunionDTO> select = archivoRelacionTipoReunionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoReunion, string NumericoPais, string CondicionPais,  string NroReunion, int NroParticipantes,
           int NroDiasRelacionReunion, decimal GastosRelacionReunion, string Observaciones, int AFPersonal, int AFInteligencia, int AFOperacionEntrenamiento,
           int AFLogistica, int AFTelematica, int AFInstruccion,int AFAccionCivica, int AFCienciaTecnologia, int AFTerrorismoNarcotrafico, int AFMedioAmbiente,
           int APPersonal, int APInteligencia, int APOperacionEntrenamiento, int APLogistica, int APTelematica, int APInstruccion, int APAccionCivica,
           int APCienciaTecnologia, int APTerrorismoNarcotrafico, int APMedioAmbiente, int AEPersonal, int AEInteligencia, int AEOperacionEntrenamiento,
           int AELogistica, int AETelematica,int  AEInstruccion, int AEAccionCivica, int AECienciaTecnologia, int AETerrorismoNarcotrafico, int AEMedioAmbiente, 
           int CargaId, string Fecha)
        {
            ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO = new();
            archivoRelacionTipoReunionDTO.CodigoReunion = CodigoReunion;
            archivoRelacionTipoReunionDTO.NumericoPais = NumericoPais;
            archivoRelacionTipoReunionDTO.CondicionPais = CondicionPais;
            archivoRelacionTipoReunionDTO.NroReunion = NroReunion;
            archivoRelacionTipoReunionDTO.NroParticipantes = NroParticipantes;
            archivoRelacionTipoReunionDTO.NroDiasRelacionReunion = NroDiasRelacionReunion;
            archivoRelacionTipoReunionDTO.GastosRelacionReunion = GastosRelacionReunion;
            archivoRelacionTipoReunionDTO.Observaciones = Observaciones;
            archivoRelacionTipoReunionDTO.AFPersonal = AFPersonal;
            archivoRelacionTipoReunionDTO.AFInteligencia = AFInteligencia;
            archivoRelacionTipoReunionDTO.AFOperacionEntrenamiento = AFOperacionEntrenamiento;
            archivoRelacionTipoReunionDTO.AFLogistica = AFLogistica;
            archivoRelacionTipoReunionDTO.AFTelematica = AFTelematica;
            archivoRelacionTipoReunionDTO.AFInstruccion = AFInstruccion;
            archivoRelacionTipoReunionDTO.AFAccionCivica = AFAccionCivica;
            archivoRelacionTipoReunionDTO.AFCienciaTecnologia = AFCienciaTecnologia;
            archivoRelacionTipoReunionDTO.AFTerrorismoNarcotrafico = AFTerrorismoNarcotrafico;
            archivoRelacionTipoReunionDTO.AFMedioAmbiente = AFMedioAmbiente;
            archivoRelacionTipoReunionDTO.APPersonal = APPersonal;
            archivoRelacionTipoReunionDTO.APInteligencia = APInteligencia;
            archivoRelacionTipoReunionDTO.APOperacionEntrenamiento = APOperacionEntrenamiento;
            archivoRelacionTipoReunionDTO.APLogistica = APLogistica;
            archivoRelacionTipoReunionDTO.APTelematica = APTelematica;
            archivoRelacionTipoReunionDTO.APInstruccion = APInstruccion;
            archivoRelacionTipoReunionDTO.APAccionCivica = APAccionCivica;
            archivoRelacionTipoReunionDTO.APCienciaTecnologia = APCienciaTecnologia;
            archivoRelacionTipoReunionDTO.APTerrorismoNarcotrafico = APTerrorismoNarcotrafico;
            archivoRelacionTipoReunionDTO.APMedioAmbiente = APMedioAmbiente;
            archivoRelacionTipoReunionDTO.AEPersonal = AEPersonal;
            archivoRelacionTipoReunionDTO.AEInteligencia = AEInteligencia;
            archivoRelacionTipoReunionDTO.AEOperacionEntrenamiento = AEOperacionEntrenamiento;
            archivoRelacionTipoReunionDTO.AELogistica = AELogistica;
            archivoRelacionTipoReunionDTO.AETelematica = AETelematica;
            archivoRelacionTipoReunionDTO.AEInstruccion = AEInstruccion;
            archivoRelacionTipoReunionDTO.AEAccionCivica = AEAccionCivica;
            archivoRelacionTipoReunionDTO.AECienciaTecnologia = AECienciaTecnologia;
            archivoRelacionTipoReunionDTO.AETerrorismoNarcotrafico = AETerrorismoNarcotrafico;
            archivoRelacionTipoReunionDTO.AEMedioAmbiente = AEMedioAmbiente;
            archivoRelacionTipoReunionDTO.CargaId = CargaId;
            archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoRelacionTipoReunionBL.AgregarRegistro(archivoRelacionTipoReunionDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(archivoRelacionTipoReunionBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoReunion, string NumericoPais, string CondicionPais, string NroReunion, int NroParticipantes,
           int NroDiasRelacionReunion, decimal GastosRelacionReunion, string Observaciones, int AFPersonal, int AFInteligencia, int AFOperacionEntrenamiento,
           int AFLogistica, int AFTelematica, int AFInstruccion, int AFAccionCivica, int AFCienciaTecnologia, int AFTerrorismoNarcotrafico, int AFMedioAmbiente,
           int APPersonal, int APInteligencia, int APOperacionEntrenamiento, int APLogistica, int APTelematica, int APInstruccion, int APAccionCivica,
           int APCienciaTecnologia, int APTerrorismoNarcotrafico, int APMedioAmbiente, int AEPersonal, int AEInteligencia, int AEOperacionEntrenamiento,
           int AELogistica, int AETelematica, int AEInstruccion, int AEAccionCivica, int AECienciaTecnologia, int AETerrorismoNarcotrafico, int AEMedioAmbiente)
        {
            ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO = new();
            archivoRelacionTipoReunionDTO.ArchivoRelacionTipoReunionId = Id;
            archivoRelacionTipoReunionDTO.CodigoReunion = CodigoReunion;
            archivoRelacionTipoReunionDTO.NumericoPais = NumericoPais;
            archivoRelacionTipoReunionDTO.CondicionPais = CondicionPais;
            archivoRelacionTipoReunionDTO.NroReunion = NroReunion;
            archivoRelacionTipoReunionDTO.NroParticipantes = NroParticipantes;
            archivoRelacionTipoReunionDTO.NroDiasRelacionReunion = NroDiasRelacionReunion;
            archivoRelacionTipoReunionDTO.GastosRelacionReunion = GastosRelacionReunion;
            archivoRelacionTipoReunionDTO.Observaciones = Observaciones;
            archivoRelacionTipoReunionDTO.AFPersonal = AFPersonal;
            archivoRelacionTipoReunionDTO.AFInteligencia = AFInteligencia;
            archivoRelacionTipoReunionDTO.AFOperacionEntrenamiento = AFOperacionEntrenamiento;
            archivoRelacionTipoReunionDTO.AFLogistica = AFLogistica;
            archivoRelacionTipoReunionDTO.AFTelematica = AFTelematica;
            archivoRelacionTipoReunionDTO.AFInstruccion = AFInstruccion;
            archivoRelacionTipoReunionDTO.AFAccionCivica = AFAccionCivica;
            archivoRelacionTipoReunionDTO.AFCienciaTecnologia = AFCienciaTecnologia;
            archivoRelacionTipoReunionDTO.AFTerrorismoNarcotrafico = AFTerrorismoNarcotrafico;
            archivoRelacionTipoReunionDTO.AFMedioAmbiente = AFMedioAmbiente;
            archivoRelacionTipoReunionDTO.APPersonal = APPersonal;
            archivoRelacionTipoReunionDTO.APInteligencia = APInteligencia;
            archivoRelacionTipoReunionDTO.APOperacionEntrenamiento = APOperacionEntrenamiento;
            archivoRelacionTipoReunionDTO.APLogistica = APLogistica;
            archivoRelacionTipoReunionDTO.APTelematica = APTelematica;
            archivoRelacionTipoReunionDTO.APInstruccion = APInstruccion;
            archivoRelacionTipoReunionDTO.APAccionCivica = APAccionCivica;
            archivoRelacionTipoReunionDTO.APCienciaTecnologia = APCienciaTecnologia;
            archivoRelacionTipoReunionDTO.APTerrorismoNarcotrafico = APTerrorismoNarcotrafico;
            archivoRelacionTipoReunionDTO.APMedioAmbiente = APMedioAmbiente;
            archivoRelacionTipoReunionDTO.AEPersonal = AEPersonal;
            archivoRelacionTipoReunionDTO.AEInteligencia = AEInteligencia;
            archivoRelacionTipoReunionDTO.AEOperacionEntrenamiento = AEOperacionEntrenamiento;
            archivoRelacionTipoReunionDTO.AELogistica = AELogistica;
            archivoRelacionTipoReunionDTO.AETelematica = AETelematica;
            archivoRelacionTipoReunionDTO.AEInstruccion = AEInstruccion;
            archivoRelacionTipoReunionDTO.AEAccionCivica = AEAccionCivica;
            archivoRelacionTipoReunionDTO.AECienciaTecnologia = AECienciaTecnologia;
            archivoRelacionTipoReunionDTO.AETerrorismoNarcotrafico = AETerrorismoNarcotrafico;
            archivoRelacionTipoReunionDTO.AEMedioAmbiente = AEMedioAmbiente;
            archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = archivoRelacionTipoReunionBL.ActualizarFormato(archivoRelacionTipoReunionDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO = new();
            archivoRelacionTipoReunionDTO.ArchivoRelacionTipoReunionId = Id;
            archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoRelacionTipoReunionBL.EliminarFormato(archivoRelacionTipoReunionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ArchivoRelacionTipoReunionDTO archivoRelacionTipoReunionDTO = new();
            archivoRelacionTipoReunionDTO.CargaId = Id;
            archivoRelacionTipoReunionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (archivoRelacionTipoReunionBL.EliminarCarga(archivoRelacionTipoReunionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ArchivoRelacionTipoReunionDTO> lista = new List<ArchivoRelacionTipoReunionDTO>();
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

                        lista.Add(new ArchivoRelacionTipoReunionDTO
                    {
                        CodigoReunion = fila.GetCell(0).ToString(),
                        NumericoPais = fila.GetCell(1).ToString(),
                        CondicionPais = fila.GetCell(2).ToString(),
                        NroReunion = fila.GetCell(3).ToString(),
                        NroParticipantes = int.Parse(fila.GetCell(4).ToString()),
                        NroDiasRelacionReunion = int.Parse(fila.GetCell(5).ToString()),
                        GastosRelacionReunion = decimal.Parse(fila.GetCell(6).ToString()),
                        Observaciones = fila.GetCell(7).ToString(),
                        AFPersonal = int.Parse(fila.GetCell(8).ToString()),
                        AFInteligencia = int.Parse(fila.GetCell(9).ToString()),
                        AFOperacionEntrenamiento = int.Parse(fila.GetCell(10).ToString()),
                        AFLogistica = int.Parse(fila.GetCell(11).ToString()),
                        AFTelematica = int.Parse(fila.GetCell(12).ToString()),
                        AFInstruccion = int.Parse(fila.GetCell(13).ToString()),
                        AFAccionCivica = int.Parse(fila.GetCell(14).ToString()),
                        AFCienciaTecnologia = int.Parse(fila.GetCell(15).ToString()),
                        AFTerrorismoNarcotrafico = int.Parse(fila.GetCell(16).ToString()),
                        AFMedioAmbiente = int.Parse(fila.GetCell(17).ToString()),
                        APPersonal = int.Parse(fila.GetCell(18).ToString()),
                        APInteligencia = int.Parse(fila.GetCell(19).ToString()),
                        APOperacionEntrenamiento = int.Parse(fila.GetCell(20).ToString()),
                        APLogistica = int.Parse(fila.GetCell(21).ToString()),
                        APTelematica = int.Parse(fila.GetCell(22).ToString()),
                        APInstruccion = int.Parse(fila.GetCell(23).ToString()),
                        APAccionCivica = int.Parse(fila.GetCell(24).ToString()),
                        APCienciaTecnologia = int.Parse(fila.GetCell(25).ToString()),
                        APTerrorismoNarcotrafico = int.Parse(fila.GetCell(26).ToString()),
                        APMedioAmbiente = int.Parse(fila.GetCell(27).ToString()),
                        AEPersonal = int.Parse(fila.GetCell(28).ToString()),
                        AEInteligencia = int.Parse(fila.GetCell(29).ToString()),
                        AEOperacionEntrenamiento = int.Parse(fila.GetCell(30).ToString()),
                        AELogistica = int.Parse(fila.GetCell(31).ToString()),
                        AETelematica = int.Parse(fila.GetCell(32).ToString()),
                        AEInstruccion = int.Parse(fila.GetCell(33).ToString()),
                        AEAccionCivica = int.Parse(fila.GetCell(34).ToString()),
                        AECienciaTecnologia = int.Parse(fila.GetCell(35).ToString()),
                        AETerrorismoNarcotrafico = int.Parse(fila.GetCell(36).ToString()),
                        AEMedioAmbiente = int.Parse(fila.GetCell(37).ToString())
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
        //Registrar Masivo[AuthorizePermission(Formato: 43, Permiso: 4)]
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

            dt.Columns.AddRange(new DataColumn[39]
            {
                    new DataColumn("CodigoReunion", typeof(string)),
                    new DataColumn("NumericoPais", typeof(string)),
                    new DataColumn("CondicionPais", typeof(string)),
                    new DataColumn("NroReunion", typeof(string)),
                    new DataColumn("NroParticipantes", typeof(int)),
                    new DataColumn("NroDiasRelacionReunion", typeof(int)),
                    new DataColumn("GastosRelacionReunion", typeof(decimal)),
                    new DataColumn("Observaciones", typeof(string)),
                    new DataColumn("AFPersonal", typeof(int)),
                    new DataColumn("AFInteligencia", typeof(int)),
                    new DataColumn("AFOperacionEntrenamiento", typeof(int)),
                    new DataColumn("AFLogistica", typeof(int)),
                    new DataColumn("AFTelematica", typeof(int)),
                    new DataColumn("AFInstruccion", typeof(int)),
                    new DataColumn("AFAccionCivica", typeof(int)),
                    new DataColumn("AFCienciaTecnologia", typeof(int)),
                    new DataColumn("AFTerrorismoNarcotrafico", typeof(int)),
                    new DataColumn("AFMedioAmbiente", typeof(int)),
                    new DataColumn("APPersonal", typeof(int)),
                    new DataColumn("APInteligencia", typeof(int)),
                    new DataColumn("APOperacionEntrenamiento", typeof(int)),
                    new DataColumn("APLogistica", typeof(int)),
                    new DataColumn("APTelematica", typeof(int)),
                    new DataColumn("APInstruccion", typeof(int)),
                    new DataColumn("APAccionCivica", typeof(int)),
                    new DataColumn("APCienciaTecnologia", typeof(int)),
                    new DataColumn("APTerrorismoNarcotrafico", typeof(int)),
                    new DataColumn("APMedioAmbiente", typeof(int)),
                    new DataColumn("AEPersonal", typeof(int)),
                    new DataColumn("AEInteligencia", typeof(int)),
                    new DataColumn("AEOperacionEntrenamiento", typeof(int)),
                    new DataColumn("AELogistica", typeof(int)),
                    new DataColumn("AETelematica", typeof(int)),
                    new DataColumn("AEInstruccion", typeof(int)),
                    new DataColumn("AEAccionCivica", typeof(int)),
                    new DataColumn("AECienciaTecnologia", typeof(int)),
                    new DataColumn("AETerrorismoNarcotrafico", typeof(int)),
                    new DataColumn("AEMedioAmbiente", typeof(int)),
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
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    int.Parse(fila.GetCell(10).ToString()),
                    int.Parse(fila.GetCell(11).ToString()),
                    int.Parse(fila.GetCell(12).ToString()),
                    int.Parse(fila.GetCell(13).ToString()),
                    int.Parse(fila.GetCell(14).ToString()),
                    int.Parse(fila.GetCell(15).ToString()),
                    int.Parse(fila.GetCell(16).ToString()),
                    int.Parse(fila.GetCell(17).ToString()),
                    int.Parse(fila.GetCell(18).ToString()),
                    int.Parse(fila.GetCell(19).ToString()),
                    int.Parse(fila.GetCell(20).ToString()),
                    int.Parse(fila.GetCell(21).ToString()),
                    int.Parse(fila.GetCell(22).ToString()),
                    int.Parse(fila.GetCell(23).ToString()),
                    int.Parse(fila.GetCell(24).ToString()),
                    int.Parse(fila.GetCell(25).ToString()),
                    int.Parse(fila.GetCell(26).ToString()),
                    int.Parse(fila.GetCell(27).ToString()),
                    int.Parse(fila.GetCell(28).ToString()),
                    int.Parse(fila.GetCell(29).ToString()),
                    int.Parse(fila.GetCell(30).ToString()),
                    int.Parse(fila.GetCell(31).ToString()),
                    int.Parse(fila.GetCell(32).ToString()),
                    int.Parse(fila.GetCell(33).ToString()),
                    int.Parse(fila.GetCell(34).ToString()),
                    int.Parse(fila.GetCell(35).ToString()),
                    int.Parse(fila.GetCell(36).ToString()),
                    int.Parse(fila.GetCell(37).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = archivoRelacionTipoReunionBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\JemgemarArchivoRelacionTipoReunion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "JemgemarArchivoRelacionTipoReunion.xlsx");
        }

    }

}

