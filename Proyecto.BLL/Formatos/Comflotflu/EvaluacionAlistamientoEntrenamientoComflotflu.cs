
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class EvaluacionAlistamientoEntrenamientoComflotflu
    {
        EvaluacionAlistamientoEntrenamientoComflotfluDAO evaluacionAlistamientoEntrenamientoComflotfluDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComflotfluDTO> ObtenerLista()
        {
            return evaluacionAlistamientoEntrenamientoComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComflotfluDTO evaluacionAlistamientoEntrenamientoComflotfluDTO)
        {
            return evaluacionAlistamientoEntrenamientoComflotfluDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComflotfluDTO);
        }

        public EvaluacionAlistamientoEntrenamientoComflotfluDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComflotfluDTO evaluacionAlistamientoEntrenamientoComflotfluDTO)
        {
            return evaluacionAlistamientoEntrenamientoComflotfluDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComflotfluDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComflotfluDTO evaluacionAlistamientoEntrenamientoComflotfluDTO)
        {
            return evaluacionAlistamientoEntrenamientoComflotfluDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComflotfluDTO> evaluacionAlistamientoEntrenamientoComflotfluDTO)
        {
            return evaluacionAlistamientoEntrenamientoComflotfluDAO.InsercionMasiva(evaluacionAlistamientoEntrenamientoComflotfluDTO);
        }

    }
}
