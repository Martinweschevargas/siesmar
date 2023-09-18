using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class OrganoControlInspeccion
    {
        readonly OrganoControlInspeccionDAO organoControlInspeccionDAO = new();

        public List<OrganoControlInspeccionDTO> ObtenerOrganoControlInspeccions()
        {
            return organoControlInspeccionDAO.ObtenerOrganoControlInspeccions();
        }

        public string AgregarOrganoControlInspeccion(OrganoControlInspeccionDTO organoControlInspeccionDto)
        {
            return organoControlInspeccionDAO.AgregarOrganoControlInspeccion(organoControlInspeccionDto);
        }

        public OrganoControlInspeccionDTO BuscarOrganoControlInspeccionID(int Codigo)
        {
            return organoControlInspeccionDAO.BuscarOrganoControlInspeccionID(Codigo);
        }

        public string ActualizarOrganoControlInspeccion(OrganoControlInspeccionDTO organoControlInspeccionDto)
        {
            return organoControlInspeccionDAO.ActualizarOrganoControlInspeccion(organoControlInspeccionDto);
        }

        public string EliminarOrganoControlInspeccion(OrganoControlInspeccionDTO organoControlInspeccionDto)
        {
            return organoControlInspeccionDAO.EliminarOrganoControlInspeccion(organoControlInspeccionDto);
        }

    }
}
