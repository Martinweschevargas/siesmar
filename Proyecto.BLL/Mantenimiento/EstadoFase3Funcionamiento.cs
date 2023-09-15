using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EstadoFase3Funcionamiento
    {
        readonly EstadoFase3FuncionamientoDAO estadoFase3FuncionamientoDAO = new();

        public List<EstadoFase3FuncionamientoDTO> ObtenerEstadoFase3Funcionamientos()
        {
            return estadoFase3FuncionamientoDAO.ObtenerEstadoFase3Funcionamientos();
        }

        public string AgregarEstadoFase3Funcionamiento(EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDto)
        {
            return estadoFase3FuncionamientoDAO.AgregarEstadoFase3Funcionamiento(estadoFase3FuncionamientoDto);
        }

        public EstadoFase3FuncionamientoDTO BuscarEstadoFase3FuncionamientoID(int Codigo)
        {
            return estadoFase3FuncionamientoDAO.BuscarEstadoFase3FuncionamientoID(Codigo);
        }

        public string ActualizarEstadoFase3Funcionamiento(EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDto)
        {
            return estadoFase3FuncionamientoDAO.ActualizarEstadoFase3Funcionamiento(estadoFase3FuncionamientoDto);
        }

        public string EliminarEstadoFase3Funcionamiento(EstadoFase3FuncionamientoDTO estadoFase3FuncionamientoDto)
        {
            return estadoFase3FuncionamientoDAO.EliminarEstadoFase3Funcionamiento(estadoFase3FuncionamientoDto);
        }

    }
}
