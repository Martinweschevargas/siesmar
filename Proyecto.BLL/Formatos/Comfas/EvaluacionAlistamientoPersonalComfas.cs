using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class EvaluacionAlistamientoPersonalComfas
    {
        EvaluacionAlistamientoPersonalComfasDAO evaluacionAlistPersonalComfasDAO = new();

        public List<EvaluacionAlistamientoPersonalComfasDTO> ObtenerLista()
        {
            return evaluacionAlistPersonalComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfasDTO evaluacionAlistPersonalComfasDTO)
        {
            return evaluacionAlistPersonalComfasDAO.AgregarRegistro(evaluacionAlistPersonalComfasDTO);
        }

        public EvaluacionAlistamientoPersonalComfasDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistPersonalComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComfasDTO evaluacionAlistPersonalComfasDTO)
        {
            return evaluacionAlistPersonalComfasDAO.ActualizaFormato(evaluacionAlistPersonalComfasDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfasDTO evaluacionAlistPersonalComfasDTO)
        {
            return evaluacionAlistPersonalComfasDAO.EliminarFormato(evaluacionAlistPersonalComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoPersonalComfasDTO> evaluacionAlistPersonalComfasDTO)
        {
            return evaluacionAlistPersonalComfasDAO.InsercionMasiva(evaluacionAlistPersonalComfasDTO);
        }

    }
}
