using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class EvaluacionAlistamientoEntrenamientoComfas
    {
        EvaluacionAlistamientoEntrenamientoComfasDAO evaluacionAlistEntrenComfasDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComfasDTO> ObtenerLista()
        {
            return evaluacionAlistEntrenComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistEntrenComfasDTO)
        {
            return evaluacionAlistEntrenComfasDAO.AgregarRegistro(evaluacionAlistEntrenComfasDTO);
        }

        public EvaluacionAlistamientoEntrenamientoComfasDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistEntrenComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistEntrenComfasDTO)
        {
            return evaluacionAlistEntrenComfasDAO.ActualizaFormato(evaluacionAlistEntrenComfasDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfasDTO evaluacionAlistEntrenComfasDTO)
        {
            return evaluacionAlistEntrenComfasDAO.EliminarFormato(evaluacionAlistEntrenComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComfasDTO> evaluacionAlistEntrenComfasDTO)
        {
            return evaluacionAlistEntrenComfasDAO.InsercionMasiva(evaluacionAlistEntrenComfasDTO);
        }

    }
}
