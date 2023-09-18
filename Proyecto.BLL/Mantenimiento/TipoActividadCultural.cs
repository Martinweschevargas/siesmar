using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoActividadCultural
    {
        readonly TipoActividadCulturalDAO tipoActividadCulturalDAO = new();

        public List<TipoActividadCulturalDTO> ObtenerTipoActividadCulturals()
        {
            return tipoActividadCulturalDAO.ObtenerTipoActividadCulturals();
        }

        public string AgregarTipoActividadCultural(TipoActividadCulturalDTO tipoActividadCulturalDto)
        {
            return tipoActividadCulturalDAO.AgregarTipoActividadCultural(tipoActividadCulturalDto);
        }

        public TipoActividadCulturalDTO BuscarTipoActividadCulturalID(int Codigo)
        {
            return tipoActividadCulturalDAO.BuscarTipoActividadCulturalID(Codigo);
        }

        public string ActualizarTipoActividadCultural(TipoActividadCulturalDTO tipoActividadCulturalDTO)
        {
            return tipoActividadCulturalDAO.ActualizarTipoActividadCultural(tipoActividadCulturalDTO);
        }

        public bool EliminarTipoActividadCultural(TipoActividadCulturalDTO tipoActividadCulturalDTO)
        {
            return tipoActividadCulturalDAO.EliminarTipoActividadCultural(tipoActividadCulturalDTO);
        }

    }
}