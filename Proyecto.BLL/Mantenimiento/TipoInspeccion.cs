using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoInspeccion
    {
        readonly TipoInspeccionDAO tipoInspeccionDAO = new();

        public List<TipoInspeccionDTO> ObtenerTipoInspeccions()
        {
            return tipoInspeccionDAO.ObtenerTipoInspeccions();
        }

        public string AgregarTipoInspeccion(TipoInspeccionDTO tipoInspeccionDto)
        {
            return tipoInspeccionDAO.AgregarTipoInspeccion(tipoInspeccionDto);
        }

        public TipoInspeccionDTO BuscarTipoInspeccionID(int Codigo)
        {
            return tipoInspeccionDAO.BuscarTipoInspeccionID(Codigo);
        }

        public string ActualizarTipoInspeccion(TipoInspeccionDTO tipoInspeccionDTO)
        {
            return tipoInspeccionDAO.ActualizarTipoInspeccion(tipoInspeccionDTO);
        }

        public bool EliminarTipoInspeccion(TipoInspeccionDTO tipoInspeccionDTO)
        {
            return tipoInspeccionDAO.EliminarTipoInspeccion(tipoInspeccionDTO);
        }

    }
}
