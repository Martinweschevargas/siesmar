using AspNetCore.Reporting;
using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Dintemar;
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

    public class DintemarInteligenciaContraintelAmenazaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        InteligenciaContraintelAmenazaDAO inteligenciaContraintelAmenazaBL = new();
        AmenazaSeguridadNacionalDAO amenazaSeguridadNacionalBL = new();
        Carga cargaBL = new();

        public DintemarInteligenciaContraintelAmenazaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Documentos de Inteligencia y Contrainteligencia por Amenaza", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<AmenazaSeguridadNacionalDTO> amenazaSeguridadNacionalDTO = amenazaSeguridadNacionalBL.ObtenerAmenazaSeguridadNacionals();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("InteligenciaContrainteligenciaAmenaza");

            return Json(new { data1 = amenazaSeguridadNacionalDTO, data2= listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<InteligenciaContraintelAmenazaDTO> select = inteligenciaContraintelAmenazaBL.ObtenerLista();


            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string CodigoAmenazaSeguridadNacional, int NotasInteligentes, int EstudiosInteligencia,
           int ApreciacionesInteligencia, int NotasInformacion, int NotasContrainteligencia, int EstudiosContrainteligencia,
           int ApreciacionesContrainteligencia, int NotasInformacionContrainteligencia, int CargaId, string fecha)
        {
            InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO = new();
            inteligenciaContraintelAmenazaDTO.CodigoAmenazaSeguridadNacional = CodigoAmenazaSeguridadNacional;
            inteligenciaContraintelAmenazaDTO.NotasInteligentes = NotasInteligentes;
            inteligenciaContraintelAmenazaDTO.EstudiosInteligencia = EstudiosInteligencia;
            inteligenciaContraintelAmenazaDTO.ApreciacionesInteligencia = ApreciacionesInteligencia;
            inteligenciaContraintelAmenazaDTO.NotasInformacion = NotasInformacion;
            inteligenciaContraintelAmenazaDTO.NotasContrainteligencia = NotasContrainteligencia;
            inteligenciaContraintelAmenazaDTO.EstudiosContrainteligencia = EstudiosContrainteligencia;
            inteligenciaContraintelAmenazaDTO.ApreciacionesContrainteligencia = ApreciacionesContrainteligencia;
            inteligenciaContraintelAmenazaDTO.NotasInformacionContrainteligencia = NotasInformacionContrainteligencia;
            inteligenciaContraintelAmenazaDTO.CargaId = CargaId;
            inteligenciaContraintelAmenazaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            inteligenciaContraintelAmenazaDTO.Fecha = fecha;

            var IND_OPERACION = inteligenciaContraintelAmenazaBL.AgregarRegistro(inteligenciaContraintelAmenazaDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(inteligenciaContraintelAmenazaBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoAmenazaSeguridadNacional, int NotasInteligentes, int EstudiosInteligencia,
           int ApreciacionesInteligencia, int NotasInformacion, int NotasContrainteligencia, int EstudiosContrainteligencia,
           int ApreciacionesContrainteligencia, int NotasInformacionContrainteligencia)
        {
            InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO = new();
            inteligenciaContraintelAmenazaDTO.InteligenciaContrainteligenciaAmenazaId = Id;
            inteligenciaContraintelAmenazaDTO.CodigoAmenazaSeguridadNacional = CodigoAmenazaSeguridadNacional;
            inteligenciaContraintelAmenazaDTO.NotasInteligentes = NotasInteligentes;
            inteligenciaContraintelAmenazaDTO.EstudiosInteligencia = EstudiosInteligencia;
            inteligenciaContraintelAmenazaDTO.ApreciacionesInteligencia = ApreciacionesInteligencia;
            inteligenciaContraintelAmenazaDTO.NotasInformacion = NotasInformacion;
            inteligenciaContraintelAmenazaDTO.NotasContrainteligencia = NotasContrainteligencia;
            inteligenciaContraintelAmenazaDTO.EstudiosContrainteligencia = EstudiosContrainteligencia;
            inteligenciaContraintelAmenazaDTO.ApreciacionesContrainteligencia = ApreciacionesContrainteligencia;
            inteligenciaContraintelAmenazaDTO.NotasInformacionContrainteligencia = NotasInformacionContrainteligencia;
            inteligenciaContraintelAmenazaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = inteligenciaContraintelAmenazaBL.ActualizaFormato(inteligenciaContraintelAmenazaDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO = new();
            inteligenciaContraintelAmenazaDTO.InteligenciaContrainteligenciaAmenazaId = Id;
            inteligenciaContraintelAmenazaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (inteligenciaContraintelAmenazaBL.EliminarFormato(inteligenciaContraintelAmenazaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje;
            InteligenciaContraintelAmenazaDTO inteligenciaContraintelAmenazaDTO = new()
            {
                CargaId = Id,
                UsuarioIngresoRegistro = User.obtenerUsuario()
            };

            if (inteligenciaContraintelAmenazaBL.EliminarCarga(inteligenciaContraintelAmenazaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<InteligenciaContraintelAmenazaDTO> lista = new List<InteligenciaContraintelAmenazaDTO>();
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

                    lista.Add(new InteligenciaContraintelAmenazaDTO
                    {
                        CodigoAmenazaSeguridadNacional = fila.GetCell(0).ToString(),
                        NotasInteligentes = int.Parse(fila.GetCell(1).ToString()),
                        EstudiosInteligencia = int.Parse(fila.GetCell(2).ToString()),
                        ApreciacionesInteligencia = int.Parse(fila.GetCell(3).ToString()),
                        NotasInformacion = int.Parse(fila.GetCell(4).ToString()),
                        NotasContrainteligencia = int.Parse(fila.GetCell(5).ToString()),
                        EstudiosContrainteligencia = int.Parse(fila.GetCell(6).ToString()),
                        ApreciacionesContrainteligencia = int.Parse(fila.GetCell(7).ToString()),
                        NotasInformacionContrainteligencia = int.Parse(fila.GetCell(8).ToString()),

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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel, string fecha)
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

            dt.Columns.AddRange(new DataColumn[10]
            {
                    new DataColumn("CodigoAmenazaSeguridadNacional", typeof(string)),
                    new DataColumn("NotasInteligentes  ", typeof(int)),
                    new DataColumn("EstudiosInteligencia ", typeof(int)),
                    new DataColumn("ApreciacionesInteligencia  ", typeof(int)),
                    new DataColumn("NotasInformacion  ", typeof(int)),
                    new DataColumn("NotasContrainteligencia   ", typeof(int)),
                    new DataColumn("EstudiosContrainteligencia  ", typeof(int)),
                    new DataColumn("ApreciacionesContrainteligencia  ", typeof(int)),
                    new DataColumn("NotasInformacionContrainteligencia  ", typeof(int)),

                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                   fila.GetCell(0).ToString(),
                   int.Parse(fila.GetCell(1).ToString()),
                   int.Parse(fila.GetCell(2).ToString()),
                   int.Parse(fila.GetCell(3).ToString()),
                   int.Parse(fila.GetCell(4).ToString()),
                   int.Parse(fila.GetCell(5).ToString()),
                   int.Parse(fila.GetCell(6).ToString()),
                   int.Parse(fila.GetCell(7).ToString()),
                   int.Parse(fila.GetCell(8).ToString()),

                    User.obtenerUsuario());
            }
            var IND_OPERACION = inteligenciaContraintelAmenazaBL.InsertarDatos(dt, fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteDICA(int? CargaId = null)
        {

            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dintemar\\InteligenciaContraintelAmenaza.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var comeEvaAlis = inteligenciaContraintelAmenazaBL.ObtenerLista(CargaId);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("InteligenciaContraintelAmenaza", comeEvaAlis);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\InteligenciaContraintelAmenaza.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "InteligenciaContraintelAmenaza.xlsx");
        }
    }

}

