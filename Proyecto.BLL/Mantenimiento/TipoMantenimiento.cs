using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoMantenimiento
    {
        readonly TipoMantenimientoDAO tipoMantenimientoDAO = new();

        public List<TipoMantenimientoDTO> ObtenerTipoMantenimientos()
        {
            return tipoMantenimientoDAO.ObtenerTipoMantenimientos();
        }

        public string AgregarTipoMantenimiento(TipoMantenimientoDTO tipoMantenimientoDto)
        {
            return tipoMantenimientoDAO.AgregarTipoMantenimiento(tipoMantenimientoDto);
        }

        public TipoMantenimientoDTO BuscarTipoMantenimientoID(int Codigo)
        {
            return tipoMantenimientoDAO.BuscarTipoMantenimientoID(Codigo);
        }

        public string ActualizarTipoMantenimiento(TipoMantenimientoDTO tipoMantenimientoDTO)
        {
            return tipoMantenimientoDAO.ActualizarTipoMantenimiento(tipoMantenimientoDTO);
        }

        public bool EliminarTipoMantenimiento(TipoMantenimientoDTO tipoMantenimientoDTO)
        {
            return tipoMantenimientoDAO.EliminarTipoMantenimiento(tipoMantenimientoDTO);
        }

    }
}
