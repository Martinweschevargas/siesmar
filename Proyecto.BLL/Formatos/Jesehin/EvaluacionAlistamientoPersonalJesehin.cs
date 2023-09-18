
using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class EvaluacionAlistamientoPersonalJesehin
    {
        EvaluacionAlistamientoPersonalJesehinDAO evaluacionAlistamientoPersonalJesehinDAO = new();

        public List<EvaluacionAlistamientoPersonalJesehinDTO> ObtenerLista()
        {
            return evaluacionAlistamientoPersonalJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO)
        {
            return evaluacionAlistamientoPersonalJesehinDAO.AgregarRegistro(evaluacionAlistamientoPersonalJesehinDTO);
        }

        public EvaluacionAlistamientoPersonalJesehinDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO)
        {
            return evaluacionAlistamientoPersonalJesehinDAO.ActualizaFormato(evaluacionAlistamientoPersonalJesehinDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalJesehinDTO evaluacionAlistamientoPersonalJesehinDTO)
        {
            return evaluacionAlistamientoPersonalJesehinDAO.EliminarFormato(evaluacionAlistamientoPersonalJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalJesehinDTO> evaluacionAlistamientoPersonalJesehinDTO)
        {
            return evaluacionAlistamientoPersonalJesehinDAO.InsercionMasiva(evaluacionAlistamientoPersonalJesehinDTO);
        }

    }
}
