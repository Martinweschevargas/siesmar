using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class EjercicioTiroArmaMenorCombasnai
    {
        EjercicioTiroArmaMenorCombasnaiDAO ejercicioTiroArmaMenorCombasnaiDAO = new();

        public List<EjercicioTiroArmaMenorCombasnaiDTO> ObtenerLista()
        {
            return ejercicioTiroArmaMenorCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO)
        {
            return ejercicioTiroArmaMenorCombasnaiDAO.AgregarRegistro(ejercicioTiroArmaMenorCombasnaiDTO);
        }

        public EjercicioTiroArmaMenorCombasnaiDTO BuscarFormato(int Codigo)
        {
            return ejercicioTiroArmaMenorCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO)
        {
            return ejercicioTiroArmaMenorCombasnaiDAO.ActualizaFormato(ejercicioTiroArmaMenorCombasnaiDTO);
        }

        public bool EliminarFormato(EjercicioTiroArmaMenorCombasnaiDTO ejercicioTiroArmaMenorCombasnaiDTO)
        {
            return ejercicioTiroArmaMenorCombasnaiDAO.EliminarFormato(ejercicioTiroArmaMenorCombasnaiDTO);
        }

        public bool InsercionMasiva(IEnumerable<EjercicioTiroArmaMenorCombasnaiDTO> ejercicioTiroArmaMenorCombasnaiDTO)
        {
            return ejercicioTiroArmaMenorCombasnaiDAO.InsercionMasiva(ejercicioTiroArmaMenorCombasnaiDTO);
        }

    }
}
