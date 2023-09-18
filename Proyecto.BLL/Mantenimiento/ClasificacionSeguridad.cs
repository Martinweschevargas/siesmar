using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionSeguridad
    {
        readonly ClasificacionSeguridadDAO clasificacionSeguridadDAO = new();

        public List<ClasificacionSeguridadDTO> ObtenerClasificacionSeguridads()
        {
            return clasificacionSeguridadDAO.ObtenerClasificacionSeguridads();
        }

        public string AgregarClasificacionSeguridad(ClasificacionSeguridadDTO clasificacionSeguridadDto)
        {
            return clasificacionSeguridadDAO.AgregarClasificacionSeguridad(clasificacionSeguridadDto);
        }

        public ClasificacionSeguridadDTO BuscarClasificacionSeguridadID(int Codigo)
        {
            return clasificacionSeguridadDAO.BuscarClasificacionSeguridadID(Codigo);
        }

        public string ActualizarClasificacionSeguridad(ClasificacionSeguridadDTO clasificacionSeguridadDto)
        {
            return clasificacionSeguridadDAO.ActualizarClasificacionSeguridad(clasificacionSeguridadDto);
        }

        public string EliminarClasificacionSeguridad(ClasificacionSeguridadDTO clasificacionSeguridadDto)
        {
            return clasificacionSeguridadDAO.EliminarClasificacionSeguridad(clasificacionSeguridadDto);
        }

    }
}
