using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class AperturaCierrePuertos
    {
        AperturaCierrePuertosDAO aperturaCierrePuertosDAO = new();

        public List<AperturaCierrePuertosDTO> ObtenerLista()
        {
            return aperturaCierrePuertosDAO.ObtenerLista();
        }

        public string AgregarRegistro(AperturaCierrePuertosDTO aperturaCierrePuertosDTO)
        {
            return aperturaCierrePuertosDAO.AgregarRegistro(aperturaCierrePuertosDTO);
        }

        public AperturaCierrePuertosDTO BuscarFormato(int Codigo)
        {
            return aperturaCierrePuertosDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AperturaCierrePuertosDTO aperturaCierrePuertosDTO)
        {
            return aperturaCierrePuertosDAO.ActualizaFormato(aperturaCierrePuertosDTO);
        }

        public bool EliminarFormato(AperturaCierrePuertosDTO aperturaCierrePuertosDTO)
        {
            return aperturaCierrePuertosDAO.EliminarFormato(aperturaCierrePuertosDTO);
        }

        public bool InsercionMasiva(IEnumerable<AperturaCierrePuertosDTO> aperturaCierrePuertosDTO)
        {
            return aperturaCierrePuertosDAO.InsercionMasiva(aperturaCierrePuertosDTO);
        }

    }
}
