using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionInspeccionExtension
    {
        readonly ClasificacionInspeccionExtensionDAO clasificacionInspeccionExtensionDAO = new();

        public List<ClasificacionInspeccionExtensionDTO> ObtenerClasificacionInspeccionExtensions()
        {
            return clasificacionInspeccionExtensionDAO.ObtenerClasificacionInspeccionExtensions();
        }

        public string AgregarClasificacionInspeccionExtension(ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDto)
        {
            return clasificacionInspeccionExtensionDAO.AgregarClasificacionInspeccionExtension(clasificacionInspeccionExtensionDto);
        }

        public ClasificacionInspeccionExtensionDTO BuscarClasificacionInspeccionExtensionID(int Codigo)
        {
            return clasificacionInspeccionExtensionDAO.BuscarClasificacionInspeccionExtensionID(Codigo);
        }

        public string ActualizarClasificacionInspeccionExtension(ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO)
        {
            return clasificacionInspeccionExtensionDAO.ActualizarClasificacionInspeccionExtension(clasificacionInspeccionExtensionDTO);
        }

        public bool EliminarClasificacionInspeccionExtension(ClasificacionInspeccionExtensionDTO clasificacionInspeccionExtensionDTO)
        {
            return clasificacionInspeccionExtensionDAO.EliminarClasificacionInspeccionExtension(clasificacionInspeccionExtensionDTO);
        }

    }
}
