using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroEquipoSatelital
    {
        RegistroEquipoSatelitalDAO registroEquipoSatelitalDAO = new();

        public List<RegistroEquipoSatelitalDTO> ObtenerLista()
        {
            return registroEquipoSatelitalDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroEquipoSatelitalDTO registroEquipoSatelital)
        {
            return registroEquipoSatelitalDAO.AgregarRegistro(registroEquipoSatelital);
        }

        public RegistroEquipoSatelitalDTO BuscarFormato(int Codigo)
        {
            return registroEquipoSatelitalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEquipoSatelitalDTO registroEquipoSatelitalDTO)
        {
            return registroEquipoSatelitalDAO.ActualizaFormato(registroEquipoSatelitalDTO);
        }

        public bool EliminarFormato(RegistroEquipoSatelitalDTO registroEquipoSatelitalDTO)
        {
            return registroEquipoSatelitalDAO.EliminarFormato( registroEquipoSatelitalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroEquipoSatelitalDAO.InsertarDatos(datos);
        }


    }
}
