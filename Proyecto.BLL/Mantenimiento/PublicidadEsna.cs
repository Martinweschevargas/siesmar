using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PublicidadEsna
    {
        readonly PublicidadEsnaDAO publicidadEsnaDAO = new();

        public List<PublicidadEsnaDTO> ObtenerPublicidadEsnas()
        {
            return publicidadEsnaDAO.ObtenerPublicidadEsnas();
        }

        public string AgregarPublicidadEsna(PublicidadEsnaDTO publicidadEsnaDto)
        {
            return publicidadEsnaDAO.AgregarPublicidadEsna(publicidadEsnaDto);
        }

        public PublicidadEsnaDTO BuscarPublicidadEsnaID(int Codigo)
        {
            return publicidadEsnaDAO.BuscarPublicidadEsnaID(Codigo);
        }

        public string ActualizarPublicidadEsna(PublicidadEsnaDTO publicidadEsnaDTO)
        {
            return publicidadEsnaDAO.ActualizarPublicidadEsna(publicidadEsnaDTO);
        }

        public string EliminarPublicidadEsna(PublicidadEsnaDTO publicidadEsnaDTO)
        {
            return publicidadEsnaDAO.EliminarPublicidadEsna(publicidadEsnaDTO);
        }

    }
}
