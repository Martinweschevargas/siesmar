using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoDesplazamiento
    {
        readonly TipoDesplazamientoDAO tipoDesplazamientoDAO = new();

        public List<TipoDesplazamientoDTO> ObtenerTipoDesplazamientos()
        {
            return tipoDesplazamientoDAO.ObtenerTipoDesplazamientos();
        }

        public string AgregarTipoDesplazamiento(TipoDesplazamientoDTO tipoDesplazamientoDto)
        {
            return tipoDesplazamientoDAO.AgregarTipoDesplazamiento(tipoDesplazamientoDto);
        }

        public TipoDesplazamientoDTO BuscarTipoDesplazamientoID(int Codigo)
        {
            return tipoDesplazamientoDAO.BuscarTipoDesplazamientoID(Codigo);
        }

        public string ActualizarTipoDesplazamiento(TipoDesplazamientoDTO tipoDesplazamientoDto)
        {
            return tipoDesplazamientoDAO.ActualizarTipoDesplazamiento(tipoDesplazamientoDto);
        }

        public string EliminarTipoDesplazamiento(TipoDesplazamientoDTO tipoDesplazamientoDto)
        {
            return tipoDesplazamientoDAO.EliminarTipoDesplazamiento(tipoDesplazamientoDto);
        }

    }
}
