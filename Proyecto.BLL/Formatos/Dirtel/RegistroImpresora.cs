using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroImpresora
    {
        RegistroImpresoraDAO registroImpresoraDAO = new();

        public List<RegistroImpresoraDTO> ObtenerLista()
        {
            return registroImpresoraDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroImpresoraDTO registroImpresora)
        {
            return registroImpresoraDAO.AgregarRegistro(registroImpresora);
        }

        public RegistroImpresoraDTO BuscarFormato(int Codigo)
        {
            return registroImpresoraDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroImpresoraDTO registroImpresoraDTO)
        {
            return registroImpresoraDAO.ActualizaFormato(registroImpresoraDTO);
        }

        public bool EliminarFormato(RegistroImpresoraDTO registroImpresoraDTO)
        {
            return registroImpresoraDAO.EliminarFormato( registroImpresoraDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroImpresoraDAO.InsertarDatos(datos);
        }


    }
}
