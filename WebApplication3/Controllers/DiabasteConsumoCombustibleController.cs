using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Diabaste;
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
    public class DiabasteConsumoCombustibleController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        ConsumoCombustible consumoCombustibleBL = new();
        Mes mesBL = new();
        ClaseCombustible claseCombustibleBL = new();
        VehiculoServicioGrupo vehiculoServicioGrupoBL = new();
        PuntoDistribucionCombustible puntoDistribucionCombustibleBL = new();
        VehiculoServicioTipo vehiculoServicioTipoBL = new();
        TipoPresupuesto tipoPresupuestoBL = new();
        CombustibleEspecificacion combustibleEspecificacionBL = new();
        Carga cargaBL = new();

        public DiabasteConsumoCombustibleController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult cargaCombs()
        {
            List<MesDTO> mesDTO = mesBL.ObtenerMess();
            List<ClaseCombustibleDTO> combustibleDTO = claseCombustibleBL.ObtenerClaseCombustibles();
            List<VehiculoServicioGrupoDTO> vehiculoServicioGrupoDTO = vehiculoServicioGrupoBL.ObtenerVehiculoServicioGrupos();
            List<PuntoDistribucionCombustibleDTO> puntoDistribucionCombustibleDTO = puntoDistribucionCombustibleBL.ObtenerPuntoDistribucionCombustibles();
            List<VehiculoServicioTipoDTO> vehiculoServicioTipoDTO = vehiculoServicioTipoBL.ObtenerVehiculoServicioTipos();
            List<TipoPresupuestoDTO> tipoPresupuestoDTO = tipoPresupuestoBL.ObtenerTipoPresupuestos();
            List<CombustibleEspecificacionDTO> combustibleEspecificacionDTO = combustibleEspecificacionBL.ObtenerCombustibleEspecificacions();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("ConsumoCombustible");
            return Json(new
            {
                data1 = mesDTO,
                data2 = combustibleDTO,
                data3 = vehiculoServicioGrupoDTO,
                data4 = puntoDistribucionCombustibleDTO,
                data5 = vehiculoServicioTipoDTO,
                data6 = tipoPresupuestoDTO,
                data7 = combustibleEspecificacionDTO,
                data8 = listaCargas});
        }

        public IActionResult CargaTabla()
        {
            List<ConsumoCombustibleDTO> consumoCombustibleDTO = consumoCombustibleBL.ObtenerLista();
            return Json(new { data = consumoCombustibleDTO });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        //Registrar[AuthorizePermission(Formato: 43, Permiso: 1)]
        public ActionResult Insertar( int Anio, string CodigoClaseCombustible, string CodigoVehiculoServicioGrupo, 
            string NumeroMes, string CodigoPuntoDistribucionCombustible, string CodigoVehiculoServicioTipo,
            string CodigoTipoPresupuesto, string CodigoCombustibleEspecificacion, int CantidadConsumidaGalon, 
            int ValorCantidadConsumida, int CargaId, string Fecha)
        {
            ConsumoCombustibleDTO consumoCombustibleDTO = new();
            consumoCombustibleDTO.Anio = Anio;
            consumoCombustibleDTO.NumeroMes = NumeroMes;
            consumoCombustibleDTO.CodigoClaseCombustible = CodigoClaseCombustible;
            consumoCombustibleDTO.CodigoVehiculoServicioGrupo = CodigoVehiculoServicioGrupo;
            consumoCombustibleDTO.CodigoPuntoDistribucionCombustible = CodigoPuntoDistribucionCombustible;
            consumoCombustibleDTO.CodigoVehiculoServicioTipo = CodigoVehiculoServicioTipo;
            consumoCombustibleDTO.CodigoTipoPresupuesto = CodigoTipoPresupuesto;
            consumoCombustibleDTO.CodigoCombustibleEspecificacion = CodigoCombustibleEspecificacion;
            consumoCombustibleDTO.CantidadConsumidaGalon = CantidadConsumidaGalon;
            consumoCombustibleDTO.ValorCantidadConsumida = ValorCantidadConsumida;
            consumoCombustibleDTO.CargaId = CargaId;
            consumoCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consumoCombustibleBL.AgregarRegistro(consumoCombustibleDTO, Fecha);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(consumoCombustibleBL.EditarFormado(Id));
        }
        //Actualizar[AuthorizePermission(Formato: 43, Permiso: 2)]
        public ActionResult Actualizar(int ConsumoCombustibleId, int Anio, string CodigoClaseCombustible, 
            string CodigoVehiculoServicioGrupo, string NumeroMes, string CodigoPuntoDistribucionCombustible, 
            string CodigoVehiculoServicioTipo, string CodigoTipoPresupuesto, string CodigoCombustibleEspecificacion, 
            int CantidadConsumidaGalon, int ValorCantidadConsumida)
        {
            ConsumoCombustibleDTO consumoCombustibleDTO = new();
            consumoCombustibleDTO.ConsumoCombustibleId = ConsumoCombustibleId;
            consumoCombustibleDTO.Anio = Anio;
            consumoCombustibleDTO.NumeroMes = NumeroMes;
            consumoCombustibleDTO.CodigoClaseCombustible = CodigoClaseCombustible;
            consumoCombustibleDTO.CodigoVehiculoServicioGrupo = CodigoVehiculoServicioGrupo;
            consumoCombustibleDTO.CodigoPuntoDistribucionCombustible = CodigoPuntoDistribucionCombustible;
            consumoCombustibleDTO.CodigoVehiculoServicioTipo = CodigoVehiculoServicioTipo;
            consumoCombustibleDTO.CodigoTipoPresupuesto = CodigoTipoPresupuesto;
            consumoCombustibleDTO.CodigoCombustibleEspecificacion = CodigoCombustibleEspecificacion;
            consumoCombustibleDTO.CantidadConsumidaGalon = CantidadConsumidaGalon;
            consumoCombustibleDTO.ValorCantidadConsumida = ValorCantidadConsumida;
            consumoCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = consumoCombustibleBL.ActualizarFormato(consumoCombustibleDTO);

            return Content(IND_OPERACION);
        }
        //Eliminar[AuthorizePermission(Formato: 43, Permiso: 3)]
        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            ConsumoCombustibleDTO consumoCombustibleDTO = new();
            consumoCombustibleDTO.ConsumoCombustibleId = Id;
            consumoCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (consumoCombustibleBL.EliminarFormato(consumoCombustibleDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }
        //Eliminar Carga[AuthorizePermission(Formato: 43, Permiso: 5)]
        public ActionResult EliminarCarga(int Id)
        {
            string mensaje = "";
            ConsumoCombustibleDTO consumoCombustibleDTO = new();
            consumoCombustibleDTO.CargaId = Id;
            consumoCombustibleDTO.UsuarioIngresoRegistro = User.obtenerUsuario();
            if (consumoCombustibleBL.EliminarCarga(consumoCombustibleDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";
            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {
            string Mensaje = "1";
            List<ConsumoCombustibleDTO> lista = new List<ConsumoCombustibleDTO>();
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

                    lista.Add(new ConsumoCombustibleDTO
                    {
                        Anio = int.Parse(fila.GetCell(0).ToString()),
                        NumeroMes = fila.GetCell(1).ToString(),
                        CodigoClaseCombustible = fila.GetCell(2).ToString(),
                        CodigoVehiculoServicioGrupo = fila.GetCell(3).ToString(),
                        CodigoPuntoDistribucionCombustible = fila.GetCell(4).ToString(),
                        CodigoVehiculoServicioTipo = fila.GetCell(5).ToString(),
                        CodigoTipoPresupuesto = fila.GetCell(6).ToString(),
                        CodigoCombustibleEspecificacion = fila.GetCell(7).ToString(),
                        CantidadConsumidaGalon = int.Parse(fila.GetCell(8).ToString()),
                        ValorCantidadConsumida = int.Parse(fila.GetCell(9).ToString()),
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

            dt.Columns.AddRange(new DataColumn[11]
            {
                    new DataColumn("Anio", typeof(int)),
                    new DataColumn("NumeroMes", typeof(string)),
                    new DataColumn("CodigoClaseCombustible", typeof(string)),
                    new DataColumn("CodigoVehiculoServicioGrupo", typeof(string)),
                    new DataColumn("CodigoPuntoDistribucionCombustible", typeof(string)),
                    new DataColumn("CodigoVehiculoServicioTipo", typeof(string)),
                    new DataColumn("CodigoTipoPresupuesto", typeof(string)),
                    new DataColumn("CodigoCombustibleEspecificacion", typeof(string)),
                    new DataColumn("CantidadConsumidaGalon", typeof(int)),
                    new DataColumn("ValorCantidadConsumida", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                    int.Parse(fila.GetCell(0).ToString()),
                    fila.GetCell(1).ToString(),
                    fila.GetCell(2).ToString(),
                    fila.GetCell(3).ToString(),
                    fila.GetCell(4).ToString(),
                    fila.GetCell(5).ToString(),
                    fila.GetCell(6).ToString(),
                    fila.GetCell(7).ToString(),
                    int.Parse(fila.GetCell(8).ToString()),
                    int.Parse(fila.GetCell(9).ToString()),
                    User.obtenerUsuario());
            }
            var IND_OPERACION = consumoCombustibleBL.InsertarDatos(dt, Fecha);
            return Content(IND_OPERACION);
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
            var path = $"{this._webHostEnviroment.WebRootPath}\\Formatos\\DiabasteConsumoCombustible.xlsx";
            var fs = new FileStream(path, FileMode.Open);

            return File(fs, "application/octet-stream", "DiabasteConsumoCombustible.xlsx");
        }

    }

}