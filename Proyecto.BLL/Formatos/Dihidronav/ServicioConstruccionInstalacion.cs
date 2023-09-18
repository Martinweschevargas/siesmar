using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class ServicioConstruccionInstalacion
    {
        ServicioConstruccionInstalacionDAO servicioConstruccionInstalacionDAO = new();

        public List<ServicioConstruccionInstalacionDTO> ObtenerLista(int? CargaId = null)
        {
            return servicioConstruccionInstalacionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ServicioConstruccionInstalacionDTO servicioConstruccionInstalacion)
        {
            return servicioConstruccionInstalacionDAO.AgregarRegistro(servicioConstruccionInstalacion);
        }

        public ServicioConstruccionInstalacionDTO BuscarFormato(int Codigo)
        {
            return servicioConstruccionInstalacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO)
        {
            return servicioConstruccionInstalacionDAO.ActualizaFormato(servicioConstruccionInstalacionDTO);
        }

        public bool EliminarFormato(ServicioConstruccionInstalacionDTO servicioConstruccionInstalacionDTO)
        {
            return servicioConstruccionInstalacionDAO.EliminarFormato( servicioConstruccionInstalacionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return servicioConstruccionInstalacionDAO.InsertarDatos(datos);
        }

    }
}
