using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar;
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

    public class IpecamarDenunciaAnticorrupcionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        DenunciaAnticorrupcion denunciaAnticorrupcionBL = new();
        CanalDenuncia canalDenunciaBL = new();//CanalDenuncia
        Carga cargaBL = new();

        public IpecamarDenunciaAnticorrupcionController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Denuncias Anticorrupción", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<CanalDenunciaDTO> CanalDenunciaDTO = canalDenunciaBL.ObtenerCanalDenuncias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("");
            return Json(new { data1 = CanalDenunciaDTO, data2 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<DenunciaAnticorrupcionDTO> select = denunciaAnticorrupcionBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }

        public ActionResult Insertar(string FechaRegistroDenuncAntic, string CodigoCanalDenuncia, string EvaluacionRequisitoDenuncAntic,
            string SituacionActualDenuncAntic,int CargaId)
        {
            DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO = new();
            denunciaAnticorrupcionDTO.FechaRegistroDenuncAntic = FechaRegistroDenuncAntic;
            denunciaAnticorrupcionDTO.CodigoCanalDenuncia = CodigoCanalDenuncia;
            denunciaAnticorrupcionDTO.EvaluacionRequisitoDenuncAntic = EvaluacionRequisitoDenuncAntic;
            denunciaAnticorrupcionDTO.SituacionActualDenuncAntic = SituacionActualDenuncAntic;
            denunciaAnticorrupcionDTO.CargaId = CargaId;
            denunciaAnticorrupcionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denunciaAnticorrupcionBL.AgregarRegistro(denunciaAnticorrupcionDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(denunciaAnticorrupcionBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string FechaRegistroDenuncAntic, string CodigoCanalDenuncia, string EvaluacionRequisitoDenuncAntic,
            string SituacionActualDenuncAntic)
        {
            DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO = new();
            denunciaAnticorrupcionDTO.DenunciaAnticorrupcionId = Id;
            denunciaAnticorrupcionDTO.FechaRegistroDenuncAntic = FechaRegistroDenuncAntic;
            denunciaAnticorrupcionDTO.CodigoCanalDenuncia = CodigoCanalDenuncia;
            denunciaAnticorrupcionDTO.EvaluacionRequisitoDenuncAntic = EvaluacionRequisitoDenuncAntic;
            denunciaAnticorrupcionDTO.SituacionActualDenuncAntic = SituacionActualDenuncAntic;
            denunciaAnticorrupcionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = denunciaAnticorrupcionBL.ActualizarFormato(denunciaAnticorrupcionDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO = new();
            denunciaAnticorrupcionDTO.DenunciaAnticorrupcionId = Id;
            denunciaAnticorrupcionDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (denunciaAnticorrupcionBL.EliminarFormato(denunciaAnticorrupcionDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<DenunciaAnticorrupcionDTO> lista = new List<DenunciaAnticorrupcionDTO>();
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

                    lista.Add(new DenunciaAnticorrupcionDTO
                    {
                        FechaRegistroDenuncAntic = fila.GetCell(0).ToString(),
                        CodigoCanalDenuncia = fila.GetCell(1).ToString(),
                        EvaluacionRequisitoDenuncAntic = fila.GetCell(2).ToString(),
                        SituacionActualDenuncAntic = fila.GetCell(3).ToString()
 
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
        public ActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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

            dt.Columns.AddRange(new DataColumn[5]
            {
                    new DataColumn("FechaRegistroDenuncAntic", typeof(string)),
                    new DataColumn("CodigoCanalDenuncia", typeof(string)),
                    new DataColumn("EvaluacionRequisitoDenuncAntic", typeof(string)),
                    new DataColumn("SituacionActualDenuncAntic", typeof(string)),
 
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    UtilitariosGlobales.obtenerFecha(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
 
                    User.obtenerUsuario());
            }
            var IND_OPERACION = denunciaAnticorrupcionBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteEIHN()
        {
            //ESTUDIOS E INVESTIGACIONES HISTÓRICAS NAVALES
            string mimtype = "";
            //int extension = 1;
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Dirintemar\\ReporteEIHN.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var estudioInvestigacionesHistoricasNavales = denunciaAnticorrupcionBL.ObtenerLista();
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("EstudioInvestigacionHistoricoNaval", estudioInvestigacionesHistoricasNavales);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\IpecamarDenunciaAnticorrupcion.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "IpecamarDenunciaAnticorrupcion.xlsx");
        }

    }

}

