using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAfiliacion
    {
        readonly TipoAfiliacionDAO tipoAfiliacionDAO = new();

        public List<TipoAfiliacionDTO> ObtenerTipoAfiliacions()
        {
            return tipoAfiliacionDAO.ObtenerTipoAfiliacions();
        }

        public string AgregarTipoAfiliacion(TipoAfiliacionDTO tipoAfiliacionDto)
        {
            return tipoAfiliacionDAO.AgregarTipoAfiliacion(tipoAfiliacionDto);
        }

        public TipoAfiliacionDTO BuscarTipoAfiliacionID(int Codigo)
        {
            return tipoAfiliacionDAO.BuscarTipoAfiliacionID(Codigo);
        }

        public string ActualizarTipoAfiliacion(TipoAfiliacionDTO tipoAfiliacionDto)
        {
            return tipoAfiliacionDAO.ActualizarTipoAfiliacion(tipoAfiliacionDto);
        }

        public string EliminarTipoAfiliacion(TipoAfiliacionDTO tipoAfiliacionDto)
        {
            return tipoAfiliacionDAO.EliminarTipoAfiliacion(tipoAfiliacionDto);
        }

    }
}
