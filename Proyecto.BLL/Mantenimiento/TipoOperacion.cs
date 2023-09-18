using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoOperacion
    {
        readonly TipoOperacionDAO tipoOperacionDAO = new();

        public List<TipoOperacionDTO> ObtenerTipoOperacions()
        {
            return tipoOperacionDAO.ObtenerTipoOperacions();
        }

        public string AgregarTipoOperacion(TipoOperacionDTO tipoOperacionDto)
        {
            return tipoOperacionDAO.AgregarTipoOperacion(tipoOperacionDto);
        }

        public TipoOperacionDTO BuscarTipoOperacionID(int Codigo)
        {
            return tipoOperacionDAO.BuscarTipoOperacionID(Codigo);
        }

        public string ActualizarTipoOperacion(TipoOperacionDTO tipoOperacionDTO)
        {
            return tipoOperacionDAO.ActualizarTipoOperacion(tipoOperacionDTO);
        }

        public string EliminarTipoOperacion(TipoOperacionDTO tipoOperacionDTO)
        {
            return tipoOperacionDAO.EliminarTipoOperacion(tipoOperacionDTO);
        }


    }
}
