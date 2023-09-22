using Marina.Siesmar.AccesoDatos.Formatos.Comfuavinav;
using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Comfuavinav;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfuavinav
{
    public class EvaluacionAlistamientoEntrenamientoComfuavinav
    {
        EvaluacionAlistamientoEntrenamientoComfuavinavDAO evaluacionAlistamientoEntrenamientoComfuavinavDAO = new();

        public List<EvaluacionAlistamientoEntrenamientoComfuavinavDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO, string? fecha = null)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.AgregarRegistro(evaluacionAlistamientoEntrenamientoComfuavinavDTO, fecha);
        }

        public EvaluacionAlistamientoEntrenamientoComfuavinavDTO EditarFormado(int Codigo)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.ActualizaFormato(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

        public bool EliminarFormato(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.EliminarFormato(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

        public bool EliminarCarga(EvaluacionAlistamientoEntrenamientoComfuavinavDTO evaluacionAlistamientoEntrenamientoComfuavinavDTO)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.EliminarCarga(evaluacionAlistamientoEntrenamientoComfuavinavDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionAlistamientoEntrenamientoComfuavinavDAO.InsertarDatos(datos, fecha);
        }

    }
}

