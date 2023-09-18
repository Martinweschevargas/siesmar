using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClaseInversion
    {
        readonly ClaseInversionDAO claseInversionDAO = new();

        public List<ClaseInversionDTO> ObtenerClaseInversions()
        {
            return claseInversionDAO.ObtenerClaseInversions();
        }

        public string AgregarClaseInversion(ClaseInversionDTO claseInversionDto)
        {
            return claseInversionDAO.AgregarClaseInversion(claseInversionDto);
        }

        public ClaseInversionDTO BuscarClaseInversionID(int Codigo)
        {
            return claseInversionDAO.BuscarClaseInversionID(Codigo);
        }

        public string ActualizarClaseInversion(ClaseInversionDTO claseInversionDto)
        {
            return claseInversionDAO.ActualizarClaseInversion(claseInversionDto);
        }

        public string EliminarClaseInversion(ClaseInversionDTO claseInversionDto)
        {
            return claseInversionDAO.EliminarClaseInversion(claseInversionDto);
        }

    }
}
