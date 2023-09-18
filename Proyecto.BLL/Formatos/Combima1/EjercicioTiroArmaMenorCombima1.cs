using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class EjercicioTiroArmaMenorCombima1
    {
        EjercicioTiroArmaMenorCombima1DAO ejercicioTiroArmaMenorCombima1DAO = new();

        public List<EjercicioTiroArmaMenorCombima1DTO> ObtenerLista()
        {
            return ejercicioTiroArmaMenorCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO)
        {
            return ejercicioTiroArmaMenorCombima1DAO.AgregarRegistro(ejercicioTiroArmaMenorCombima1DTO);
        }

        public EjercicioTiroArmaMenorCombima1DTO BuscarFormato(int Codigo)
        {
            return ejercicioTiroArmaMenorCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO)
        {
            return ejercicioTiroArmaMenorCombima1DAO.ActualizaFormato(ejercicioTiroArmaMenorCombima1DTO);
        }

        public bool EliminarFormato(EjercicioTiroArmaMenorCombima1DTO ejercicioTiroArmaMenorCombima1DTO)
        {
            return ejercicioTiroArmaMenorCombima1DAO.EliminarFormato(ejercicioTiroArmaMenorCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<EjercicioTiroArmaMenorCombima1DTO> ejercicioTiroArmaMenorCombima1DTO)
        {
            return ejercicioTiroArmaMenorCombima1DAO.InsercionMasiva(ejercicioTiroArmaMenorCombima1DTO);
        }

    }
}
