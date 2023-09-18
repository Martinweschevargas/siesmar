
using Marina.Siesmar.AccesoDatos.Formatos.Comfuinmar;
using Marina.Siesmar.Entidades.Formatos.Comfuinmar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuinmar
{
    public class EvaluacionAlistamientoPersonalComfuinmar
    {
        EvaluacionAlistamientoPersonalComfuinmarDAO evaluacionAlistamientoPersonalComfuinmarDAO = new();

        public List<EvaluacionAlistamientoPersonalComfuinmarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO, string? fecha)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.AgregarRegistro(evaluacionAlistamientoPersonalComfuinmarDTO, fecha);
        }

        public EvaluacionAlistamientoPersonalComfuinmarDTO EditarFormato(int Codigo)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.ActualizaFormato(evaluacionAlistamientoPersonalComfuinmarDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.EliminarFormato(evaluacionAlistamientoPersonalComfuinmarDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComfuinmarDTO evaluacionAlistamientoPersonalComfuinmarDTO)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.EliminarCarga(evaluacionAlistamientoPersonalComfuinmarDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoPersonalComfuinmarDAO.InsertarDatos(datos, fecha);
        }
    }
}
