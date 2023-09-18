using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class EvaluacionAlistPersonalCombima1
    {
        EvaluacionAlistPersonalCombima1DAO evaluacionAlistPersonalCombima1DAO = new();

        public List<EvaluacionAlistPersonalCombima1DTO> ObtenerLista()
        {
            return evaluacionAlistPersonalCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO)
        {
            return evaluacionAlistPersonalCombima1DAO.AgregarRegistro(evaluacionAlistPersonalCombima1DTO);
        }

        public EvaluacionAlistPersonalCombima1DTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistPersonalCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO)
        {
            return evaluacionAlistPersonalCombima1DAO.ActualizaFormato(evaluacionAlistPersonalCombima1DTO);
        }

        public bool EliminarFormato(EvaluacionAlistPersonalCombima1DTO evaluacionAlistPersonalCombima1DTO)
        {
            return evaluacionAlistPersonalCombima1DAO.EliminarFormato(evaluacionAlistPersonalCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistPersonalCombima1DTO> evaluacionAlistPersonalCombima1DTO)
        {
            return evaluacionAlistPersonalCombima1DAO.InsercionMasiva(evaluacionAlistPersonalCombima1DTO);
        }

    }
}
