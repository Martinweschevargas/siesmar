using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ActividadIlicitaInterventor
    {
        readonly ActividadIlicitaInterventorDAO actividadIlicitaInterventorDAO = new();

        public List<ActividadIlicitaInterventorDTO> ObtenerActividadIlicitaInterventors()
        {
            return actividadIlicitaInterventorDAO.ObtenerActividadIlicitaInterventors();
        }

        public string AgregarActividadIlicitaInterventor(ActividadIlicitaInterventorDTO actividadIlicitaInterventorDto)
        {
            return actividadIlicitaInterventorDAO.AgregarActividadIlicitaInterventor(actividadIlicitaInterventorDto);
        }

        public ActividadIlicitaInterventorDTO BuscarActividadIlicitaInterventorID(int Codigo)
        {
            return actividadIlicitaInterventorDAO.BuscarActividadIlicitaInterventorID(Codigo);
        }

        public string ActualizarActividadIlicitaInterventor(ActividadIlicitaInterventorDTO actividadIlicitaInterventorDto)
        {
            return actividadIlicitaInterventorDAO.ActualizarActividadIlicitaInterventor(actividadIlicitaInterventorDto);
        }

        public string EliminarActividadIlicitaInterventor(ActividadIlicitaInterventorDTO actividadIlicitaInterventorDto)
        {
            return actividadIlicitaInterventorDAO.EliminarActividadIlicitaInterventor(actividadIlicitaInterventorDto);
        }

    }
}
