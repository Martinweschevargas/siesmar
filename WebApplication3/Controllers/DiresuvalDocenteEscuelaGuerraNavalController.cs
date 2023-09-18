using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diresuval;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresuval;
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

    public class DiresuvalDocenteEscuelaGuerraNavalController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        DocenteEscuelaGuerraNaval docenteEscuelaGuerraNavalBL = new();
        TipoPersonalMilitar tipoPersonalMilitarBL = new();
        CondicionLaboralDocente condicionLaboralDocenteBL = new();
        RegimenLaboral regimenLaboralBL = new();
        GradoEstudioAlcanzado gradoEstudioAlcanzadoBL = new();
        CarreraUniversitariaEspecialidad carreraUniversitariaEspecialidadBL = new();
        Carga cargaBL = new();


        public DiresuvalDocenteEscuelaGuerraNavalController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Docentes de la Escuela Superior de Guerra Naval", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<TipoPersonalMilitarDTO> tipoPersonalMilitarDTO = tipoPersonalMilitarBL.ObtenerTipoPersonalMilitars();
            List<CondicionLaboralDocenteDTO> condicionLaboralDocenteDTO = condicionLaboralDocenteBL.ObtenerCondicionLaboralDocentes();
            List<RegimenLaboralDTO> regimenLaboralDTO = regimenLaboralBL.ObtenerRegimenLaborals();
            List<GradoEstudioAlcanzadoDTO> gradoEstudioAlcanzadoDTO = gradoEstudioAlcanzadoBL.ObtenerGradoEstudioAlcanzados();
            List<CarreraUniversitariaEspecialidadDTO> carreraUniversitariaEspecialidadDTO = carreraUniversitariaEspecialidadBL.ObtenerCarreraUniversitariaEspecialidads();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("DocenteEscuelaGuerraNaval");

            return Json(new { data1 = tipoPersonalMilitarDTO, data2 = condicionLaboralDocenteDTO, data3 = regimenLaboralDTO, data4 = gradoEstudioAlcanzadoDTO,
                data5 = carreraUniversitariaEspecialidadDTO, data6 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<DocenteEscuelaGuerraNavalDTO> select = docenteEscuelaGuerraNavalBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        //[AuthorizePermission(Formato: 43, Permiso: 1)]//Registrar
        public ActionResult Insertar( string DNIDocenteEscuela, string CodigoRegimenLaboral, string CodigoCondicionLaboralDocente, string CodigoGradoEstudioAlcanzado, 
            string DedicacionDocente, string CodigoTipoPersonalMilitar, string CodigoCarreraUniversitariaEspecialidad, int CargaId, string Fecha)
        {
            DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO = new();
            docenteEscuelaGuerraNavalDTO.DNIDocenteEscuela = DNIDocenteEscuela;
            docenteEscuelaGuerraNavalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            docenteEscuelaGuerraNavalDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docenteEscuelaGuerraNavalDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            docenteEscuelaGuerraNavalDTO.DedicacionDocente = DedicacionDocente;
            docenteEscuelaGuerraNavalDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            docenteEscuelaGuerraNavalDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docenteEscuelaGuerraNavalDTO.CargaId = CargaId;
            docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docenteEscuelaGuerraNavalBL.AgregarRegistro(docenteEscuelaGuerraNavalDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(docenteEscuelaGuerraNavalBL.BuscarFormato(Id));
        }

        //[AuthorizePermission(Formato: 43, Permiso: 2)]//Actualizar
        public ActionResult Actualizar(int Id, string DNIDocenteEscuela, string CodigoRegimenLaboral, string CodigoCondicionLaboralDocente, string CodigoGradoEstudioAlcanzado,
            string DedicacionDocente, string CodigoTipoPersonalMilitar, string CodigoCarreraUniversitariaEspecialidad)
        {
            DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO = new();
            docenteEscuelaGuerraNavalDTO.DocenteEscuelaGuerraNavalId = Id;
            docenteEscuelaGuerraNavalDTO.DNIDocenteEscuela = DNIDocenteEscuela;
            docenteEscuelaGuerraNavalDTO.CodigoTipoPersonalMilitar = CodigoTipoPersonalMilitar;
            docenteEscuelaGuerraNavalDTO.CodigoCondicionLaboralDocente = CodigoCondicionLaboralDocente;
            docenteEscuelaGuerraNavalDTO.CodigoRegimenLaboral = CodigoRegimenLaboral;
            docenteEscuelaGuerraNavalDTO.DedicacionDocente = DedicacionDocente;
            docenteEscuelaGuerraNavalDTO.CodigoGradoEstudioAlcanzado = CodigoGradoEstudioAlcanzado;
            docenteEscuelaGuerraNavalDTO.CodigoCarreraUniversitariaEspecialidad = CodigoCarreraUniversitariaEspecialidad;
            docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = docenteEscuelaGuerraNavalBL.ActualizarFormato(docenteEscuelaGuerraNavalDTO);

            return Content(IND_OPERACION);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 3)]//Eliminar
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO = new();
            docenteEscuelaGuerraNavalDTO.DocenteEscuelaGuerraNavalId = Id;
            docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (docenteEscuelaGuerraNavalBL.EliminarFormato(docenteEscuelaGuerraNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //[AuthorizePermission(Formato: 43, Permiso: 5)]//Eliminar Carga
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            DocenteEscuelaGuerraNavalDTO docenteEscuelaGuerraNavalDTO = new();
            docenteEscuelaGuerraNavalDTO.CargaId = Id;
            docenteEscuelaGuerraNavalDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (docenteEscuelaGuerraNavalBL.EliminarCarga(docenteEscuelaGuerraNavalDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DocenteEscuelaGuerraNavalDTO> lista = new List<DocenteEscuelaGuerraNavalDTO>();
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

                    lista.Add(new DocenteEscuelaGuerraNavalDTO
                    {
                        DNIDocenteEscuela = fila.GetCell(0).ToString(),
                        CodigoTipoPersonalMilitar = fila.GetCell(1).ToString(),
                        CodigoCondicionLaboralDocente = fila.GetCell(2).ToString(),
                        CodigoRegimenLaboral = fila.GetCell(3).ToString(),
                        DedicacionDocente = fila.GetCell(4).ToString(),
                        CodigoGradoEstudioAlcanzado = fila.GetCell(5).ToString(),
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
                    new DataColumn("DNIDocenteEscuela", typeof(string)),
                    new DataColumn("CodigoTipoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoCondicionLaboralDocente", typeof(string)),
                    new DataColumn("CodigoRegimenLaboral", typeof(string)),
                    new DataColumn("DedicacionDocente", typeof(string)),
                    new DataColumn("CodigoGradoEstudioAlcanzado", typeof(string)),
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
            var IND_OPERACION = docenteEscuelaGuerraNavalBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDDEGN(int? CargaId = null)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Diresuval\\DocenteEscuelaGuerraNaval.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var capacitacionPerfeccionamientoExtraC = docenteEscuelaGuerraNavalBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DiresuvalDocenteEscuelaGuerraNaval", capacitacionPerfeccionamientoExtraC);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiresuvalDocenteEscuelaGuerraNaval.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiresuvalDocenteEscuelaGuerraNaval.xlsx");
        }
    }

}

