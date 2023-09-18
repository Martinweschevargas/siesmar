using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class BandaMusicoComescla
    {
        BandaMusicoComesclaDAO bandaMusicoComesclaDAO = new();

        public List<BandaMusicoComesclaDTO> ObtenerLista()
        {
            return bandaMusicoComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(BandaMusicoComesclaDTO bandaMusicoComesclaDTO)
        {
            return bandaMusicoComesclaDAO.AgregarRegistro(bandaMusicoComesclaDTO);
        }

        public BandaMusicoComesclaDTO BuscarFormato(int Codigo)
        {
            return bandaMusicoComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(BandaMusicoComesclaDTO bandaMusicoComesclaDTO)
        {
            return bandaMusicoComesclaDAO.ActualizaFormato(bandaMusicoComesclaDTO);
        }

        public bool EliminarFormato(BandaMusicoComesclaDTO bandaMusicoComesclaDTO)
        {
            return bandaMusicoComesclaDAO.EliminarFormato(bandaMusicoComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<BandaMusicoComesclaDTO> bandaMusicoComesclaDTO)
        {
            return bandaMusicoComesclaDAO.InsercionMasiva(bandaMusicoComesclaDTO);
        }

    }
}
