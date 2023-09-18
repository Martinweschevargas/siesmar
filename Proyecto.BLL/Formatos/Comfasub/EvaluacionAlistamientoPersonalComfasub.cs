
using Marina.Siesmar.AccesoDatos.Formatos.Comfasub;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comfasub;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfasub
{
    public class EvaluacionAlistamientoPersonalComfasub
    {
        EvaluacionAlistamientoPersonalComfasubDAO evaluacionAlistamientoPersonalComfasubDAO = new();

        public List<EvaluacionAlistamientoPersonalComfasubDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO, string? fecha)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.AgregarRegistro(evaluacionAlistamientoPersonalComfasubDTO, fecha);
        }

        public EvaluacionAlistamientoPersonalComfasubDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.ActualizaFormato(evaluacionAlistamientoPersonalComfasubDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.EliminarFormato(evaluacionAlistamientoPersonalComfasubDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComfasubDTO evaluacionAlistamientoPersonalComfasubDTO)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.EliminarCarga(evaluacionAlistamientoPersonalComfasubDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoPersonalComfasubDAO.InsertarDatos(datos, fecha);
        }

    }
}
