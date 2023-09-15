using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class ActividadDptoCartografia
    {
        ActividadDptoCartografiaDAO actividadDptoCartografiaDAO = new();

        public List<ActividadDptoCartografiaDTO> ObtenerLista(int? CargaId = null)
        {
            return actividadDptoCartografiaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ActividadDptoCartografiaDTO actividadDptoCartografia)
        {
            return actividadDptoCartografiaDAO.AgregarRegistro(actividadDptoCartografia);
        }

        public ActividadDptoCartografiaDTO BuscarFormato(int Codigo)
        {
            return actividadDptoCartografiaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActividadDptoCartografiaDTO actividadDptoCartografiaDTO)
        {
            return actividadDptoCartografiaDAO.ActualizaFormato(actividadDptoCartografiaDTO);
        }

        public bool EliminarFormato(ActividadDptoCartografiaDTO actividadDptoCartografiaDTO)
        {
            return actividadDptoCartografiaDAO.EliminarFormato( actividadDptoCartografiaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return actividadDptoCartografiaDAO.InsertarDatos(datos);
        }

    }
}
