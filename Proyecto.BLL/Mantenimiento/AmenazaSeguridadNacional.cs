using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AmenazaSeguridadNacional
    {
        readonly AmenazaSeguridadNacionalDAO AmenazaSeguridadNacionalDAO = new();

        public List<AmenazaSeguridadNacionalDTO> ObtenerAmenazaSeguridadNacionals()
        {
            return AmenazaSeguridadNacionalDAO.ObtenerAmenazaSeguridadNacionals();
        }

        public string AgregarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO amenazaSeguridadNacionalDto)
        {
            return AmenazaSeguridadNacionalDAO.AgregarAmenazaSeguridadNacional(amenazaSeguridadNacionalDto);
        }

        public AmenazaSeguridadNacionalDTO BuscarAmenazaSeguridadNacionalID(int Codigo)
        {
            return AmenazaSeguridadNacionalDAO.BuscarAmenazaSeguridadNacionalID(Codigo);
        }

        public string ActualizarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO amenazaSeguridadNacionalDto)
        {
            return AmenazaSeguridadNacionalDAO.ActualizarAmenazaSeguridadNacional(amenazaSeguridadNacionalDto);
        }

        public string EliminarAmenazaSeguridadNacional(AmenazaSeguridadNacionalDTO amenazaSeguridadNacionalDto)
        {
            return AmenazaSeguridadNacionalDAO.EliminarAmenazaSeguridadNacional(amenazaSeguridadNacionalDto);
        }

    }
}
