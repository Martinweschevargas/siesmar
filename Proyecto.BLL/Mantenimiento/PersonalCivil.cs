using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PersonalCivil
    {
        readonly PersonalCivilMDAO PersonalCivilMDAO = new();

        public List<PersonalCivilMDTO> ObtenerPersonalCivils()
        {
            return PersonalCivilMDAO.ObtenerPersonalCivils();
        }

        public string AgregarPersonalCivil(PersonalCivilMDTO PersonalCivilMDTO)
        {
            return PersonalCivilMDAO.AgregarPersonalCivil(PersonalCivilMDTO);
        }

        public PersonalCivilMDTO BuscarPersonalCivilID(int Codigo)
        {
            return PersonalCivilMDAO.BuscarPersonalCivilID(Codigo);
        }

        public string ActualizarPersonalCivil(PersonalCivilMDTO PersonalCivilMDTO)
        {
            return PersonalCivilMDAO.ActualizarPersonalCivil(PersonalCivilMDTO);
        }

        public string EliminarPersonalCivil(PersonalCivilMDTO PersonalCivilMDTO)
        {
            return PersonalCivilMDAO.EliminarPersonalCivil(PersonalCivilMDTO);
        }

    }
}
