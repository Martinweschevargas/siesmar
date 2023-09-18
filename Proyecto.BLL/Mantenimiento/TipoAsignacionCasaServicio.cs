using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAsignacionCasaServicio
    {
        readonly TipoAsignacionCasaServicioDAO TipoAsignacionCasaServicioDAO = new();

        public List<TipoAsignacionCasaServicioDTO> ObtenerTipoAsignacionCasaServicios()
        {
            return TipoAsignacionCasaServicioDAO.ObtenerTipoAsignacionCasaServicios();
        }

        public string AgregarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO tipoAsignacionCasaServicioDto)
        {
            return TipoAsignacionCasaServicioDAO.AgregarTipoAsignacionCasaServicio(tipoAsignacionCasaServicioDto);
        }

        public TipoAsignacionCasaServicioDTO BuscarTipoAsignacionCasaServicioID(int Codigo)
        {
            return TipoAsignacionCasaServicioDAO.BuscarTipoAsignacionCasaServicioID(Codigo);
        }

        public string ActualizarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO tipoAsignacionCasaServicioDto)
        {
            return TipoAsignacionCasaServicioDAO.ActualizarTipoAsignacionCasaServicio(tipoAsignacionCasaServicioDto);
        }

        public string EliminarTipoAsignacionCasaServicio(TipoAsignacionCasaServicioDTO tipoAsignacionCasaServicioDto)
        {
            return TipoAsignacionCasaServicioDAO.EliminarTipoAsignacionCasaServicio(tipoAsignacionCasaServicioDto);
        }

    }
}
