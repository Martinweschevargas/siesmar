using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoPublicacion
    {
        readonly TipoPublicacionDAO tipoPublicacionDAO = new();

        public List<TipoPublicacionDTO> ObtenerTipoPublicacions()
        {
            return tipoPublicacionDAO.ObtenerTipoPublicacions();
        }

        public string AgregarTipoPublicacion(TipoPublicacionDTO tipoPublicacionDto)
        {
            return tipoPublicacionDAO.AgregarTipoPublicacion(tipoPublicacionDto);
        }

        public TipoPublicacionDTO BuscarTipoPublicacionID(int Codigo)
        {
            return tipoPublicacionDAO.BuscarTipoPublicacionID(Codigo);
        }

        public string ActualizarTipoPublicacion(TipoPublicacionDTO tipoPublicacionDTO)
        {
            return tipoPublicacionDAO.ActualizarTipoPublicacion(tipoPublicacionDTO);
        }

        public bool EliminarTipoPublicacion(TipoPublicacionDTO tipoPublicacionDTO)
        {
            return tipoPublicacionDAO.EliminarTipoPublicacion(tipoPublicacionDTO);
        }

    }
}