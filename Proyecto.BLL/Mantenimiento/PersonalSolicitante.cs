using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PersonalSolicitante
    {
        readonly PersonalSolicitanteDAO PersonalSolicitanteDAO = new();

        public List<PersonalSolicitanteDTO> ObtenerPersonalSolicitantes()
        {
            return PersonalSolicitanteDAO.ObtenerPersonalSolicitantes();
        }

        public string AgregarPersonalSolicitante(PersonalSolicitanteDTO personalSolicitanteDto)
        {
            return PersonalSolicitanteDAO.AgregarPersonalSolicitante(personalSolicitanteDto);
        }

        public PersonalSolicitanteDTO BuscarPersonalSolicitanteID(int Codigo)
        {
            return PersonalSolicitanteDAO.BuscarPersonalSolicitanteID(Codigo);
        }

        public string ActualizarPersonalSolicitante(PersonalSolicitanteDTO personalSolicitanteDto)
        {
            return PersonalSolicitanteDAO.ActualizarPersonalSolicitante(personalSolicitanteDto);
        }

        public string EliminarPersonalSolicitante(PersonalSolicitanteDTO personalSolicitanteDto)
        {
            return PersonalSolicitanteDAO.EliminarPersonalSolicitante(personalSolicitanteDto);
        }

    }
}
