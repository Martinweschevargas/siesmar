using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac;
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

    public class ComoperpacEfectivoCompaniaIntervencionRapidaController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        EfectivoCompaniaIntervencionRapida efectivoCompaniaIntervencionRapidaBL = new();
        ComandanciaNaval comandanciaNavalBL = new();
        UbicacionCIRD ubicacionCIRDBL = new();
        Carga cargaBL = new();

        public ComoperpacEfectivoCompaniaIntervencionRapidaController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Efectivos por Compañías de Intervención Rápida", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<ComandanciaNavalDTO> comandanciaNavalDTO = comandanciaNavalBL.ObtenerComandanciaNavals(); ;
            List<UbicacionCIRDDTO> ubicacionCIRD = ubicacionCIRDBL.ObtenerUbicacionCIRDs();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("EfectivoCompaniaIntervencionRapida");
            return Json(new { 
                data1 = comandanciaNavalDTO, 
                data2 = ubicacionCIRD,
                data3 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<EfectivoCompaniaIntervencionRapidaDTO> select = efectivoCompaniaIntervencionRapidaBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string CodigoComandanciaNaval, string CodigoUbicacionCIRD, int CantidadEfectivos, decimal NivelOrganizacion,
            decimal NivelEquipamiento, decimal NivelInstruccion, decimal NivelEntrenamiento, int CargaId, string Fecha)
        {
            EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO = new();
            efectivoCompaniaIntervencionRapidaDTO.CodigoComandanciaNaval = CodigoComandanciaNaval;
            efectivoCompaniaIntervencionRapidaDTO.CodigoUbicacionCIRD = CodigoUbicacionCIRD;
            efectivoCompaniaIntervencionRapidaDTO.CantidadEfectivos = CantidadEfectivos;
            efectivoCompaniaIntervencionRapidaDTO.NivelOrganizacion = NivelOrganizacion;
            efectivoCompaniaIntervencionRapidaDTO.NivelEquipamiento = NivelEquipamiento;
            efectivoCompaniaIntervencionRapidaDTO.NivelInstruccion = NivelInstruccion;
            efectivoCompaniaIntervencionRapidaDTO.NivelEntrenamiento = NivelEntrenamiento;
            efectivoCompaniaIntervencionRapidaDTO.CargaId = CargaId;
            efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoCompaniaIntervencionRapidaBL.AgregarRegistro(efectivoCompaniaIntervencionRapidaDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(efectivoCompaniaIntervencionRapidaBL.EditarFormato(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string CodigoComandanciaNaval, string CodigoUbicacionCIRD, int CantidadEfectivos, 
            decimal NivelOrganizacion, decimal NivelEquipamiento, decimal NivelInstruccion, decimal NivelEntrenamiento)
        {
            EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO = new();
            efectivoCompaniaIntervencionRapidaDTO.EfectivoCompaniaIntervencionRapidaId = Id;
            efectivoCompaniaIntervencionRapidaDTO.CodigoComandanciaNaval = CodigoComandanciaNaval;
            efectivoCompaniaIntervencionRapidaDTO.CodigoUbicacionCIRD = CodigoUbicacionCIRD;
            efectivoCompaniaIntervencionRapidaDTO.CantidadEfectivos = CantidadEfectivos;
            efectivoCompaniaIntervencionRapidaDTO.NivelOrganizacion = NivelOrganizacion;
            efectivoCompaniaIntervencionRapidaDTO.NivelEquipamiento = NivelEquipamiento;
            efectivoCompaniaIntervencionRapidaDTO.NivelInstruccion = NivelInstruccion;
            efectivoCompaniaIntervencionRapidaDTO.NivelEntrenamiento = NivelEntrenamiento;
            efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = efectivoCompaniaIntervencionRapidaBL.ActualizarFormato(efectivoCompaniaIntervencionRapidaDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO = new();
            efectivoCompaniaIntervencionRapidaDTO.EfectivoCompaniaIntervencionRapidaId = Id;
            efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (efectivoCompaniaIntervencionRapidaBL.EliminarFormato(efectivoCompaniaIntervencionRapidaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO = new();
            efectivoCompaniaIntervencionRapidaDTO.CargaId = Id;
            efectivoCompaniaIntervencionRapidaDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (efectivoCompaniaIntervencionRapidaBL.EliminarCarga(efectivoCompaniaIntervencionRapidaDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<EfectivoCompaniaIntervencionRapidaDTO> lista = new List<EfectivoCompaniaIntervencionRapidaDTO>();
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

                    lista.Add(new EfectivoCompaniaIntervencionRapidaDTO
                    {
                        CodigoComandanciaNaval = fila.GetCell(0).ToString(),
                        CodigoUbicacionCIRD = fila.GetCell(1).ToString(),
                        CantidadEfectivos = int.Parse(fila.GetCell(2).ToString()),
                        NivelOrganizacion = decimal.Parse(fila.GetCell(3).ToString()),
                        NivelEquipamiento = decimal.Parse(fila.GetCell(4).ToString()),
                        NivelInstruccion = decimal.Parse(fila.GetCell(5).ToString()),
                        NivelEntrenamiento = decimal.Parse(fila.GetCell(6).ToString())
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
                    new DataColumn("CodigoComandanciaNaval", typeof(string)),
                    new DataColumn("CodigoUbicacionCIRD", typeof(string)),
                    new DataColumn("CantidadEfectivos", typeof(int)),
                    new DataColumn("NivelOrganizacion", typeof(decimal)),
                    new DataColumn("NivelEquipamiento", typeof(decimal)),
                    new DataColumn("NivelInstruccion", typeof(decimal)),
                    new DataColumn("NivelEntrenamiento", typeof(decimal)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                dt.Rows.Add(
                    fila.GetCell(0).ToString(),
                    fila.GetCell(1).ToString(),
                    int.Parse(fila.GetCell(2).ToString()),
                    decimal.Parse(fila.GetCell(3).ToString()),
                    decimal.Parse(fila.GetCell(4).ToString()),
                    decimal.Parse(fila.GetCell(5).ToString()),
                    decimal.Parse(fila.GetCell(6).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = efectivoCompaniaIntervencionRapidaBL.InsertarDatos(dt, Fecha);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\ComoperpacEfectivoCompaniaIntervencionRapida.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "ComoperpacEfectivoCompaniaIntervencionRapida.xlsx");
        }
    }
}

