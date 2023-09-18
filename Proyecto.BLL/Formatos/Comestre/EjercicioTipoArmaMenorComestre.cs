using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class EjercicioTipoArmaMenorComestre
    {
        EjercicioTipoArmaMenorComestreDAO ejercicioTipoArmaMenorComestreDAO = new();

        public List<EjercicioTipoArmaMenorComestreDTO> ObtenerLista()
        {
            return ejercicioTipoArmaMenorComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestre)
        {
            return ejercicioTipoArmaMenorComestreDAO.AgregarRegistro(ejercicioTipoArmaMenorComestre);
        }

        public EjercicioTipoArmaMenorComestreDTO BuscarFormato(int Codigo)
        {
            return ejercicioTipoArmaMenorComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO)
        {
            return ejercicioTipoArmaMenorComestreDAO.ActualizaFormato(ejercicioTipoArmaMenorComestreDTO);
        }

        public bool EliminarFormato(EjercicioTipoArmaMenorComestreDTO ejercicioTipoArmaMenorComestreDTO)
        {
            return ejercicioTipoArmaMenorComestreDAO.EliminarFormato( ejercicioTipoArmaMenorComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<EjercicioTipoArmaMenorComestreDTO> ejercicioTipoArmaMenorComestreDTO)
        {
            return ejercicioTipoArmaMenorComestreDAO.InsercionMasiva(ejercicioTipoArmaMenorComestreDTO);
        }

    }
}
