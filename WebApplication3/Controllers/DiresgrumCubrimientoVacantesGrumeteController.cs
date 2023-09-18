using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diresgrum;
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

    public class DiresgrumCubrimientoVacantesGrumeteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        CubrimientoVacantesGrumete cubrimientoVacantesGrumeteBL = new();
        EspecialidadGrumeteDAO especialidadGrumeteBL = new();
        Carga cargaBL = new();

        public DiresgrumCubrimientoVacantesGrumeteController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Cubrimiento de Vacantes de Grumetes", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<EspecialidadGrumeteDTO> especialidadGrumeteDTO = especialidadGrumeteBL.ObtenerEspecialidadGrumetes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("CubrimientoVacanteGrumete");

            return Json(new { 
                data1 = especialidadGrumeteDTO, 
                data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<CubrimientoVacantesGrumeteDTO> select = cubrimientoVacantesGrumeteBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(int AnioCubrimientoVacante, int NumeroContingente, string CodigoEspecialidadGrumete, string SexoGrumete,
            int NumeroRequerido, int NumeroEfectivo, int DeficitVacante, int CargaId, string Fecha)
        {
            CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO = new();
            cubrimientoVacantesGrumeteDTO.AnioCubrimientoVacante = AnioCubrimientoVacante;
            cubrimientoVacantesGrumeteDTO.NumeroContingente = NumeroContingente;
            cubrimientoVacantesGrumeteDTO.CodigoEspecialidadGrumete = CodigoEspecialidadGrumete;
            cubrimientoVacantesGrumeteDTO.SexoGrumete = SexoGrumete;
            cubrimientoVacantesGrumeteDTO.NumeroRequerido = NumeroRequerido;
            cubrimientoVacantesGrumeteDTO.NumeroEfectivo = NumeroEfectivo;
            cubrimientoVacantesGrumeteDTO.DeficitVacante = DeficitVacante;
            cubrimientoVacantesGrumeteDTO.CargaId = CargaId;
            cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cubrimientoVacantesGrumeteBL.AgregarRegistro(cubrimientoVacantesGrumeteDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(cubrimientoVacantesGrumeteBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, int AnioCubrimientoVacante, int NumeroContingente, string CodigoEspecialidadGrumete, string SexoGrumete,
            int NumeroRequerido, int NumeroEfectivo, int DeficitVacante)
        {
            CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO = new();
            cubrimientoVacantesGrumeteDTO.CubrimientoVacanteGrumeteId = Id;
            cubrimientoVacantesGrumeteDTO.AnioCubrimientoVacante = AnioCubrimientoVacante;
            cubrimientoVacantesGrumeteDTO.NumeroContingente = NumeroContingente;
            cubrimientoVacantesGrumeteDTO.CodigoEspecialidadGrumete = CodigoEspecialidadGrumete;
            cubrimientoVacantesGrumeteDTO.SexoGrumete = SexoGrumete;
            cubrimientoVacantesGrumeteDTO.NumeroRequerido = NumeroRequerido;
            cubrimientoVacantesGrumeteDTO.NumeroEfectivo = NumeroEfectivo;
            cubrimientoVacantesGrumeteDTO.DeficitVacante = DeficitVacante;
            cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = cubrimientoVacantesGrumeteBL.ActualizarFormato(cubrimientoVacantesGrumeteDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO = new();
            cubrimientoVacantesGrumeteDTO.CubrimientoVacanteGrumeteId = Id;
            cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (cubrimientoVacantesGrumeteBL.EliminarFormato(cubrimientoVacantesGrumeteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO = new();
            cubrimientoVacantesGrumeteDTO.CargaId = Id;
            cubrimientoVacantesGrumeteDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (cubrimientoVacantesGrumeteBL.EliminarCarga(cubrimientoVacantesGrumeteDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<CubrimientoVacantesGrumeteDTO> lista = new List<CubrimientoVacantesGrumeteDTO>();
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

                    lista.Add(new CubrimientoVacantesGrumeteDTO
                    {
                        AnioCubrimientoVacante = int.Parse(fila.GetCell(0).ToString()),
                        NumeroContingente = int.Parse(fila.GetCell(1).ToString()),
                        CodigoEspecialidadGrumete = fila.GetCell(2).ToString(),
                        SexoGrumete = fila.GetCell(3).ToString(),
                        NumeroRequerido = int.Parse(fila.GetCell(4).ToString()),
                        NumeroEfectivo = int.Parse(fila.GetCell(5).ToString()),
                        DeficitVacante = int.Parse(fila.GetCell(6).ToString()),

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

            dt.Columns.AddRange(new DataColumn[8]
            {
                    new DataColumn("AnioCubrimientoVacante", typeof(int)),
                    new DataColumn("NumeroContingente", typeof(int)),
                    new DataColumn("CodigoEspecialidadGrumete", typeof(string)),
                    new DataColumn("SexoGrumete", typeof(string)),
                    new DataColumn("NumeroRequerido", typeof(int)),
                    new DataColumn("NumeroEfectivo", typeof(int)),
                    new DataColumn("DeficitVacante", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    int.Parse(fila.GetCell(1).ToString()),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    int.Parse(fila.GetCell(4).ToString()),
                    int.Parse(fila.GetCell(5).ToString()),
                    int.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = cubrimientoVacantesGrumeteBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiresgrumCubrimientoVacantesGrumete.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiresgrumCubrimientoVacantesGrumete.xlsx");
        }
    }

}

