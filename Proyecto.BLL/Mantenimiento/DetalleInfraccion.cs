using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DetalleInfraccion
    {
        readonly DetalleInfraccionDAO detalleInfraccionDAO = new();

        public List<DetalleInfraccionDTO> ObtenerDetalleInfraccions()
        {
            return detalleInfraccionDAO.ObtenerDetalleInfraccions();
        }

        public string AgregarDetalleInfraccion(DetalleInfraccionDTO detalleInfraccionDto)
        {
            return detalleInfraccionDAO.AgregarDetalleInfraccion(detalleInfraccionDto);
        }

        public DetalleInfraccionDTO BuscarDetalleInfraccionID(int Codigo)
        {
            return detalleInfraccionDAO.BuscarDetalleInfraccionID(Codigo);
        }

        public string ActualizarDetalleInfraccion(DetalleInfraccionDTO detalleInfraccionDTO)
        {
            return detalleInfraccionDAO.ActualizarDetalleInfraccion(detalleInfraccionDTO);
        }

        public string EliminarDetalleInfraccion(DetalleInfraccionDTO detalleInfraccionDTO)
        {
            return detalleInfraccionDAO.EliminarDetalleInfraccion(detalleInfraccionDTO);
        }

    }
}
