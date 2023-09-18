using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzotres;
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
    public class ComzotresBandaMusicoComzotresController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        BandaMusicoComzotres bandaMusicoComzotresBL = new();
        TipoComision tipoComisionBL = new();
        Evento eventoBL = new();
        GrupoComisionado grupoComisionadoBL = new();
        VestimentaUniforme vestimentaUniformeBL = new();
        Carga cargaBL = new();

        public ComzotresBandaMusicoComzotresController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Banda de Musicos", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<TipoComisionDTO> tipoComisionDTO = tipoComisionBL.ObtenerTipoComisions();
            List<EventoDTO> eventoDTO = eventoBL.ObtenerEventos();
            List<GrupoComisionadoDTO> grupoComisionadoDTO = grupoComisionadoBL.ObtenerGrupoComisionados();
            List<VestimentaUniformeDTO> vestimentaUniformeDTO = vestimentaUniformeBL.ObtenerVestimentaUniformes();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("BandaMusicoComzotres");
            return Json(new
            {
                data1 = tipoComisionDTO,
                data2 = eventoDTO,
                data3 = grupoComisionadoDTO,
                data4 = vestimentaUniformeDTO,
                data5 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<BandaMusicoComzotresDTO> lista = bandaMusicoComzotresBL.ObtenerLista();
            return Json(new { data = lista });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar( string CodigoTipoComision, string CodigoEvento, string CodigoGrupoComisionado, 
            string CodigoVestimentaUniforme, string NombreEvento, string Lugar, string FechaHoraSalida, string FechaHoraInicio, 
            string FechaHoraTermino, string RequerimientoMovilidad, string Observacion, int CargaId, string Fecha)
        {
            BandaMusicoComzotresDTO bandaMusicoComzotresDTO = new();
            bandaMusicoComzotresDTO.CodigoTipoComision = CodigoTipoComision;
            bandaMusicoComzotresDTO.CodigoEvento = CodigoEvento;
            bandaMusicoComzotresDTO.CodigoGrupoComisionado = CodigoGrupoComisionado;
            bandaMusicoComzotresDTO.CodigoVestimentaUniforme = CodigoVestimentaUniforme;
            bandaMusicoComzotresDTO.NombreEvento = NombreEvento;
            bandaMusicoComzotresDTO.Lugar = Lugar;
            bandaMusicoComzotresDTO.FechaHoraSalida = FechaHoraSalida;
            bandaMusicoComzotresDTO.FechaHoraInicio = FechaHoraInicio;
            bandaMusicoComzotresDTO.FechaHoraTermino = FechaHoraTermino;
            bandaMusicoComzotresDTO.RequerimientoMovilidad = RequerimientoMovilidad;
            bandaMusicoComzotresDTO.Observacion = Observacion;
            bandaMusicoComzotresDTO.CargaId = CargaId;
            bandaMusicoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = bandaMusicoComzotresBL.AgregarRegistro(bandaMusicoComzotresDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(bandaMusicoComzotresBL.EditarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoTipoComision, string CodigoEvento, string CodigoGrupoComisionado,
            string CodigoVestimentaUniforme, string NombreEvento, string Lugar, string FechaHoraSalida, string FechaHoraInicio,
            string FechaHoraTermino, string RequerimientoMovilidad, string Observacion)
        {
            BandaMusicoComzotresDTO bandaMusicoComzotresDTO = new();
            bandaMusicoComzotresDTO.BandaMusicoComzotresId = Id;
            bandaMusicoComzotresDTO.CodigoTipoComision = CodigoTipoComision;
            bandaMusicoComzotresDTO.CodigoEvento = CodigoEvento;
            bandaMusicoComzotresDTO.CodigoGrupoComisionado = CodigoGrupoComisionado;
            bandaMusicoComzotresDTO.CodigoVestimentaUniforme = CodigoVestimentaUniforme;
            bandaMusicoComzotresDTO.NombreEvento = NombreEvento;
            bandaMusicoComzotresDTO.Lugar = Lugar;
            bandaMusicoComzotresDTO.FechaHoraSalida = FechaHoraSalida;
            bandaMusicoComzotresDTO.FechaHoraInicio = FechaHoraInicio;
            bandaMusicoComzotresDTO.FechaHoraTermino = FechaHoraTermino;
            bandaMusicoComzotresDTO.RequerimientoMovilidad = RequerimientoMovilidad;
            bandaMusicoComzotresDTO.Observacion = Observacion;
            bandaMusicoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = bandaMusicoComzotresBL.ActualizarFormato(bandaMusicoComzotresDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            BandaMusicoComzotresDTO bandaMusicoComzotresDTO = new();
            bandaMusicoComzotresDTO.BandaMusicoComzotresId = Id;
            bandaMusicoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (bandaMusicoComzotresBL.EliminarFormato(bandaMusicoComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            BandaMusicoComzotresDTO bandaMusicoComzotresDTO = new();
            bandaMusicoComzotresDTO.CargaId = Id;
            bandaMusicoComzotresDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (bandaMusicoComzotresBL.EliminarCarga(bandaMusicoComzotresDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<BandaMusicoComzotresDTO> lista = new List<BandaMusicoComzotresDTO>();
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

                    lista.Add(new BandaMusicoComzotresDTO
                    {
                        CodigoTipoComision = fila.GetCell(0).ToString(),
                        CodigoEvento = fila.GetCell(1).ToString(),
                        CodigoGrupoComisionado = fila.GetCell(2).ToString(),
                        CodigoVestimentaUniforme = fila.GetCell(3).ToString(),
                        NombreEvento = fila.GetCell(4).ToString(),
                        Lugar = fila.GetCell(5).ToString(),
                        FechaHoraSalida = fila.GetCell(6).ToString(),
                        FechaHoraInicio = fila.GetCell(7).ToString(),
                        FechaHoraTermino = fila.GetCell(8).ToString(),
                        RequerimientoMovilidad = fila.GetCell(9).ToString(),
                        Observacion = fila.GetCell(10).ToString()
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
                    new DataColumn("CodigoTipoComision", typeof(string)),
                    new DataColumn("CodigoEvento", typeof(string)),
                    new DataColumn("CodigoGrupoComisionado", typeof(string)),
                    new DataColumn("CodigoVestimentaUniforme", typeof(string)),
                    new DataColumn("NombreEvento", typeof(string)),
                    new DataColumn("Lugar", typeof(string)),
                    new DataColumn("FechaHoraSalida", typeof(string)),
                    new DataColumn("FechaHoraInicio", typeof(string)),
                    new DataColumn("FechaHoraTermino", typeof(string)),
                    new DataColumn("RequerimientoMovilidad", typeof(string)),
                    new DataColumn("Observacion", typeof(string)),
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
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(6).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(7).ToString()),
                    UtilitariosGlobales.obtenerFechaHora(fila.GetCell(8).ToString()),
                    fila.GetCell(9).ToString(),
                    fila.GetCell(10).ToString(),
                    User.obtenerUsuario()
                   );
            }
            var IND_OPERACION = bandaMusicoComzotresBL.InsertarDatos(dt, Fecha);
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
            var result=localReport.Execute(RenderType.Pdf,extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComzotresBandaMusicoComzotres.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComzotresBandaMusicoComzotres.xlsx");
        }
    }

}