using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class ActividadDepartamentoOceanografia
    {
        ActividadDepartamentoOceanografiaDAO actividadDepartamentoOceanografiaDAO = new();

        public List<ActividadDepartamentoOceanografiaDTO> ObtenerLista(int? CargaId = null)
        {
            return actividadDepartamentoOceanografiaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografia)
        {
            return actividadDepartamentoOceanografiaDAO.AgregarRegistro(actividadDepartamentoOceanografia);
        }

        public ActividadDepartamentoOceanografiaDTO BuscarFormato(int Codigo)
        {
            return actividadDepartamentoOceanografiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO)
        {
            return actividadDepartamentoOceanografiaDAO.ActualizaFormato(actividadDepartamentoOceanografiaDTO);
        }

        public bool EliminarFormato(ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO)
        {
            return actividadDepartamentoOceanografiaDAO.EliminarFormato( actividadDepartamentoOceanografiaDTO);
        }


        public string InsertarDatos(DataTable datos)
        {
            return actividadDepartamentoOceanografiaDAO.InsertarDatos(datos);
        }


    }
}
