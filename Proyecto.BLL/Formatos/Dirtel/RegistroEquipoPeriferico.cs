using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroEquipoPeriferico
    {
        RegistroEquipoPerifericoDAO registroEquipoPerifericoDAO = new();

        public List<RegistroEquipoPerifericoDTO> ObtenerLista()
        {
            return registroEquipoPerifericoDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroEquipoPerifericoDTO registroEquipoPeriferico)
        {
            return registroEquipoPerifericoDAO.AgregarRegistro(registroEquipoPeriferico);
        }

        public RegistroEquipoPerifericoDTO BuscarFormato(int Codigo)
        {
            return registroEquipoPerifericoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEquipoPerifericoDTO registroEquipoPerifericoDTO)
        {
            return registroEquipoPerifericoDAO.ActualizaFormato(registroEquipoPerifericoDTO);
        }

        public bool EliminarFormato(RegistroEquipoPerifericoDTO registroEquipoPerifericoDTO)
        {
            return registroEquipoPerifericoDAO.EliminarFormato( registroEquipoPerifericoDTO);
        }
        public string InsertarDatos(DataTable datos)
        {
            return registroEquipoPerifericoDAO.InsertarDatos(datos);
        }


    }
}
