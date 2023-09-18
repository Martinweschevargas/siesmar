using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoActividadDenominacion
    {
        readonly TipoActividadDenominacionDAO tipoActividadDenominacionDAO = new();

        public List<TipoActividadDenominacionDTO> ObtenerTipoActividadDenominacions()
        {
            return tipoActividadDenominacionDAO.ObtenerTipoActividadDenominacions();
        }

        public string AgregarTipoActividadDenominacion(TipoActividadDenominacionDTO tipoActividadDenominacionDto)
        {
            return tipoActividadDenominacionDAO.AgregarTipoActividadDenominacion(tipoActividadDenominacionDto);
        }

        public TipoActividadDenominacionDTO BuscarTipoActividadDenominacionID(int Codigo)
        {
            return tipoActividadDenominacionDAO.BuscarTipoActividadDenominacionID(Codigo);
        }

        public string ActualizarTipoActividadDenominacion(TipoActividadDenominacionDTO tipoActividadDenominacionDto)
        {
            return tipoActividadDenominacionDAO.ActualizarTipoActividadDenominacion(tipoActividadDenominacionDto);
        }

        public string EliminarTipoActividadDenominacion(TipoActividadDenominacionDTO tipoActividadDenominacionDto)
        {
            return tipoActividadDenominacionDAO.EliminarTipoActividadDenominacion(tipoActividadDenominacionDto);
        }

    }
}
