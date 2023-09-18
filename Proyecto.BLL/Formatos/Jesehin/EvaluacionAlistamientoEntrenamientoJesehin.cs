
using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class EvaluacionAlistamientoEntrenamientoJesehin
    {
        EvaluacionAlistamientoEntrenamientoJesehinDAO evaluacionAlistamientoEntrenamientoJesehinDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoJesehinDTO> ObtenerLista()
        {
            return evaluacionAlistamientoEntrenamientoJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            return evaluacionAlistamientoEntrenamientoJesehinDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoJesehinDTO);
        }

        public EvaluacionAlistamientoEntrenamientoJesehinDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            return evaluacionAlistamientoEntrenamientoJesehinDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoJesehinDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoJesehinDTO evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            return evaluacionAlistamientoEntrenamientoJesehinDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoJesehinDTO> evaluacionAlistamientoEntrenamientoJesehinDTO)
        {
            return evaluacionAlistamientoEntrenamientoJesehinDAO.InsercionMasiva(evaluacionAlistamientoEntrenamientoJesehinDTO);
        }

    }
}
