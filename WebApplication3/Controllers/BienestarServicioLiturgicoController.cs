using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Bienestar;
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

    public class BienestarServicioLiturgicoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;

        ServicioLiturgico servicioLiturgicoBL = new();
        PersonalSolicitante personalSolicitanteBL = new();
        CondicionSolicitante condicionSolicitanteBL = new();
        GradoPersonalMilitar gradoPersonalMilitarBL = new();
        PersonalBeneficiado personalBeneficiadoBL = new();
        CategoriaPago categoriaPagoBL = new();
        ServicioReligioso servicioReligiosoBL = new();
        Carga cargaBL = new();

        public BienestarServicioLiturgicoController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Servicio Litúrgico", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<PersonalSolicitanteDTO> personalSolicitanteDTO = personalSolicitanteBL.ObtenerPersonalSolicitantes();
            List<CondicionSolicitanteDTO> condicionSolicitanteDTO = condicionSolicitanteBL.ObtenerCondicionSolicitantes();
            List<GradoPersonalMilitarDTO> gradoPersonalMilitarDTO = gradoPersonalMilitarBL.ObtenerGradoPersonalMilitars();
            List<PersonalBeneficiadoDTO> personalBeneficiadoDTO = personalBeneficiadoBL.ObtenerPersonalBeneficiados();
            List<CategoriaPagoDTO> categoriaPagoDTO = categoriaPagoBL.ObtenerCategoriaPagos();
            List<ServicioReligiosoDTO> servicioReligiosoDTO = servicioReligiosoBL.ObtenerCapintanias();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ServicioLiturgico");

            return Json(new
            {
                data1 = personalSolicitanteDTO,
                data2 = condicionSolicitanteDTO,
                data3 = gradoPersonalMilitarDTO,
                data4 = personalBeneficiadoDTO,
                data5 = categoriaPagoDTO,
                data6 = servicioReligiosoDTO,
                data7 = listaCargas
            });
        }

        public IActionResult CargaTabla()
        {
            List<ServicioLiturgicoDTO> select = servicioLiturgicoBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
           
            return View();
        }

        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar(string FechaServicioLiturgico, string DNISolicitante, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoGradoPersonalMilitar, string CodigoPersonalBeneficiado, string CodigoCategoriaPago, string CodigoServicioReligioso, int CargaId, string fecha)
        {
            ServicioLiturgicoDTO servicioLiturgicoDTO = new();
            servicioLiturgicoDTO.FechaServicioLiturgico = FechaServicioLiturgico;
            servicioLiturgicoDTO.DNISolicitante = DNISolicitante;
            servicioLiturgicoDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            servicioLiturgicoDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            servicioLiturgicoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioLiturgicoDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            servicioLiturgicoDTO.CodigoCategoriaPago = CodigoCategoriaPago;
            servicioLiturgicoDTO.CodigoServicioReligioso = CodigoServicioReligioso;
            servicioLiturgicoDTO.CargaId = CargaId;
            servicioLiturgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = servicioLiturgicoBL.AgregarRegistro(servicioLiturgicoDTO, fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(servicioLiturgicoBL.EditarFormato(Id));
        }

        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int Id, string FechaServicioLiturgico, string DNISolicitante, string CodigoPersonalSolicitante, string CodigoCondicionSolicitante,
            string CodigoGradoPersonalMilitar, string CodigoPersonalBeneficiado, string CodigoCategoriaPago, string CodigoServicioReligioso)
        {
            ServicioLiturgicoDTO servicioLiturgicoDTO = new();
            servicioLiturgicoDTO.ServicioLiturgicoId = Id;
            servicioLiturgicoDTO.FechaServicioLiturgico = FechaServicioLiturgico;
            servicioLiturgicoDTO.DNISolicitante = DNISolicitante;
            servicioLiturgicoDTO.CodigoPersonalSolicitante = CodigoPersonalSolicitante;
            servicioLiturgicoDTO.CodigoCondicionSolicitante = CodigoCondicionSolicitante;
            servicioLiturgicoDTO.CodigoGradoPersonalMilitar = CodigoGradoPersonalMilitar;
            servicioLiturgicoDTO.CodigoPersonalBeneficiado = CodigoPersonalBeneficiado;
            servicioLiturgicoDTO.CodigoCategoriaPago = CodigoCategoriaPago;
            servicioLiturgicoDTO.CodigoServicioReligioso = CodigoServicioReligioso;
            servicioLiturgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            var IND_OPERACION = servicioLiturgicoBL.ActualizarFormato(servicioLiturgicoDTO);

            return Content(IND_OPERACION);
        }

        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ServicioLiturgicoDTO servicioLiturgicoDTO = new();
            servicioLiturgicoDTO.ServicioLiturgicoId = Id;
            servicioLiturgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (servicioLiturgicoBL.EliminarFormato(servicioLiturgicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ServicioLiturgicoDTO servicioLiturgicoDTO = new();
            servicioLiturgicoDTO.CargaId = Id;
            servicioLiturgicoDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (servicioLiturgicoBL.EliminarCarga(servicioLiturgicoDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }


        [HttpPost]
        public ActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ServicioLiturgicoDTO> lista = new List<ServicioLiturgicoDTO>();
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

                    lista.Add(new ServicioLiturgicoDTO
                    {
                        FechaServicioLiturgico = fila.GetCell(0).ToString(),
                        DNISolicitante = fila.GetCell(1).ToString(),
                        CodigoPersonalSolicitante = fila.GetCell(2).ToString(),
                        CodigoCondicionSolicitante = fila.GetCell(3).ToString(),
                        CodigoGradoPersonalMilitar = fila.GetCell(4).ToString(),
                        CodigoPersonalBeneficiado = fila.GetCell(5).ToString(),
                        CodigoCategoriaPago = fila.GetCell(6).ToString(),
                        CodigoServicioReligioso = fila.GetCell(7).ToString()
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("FechaServicioLiturgico", typeof(string)),
                    new DataColumn("DNISolicitante", typeof(string)),
                    new DataColumn("CodigoPersonalSolicitante", typeof(string)),
                    new DataColumn("CodigoCondicionSolicitante", typeof(string)),
                    new DataColumn("CodigoGradoPersonalMilitar", typeof(string)),
                    new DataColumn("CodigoPersonalBeneficiado", typeof(string)),
                    new DataColumn("CodigoCategoriaPago", typeof(string)),
                    new DataColumn("CodigoServicioReligioso", typeof(string)),
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
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = servicioLiturgicoBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
        }

        public IActionResult ReporteSL(int idCarga)
        {
            string mimtype = "";
            var path = $"{this._webHostEnviroment.WebRootPath}\\Reports\\Bienestar\\ServicioLiturgico.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var servicioLiturgico = servicioLiturgicoBL.BienestarVisualizacionServicioLiturgico(idCarga);
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("ServicioLiturgico", servicioLiturgico);
            var result = localReport.Execute(RenderType.Pdf, 1, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        [HttpGet]
        public IActionResult DownloadFile()
        {
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\BienestarServicioLiturgico.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "BienestarServicioLiturgico.xlsx");
        }

       
    }

}

