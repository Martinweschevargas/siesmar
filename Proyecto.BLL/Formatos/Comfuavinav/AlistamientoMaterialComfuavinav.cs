using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class AlistamientoMaterialComfuavinav
    {
        AlistamientoMaterialComfuavinavDAO alistamientoMaterialComfuavinavDAO = new();

        public List<AlistamientoMaterialComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO, string? fecha)
        {
            return alistamientoMaterialComfuavinavDAO.AgregarRegistro(alistamientoMaterialComfuavinavDTO, fecha);
        }

        public AlistamientoMaterialComfuavinavDTO EditarFormado(int Codigo)
        {
            return alistamientoMaterialComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO)
        {
            return alistamientoMaterialComfuavinavDAO.ActualizaFormato(alistamientoMaterialComfuavinavDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO)
        {
            return alistamientoMaterialComfuavinavDAO.EliminarFormato(alistamientoMaterialComfuavinavDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComfuavinavDTO alistamientoMaterialComfuavinavDTO)
        {
            return alistamientoMaterialComfuavinavDAO.EliminarCarga(alistamientoMaterialComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}
