using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoInformacion
    {
        readonly TipoInformacionDAO tipoInformacionDAO = new();

        public List<TipoInformacionDTO> ObtenerTipoInformacions()
        {
            return tipoInformacionDAO.ObtenerTipoInformacions();
        }

        public string AgregarTipoInformacion(TipoInformacionDTO tipoInformacionDto)
        {
            return tipoInformacionDAO.AgregarTipoInformacion(tipoInformacionDto);
        }

        public TipoInformacionDTO BuscarTipoInformacionID(int Codigo)
        {
            return tipoInformacionDAO.BuscarTipoInformacionID(Codigo);
        }

        public string ActualizarTipoInformacion(TipoInformacionDTO tipoInformacionDTO)
        {
            return tipoInformacionDAO.ActualizarTipoInformacion(tipoInformacionDTO);
        }

        public bool EliminarTipoInformacion(TipoInformacionDTO tipoInformacionDTO)
        {
            return tipoInformacionDAO.EliminarTipoInformacion(tipoInformacionDTO);
        }

    }
}
