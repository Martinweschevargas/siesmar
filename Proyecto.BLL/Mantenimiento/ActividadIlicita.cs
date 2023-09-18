using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ActividadIlicita
    {
        readonly ActividadIlicitaDAO actividadIlicitaDAO = new();

        public List<ActividadIlicitaDTO> ObtenerActividadIlicitas()
        {
            return actividadIlicitaDAO.ObtenerActividadIlicitas();
        }

        public string AgregarActividadIlicita(ActividadIlicitaDTO actividadIlicitaDto)
        {
            return actividadIlicitaDAO.AgregarActividadIlicita(actividadIlicitaDto);
        }

        public ActividadIlicitaDTO BuscarActividadIlicitaID(int Codigo)
        {
            return actividadIlicitaDAO.BuscarActividadIlicitaID(Codigo);
        }

        public string ActualizarActividadIlicita(ActividadIlicitaDTO actividadIlicitaDto)
        {
            return actividadIlicitaDAO.ActualizarActividadIlicita(actividadIlicitaDto);
        }

        public string EliminarActividadIlicita(ActividadIlicitaDTO actividadIlicitaDto)
        {
            return actividadIlicitaDAO.EliminarActividadIlicita(actividadIlicitaDto);
        }

    }
}
