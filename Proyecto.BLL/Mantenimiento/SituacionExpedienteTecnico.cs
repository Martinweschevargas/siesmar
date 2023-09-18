using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SituacionExpedienteTecnico
    {
        readonly SituacionExpedienteTecnicoDAO situacionExpedienteTecnicoDAO = new();

        public List<SituacionExpedienteTecnicoDTO> ObtenerSituacionExpedienteTecnicos()
        {
            return situacionExpedienteTecnicoDAO.ObtenerSituacionExpedienteTecnicos();
        }

        public string AgregarSituacionExpedienteTecnico(SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDto)
        {
            return situacionExpedienteTecnicoDAO.AgregarSituacionExpedienteTecnico(situacionExpedienteTecnicoDto);
        }

        public SituacionExpedienteTecnicoDTO BuscarSituacionExpedienteTecnicoID(int Codigo)
        {
            return situacionExpedienteTecnicoDAO.BuscarSituacionExpedienteTecnicoID(Codigo);
        }

        public string ActualizarSituacionExpedienteTecnico(SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO)
        {
            return situacionExpedienteTecnicoDAO.ActualizarSituacionExpedienteTecnico(situacionExpedienteTecnicoDTO);
        }

        public bool EliminarSituacionExpedienteTecnico(SituacionExpedienteTecnicoDTO situacionExpedienteTecnicoDTO)
        {
            return situacionExpedienteTecnicoDAO.EliminarSituacionExpedienteTecnico(situacionExpedienteTecnicoDTO);
        }

    }
}
