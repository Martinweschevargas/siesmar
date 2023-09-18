using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClaseVehiculo
    {
        readonly ClaseVehiculoDAO claseVehiculoDAO = new();

        public List<ClaseVehiculoDTO> ObtenerClaseVehiculos()
        {
            return claseVehiculoDAO.ObtenerClaseVehiculos();
        }

        public string AgregarClaseVehiculo(ClaseVehiculoDTO claseVehiculoDto)
        {
            return claseVehiculoDAO.AgregarClaseVehiculo(claseVehiculoDto);
        }

        public ClaseVehiculoDTO BuscarClaseVehiculoID(int Codigo)
        {
            return claseVehiculoDAO.BuscarClaseVehiculoID(Codigo);
        }

        public string ActualizarClaseVehiculo(ClaseVehiculoDTO claseVehiculoDto)
        {
            return claseVehiculoDAO.ActualizarClaseVehiculo(claseVehiculoDto);
        }

        public string EliminarClaseVehiculo(ClaseVehiculoDTO claseVehiculoDto)
        {
            return claseVehiculoDAO.EliminarClaseVehiculo(claseVehiculoDto);
        }

    }
}
