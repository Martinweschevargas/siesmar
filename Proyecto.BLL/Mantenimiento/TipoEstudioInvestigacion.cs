using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEstudioInvestigacion
    {
        readonly TipoEstudioInvestigacionDAO tipoEstudioInvestigacionDAO = new();

        public List<TipoEstudioInvestigacionDTO> ObtenerTipoEstudioInvestigacions()
        {
            return tipoEstudioInvestigacionDAO.ObtenerTipoEstudioInvestigacions();
        }

        public string AgregarTipoEstudioInvestigacion(TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDto)
        {
            return tipoEstudioInvestigacionDAO.AgregarTipoEstudioInvestigacion(tipoEstudioInvestigacionDto);
        }

        public TipoEstudioInvestigacionDTO BuscarTipoEstudioInvestigacionID(int Codigo)
        {
            return tipoEstudioInvestigacionDAO.BuscarTipoEstudioInvestigacionID(Codigo);
        }

        public string ActualizarTipoEstudioInvestigacion(TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO)
        {
            return tipoEstudioInvestigacionDAO.ActualizarTipoEstudioInvestigacion(tipoEstudioInvestigacionDTO);
        }

        public bool EliminarTipoEstudioInvestigacion(TipoEstudioInvestigacionDTO tipoEstudioInvestigacionDTO)
        {
            return tipoEstudioInvestigacionDAO.EliminarTipoEstudioInvestigacion(tipoEstudioInvestigacionDTO);
        }

    }
}
