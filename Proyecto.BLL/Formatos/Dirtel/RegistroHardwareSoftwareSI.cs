using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroHardwareSoftwareSI
    {
        RegistroHardwareSoftwareSIDAO registroHardwareSoftwareSIDAO = new();

        public List<RegistroHardwareSoftwareSIDTO> ObtenerLista(int? CargaId = null)
        {
            return registroHardwareSoftwareSIDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSI)
        {
            return registroHardwareSoftwareSIDAO.AgregarRegistro(registroHardwareSoftwareSI);
        }

        public RegistroHardwareSoftwareSIDTO BuscarFormato(int Codigo)
        {
            return registroHardwareSoftwareSIDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO)
        {
            return registroHardwareSoftwareSIDAO.ActualizaFormato(registroHardwareSoftwareSIDTO);
        }

        public bool EliminarFormato(RegistroHardwareSoftwareSIDTO registroHardwareSoftwareSIDTO)
        {
            return registroHardwareSoftwareSIDAO.EliminarFormato( registroHardwareSoftwareSIDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroHardwareSoftwareSIDAO.InsertarDatos(datos);
        }


    }
}
