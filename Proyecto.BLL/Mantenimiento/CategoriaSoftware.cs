using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CategoriaSoftware
    {
        readonly CategoriaSoftwareDAO categoriaSoftwareDAO = new();

        public List<CategoriaSoftwareDTO> ObtenerCategoriaSoftwares()
        {
            return categoriaSoftwareDAO.ObtenerCategoriaSoftwares();
        }

        public string AgregarCategoriaSoftware(CategoriaSoftwareDTO categoriaSoftwareDto)
        {
            return categoriaSoftwareDAO.AgregarCategoriaSoftware(categoriaSoftwareDto);
        }

        public CategoriaSoftwareDTO BuscarCategoriaSoftwareID(int Codigo)
        {
            return categoriaSoftwareDAO.BuscarCategoriaSoftwareID(Codigo);
        }

        public string ActualizarCategoriaSoftware(CategoriaSoftwareDTO categoriaSoftwareDto)
        {
            return categoriaSoftwareDAO.ActualizarCategoriaSoftware(categoriaSoftwareDto);
        }

        public string EliminarCategoriaSoftware(CategoriaSoftwareDTO categoriaSoftwareDto)
        {
            return categoriaSoftwareDAO.EliminarCategoriaSoftware(categoriaSoftwareDto);
        }

    }
}
