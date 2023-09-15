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

        public string AgregarAlistamientoMunicion(AlistamientoMunicionDTO alistamientoMunicionDto)
        {
            return alistamientoMunicionDAO.AgregarAlistamientoMunicion(alistamientoMunicionDto);
        }

        public AlistamientoMunicionDTO BuscarAlistamientoMunicionID(int Codigo)
        {
            return alistamientoMunicionDAO.BuscarAlistamientoMunicionID(Codigo);
        }

        public string ActualizarAlistamientoMunicion(AlistamientoMunicionDTO alistamientoMunicionDto)
        {
            return alistamientoMunicionDAO.ActualizarAlistamientoMunicion(alistamientoMunicionDto);
        }

        public string EliminarAlistamientoMunicion(AlistamientoMunicionDTO alistamientoMunicionDto)
        {
            return alistamientoMunicionDAO.EliminarAlistamientoMunicion(alistamientoMunicionDto);
        }

    }
}
