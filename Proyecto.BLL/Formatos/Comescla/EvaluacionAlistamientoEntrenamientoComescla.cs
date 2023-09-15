using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class EvaluacionAlistamientoEntrenamientoComescla
    {
        EvaluacionAlistamientoEntrenamientoComesclaDAO evalAlistamientoEntrenamientoComesclaDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComesclaDTO> ObtenerLista()
        {
            return evalAlistamientoEntrenamientoComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComesclaDTO evalAlistamientoEntrenamientoComesclaDTO)
        {
            return evalAlistamientoEntrenamientoComesclaDAO.AgregarRegistro(evalAlistamientoEntrenamientoComesclaDTO);
        }

        public EvaluacionAlistamientoEntrenamientoComesclaDTO BuscarFormato(int Codigo)
        {
            return evalAlistamientoEntrenamientoComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComesclaDTO evalAlistamientoEntrenamientoComesclaDTO)
        {
            return evalAlistamientoEntrenamientoComesclaDAO.ActualizaFormato(evalAlistamientoEntrenamientoComesclaDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComesclaDTO evalAlistamientoEntrenamientoComesclaDTO)
        {
            return evalAlistamientoEntrenamientoComesclaDAO.EliminarFormato(evalAlistamientoEntrenamientoComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistamientoEntrenamientoComesclaDTO> evalAlistamientoEntrenamientoComesclaDTO)
        {
            return evalAlistamientoEntrenamientoComesclaDAO.InsercionMasiva(evalAlistamientoEntrenamientoComesclaDTO);
        }

    }
}
