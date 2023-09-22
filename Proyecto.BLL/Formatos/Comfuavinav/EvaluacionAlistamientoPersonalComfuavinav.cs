using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoPersonalComfuavinav
    {
        EvaluacionAlistamientoPersonalComfuavinavDAO evaluacionAlistamientoPersonalComfuavinavDAO = new();

        public List<EvaluacionAlistamientoPersonalComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistamientoPersonalComfuavinavDTO, string? fecha)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.AgregarRegistro(evaluacionAlistamientoPersonalComfuavinavDTO, fecha);
        }

        public EvaluacionAlistamientoPersonalComfuavinavDTO EditarFormato(int Codigo)
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

        public bool EliminarCarga(EvaluacionAlistamientoPersonalComfuavinavDTO evaluacionAlistamientoPersonalComfuavinavDTO)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.EliminarCarga(evaluacionAlistamientoPersonalComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoPersonalComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}