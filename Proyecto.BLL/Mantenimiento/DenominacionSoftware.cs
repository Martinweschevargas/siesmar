using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DenominacionSoftware
    {
        readonly DenominacionSoftwareDAO denominacionSoftwareDAO = new();

        public List<DenominacionSoftwareDTO> ObtenerDenominacionSoftwares()
        {
            return denominacionSoftwareDAO.ObtenerDenominacionSoftwares();
        }

        public string AgregarDenominacionSoftware(DenominacionSoftwareDTO denominacionSoftwareDto)
        {
            return denominacionSoftwareDAO.AgregarDenominacionSoftware(denominacionSoftwareDto);
        }

        public DenominacionSoftwareDTO BuscarDenominacionSoftwareID(int Codigo)
        {
            return denominacionSoftwareDAO.BuscarDenominacionSoftwareID(Codigo);
        }

        public string ActualizarDenominacionSoftware(DenominacionSoftwareDTO denominacionSoftwareDto)
        {
            return denominacionSoftwareDAO.ActualizarDenominacionSoftware(denominacionSoftwareDto);
        }

        public string EliminarDenominacionSoftware(DenominacionSoftwareDTO denominacionSoftwareDto)
        {
            return denominacionSoftwareDAO.EliminarDenominacionSoftware(denominacionSoftwareDto);
        }

    }
}
