using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Direcomar;
using Marina.Siesmar.Entidades.Formatos.Direcomar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Direcomar
{
    public class EvaluacionPresupuestal
    {
        EvaluacionPresupuestalDAO evaluacionPresupuestalDAO = new();

        public List<EvaluacionPresupuestalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return evaluacionPresupuestalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }
        public List<EvaluacionPresupuestalDTO> DirecomarVisualizacionEvaluacionPresupuestal(int? CargaId = null, string? fechaInicio = null, string? fechaFin = null)
        {
            return evaluacionPresupuestalDAO.DirecomarVisualizacionEvaluacionPresupuestal(CargaId, fechaInicio, fechaFin);
        }

        public string AgregarRegistro(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO, string? fecha)
        {
            return evaluacionPresupuestalDAO.AgregarRegistro(evaluacionPresupuestalDTO, fecha);
        }

        public EvaluacionPresupuestalDTO EditarFormato(int Codigo)
        {
            return evaluacionPresupuestalDAO.BuscarFormato(Codigo);
        }

        public bool EliminarCarga(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO)
        {
            return evaluacionPresupuestalDAO.EliminarCarga(evaluacionPresupuestalDTO);
        }

        public string ActualizarFormato(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO)
        {
            return evaluacionPresupuestalDAO.ActualizaFormato(evaluacionPresupuestalDTO);
        }

        public bool EliminarFormato(EvaluacionPresupuestalDTO evaluacionPresupuestalDTO)
        {
            return evaluacionPresupuestalDAO.EliminarFormato(evaluacionPresupuestalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return evaluacionPresupuestalDAO.InsertarDatos(datos, fecha);
        }

    }
}
