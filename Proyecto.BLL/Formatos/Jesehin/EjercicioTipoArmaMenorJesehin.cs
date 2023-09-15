using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class EjercicioTipoArmaMenorJesehin
    {
        EjercicioTipoArmaMenorJesehinDAO ejercicioTipoArmaMenorJesehinDAO = new();

        public List<EjercicioTipoArmaMenorJesehinDTO> ObtenerLista()
        {
            return ejercicioTipoArmaMenorJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehin)
        {
            return ejercicioTipoArmaMenorJesehinDAO.AgregarRegistro(ejercicioTipoArmaMenorJesehin);
        }

        public EjercicioTipoArmaMenorJesehinDTO BuscarFormato(int Codigo)
        {
            return ejercicioTipoArmaMenorJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehinDTO)
        {
            return ejercicioTipoArmaMenorJesehinDAO.ActualizaFormato(ejercicioTipoArmaMenorJesehinDTO);
        }

        public bool EliminarFormato(EjercicioTipoArmaMenorJesehinDTO ejercicioTipoArmaMenorJesehinDTO)
        {
            return ejercicioTipoArmaMenorJesehinDAO.EliminarFormato( ejercicioTipoArmaMenorJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<EjercicioTipoArmaMenorJesehinDTO> ejercicioTipoArmaMenorJesehinDTO)
        {
            return ejercicioTipoArmaMenorJesehinDAO.InsercionMasiva(ejercicioTipoArmaMenorJesehinDTO);
        }

    }
}
