using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class ZarpeNave
    {
        ZarpeNaveDAO zarpeNaveDAO = new();

        public List<ZarpeNaveDTO> ObtenerLista()
        {
            return zarpeNaveDAO.ObtenerLista();
        }

        public string AgregarRegistro(ZarpeNaveDTO zarpeNaveDTO)
        {
            return zarpeNaveDAO.AgregarRegistro(zarpeNaveDTO);
        }

        public ZarpeNaveDTO BuscarFormato(int Codigo)
        {
            return zarpeNaveDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ZarpeNaveDTO zarpeNaveDTO)
        {
            return zarpeNaveDAO.ActualizaFormato(zarpeNaveDTO);
        }

        public bool EliminarFormato(ZarpeNaveDTO zarpeNaveDTO)
        {
            return zarpeNaveDAO.EliminarFormato(zarpeNaveDTO);
        }

        public bool InsercionMasiva(IEnumerable<ZarpeNaveDTO> zarpeNaveDTO)
        {
            return zarpeNaveDAO.InsercionMasiva(zarpeNaveDTO);
        }

    }
}
