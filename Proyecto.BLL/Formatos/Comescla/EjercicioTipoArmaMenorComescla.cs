using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class EjercicioTipoArmaMenorComescla
    {
        EjercicioTipoArmaMenorComesclaDAO ejercicioTipoArmaMenorComesclaDAO = new();

        public List<EjercicioTipoArmaMenorComesclaDTO> ObtenerLista()
        {
            return ejercicioTipoArmaMenorComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO)
        {
            return ejercicioTipoArmaMenorComesclaDAO.AgregarRegistro(ejercicioTipoArmaMenorComesclaDTO);
        }

        public EjercicioTipoArmaMenorComesclaDTO BuscarFormato(int Codigo)
        {
            return ejercicioTipoArmaMenorComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO)
        {
            return ejercicioTipoArmaMenorComesclaDAO.ActualizaFormato(ejercicioTipoArmaMenorComesclaDTO);
        }

        public bool EliminarFormato(EjercicioTipoArmaMenorComesclaDTO ejercicioTipoArmaMenorComesclaDTO)
        {
            return ejercicioTipoArmaMenorComesclaDAO.EliminarFormato(ejercicioTipoArmaMenorComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<EjercicioTipoArmaMenorComesclaDTO> ejercicioTipoArmaMenorComesclaDTO)
        {
            return ejercicioTipoArmaMenorComesclaDAO.InsercionMasiva(ejercicioTipoArmaMenorComesclaDTO);
        }

    }
}
