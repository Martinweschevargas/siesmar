using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class NavegacionConsumoCombustible
    {
        NavegacionConsumoCombustibleDAO navegacionConsumoCombustibleDAO = new();

        public List<NavegacionConsumoCombustibleDTO> ObtenerLista()
        {
            return navegacionConsumoCombustibleDAO.ObtenerLista();
        }

        public string AgregarRegistro(NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO)
        {
            return navegacionConsumoCombustibleDAO.AgregarRegistro(navegacionConsumoCombustibleDTO);
        }

        public NavegacionConsumoCombustibleDTO BuscarFormato(int Codigo)
        {
            return navegacionConsumoCombustibleDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO)
        {
            return navegacionConsumoCombustibleDAO.ActualizaFormato(navegacionConsumoCombustibleDTO);
        }

        public bool EliminarFormato(NavegacionConsumoCombustibleDTO navegacionConsumoCombustibleDTO)
        {
            return navegacionConsumoCombustibleDAO.EliminarFormato(navegacionConsumoCombustibleDTO);
        }

        public bool InsercionMasiva(IEnumerable<NavegacionConsumoCombustibleDTO> navegacionConsumoCombustibleDTO)
        {
            return navegacionConsumoCombustibleDAO.InsercionMasiva(navegacionConsumoCombustibleDTO);
        }

    }
}
