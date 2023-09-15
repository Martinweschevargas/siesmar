using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroEquipoComunicacion
    {
        RegistroEquipoComunicacionDAO registroEquipoComunicacionDAO = new();

        public List<RegistroEquipoComunicacionDTO> ObtenerLista()
        {
            return registroEquipoComunicacionDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroEquipoComunicacionDTO registroEquipoComunicacion)
        {
            return registroEquipoComunicacionDAO.AgregarRegistro(registroEquipoComunicacion);
        }

        public RegistroEquipoComunicacionDTO BuscarFormato(int Codigo)
        {
            return registroEquipoComunicacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEquipoComunicacionDTO registroEquipoComunicacionDTO)
        {
            return registroEquipoComunicacionDAO.ActualizaFormato(registroEquipoComunicacionDTO);
        }

        public bool EliminarFormato(RegistroEquipoComunicacionDTO registroEquipoComunicacionDTO)
        {
            return registroEquipoComunicacionDAO.EliminarFormato( registroEquipoComunicacionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroEquipoComunicacionDAO.InsertarDatos(datos);
        }


    }
}
