using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TrabajoSeñalizacionNautica
    {
        readonly TrabajoSeñalizacionNauticaDAO trabajoSeñalizacionNauticaDAO = new();

        public List<TrabajoSeñalizacionNauticaDTO> ObtenerTrabajoSeñalizacionNauticas()
        {
            return trabajoSeñalizacionNauticaDAO.ObtenerTrabajoSeñalizacionNauticas();
        }

        public string AgregarTrabajoSeñalizacionNautica(TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDto)
        {
            return trabajoSeñalizacionNauticaDAO.AgregarTrabajoSeñalizacionNautica(trabajoSeñalizacionNauticaDto);
        }

        public TrabajoSeñalizacionNauticaDTO BuscarTrabajoSeñalizacionNauticaID(int Codigo)
        {
            return trabajoSeñalizacionNauticaDAO.BuscarTrabajoSeñalizacionNauticaID(Codigo);
        }

        public string ActualizarTrabajoSeñalizacionNautica(TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDto)
        {
            return trabajoSeñalizacionNauticaDAO.ActualizarTrabajoSeñalizacionNautica(trabajoSeñalizacionNauticaDto);
        }

        public string EliminarTrabajoSeñalizacionNautica(TrabajoSeñalizacionNauticaDTO trabajoSeñalizacionNauticaDto)
        {
            return trabajoSeñalizacionNauticaDAO.EliminarTrabajoSeñalizacionNautica(trabajoSeñalizacionNauticaDto);
        }

    }
}
