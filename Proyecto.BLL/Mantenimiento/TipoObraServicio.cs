using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoObraServicio
    {
        readonly TipoObraServicioDAO tipoObraServicioDAO = new();

        public List<TipoObraServicioDTO> ObtenerTipoObraServicios()
        {
            return tipoObraServicioDAO.ObtenerTipoObraServicios();
        }

        public string AgregarTipoObraServicio(TipoObraServicioDTO tipoObraServicioDto)
        {
            return tipoObraServicioDAO.AgregarTipoObraServicio(tipoObraServicioDto);
        }

        public TipoObraServicioDTO BuscarTipoObraServicioID(int Codigo)
        {
            return tipoObraServicioDAO.BuscarTipoObraServicioID(Codigo);
        }

        public string ActualizarTipoObraServicio(TipoObraServicioDTO tipoObraServicioDTO)
        {
            return tipoObraServicioDAO.ActualizarTipoObraServicio(tipoObraServicioDTO);
        }

        public bool EliminarTipoObraServicio(TipoObraServicioDTO tipoObraServicioDTO)
        {
            return tipoObraServicioDAO.EliminarTipoObraServicio(tipoObraServicioDTO);
        }

    }
}
