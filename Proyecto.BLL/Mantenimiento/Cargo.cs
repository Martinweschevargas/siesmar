using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Cargo
    {
        readonly CargoDAO cargoDAO = new();

        public List<CargoDTO> ObtenerCargos()
        {
            return cargoDAO.ObtenerCargos();
        }

        public string AgregarCargo(CargoDTO cargoDto)
        {
            return cargoDAO.AgregarCargo(cargoDto);
        }

        public CargoDTO BuscarCargoID(int Codigo)
        {
            return cargoDAO.BuscarCargoID(Codigo);
        }

        public string ActualizarCargo(CargoDTO cargoDto)
        {
            return cargoDAO.ActualizarCargo(cargoDto);
        }

        public string EliminarCargo(CargoDTO cargoDto)
        {
            return cargoDAO.EliminarCargo(cargoDto);
        }

    }
}
