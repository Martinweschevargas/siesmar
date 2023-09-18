using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClasificacionInspeccionConocimiento
    {
        readonly ClasificacionInspeccionConocimientoDAO clasificacionInspeccionConocimientoDAO = new();

        public List<ClasificacionInspeccionConocimientoDTO> ObtenerClasificacionInspeccionConocimientos()
        {
            return clasificacionInspeccionConocimientoDAO.ObtenerClasificacionInspeccionConocimientos();
        }

        public string AgregarClasificacionInspeccionConocimiento(ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDto)
        {
            return clasificacionInspeccionConocimientoDAO.AgregarClasificacionInspeccionConocimiento(clasificacionInspeccionConocimientoDto);
        }

        public ClasificacionInspeccionConocimientoDTO BuscarClasificacionInspeccionConocimientoID(int Codigo)
        {
            return clasificacionInspeccionConocimientoDAO.BuscarClasificacionInspeccionConocimientoID(Codigo);
        }

        public string ActualizarClasificacionInspeccionConocimiento(ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO)
        {
            return clasificacionInspeccionConocimientoDAO.ActualizarClasificacionInspeccionConocimiento(clasificacionInspeccionConocimientoDTO);
        }

        public bool EliminarClasificacionInspeccionConocimiento(ClasificacionInspeccionConocimientoDTO clasificacionInspeccionConocimientoDTO)
        {
            return clasificacionInspeccionConocimientoDAO.EliminarClasificacionInspeccionConocimiento(clasificacionInspeccionConocimientoDTO);
        }

    }
}
