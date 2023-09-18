using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class ServicioLavanderiaComestre
    {
        ServicioLavanderiaComestreDAO servicioLavanderiaComestreDAO = new();

        public List<ServicioLavanderiaComestreDTO> ObtenerLista()
        {
            return servicioLavanderiaComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(ServicioLavanderiaComestreDTO servicioLavanderiaComestre)
        {
            return servicioLavanderiaComestreDAO.AgregarRegistro(servicioLavanderiaComestre);
        }

        public ServicioLavanderiaComestreDTO BuscarFormato(int Codigo)
        {
            return servicioLavanderiaComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioLavanderiaComestreDTO servicioLavanderiaComestreDTO)
        {
            return servicioLavanderiaComestreDAO.ActualizaFormato(servicioLavanderiaComestreDTO);
        }

        public bool EliminarFormato(ServicioLavanderiaComestreDTO servicioLavanderiaComestreDTO)
        {
            return servicioLavanderiaComestreDAO.EliminarFormato( servicioLavanderiaComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<ServicioLavanderiaComestreDTO> servicioLavanderiaComestreDTO)
        {
            return servicioLavanderiaComestreDAO.InsercionMasiva(servicioLavanderiaComestreDTO);
        }

    }
}
