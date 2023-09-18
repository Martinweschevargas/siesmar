using AspNetCore.Reporting;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Entidades.Seguridad;
using Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro;
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

    public class ComzocuatroAlistamientoMaterialController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        Usuario usuarioBL = new();

        AlistamientoMaterialComzocuatro alistamientoMaterialComzocuatroBL = new();

        UnidadNaval unidadNavalBL = new();
        CapacidadOperativa capacidadOperativaBL = new();
        AlistamientoMaterialRequerido3N alistamientoMaterialRequerido3NBL = new();

        Carga cargaBL = new();

        public ComzocuatroAlistamientoMaterialController(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnviroment = webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [Breadcrumb(FromAction = "Index", Title = "Alistamiento de Material", FromController = typeof(HomeController))]
        public IActionResult Index()
        {
            return View(); 
        }

        public IActionResult cargaCombs()
        {
            List<UnidadNavalDTO> unidadNavalDTO = unidadNavalBL.ObtenerUnidadNavals();
            List<CapacidadOperativaDTO> capacidadOperativaDTO = capacidadOperativaBL.ObtenerCapacidadOperativas();
            List<AlistamientoMaterialRequerido3NDTO> alistamientoMaterialRequerido3NDTO = alistamientoMaterialRequerido3NBL.ObtenerAlistamientoMaterialRequerido3Ns();
            List<CargaDTO> listaCargas = cargaBL.ObtenerListaCargas("AlistamientoMaterialRequerido3N");

            return Json(new { data1 = unidadNavalDTO, data2 = capacidadOperativaDTO, data3 = alistamientoMaterialRequerido3NDTO, data4 = listaCargas });
        }

        public IActionResult CargaTabla()
        {
            List<AlistamientoMaterialComzocuatroDTO> select = alistamientoMaterialComzocuatroBL.ObtenerLista();
            return Json(new { data = select });
        }

        [Breadcrumb(Title = "Carga Individual")]
        public IActionResult Individual()
        {
            return View();
        }
        public ActionResult Insertar(string CodigoCapacidadOperativa, string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo,
             int PorcentajeOperatividad,decimal PorcentajeFuncional, decimal NivelAlistamientoParcial, int CargaId)
        {
            AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO = new();
            alistamientoMaterialComzocuatroDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComzocuatroDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComzocuatroDTO.Requerido = Requerido;
            alistamientoMaterialComzocuatroDTO.Operativo = Operativo;
            alistamientoMaterialComzocuatroDTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialComzocuatroDTO.PorcentajeFuncional = PorcentajeFuncional;
            alistamientoMaterialComzocuatroDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComzocuatroDTO.CargaId = CargaId;
            alistamientoMaterialComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComzocuatroBL.AgregarRegistro(alistamientoMaterialComzocuatroDTO);
            return Content(IND_OPERACION);
        }

        public ActionResult Mostrar(int Id)
        {
            return Json(alistamientoMaterialComzocuatroBL.BuscarFormato(Id));
        }

        public ActionResult Actualizar(int Id, string CodigoCapacidadOperativa, string CodigoUnidadNaval, string CodigoAlistamientoMaterialRequerido3N, int Requerido, int Operativo,
            int PorcentajeOperatividad, decimal PorcentajeFuncional, decimal NivelAlistamientoParcial)
        {
            AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO = new();
            alistamientoMaterialComzocuatroDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComzocuatroDTO.CodigoCapacidadOperativa = CodigoCapacidadOperativa;
            alistamientoMaterialComzocuatroDTO.CodigoUnidadNaval = CodigoUnidadNaval;
            alistamientoMaterialComzocuatroDTO.CodigoAlistamientoMaterialRequerido3N = CodigoAlistamientoMaterialRequerido3N;
            alistamientoMaterialComzocuatroDTO.Requerido = Requerido;
            alistamientoMaterialComzocuatroDTO.Operativo = Operativo;
            alistamientoMaterialComzocuatroDTO.PorcentajeOperatividad = PorcentajeOperatividad;
            alistamientoMaterialComzocuatroDTO.PorcentajeFuncional = PorcentajeFuncional;
            alistamientoMaterialComzocuatroDTO.NivelAlistamientoParcial = NivelAlistamientoParcial;
            alistamientoMaterialComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            var IND_OPERACION = alistamientoMaterialComzocuatroBL.ActualizarFormato(alistamientoMaterialComzocuatroDTO);

            return Content(IND_OPERACION);
        }

        public ActionResult Eliminar(int Id)
        {
            string mensaje = "";
            AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO = new();
            alistamientoMaterialComzocuatroDTO.AlistamientoMaterialId = Id;
            alistamientoMaterialComzocuatroDTO.UsuarioIngresoRegistro = User.obtenerUsuario();

            if (alistamientoMaterialComzocuatroBL.EliminarFormato(alistamientoMaterialComzocuatroDTO) == true)
                mensaje = "1";
            else
                mensaje = "0";

            return Content(mensaje);
        }

        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            string Mensaje = "1";
            List<AlistamientoMaterialComzocuatroDTO> lista = new List<AlistamientoMaterialComzocuatroDTO>();
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

                    lista.Add(new AlistamientoMaterialComzocuatroDTO
                    {
                        CodigoUnidadNaval = fila.GetCell(0).ToString(),
                        CodigoCapacidadOperativa = fila.GetCell(1).ToString(),
                        CodigoAlistamientoMaterialRequerido3N = fila.GetCell(2).ToString(),
                        Requerido = int.Parse(fila.GetCell(3).ToString()),
                        Operativo = int.Parse(fila.GetCell(4).ToString()),
                        PorcentajeOperatividad = int.Parse(fila.GetCell(5).ToString()),
                        PorcentajeFuncional = int.Parse(fila.GetCell(6).ToString()),
                        NivelAlistamientoParcial = int.Parse(fila.GetCell(7).ToString()),
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
        public IActionResult EnviarDatos([FromForm] IFormFile ArchivoExcel)
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

            dt.Columns.AddRange(new DataColumn[9]
            {
                    new DataColumn("CodigoUnidadNaval", typeof(int)),
                    new DataColumn("CodigoCapacidadOperativa", typeof(string)),
                    new DataColumn("CodigoAlistamientoMaterialRequerido3N", typeof(string)),
                    new DataColumn("Requerido", typeof(int)),
                    new DataColumn("Operativo", typeof(int)),
                    new DataColumn("PorcentajeOperatividad", typeof(int)),
                    new DataColumn("PorcentajeFuncional", typeof(int)),
                    new DataColumn("NivelAlistamientoParcial", typeof(int)),
                    new DataColumn("UsuarioIngresoRegistro", typeof(string))
            });

            for (int i = 1; i <= cantidadFilas; i++)
            {
                IRow fila = HojaExcel.GetRow(i);

                dt.Rows.Add(
                             fila.GetCell(0).ToString(),
                             fila.GetCell(1).ToString(),
                             fila.GetCell(2).ToString(),
                             int.Parse(fila.GetCell(3).ToString()),
                             int.Parse(fila.GetCell(4).ToString()),
                             int.Parse(fila.GetCell(5).ToString()),
                             int.Parse(fila.GetCell(6).ToString()),
                             int.Parse(fila.GetCell(7).ToString()),
                            User.obtenerUsuario());
            }
            var IND_OPERACION = alistamientoMaterialComzocuatroBL.InsertarDatos(dt);
            return Content(IND_OPERACION);
        }

    }

}

