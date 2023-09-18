using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CausalTramiteAlta
    {
        readonly CausalTramiteAltaDAO causalTramiteAltaDAO = new();

        public List<CausalTramiteAltaDTO> ObtenerCausalTramiteAltas()
        {
            return causalTramiteAltaDAO.ObtenerCausalTramiteAltas();
        }

        public string AgregarCausalTramiteAlta(CausalTramiteAltaDTO causalTramiteAltaDto)
        {
            return causalTramiteAltaDAO.AgregarCausalTramiteAlta(causalTramiteAltaDto);
        }

        public CausalTramiteAltaDTO BuscarCausalTramiteAltaID(int Codigo)
        {
            return causalTramiteAltaDAO.BuscarCausalTramiteAltaID(Codigo);
        }

        public string ActualizarCausalTramiteAlta(CausalTramiteAltaDTO causalTramiteAltaDto)
        {
            return causalTramiteAltaDAO.ActualizarCausalTramiteAlta(causalTramiteAltaDto);
        }

        public string EliminarCausalTramiteAlta(CausalTramiteAltaDTO causalTramiteAltaDto)
        {
            return causalTramiteAltaDAO.EliminarCausalTramiteAlta(causalTramiteAltaDto);
        }

    }
}
