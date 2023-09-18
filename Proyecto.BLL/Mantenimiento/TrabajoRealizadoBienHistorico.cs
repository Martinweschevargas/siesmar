using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TrabajoRealizadoBienHistorico
    {
        readonly TrabajoRealizadoBienHistoricoDAO trabajoRealizadoBienHistoricoDAO = new();

        public List<TrabajoRealizadoBienHistoricoDTO> ObtenerTrabajoRealizadoBienHistoricos()
        {
            return trabajoRealizadoBienHistoricoDAO.ObtenerTrabajoRealizadoBienHistoricos();
        }

        public string AgregarTrabajoRealizadoBienHistorico(TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDto)
        {
            return trabajoRealizadoBienHistoricoDAO.AgregarTrabajoRealizadoBienHistorico(trabajoRealizadoBienHistoricoDto);
        }

        public TrabajoRealizadoBienHistoricoDTO BuscarTrabajoRealizadoBienHistoricoID(int Codigo)
        {
            return trabajoRealizadoBienHistoricoDAO.BuscarTrabajoRealizadoBienHistoricoID(Codigo);
        }

        public string ActualizarTrabajoRealizadoBienHistorico(TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO)
        {
            return trabajoRealizadoBienHistoricoDAO.ActualizarTrabajoRealizadoBienHistorico(trabajoRealizadoBienHistoricoDTO);
        }

        public bool EliminarTrabajoRealizadoBienHistorico(TrabajoRealizadoBienHistoricoDTO trabajoRealizadoBienHistoricoDTO)
        {
            return trabajoRealizadoBienHistoricoDAO.EliminarTrabajoRealizadoBienHistorico(trabajoRealizadoBienHistoricoDTO);
        }

    }
}