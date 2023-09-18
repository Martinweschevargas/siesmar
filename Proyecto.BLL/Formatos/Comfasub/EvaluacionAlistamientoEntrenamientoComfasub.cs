
using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class EvaluacionAlistamientoEntrenamientoComfasub
    {
        EvaluacionAlistamientoEntrenamientoComfasubDAO evaluacionAlistamientoEntrenamientoComfasubDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO, string? fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfasubDTO, fecha);
        }

        public EvaluacionAlistamientoEntrenamientoComfasubDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComfasubDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComfasubDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComfasubDTO evaluacionAlistamientoEntrenamientoComfasubDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.EliminarCarga(evaluacionAlistamientoEntrenamientoComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
