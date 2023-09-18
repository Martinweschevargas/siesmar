using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class EntregaArregloFloralCeremonia
    {
        EntregaArregloFloralCeremoniaDAO entregaArregloFloralCeremoniaDAO = new();

        public List<EntregaArregloFloralCeremoniaDTO> ObtenerLista(int? CargaId = null)
        {
            return entregaArregloFloralCeremoniaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO)
        {
            return entregaArregloFloralCeremoniaDAO.AgregarRegistro(entregaArregloFloralCeremoniaDTO);
        }

        public EntregaArregloFloralCeremoniaDTO BuscarFormato(int Codigo)
        {
            return entregaArregloFloralCeremoniaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO)
        {
            return entregaArregloFloralCeremoniaDAO.ActualizaFormato(entregaArregloFloralCeremoniaDTO);
        }

        public bool EliminarFormato(EntregaArregloFloralCeremoniaDTO entregaArregloFloralCeremoniaDTO)
        {
            return entregaArregloFloralCeremoniaDAO.EliminarFormato(entregaArregloFloralCeremoniaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return entregaArregloFloralCeremoniaDAO.InsertarDatos(datos);
        }

    }
}
