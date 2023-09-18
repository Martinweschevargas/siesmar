using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CicloDesarrolloSoftware
    {
        readonly CicloDesarrolloSoftwareDAO cicloDesarrolloSoftwareDAO = new();

        public List<CicloDesarrolloSoftwareDTO> ObtenerCicloDesarrolloSoftwares()
        {
            return cicloDesarrolloSoftwareDAO.ObtenerCicloDesarrolloSoftwares();
        }

        public string AgregarCicloDesarrolloSoftware(CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDto)
        {
            return cicloDesarrolloSoftwareDAO.AgregarCicloDesarrolloSoftware(cicloDesarrolloSoftwareDto);
        }

        public CicloDesarrolloSoftwareDTO BuscarCicloDesarrolloSoftwareID(int Codigo)
        {
            return cicloDesarrolloSoftwareDAO.BuscarCicloDesarrolloSoftwareID(Codigo);
        }

        public string ActualizarCicloDesarrolloSoftware(CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO)
        {
            return cicloDesarrolloSoftwareDAO.ActualizarCicloDesarrolloSoftware(cicloDesarrolloSoftwareDTO);
        }

        public string EliminarCicloDesarrolloSoftware(CicloDesarrolloSoftwareDTO cicloDesarrolloSoftwareDTO)
        {
            return cicloDesarrolloSoftwareDAO.EliminarCicloDesarrolloSoftware(cicloDesarrolloSoftwareDTO);
        }

    }
}
