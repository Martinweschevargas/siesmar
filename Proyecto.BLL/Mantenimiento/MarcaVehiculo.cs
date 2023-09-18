using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class MarcaVehiculo
    {
        readonly MarcaVehiculoDAO marcaVehiculoDAO = new();

        public List<MarcaVehiculoDTO> ObtenerMarcaVehiculos()
        {
            return marcaVehiculoDAO.ObtenerMarcaVehiculos();
        }

        public string AgregarMarcaVehiculo(MarcaVehiculoDTO marcaVehiculoDto)
        {
            return marcaVehiculoDAO.AgregarMarcaVehiculo(marcaVehiculoDto);
        }

        public MarcaVehiculoDTO BuscarMarcaVehiculoID(int Codigo)
        {
            return marcaVehiculoDAO.BuscarMarcaVehiculoID(Codigo);
        }

        public string ActualizarMarcaVehiculo(MarcaVehiculoDTO marcaVehiculoDTO)
        {
            return marcaVehiculoDAO.ActualizarMarcaVehiculo(marcaVehiculoDTO);
        }

        public string EliminarMarcaVehiculo(MarcaVehiculoDTO marcaVehiculoDTO)
        {
            return marcaVehiculoDAO.EliminarMarcaVehiculo(marcaVehiculoDTO);
        }

    }
}
