using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InspeccionExtension
    {
        readonly InspeccionExtensionDAO inspeccionExtensionDAO = new();

        public List<InspeccionExtensionDTO> ObtenerInspeccionExtensions()
        {
            return inspeccionExtensionDAO.ObtenerInspeccionExtensions();
        }

        public string AgregarInspeccionExtension(InspeccionExtensionDTO inspeccionExtensionDto)
        {
            return inspeccionExtensionDAO.AgregarInspeccionExtension(inspeccionExtensionDto);
        }

        public InspeccionExtensionDTO BuscarInspeccionExtensionID(int Codigo)
        {
            return inspeccionExtensionDAO.BuscarInspeccionExtensionID(Codigo);
        }

        public string ActualizarInspeccionExtension(InspeccionExtensionDTO inspeccionExtensionDto)
        {
            return inspeccionExtensionDAO.ActualizarInspeccionExtension(inspeccionExtensionDto);
        }

        public string EliminarInspeccionExtension(InspeccionExtensionDTO inspeccionExtensionDto)
        {
            return inspeccionExtensionDAO.EliminarInspeccionExtension(inspeccionExtensionDto);
        }

    }
}
