using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class AlistamientoMaterialComescuama
    {
        AlistamientoMaterialComescuamaDAO alistamientoMaterialComescuamaDAO = new();

        public List<AlistamientoMaterialComescuamaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistamientoMaterialComescuamaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO, string? fecha)
        {
            return alistamientoMaterialComescuamaDAO.AgregarRegistro(alistamientoMaterialComescuamaDTO, fecha);
        }

        public AlistamientoMaterialComescuamaDTO EditarFormato(int Codigo)
        {
            return alistamientoMaterialComescuamaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO)
        {
            return alistamientoMaterialComescuamaDAO.ActualizaFormato(alistamientoMaterialComescuamaDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO)
        {
            return alistamientoMaterialComescuamaDAO.EliminarFormato(alistamientoMaterialComescuamaDTO);
        }

        public bool EliminarCarga(AlistamientoMaterialComescuamaDTO alistamientoMaterialComescuamaDTO)
        {
            return alistamientoMaterialComescuamaDAO.EliminarCarga(alistamientoMaterialComescuamaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistamientoMaterialComescuamaDAO.InsertarDatos(datos, fecha);
        }
    }
}
