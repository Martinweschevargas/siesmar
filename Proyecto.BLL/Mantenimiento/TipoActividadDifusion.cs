using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoActividadDifusion
    {
        readonly TipoActividadDifusionDAO tipoActividadDifusionDAO = new();

        public List<TipoActividadDifusionDTO> ObtenerTipoActividadDifusions()
        {
            return tipoActividadDifusionDAO.ObtenerTipoActividadDifusions();
        }

        public string AgregarTipoActividadDifusion(TipoActividadDifusionDTO tipoActividadDifusionDto)
        {
            return tipoActividadDifusionDAO.AgregarTipoActividadDifusion(tipoActividadDifusionDto);
        }

        public TipoActividadDifusionDTO BuscarTipoActividadDifusionID(int Codigo)
        {
            return tipoActividadDifusionDAO.BuscarTipoActividadDifusionID(Codigo);
        }

        public string ActualizarTipoActividadDifusion(TipoActividadDifusionDTO tipoActividadDifusionDTO)
        {
            return tipoActividadDifusionDAO.ActualizarTipoActividadDifusion(tipoActividadDifusionDTO);
        }

        public bool EliminarTipoActividadDifusion(TipoActividadDifusionDTO tipoActividadDifusionDTO)
        {
            return tipoActividadDifusionDAO.EliminarTipoActividadDifusion(tipoActividadDifusionDTO);
        }

    }
}