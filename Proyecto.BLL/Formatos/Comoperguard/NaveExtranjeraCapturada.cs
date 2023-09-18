using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class NaveExtranjeraCapturada
    {
        NaveExtranjeraCapturadaDAO naveExtranjeraCapturadaDAO = new();

        public List<NaveExtranjeraCapturadaDTO> ObtenerLista()
        {
            return naveExtranjeraCapturadaDAO.ObtenerLista();
        }

        public string AgregarRegistro(NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO)
        {
            return naveExtranjeraCapturadaDAO.AgregarRegistro(naveExtranjeraCapturadaDTO);
        }

        public NaveExtranjeraCapturadaDTO BuscarFormato(int Codigo)
        {
            return naveExtranjeraCapturadaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO)
        {
            return naveExtranjeraCapturadaDAO.ActualizaFormato(naveExtranjeraCapturadaDTO);
        }

        public bool EliminarFormato(NaveExtranjeraCapturadaDTO naveExtranjeraCapturadaDTO)
        {
            return naveExtranjeraCapturadaDAO.EliminarFormato(naveExtranjeraCapturadaDTO);
        }

        public bool InsercionMasiva(IEnumerable<NaveExtranjeraCapturadaDTO> naveExtranjeraCapturadaDTO)
        {
            return naveExtranjeraCapturadaDAO.InsercionMasiva(naveExtranjeraCapturadaDTO);
        }

    }
}
