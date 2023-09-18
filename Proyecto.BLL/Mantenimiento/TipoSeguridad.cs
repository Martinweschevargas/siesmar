using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoSeguridad
    {
        readonly TipoSeguridadDAO tipoSeguridadDAO = new();

        public List<TipoSeguridadDTO> ObtenerTipoSeguridads()
        {
            return tipoSeguridadDAO.ObtenerTipoSeguridads();
        }

        public string AgregarTipoSeguridad(TipoSeguridadDTO tipoSeguridadDto)
        {
            return tipoSeguridadDAO.AgregarTipoSeguridad(tipoSeguridadDto);
        }

        public TipoSeguridadDTO BuscarTipoSeguridadID(int Codigo)
        {
            return tipoSeguridadDAO.BuscarTipoSeguridadID(Codigo);
        }

        public string ActualizarTipoSeguridad(TipoSeguridadDTO tipoSeguridadDTO)
        {
            return tipoSeguridadDAO.ActualizarTipoSeguridad(tipoSeguridadDTO);
        }

        public bool EliminarTipoSeguridad(TipoSeguridadDTO tipoSeguridadDTO)
        {
            return tipoSeguridadDAO.EliminarTipoSeguridad(tipoSeguridadDTO);
        }

    }
}
