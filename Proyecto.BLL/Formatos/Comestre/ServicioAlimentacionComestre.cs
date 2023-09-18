using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class ServicioAlimentacionComestre
    {
        ServicioAlimentacionComestreDAO servicioAlimentacionComestreDAO = new();

        public List<ServicioAlimentacionComestreDTO> ObtenerLista()
        {
            return servicioAlimentacionComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(ServicioAlimentacionComestreDTO servicioAlimentacionComestre)
        {
            return servicioAlimentacionComestreDAO.AgregarRegistro(servicioAlimentacionComestre);
        }

        public ServicioAlimentacionComestreDTO BuscarFormato(int Codigo)
        {
            return servicioAlimentacionComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO)
        {
            return servicioAlimentacionComestreDAO.ActualizaFormato(servicioAlimentacionComestreDTO);
        }

        public bool EliminarFormato(ServicioAlimentacionComestreDTO servicioAlimentacionComestreDTO)
        {
            return servicioAlimentacionComestreDAO.EliminarFormato( servicioAlimentacionComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<ServicioAlimentacionComestreDTO> servicioAlimentacionComestreDTO)
        {
            return servicioAlimentacionComestreDAO.InsercionMasiva(servicioAlimentacionComestreDTO);
        }

    }
}
