using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoPersonalComfuavinav
    {
        EvaluacionAlistamientoPersonalComfuavinavDAO evaluacionAlistamientoPersonalComfuavinavDAO = new();

        public List<EvaluacionAlistamientoPersonalComfuavinavDTO> ObtenerLista()
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistamientoPersonalComfuavinavDTO)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.AgregarRegistro(evaluacionAlistamientoPersonalComfuavinavDTO);
        }

        public EvaluacionAlistamientoPersonalComfuavinavDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistamientoPersonalComfuavinavDTO)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.ActualizaFormato(evaluacionAlistamientoPersonalComfuavinavDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistamientoPersonalComfuavinavDTO)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.EliminarFormato(evaluacionAlistamientoPersonalComfuavinavDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComfuavinavDTO> evaluacionAlistamientoPersonalComfuavinavDTO)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.InsercionMasiva(evaluacionAlistamientoPersonalComfuavinavDTO);
        }

    }
}
