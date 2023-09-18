using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Dircapen;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dircapen;
using Marina.Siesmar.LogicaNegocios.Mantenimiento;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using Marina.Siesmar.Presentacion.Filters;
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

    public class DircapenDocentesCapacitacionPerfeccionamientoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        DocentesCapacitacionPerfeccionamiento docentesCapacitacionPerfecBL = new();
        CondicionLaboralDocente condicionLaboralDocenteBL = new();
        RegimenLaboral regimenLaboralBL = new();
        NivelEstudio nivelEstudioBL = new();
        CarreraUniversitariaEspecialidad carreraUniversitariaEspecialidadBL = new();
        Carga cargaBL = new();

        public DircapenDocentesCapacitacionPerfeccionamientoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Docentes del Departamento de Capacitación y Perfeccionamiento", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<CondicionLaboralDocenteDTO> condicionLaboralDocenteDTO = condicionLaboralDocenteBL.ObtenerCondicionLaboralDocentes();
            List<RegimenLaboralDTO> regimenLaboralDTO = regimenLaboralBL.ObtenerRegimenLaborals();
            List<NivelEstudioDTO> nivelEstudioDTO = nivelEstudioBL.ObtenerNivelEstudios();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = carreraUniversitariaEspecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DocenteCapacitacionPerfeccionamiento");

            return Json(new { data1 = tipoPersonalMilitarDTO, data2 = condicionLaboralDocenteDTO, data3 = regimenLaboralDTO,  data4 = nivelEstudioDTO, 
                data5 = carreraUniversitariaEspecialidadDTO, data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<DocentesCapacitacionPerfeccionamientoDTO> select = docentesCapacitacionPerfecBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar( string DNIDocente, string CodigoTipoPersonalMilitar, string CodigoCondicionLaboralDocente, string CodigoRegimenLaboral,
            string DedicacionDocente, string CodigoNivelEstudio, string CodigoCarreraUniversitariaEspecialidad, int CargaId, string Fecha)
        {
            DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO = new();
            docentesCapacitacionPerfecDTO.DNIDocente = DNIDocente;
            docentesCapacitacionPerfecDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            docentesCapacitacionPerfecDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docentesCapacitacionPerfecDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            docentesCapacitacionPerfecDTO.DedicacionDocente = DedicacionDocente;
            docentesCapacitacionPerfecDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            docentesCapacitacionPerfecDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docentesCapacitacionPerfecDTO.CargaId = CargaId;
            docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docentesCapacitacionPerfecBL.AgregarRegistro(docentesCapacitacionPerfecDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(docentesCapacitacionPerfecBL.EditarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DNIDocente, string CodigoTipoPersonalMilitar, string CodigoCondicionLaboralDocente, string CodigoRegimenLaboral,
            string DedicacionDocente, string CodigoNivelEstudio, string CodigoCarreraUniversitariaEspecialidad)
        {
            DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO = new();
            docentesCapacitacionPerfecDTO.DocenteCapacitacionPerfeccionamientoId = Id;
            docentesCapacitacionPerfecDTO.DNIDocente = DNIDocente;
            docentesCapacitacionPerfecDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            docentesCapacitacionPerfecDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docentesCapacitacionPerfecDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            docentesCapacitacionPerfecDTO.DedicacionDocente = DedicacionDocente;
            docentesCapacitacionPerfecDTO.CodigoNivelEstudio = CodigoNivelEstudio;
            docentesCapacitacionPerfecDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docentesCapacitacionPerfecBL.ActualizarFormato(docentesCapacitacionPerfecDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO = new();
            docentesCapacitacionPerfecDTO.DocenteCapacitacionPerfeccionamientoId = Id;
            docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (docentesCapacitacionPerfecBL.EliminarFormato(docentesCapacitacionPerfecDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO = new();
            docentesCapacitacionPerfecDTO.CargaId = Id;
            docentesCapacitacionPerfecDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (docentesCapacitacionPerfecBL.EliminarCarga(docentesCapacitacionPerfecDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DocentesCapacitacionPerfeccionamientoDTO> lista = new List<DocentesCapacitacionPerfeccionamientoDTO>();
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

                    lista.Add(new DocentesCapacitacionPerfeccionamientoDTO
                    {
                        DNIDocente = fila.GetCell(0).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(1).ToString(),
                        CodigoCondicionLaboralDocente = fila.GetCell(2).ToString(),
                        CodigoRegimenLaboral = fila.GetCell(3).ToString(),
                        DedicacionDocente = fila.GetCell(4).ToString(),
                        CodigoNivelEstudio = fila.GetCell(5).ToString(),
                        CodigoCarreraUniversitariaEspecialidad = fila.GetCell(6).ToString(),

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
        //[AuthorizePermission(Formato: 43, Permiso: 4)]//Registrar Masivo
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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("DNIDocente", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralDocente", typeof(string)),
                    new DataColumn("CodigoRegimenLaboral", typeof(string)),
                    new DataColumn("DedicacionDocente", typeof(string)),
                    new DataColumn("CodigoNivelEstudio", typeof(string)),
                    new DataColumn("CodigoCarreraUniversitariaEspecialidad", typeof(string)),

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


                    User.obtenerUsuario());
            }
            var IND_OPERACION = docentesCapacitacionPerfecBL.InsertarDatos(dt, Fecha);
            return Json(IND_OPERACION);
        }

        public IActionResult ReporteDDCP(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dircapen\\DocentesCapacitacionPerfeccionamiento.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var DocenteEsnas = docentesCapacitacionPerfecBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DocentesCapacitacionPerfeccionamiento", DocenteEsnas);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DircapenDocentesCapacitacionPerfeccionamiento.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DircapenDocentesCapacitacionPerfeccionamiento.xlsx");
        }

    }
}

