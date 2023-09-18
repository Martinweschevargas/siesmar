using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PersonalComision
    {
        readonly PersonalComisionDAO personalComisionDAO = new();

        public List<PersonalComisionDTO> ObtenerPersonalComisions()
        {
            return personalComisionDAO.ObtenerPersonalComisions();
        }

        public string AgregarPersonalComision(PersonalComisionDTO personalComisionDto)
        {
            return personalComisionDAO.AgregarPersonalComision(personalComisionDto);
        }

        public PersonalComisionDTO BuscarPersonalComisionID(int Codigo)
        {
            return personalComisionDAO.BuscarPersonalComisionID(Codigo);
        }

        public string ActualizarPersonalComision(PersonalComisionDTO personalComisionDto)
        {
            return personalComisionDAO.ActualizarPersonalComision(personalComisionDto);
        }

        public string EliminarPersonalComision(PersonalComisionDTO personalComisionDto)
        {
            return personalComisionDAO.EliminarPersonalComision(personalComisionDto);
        }

    }
}
