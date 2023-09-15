using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class EvaluacionAlistamientoPersonalComestre
    {
        EvaluacionAlistamientoPersonalComestreDAO evaluacionAlistamientoPersonalComestreDAO = new();

        public List<EvaluacionAlistamientoPersonalComestreDTO> ObtenerLista()
        {
            return evaluacionAlistamientoPersonalComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComestreDTO evaluacionAlistamientoPersonalComestre)
        {
            return evaluacionAlistamientoPersonalComestreDAO.AgregarRegistro(evaluacionAlistamientoPersonalComestre);
        }

        public EvaluacionAlistamientoPersonalComestreDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComestreDTO evaluacionAlistamientoPersonalComestreDTO)
        {
            return evaluacionAlistamientoPersonalComestreDAO.ActualizaFormato(evaluacionAlistamientoPersonalComestreDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComestreDTO evaluacionAlistamientoPersonalComestreDTO)
        {
            return evaluacionAlistamientoPersonalComestreDAO.EliminarFormato( evaluacionAlistamientoPersonalComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComestreDTO> evaluacionAlistamientoPersonalComestreDTO)
        {
            return evaluacionAlistamientoPersonalComestreDAO.InsercionMasiva(evaluacionAlistamientoPersonalComestreDTO);
        }

    }
}
