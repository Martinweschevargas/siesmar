using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PersonalCivilLaboral
    {
        readonly PersonalCivilLaboralDAO personalCivilLaboralDAO = new();

        public List<PersonalCivilLaboralDTO> ObtenerPersonalCivilLaborals()
        {
            return personalCivilLaboralDAO.ObtenerPersonalCivilLaborals();
        }

        public string AgregarPersonalCivilLaboral(PersonalCivilLaboralDTO personalCivilLaboralDto)
        {
            return personalCivilLaboralDAO.AgregarPersonalCivilLaboral(personalCivilLaboralDto);
        }

        public PersonalCivilLaboralDTO BuscarPersonalCivilLaboralID(int Codigo)
        {
            return personalCivilLaboralDAO.BuscarPersonalCivilLaboralID(Codigo);
        }

        public string ActualizarPersonalCivilLaboral(PersonalCivilLaboralDTO personalCivilLaboralDTO)
        {
            return personalCivilLaboralDAO.ActualizarPersonalCivilLaboral(personalCivilLaboralDTO);
        }

        public bool EliminarPersonalCivilLaboral(int Codigo)
        {
            return personalCivilLaboralDAO.EliminarPersonalCivilLaboral(Codigo);
        }

    }
}
