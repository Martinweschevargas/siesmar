using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoApoyoSocial
    {
        readonly TipoApoyoSocialDAO tipoApoyoSocialDAO = new();

        public List<TipoApoyoSocialDTO> ObtenerTipoApoyoSocials()
        {
            return tipoApoyoSocialDAO.ObtenerTipoApoyoSocials();
        }

        public string AgregarTipoApoyoSocial(TipoApoyoSocialDTO tipoApoyoSocialDto)
        {
            return tipoApoyoSocialDAO.AgregarTipoApoyoSocial(tipoApoyoSocialDto);
        }

        public TipoApoyoSocialDTO BuscarTipoApoyoSocialID(int Codigo)
        {
            return tipoApoyoSocialDAO.BuscarTipoApoyoSocialID(Codigo);
        }

        public string ActualizarTipoApoyoSocial(TipoApoyoSocialDTO tipoApoyoSocialDTO)
        {
            return tipoApoyoSocialDAO.ActualizarTipoApoyoSocial(tipoApoyoSocialDTO);
        }

        public bool EliminarTipoApoyoSocial(TipoApoyoSocialDTO tipoApoyoSocialDTO)
        {
            return tipoApoyoSocialDAO.EliminarTipoApoyoSocial(tipoApoyoSocialDTO);
        }

    }
}
