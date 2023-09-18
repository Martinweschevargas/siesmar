using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoServicio
    {
        readonly TipoServicioDAO tipoServicioDAO = new();

        public List<TipoServicioDTO> ObtenerTipoServicios()
        {
            return tipoServicioDAO.ObtenerTipoServicios();
        }

        public string AgregarTipoServicio(TipoServicioDTO tipoServicioDto)
        {
            return tipoServicioDAO.AgregarTipoServicio(tipoServicioDto);
        }

        public TipoServicioDTO BuscarTipoServicioID(int Codigo)
        {
            return tipoServicioDAO.BuscarTipoServicioID(Codigo);
        }

        public string ActualizarTipoServicio(TipoServicioDTO tipoServicioDTO)
        {
            return tipoServicioDAO.ActualizarTipoServicio(tipoServicioDTO);
        }

        public bool EliminarTipoServicio(TipoServicioDTO tipoServicioDTO)
        {
            return tipoServicioDAO.EliminarTipoServicio(tipoServicioDTO);
        }

    }
}
