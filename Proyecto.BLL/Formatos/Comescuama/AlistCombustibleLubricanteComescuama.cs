using Marina.Siesmar.AccesoDatos.Formatos.Comescuama;
using Marina.Siesmar.Entidades.Formatos.Comescuama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescuama
{
    public class AlistCombustibleLubricanteComescuama
    {
        AlistCombustibleLubricanteComescuamaDAO alistCombustibleLubricanteComescuamaDAO = new();

        public List<AlistCombustibleLubricanteComescuamaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return alistCombustibleLubricanteComescuamaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO, string? fecha)
        {
            return alistCombustibleLubricanteComescuamaDAO.AgregarRegistro(alistCombustibleLubricanteComescuamaDTO, fecha);
        }

        public AlistCombustibleLubricanteComescuamaDTO EditarFormato(int Codigo)
        {
            return alistCombustibleLubricanteComescuamaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO)
        {
            return alistCombustibleLubricanteComescuamaDAO.ActualizaFormato(alistCombustibleLubricanteComescuamaDTO);
        }

        public bool EliminarFormato(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO)
        {
            return alistCombustibleLubricanteComescuamaDAO.EliminarFormato(alistCombustibleLubricanteComescuamaDTO);
        }

        public bool EliminarCarga(AlistCombustibleLubricanteComescuamaDTO alistCombustibleLubricanteComescuamaDTO)
        {
            return alistCombustibleLubricanteComescuamaDAO.EliminarCarga(alistCombustibleLubricanteComescuamaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return alistCombustibleLubricanteComescuamaDAO.InsertarDatos(datos, fecha);
        }
    }
}
