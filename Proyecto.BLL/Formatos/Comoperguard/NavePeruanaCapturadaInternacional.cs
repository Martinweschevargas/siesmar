using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class NavePeruanaCapturadaInternacional
    {
        NavePeruanaCapturadaInternacionalDAO navePeruanaCapturadaInterDAO = new();

        public List<NavePeruanaCapturadaInternacionalDTO> ObtenerLista()
        {
            return navePeruanaCapturadaInterDAO.ObtenerLista();
        }

        public string AgregarRegistro(NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInterDTO)
        {
            return navePeruanaCapturadaInterDAO.AgregarRegistro(navePeruanaCapturadaInterDTO);
        }

        public NavePeruanaCapturadaInternacionalDTO BuscarFormato(int Codigo)
        {
            return navePeruanaCapturadaInterDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInterDTO)
        {
            return navePeruanaCapturadaInterDAO.ActualizaFormato(navePeruanaCapturadaInterDTO);
        }

        public bool EliminarFormato(NavePeruanaCapturadaInternacionalDTO navePeruanaCapturadaInterDTO)
        {
            return navePeruanaCapturadaInterDAO.EliminarFormato(navePeruanaCapturadaInterDTO);
        }

        public bool InsercionMasiva(IEnumerable<NavePeruanaCapturadaInternacionalDTO> navePeruanaCapturadaInterDTO)
        {
            return navePeruanaCapturadaInterDAO.InsercionMasiva(navePeruanaCapturadaInterDTO);
        }

    }
}
