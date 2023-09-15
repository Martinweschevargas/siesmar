using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoSituacionTramite
    {
        readonly TipoSituacionTramiteDAO tipoSituacionTramiteDAO = new();

        public List<TipoSituacionTramiteDTO> ObtenerTipoSituacionTramites()
        {
            return tipoSituacionTramiteDAO.ObtenerTipoSituacionTramites();
        }

        public string AgregarTipoSituacionTramite(TipoSituacionTramiteDTO tipoSituacionTramiteDto)
        {
            return tipoSituacionTramiteDAO.AgregarTipoSituacionTramite(tipoSituacionTramiteDto);
        }

        public TipoSituacionTramiteDTO BuscarTipoSituacionTramiteID(int Codigo)
        {
            return tipoSituacionTramiteDAO.BuscarTipoSituacionTramiteID(Codigo);
        }

        public string ActualizarTipoSituacionTramite(TipoSituacionTramiteDTO tipoSituacionTramiteDTO)
        {
            return tipoSituacionTramiteDAO.ActualizarTipoSituacionTramite(tipoSituacionTramiteDTO);
        }

        public bool EliminarTipoSituacionTramite(TipoSituacionTramiteDTO tipoSituacionTramiteDTO)
        {
            return tipoSituacionTramiteDAO.EliminarTipoSituacionTramite(tipoSituacionTramiteDTO);
        }

    }
}
