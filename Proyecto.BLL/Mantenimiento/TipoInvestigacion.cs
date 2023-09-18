using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoInvestigacion
    {
        readonly TipoInvestigacionDAO tipoInvestigacionDAO = new();

        public List<TipoInvestigacionDTO> ObtenerTipoInvestigacions()
        {
            return tipoInvestigacionDAO.ObtenerTipoInvestigacions();
        }

        public string AgregarTipoInvestigacion(TipoInvestigacionDTO tipoInvestigacionDto)
        {
            return tipoInvestigacionDAO.AgregarTipoInvestigacion(tipoInvestigacionDto);
        }

        public TipoInvestigacionDTO BuscarTipoInvestigacionID(int Codigo)
        {
            return tipoInvestigacionDAO.BuscarTipoInvestigacionID(Codigo);
        }

        public string ActualizarTipoInvestigacion(TipoInvestigacionDTO tipoInvestigacionDTO)
        {
            return tipoInvestigacionDAO.ActualizarTipoInvestigacion(tipoInvestigacionDTO);
        }

        public bool EliminarTipoInvestigacion(TipoInvestigacionDTO tipoInvestigacionDTO)
        {
            return tipoInvestigacionDAO.EliminarTipoInvestigacion(tipoInvestigacionDTO);
        }

    }
}
