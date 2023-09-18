using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroEquipoConectividad
    {
        RegistroEquipoConectividadDAO registroEquipoConectividadDAO = new();

        public List<RegistroEquipoConectividadDTO> ObtenerLista()
        {
            return registroEquipoConectividadDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroEquipoConectividadDTO registroEquipoConectividad)
        {
            return registroEquipoConectividadDAO.AgregarRegistro(registroEquipoConectividad);
        }

        public RegistroEquipoConectividadDTO BuscarFormato(int Codigo)
        {
            return registroEquipoConectividadDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEquipoConectividadDTO registroEquipoConectividadDTO)
        {
            return registroEquipoConectividadDAO.ActualizaFormato(registroEquipoConectividadDTO);
        }

        public bool EliminarFormato(RegistroEquipoConectividadDTO registroEquipoConectividadDTO)
        {
            return registroEquipoConectividadDAO.EliminarFormato(registroEquipoConectividadDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroEquipoConectividadDAO.InsertarDatos(datos);
        }

    }
}