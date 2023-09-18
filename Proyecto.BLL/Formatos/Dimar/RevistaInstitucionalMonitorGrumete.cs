using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class RevistaInstitucionalMonitorGrumete
    {
        RevistaInstitucionalMonitorGrumeteDAO revistaInstitucionalMonitorGrumeteDAO = new();

        public List<RevistaInstitucionalMonitorGrumeteDTO> ObtenerLista(int? CargaId = null)
        {
            return revistaInstitucionalMonitorGrumeteDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO)
        {
            return revistaInstitucionalMonitorGrumeteDAO.AgregarRegistro(revistaInstitucionalMonitorGrumeteDTO);
        }

        public RevistaInstitucionalMonitorGrumeteDTO BuscarFormato(int Codigo)
        {
            return revistaInstitucionalMonitorGrumeteDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO)
        {
            return revistaInstitucionalMonitorGrumeteDAO.ActualizaFormato(revistaInstitucionalMonitorGrumeteDTO);
        }

        public bool EliminarFormato(RevistaInstitucionalMonitorGrumeteDTO revistaInstitucionalMonitorGrumeteDTO)
        {
            return revistaInstitucionalMonitorGrumeteDAO.EliminarFormato(revistaInstitucionalMonitorGrumeteDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return revistaInstitucionalMonitorGrumeteDAO.InsertarDatos(datos);
        }

    }
}
