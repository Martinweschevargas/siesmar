using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class IncidenteOcurrido
    {
        readonly IncidenteOcurridoDAO incidenteOcurridoDAO = new();

        public List<IncidenteOcurridoDTO> ObtenerIncidenteOcurridos()
        {
            return incidenteOcurridoDAO.ObtenerIncidenteOcurridos();
        }

        public string AgregarIncidenteOcurrido(IncidenteOcurridoDTO incidenteOcurridoDto)
        {
            return incidenteOcurridoDAO.AgregarIncidenteOcurrido(incidenteOcurridoDto);
        }

        public IncidenteOcurridoDTO BuscarIncidenteOcurridoID(int Codigo)
        {
            return incidenteOcurridoDAO.BuscarIncidenteOcurridoID(Codigo);
        }

        public string ActualizarIncidenteOcurrido(IncidenteOcurridoDTO incidenteOcurridoDTO)
        {
            return incidenteOcurridoDAO.ActualizarIncidenteOcurrido(incidenteOcurridoDTO);
        }

        public string EliminarIncidenteOcurrido(IncidenteOcurridoDTO incidenteOcurridoDTO)
        {
            return incidenteOcurridoDAO.EliminarIncidenteOcurrido(incidenteOcurridoDTO);
        }

    }
}
