using Marina.Siesmar.AccesoDatos.Formatos.Disamar;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Disamar
{
    public class RegistroAtencionConsultaExterna
    {
        RegistroAtencionConsultaExternaDAO registroAtencionConsultaExternaDAO = new();

        public List<RegistroAtencionConsultaExternaDTO> ObtenerLista(int? CargaId = null)
        {
            return registroAtencionConsultaExternaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO)
        {
            return registroAtencionConsultaExternaDAO.AgregarRegistro(registroAtencionConsultaExternaDTO);
        }

        public RegistroAtencionConsultaExternaDTO BuscarFormato(int Codigo)
        {
            return registroAtencionConsultaExternaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO)
        {
            return registroAtencionConsultaExternaDAO.ActualizaFormato(registroAtencionConsultaExternaDTO);
        }

        public bool EliminarFormato(RegistroAtencionConsultaExternaDTO registroAtencionConsultaExternaDTO)
        {
            return registroAtencionConsultaExternaDAO.EliminarFormato(registroAtencionConsultaExternaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroAtencionConsultaExternaDAO.InsertarDatos(datos);
        }
    }
}
