using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diali;
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
    public class DialiLicArmasMenoresMilitarController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        LicenciaArmasMenoresMilitar LicenciaArmasBL = new();
        TramiteArmaMenor tramitearmamenorBL = new();
        SituacionPersonalSolicitante situacionpersolBL = new();
        Carga cargaBL = new();

        public DialiLicArmasMenoresMilitarController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Certificados o Licencias de Posesión y uso de Armas Menores Otorgadas", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TramiteArmaMenorDTO> tramitearmamenorDTO = tramitearmamenorBL.ObtenerTramiteArmaMenors();
            List<SituacionPersonalSolicitanteDTO> situacionpersonalDTO = situacionpersolBL.ObtenerSituacionPersonalSolicitantes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("LicenciaArmaMenorMilitar");
            return Json(new { 
                data1 = tramitearmamenorDTO, 
                data2 = situacionpersonalDTO, 
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<LicenciaArmasMenoresMilitarDTO> lista = LicenciaArmasBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoDocumentoArmaMenor, string SolDocumentoArmaMenor, string FechaSolicitudLicArmaMenor,
           string CodigoTramiteArmaMenor, string CodigoSituacionPersonalSolicitante, string CondicionAprobLicArmaMenor, string FechaOtorgamientoLicArmaMenor,
           string NroLicenciaArmaMenor, int CargaId, string Fecha)
        {
            LicenciaArmasMenoresMilitarDTO LicenciaArmasDTO = new();
            LicenciaArmasDTO.CodigoDocumentoArmaMenor = CodigoDocumentoArmaMenor;
            LicenciaArmasDTO.SolDocumentoArmaMenor = SolDocumentoArmaMenor;
            LicenciaArmasDTO.FechaSolicitudLicArmaMenor = FechaSolicitudLicArmaMenor;
            LicenciaArmasDTO.CodigoTramiteArmaMenor = CodigoTramiteArmaMenor;
            LicenciaArmasDTO.CodigoSituacionPersonalSolicitante = CodigoSituacionPersonalSolicitante;
            LicenciaArmasDTO.CondicionAprobLicArmaMenor = CondicionAprobLicArmaMenor;
            LicenciaArmasDTO.FechaOtorgamientoLicArmaMenor = FechaOtorgamientoLicArmaMenor;
            LicenciaArmasDTO.NroLicenciaArmaMenor = NroLicenciaArmaMenor;
            LicenciaArmasDTO.CargaId = CargaId;
            LicenciaArmasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = LicenciaArmasBL.AgregarRegistro(LicenciaArmasDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(LicenciaArmasBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoDocumentoArmaMenor, string SolDocumentoArmaMenor, string FechaSolicitudLicArmaMenor,
           string CodigoTramiteArmaMenor, string CodigoSituacionPersonalSolicitante, string CondicionAprobLicArmaMenor, string FechaOtorgamientoLicArmaMenor,
           string NroLicenciaArmaMenor)
        {
            LicenciaArmasMenoresMilitarDTO LicenciaArmasDTO = new();
            LicenciaArmasDTO.LicenciaArmaMenorId = Id;
            LicenciaArmasDTO.CodigoDocumentoArmaMenor = CodigoDocumentoArmaMenor;
            LicenciaArmasDTO.SolDocumentoArmaMenor = SolDocumentoArmaMenor;
            LicenciaArmasDTO.FechaSolicitudLicArmaMenor = FechaSolicitudLicArmaMenor;
            LicenciaArmasDTO.CodigoTramiteArmaMenor = CodigoTramiteArmaMenor;
            LicenciaArmasDTO.CodigoSituacionPersonalSolicitante = CodigoSituacionPersonalSolicitante;
            LicenciaArmasDTO.CondicionAprobLicArmaMenor = CondicionAprobLicArmaMenor;
            LicenciaArmasDTO.FechaOtorgamientoLicArmaMenor = FechaOtorgamientoLicArmaMenor;
            LicenciaArmasDTO.NroLicenciaArmaMenor = NroLicenciaArmaMenor;
            LicenciaArmasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = LicenciaArmasBL.ActualizarFormato(LicenciaArmasDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            LicenciaArmasMenoresMilitarDTO LicenciaArmasDTO = new();
            LicenciaArmasDTO.LicenciaArmaMenorId = Id;
            LicenciaArmasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (LicenciaArmasBL.EliminarFormato(LicenciaArmasDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            LicenciaArmasMenoresMilitarDTO LicenciaArmasDTO = new();
            LicenciaArmasDTO.CargaId = Id;
            LicenciaArmasDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (LicenciaArmasBL.EliminarCarga(LicenciaArmasDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<LicenciaArmasMenoresMilitarDTO> lista = new List<LicenciaArmasMenoresMilitarDTO>();
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

                    lista.Add(new LicenciaArmasMenoresMilitarDTO
                    {
                        CodigoDocumentoArmaMenor = fila.GetCell(1).ToString(),
                        SolDocumentoArmaMenor = fila.GetCell(2).ToString(),
                        FechaSolicitudLicArmaMenor = fila.GetCell(3).ToString(),
                        CodigoTramiteArmaMenor = fila.GetCell(4).ToString(),
                        CodigoSituacionPersonalSolicitante = fila.GetCell(5).ToString(),
                        CondicionAprobLicArmaMenor = fila.GetCell(6).ToString(),
                        FechaOtorgamientoLicArmaMenor = fila.GetCell(7).ToString(),
                        NroLicenciaArmaMenor = fila.GetCell(8).ToString()
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("CodigoDocumentoArmaMenor", typeof(string)),
                    new DataColumn("SolDocumentoArmaMenor", typeof(string)),
                    new DataColumn("FechaSolicitudLicArmaMenor", typeof(string)),
                    new DataColumn("CodigoTramiteArmaMenor", typeof(string)),
                    new DataColumn("CodigoSituacionPersonalSolicitante", typeof(string)),
                    new DataColumn("CondicionAprobLicArmaMenor", typeof(string)),
                    new DataColumn("FechaOtorgamientoLicArmaMenor", typeof(string)),
                    new DataColumn("NroLicenciaArmaMenor", typeof(string)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(3).ToString()),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(7).ToString()),
                    fila.GetCell(8).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = LicenciaArmasBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DialiLicArmasMenoresMilitar.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DialiLicArmasMenoresMilitar.xlsx");
        }
    }

}