using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroIncidenteInformatico
    {
        RegistroIncidenteInformaticoDAO registroIncidenteInformaticoDAO = new();

        public List<RegistroIncidenteInformaticoDTO> ObtenerLista(int? CargaId = null)
        {
            return registroIncidenteInformaticoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroIncidenteInformaticoDTO registroIncidenteInformatico)
        {
            return registroIncidenteInformaticoDAO.AgregarRegistro(registroIncidenteInformatico);
        }

        public RegistroIncidenteInformaticoDTO BuscarFormato(int Codigo)
        {
            return registroIncidenteInformaticoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO)
        {
            return registroIncidenteInformaticoDAO.ActualizaFormato(registroIncidenteInformaticoDTO);
        }

        public bool EliminarFormato(RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO)
        {
            return registroIncidenteInformaticoDAO.EliminarFormato( registroIncidenteInformaticoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroIncidenteInformaticoDAO.InsertarDatos(datos);
        }


    }
}
