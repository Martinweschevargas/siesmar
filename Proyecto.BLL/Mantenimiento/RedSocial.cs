using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class RedSocial
    {
        readonly RedSocialDAO redSocialDAO = new();

        public List<RedSocialDTO> ObtenerRedSocials()
        {
            return redSocialDAO.ObtenerRedSocials();
        }

        public string AgregarRedSocial(RedSocialDTO redSocialDto)
        {
            return redSocialDAO.AgregarRedSocial(redSocialDto);
        }

        public RedSocialDTO BuscarRedSocialID(int Codigo)
        {
            return redSocialDAO.BuscarRedSocialID(Codigo);
        }

        public string ActualizarRedSocial(RedSocialDTO redSocialDto)
        {
            return redSocialDAO.ActualizarRedSocial(redSocialDto);
        }

        public string EliminarRedSocial(RedSocialDTO redSocialDto)
        {
            return redSocialDAO.EliminarRedSocial(redSocialDto);
        }

    }
}
