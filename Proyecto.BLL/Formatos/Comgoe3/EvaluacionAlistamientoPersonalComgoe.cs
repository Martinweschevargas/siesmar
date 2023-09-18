
using Marina.Siesmar.AccesoDatos.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class EvaluacionAlistamientoPersonalComgoe
    {
        EvaluacionAlistamientoPersonalComgoeDAO evaluacionAlistamientoPersonalComgoeDAO = new();

        public List<EvaluacionAlistamientoPersonalComgoeDTO> ObtenerLista()
        {
            return evaluacionAlistamientoPersonalComgoeDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComgoeDTO evaluacionAlistamientoPersonalComgoeDTO)
        {
            return evaluacionAlistamientoPersonalComgoeDAO.AgregarRegistro(evaluacionAlistamientoPersonalComgoeDTO);
        }

        public EvaluacionAlistamientoPersonalComgoeDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComgoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComgoeDTO evaluacionAlistamientoPersonalComgoeDTO)
        {
            return evaluacionAlistamientoPersonalComgoeDAO.ActualizaFormato(evaluacionAlistamientoPersonalComgoeDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComgoeDTO evaluacionAlistamientoPersonalComgoeDTO)
        {
            return evaluacionAlistamientoPersonalComgoeDAO.EliminarFormato(evaluacionAlistamientoPersonalComgoeDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComgoeDTO> evaluacionAlistamientoPersonalComgoeDTO)
        {
            return evaluacionAlistamientoPersonalComgoeDAO.InsercionMasiva(evaluacionAlistamientoPersonalComgoeDTO);
        }

    }
}
