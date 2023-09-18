using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionInspeccionFinalidad
    {
        readonly ClasificacionInspeccionFinalidadDAO clasificacionInspeccionFinalidadDAO = new();

        public List<ClasificacionInspeccionFinalidadDTO> ObtenerClasificacionInspeccionFinalidads()
        {
            return clasificacionInspeccionFinalidadDAO.ObtenerClasificacionInspeccionFinalidads();
        }

        public string AgregarClasificacionInspeccionFinalidad(ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDto)
        {
            return clasificacionInspeccionFinalidadDAO.AgregarClasificacionInspeccionFinalidad(clasificacionInspeccionFinalidadDto);
        }

        public ClasificacionInspeccionFinalidadDTO BuscarClasificacionInspeccionFinalidadID(int Codigo)
        {
            return clasificacionInspeccionFinalidadDAO.BuscarClasificacionInspeccionFinalidadID(Codigo);
        }

        public string ActualizarClasificacionInspeccionFinalidad(ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO)
        {
            return clasificacionInspeccionFinalidadDAO.ActualizarClasificacionInspeccionFinalidad(clasificacionInspeccionFinalidadDTO);
        }

        public bool EliminarClasificacionInspeccionFinalidad(ClasificacionInspeccionFinalidadDTO clasificacionInspeccionFinalidadDTO)
        {
            return clasificacionInspeccionFinalidadDAO.EliminarClasificacionInspeccionFinalidad(clasificacionInspeccionFinalidadDTO);
        }

    }
}
