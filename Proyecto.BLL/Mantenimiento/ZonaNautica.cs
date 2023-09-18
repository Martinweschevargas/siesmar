using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ZonaNautica
    {
        readonly ZonaNauticaDAO zonaNauticaDAO = new();

        public List<ZonaNauticaDTO> ObtenerZonaNauticas()
        {
            return zonaNauticaDAO.ObtenerZonaNauticas();
        }

        public string AgregarZonaNautica(ZonaNauticaDTO zonaNauticaDto)
        {
            return zonaNauticaDAO.AgregarZonaNautica(zonaNauticaDto);
        }

        public ZonaNauticaDTO BuscarZonaNauticaID(int Codigo)
        {
            return zonaNauticaDAO.BuscarZonaNauticaID(Codigo);
        }

        public string ActualizarZonaNautica(ZonaNauticaDTO zonaNauticaDto)
        {
            return zonaNauticaDAO.ActualizarZonaNautica(zonaNauticaDto);
        }

        public string EliminarZonaNautica(ZonaNauticaDTO zonaNauticaDto)
        {
            return zonaNauticaDAO.EliminarZonaNautica(zonaNauticaDto);
        }

    }
}
