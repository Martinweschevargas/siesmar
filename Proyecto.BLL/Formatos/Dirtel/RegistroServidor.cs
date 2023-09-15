using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroServidor
    {
        RegistroServidorDAO registroServidorDAO = new();

        public List<RegistroServidorDTO> ObtenerLista()
        {
            return registroServidorDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroServidorDTO registroServidor)
        {
            return registroServidorDAO.AgregarRegistro(registroServidor);
        }

        public RegistroServidorDTO BuscarFormato(int Codigo)
        {
            return registroServidorDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroServidorDTO registroServidorDTO)
        {
            return registroServidorDAO.ActualizaFormato(registroServidorDTO);
        }

        public bool EliminarFormato(RegistroServidorDTO registroServidorDTO)
        {
            return registroServidorDAO.EliminarFormato( registroServidorDTO);
        }
        public string InsertarDatos(DataTable datos)
        {
            return registroServidorDAO.InsertarDatos(datos);
        }


    }
}
