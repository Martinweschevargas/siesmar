using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoDotacionVueloComfuavinav
    {
        EvaluacionAlistamientoDotacionVueloComfuavinavDAO evaluacionAlistamientoDotacionVueloComfuavinavDAO = new();

        public List<EvaluacionAlistamientoDotacionVueloComfuavinavDTO> ObtenerLista()
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.AgregarRegistro(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

        public EvaluacionAlistamientoDotacionVueloComfuavinavDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.ActualizaFormato(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoDotacionVueloComfuavinavDTO evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.EliminarFormato(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoDotacionVueloComfuavinavDTO> evaluacionAlistamientoDotacionVueloComfuavinavDTO)
        {
            return evaluacionAlistamientoDotacionVueloComfuavinavDAO.InsercionMasiva(evaluacionAlistamientoDotacionVueloComfuavinavDTO);
        }

    }
}
