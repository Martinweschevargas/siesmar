using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class ConsolidadoComisionCeremonia
    {
        ConsolidadoComisionCeremoniaDAO consolidadoComisionCeremoniaDAO = new();

        public List<ConsolidadoComisionCeremoniaDTO> ObtenerLista(int? CargaId = null)
        {
            return consolidadoComisionCeremoniaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO)
        {
            return consolidadoComisionCeremoniaDAO.AgregarRegistro(consolidadoComisionCeremoniaDTO);
        }

        public ConsolidadoComisionCeremoniaDTO BuscarFormato(int Codigo)
        {
            return consolidadoComisionCeremoniaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO)
        {
            return consolidadoComisionCeremoniaDAO.ActualizaFormato(consolidadoComisionCeremoniaDTO);
        }

        public bool EliminarFormato(ConsolidadoComisionCeremoniaDTO consolidadoComisionCeremoniaDTO)
        {
            return consolidadoComisionCeremoniaDAO.EliminarFormato(consolidadoComisionCeremoniaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return consolidadoComisionCeremoniaDAO.InsertarDatos(datos);
        }

    }
}
