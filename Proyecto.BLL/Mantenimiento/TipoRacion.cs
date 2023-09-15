using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoRacion
    {
        readonly TipoRacionDAO tipoRacionDAO = new();

        public List<TipoRacionDTO> ObtenerTipoRacions()
        {
            return tipoRacionDAO.ObtenerTipoRacions();
        }

        public string AgregarTipoRacion(TipoRacionDTO tipoRacionDto)
        {
            return tipoRacionDAO.AgregarTipoRacion(tipoRacionDto);
        }

        public TipoRacionDTO BuscarTipoRacionID(int Codigo)
        {
            return tipoRacionDAO.BuscarTipoRacionID(Codigo);
        }

        public string ActualizarTipoRacion(TipoRacionDTO tipoRacionDto)
        {
            return tipoRacionDAO.ActualizarTipoRacion(tipoRacionDto);
        }

        public string EliminarTipoRacion(TipoRacionDTO tipoRacionDto)
        {
            return tipoRacionDAO.EliminarTipoRacion(tipoRacionDto);
        }

    }
}