using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EvaluacionAlistamientoEntrenamiento
    {
        readonly EvaluacionAlistamientoEntrenamientoDAO evaluacionAlistamientoEntrenamientoDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoDTO> ObtenerEvaluacionAlistamientoEntrenamientos()
        {
            return evaluacionAlistamientoEntrenamientoDAO.ObtenerEvaluacionAlistamientoEntrenamientos();
        }

        public string AgregarEvaluacionAlistamientoEntrenamiento(EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDto)
        {
            return evaluacionAlistamientoEntrenamientoDAO.AgregarEvaluacionAlistamientoEntrenamiento(evaluacionAlistamientoEntrenamientoDto);
        }

        public EvaluacionAlistamientoEntrenamientoDTO BuscarEvaluacionAlistamientoEntrenamientoID(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoDAO.BuscarEvaluacionAlistamientoEntrenamientoID(Codigo);
        }

        public string ActualizarEvaluacionAlistamientoEntrenamiento(EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDto)
        {
            return evaluacionAlistamientoEntrenamientoDAO.ActualizarEvaluacionAlistamientoEntrenamiento(evaluacionAlistamientoEntrenamientoDto);
        }

        public string EliminarEvaluacionAlistamientoEntrenamiento(EvaluacionAlistamientoEntrenamientoDTO evaluacionAlistamientoEntrenamientoDto)
        {
            return evaluacionAlistamientoEntrenamientoDAO.EliminarEvaluacionAlistamientoEntrenamiento(evaluacionAlistamientoEntrenamientoDto);
        }

    }
}
