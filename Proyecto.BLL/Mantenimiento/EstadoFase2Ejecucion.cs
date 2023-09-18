using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EstadoFase2Ejecucion
    {
        readonly EstadoFase2EjecucionDAO estadoFase2EjecucionDAO = new();

        public List<EstadoFase2EjecucionDTO> ObtenerEstadoFase2Ejecucions()
        {
            return estadoFase2EjecucionDAO.ObtenerEstadoFase2Ejecucions();
        }

        public string AgregarEstadoFase2Ejecucion(EstadoFase2EjecucionDTO estadoFase2EjecucionDto)
        {
            return estadoFase2EjecucionDAO.AgregarEstadoFase2Ejecucion(estadoFase2EjecucionDto);
        }

        public EstadoFase2EjecucionDTO BuscarEstadoFase2EjecucionID(int Codigo)
        {
            return estadoFase2EjecucionDAO.BuscarEstadoFase2EjecucionID(Codigo);
        }

        public string ActualizarEstadoFase2Ejecucion(EstadoFase2EjecucionDTO estadoFase2EjecucionDTO)
        {
            return estadoFase2EjecucionDAO.ActualizarEstadoFase2Ejecucion(estadoFase2EjecucionDTO);
        }

        public bool EliminarEstadoFase2Ejecucion(EstadoFase2EjecucionDTO estadoFase2EjecucionDTO)
        {
            return estadoFase2EjecucionDAO.EliminarEstadoFase2Ejecucion(estadoFase2EjecucionDTO);
        }

    }
}
