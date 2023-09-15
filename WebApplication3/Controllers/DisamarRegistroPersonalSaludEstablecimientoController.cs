using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Disamar;
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

    public class DisamarRegistroPersonalSaludEstablecimientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        RegistroPersonalSaludEstablecimiento registroPersonalSaludEstablecimientoBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        EstablecimientoSaludMGP establecimientoSaludMGPBL = new();
        CondicionLaboral condicionLaboralBL = new();
        Carga cargaBL = new();

        public DisamarRegistroPersonalSaludEstablecimientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Registro del Personal de la Salud de los Establecimientos de Salud", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<EstablecimientoSaludMGPDTO> establecimientoSaludMGPDTO = establecimientoSaludMGPBL.ObtenerEstablecimientoSaludMGPs();
            List<CondicionLaboralDTO> condicionLaboralDTO = condicionLaboralBL.ObtenerCondicionLaborals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("RegistroPersonalSaludEstablecimiento");
            return Json(new
            {
                data1 = gradoPersonalMilitarDTO,
                data2 = establecimientoSaludMGPDTO,
                data3 = condicionLaboralDTO,
                data4 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<RegistroPersonalSaludEstablecimientoDTO> select = registroPersonalSaludEstablecimientoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string ApellidosNombresPersonalMedico, string CIPPersonalMedico, string DNIPersonalMedico, string TipoPersonal, string CodigoGradoPersonalMilitar,
            string NombreColegioProfesional, string NumeroColegiatura, string Especialidad, string CodigoEstablecimientoSaludMGP, string CodigoCondicionLaboral,
            string TipoLaborRealizar,int CargaId, string Fecha)
        {
            RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO = new();
            registroPersonalSaludEstablecimientoDTO.ApellidosNombresPersonalMedico = ApellidosNombresPersonalMedico;
            registroPersonalSaludEstablecimientoDTO.CIPPersonalMedico = CIPPersonalMedico;
            registroPersonalSaludEstablecimientoDTO.DNIPersonalMedico = DNIPersonalMedico;
            registroPersonalSaludEstablecimientoDTO.TipoPersonal = TipoPersonal;
            registroPersonalSaludEstablecimientoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroPersonalSaludEstablecimientoDTO.NombreColegioProfesional = NombreColegioProfesional;
            registroPersonalSaludEstablecimientoDTO.NumeroColegiatura = NumeroColegiatura;
            registroPersonalSaludEstablecimientoDTO.Especialidad = Especialidad;
            registroPersonalSaludEstablecimientoDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroPersonalSaludEstablecimientoDTO.CodigoCondicionLaboral = CodigoCondicionLaboral;
            registroPersonalSaludEstablecimientoDTO.TipoLaborRealizar = TipoLaborRealizar;
            registroPersonalSaludEstablecimientoDTO.CargaId = CargaId;
            registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroPersonalSaludEstablecimientoBL.AgregarRegistro(registroPersonalSaludEstablecimientoDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(registroPersonalSaludEstablecimientoBL.EditarFormato(Id));
        }


        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string ApellidosNombresPersonalMedico, string CIPPersonalMedico, string DNIPersonalMedico, string TipoPersonal,
            string CodigoGradoPersonalMilitar, string NombreColegioProfesional, string NumeroColegiatura, string Especialidad, string CodigoEstablecimientoSaludMGP,
            string NombreEstablecimientoSalud, string CodigoCondicionLaboral, string TipoLaborRealizar)
        {
            RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO = new();
            registroPersonalSaludEstablecimientoDTO.RegistroPersonalSaludEstablecimientoId = Id;
            registroPersonalSaludEstablecimientoDTO.ApellidosNombresPersonalMedico = ApellidosNombresPersonalMedico;
            registroPersonalSaludEstablecimientoDTO.CIPPersonalMedico = CIPPersonalMedico;
            registroPersonalSaludEstablecimientoDTO.DNIPersonalMedico = DNIPersonalMedico;
            registroPersonalSaludEstablecimientoDTO.TipoPersonal = TipoPersonal;
            registroPersonalSaludEstablecimientoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            registroPersonalSaludEstablecimientoDTO.NombreColegioProfesional = NombreColegioProfesional;
            registroPersonalSaludEstablecimientoDTO.NumeroColegiatura = NumeroColegiatura;
            registroPersonalSaludEstablecimientoDTO.Especialidad = Especialidad;
            registroPersonalSaludEstablecimientoDTO.CodigoEstablecimientoSaludMGP = CodigoEstablecimientoSaludMGP;
            registroPersonalSaludEstablecimientoDTO.CodigoCondicionLaboral = CodigoCondicionLaboral;
            registroPersonalSaludEstablecimientoDTO.TipoLaborRealizar = TipoLaborRealizar;
            
            registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = registroPersonalSaludEstablecimientoBL.ActualizarFormato(registroPersonalSaludEstablecimientoDTO);

            return Content(IND_OPERACION);
        }


        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO = new();
            registroPersonalSaludEstablecimientoDTO.RegistroPersonalSaludEstablecimientoId = Id;
            registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (registroPersonalSaludEstablecimientoBL.EliminarFormato(registroPersonalSaludEstablecimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            RegistroPersonalSaludEstablecimientoDTO registroPersonalSaludEstablecimientoDTO = new();
            registroPersonalSaludEstablecimientoDTO.CargaId = Id;
            registroPersonalSaludEstablecimientoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (registroPersonalSaludEstablecimientoBL.EliminarCarga(registroPersonalSaludEstablecimientoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<RegistroPersonalSaludEstablecimientoDTO> lista = new List<RegistroPersonalSaludEstablecimientoDTO>();
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

                    lista.Add(new RegistroPersonalSaludEstablecimientoDTO
                    {
                        ApellidosNombresPersonalMedico = fila.GetCell(0).ToString(),
                        CIPPersonalMedico = fila.GetCell(1).ToString(),
                        DNIPersonalMedico = fila.GetCell(2).ToString(),
                        TipoPersonal = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        NombreColegioProfesional = fila.GetCell(5).ToString(),
                        NumeroColegiatura = fila.GetCell(6).ToString(),
                        Especialidad = fila.GetCell(7).ToString(),
                        CodigoEstablecimientoSaludMGP = fila.GetCell(8).ToString(),
                        CodigoCondicionLaboral = fila.GetCell(9).ToString(),
                        TipoLaborRealizar = fila.GetCell(10).ToString(),
 
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

            dt.Columns.AddRange(new DataColumn[12]
            {
                    new DataColumn("ApellidosNombresPersonalMedico", typeof(string)),
                    new DataColumn("CIPPersonalMedico", typeof(string)),
                    new DataColumn("DNIPersonalMedico", typeof(string)),
                    new DataColumn("TipoPersonal", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("NombreColegioProfesional", typeof(string)),
                    new DataColumn("NumeroColegiatura", typeof(string)),
                    new DataColumn("Especialidad", typeof(string)),
                    new DataColumn("CodigoEstablecimientoSaludMGP", typeof(string)),
                    new DataColumn("CodigoCondicionLaboral", typeof(string)),
                    new DataColumn("TipoLaborRealizar", typeof(string)),
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
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    fila.GetCell(8).ToString(),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),


                    User.obtenerUsuario());
            }
            var IND_OPERACION = registroPersonalSaludEstablecimientoBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DisamarRegistroPersonalSaludEstablecimiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DisamarRegistroPersonalSaludEstablecimiento.xlsx");
        }


    }

}

