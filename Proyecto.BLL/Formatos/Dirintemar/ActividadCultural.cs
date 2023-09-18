using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class ActividadCultural
    {
        ActividadCulturalDAO actividadCulturalDAO = new();

        public List<ActividadCulturalDTO> ObtenerLista()
        {
            return actividadCulturalDAO.ObtenerLista();
        }

        public string AgregarRegistro(ActividadCulturalDTO actividadCultural)
        {
            return actividadCulturalDAO.AgregarRegistro(actividadCultural);
        }

        public ActividadCulturalDTO EditarFormato(int Codigo)
        {
            return actividadCulturalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActividadCulturalDTO actividadCulturalDTO)
        {
            return actividadCulturalDAO.ActualizaFormato(actividadCulturalDTO);
        }

        public bool EliminarFormato(ActividadCulturalDTO actividadCulturalDTO)
        {
            return actividadCulturalDAO.EliminarFormato( actividadCulturalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return actividadCulturalDAO.InsertarDatos(datos);
        }

    }
}
