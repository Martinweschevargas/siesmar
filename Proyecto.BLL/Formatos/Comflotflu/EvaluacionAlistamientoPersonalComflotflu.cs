
using Marina.Siesmar.AccesoDatos.Formatos.Comflotflu;
using Marina.Siesmar.Entidades.Formatos.Comflotflu;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comflotflu
{
    public class EvaluacionAlistamientoPersonalComflotflu
    {
        EvaluacionAlistamientoPersonalComflotfluDAO evaluacionAlistamientoPersonalComflotfluDAO = new();

        public List<EvaluacionAlistamientoPersonalComflotfluDTO> ObtenerLista()
        {
            return evaluacionAlistamientoPersonalComflotfluDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComflotfluDTO evaluacionAlistamientoPersonalComflotfluDTO)
        {
            return evaluacionAlistamientoPersonalComflotfluDAO.AgregarRegistro(evaluacionAlistamientoPersonalComflotfluDTO);
        }

        public EvaluacionAlistamientoPersonalComflotfluDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComflotfluDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComflotfluDTO evaluacionAlistamientoPersonalComflotfluDTO)
        {
            return evaluacionAlistamientoPersonalComflotfluDAO.ActualizaFormato(evaluacionAlistamientoPersonalComflotfluDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComflotfluDTO evaluacionAlistamientoPersonalComflotfluDTO)
        {
            return evaluacionAlistamientoPersonalComflotfluDAO.EliminarFormato(evaluacionAlistamientoPersonalComflotfluDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComflotfluDTO> evaluacionAlistamientoPersonalComflotfluDTO)
        {
            return evaluacionAlistamientoPersonalComflotfluDAO.InsercionMasiva(evaluacionAlistamientoPersonalComflotfluDTO);
        }

    }
}
