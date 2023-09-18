using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoActividad
    {
        readonly TipoActividadDAO tipoActividadDAO = new();

        public List<TipoActividadDTO> ObtenerTipoActividads()
        {
            return tipoActividadDAO.ObtenerTipoActividads();
        }

        public string AgregarTipoActividad(TipoActividadDTO tipoActividadDto)
        {
            return tipoActividadDAO.AgregarTipoActividad(tipoActividadDto);
        }

        public TipoActividadDTO BuscarTipoActividadID(int Codigo)
        {
            return tipoActividadDAO.BuscarTipoActividadID(Codigo);
        }

        public string ActualizarTipoActividad(TipoActividadDTO tipoActividadDto)
        {
            return tipoActividadDAO.ActualizarTipoActividad(tipoActividadDto);
        }

        public string EliminarTipoActividad(TipoActividadDTO tipoActividadDto)
        {
            return tipoActividadDAO.EliminarTipoActividad(tipoActividadDto);
        }

    }
}
