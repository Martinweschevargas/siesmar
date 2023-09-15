using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionInspeccion
    {
        readonly ClasificacionInspeccionDAO clasificacionInspeccionDAO = new();

        public List<ClasificacionInspeccionDTO> ObtenerClasificacionInspeccions()
        {
            return clasificacionInspeccionDAO.ObtenerClasificacionInspeccions();
        }

        public string AgregarClasificacionInspeccion(ClasificacionInspeccionDTO clasificacionInspeccionDto)
        {
            return clasificacionInspeccionDAO.AgregarClasificacionInspeccion(clasificacionInspeccionDto);
        }

        public ClasificacionInspeccionDTO BuscarClasificacionInspeccionID(int Codigo)
        {
            return clasificacionInspeccionDAO.BuscarClasificacionInspeccionID(Codigo);
        }

        public string ActualizarClasificacionInspeccion(ClasificacionInspeccionDTO clasificacionInspeccionDto)
        {
            return clasificacionInspeccionDAO.ActualizarClasificacionInspeccion(clasificacionInspeccionDto);
        }

        public string EliminarClasificacionInspeccion(ClasificacionInspeccionDTO clasificacionInspeccionDto)
        {
            return clasificacionInspeccionDAO.EliminarClasificacionInspeccion(clasificacionInspeccionDto);
        }

    }
}
