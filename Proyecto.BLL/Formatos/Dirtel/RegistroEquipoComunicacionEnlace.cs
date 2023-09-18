using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroEquipoComunicacionEnlace
    {
        RegistroEquipoComunicacionEnlaceDAO registroEquipoComunicacionEnlaceDAO = new();

        public List<RegistroEquipoComunicacionEnlaceDTO> ObtenerLista()
        {
            return registroEquipoComunicacionEnlaceDAO.ObtenerLista();
        }

        public string AgregarRegistro(RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlace)
        {
            return registroEquipoComunicacionEnlaceDAO.AgregarRegistro(registroEquipoComunicacionEnlace);
        }

        public RegistroEquipoComunicacionEnlaceDTO BuscarFormato(int Codigo)
        {
            return registroEquipoComunicacionEnlaceDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO)
        {
            return registroEquipoComunicacionEnlaceDAO.ActualizaFormato(registroEquipoComunicacionEnlaceDTO);
        }

        public bool EliminarFormato(RegistroEquipoComunicacionEnlaceDTO registroEquipoComunicacionEnlaceDTO)
        {
            return registroEquipoComunicacionEnlaceDAO.EliminarFormato( registroEquipoComunicacionEnlaceDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroEquipoComunicacionEnlaceDAO.InsertarDatos(datos);
        }


    }
}
