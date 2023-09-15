using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class ServicioPeluqueriaComestre
    {
        ServicioPeluqueriaComestreDAO servicioPeluqueriaComestreDAO = new();

        public List<ServicioPeluqueriaComestreDTO> ObtenerLista()
        {
            return servicioPeluqueriaComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(ServicioPeluqueriaComestreDTO servicioPeluqueriaComestre)
        {
            return servicioPeluqueriaComestreDAO.AgregarRegistro(servicioPeluqueriaComestre);
        }

        public ServicioPeluqueriaComestreDTO BuscarFormato(int Codigo)
        {
            return servicioPeluqueriaComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ServicioPeluqueriaComestreDTO servicioPeluqueriaComestreDTO)
        {
            return servicioPeluqueriaComestreDAO.ActualizaFormato(servicioPeluqueriaComestreDTO);
        }

        public bool EliminarFormato(ServicioPeluqueriaComestreDTO servicioPeluqueriaComestreDTO)
        {
            return servicioPeluqueriaComestreDAO.EliminarFormato( servicioPeluqueriaComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<ServicioPeluqueriaComestreDTO> servicioPeluqueriaComestreDTO)
        {
            return servicioPeluqueriaComestreDAO.InsercionMasiva(servicioPeluqueriaComestreDTO);
        }

    }
}
