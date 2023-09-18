using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class ServicioMovilidadComestre
    {
        ServicioMovilidadComestreDAO servicioMovilidadComestreDAO = new();

        public List<ServicioMovilidadComestreDTO> ObtenerLista()
        {
            return servicioMovilidadComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(ServicioMovilidadComestreDTO servicioMovilidadComestre)
        {
            return servicioMovilidadComestreDAO.AgregarRegistro(servicioMovilidadComestre);
        }

        public ServicioMovilidadComestreDTO BuscarFormato(int Codigo)
        {
            return servicioMovilidadComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioMovilidadComestreDTO servicioMovilidadComestreDTO)
        {
            return servicioMovilidadComestreDAO.ActualizaFormato(servicioMovilidadComestreDTO);
        }

        public bool EliminarFormato(ServicioMovilidadComestreDTO servicioMovilidadComestreDTO)
        {
            return servicioMovilidadComestreDAO.EliminarFormato( servicioMovilidadComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<ServicioMovilidadComestreDTO> servicioMovilidadComestreDTO)
        {
            return servicioMovilidadComestreDAO.InsercionMasiva(servicioMovilidadComestreDTO);
        }

    }
}
