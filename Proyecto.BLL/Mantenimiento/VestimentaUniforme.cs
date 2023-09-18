using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class VestimentaUniforme
    {
        readonly VestimentaUniformeDAO vestimentaUniformeDAO = new();

        public List<VestimentaUniformeDTO> ObtenerVestimentaUniformes()
        {
            return vestimentaUniformeDAO.ObtenerVestimentaUniformes();
        }

        public string AgregarVestimentaUniforme(VestimentaUniformeDTO vestimentaUniformeDto)
        {
            return vestimentaUniformeDAO.AgregarVestimentaUniforme(vestimentaUniformeDto);
        }

        public VestimentaUniformeDTO BuscarVestimentaUniformeID(int Codigo)
        {
            return vestimentaUniformeDAO.BuscarVestimentaUniformeID(Codigo);
        }

        public string ActualizarVestimentaUniforme(VestimentaUniformeDTO vestimentaUniformeDto)
        {
            return vestimentaUniformeDAO.ActualizarVestimentaUniforme(vestimentaUniformeDto);
        }

        public string EliminarVestimentaUniforme(VestimentaUniformeDTO vestimentaUniformeDto)
        {
            return vestimentaUniformeDAO.EliminarVestimentaUniforme(vestimentaUniformeDto);
        }

    }
}
