using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class ServicioSastreriaComestre
    {
        ServicioSastreriaComestreDAO servicioSastreriaComestreDAO = new();

        public List<ServicioSastreriaComestreDTO> ObtenerLista()
        {
            return servicioSastreriaComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(ServicioSastreriaComestreDTO servicioSastreriaComestre)
        {
            return servicioSastreriaComestreDAO.AgregarRegistro(servicioSastreriaComestre);
        }

        public ServicioSastreriaComestreDTO BuscarFormato(int Codigo)
        {
            return servicioSastreriaComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioSastreriaComestreDTO servicioSastreriaComestreDTO)
        {
            return servicioSastreriaComestreDAO.ActualizaFormato(servicioSastreriaComestreDTO);
        }

        public bool EliminarFormato(ServicioSastreriaComestreDTO servicioSastreriaComestreDTO)
        {
            return servicioSastreriaComestreDAO.EliminarFormato( servicioSastreriaComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<ServicioSastreriaComestreDTO> servicioSastreriaComestreDTO)
        {
            return servicioSastreriaComestreDAO.InsercionMasiva(servicioSastreriaComestreDTO);
        }

    }
}
