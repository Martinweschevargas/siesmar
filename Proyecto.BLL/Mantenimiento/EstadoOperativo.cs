using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EstadoOperativo
    {
        readonly EstadoOperativoDAO estadoOperativoDAO = new();

        public List<EstadoOperativoDTO> ObtenerEstadoOperativos()
        {
            return estadoOperativoDAO.ObtenerEstadoOperativos();
        }

        public string AgregarEstadoOperativo(EstadoOperativoDTO estadoOperativoDto)
        {
            return estadoOperativoDAO.AgregarEstadoOperativo(estadoOperativoDto);
        }

        public EstadoOperativoDTO BuscarEstadoOperativoID(int Codigo)
        {
            return estadoOperativoDAO.BuscarEstadoOperativoID(Codigo);
        }

        public string ActualizarEstadoOperativo(EstadoOperativoDTO estadoOperativoDto)
        {
            return estadoOperativoDAO.ActualizarEstadoOperativo(estadoOperativoDto);
        }

        public string EliminarEstadoOperativo(EstadoOperativoDTO estadoOperativoDto)
        {
            return estadoOperativoDAO.EliminarEstadoOperativo(estadoOperativoDto);
        }

    }
}
