using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ColorVehiculo
    {
        readonly ColorVehiculoDAO colorVehiculoDAO = new();

        public List<ColorVehiculoDTO> ObtenerColorVehiculos()
        {
            return colorVehiculoDAO.ObtenerColorVehiculos();
        }

        public string AgregarColorVehiculo(ColorVehiculoDTO colorVehiculoDto)
        {
            return colorVehiculoDAO.AgregarColorVehiculo(colorVehiculoDto);
        }

        public ColorVehiculoDTO BuscarColorVehiculoID(int Codigo)
        {
            return colorVehiculoDAO.BuscarColorVehiculoID(Codigo);
        }

        public string ActualizarColorVehiculo(ColorVehiculoDTO colorVehiculoDto)
        {
            return colorVehiculoDAO.ActualizarColorVehiculo(colorVehiculoDto);
        }

        public string EliminarColorVehiculo(ColorVehiculoDTO colorVehiculoDto)
        {
            return colorVehiculoDAO.EliminarColorVehiculo(colorVehiculoDto);
        }

    }
}
