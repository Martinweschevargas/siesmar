using Marina.Siesmar.AccesoDatos.Formatos.Disamar;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Disamar
{
    public class RegistroAtencionEmergencia
    {
        RegistroAtencionEmergenciaDAO registroAtencionEmergenciaDAO = new();

        public List<RegistroAtencionEmergenciaDTO> ObtenerLista(int? CargaId = null)
        {
            return registroAtencionEmergenciaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO)
        {
            return registroAtencionEmergenciaDAO.AgregarRegistro(registroAtencionEmergenciaDTO);
        }

        public RegistroAtencionEmergenciaDTO BuscarFormato(int Codigo)
        {
            return registroAtencionEmergenciaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO)
        {
            return registroAtencionEmergenciaDAO.ActualizaFormato(registroAtencionEmergenciaDTO);
        }

        public bool EliminarFormato(RegistroAtencionEmergenciaDTO registroAtencionEmergenciaDTO)
        {
            return registroAtencionEmergenciaDAO.EliminarFormato(registroAtencionEmergenciaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroAtencionEmergenciaDAO.InsertarDatos(datos);
        }

    }
}
