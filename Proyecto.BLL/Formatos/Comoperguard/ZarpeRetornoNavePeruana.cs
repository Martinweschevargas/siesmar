using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class ZarpeRetornoNavePeruana
    {
        ZarpeRetornoNavePeruanaDAO ZarpeRetornoNavePeruanaDAO = new();

        public List<ZarpeRetornoNavePeruanaDTO> ObtenerLista()
        {
            return ZarpeRetornoNavePeruanaDAO.ObtenerLista();
        }

        public string AgregarRegistro(ZarpeRetornoNavePeruanaDTO ZarpeRetornoNavePeruanaDTO)
        {
            return ZarpeRetornoNavePeruanaDAO.AgregarRegistro(ZarpeRetornoNavePeruanaDTO);
        }

        public ZarpeRetornoNavePeruanaDTO BuscarFormato(int Codigo)
        {
            return ZarpeRetornoNavePeruanaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ZarpeRetornoNavePeruanaDTO ZarpeRetornoNavePeruanaDTO)
        {
            return ZarpeRetornoNavePeruanaDAO.ActualizaFormato(ZarpeRetornoNavePeruanaDTO);
        }

        public bool EliminarFormato(ZarpeRetornoNavePeruanaDTO ZarpeRetornoNavePeruanaDTO)
        {
            return ZarpeRetornoNavePeruanaDAO.EliminarFormato(ZarpeRetornoNavePeruanaDTO);
        }

        public bool InsercionMasiva(IEnumerable<ZarpeRetornoNavePeruanaDTO> ZarpeRetornoNavePeruanaDTO)
        {
            return ZarpeRetornoNavePeruanaDAO.InsercionMasiva(ZarpeRetornoNavePeruanaDTO);
        }

    }
}
