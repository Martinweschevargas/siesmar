using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class EvaluacionAlistamientoEntrenamientoComestre
    {
        EvaluacionAlistamientoEntrenamientoComestreDAO evaluacionAlistamientoEntrenamientoComestreDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComestreDTO> ObtenerLista()
        {
            return evaluacionAlistamientoEntrenamientoComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComestreDTO evaluacionAlistamientoEntrenamientoComestre)
        {
            return evaluacionAlistamientoEntrenamientoComestreDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComestre);
        }

        public EvaluacionAlistamientoEntrenamientoComestreDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComestreDTO evaluacionAlistamientoEntrenamientoComestreDTO)
        {
            return evaluacionAlistamientoEntrenamientoComestreDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComestreDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComestreDTO evaluacionAlistamientoEntrenamientoComestreDTO)
        {
            return evaluacionAlistamientoEntrenamientoComestreDAO.EliminarFormato( evaluacionAlistamientoEntrenamientoComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComestreDTO> evaluacionAlistamientoEntrenamientoComestreDTO)
        {
            return evaluacionAlistamientoEntrenamientoComestreDAO.InsercionMasiva(evaluacionAlistamientoEntrenamientoComestreDTO);
        }

    }
}
