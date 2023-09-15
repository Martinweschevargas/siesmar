using Marina.Siesmar.AccesoDatos.Formatos.Dirtel;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirtel
{
    public class RegistroDesarrolloSistemaInstitucional
    {
        RegistroDesarrolloSistemaInstitucionalDAO registroDesarrolloSistemaInstitucionalDAO = new();

        public List<RegistroDesarrolloSistemaInstitucionalDTO> ObtenerLista(int? CargaId = null)
        {
            return registroDesarrolloSistemaInstitucionalDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucional)
        {
            return registroDesarrolloSistemaInstitucionalDAO.AgregarRegistro(registroDesarrolloSistemaInstitucional);
        }

        public RegistroDesarrolloSistemaInstitucionalDTO BuscarFormato(int Codigo)
        {
            return registroDesarrolloSistemaInstitucionalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO)
        {
            return registroDesarrolloSistemaInstitucionalDAO.ActualizaFormato(registroDesarrolloSistemaInstitucionalDTO);
        }

        public bool EliminarFormato(RegistroDesarrolloSistemaInstitucionalDTO registroDesarrolloSistemaInstitucionalDTO)
        {
            return registroDesarrolloSistemaInstitucionalDAO.EliminarFormato( registroDesarrolloSistemaInstitucionalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroDesarrolloSistemaInstitucionalDAO.InsertarDatos(datos);
        }

    }
}
