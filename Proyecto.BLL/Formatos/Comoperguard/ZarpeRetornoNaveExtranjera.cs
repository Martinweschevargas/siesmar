using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class ZarpeRetornoNaveExtranjera
    {
        ZarpeRetornoNaveExtranjeraDAO zarpeRetornoNaveExtranjeraDAO = new();

        public List<ZarpeRetornoNaveExtranjeraDTO> ObtenerLista()
        {
            return zarpeRetornoNaveExtranjeraDAO.ObtenerLista();
        }

        public string AgregarRegistro(ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO)
        {
            return zarpeRetornoNaveExtranjeraDAO.AgregarRegistro(zarpeRetornoNaveExtranjeraDTO);
        }

        public ZarpeRetornoNaveExtranjeraDTO BuscarFormato(int Codigo)
        {
            return zarpeRetornoNaveExtranjeraDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO)
        {
            return zarpeRetornoNaveExtranjeraDAO.ActualizaFormato(zarpeRetornoNaveExtranjeraDTO);
        }

        public bool EliminarFormato(ZarpeRetornoNaveExtranjeraDTO zarpeRetornoNaveExtranjeraDTO)
        {
            return zarpeRetornoNaveExtranjeraDAO.EliminarFormato(zarpeRetornoNaveExtranjeraDTO);
        }

        public bool InsercionMasiva(IEnumerable<ZarpeRetornoNaveExtranjeraDTO> zarpeRetornoNaveExtranjeraDTO)
        {
            return zarpeRetornoNaveExtranjeraDAO.InsercionMasiva(zarpeRetornoNaveExtranjeraDTO);
        }

    }
}
