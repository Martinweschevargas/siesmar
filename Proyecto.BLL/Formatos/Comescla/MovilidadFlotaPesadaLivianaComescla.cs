using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class MovilidadFlotaPesadaLivianaComescla
    {
        MovilidadFlotaPesadaLivianaComesclaDAO movilidadFlotaPesadaLivianaComesclaDAO = new();

        public List<MovilidadFlotaPesadaLivianaComesclaDTO> ObtenerLista()
        {
            return movilidadFlotaPesadaLivianaComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(MovilidadFlotaPesadaLivianaComesclaDTO movilidadFlotaPesadaLivianaComesclaDTO)
        {
            return movilidadFlotaPesadaLivianaComesclaDAO.AgregarRegistro(movilidadFlotaPesadaLivianaComesclaDTO);
        }

        public MovilidadFlotaPesadaLivianaComesclaDTO BuscarFormato(int Codigo)
        {
            return movilidadFlotaPesadaLivianaComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MovilidadFlotaPesadaLivianaComesclaDTO movilidadFlotaPesadaLivianaComesclaDTO)
        {
            return movilidadFlotaPesadaLivianaComesclaDAO.ActualizaFormato(movilidadFlotaPesadaLivianaComesclaDTO);
        }

        public bool EliminarFormato(MovilidadFlotaPesadaLivianaComesclaDTO movilidadFlotaPesadaLivianaComesclaDTO)
        {
            return movilidadFlotaPesadaLivianaComesclaDAO.EliminarFormato(movilidadFlotaPesadaLivianaComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<MovilidadFlotaPesadaLivianaComesclaDTO> movilidadFlotaPesadaLivianaComesclaDTO)
        {
            return movilidadFlotaPesadaLivianaComesclaDAO.InsercionMasiva(movilidadFlotaPesadaLivianaComesclaDTO);
        }

    }
}
