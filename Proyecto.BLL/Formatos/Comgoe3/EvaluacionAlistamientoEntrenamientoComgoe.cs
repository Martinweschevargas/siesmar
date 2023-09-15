
using Marina.Siesmar.AccesoDatos.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comgoe3
{
    public class EvaluacionAlistamientoEntrenamientoComgoe
    {
        EvaluacionAlistamientoEntrenamientoComgoeDAO evaluacionAlistamientoEntrenamientoComgoeDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComgoeDTO> ObtenerLista()
        {
            return evaluacionAlistamientoEntrenamientoComgoeDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComgoeDTO evaluacionAlistamientoEntrenamientoComgoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComgoeDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComgoeDTO);
        }

        public EvaluacionAlistamientoEntrenamientoComgoeDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComgoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComgoeDTO evaluacionAlistamientoEntrenamientoComgoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComgoeDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComgoeDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComgoeDTO evaluacionAlistamientoEntrenamientoComgoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComgoeDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComgoeDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComgoeDTO> evaluacionAlistamientoEntrenamientoComgoeDTO)
        {
            return evaluacionAlistamientoEntrenamientoComgoeDAO.InsercionMasiva(evaluacionAlistamientoEntrenamientoComgoeDTO);
        }

    }
}
