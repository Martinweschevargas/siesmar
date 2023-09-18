using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diperadmon;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diperadmon;
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
    public class DiperadmonPersonalMilitarRetiroBajaController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        PersonalMilitarRetiroBaja personalmilitarbajaBL = new();
        GradoPersonalMilitar gradopersonalmBL = new();
        EspecialidadGenericaPersonal especialidadgenericaBL = new();
        MotivoBajaPersonal motivobajapersBL = new();
        Carga cargaBL = new();

        public DiperadmonPersonalMilitarRetiroBajaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        [Breadcrumb(FromAction = "Index", Title = "Personal Militar Superior, Subalterno y Marinería en Situación de retiro o baja", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradopersonalmBL.ObtenerGradoPersonalMilitars();
            List<EspecialidadGenericaPersonalDTO> especialidadGenericaPersonalDAO = especialidadgenericaBL.ObtenerEspecialidadGenericaPersonals();
            List<MotivoBajaPersonalDTO> motivoBajaPersonalDAO = motivobajapersBL.ObtenerMotivoBajaPersonals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("PersonalMilitarRetiroBaja");
            return Json(new { 
                data1 = gradoPersonalMilitarDTO, 
                data2 = especialidadGenericaPersonalDAO, 
                data3 = motivoBajaPersonalDAO, 
                data4 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<PersonalMilitarRetiroBajaDTO> select = personalmilitarbajaBL.ObtenerLista();
            return Json(new { data = select });
        }
        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string DNIPMilitarRetBaja, string CodigoGradoPersonalMilitar,
            string SexoPMilitarRetBaja, string CodigoEspecialidadGenericaPersonal, string CodigoMotivoBajaPersonal, 
            string FechaIngresoInsPMilitarRetBaja, string FechaRetiroPMilitarRetBaja, int CargaId, string Fecha)
        {
            PersonalMilitarRetiroBajaDTO personalMilitarBajaDTO = new();
            personalMilitarBajaDTO.DNIPMilitarRetBaja = DNIPMilitarRetBaja;
            personalMilitarBajaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            personalMilitarBajaDTO.SexoPMilitarRetBaja = SexoPMilitarRetBaja;
            personalMilitarBajaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            personalMilitarBajaDTO.CodigoMotivoBajaPersonal = CodigoMotivoBajaPersonal;
            personalMilitarBajaDTO.FechaIngresoInsPMilitarRetBaja = FechaIngresoInsPMilitarRetBaja;
            personalMilitarBajaDTO.FechaRetiroPMilitarRetBaja = FechaRetiroPMilitarRetBaja;
            personalMilitarBajaDTO.CargaId = CargaId;
            personalMilitarBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalmilitarbajaBL.AgregarRegistro(personalMilitarBajaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(personalmilitarbajaBL.BuscarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string DNIPMilitarRetBaja, string CodigoGradoPersonalMilitar, 
            string SexoPMilitarRetBaja, string CodigoEspecialidadGenericaPersonal, string CodigoMotivoBajaPersonal, 
            string FechaIngresoInsPMilitarRetBaja, string FechaRetiroPMilitarRetBaja)
        {

            PersonalMilitarRetiroBajaDTO personalMilitarBajaDTO = new();
            personalMilitarBajaDTO.PersonalMilitarRetiroBajaId = Id;
            personalMilitarBajaDTO.DNIPMilitarRetBaja = DNIPMilitarRetBaja;
            personalMilitarBajaDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            personalMilitarBajaDTO.SexoPMilitarRetBaja = SexoPMilitarRetBaja;
            personalMilitarBajaDTO.CodigoEspecialidadGenericaPersonal = CodigoEspecialidadGenericaPersonal;
            personalMilitarBajaDTO.CodigoMotivoBajaPersonal = CodigoMotivoBajaPersonal;
            personalMilitarBajaDTO.FechaIngresoInsPMilitarRetBaja = FechaIngresoInsPMilitarRetBaja;
            personalMilitarBajaDTO.FechaRetiroPMilitarRetBaja = FechaRetiroPMilitarRetBaja;
            personalMilitarBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = personalmilitarbajaBL.ActualizarFormato(personalMilitarBajaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            PersonalMilitarRetiroBajaDTO personalMilitarBajaDTO = new();
            personalMilitarBajaDTO.PersonalMilitarRetiroBajaId = Id;
            personalMilitarBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalmilitarbajaBL.EliminarFormato(personalMilitarBajaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            PersonalMilitarRetiroBajaDTO personalMilitarBajaDTO = new();
            personalMilitarBajaDTO.CargaId = Id;
            personalMilitarBajaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (personalmilitarbajaBL.EliminarCarga(personalMilitarBajaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<PersonalMilitarRetiroBajaDTO> lista = new List<PersonalMilitarRetiroBajaDTO>();
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

                    lista.Add(new PersonalMilitarRetiroBajaDTO
                    {
                        DNIPMilitarRetBaja = fila.GetCell(0).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(1).ToString(),
                        SexoPMilitarRetBaja = fila.GetCell(2).ToString(),
                        CodigoEspecialidadGenericaPersonal = fila.GetCell(3).ToString(),
                        CodigoMotivoBajaPersonal = fila.GetCell(4).ToString(),
                        FechaIngresoInsPMilitarRetBaja = UtilitariosGlobales.obtenerFecha(fila.GetCell(5).ToString()),
                        FechaRetiroPMilitarRetBaja = UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
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
                    new DataColumn("DNIPMilitarRetBaja", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("SexoPMilitarRetBaja", typeof(string)),
                    new DataColumn("CodigoEspecialidadGenericaPersonal", typeof(string)),
                    new DataColumn("CodigoMotivoBajaPersonal", typeof(string)),
                    new DataColumn("FechaIngresoInsPMilitarRetBaja", typeof(string)),
                    new DataColumn("FechaRetiroPMilitarRetBaja", typeof(string)),
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
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = personalmilitarbajaBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiperadmonPersonalMilitarRetiroBaja.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiperadmonPersonalMilitarRetiroBaja.xlsx");
        }
    }

}