using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionLaboral
    {
        readonly CondicionLaboralDAO condicionLaboralDAO = new();

        public List<CondicionLaboralDTO> ObtenerCondicionLaborals()
        {
            return condicionLaboralDAO.ObtenerCondicionLaborals();
        }

        public string AgregarCondicionLaboral(CondicionLaboralDTO condicionLaboralDto)
        {
            return condicionLaboralDAO.AgregarCondicionLaboral(condicionLaboralDto);
        }

        public CondicionLaboralDTO BuscarCondicionLaboralID(int Codigo)
        {
            return condicionLaboralDAO.BuscarCondicionLaboralID(Codigo);
        }

        public string ActualizarCondicionLaboral(CondicionLaboralDTO condicionLaboralDto)
        {
            return condicionLaboralDAO.ActualizarCondicionLaboral(condicionLaboralDto);
        }

        public string EliminarCondicionLaboral(CondicionLaboralDTO condicionLaboralDto)
        {
            return condicionLaboralDAO.EliminarCondicionLaboral(condicionLaboralDto);
        }

    }
}
