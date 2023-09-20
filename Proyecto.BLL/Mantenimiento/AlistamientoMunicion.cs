using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AlistamientoMunicion
    {
        readonly AlistamientoMunicionDAO alistamientoMunicionDAO = new();

        public List<AlistamientoMunicionDTO> ObtenerAlistamientoMunicions()
        {
            return alistamientoMunicionDAO.ObtenerAlistamientoMunicions();
        }

        public string AgregarAlistamientoMunicion(AlistamientoMunicionDTO alistamientoMunicionDTO)
        {
            return alistamientoMunicionDAO.AgregarAlistamientoMunicion(alistamientoMunicionDTO);
        }

        public AlistamientoMunicionDTO BuscarAlistamientoMunicionID(int Codigo)
        {
            return alistamientoMunicionDAO.BuscarAlistamientoMunicionID(Codigo);
        }

        public string ActualizarAlistamientoMunicion(AlistamientoMunicionDTO alistamientoMunicionDTO)
        {
            return alistamientoMunicionDAO.ActualizarAlistamientoMunicion(alistamientoMunicionDTO);
        }

        public string EliminarAlistamientoMunicion(AlistamientoMunicionDTO alistamientoMunicionDTO)
        {
            return alistamientoMunicionDAO.EliminarAlistamientoMunicion(alistamientoMunicionDTO);
        }

    }
}
