using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class NavePuertoRETRAM
    {
        NavePuertoRETRAMDAO navePuertoRETRAMDAO = new();

        public List<NavePuertoRETRAMDTO> ObtenerLista()
        {
            return navePuertoRETRAMDAO.ObtenerLista();
        }

        public string AgregarRegistro(NavePuertoRETRAMDTO navePuertoRETRAMDTO)
        {
            return navePuertoRETRAMDAO.AgregarRegistro(navePuertoRETRAMDTO);
        }

        public NavePuertoRETRAMDTO BuscarFormato(int Codigo)
        {
            return navePuertoRETRAMDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(NavePuertoRETRAMDTO navePuertoRETRAMDTO)
        {
            return navePuertoRETRAMDAO.ActualizaFormato(navePuertoRETRAMDTO);
        }

        public bool EliminarFormato(NavePuertoRETRAMDTO navePuertoRETRAMDTO)
        {
            return navePuertoRETRAMDAO.EliminarFormato(navePuertoRETRAMDTO);
        }

        public bool InsercionMasiva(IEnumerable<NavePuertoRETRAMDTO> navePuertoRETRAMDTO)
        {
            return navePuertoRETRAMDAO.InsercionMasiva(navePuertoRETRAMDTO);
        }

    }
}
