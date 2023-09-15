
using Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar
{
    public class EvaluacionAlistamientoEntrenamientoComfuinmar
    {
        EvaluacionAlistamientoEntrenamientoComfuinmarDAO evaluacionAlistamientoEntrenamientoComfuinmarDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO, string? fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfuinmarDTO, fecha);
        }

        public EvaluacionAlistamientoEntrenamientoComfuinmarDTO EditarFormato(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComfuinmarDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComfuinmarDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComfuinmarDTO evaluacionAlistamientoEntrenamientoComfuinmarDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.EliminarCarga(evaluacionAlistamientoEntrenamientoComfuinmarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfuinmarDAO.InsertarDatos(datos, fecha);
        }
    }
}
