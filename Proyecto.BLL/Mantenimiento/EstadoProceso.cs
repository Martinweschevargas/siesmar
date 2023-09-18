using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EstadoProceso
    {
        readonly EstadoProcesoDAO estadoProcesoDAO = new();

        public List<EstadoProcesoDTO> btenerEstadoProcesos()
        {
            return estadoProcesoDAO.ObtenerEstadoProcesos();
        }

        public string AgregarEstadoProceso(EstadoProcesoDTO estadoProcesoDto)
        {
            return estadoProcesoDAO.AgregarEstadoProceso(estadoProcesoDto);
        }

        public EstadoProcesoDTO BuscarEstadoProcesoID(int Codigo)
        {
            return estadoProcesoDAO.BuscarEstadoProcesoID(Codigo);
        }

        public string ActualizarEstadoProceso(EstadoProcesoDTO estadoProcesoDto)
        {
            return estadoProcesoDAO.ActualizarEstadoProceso(estadoProcesoDto);
        }

        public string EliminarEstadoProceso(EstadoProcesoDTO estadoProcesoDto)
        {
            return estadoProcesoDAO.EliminarEstadoProceso(estadoProcesoDto);
        }

    }
}