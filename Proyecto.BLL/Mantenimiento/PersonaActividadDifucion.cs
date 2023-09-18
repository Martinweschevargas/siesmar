using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PersonaActividadDifucion
    {
        readonly PersonaActividadDifucionDAO personaActividadDifucionDAO = new();

        public List<PersonaActividadDifucionDTO> ObtenerPersonaActividadDifucions()
        {
            return personaActividadDifucionDAO.ObtenerPersonaActividadDifucions();
        }

        public string AgregarPersonaActividadDifucion(PersonaActividadDifucionDTO personaActividadDifucionDto)
        {
            return personaActividadDifucionDAO.AgregarPersonaActividadDifucion(personaActividadDifucionDto);
        }

        public PersonaActividadDifucionDTO BuscarPersonaActividadDifucionID(int Codigo)
        {
            return personaActividadDifucionDAO.BuscarPersonaActividadDifucionID(Codigo);
        }

        public string ActualizarPersonaActividadDifucion(PersonaActividadDifucionDTO personaActividadDifucionDTO)
        {
            return personaActividadDifucionDAO.ActualizarPersonaActividadDifucion(personaActividadDifucionDTO);
        }

        public bool EliminarPersonaActividadDifucion(int Codigo)
        {
            return personaActividadDifucionDAO.EliminarPersonaActividadDifucion(Codigo);
        }

    }
}
