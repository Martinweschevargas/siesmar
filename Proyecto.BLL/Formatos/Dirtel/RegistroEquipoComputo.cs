using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroEquipoComputo
    {
        RegistroEquipoComputoDAO registroEquipoComputoDAO = new();

        public List<RegistroEquipoComputoDTO> ObtenerLista()
        {
            return registroEquipoComputoDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroEquipoComputoDTO registroEquipoComputo)
        {
            return registroEquipoComputoDAO.AgregarRegistro(registroEquipoComputo);
        }

        public RegistroEquipoComputoDTO BuscarFormato(int Codigo)
        {
            return registroEquipoComputoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEquipoComputoDTO registroEquipoComputoDTO)
        {
            return registroEquipoComputoDAO.ActualizaFormato(registroEquipoComputoDTO);
        }

        public bool EliminarFormato(RegistroEquipoComputoDTO registroEquipoComputoDTO)
        {
            return registroEquipoComputoDAO.EliminarFormato( registroEquipoComputoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroEquipoComputoDAO.InsertarDatos(datos);
        }


    }
}
