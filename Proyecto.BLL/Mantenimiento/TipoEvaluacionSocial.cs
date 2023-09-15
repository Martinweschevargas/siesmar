using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEvaluacionSocial
    {
        readonly TipoEvaluacionSocialDAO tipoEvaluacionSocialDAO = new();

        public List<TipoEvaluacionSocialDTO> ObtenerTipoEvaluacionSocials()
        {
            return tipoEvaluacionSocialDAO.ObtenerTipoEvaluacionSocials();
        }

        public string AgregarTipoEvaluacionSocial(TipoEvaluacionSocialDTO tipoEvaluacionSocialDto)
        {
            return tipoEvaluacionSocialDAO.AgregarTipoEvaluacionSocial(tipoEvaluacionSocialDto);
        }

        public TipoEvaluacionSocialDTO BuscarTipoEvaluacionSocialID(int Codigo)
        {
            return tipoEvaluacionSocialDAO.BuscarTipoEvaluacionSocialID(Codigo);
        }

        public string ActualizarTipoEvaluacionSocial(TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO)
        {
            return tipoEvaluacionSocialDAO.ActualizarTipoEvaluacionSocial(tipoEvaluacionSocialDTO);
        }

        public bool EliminarTipoEvaluacionSocial(TipoEvaluacionSocialDTO tipoEvaluacionSocialDTO)
        {
            return tipoEvaluacionSocialDAO.EliminarTipoEvaluacionSocial(tipoEvaluacionSocialDTO);
        }

    }
}
