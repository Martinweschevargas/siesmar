using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class EvaluacionAlistamientoPersonalComescla
    {
        EvaluacionAlistamientoPersonalComesclaDAO evaluacionAlistamientoPersonalComesclaDAO = new();

        public List<EvaluacionAlistamientoPersonalComesclaDTO> ObtenerLista()
        {
            return evaluacionAlistamientoPersonalComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComesclaDTO evaluacionAlistamientoPersonalComesclaDTO)
        {
            return evaluacionAlistamientoPersonalComesclaDAO.AgregarRegistro(evaluacionAlistamientoPersonalComesclaDTO);
        }

        public EvaluacionAlistamientoPersonalComesclaDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComesclaDTO evaluacionAlistamientoPersonalComesclaDTO)
        {
            return evaluacionAlistamientoPersonalComesclaDAO.ActualizaFormato(evaluacionAlistamientoPersonalComesclaDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComesclaDTO evaluacionAlistamientoPersonalComesclaDTO)
        {
            return evaluacionAlistamientoPersonalComesclaDAO.EliminarFormato(evaluacionAlistamientoPersonalComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComesclaDTO> evaluacionAlistamientoPersonalComesclaDTO)
        {
            return evaluacionAlistamientoPersonalComesclaDAO.InsercionMasiva(evaluacionAlistamientoPersonalComesclaDTO);
        }

    }
}
