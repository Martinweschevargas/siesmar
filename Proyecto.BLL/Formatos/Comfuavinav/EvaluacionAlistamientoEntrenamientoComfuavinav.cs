using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoEntrenamientoComfuavinav
    {
        EvaluacionAlistamientoEntrenamientoComfuavinavDAO evaluacionAlistamientoEntrenamientoComfuavinavDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> ObtenerLista()
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

        public EvaluacionAlistamientoEntrenamientoComfuavinavDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.InsercionMasiva(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

    }
}
