using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroRINFO
    {
        RegistroRINFODAO registroRINFODAO = new();

        public List<RegistroRINFODTO> ObtenerLista(int? CargaId = null)
        {
            return registroRINFODAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroRINFODTO registroRINFO)
        {
            return registroRINFODAO.AgregarRegistro(registroRINFO);
        }

        public RegistroRINFODTO BuscarFormato(int Codigo)
        {
            return registroRINFODAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroRINFODTO registroRINFODTO)
        {
            return registroRINFODAO.ActualizaFormato(registroRINFODTO);
        }

        public bool EliminarFormato(RegistroRINFODTO registroRINFODTO)
        {
            return registroRINFODAO.EliminarFormato( registroRINFODTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroRINFODAO.InsertarDatos(datos);
        }

    }

}
