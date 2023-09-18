
using Marina.Siesmar.AccesoDatos.Formatos.Disamar;
using Marina.Siesmar.Entidades.Formatos.Disamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Disamar
{
    public class RegistroEgresoHospitalario
    {
        RegistroEgresoHospitalarioDAO registroEgresoHospitalarioDAO = new();

        public List<RegistroEgresoHospitalarioDTO> ObtenerLista(int? CargaId = null)
        {
            return registroEgresoHospitalarioDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO)
        {
            return registroEgresoHospitalarioDAO.AgregarRegistro(registroEgresoHospitalarioDTO);
        }

        public RegistroEgresoHospitalarioDTO BuscarFormato(int Codigo)
        {
            return registroEgresoHospitalarioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO)
        {
            return registroEgresoHospitalarioDAO.ActualizaFormato(registroEgresoHospitalarioDTO);
        }

        public bool EliminarFormato(RegistroEgresoHospitalarioDTO registroEgresoHospitalarioDTO)
        {
            return registroEgresoHospitalarioDAO.EliminarFormato(registroEgresoHospitalarioDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return registroEgresoHospitalarioDAO.InsertarDatos(datos);
        }


    }
}
