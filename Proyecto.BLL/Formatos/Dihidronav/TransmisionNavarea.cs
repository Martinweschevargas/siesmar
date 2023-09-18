using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class TransmisionNavarea
    {
        TransmisionNavareaDAO transmisionNavareaDAO = new();

        public List<TransmisionNavareaDTO> ObtenerLista(int? CargaId = null)
        {
            return transmisionNavareaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(TransmisionNavareaDTO transmisionNavarea)
        {
            return transmisionNavareaDAO.AgregarRegistro(transmisionNavarea);
        }

        public TransmisionNavareaDTO BuscarFormato(int Codigo)
        {
            return transmisionNavareaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(TransmisionNavareaDTO transmisionNavareaDTO)
        {
            return transmisionNavareaDAO.ActualizaFormato(transmisionNavareaDTO);
        }

        public bool EliminarFormato(TransmisionNavareaDTO transmisionNavareaDTO)
        {
            return transmisionNavareaDAO.EliminarFormato( transmisionNavareaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return transmisionNavareaDAO.InsertarDatos(datos);
        }

    }
}
