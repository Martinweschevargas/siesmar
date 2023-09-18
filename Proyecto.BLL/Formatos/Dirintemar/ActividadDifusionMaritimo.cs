using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class ActividadDifusionMaritimo
    {
        ActividadDifusionMaritimoDAO actividadDifusionMaritimoDAO = new();

        public List<ActividadDifusionMaritimoDTO> ObtenerLista()
        {
            return actividadDifusionMaritimoDAO.ObtenerLista();
        }

        public string AgregarRegistro(ActividadDifusionMaritimoDTO actividadDifusionMaritimo)
        {
            return actividadDifusionMaritimoDAO.AgregarRegistro(actividadDifusionMaritimo);
        }

        public ActividadDifusionMaritimoDTO EditarFormato(int Codigo)
        {
            return actividadDifusionMaritimoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO)
        {
            return actividadDifusionMaritimoDAO.ActualizaFormato(actividadDifusionMaritimoDTO);
        }

        public bool EliminarFormato(ActividadDifusionMaritimoDTO actividadDifusionMaritimoDTO)
        {
            return actividadDifusionMaritimoDAO.EliminarFormato(actividadDifusionMaritimoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return actividadDifusionMaritimoDAO.InsertarDatos(datos);
        }

    }
}
