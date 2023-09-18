using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class EvaluacionAlistEntrenamientoCombima1
    {
        EvaluacionAlistEntrenamientoCombima1DAO evaluacionAlistEntrenamientoCombima1DAO = new();

        public List<EvaluacionAlistEntrenamientoCombima1DTO> ObtenerLista()
        {
            return evaluacionAlistEntrenamientoCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO)
        {
            return evaluacionAlistEntrenamientoCombima1DAO.AgregarRegistro(evaluacionAlistEntrenamientoCombima1DTO);
        }

        public EvaluacionAlistEntrenamientoCombima1DTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistEntrenamientoCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO)
        {
            return evaluacionAlistEntrenamientoCombima1DAO.ActualizaFormato(evaluacionAlistEntrenamientoCombima1DTO);
        }

        public bool EliminarFormato(EvaluacionAlistEntrenamientoCombima1DTO evaluacionAlistEntrenamientoCombima1DTO)
        {
            return evaluacionAlistEntrenamientoCombima1DAO.EliminarFormato(evaluacionAlistEntrenamientoCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistEntrenamientoCombima1DTO> evaluacionAlistEntrenamientoCombima1DTO)
        {
            return evaluacionAlistEntrenamientoCombima1DAO.InsercionMasiva(evaluacionAlistEntrenamientoCombima1DTO);
        }

    }
}
