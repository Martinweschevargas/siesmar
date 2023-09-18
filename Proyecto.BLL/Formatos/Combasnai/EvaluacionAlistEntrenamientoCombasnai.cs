using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class EvaluacionAlistEntrenamientoCombasnai
    {
        EvaluacionAlistEntrenamientoCombasnaiDAO evaluacionAlistEntrenamientoCombasnaiDAO = new();

        public List<EvaluacionAlistEntrenamientoCombasnaiDTO> ObtenerLista()
        {
            return evaluacionAlistEntrenamientoCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistEntrenamientoCombasnaiDTO)
        {
            return evaluacionAlistEntrenamientoCombasnaiDAO.AgregarRegistro(evaluacionAlistEntrenamientoCombasnaiDTO);
        }

        public EvaluacionAlistEntrenamientoCombasnaiDTO BuscarFormato(int Codigo)
        {
            return evaluacionAlistEntrenamientoCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistEntrenamientoCombasnaiDTO)
        {
            return evaluacionAlistEntrenamientoCombasnaiDAO.ActualizaFormato(evaluacionAlistEntrenamientoCombasnaiDTO);
        }

        public bool EliminarFormato(EvaluacionAlistEntrenamientoCombasnaiDTO evaluacionAlistEntrenamientoCombasnaiDTO)
        {
            return evaluacionAlistEntrenamientoCombasnaiDAO.EliminarFormato(evaluacionAlistEntrenamientoCombasnaiDTO);
        }

        public bool InsercionMasiva(IEnumerable<EvaluacionAlistEntrenamientoCombasnaiDTO> evaluacionAlistEntrenamientoCombasnaiDTO)
        {
            return evaluacionAlistEntrenamientoCombasnaiDAO.InsercionMasiva(evaluacionAlistEntrenamientoCombasnaiDTO);
        }

    }
}
