using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionLaboralCivil
    {
        readonly CondicionLaboralCivilDAO CondicionLaboralCivilDAO = new();

        public List<CondicionLaboralCivilDTO> ObtenerCondicionLaboralCivils()
        {
            return CondicionLaboralCivilDAO.ObtenerCondicionLaboralCivils();
        }

        public string AgregarCondicionLaboralCivil(CondicionLaboralCivilDTO CondicionLaboralCivilDto)
        {
            return CondicionLaboralCivilDAO.AgregarCondicionLaboralCivil(CondicionLaboralCivilDto);
        }

        public CondicionLaboralCivilDTO BuscarCondicionLaboralCivilID(int Codigo)
        {
            return CondicionLaboralCivilDAO.BuscarCondicionLaboralCivilID(Codigo);
        }

        public string ActualizarCondicionLaboralCivil(CondicionLaboralCivilDTO CondicionLaboralCivilDto)
        {
            return CondicionLaboralCivilDAO.ActualizarCondicionLaboralCivil(CondicionLaboralCivilDto);
        }

        public string EliminarCondicionLaboralCivil(CondicionLaboralCivilDTO CondicionLaboralCivilDto)
        {
            return CondicionLaboralCivilDAO.EliminarCondicionLaboralCivil(CondicionLaboralCivilDto);
        }

    }
}
