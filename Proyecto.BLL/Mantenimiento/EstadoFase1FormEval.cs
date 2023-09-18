using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EstadoFase1FormEval
    {
        readonly EstadoFase1FormEvalDAO estadoFase1FormEvalDAO = new();

        public List<EstadoFase1FormEvalDTO> ObtenerEstadoFase1FormEvals()
        {
            return estadoFase1FormEvalDAO.ObtenerEstadoFase1FormEvals();
        }

        public string AgregarEstadoFase1FormEval(EstadoFase1FormEvalDTO estadoFase1FormEvalDto)
        {
            return estadoFase1FormEvalDAO.AgregarEstadoFase1FormEval(estadoFase1FormEvalDto);
        }

        public EstadoFase1FormEvalDTO BuscarEstadoFase1FormEvalID(int Codigo)
        {
            return estadoFase1FormEvalDAO.BuscarEstadoFase1FormEvalID(Codigo);
        }

        public string ActualizarEstadoFase1FormEval(EstadoFase1FormEvalDTO estadoFase1FormEvalDTO)
        {
            return estadoFase1FormEvalDAO.ActualizarEstadoFase1FormEval(estadoFase1FormEvalDTO);
        }

        public bool EliminarEstadoFase1FormEval(EstadoFase1FormEvalDTO estadoFase1FormEvalDTO)
        {
            return estadoFase1FormEvalDAO.EliminarEstadoFase1FormEval(estadoFase1FormEvalDTO);
        }

    }
}
