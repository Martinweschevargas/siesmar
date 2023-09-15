using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class AccesoInformacionPublica
    {
        AccesoInformacionPublicaDAO accesoInformacionPublicaDAO = new();

        public List<AccesoInformacionPublicaDTO> ObtenerLista(int? CargaId = null)
        {
            return accesoInformacionPublicaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(AccesoInformacionPublicaDTO accesoInformacionPublicaDTO)
        {
            return accesoInformacionPublicaDAO.AgregarRegistro(accesoInformacionPublicaDTO);
        }

        public AccesoInformacionPublicaDTO BuscarFormato(int Codigo)
        {
            return accesoInformacionPublicaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AccesoInformacionPublicaDTO accesoInformacionPublicaDTO)
        {
            return accesoInformacionPublicaDAO.ActualizaFormato(accesoInformacionPublicaDTO);
        }

        public bool EliminarFormato(AccesoInformacionPublicaDTO accesoInformacionPublicaDTO)
        {
            return accesoInformacionPublicaDAO.EliminarFormato(accesoInformacionPublicaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return accesoInformacionPublicaDAO.InsertarDatos(datos);
        }

    }
}
