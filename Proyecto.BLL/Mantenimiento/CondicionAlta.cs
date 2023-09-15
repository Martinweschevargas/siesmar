using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionAlta
    {
        readonly CondicionAltaDAO condicionAltaDAO = new();

        public List<CondicionAltaDTO> ObtenerCondicionAltas()
        {
            return condicionAltaDAO.ObtenerCondicionAltas();
        }

        public string AgregarCondicionAlta(CondicionAltaDTO condicionAltaDto)
        {
            return condicionAltaDAO.AgregarCondicionAlta(condicionAltaDto);
        }

        public CondicionAltaDTO BuscarCondicionAltaID(int Codigo)
        {
            return condicionAltaDAO.BuscarCondicionAltaID(Codigo);
        }

        public string ActualizarCondicionAlta(CondicionAltaDTO condicionAltaDto)
        {
            return condicionAltaDAO.ActualizarCondicionAlta(condicionAltaDto);
        }

        public string EliminarCondicionAlta(CondicionAltaDTO condicionAltaDto)
        {
            return condicionAltaDAO.EliminarCondicionAlta(condicionAltaDto);
        }

    }
}
